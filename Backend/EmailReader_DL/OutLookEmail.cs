using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Serialization;
using EmailReader_DL.Data;

namespace EmailReader_DL
{

    public class OutLookEmailRead
    {
        static string errorLogPath = ConfigCaller.ErrorLogPath;// @"D:\ForeignProjects\MailTrak_Backend_V1.0\APIChecker\ErrorLog";// System.Configuration.ConfigurationManager.AppSettings["ErrorLogPath"];

        public class OutLookEmail
        {
            public string EmailFrom { get; set; }
            public string EmailSubject { get; set; }
            public string EmailBody { get; set; }
            public DateTime EmailDateSent { get; set; }
            public int MessageNumber { get; set; }
        }

        //public class ExceptionMailReaderTable
        //{
        //    public string BatchNo { get; set; }
        //    public string Status { get; set; }
        //    public string Subject { get; set; }
        //    public string EmailFrom { get; set; }
        //    public DateTime ReadTime { get; set; } = DateTime.Now;
        //    public bool IsSynced { get; set; } = false;
        //    public string MailBody { get; set; }
        //    public string TransactionDateTime { get; set; }
        //    public string ExceptionStatus { get; set; }
        //    public string EmailFor { get; set; }
        //}


        public static void TriggerMailReader()
        {
            Console.WriteLine("EmailReader If_the_Current_Batch_Enabled_for_Email_Reading_and_Update_the_Status");
            Console.WriteLine(errorLogPath);
            WriteLog("EmailReader If_the_Current_Batch_Enabled_for_Email_Reading_and_Update_the_Status", "TriggerMailReader");
            if (If_the_Current_Batch_Enabled_for_Email_Reading_and_Update_the_Status() == true)
            {
                Console.WriteLine("EmailReader ReadMailItems Started");
                WriteLog("EmailReader ReadMailItems Started", "TriggerMailReader");
                List<ExceptionMailReaderTable> mailList = ReadMailItems();
                Console.WriteLine("EmailReader ReadMailItems Stopped");
                WriteLog("EmailReader ReadMailItems Stopped", "TriggerMailReader");

                Console.WriteLine("EmailReader CallMailTrackerToDoOutlookEmail Started");
                WriteLog("EmailReader CallMailTrackerToDoOutlookEmail Started", "TriggerMailReader");
                //CallAPI_OutlookEmail.CallMailTrackerToDoOutlookEmail(mailList);
                Console.WriteLine("EmailReader CallMailTrackerToDoOutlookEmail Stopped");
                WriteLog("EmailReader CallMailTrackerToDoOutlookEmail Stopped", "TriggerMailReader");
            }
        }

        //private static void MainFlow1_API_Caller(List<ExceptionMailReaderTable> mailList)
        //{
        //    try
        //    {
        //        string html = string.Empty;
        //        string url = "";
        //        url = ConfigCaller.MailTracker_GetMailbagURL;
        //        WriteLog("Step 1 " + url, "MainFlow1_API_Caller");

        //        var serializer = new JavaScriptSerializer();
        //        string DATA = serializer.Serialize(mailList);

        //        html = API_Setup(url, DATA);

        //        try
        //        {

        //            WriteLog(html, "MainFlow1_API_Caller");

        //            List<MailBagTransDto> model = new List<MailBagTransDto>();
        //            model = serializer.Deserialize<List<MailBagTransDto>>(html);
        //            if (model.Count > 0)
        //            {
        //                WriteLog("Step 9 ", "MainFlow1_API_Caller");
        //                AckMailBagTransactions(model.FirstOrDefault());
        //            }

        //            WriteLog(html, "MainFlow1_API_Caller");
        //        }
        //        catch (Exception ex)
        //        {

        //            CallAPI.WriteLog(ex.Message, "MainFlow1_API_Caller");
        //            throw ex;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        CallAPI.WriteLog(ex.Message, "MainFlow1_API_Caller");
        //        throw;
        //    }
        //}

