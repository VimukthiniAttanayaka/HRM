using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using HRM;
using AspNetCore.Reporting;
using HRM_DAL.ReportModels;
using System.Text.Json;
using IronXL;

namespace HRM_DAL.Data
{
    public class Reports_Data
    {
        private static LogError objError = new LogError();
        public static string GetSavingFineName(string reportName, string cUS_ID)
        {
            string RequestReferenceID = System.DateTime.Now.ToString("ddMMyyyyHHmmss");
            string filename = reportName + "_" + cUS_ID + "_" + RequestReferenceID;
            return filename;
        }

        public static List<ReportsReturnResponse> MailbagDailyActivityReports(MailbagDailyActivityRequestModel model)
        {
            List<ReportsReturnResponse> objUserHeadList = new List<ReportsReturnResponse>();
            ReportsReturnResponse objUserHead = new ReportsReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objUserHead.resp = false;
                objUserHead.IsAuthenticated = false;
                objUserHeadList.Add(objUserHead);
                return objUserHeadList;
            }

            try
            {
                string reportName = "MailbagDailyActivityReports";
                ReportService _reportService = new ReportService();
                LocalReport rep = _reportService.SetupReport(reportName);

                List<HRM_DAL.ReportModels.MailbagDailyActivityModel> repMod = new List<ReportModels.MailbagDailyActivityModel>();

                repMod = LoadData_MailbagDailyActivity(model);

                rep.AddDataSource("MasterDataSet", repMod);
                Dictionary<string, string> dic = new Dictionary<string, string>();

                var returnString = _reportService.PrintReport(rep, dic, model.ExportMode);
                //   _reportService.GenerateReportAsync(reportName);
                string rdlcFilePath = ConfigCaller.PDFReportPath + "\\" + GetSavingFineName(reportName, model.CUS_ID) + "." + ReportService.GetFileFormat(model.ExportMode);

                if (!Directory.Exists(ConfigCaller.PDFReportPath))
                {
                    Directory.CreateDirectory(ConfigCaller.PDFReportPath);
                }

                System.IO.File.WriteAllBytes(rdlcFilePath, returnString);
                string base64String = Convert.ToBase64String(returnString, 0, returnString.Length);

                objUserHead = new ReportsReturnResponse
                {
                    resp = true,
                    PDFFilePath = rdlcFilePath,
                    base64String = base64String
                };
                objUserHeadList.Add(objUserHead);
            }
            catch (Exception ex)
            {
                objUserHead = new ReportsReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "Reports_Data", "MailbagDailyActivityReports", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Reports_Data", "MailbagDailyActivityReports", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Reports_Data", "MailbagDailyActivityReports", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Reports_Data", "MailbagDailyActivityReports", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objUserHeadList;
        }

