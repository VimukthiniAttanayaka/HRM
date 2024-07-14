using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using email_sender;
using System.Linq;
using System.Web.Script.Serialization;
using System.Text.Json;
using utility_handler.Utility;
//using Newtonsoft.Json;
using email_sender.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System.IO;

namespace HRM_DAL.Data
{
    public class DayEndProcess_Data
    {
        private static LogError objError = new LogError();
        static List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();

        public class Batch_Summary_Email
        {
            public static List<ReturnResponse> Process()
            {
                try
                {
                    //check timer activated
                    ReturnSystemPMModel config = SystemParameter_Data.PredefinedProperties.ServiceRelated.DayEndProcess_Batch_Summery_Email_Active();
                    if (config != null && config.SP_Value == "1")
                    {
                        ReturnSystemPMModel obj_SessionFrom = SystemParameter_Data.PredefinedProperties.ServiceRelated.DayEndProcess_Batch_Summery_Email_Session_From();
                        ReturnSystemPMModel obj_SessionTo = SystemParameter_Data.PredefinedProperties.ServiceRelated.DayEndProcess_Batch_Summery_Email_Session_To();

                        if (obj_SessionFrom != null)
                        {
                            int fromMinutes = 0;
                            int fromHours = 0;

                            var fromtime = obj_SessionFrom.SP_Value.Split(":");
                            int.TryParse(fromtime[1], out fromMinutes);
                            int.TryParse(fromtime[0], out fromHours);

                            DateTime fromTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, fromHours, fromMinutes, 0);

                            int toMinutes = 0;
                            int toHours = 0;

                            var totime = obj_SessionTo.SP_Value.Split(":");
                            int.TryParse(totime[1], out toMinutes);
                            int.TryParse(totime[0], out toHours);

                            DateTime toTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, toHours, toMinutes, 0);

                            if (DateTime.Now >= fromTime && DateTime.Now <= toTime)
                            {
                                //read completed jobs and non emailed from DB
                                List<DayEndProcessHeader> summeryList = Batch_Summary_List_where_Status_Completed();
                                foreach (var item in summeryList)
                                {

                                    Send_Batch_Summary_Email_Notification(item);
                                }
                            }

                        }
                        //SystemParameter_Data.PredefinedProperties.ServiceRelated.UpdateRelated.DayEndProcess_Batch_Summery_Email_MarkInactive();
                    }
                }
                catch (Exception ex)
                {
                    objError.WriteLog(0, "DayEndProcess_Data", "Batch_Summary_Email_Process", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "DayEndProcess_Data", "Batch_Summary_Email_Process", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "DayEndProcess_Data", "Batch_Summary_Email_Process", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "DayEndProcess_Data", "Batch_Summary_Email_Process", "Inner Exception Message: " + ex.InnerException.Message);
                    }
                }
                return objUserHeadList;
            }

            public static List<ReturnResponse> ManualProcess()
            {
                try
                {
                    List<DayEndProcessHeader> summeryList = Batch_Summary_List_where_Status_Completed();
                    foreach (var item in summeryList)
                    {

                        Send_Batch_Summary_Email_Notification(item);
                    }
                }
                catch (Exception ex)
                {
                    objError.WriteLog(0, "DayEndProcess_Data", "Batch_Summary_Email_ManualProcess", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "DayEndProcess_Data", "Batch_Summary_Email_ManualProcess", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "DayEndProcess_Data", "Batch_Summary_Email_ManualProcess", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "DayEndProcess_Data", "Batch_Summary_Email_ManualProcess", "Inner Exception Message: " + ex.InnerException.Message);
                    }
                }
                return objUserHeadList;
            }

            public static List<ReturnResponse> Send_Batch_Summary_Email_Notification(DayEndProcessHeader model)
            {
                ReturnResponse objUserHead = new ReturnResponse();
                try
                {
                    objError.WriteLog(2, "DayEndProcess_Data", "Send_Batch_Summary_Email_Notification", "begin : " + JsonSerializer.Serialize(objUserHeadList));

                    if (string.IsNullOrEmpty(model.EmailAddress))
                    {
                        objUserHead = new ReturnResponse
                        {
                            resp = false,
                            msg = "Email is Empty"
                        };
                        objUserHeadList.Add(objUserHead);
                    }
                    else
                    {
                        string subject, Body = "";

                        string Header = "Outgoing Mail Transaction Batch No. [BatchNo] dated [BatchCreatedOn]";
                        string EmailPath = ConfigCaller.Email_Notification_to_Batch_Summary_Email_Notification;

                        if (System.IO.File.Exists(EmailPath))
                        {
                            string filecontent = System.IO.File.ReadAllText(EmailPath);

                            subject = Header;
                            subject = subject.Replace("[BatchCreatedOn]", model.BatchCreatedOn.ToString("dd-MMM-yyyy HH:mm:ss"));
                            subject = subject.Replace("[BatchNo]", model.BatchNumber);

                            filecontent = filecontent.Replace("[BatchNo]", model.BatchNumber);
                            filecontent = filecontent.Replace("[KioskNo]", model.KioskNo);
                            filecontent = filecontent.Replace("[Staff ID]", model.StaffID);
                            filecontent = filecontent.Replace("[Staff Name]", model.StaffName);
                            filecontent = filecontent.Replace("[PCCode]", model.PCCode);

                            if (model.BatchNumber.StartsWith("M_"))
                            {
                                filecontent = filecontent.Replace("[BatchCreatedOn]", "");
                            }
                            else
                            {
                                filecontent = filecontent.Replace("[BatchCreatedOn]", model.BatchCreatedOn.ToString("dd-MMM-yyyy HH:mm:ss"));
                            }

                            filecontent = filecontent.Replace("[BatchReceivedOn]", model.BatchReceivedOn.ToString("dd-MMM-yyyy HH:mm:ss"));
                            if (model.BatchProcessedOn == DateTime.MinValue)
                            {
                                filecontent = filecontent.Replace("[BatchProcessedOn]", "");
                            }
                            else
                            {
                                filecontent = filecontent.Replace("[BatchProcessedOn]", model.BatchProcessedOn.ToString("dd-MMM-yyyy HH:mm:ss"));
                            }

                            //Batch created and deposited on  :dd - MMM - yyyy HH: mm: ss
                            //Batch received at mailroom on   :dd - MMM - yyyy HH: mm: ss
                            //Batch processed on              :dd - MMM - yyyy HH: mm: ss
                            filecontent = filecontent.Replace("[Mail Type]", model.MailType);
                            filecontent = filecontent.Replace("[declared Qty]", model.declaredQty.ToString());
                            filecontent = filecontent.Replace("[Actual Qty]", model.actualQty.ToString());
                            filecontent = filecontent.Replace("[CentralMailroomNumber]", model.CentralMailroomNumber);

                            string table = "";
                            decimal totalcharges = 0;

                            //string border= @"style="border: 1px solid black;border-collapse:collapse; \"";

                            foreach (var item in model.DayEndProcessDetails)
                            {
                                totalcharges = totalcharges + item.TotalCost;
                                table = table + "<tr><td>" + item.TrackingNumber + "</td><td>" + item.RecipentName + " " +
                                item.Address + " " +
                                item.Country + "</td><td>" + item.TotalCost + "</td></tr>";

                            }

                            string table1 = "";
                            filecontent = filecontent.Replace("[Total Mail Expense]", totalcharges.ToString());
                            if (model.MailType == "Courier" || model.MailType == "Registered")
                            {
                                table1 = table1 + "<tr><td>" + model.MailType + "	                </td><td>:</td><td><table style=\"border: 1px solid black; border - collapse: collapse; \"><tr ><td style=\"border: 1px solid black; border - collapse: collapse; \">Airway/Registered No</td><td style=\"border: 1px solid black; border - collapse: collapse; \">Recipient/Address</td><td style=\"border: 1px solid black; border - collapse: collapse; \">Charges</td></tr>" + table + "</table></td></tr>";
                                filecontent = filecontent.Replace("[Registered Courier]", table1);
                            }
                            else { filecontent = filecontent.Replace("[Registered Courier]", ""); }

                            Body = filecontent;

                            EmailAttachedFileDetails objFilesAttachment = new EmailAttachedFileDetails();
                            if (model.AttachDocsToEmail == true)
                            {
                                objFilesAttachment = AttcahFilesBinary(model);
                            }

                            ReturnResponse rtn = Email_Sender_Preperation.Send(model.EmailAddress, Body, model.BusinessUnit, true, subject, objFilesAttachment);

                            //(bool messageid, string message) result = SendMail.Send_V1(BaseClassDBCallerData.userNameEmail, model.EmailAddress, "",
                            //          subject, Body, BaseClassDBCallerData.smtpServer, BaseClassDBCallerData.smtpPort,
                            //          BaseClassDBCallerData.security, BaseClassDBCallerData.userNameEmail, BaseClassDBCallerData.userpassword);

                            //objUserHead = new ReturnResponse
                            //{
                            //    resp = result.messageid,
                            //    msg = result.message,
                            //};
                            //objUserHeadList.Add(objUserHead);

                            if (rtn.resp == true)
                            {
                                objUserHeadList.Add(Batch_Summary_List_where_Status_Completed_mark_EmailSend(model.BatchNumber));
                            }

                            objUserHeadList.Add(rtn);
                        }
                    }

                    objError.WriteLog(2, "DayEndProcess_Data", "Send_Batch_Summary_Email_Notification", "end : " + JsonSerializer.Serialize(objUserHeadList));
                }
                catch (Exception ex)
                {
                    objUserHead = new ReturnResponse
                    {
                        resp = false,
                        msg = ex.Message.ToString()
                    };
                    objUserHeadList.Add(objUserHead);

                    objError.WriteLog(0, "DayEndProcess_Data", "Send_Batch_Summary_Email_Notification", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "DayEndProcess_Data", "Send_Batch_Summary_Email_Notification", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "DayEndProcess_Data", "Send_Batch_Summary_Email_Notification", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "DayEndProcess_Data", "Send_Batch_Summary_Email_Notification", "Inner Exception Message: " + ex.InnerException.Message);
                    }

                }
                return objUserHeadList;
            }

            public static EmailAttachedFileDetails AttcahFilesBinary(DayEndProcessHeader model)
            {
                EmailAttachedFileDetails obj = new EmailAttachedFileDetails();
                obj.FileObjectList = new List<FileObject>();

                try
                {

                    if (File.Exists(model.FilePathReference_Processing_ItemLevel_Local.Trim()))
                    {
                        obj.HasFilesAttached = true;
                        //FileStream fs = File.OpenWrite(model.FilePathReference_Processing_ItemLevel_Local);
                        byte[] bytes = File.ReadAllBytes(model.FilePathReference_Processing_ItemLevel_Local.Trim());
                        string ext = Path.GetExtension(model.FilePathReference_Processing_ItemLevel_Local.Trim());
                        obj.FileObjectList.Add(new FileObject() { FileBinary = bytes, FileName = "Local File", FileExtension = ext });
                        //fs.Close();
                        //fs.Dispose();
                    }

                    if (File.Exists(model.FilePathReference_Processing_ItemLevel_Oversea.Trim()))
                    {
                        obj.HasFilesAttached = true;
                        //FileStream fs = File.OpenWrite(model.FilePathReference_Processing_ItemLevel_Oversea);
                        byte[] bytes = File.ReadAllBytes(model.FilePathReference_Processing_ItemLevel_Oversea.Trim());
                        string ext = Path.GetExtension(model.FilePathReference_Processing_ItemLevel_Oversea.Trim());
                        obj.FileObjectList.Add(new FileObject() { FileBinary = bytes, FileName = "Oversea File", FileExtension = ext });
                        //fs.Close();
                        //fs.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    objError.WriteLog(0, "DayEndProcess_Data", "AttcahFilesBinary", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "DayEndProcess_Data", "AttcahFilesBinary", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "DayEndProcess_Data", "AttcahFilesBinary", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "DayEndProcess_Data", "AttcahFilesBinary", "Inner Exception Message: " + ex.InnerException.Message);
                    }
                }
                return obj;
            }

            public static ReturnResponse Batch_Summary_List_where_Status_Completed_mark_EmailSend(string batchno)
            {
                ReturnResponse obj = new ReturnResponse();

                try
                {
                    using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                    {
                        if (lconn.State == ConnectionState.Closed)
                        {
                            lconn.Open();
                        }

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = lconn;

                            cmd.CommandText = "sp_Batch_Summary_List_where_Status_Completed_mark_EmailSend";
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@BatchNo", batchno);
                            cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = cmd;
                            DataSet ds = new DataSet();
                            da.Fill(ds);

                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow rdr in ds.Tables[0].Rows)
                                {
                                    if (ds.Tables[0].Columns.Contains("RTN_RESP"))
                                    {
                                        obj = new ReturnResponse
                                        {
                                            resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                            msg = rdr["RTN_MSG"].ToString()
                                        };
                                    }
                                    else
                                    {
                                        obj = new ReturnResponse
                                        {
                                            resp = true,
                                            msg = "Status Updated"
                                        };
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    obj = new ReturnResponse
                    {
                        resp = false,
                        msg = ex.Message.ToString()
                    };

                    objError.WriteLog(0, "DayEndProcess_Data", "Batch_Summary_List_where_Status_Completed_mark_EmailSend", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "DayEndProcess_Data", "Batch_Summary_List_where_Status_Completed_mark_EmailSend", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "DayEndProcess_Data", "Batch_Summary_List_where_Status_Completed_mark_EmailSend", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "DayEndProcess_Data", "Batch_Summary_List_where_Status_Completed_mark_EmailSend", "Inner Exception Message: " + ex.InnerException.Message);
                    }
                }
                return obj;
            }


            public static List<DayEndProcessHeader> Batch_Summary_List_where_Status_Completed()
            {
                List<DayEndProcessHeader> objHeadList = new List<DayEndProcessHeader>();
                DayEndProcessHeader obj = new DayEndProcessHeader();
                DayEndProcessDetail objD = new DayEndProcessDetail();

                try
                {
                    using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                    {
                        if (lconn.State == ConnectionState.Closed)
                        {
                            lconn.Open();
                        }

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = lconn;

                            cmd.CommandText = "sp_Batch_Summary_List_where_Status_Completed";
                            cmd.CommandType = CommandType.StoredProcedure;


                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = cmd;
                            DataSet ds = new DataSet();
                            da.Fill(ds);

                            string EmailAddress = "";
                            string USR_FirstName = "";
                            string USR_LastName = "";
                            string StaffID = "";
                            string UserTable = "";


                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {

                                foreach (DataRow rdr in ds.Tables[0].Rows)
                                {
                                    objError.WriteLog(2, "DayEndProcess_Data", "Batch_Summary_List_where_Status_Completed", "Stack Track: " + DataSet_Related.DataRow_To_String(rdr));

                                    StaffID = rdr["StaffID"].ToString();
                                    UserTable = rdr["UserTable"].ToString();

                                    if (string.IsNullOrEmpty(StaffID) == false)
                                    {
                                        using (SqlCommand cmdc = new SqlCommand())
                                        {
                                            cmdc.Connection = lconn;

                                            cmdc.CommandText = "sp_get_customer_user";
                                            cmdc.CommandType = CommandType.StoredProcedure;

                                            cmdc.Parameters.AddWithValue("@USER_ID", StaffID);
                                            cmdc.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                                            cmdc.Parameters.AddWithValue("@TABLE", UserTable);
                                            cmdc.Parameters["@TABLE"].Direction = ParameterDirection.Input;

                                            SqlDataAdapter dta = new SqlDataAdapter();
                                            dta.SelectCommand = cmdc;
                                            DataSet Dsc = new DataSet();
                                            dta.Fill(Dsc);

                                            if (Dsc != null && Dsc.Tables.Count > 0 && Dsc.Tables[0].Rows.Count > 0)
                                            {
                                                foreach (DataRow rdrc in Dsc.Tables[0].Rows)
                                                {
                                                    EmailAddress = rdrc["USR_EmailAddress"].ToString();
                                                    USR_FirstName = rdrc["USR_FirstName"].ToString();
                                                    USR_LastName = rdrc["USR_LastName"].ToString();
                                                }
                                            }
                                        }

                                        if (string.IsNullOrEmpty(EmailAddress) == false)
                                        {

                                            DateTime BatchCreatedOn = DateTime.MinValue;
                                            DateTime.TryParse(rdr["BatchCreatedOn"].ToString(), out BatchCreatedOn);

                                            DateTime BatchProcessedOn = DateTime.MinValue;
                                            DateTime.TryParse(rdr["BatchProcessedOn"].ToString(), out BatchProcessedOn);

                                            DateTime BatchReceivedOn = DateTime.MinValue;
                                            DateTime.TryParse(rdr["BatchReceivedOn"].ToString(), out BatchReceivedOn);

                                            obj = new DayEndProcessHeader()
                                            {
                                                BatchNumber = rdr["BatchNumber"].ToString(),
                                                CustomerID = rdr["CustomerID"].ToString(),
                                                //batchdatetime = rdr["batchdatetime"].ToString(),
                                                //BatchNo = rdr["BatchNo"].ToString(),
                                                KioskNo = rdr["KioskNo"].ToString(),
                                                StaffID = rdr["StaffID"].ToString(),
                                                PCCode = rdr["PCCode"].ToString(),
                                                MailType = rdr["MailType"].ToString(),
                                                declaredQty = Decimal.ToInt16(Convert.ToDecimal(rdr["declaredQty"].ToString())),
                                                BatchCreatedOn = BatchCreatedOn,
                                                StaffName = USR_FirstName + " " + USR_LastName,// rdr["StaffName"].ToString(),
                                                BatchProcessedOn = BatchProcessedOn,
                                                BatchReceivedOn = BatchReceivedOn,
                                                CentralMailroomNumber = rdr["CentralMailroomNumber"].ToString(),
                                                actualQty = Decimal.ToInt16(Convert.ToDecimal(rdr["actualQty"].ToString())),
                                                //EmailSubject = rdr["EmailSubject"].ToString(),
                                                //Customer_Reply = rdr["Customer_Reply"].ToString(),
                                                EmailAddress = EmailAddress,
                                                BusinessUnit = rdr["BusinessUnit"].ToString(),
                                                ExceptionType = rdr["ExceptionType"].ToString(),
                                                ExceptionStatus = rdr["ExceptionStatus"].ToString(),
                                                CustomerName = rdr["CustomerName"].ToString(),
                                                UserTable = rdr["UserTable"].ToString(),

                                                AutoRemark = rdr["AutoRemark"].ToString(),
                                                ProcessStage = rdr["ProcessStage"].ToString(),

                                                FilePathReference_Processing_ItemLevel_Local = rdr["FilePathReference_Processing_ItemLevel_Local"].ToString(),
                                                FilePathReference_Processing_ItemLevel_Oversea = rdr["FilePathReference_Processing_ItemLevel_Oversea"].ToString(),

                                            };
                                            if (rdr["AttachDocsToEmail"].ToString().ToUpper() == "TRUE")
                                            { obj.AttachDocsToEmail = true; }
                                            else { obj.AttachDocsToEmail = false; }

                                            obj.DayEndProcessDetails = new List<DayEndProcessDetail>();

                                            foreach (DataRow rdrd in ds.Tables[1].Rows)
                                            {
                                                if (rdr["BatchNumber"].ToString() == rdrd["BatchNumber"].ToString())
                                                {
                                                    objError.WriteLog(2, "DayEndProcess_Data", "Batch_Summary_List_where_Status_Completed", "Stack Track: ItemLevel : " + DataSet_Related.DataRow_To_String(rdrd));

                                                    objD = new DayEndProcessDetail()
                                                    {
                                                        BatchNumber = rdrd["BatchNumber"].ToString(),
                                                        SN = rdrd["SN"].ToString(),
                                                        PostageAmount = rdrd["PostageAmount"].ToString(),
                                                        TrackingNumber = rdrd["TrackingNumber"].ToString(),
                                                        RecipentName = rdrd["RecipentName"].ToString(),
                                                        Address = rdrd["Address"].ToString(),
                                                        Country = rdrd["Country"].ToString(),
                                                        MailItemType = rdrd["MailItemType"].ToString(),
                                                        Quantity = Convert.ToDecimal(rdrd["Quantity"].ToString()),
                                                        TotalCost = Convert.ToDecimal(rdrd["TotalCost"].ToString()),
                                                        Deliver_Courier_Company = rdrd["Deliver_Courier_Company"].ToString(),
                                                        TrackedMail = rdrd["TrackedMail"].ToString(),
                                                        TrackedPackage = rdrd["TrackedPackage"].ToString(),
                                                        BatchedRecord = rdrd["BatchedRecord"].ToString(),
                                                    };
                                                    obj.DayEndProcessDetails.Add(objD);
                                                }
                                            }
                                            objHeadList.Add(obj);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    objError.WriteLog(0, "DayEndProcess_Data", "Batch_Summary_List_where_Status_Completed", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "DayEndProcess_Data", "Batch_Summary_List_where_Status_Completed", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "DayEndProcess_Data", "Batch_Summary_List_where_Status_Completed", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "DayEndProcess_Data", "Batch_Summary_List_where_Status_Completed", "Inner Exception Message: " + ex.InnerException.Message);
                    }
                }
                return objHeadList;
            }
        }

        public class DayEndProcessHeader : OutLookEamail_TransactionHeader
        {
            public List<DayEndProcessDetail> DayEndProcessDetails { get; set; }

        }

        public class DayEndProcessDetail
        {
            public string BatchNumber { get; set; }
            public string SN { get; set; }
            public string TrackingNumber { get; set; }
            public string PostageAmount { get; set; }
            public string Address { get; set; }
            public string RecipentName { get; set; }
            public string Country { get; set; }
            public string MailItemType { get; set; }
            public decimal Quantity { get; set; }
            public decimal TotalCost { get; set; }
            public string Deliver_Courier_Company { get; set; }
            public string TrackedMail { get; set; }
            public string TrackedPackage { get; set; }
            public string BatchedRecord { get; set; }
        }
    }
}