        public static List<ExceptionMailReaderTable> ReadMailItems()
        {
            Application outLookApplication = null;
            NameSpace outLookNameSpace = null;
            MAPIFolder inboxFolder = null;

            Items mailItems = null;
            List<OutLookEmail> listEmailDetails = new List<OutLookEmail>();
            List<ExceptionMailReaderTable> listEmailDetailsTab = new List<ExceptionMailReaderTable>();
            OutLookEmail emailDetails;
            ExceptionMailReaderTable listEmailDetailsObj;
            DataAccess dataAccess = new DataAccess();
            bool isSucess = true;
            string text = "";

            try
            {
                outLookApplication = new Application();
                outLookNameSpace = outLookApplication.GetNamespace("MAPI");


                inboxFolder = outLookNameSpace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);


                var user = outLookNameSpace.CurrentUser;
                Console.WriteLine("Username - " + user.Name);


                var foldername = inboxFolder.Name;
                Console.WriteLine("foldername - " + foldername);


                mailItems = inboxFolder.Items.Restrict("[Unread]=true");

                Console.WriteLine("mailItems.Count >> " + mailItems.Count);


                MailItem mailItem = null;


                foreach (var objItem in mailItems)
                {
                    try
                    {
                        mailItem = null;

                        if (objItem is MailItem)
                        {

                            mailItem = (MailItem)objItem;
                        }


                        if (mailItem == null)
                        {
                            continue;
                        }

                        emailDetails = new OutLookEmail();
                        emailDetails.EmailFrom = mailItem.SenderEmailAddress;
                        emailDetails.EmailSubject = mailItem.Subject;
                        emailDetails.EmailBody = mailItem.Body;

                        listEmailDetails.Add(emailDetails);

                        string mailsubjecttype = "";
                        if ((mailItem.Subject != null) && (mailItem.Subject.Contains(EmailHeaderDefinitions.Mail_Quantity_Discrepancy)))
                            mailsubjecttype = EmailHeaderDefinitions.Mail_Quantity_Discrepancy;
                        if ((mailItem.Subject != null) && (mailItem.Subject.Contains(EmailHeaderDefinitions.Physical_Mail_Not_Received_by_Mailroom)))
                            mailsubjecttype = EmailHeaderDefinitions.Physical_Mail_Not_Received_by_Mailroom;
                        if ((mailItem.Subject != null) && (mailItem.Subject.Contains(EmailHeaderDefinitions.Returned_Mail_Acknowledgement_for_Mail_Quantity_Discrepancy)))
                            mailsubjecttype = EmailHeaderDefinitions.Returned_Mail_Acknowledgement_for_Mail_Quantity_Discrepancy;

                        Console.WriteLine("Email Subject " + mailsubjecttype);
                        //List<string> meilheaderlist = new List<string>();
                        //meilheaderlist.Add(EmailHeaderDefinitions.Mail_Quantity_Discrepancy);
                        //meilheaderlist.Add(EmailHeaderDefinitions.Physical_Mail_Not_Received_by_Mailroom);
                        //meilheaderlist.Add(EmailHeaderDefinitions.Returned_Mail_Acknowledgement_for_Mail_Quantity_Discrepancy);

                        if ((mailItem.Subject != null) && string.IsNullOrEmpty(mailsubjecttype) == false
                            //(mailItem.Subject.Contains("Exception")))
                            //&& (mailItem.Subject.Contains(mailsubjecttype))
                            )
                        {

                            text = mailItem.Body;
                            string[] separatingStringsBody = { "<<", "...", ".", "\t", "\r", "\n" };
                            string[] wordsBody = text.Split(separatingStringsBody, System.StringSplitOptions.RemoveEmptyEntries);
                            string status = "";

                            foreach (var item in wordsBody)
                            {
                                if (item.ToUpper() == "YES")
                                {
                                    status = "YES";
                                    break;
                                }
                                else if (item.ToUpper() == "NO")
                                {
                                    status = "NO";
                                    break;
                                }
                            }

                            Console.WriteLine("Replied Status " + status);

                            //foreach (var item in meilheaderlist)
                            //{
                            text = mailItem.Subject;
                            WriteLog("Email Subject " + mailItem.Subject, "ReadMailItems");

                            string[] separatingStringsSubject = { "Batch No. ", " dated ", "- " + mailsubjecttype };
                            string[] wordsSubject = text.Split(separatingStringsSubject, System.StringSplitOptions.RemoveEmptyEntries);
                            string batchno = wordsSubject[01].Trim();

                            string transactionDateTime = "";
                            if (wordsSubject.Count() > 2)
                            { transactionDateTime = wordsSubject[02]; }

                            string emailIsFor = "";
                            if (wordsSubject.Count() > 3)
                            { emailIsFor = wordsSubject[03].Trim(); }

                            WriteLog("Email Body " + mailItem.Body, "ReadMailItems");

                            if (!string.IsNullOrEmpty(mailItem.Body))
                            {
                                //isSucess = dataAccess.insert_mail_records(status, batchno);
                                listEmailDetailsObj = new ExceptionMailReaderTable()
                                {
                                    BatchNo = batchno.Trim(),
                                    EmailReplyStatus = status.Trim(),
                                    Subject = mailItem.Subject,
                                    MailBody = mailItem.Body,
                                    TransactionDateTime = transactionDateTime,
                                    EmailFrom = emailDetails.EmailFrom,
                                    EmailFor = mailsubjecttype,//emailIsFor.Trim()
                                };

                                OutgoingmailBatchModel objEnquiryDetail = new OutgoingmailBatchModel();
                                objEnquiryDetail = DataAccess.get_batchno_details_ExceptionEmail(batchno.Trim());
                                if (objEnquiryDetail != null)
                                {
                                    listEmailDetailsObj.ExceptionStatus = objEnquiryDetail.ExceptionStatus;
                                    listEmailDetailsObj.Status = objEnquiryDetail.Status;
                                }

                                listEmailDetailsTab.Add(listEmailDetailsObj);

                                isSucess = dataAccess.insert_mail_records(listEmailDetailsObj);
                                Console.WriteLine(isSucess);

                                if (isSucess)
                                {
                                    EmailReader_DL.DataAccess.WriteLog("ReadMailItems", "Success " + batchno);
                                }
                                else
                                {
                                    EmailReader_DL.DataAccess.WriteLog("ReadMailItems", "Fail " + batchno);
                                }

                                mailItem.UnRead = false;
                                mailItem.Save();
                                text = "";

                            }
                        }

                        //}

                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        EmailReader_DL.DataAccess.WriteLog("ReadMailItems", "Fail " + ex.Message + " - " + ex.StackTrace);
                        continue;
                    }

                }


            }
            catch (System.Exception ex)
            {
                EmailReader_DL.DataAccess.WriteLog("ReadMailItems", "Fail " + ex.Message + " - " + ex.StackTrace);

                Console.WriteLine(ex.Message);
            }
            finally
            {
                ReleaseComObject(mailItems);
                ReleaseComObject(inboxFolder);
                ReleaseComObject(outLookNameSpace);
                ReleaseComObject(outLookApplication);
            }

