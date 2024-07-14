using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System.IO;
using System.Drawing;
using AspNetCore.Reporting;
using HRM_DAL.ReportModels;
using System.Text.Json;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using Newtonsoft.Json;


namespace HRM_DAL.Data
{
    public class Recieve_Data
    {
        private static LogError objError = new LogError();

        public static List<ReceiveSummeryHeaderModel> get_batch_details(ProcessRequestQRStringModel ScannedText)
        {
            List<ReceiveSummeryHeaderModel> objReceiveHeadList = new List<ReceiveSummeryHeaderModel>();
            ReceiveSummeryHeaderModel objReceiveHead = new ReceiveSummeryHeaderModel();
            objReceiveHead.ReceiveSummeryModelList = new List<ReceiveSummeryModel>();

            if (login_Data.AuthenticationKeyValidateWithDB(ScannedText) == false)
            {
                objReceiveHead.resp = false;
                objReceiveHead.IsAuthenticated = false;
                objReceiveHeadList.Add(objReceiveHead);
                return objReceiveHeadList;
            }
            try
            {
                if (string.IsNullOrEmpty(ScannedText.QRString))
                {
                    objReceiveHead.resp = false;
                    objReceiveHead.msg = "QR Code cannot empty";
                    objReceiveHeadList.Add(objReceiveHead);
                    return objReceiveHeadList;
                }

                List<string> spitbyHash = ScannedText.QRString.Split('#').ToList();
                string BatchNo = "";
                if (spitbyHash.Count > 0)
                {
                    BatchNo = spitbyHash[0];
                }
                string DeviceNo = "";
                string StaffID = "";
                string MailType = "";
                string DeclaredQuantity = "";
                string PCCode = "";
                string TransactionDate = "";

                List<string> spitbyHashD = spitbyHash[0].Split('-').ToList();
                for (int i = 0; i < spitbyHashD.Count - 1; i++)
                {
                    if (string.IsNullOrEmpty(DeviceNo))
                    { DeviceNo = spitbyHashD[i]; }
                    else { DeviceNo = DeviceNo + "-" + spitbyHashD[i]; }
                }

                //QR Body
                //#1%A03#2%T001#3%R#4%25#5%P0001#6%20220920T10:27:43.10Z

                foreach (var item in spitbyHash)
                {
                    ////#1 - Device No – (A03)
                    //if (item.StartsWith("1%"))
                    //{
                    //    List<string> tempDe = item.Split('%').ToList();
                    //    DeviceNo = tempDe[1];
                    //}
                    //#2 - Staff ID – (T001)
                    if (item.StartsWith("1%"))
                    {
                        List<string> tempDe = item.Split('%').ToList();
                        StaffID = tempDe[1];
                    }
                    //#3 - Mail Type (C - Courier, O - Ordinary, R - Registered)
                    if (item.StartsWith("2%"))
                    {
                        List<string> tempDe = item.Split('%').ToList();
                        MailType = tempDe[1];
                        if (MailType == "C") MailType = "Courier";
                        else if (MailType == "O") MailType = "Ordinary";
                        else if (MailType == "R") MailType = "Registered";
                    }
                    //#4 - Declared Quantity - (T001)
                    if (item.StartsWith("3%"))
                    {
                        List<string> tempDe = item.Split('%').ToList();
                        DeclaredQuantity = tempDe[1];
                    }
                    //#5 - PC Code – (P0001)
                    if (item.StartsWith("4%"))
                    {
                        List<string> tempDe = item.Split('%').ToList();
                        PCCode = tempDe[1];
                    }
                    //#6 – Transaction Date – (20220920T10:27:43.10Z)
                    if (item.StartsWith("5%"))
                    {
                        List<string> tempDe = item.Split('%').ToList();
                        TransactionDate = tempDe[1];
                    }
                }

                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_receive_batch_details";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BatchNo", BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DeviceNo", DeviceNo);
                        cmd.Parameters["@DeviceNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@StaffID", StaffID);
                        cmd.Parameters["@StaffID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MailType", MailType);
                        cmd.Parameters["@MailType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DeclaredQuantity", DeclaredQuantity);
                        cmd.Parameters["@DeclaredQuantity"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PCCode", PCCode);
                        cmd.Parameters["@PCCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TransactionDate", TransactionDate);
                        cmd.Parameters["@TransactionDate"].Direction = ParameterDirection.Input;


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            objReceiveHead.resp = true;
                            objReceiveHead.msg = "";
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                if (Ds.Tables[0].Columns.Contains("RTN_RESP"))
                                {
                                    objReceiveHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objReceiveHead.msg = rdr["RTN_MSG"].ToString();
                                }
                                else
                                {
                                    ReceiveSummeryModel objReceiveDetail = new ReceiveSummeryModel()
                                    {
                                        BatchNo = rdr["BatchNumber"].ToString(),
                                        DeviceNo = rdr["DeviceNo"].ToString(),
                                        StaffID = rdr["StaffID"].ToString(),
                                        MailType = rdr["MailTypeID"].ToString(),
                                        Quantity = rdr["Declared_Qty"].ToString(),
                                        PCCode = rdr["PCCode"].ToString(),
                                        TransactionDate = rdr["TransactionDate"].ToString(),
                                        StaffName = rdr["StaffName"].ToString(),
                                        DepartmentID = rdr["DepartmentID"].ToString(),
                                        IsOffLine = rdr["IsOffLine"].ToString() == "1" ? true : false
                                    };

                                    if (objReceiveDetail.IsOffLine == true)
                                    {
                                        if (
                                            string.IsNullOrEmpty(DeviceNo) ||
                                            string.IsNullOrEmpty(StaffID) ||
                                            string.IsNullOrEmpty(MailType) ||
                                            string.IsNullOrEmpty(DeclaredQuantity) ||
                                            string.IsNullOrEmpty(PCCode) ||
                                            string.IsNullOrEmpty(TransactionDate))
                                        {
                                            objReceiveHead.resp = false;
                                            objReceiveHead.msg = "Invalid QR Code";
                                            objReceiveHeadList.Add(objReceiveHead);
                                            return objReceiveHeadList;
                                        }
                                    }

                                    objReceiveHead.ReceiveSummeryModelList.Add(objReceiveDetail);
                                }

                            }
                            objReceiveHeadList.Add(objReceiveHead);
                        }
                        else
                        {
                            objReceiveHead.resp = true;
                            objReceiveHead.msg = "";
                            objReceiveHeadList.Add(objReceiveHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objReceiveHead.resp = false;
                objReceiveHead.msg = ex.Message.ToString();

                objReceiveHeadList.Add(objReceiveHead);

                objError.WriteLog(0, "Recieve_Data", "get_batch_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Recieve_Data", "get_batch_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Recieve_Data", "get_batch_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Recieve_Data", "get_batch_details", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objReceiveHeadList;
        }

        public static List<ReceiveSubmitBatchModel> ClearForm_Receive(ReceiveDeleteBatchNoModel model)
        {
            List<ReceiveSubmitBatchModel> objReceiveHeadList = new List<ReceiveSubmitBatchModel>();
            ReceiveSubmitBatchModel objReceiveHead = new ReceiveSubmitBatchModel();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objReceiveHead.resp = false;
                objReceiveHead.IsAuthenticated = false;
                objReceiveHeadList.Add(objReceiveHead);
                return objReceiveHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_delete_receive_batch";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BatchNo", model.BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                        cmd.Parameters["@CreatedBy"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            objReceiveHead.resp = true;
                            objReceiveHead.msg = "";
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                if (Ds.Tables[0].Columns.Contains("RTN_RESP"))
                                {
                                    objReceiveHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objReceiveHead.msg = rdr["RTN_MSG"].ToString();
                                }
                            }
                            objReceiveHeadList.Add(objReceiveHead);
                        }
                        else
                        {
                            objReceiveHead.resp = true;
                            objReceiveHead.msg = "";
                            objReceiveHeadList.Add(objReceiveHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objReceiveHead.resp = false;
                objReceiveHead.msg = ex.Message.ToString();

                objReceiveHeadList.Add(objReceiveHead);

                objError.WriteLog(0, "Recieve_Data", "ClearForm_Receive", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Recieve_Data", "ClearForm_Receive", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Recieve_Data", "ClearForm_Receive", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Recieve_Data", "ClearForm_Receive", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objReceiveHeadList;
        }

        public static List<ReportsReturnResponse_Image> PrintQRSticker(ReceiveRequestBatchNoModel model)
        {
            List<ReportsReturnResponse_Image> objUserHeadList = new List<ReportsReturnResponse_Image>();
            ReportsReturnResponse_Image objUserHead = new ReportsReturnResponse_Image();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objUserHead.resp = false;
                objUserHead.IsAuthenticated = false;
                objUserHeadList.Add(objUserHead);
                return objUserHeadList;
            }
            try
            {
                string reportName = "PrintQR";

                ReportService _reportService = new ReportService();
                LocalReport rep = _reportService.SetupReport(reportName);

                List<HRM_DAL.ReportModels.QRPrintingModel> repMod = new List<ReportModels.QRPrintingModel>();

                repMod = LoadData_PrintQRSticker(model);

                rep.AddDataSource("MasterDataSet", repMod);
                Dictionary<string, string> dic = new Dictionary<string, string>();

                var returnString = _reportService.PrintReport(rep, dic, "pdf");
                //   _reportService.GenerateReportAsync(reportName);

                List<ReturSystemPMModelHead> tem = SystemParameter_Data.get_system_parameter_single(
                                 new GetSystemPMSingleModel()
                                 { SP_ID = "FilePathReference_QR_Print" });

                string FilePathReference_QR_Print = "";

                if (tem != null && tem.Count > 0 && tem[0].SystemPM != null && tem[0].SystemPM.Count > 0)
                {
                    FilePathReference_QR_Print = tem[0].SystemPM[0].SP_Value;
                    if (!Directory.Exists(FilePathReference_QR_Print))
                    {
                        Directory.CreateDirectory(FilePathReference_QR_Print);
                    }
                }

                string rdlcFilePath = FilePathReference_QR_Print + "\\" + Reports_Data.GetSavingFineName(reportName, model.CUS_ID) + "_" + model.BatchNo + ".pdf";
                string rdlcFilePath_Image = FilePathReference_QR_Print + "\\" + Reports_Data.GetSavingFineName(reportName, model.CUS_ID) + "_" + model.BatchNo + ".png";
                System.IO.File.WriteAllBytes(rdlcFilePath, returnString);
                string base64String = Convert.ToBase64String(returnString, 0, returnString.Length);

                objUserHead = new ReportsReturnResponse_Image
                {
                    resp = true,
                    PDFFilePath = rdlcFilePath,
                    ImageFilePath = rdlcFilePath_Image,
                    base64String = base64String
                };
                objUserHeadList.Add(objUserHead);
            }
            catch (Exception ex)
            {
                objUserHead = new ReportsReturnResponse_Image
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "Recieve_Data", "PrintQRSticker", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Recieve_Data", "PrintQRSticker", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Recieve_Data", "PrintQRSticker", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Recieve_Data", "PrintQRSticker", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objUserHeadList;
        }

        private static List<QRPrintingModel> LoadData_PrintQRSticker(ReceiveRequestBatchNoModel model)
        {
            List<QRPrintingModel> listMain = new List<QRPrintingModel>();
            try
            {
                List<ReturSystemPMModelHead> tem = SystemParameter_Data.get_system_parameter_single(
                                 new GetSystemPMSingleModel()
                                 { SP_ID = "FilePathReference_QR_Print" });

                string FilePathReference_QR_Print = "";

                if (tem != null && tem.Count > 0 && tem[0].SystemPM != null && tem[0].SystemPM.Count > 0)
                {
                    FilePathReference_QR_Print = tem[0].SystemPM[0].SP_Value;
                    if (!Directory.Exists(FilePathReference_QR_Print))
                    {
                        Directory.CreateDirectory(FilePathReference_QR_Print);
                    }
                }
                QRPrintingModel qr = new QRPrintingModel();

                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_generate_qr_details";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BatchNo", model.BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr1 in Ds.Tables[0].Rows)
                            {
                                qr.BatchNo = rdr1["BatchNumber"].ToString();
                                qr.TransactionNumber = rdr1["TransactionNumber"].ToString();
                                qr.DatePrinted = rdr1["DatePrinted"].ToString();
                                qr.StaffID = rdr1["StaffID"].ToString();
                                qr.StaffName = rdr1["StaffName"].ToString();
                                qr.PCCode = rdr1["PCCode"].ToString();
                                qr.DepartmentName = rdr1["DepartmentName"].ToString();
                                qr.DepartmentID = rdr1["DepartmentID"].ToString();
                                qr.MailType = rdr1["MailType"].ToString();
                                qr.MailTypeID = rdr1["MailTypeID"].ToString();
                                qr.ReceivedAtMailRoomOn = rdr1["ReceivedAtMailRoomOn"].ToString();
                                qr.DeclaredMailQuantity = rdr1["DeclaredMailQuantity"].ToString();
                                qr.ActualMailQuantity = rdr1["ActualMailQuantity"].ToString();
                                qr.DeviceNo = rdr1["DeviceNo"].ToString();
                                qr.DeclaredQuantity = rdr1["DeclaredQuantity"].ToString();
                                qr.TransactionDate = rdr1["TransactionDate"].ToString();
                            }
                        }
                    }

                    StringBuilder str = new StringBuilder();

                    //M_B001-DBS-DAH-A03 230204265#1%A03#2%T001#3%R#4%25#5%P0001#6%20220920T10:27:43.10Z
                    str.Append(qr.BatchNo);
                    str.Append("#1%" + qr.DeviceNo);
                    str.Append("#2%" + qr.StaffID);
                    str.Append("#3%" + qr.MailType);
                    str.Append("#4%" + qr.DeclaredQuantity);
                    str.Append("#5%" + qr.PCCode);
                    str.Append("#6%" + qr.TransactionDate);

                    //string jsonString = JsonSerializer.Serialize(qr);

                    QRCoder.QRCodeGenerator qRCodeGenerator = new QRCoder.QRCodeGenerator();

                    QRCoder.QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(str.ToString(), QRCoder.QRCodeGenerator.ECCLevel.Q);
                    QRCoder.QRCode qRCode = new QRCoder.QRCode(qRCodeData);
                    Bitmap bmp = qRCode.GetGraphic(5);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        bmp.Save(ms, ImageFormat.Bmp);
                        bmp.Save(FilePathReference_QR_Print + "\\" + model.BatchNo + ".png");
                        byte[] xByte = ms.ToArray();

                        qr.BarCode = xByte;
                        listMain.Add(qr);
                    }
                }
            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "Recieve_Data", "LoadData_PrintQRSticker", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Recieve_Data", "LoadData_PrintQRSticker", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Recieve_Data", "LoadData_PrintQRSticker", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Recieve_Data", "LoadData_PrintQRSticker", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return listMain;
        }

        public static List<ServerDateTimeHeaderModel> get_server_Datetime(RequestBaseModel model)
        {
            List<ServerDateTimeHeaderModel> objReceiveHeadList = new List<ServerDateTimeHeaderModel>();
            ServerDateTimeHeaderModel objReceiveHead = new ServerDateTimeHeaderModel();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objReceiveHead.resp = false;
                objReceiveHead.IsAuthenticated = false;
                objReceiveHeadList.Add(objReceiveHead);
                return objReceiveHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "get_server_Datetime";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BU_ID", model.BU_ID);
                        cmd.Parameters["@BU_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                DateTime trdate = DateTime.MinValue;
                                DateTime.TryParse(rdr["TransactionDate"].ToString(), out trdate);

                                objReceiveHead.resp = true;
                                objReceiveHead.msg = "TransactionDate";
                                objReceiveHead.ServerDateTime = trdate;
                            }
                            objReceiveHeadList.Add(objReceiveHead);
                        }
                        else
                        {
                            objReceiveHead.resp = true;
                            objReceiveHead.msg = "";
                            objReceiveHeadList.Add(objReceiveHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objReceiveHead.resp = false;
                objReceiveHead.msg = ex.Message.ToString();

                objReceiveHeadList.Add(objReceiveHead);

                objError.WriteLog(0, "Recieve_Data", "get_server_Datetime", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Recieve_Data", "get_server_Datetime", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Recieve_Data", "get_server_Datetime", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Recieve_Data", "get_server_Datetime", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objReceiveHeadList;
        }

        public static List<ReceiveSummeryHeaderModel> get_receiving_pending(ReceivePendingModel model)
        {
            List<ReceiveSummeryHeaderModel> objReceiveHeadList = new List<ReceiveSummeryHeaderModel>();
            ReceiveSummeryHeaderModel objReceiveHead = new ReceiveSummeryHeaderModel();
            objReceiveHead.ReceiveSummeryModelList = new List<ReceiveSummeryModel>();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objReceiveHead.resp = false;
                objReceiveHead.IsAuthenticated = false;
                objReceiveHeadList.Add(objReceiveHead);
                return objReceiveHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "get_receiving_pending";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", model.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", model.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TransactionDate", model.TransactionDate);
                        cmd.Parameters["@TransactionDate"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Staff_ID", model.Staff_ID);
                        cmd.Parameters["@Staff_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_ID", model.CUS_ID);
                        cmd.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Department", model.Department);
                        cmd.Parameters["@Department"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DepartmentPCCode", model.DepartmentPCCode);
                        cmd.Parameters["@DepartmentPCCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MailTypeID", model.MailTypeID);
                        cmd.Parameters["@MailTypeID"].Direction = ParameterDirection.Input;


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                if (Ds.Tables[0].Columns.Contains("RTN_RESP"))
                                {
                                    objReceiveHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objReceiveHead.msg = rdr["RTN_MSG"].ToString();
                                }
                                else
                                {
                                    ReceiveSummeryModel objReceiveDetail = new ReceiveSummeryModel()
                                    {
                                        BatchNo = rdr["BatchNumber"].ToString(),
                                        DeviceNo = rdr["DeviceNo"].ToString(),
                                        StaffID = rdr["StaffID"].ToString(),
                                        MailType = rdr["MailTypeID"].ToString(),
                                        Quantity = rdr["Declared_Qty"].ToString(),
                                        PCCode = rdr["PCCode"].ToString(),
                                        StaffName = rdr["StaffName"].ToString(),
                                        DepartmentID = rdr["DepartmentID"].ToString(),
                                        TransactionDate = rdr["TransactionDate"].ToString(),
                                        IsOffLine = rdr["IsOffLine"].ToString() == "1" ? true : false
                                    };
                                    objReceiveHead.ReceiveSummeryModelList.Add(objReceiveDetail);
                                }

                            }
                            objReceiveHeadList.Add(objReceiveHead);
                        }
                        else
                        {
                            objReceiveHead.resp = true;
                            objReceiveHead.msg = "";
                            objReceiveHeadList.Add(objReceiveHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objReceiveHead.resp = false;
                objReceiveHead.msg = ex.Message.ToString();

                objReceiveHeadList.Add(objReceiveHead);

                objError.WriteLog(0, "Recieve_Data", "get_receiving_pending", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Recieve_Data", "get_receiving_pending", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Recieve_Data", "get_receiving_pending", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Recieve_Data", "get_receiving_pending", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objReceiveHeadList;
        }

        public static List<ReceiveSubmitBatchModel> insert_batch_submit(ReceiveSubmitBatchNoModel model)
        {
            List<ReceiveSubmitBatchModel> objReceiveHeadList = new List<ReceiveSubmitBatchModel>();
            ReceiveSubmitBatchModel objReceiveHead = new ReceiveSubmitBatchModel();


            string DATA = JsonConvert.SerializeObject(model);
            objError.WriteLog(2, "Recieve_Data", "insert_batch_submit", "Stack Track: Submit List:" + DATA);


            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objReceiveHead.resp = false;
                objReceiveHead.IsAuthenticated = false;
                objReceiveHeadList.Add(objReceiveHead);
                return objReceiveHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_insert_receive_batch_submit";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BatchNo", model.BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@StaffID", model.StaffID);
                        cmd.Parameters["@StaffID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@StaffName", model.StaffName);
                        cmd.Parameters["@StaffName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DepartmentID", model.DepartmentID);
                        cmd.Parameters["@DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@IsOffLine", model.IsOffLine);
                        cmd.Parameters["@IsOffLine"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PCCode", model.PCCode);
                        cmd.Parameters["@PCCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MailType", model.MailType);
                        cmd.Parameters["@MailType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DeclaredQty", model.DeclaredQty);
                        cmd.Parameters["@DeclaredQty"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@RecievedQty", model.RecievedQty);
                        cmd.Parameters["@RecievedQty"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CustomerID", model.CustomerID);
                        cmd.Parameters["@CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                        cmd.Parameters["@CreatedBy"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DeviceNo", model.DeviceNo);
                        cmd.Parameters["@DeviceNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DeviceTypeID", model.DeviceTypeID);
                        cmd.Parameters["@DeviceTypeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@VendorID", model.VendorID);
                        cmd.Parameters["@VendorID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@LocationID", model.LocationID);
                        cmd.Parameters["@LocationID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TransactionDateTime", model.TransactionDateTime);
                        cmd.Parameters["@TransactionDateTime"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ServerSyncDatetime", model.ServerSyncDatetime);
                        cmd.Parameters["@ServerSyncDatetime"].Direction = ParameterDirection.Input;


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                if (Ds.Tables[0].Columns.Contains("RTN_RESP"))
                                {
                                    objReceiveHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objReceiveHead.msg = rdr["RTN_MSG"].ToString();
                                }
                            }
                            objReceiveHeadList.Add(objReceiveHead);
                        }
                        else
                        {
                            objReceiveHead.resp = true;
                            objReceiveHead.msg = "";
                            objReceiveHeadList.Add(objReceiveHead);
                        }

                    }
                    DATA = JsonConvert.SerializeObject(objReceiveHeadList);
                    objError.WriteLog(2, "Recieve_Data", "insert_batch_submit", "Stack Track: Return List:" + DATA);
                }

            }
            catch (Exception ex)
            {
                objReceiveHead.resp = false;
                objReceiveHead.msg = ex.Message.ToString();

                objReceiveHeadList.Add(objReceiveHead);

                objError.WriteLog(0, "Recieve_Data", "insert_batch_submit", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Recieve_Data", "insert_batch_submit", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Recieve_Data", "insert_batch_submit", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Recieve_Data", "insert_batch_submit", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objReceiveHeadList;
        }

        public static List<ReceiveGridViewHeaderModel> get_batch_grid_details(ReceiveGridRequestBatchNoModel gridmodel)
        {
            List<ReceiveGridViewHeaderModel> objReceiveHeadList = new List<ReceiveGridViewHeaderModel>();
            ReceiveGridViewHeaderModel objReceiveHead = new ReceiveGridViewHeaderModel();
            objReceiveHead.ReceiveGridViewModelList = new List<ReceiveGridViewModel>();

            if (login_Data.AuthenticationKeyValidateWithDB(gridmodel) == false)
            {
                objReceiveHead.resp = false;
                objReceiveHead.IsAuthenticated = false;
                objReceiveHeadList.Add(objReceiveHead);
                return objReceiveHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_receive_batch_grid_details";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BatchNo", gridmodel.BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Staff_ID", gridmodel.Staff_ID);
                        cmd.Parameters["@Staff_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TrDateFrom", gridmodel.TrDateFrom);
                        cmd.Parameters["@TrDateFrom"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TrDateTo", gridmodel.TrDateTo);
                        cmd.Parameters["@TrDateTo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PCCode", gridmodel.PCCode);
                        cmd.Parameters["@PCCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MailTypeID", gridmodel.MailTypeID);
                        cmd.Parameters["@MailTypeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_ID", gridmodel.CUS_ID);
                        cmd.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_NO", gridmodel.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", gridmodel.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USER_ID", gridmodel.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        string RC;
                        using (SqlConnection lconn1 = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                        {
                            using (SqlCommand cmdrc = new SqlCommand())
                            {
                                lconn1.Open();
                                cmdrc.Connection = lconn1;

                                cmdrc.CommandText = "sp_get_OutgoingMailTransactionSync_count";
                                cmdrc.CommandType = CommandType.StoredProcedure;

                                cmdrc.Parameters.AddWithValue("@CUS_ID", gridmodel.CUS_ID);
                                cmdrc.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

                                SqlDataReader rdrrc = cmdrc.ExecuteReader();
                                rdrrc.Read();
                                RC = rdrrc["RC"].ToString();
                            }
                        }

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                if (Ds.Tables[0].Columns.Contains("RTN_RESP"))
                                {
                                    objReceiveHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objReceiveHead.msg = rdr["RTN_MSG"].ToString();
                                }
                                else
                                {
                                    DateTime trdate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["TransactionDate"].ToString(), out trdate);

                                    decimal decQty = 0;
                                    decimal.TryParse(rdr["DeclaredQty"].ToString(), out decQty);

                                    decimal recQty = 0;
                                    decimal.TryParse(rdr["RecievedQty"].ToString(), out recQty);

                                    objReceiveHead.resp = true;
                                    objReceiveHead.msg = "Receive";

                                    ReceiveGridViewModel objReceiveDetails = new ReceiveGridViewModel()
                                    {
                                        BatchNo = rdr["BatchNumber"].ToString(),
                                        DeclaredQty = decQty,
                                        RecievedQty = recQty,
                                        StaffName = rdr["StaffName"].ToString(),
                                        Staff_ID = rdr["Staff_ID"].ToString(),
                                        TransactionDate = trdate,
                                        MailType = rdr["MailType"].ToString(),
                                        MailTypeID = rdr["MailTypeID"].ToString(),
                                        PCCode = rdr["PCCode"].ToString(),
                                        Location = rdr["Location"].ToString(),
                                        RC = RC,
                                    };
                                    objReceiveHead.ReceiveGridViewModelList.Add(objReceiveDetails);
                                }

                            }
                            objReceiveHeadList.Add(objReceiveHead);
                        }
                        else
                        {
                            objReceiveHead.resp = true;
                            objReceiveHead.msg = "";
                            objReceiveHeadList.Add(objReceiveHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objReceiveHead.resp = false;
                objReceiveHead.msg = ex.Message.ToString();
                objReceiveHeadList.Add(objReceiveHead);

                objError.WriteLog(0, "Recieve_Data", "get_batch_grid_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Recieve_Data", "get_batch_grid_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Recieve_Data", "get_batch_grid_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Recieve_Data", "get_batch_grid_details", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objReceiveHeadList;
        }

        public static List<ReceiveCreateNewBatchHeaderModel> create_new_batch(ReceiveCreateNewBatchModel model)
        {
            List<ReceiveCreateNewBatchHeaderModel> objGridViewHeadList = new List<ReceiveCreateNewBatchHeaderModel>();
            ReceiveCreateNewBatchHeaderModel objGridViewHead = new ReceiveCreateNewBatchHeaderModel();
            objGridViewHead.ReceiveGridViewModelList = new List<ReceiveGridViewModel>();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objGridViewHead.resp = false;
                objGridViewHead.IsAuthenticated = false;
                objGridViewHeadList.Add(objGridViewHead);
                return objGridViewHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_create_new_batch";
                        cmd.CommandType = CommandType.StoredProcedure;

                        string BatchNo = "";
                        BatchNo = GenerateBatchNo(model, model.CreatedBy);

                        model.CUS_ID = model.CustomerID;

                        cmd.Parameters.AddWithValue("@BatchNo", BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TransactionDate", model.TransactionDate);
                        cmd.Parameters["@TransactionDate"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@StaffID", model.StaffID);
                        cmd.Parameters["@StaffID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@StaffName", model.StaffName);
                        cmd.Parameters["@StaffName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DepartmentID", model.DepartmentID);
                        cmd.Parameters["@DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@IsOffLine", model.IsOffLine);
                        cmd.Parameters["@IsOffLine"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PCCode", model.PCCode);
                        cmd.Parameters["@PCCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MailType", model.MailType);
                        cmd.Parameters["@MailType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DeclaredQty", model.DeclaredQty);
                        cmd.Parameters["@DeclaredQty"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@RecievedQty", model.RecievedQty);
                        cmd.Parameters["@RecievedQty"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CustomerID", model.CustomerID);
                        //cmd.Parameters["@CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                        cmd.Parameters["@CreatedBy"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DeviceNo", model.DeviceNo);
                        cmd.Parameters["@DeviceNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DeviceTypeID", model.DeviceTypeID);
                        cmd.Parameters["@DeviceTypeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@VendorID", model.VendorID);
                        cmd.Parameters["@VendorID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@LocationID", model.LocationID);
                        cmd.Parameters["@LocationID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_ID", model.CUS_ID);
                        cmd.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

                        ReturnResponse res_image = new ReturnResponse();
                        res_image = SaveImageToFileFolder(model.UploadedFile, BatchNo, model.UploadedFileFormat);

                        string FilePathReference_Receiving = "";

                        if (res_image.resp == true)
                        {
                            FilePathReference_Receiving = res_image.msg;
                        }
                        else
                        {
                            objGridViewHead.resp = false;
                            objGridViewHead.msg = "Error in File Save : Image";

                            objGridViewHeadList.Add(objGridViewHead);
                            return objGridViewHeadList;
                        }

                        cmd.Parameters.AddWithValue("@FilePathReference_Receiving", FilePathReference_Receiving);
                        cmd.Parameters["@FilePathReference_Receiving"].Direction = ParameterDirection.Input;


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                if (Ds.Tables[0].Columns.Contains("RTN_RESP"))
                                {
                                    objGridViewHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objGridViewHead.msg = rdr["RTN_MSG"].ToString();
                                }
                            }

                            if (Ds.Tables.Count > 1)
                            {
                                foreach (DataRow rdr in Ds.Tables[1].Rows)
                                {
                                    DateTime trdate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["TransactionDate"].ToString(), out trdate);

                                    decimal decQty = 0;
                                    decimal.TryParse(rdr["DeclaredQty"].ToString(), out decQty);

                                    decimal recQty = 0;
                                    decimal.TryParse(rdr["RecievedQty"].ToString(), out recQty);

                                    ReceiveGridViewModel objGridViewDetails = new ReceiveGridViewModel()
                                    {
                                        BatchNo = rdr["BatchNumber"].ToString(),
                                        DeclaredQty = decQty,
                                        RecievedQty = recQty,
                                        StaffName = rdr["StaffName"].ToString(),
                                        Staff_ID = rdr["Staff_ID"].ToString(),
                                        TransactionDate = trdate,
                                        MailType = rdr["MailType"].ToString(),
                                        PCCode = rdr["PCCode"].ToString(),
                                    };
                                    objGridViewHead.ReceiveGridViewModelList.Add(objGridViewDetails);
                                }
                            }
                            objGridViewHeadList.Add(objGridViewHead);
                        }
                        else
                        {
                            objGridViewHead.resp = true;
                            objGridViewHead.msg = "";
                            objGridViewHeadList.Add(objGridViewHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objGridViewHead.resp = false;
                objGridViewHead.msg = ex.Message.ToString();
                objGridViewHeadList.Add(objGridViewHead);

                objError.WriteLog(0, "Recieve_Data", "create_new_batch", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Recieve_Data", "create_new_batch", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Recieve_Data", "create_new_batch", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Recieve_Data", "create_new_batch", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objGridViewHeadList;
        }

        private static string GenerateBatchNo(ReceiveCreateNewBatchModel model, string CreatedBy)
        {
            string NewBatchNo = "";
            try
            {
                List<ReturSystemPMModelHead> tem = SystemParameter_Data.get_system_parameter_single(
                                   new GetSystemPMSingleModel()
                                   { SP_ID = "LastManualBatchSequenceNo" });

                ReturnSystemPMModel spm = new ReturnSystemPMModel();

                string LastManualBatchSequenceNoDB = "";
                int intLastManualBatchSequenceNo = 0;
                string LastManualBatchSequenceNo = "";

                if (tem != null && tem.Count > 0 && tem[0].SystemPM != null && tem[0].SystemPM.Count > 0)
                {
                    spm = tem[0].SystemPM[0];
                    LastManualBatchSequenceNoDB = spm.SP_Value;
                    int.TryParse(LastManualBatchSequenceNoDB, out intLastManualBatchSequenceNo);
                }

                LastManualBatchSequenceNo = intLastManualBatchSequenceNo.ToString("00000");

                //List<ReturSystemPMModelHead> temBatch = SystemParameter_Data.get_system_parameter_single(
                //   new GetSystemPMSingleModel()
                //   { SP_ID = "NewBatchConstant" });

                //string strNewBatchConstant = "";
                //if (temBatch != null && temBatch.Count > 0 && temBatch[0].SystemPM != null && temBatch[0].SystemPM.Count > 0)
                //{
                //    strNewBatchConstant = temBatch[0].SystemPM[0].SP_Value;
                //}

                NewBatchNo = "M_" + model.BU_ID + "-" + model.CustomerID + "-" + model.LocationID + "-" + model.DeviceNo + "-" /*"DBS-DAH-A01"*/ + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + LastManualBatchSequenceNo;
                //M_B001 - DBS - DAH - A03 230204265
                //Manual Batch – (M_)
                //Business Unit – (B001)
                //Company Id – (DBS)
                //Location Code – (DAH)

                SystemParameter_Data.modify_system_parameter(new SystemPMModel()
                {
                    SP_Description = spm.SP_Description,
                    SP_DisplaySeq = spm.SP_DisplaySeq,
                    SP_ID = spm.SP_ID,
                    SP_Type = spm.SP_Type,
                    USER_ID = CreatedBy,
                    SP_Value = (intLastManualBatchSequenceNo + 1).ToString()
                });
            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "Recieve_Data", "GenerateBatchNo", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Recieve_Data", "GenerateBatchNo", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Recieve_Data", "GenerateBatchNo", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Recieve_Data", "GenerateBatchNo", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return NewBatchNo;

        }

        private static ReturnResponse SaveImageToFileFolder(byte[] uploadedFile, string batchNo, string filefornat)
        {
            ReturnResponse res = new ReturnResponse();

            string FilePathReference_Receiving = "";
            try
            {
                if (uploadedFile != null && uploadedFile.Length > 0)
                {
                    //Image img = null;
                    using (var ms = new MemoryStream(uploadedFile))
                    {
                        //img = Image.FromStream(ms);
                        string FilePathReference = "";

                        List<ReturSystemPMModelHead> tem = SystemParameter_Data.get_system_parameter_single(
                                    new GetSystemPMSingleModel()
                                    { SP_ID = "ReceivedImageSavingPath" });

                        if (tem != null && tem.Count > 0 && tem[0].SystemPM != null && tem[0].SystemPM.Count > 0)
                        {
                            FilePathReference = tem[0].SystemPM[0].SP_Value;
                        }


                        if (!Directory.Exists(FilePathReference.Trim()))
                        {
                            Directory.CreateDirectory(FilePathReference.Trim());
                        }

                        if (string.IsNullOrEmpty(filefornat)) filefornat = "jpg";

                        FilePathReference_Receiving = FilePathReference.Trim() + "\\" + batchNo + "." + filefornat;

                        if (!File.Exists(FilePathReference_Receiving.Trim()))
                        {
                            //File.Create(FilePathReference_Receiving.Trim());
                            FileStream fs = File.Create(FilePathReference_Receiving);
                            BinaryWriter bw = new BinaryWriter(fs);
                            fs.Write(uploadedFile);
                            fs.Close();
                            fs.Dispose();
                            bw.Close();
                            bw.Dispose();
                        }
                        else
                        {
                            FileStream fs = File.OpenWrite(FilePathReference_Receiving);
                            BinaryWriter bw = new BinaryWriter(fs);
                            fs.Write(uploadedFile);
                            fs.Close();
                            fs.Dispose();
                            bw.Close();
                            bw.Dispose();
                        }

                        //File.OpenWrite(FilePathReference_Receiving);
                        //File.WriteAllBytes(FilePathReference_Receiving, uploadedFile);
                        ////img.Save(FilePathReference_Receiving, System.Drawing.Imaging.ImageFormat.Png);

                        res = new ReturnResponse() { resp = true, msg = FilePathReference_Receiving, obj = new { bytelength = uploadedFile.Length } };

                    }
                }
                else
                {
                    res = new ReturnResponse() { resp = true, msg = "" };
                }
            }
            catch (Exception ex)
            {
                if (uploadedFile != null)
                {
                    res = new ReturnResponse() { resp = false, msg = "Error Message: " + ex.Message, obj = new { bytelength = uploadedFile.Length } };
                }
                else
                {
                    res = new ReturnResponse() { resp = false, msg = "Error Message: " + ex.Message, obj = new { bytelength = 0 } };
                }

                objError.WriteLog(0, "Recieve_Data", "SaveImageToFileFolder", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Recieve_Data", "SaveImageToFileFolder", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Recieve_Data", "SaveImageToFileFolder", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Recieve_Data", "SaveImageToFileFolder", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return res;

        }
    }
}