        private static List<MailbagDailyActivityModel> LoadData_MailbagDailyActivity(MailbagDailyActivityRequestModel model)
        {
            List<MailbagDailyActivityModel> listMain = new List<MailbagDailyActivityModel>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        //cmd.CommandText = "sp_get_report_mailbagdailyactivity";
                        cmd.CommandText = "sp_get_report_mailbagdailyactivity_v1";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Date", model.Date);
                        cmd.Parameters["@Date"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CustomerID", model.CustomerID);
                        cmd.Parameters["@CustomerID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                MailbagDailyActivityModel objData = new MailbagDailyActivityModel();

                                objData.CustomerName = rdr["CustomerName"].ToString();
                                objData.Date = rdr["Date"].ToString();

                                objData.TripNo = rdr["TripNo"].ToString().Trim();
                                objData.CollectionLocation = rdr["CollectionLocation"].ToString().Trim();
                                objData.ContractTime = rdr["ContractTime"].ToString().Trim();
                                objData.ActualTime = rdr["ActualTime"].ToString().Trim();
                                objData.Variance = rdr["Variance"].ToString().Trim();
                                objData.Collection_BagNo = rdr["Collection_BagNo"].ToString().Trim();
                                objData.Collection_SealNo = rdr["Collection_SealNo"].ToString().Trim();
                                objData.Collection_Exeption = rdr["Collection_Exeption"].ToString().Trim();
                                objData.Delivery_BagNo = rdr["Delivery_BagNo"].ToString().Trim();
                                objData.Delivery_SealNo = rdr["Delivery_SealNo"].ToString().Trim();
                                objData.Delivery_Exeption = rdr["Delivery_Exeption"].ToString().Trim();

                                objData.TotalNoLocations = rdr["TotalNoLocations"].ToString().Trim();
                                objData.TotalNoPlannedJobs = rdr["TotalNoPlannedJobs"].ToString().Trim();

                                objData.NoJobsCompleted = rdr["NoJobsCompleted"].ToString().Trim();
                                objData.TotalNoLateDelivery = rdr["TotalNoLateDelivery"].ToString().Trim();
                                objData.TotalNoDeliveryOnTime = rdr["TotalNoDeliveryOnTime"].ToString().Trim();

                                objData.Delayed = rdr["Delayed"].ToString().Trim();
                                objData.MisDelivered = rdr["MisDelivered"].ToString().Trim();
                                objData.Timeliness = rdr["Timeliness"].ToString().Trim();
                                objData.Result = rdr["Result"].ToString().Trim();

                                objData.NoSealedBagsCollected = rdr["NoSealedBagsCollected"].ToString().Trim();
                                objData.NoUnOpenedBagsCollected = rdr["NoUnOpenedBagsCollected"].ToString().Trim();
                                objData.NoEmptyBagsCollected = rdr["NoEmptyBagsCollected"].ToString().Trim();

                                objData.TotalNoOfCollectedContainers = rdr["TotalNoOfCollectedContainers"].ToString().Trim();
                                objData.TotalNoOfDeliveredContainers = rdr["TotalNoOfDeliveredContainers"].ToString().Trim();

                                objData.CPCode = rdr["CPCode"].ToString().Trim();


                                objData.CollectedBy_Date = rdr["CollectedBy_Date"].ToString().Trim();
                                objData.CollectedBy_Time = rdr["CollectedBy_Time"].ToString().Trim();
                                objData.CollectedBy_CollectedBy = rdr["CollectedBy_CollectedBy"].ToString().Trim();

                                objData.LooseMail = rdr["LooseMail"].ToString().Trim();

                                listMain.Add(objData);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "Reports_Data", "LoadData_MailbagDailyActivity", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Reports_Data", "LoadData_MailbagDailyActivity", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Reports_Data", "LoadData_MailbagDailyActivity", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Reports_Data", "LoadData_MailbagDailyActivity", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return listMain;
        }

        public static List<ReportsReturnResponse> MailbagDailyActivityReports_V1(MailbagDailyActivityRequestModel_V1 model)
        {
            List<ReportsReturnResponse> objUserHeadList = new List<ReportsReturnResponse>();
            ReportsReturnResponse objUserHead = new ReportsReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objUserHead.resp = false;
                objUserHead.IsAuthenticated = false;
                objUserHeadList.Add(objUserHead);
                return objUserHeadList;
            }

            string reportName = "MailbagDailyActivityReports_V1";
            //create new folder
            string newfolder = ConfigCaller.PDFReportPath + "\\" + GetSavingFineName(reportName, model.CUS_ID);

            if (!Directory.Exists(newfolder))
            {
                Directory.CreateDirectory(newfolder);
            }

            try
            {
                ReportService _reportService = new ReportService();

                DateTime rangeDatetime;


                bool isPrimary = true;
                WorkBook PrimaryWB = null;
                //render all reports and save to files
                for (int i = 0; i < 32; i++)
                {
                    rangeDatetime = model.DateFrom.AddDays(i).Date;

                    LocalReport rep = _reportService.SetupReport(reportName);

                    List<HRM_DAL.ReportModels.MailbagDailyActivityModel> repMod = new List<ReportModels.MailbagDailyActivityModel>();

                    repMod = LoadData_MailbagDailyActivity_V1(new MailbagDailyActivityRequestModel() { Date = rangeDatetime, CustomerID = model.CustomerID });

                    rep.AddDataSource("MasterDataSet", repMod);
                    Dictionary<string, string> dic = new Dictionary<string, string>();

                    var returnString_sub = _reportService.PrintReport(rep, dic, model.ExportMode);

                    string RequestReferenceID = rangeDatetime.ToString("ddMMyyyyHHmmss");

                    string rdlcFilePath1 = newfolder + "\\" + RequestReferenceID + "." + ReportService.GetFileFormat(model.ExportMode);

                    System.IO.File.WriteAllBytes(rdlcFilePath1, returnString_sub);

                    WorkBook CurrWB = WorkBook.LoadExcel(rdlcFilePath1);
                    CurrWB.DefaultWorkSheet.Name = rangeDatetime.ToString("MMM dd").Replace("/", "");

                    if (PrimaryWB == null)
                    {
                        PrimaryWB = WorkBook.Create(ExcelFileFormat.XLSX);
                    }

                    if (isPrimary == true)
                    {
                        PrimaryWB = CurrWB;
                        isPrimary = false;
                    }
                    else
                    {
                        WorkSheet workSheet = CurrWB.DefaultWorkSheet;// PrimaryWB.CreateWorkSheet(CurrWB.DefaultWorkSheet.Name);
                        List<IronXL.Drawing.Images.IImage> images = PrimaryWB.DefaultWorkSheet.Images;

                        foreach (var item in images)
                        {

                            workSheet.InsertImage(item.Data, IronXL.Drawing.Images.ImageFormat.PNG, 4, 4, 4, 3);
                        }
                        workSheet.CopyTo(PrimaryWB, CurrWB.DefaultWorkSheet.Name);
                    }


                }

                string rdlcFilePath = ConfigCaller.PDFReportPath + "\\" + GetSavingFineName(reportName, model.CUS_ID) + "." + ReportService.GetFileFormat(model.ExportMode);
                PrimaryWB.SaveAs(rdlcFilePath);

                var returnString = File.ReadAllBytes(rdlcFilePath);
                string base64String = Convert.ToBase64String(returnString, 0, returnString.Length);

                objUserHead = new ReportsReturnResponse
                {
                    resp = true,
                    PDFFilePath = rdlcFilePath,
                    base64String = base64String
                };
                objUserHeadList.Add(objUserHead);

                string[] arr = Directory.GetFiles(newfolder);
                foreach (var item in arr)
                {
                    File.Delete(item);
                }
                Directory.Delete(newfolder);

            }
            catch (Exception ex)
            {

                string[] arr = Directory.GetFiles(newfolder);
                foreach (var item in arr)
                {
                    File.Delete(item);
                }
                Directory.Delete(newfolder);

                objUserHead = new ReportsReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "Reports_Data", "MailbagDailyActivityReports_V1", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Reports_Data", "MailbagDailyActivityReports_V1", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Reports_Data", "MailbagDailyActivityReports_V1", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Reports_Data", "MailbagDailyActivityReports_V1", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objUserHeadList;
        }

        private static List<MailbagDailyActivityModel> LoadData_MailbagDailyActivity_V1(MailbagDailyActivityRequestModel model)
        {
            List<MailbagDailyActivityModel> listMain = new List<MailbagDailyActivityModel>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        //cmd.CommandText = "sp_get_report_mailbagdailyactivity";
                        cmd.CommandText = "sp_get_report_mailbagdailyactivity_v1";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Date", model.Date);
                        cmd.Parameters["@Date"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CustomerID", model.CustomerID);
                        cmd.Parameters["@CustomerID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                MailbagDailyActivityModel objData = new MailbagDailyActivityModel();

                                objData.CustomerName = rdr["CustomerName"].ToString();
                                objData.Date = rdr["Date"].ToString();

                                objData.TripNo = rdr["TripNo"].ToString().Trim();
                                objData.CollectionLocation = rdr["CollectionLocation"].ToString().Trim();
                                objData.ContractTime = rdr["ContractTime"].ToString().Trim();
                                objData.ActualTime = rdr["ActualTime"].ToString().Trim();
                                objData.Variance = rdr["Variance"].ToString().Trim();
                                objData.Collection_BagNo = rdr["Collection_BagNo"].ToString().Trim();
                                objData.Collection_SealNo = rdr["Collection_SealNo"].ToString().Trim();
                                objData.Collection_Exeption = rdr["Collection_Exeption"].ToString().Trim();
                                objData.Delivery_BagNo = rdr["Delivery_BagNo"].ToString().Trim();
                                objData.Delivery_SealNo = rdr["Delivery_SealNo"].ToString().Trim();
                                objData.Delivery_Exeption = rdr["Delivery_Exeption"].ToString().Trim();

                                objData.TotalNoLocations = rdr["TotalNoLocations"].ToString().Trim();
                                objData.TotalNoPlannedJobs = rdr["TotalNoPlannedJobs"].ToString().Trim();

                                objData.NoJobsCompleted = rdr["NoJobsCompleted"].ToString().Trim();
                                objData.TotalNoLateDelivery = rdr["TotalNoLateDelivery"].ToString().Trim();
                                objData.TotalNoDeliveryOnTime = rdr["TotalNoDeliveryOnTime"].ToString().Trim();

                                objData.Delayed = rdr["Delayed"].ToString().Trim();
                                objData.MisDelivered = rdr["MisDelivered"].ToString().Trim();
                                objData.Timeliness = rdr["Timeliness"].ToString().Trim();
                                objData.Result = rdr["Result"].ToString().Trim();

                                objData.NoSealedBagsCollected = rdr["NoSealedBagsCollected"].ToString().Trim();
                                objData.NoUnOpenedBagsCollected = rdr["NoUnOpenedBagsCollected"].ToString().Trim();
                                objData.NoEmptyBagsCollected = rdr["NoEmptyBagsCollected"].ToString().Trim();

                                objData.TotalNoOfCollectedContainers = rdr["TotalNoOfCollectedContainers"].ToString().Trim();
                                objData.TotalNoOfDeliveredContainers = rdr["TotalNoOfDeliveredContainers"].ToString().Trim();

                                objData.CPCode = rdr["CPCode"].ToString().Trim();


                                objData.CollectedBy_Date = rdr["CollectedBy_Date"].ToString().Trim();
                                objData.CollectedBy_Time = rdr["CollectedBy_Time"].ToString().Trim();
                                objData.CollectedBy_CollectedBy = rdr["CollectedBy_CollectedBy"].ToString().Trim();

                                objData.LooseMail = rdr["LooseMail"].ToString().Trim();

                                listMain.Add(objData);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "Reports_Data", "LoadData_MailbagDailyActivity_V1", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Reports_Data", "LoadData_MailbagDailyActivity_V1", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Reports_Data", "LoadData_MailbagDailyActivity_V1", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Reports_Data", "LoadData_MailbagDailyActivity_V1", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return listMain;
        }

        public static List<ReportsReturnResponse> PrintContainerLabelWithQRSticker(PrintContainerRequestModel model)
        {
            List<ReportsReturnResponse> objUserHeadList = new List<ReportsReturnResponse>();
            ReportsReturnResponse objUserHead = new ReportsReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objUserHead.resp = false;
                objUserHead.IsAuthenticated = false;
                objUserHeadList.Add(objUserHead);
                return objUserHeadList;
            }

            try
            {
                string reportName = "PrintQRSticker";

                ReportService _reportService = new ReportService();
                LocalReport rep = _reportService.SetupReport(reportName);

                List<HRM_DAL.ReportModels.PrintQRStickerModel> repMod = new List<ReportModels.PrintQRStickerModel>();

                repMod = LoadData_PrintQRSticker(model);

                rep.AddDataSource("MasterDataSet", repMod);
                Dictionary<string, string> dic = new Dictionary<string, string>();

                var returnString = _reportService.PrintReport(rep, dic, model.ExportMode);
                //   _reportService.GenerateReportAsync(reportName);

                List<ReturSystemPMModelHead> tem = SystemParameter_Data.get_system_parameter_single(
                                 new GetSystemPMSingleModel()
                                 { SP_ID = "FilePathReference_QR_Label_Print" });

                string FilePathReference_QR_Print = "";

                if (tem != null && tem.Count > 0 && tem[0].SystemPM != null && tem[0].SystemPM.Count > 0)
                {
                    FilePathReference_QR_Print = tem[0].SystemPM[0].SP_Value;
                    if (!Directory.Exists(FilePathReference_QR_Print))
                    {
                        Directory.CreateDirectory(FilePathReference_QR_Print);
                    }
                }

                string rdlcFilePath = FilePathReference_QR_Print + "\\" + GetSavingFineName(reportName, model.CUS_ID) /*+ "_" + model.CN_ID */+ "." + ReportService.GetFileFormat(model.ExportMode);
                System.IO.File.WriteAllBytes(rdlcFilePath, returnString);
                string base64String = Convert.ToBase64String(returnString, 0, returnString.Length);

                objUserHead = new ReportsReturnResponse
                {
                    resp = true,
                    PDFFilePath = rdlcFilePath,
                    base64String = base64String
                };
                objUserHeadList.Add(objUserHead);
            }
            catch (Exception ex)
            {
                objUserHead = new ReportsReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "Reports_Data", "PrintQRSticker", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Reports_Data", "PrintQRSticker", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Reports_Data", "PrintQRSticker", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Reports_Data", "PrintQRSticker", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objUserHeadList;
        }

        private static List<PrintQRStickerModel> LoadData_PrintQRSticker(PrintContainerRequestModel model)
        {
            List<PrintQRStickerModel> listMain = new List<PrintQRStickerModel>();
            try
            {
                List<ReturSystemPMModelHead> tem = SystemParameter_Data.get_system_parameter_single(
                                 new GetSystemPMSingleModel()
                                 { SP_ID = "FilePathReference_QR_Print" });

                string FilePathReference_QR_Print = "";

                if (tem != null && tem.Count > 0 && tem[0].SystemPM != null && tem[0].SystemPM.Count > 0)
                {
                    FilePathReference_QR_Print = tem[0].SystemPM[0].SP_Value;
                }

                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    foreach (var CNitem in model.CN_IDList)
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = lconn;

                            cmd.CommandText = "sp_get_report_containerPrintQRSticker";
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@CN_ID", CNitem);
                            cmd.Parameters["@CN_ID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@CN_LabelTypeID", model.LabelType);
                            cmd.Parameters["@CN_LabelTypeID"].Direction = ParameterDirection.Input;

                            cmd.Parameters.AddWithValue("@CN_LastPrintedBy", model.UserID);
                            cmd.Parameters["@CN_LastPrintedBy"].Direction = ParameterDirection.Input;

                            SqlDataAdapter dta = new SqlDataAdapter();
                            dta.SelectCommand = cmd;
                            DataSet Ds = new DataSet();
                            dta.Fill(Ds);

                            PrintContainerQRModel qr = new PrintContainerQRModel() { CN_ID = CNitem };
                            string jsonString = JsonSerializer.Serialize(qr);

                            if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                            {
                                //Image ima = Image.FromFile(@"D:\Foreign Projects\HRM_Backend_V1.0\HRM_DAL\Images\Transnational-group-logo.png");

                                //ImageConverter _imageConverter = new ImageConverter();
                                ////byte[] xByte = (byte[])_imageConverter.ConvertTo(ima, typeof(byte[])); 

                                QRCoder.QRCodeGenerator qRCodeGenerator = new QRCoder.QRCodeGenerator();

                                QRCoder.QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(jsonString, QRCoder.QRCodeGenerator.ECCLevel.Q);
                                QRCoder.QRCode qRCode = new QRCoder.QRCode(qRCodeData);
                                Bitmap bmp = qRCode.GetGraphic(5);

                                using (MemoryStream ms = new MemoryStream())
                                {
                                    bmp.Save(ms, ImageFormat.Bmp);
                                    bmp.Save(FilePathReference_QR_Print + "\\" + CNitem + ".png");
                                    byte[] xByte = ms.ToArray();

                                    foreach (DataRow rdr in Ds.Tables[0].Rows)
                                    {
                                        for (int i = 0; i < model.PrintCountPerLabel; i++)
                                        {
                                            PrintQRStickerModel objData = new PrintQRStickerModel();
                                            objData.CNID = CNitem;
                                            objData.CountryCode = rdr["CountryCode"].ToString();
                                            objData.CompanyName = rdr["CompanyName"].ToString();
                                            objData.ContainerNumber = rdr["ContainerNumber"].ToString();
                                            objData.ContainerType = rdr["ContainerType"].ToString();
                                            objData.CostCenterName = rdr["CostCenterName"].ToString();
                                            objData.CostCenterNumber = rdr["CostCenterNumber"].ToString();
                                            objData.CN_LabelFooterLine1 = rdr["CN_LabelFooterLine1"].ToString();
                                            objData.CN_LabelFooterLine2 = rdr["CN_LabelFooterLine2"].ToString();
                                            //                      "This bag contains no commercial value, If found please call \n " +
                                            //"1800 - EXPRESS(+65 - 6379 - 5555)";
                                            objData.BarCode = xByte;
                                            listMain.Add(objData);

                                        }
                                    }
                                }

                            }

                            cmd.Parameters.Clear();
                        }

                    }
                }


            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "Reports_Data", "LoadData_PrintQRSticker", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Reports_Data", "LoadData_PrintQRSticker", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Reports_Data", "LoadData_PrintQRSticker", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Reports_Data", "LoadData_PrintQRSticker", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return listMain;
        }
    }
}