            return listEmailDetailsTab;

        }

        private static void ReleaseComObject(object obj)
        {
            if (obj != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            }
        }

        private static bool If_the_Current_Batch_Enabled_for_Email_Reading_and_Update_the_Status()
        {
            ReturnSystemPMModel obj = DataAccess.get_system_parameter_single("Current_Batch_Enabled_Email_Reading");
            if (obj != null && obj.SP_Value == "1")
            {
                //check time 1
                return CheckTimeFrame1();
                //ReturnSystemPMModel obj_Session1 = DataAccess.get_system_parameter_single("Current_Batch_Enabled_Email_Reading_Session1");
                //if (obj_Session1 != null)
                //{
                //    if (DateTime.Now.Hour.ToString() == obj_Session1.SP_Value)
                //    {
                //        return true;
                //    }
                //}

                //check time 2
                return CheckTimeFrame2();
                //ReturnSystemPMModel obj_Session2 = DataAccess.get_system_parameter_single("Current_Batch_Enabled_Email_Reading_Session2");
                //if (obj_Session2 != null)
                //{
                //    if (DateTime.Now.Hour.ToString() == obj_Session2.SP_Value)
                //    {
                //        return true;
                //    }
                //}

                //check time 3
                return CheckTimeFrame3();
                //ReturnSystemPMModel obj_Session3 = DataAccess.get_system_parameter_single("Current_Batch_Enabled_Email_Reading_Session3");
                //if (obj_Session3 != null)
                //{
                //    if (DateTime.Now.Hour.ToString() == obj_Session3.SP_Value)
                //    {
                //        return true;
                //    }
                //}
            }
            else
            {
                return false;
            }
            return false;
        }

        public static bool CheckTimeFrame1()
        {
            ReturnSystemPMModel obj_SessionFrom = SystemParameter_Data.PredefinedProperties.ServiceRelated.Exceptions_EmailReder_Process_Session1_From();
            ReturnSystemPMModel obj_SessionTo = SystemParameter_Data.PredefinedProperties.ServiceRelated.Exceptions_EmailReder_Process_Session1_To();

            if (obj_SessionFrom != null)
            {
                int fromMinutes = 0;
                int fromHours = 0;

                var fromtime = obj_SessionFrom.SP_Value.Split(':');
                int.TryParse(fromtime[1], out fromMinutes);
                int.TryParse(fromtime[0], out fromHours);

                DateTime fromTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, fromHours, fromMinutes, 0);

                int toMinutes = 0;
                int toHours = 0;

                var totime = obj_SessionTo.SP_Value.Split(':');
                int.TryParse(totime[1], out toMinutes);
                int.TryParse(totime[0], out toHours);

                DateTime toTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, toHours, toMinutes, 0);

                if (DateTime.Now >= fromTime && DateTime.Now <= toTime)
                {
                    return true;
                }

            }
            return false;
        }

        public static bool CheckTimeFrame2()
        {
            ReturnSystemPMModel obj_SessionFrom = SystemParameter_Data.PredefinedProperties.ServiceRelated.Exceptions_EmailReder_Process_Session2_From();
            ReturnSystemPMModel obj_SessionTo = SystemParameter_Data.PredefinedProperties.ServiceRelated.Exceptions_EmailReder_Process_Session2_To();

            if (obj_SessionFrom != null)
            {
                int fromMinutes = 0;
                int fromHours = 0;

                var fromtime = obj_SessionFrom.SP_Value.Split(':');
                int.TryParse(fromtime[1], out fromMinutes);
                int.TryParse(fromtime[0], out fromHours);

                DateTime fromTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, fromHours, fromMinutes, 0);

                int toMinutes = 0;
                int toHours = 0;

                var totime = obj_SessionTo.SP_Value.Split(':');
                int.TryParse(totime[1], out toMinutes);
                int.TryParse(totime[0], out toHours);

                DateTime toTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, toHours, toMinutes, 0);

                if (DateTime.Now >= fromTime && DateTime.Now <= toTime)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckTimeFrame3()
        {
            ReturnSystemPMModel obj_SessionFrom = SystemParameter_Data.PredefinedProperties.ServiceRelated.Exceptions_EmailReder_Process_Session3_From();
            ReturnSystemPMModel obj_SessionTo = SystemParameter_Data.PredefinedProperties.ServiceRelated.Exceptions_EmailReder_Process_Session3_To();

            if (obj_SessionFrom != null)
            {
                int fromMinutes = 0;
                int fromHours = 0;

                var fromtime = obj_SessionFrom.SP_Value.Split(':');
                int.TryParse(fromtime[1], out fromMinutes);
                int.TryParse(fromtime[0], out fromHours);

                DateTime fromTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, fromHours, fromMinutes, 0);

                int toMinutes = 0;
                int toHours = 0;

                var totime = obj_SessionTo.SP_Value.Split(':');
                int.TryParse(totime[1], out toMinutes);
                int.TryParse(totime[0], out toHours);

                DateTime toTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, toHours, toMinutes, 0);

                if (DateTime.Now >= fromTime && DateTime.Now <= toTime)
                {
                    return true;
                }

            }
            return false;
        }


        //private static void MainFlow1(List<ExceptionMailReaderTable> objloop)
        //{
        //    try
        //    {
        //        //List<OutLookEamail_TransactionHeader> objloop = Get_Unread_Cutomer_Replied_Email_List_from_the_Inbox_by_Email_Received_Date_Date_ASC();
        //        //While End of Email List
        //        foreach (var item in objloop)
        //        {
        //            //If the Email is for "Continue the Discrepancy"
        //            if (If_the_mail_is_for_Continue_the_Discrepancy(item.EmailFor) == true)
        //            {     //If Customer Reply is "Yes"
        //                if (item.Status.ToUpper() == "YES")
        //                {
        //                    //If Exception Status is "Pending"
        //                    if (item.ExceptionStatus == "Pending")
        //                    {
        //                        //Set Exception Status = "Closed"
        //                        item.ExceptionStatus = "Closed";
        //                        //system Specify the Auto Remark
        //                        system_Specify_the_Auto_Remark();
        //                    }
        //                }
        //                else
        //                {
        //                    //If Exception Status is "Pending"
        //                    if (item.ExceptionStatus == "Pending")
        //                    {  //Set Exception Status =  "Pending Return Confirmation"
        //                        item.ExceptionStatus = "Pending Return Confirmation";
        //                        //system Specify the Auto Remark
        //                        system_Specify_the_Auto_Remark();
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                //If   the Email is for   "Return    Confirmation"
        //                if (If_the_Email_is_for_Return_Confirmation(item.EmailFor) == true)
        //                {
        //                    //If     Customer Reply is     "Yes" 
        //                    if (item.Status.ToUpper() == "YES")
        //                    {
        //                        //If Exception Status is"Pending Return Confirmation" or"Return not Received"
        //                        if (If_Exception_Status_is_Pending_Return_Confirmation_or_Return_not_Received(item.ExceptionStatus) == true)
        //                        {
        //                            //Set Exception Status = "Returned"
        //                            item.ExceptionStatus = "Returned";
        //                            //system Specify the Auto Remark
        //                            system_Specify_the_Auto_Remark();
        //                        }
        //                    }
        //                    else
        //                    {
        //                        //If    Exception Status is    "Pending Return Confirmation" or"Return not Received"      
        //                        if (If_Exception_Status_is_Pending_Return_Confirmation_or_Return_not_Received(item.ExceptionStatus) == true)
        //                        {
        //                            //Set Exception Status = "Return not Received"
        //                            item.ExceptionStatus = "Return not Received";
        //                            //system Specify the Auto Remark
        //                            system_Specify_the_Auto_Remark();
        //                        }
        //                    }
        //                }
        //                //If    the Email is for    "No Mail     Received"
        //                else if (If_the_Email_is_for_No_Mail_Received(item.EmailFor) == true)
        //                {
        //                    //If     Customer Reply is     "Yes" 
        //                    if (item.Status.ToUpper() == "YES")
        //                    {
        //                        //If Exception Status is"Pending"
        //                        if (If_Exception_Status_is_Pending(item.ExceptionStatus) == true)
        //                        {
        //                            //Set Exception Status = "Canceled
        //                            item.ExceptionStatus = "Canceled";
        //                            //system Specify the Auto Remark
        //                            system_Specify_the_Auto_Remark();
        //                        }
        //                    }
        //                    else
        //                    {
        //                        //system Specify the Auto Remark
        //                        system_Specify_the_Auto_Remark();
        //                    }

        //                }
        //            }

        //            DataAccess.UpdateOutgoingExceptionStatus(item);
        //        }

        //    }
        //    catch (System.Exception ex)
        //    {
        //        EmailReader_DL.DataAccess.WriteLog("MainFlow1", "Fail " + ex.Message + " - " + ex.StackTrace);
        //    }
        //}

        //private static void system_Specify_the_Auto_Remark()
        //{
        //    throw new NotImplementedException();
        //}

        ////public static List<OutLookEamail_TransactionHeader> Get_Unread_Cutomer_Replied_Email_List_from_the_Inbox_by_Email_Received_Date_Date_ASC()
        ////{
        ////    List<OutLookEamail_TransactionHeader> objHeadList = new List<OutLookEamail_TransactionHeader>();

        ////    objHeadList = read_notsyncedmail_with_transaction();

        ////    return objHeadList;
        ////}

        public static bool WriteLog(string LogText, string Action)
        {

            try
            {
                if (errorLogPath == string.Empty)
                {
                    return false;
                }


                if (!System.IO.Directory.Exists(errorLogPath))
                {
                    System.IO.Directory.CreateDirectory(errorLogPath);
                }


                string strFileName = errorLogPath + "\\" + "Kiosk" + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

                StringBuilder strLog = new StringBuilder();
                strLog.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - ");
                strLog.Append(" KioskReader ");
                strLog.Append(" - " + Action);
                strLog.Append(" - " + LogText);

                if (!System.IO.File.Exists(strFileName))
                {
                    using (System.IO.StreamWriter sw = System.IO.File.CreateText(strFileName))
                    {
                        sw.WriteLine(strLog.ToString());
                    }
                }
                else
                {
                    using (System.IO.StreamWriter sw = System.IO.File.AppendText(strFileName))
                    {
                        sw.WriteLine(strLog.ToString());
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        //private static bool If_the_mail_is_for_Continue_the_Discrepancy(string EmailSubject)
        //{
        //    if (EmailSubject.ToUpper().Contains("DISCREPANCY"))
        //    { return true; }
        //    else { return false; }
        //}

        //private static bool If_the_Email_is_for_No_Mail_Received(string EmailSubject)
        //{
        //    if (EmailSubject.ToUpper().Contains("MAIL NOT RECEIVED"))
        //    { return true; }
        //    else { return false; }
        //}

        //private static bool If_the_Email_is_for_Return_Confirmation(string EmailSubject)//not implemented
        //{
        //    if (EmailSubject.ToUpper().Contains("RETURN"))
        //    { return true; }
        //    else { return false; }
        //}

        //private static bool If_Exception_Status_is_Pending_Return_Confirmation_or_Return_not_Received(string Exception_Status)
        //{
        //    if (Exception_Status == "Pending Return Confirmation" || Exception_Status == "Return Not Received")
        //        return true;
        //    else
        //        return false;
        //}

        //private static bool If_Exception_Status_is_Pending(string Exception_Status)
        //{
        //    if (Exception_Status == "Pending")
        //        return true;
        //    else
        //        return false;
        //}

    }

    public class ReturnSystemPMModel
    {
        public string SP_ID { get; set; }
        public string SP_Description { get; set; }
        public string SP_Value { get; set; }
        public string SP_Type { get; set; }
        public int SP_DisplaySeq { get; set; }
    }

    public class EmailHeaderDefinitions
    {
        public const string Mail_Quantity_Discrepancy = "Mail Quantity Discrepancy";
        public const string Returned_Mail_Acknowledgement_for_Mail_Quantity_Discrepancy = "Returned Mail Acknowledgement for Mail Quantity Discrepancy";
        public const string Physical_Mail_Not_Received_by_Mailroom = "Physical Mail Not Received by Mailroom";
    }
}
