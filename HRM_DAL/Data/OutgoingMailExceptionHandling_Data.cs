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
//using Newtonsoft.Json;
using email_sender.Models;

namespace HRM_DAL.Data
{
    public class OutgoingMailExceptionHandling_Data
    {
        private static LogError objError = new LogError();
        static List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();

        public static List<ReturnResponse> RunProcess()
        {
            ReturnResponse objUserHead = new ReturnResponse();

            try
            {
                //using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                //{
                MainFlow2_Related.MainFlow2();
                //}
            }
            catch (Exception ex)
            {
                objUserHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "RunProcess", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "RunProcess", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "RunProcess", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "RunProcess", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objUserHeadList;
        }

        public static class MainFlow1_Related
        {
            public static List<ReturnResponse> MainFlow1(List<ExceptionMailReaderTable> objloop)
            {
                ReturnResponse objUserHead = new ReturnResponse();

                try
                {
                    string OldStatus = "";
                    objError.WriteLog(0, "OutgoingMailExceptionHandlingData", "MainFlow1", "Records Count " + objloop.Count);
                    //List<OutLookEamail_TransactionHeader> objloop = Get_Unread_Cutomer_Replied_Email_List_from_the_Inbox_by_Email_Received_Date_Date_ASC();
                    //While End of Email List
                    foreach (var item in objloop)
                    {
                        //If the Email is for "Continue the Discrepancy"
                        objError.WriteLog(0, "OutgoingMailExceptionHandlingData", "MainFlow1", "Email is For " + item.EmailFor);
                        if (If_the_mail_is_for_Continue_the_Discrepancy(item.EmailFor) == true)
                        {
                            //If Customer Reply is "Yes"
                            objError.WriteLog(0, "OutgoingMailExceptionHandlingData", "MainFlow1", "Email Status " + item.Status.ToUpper());
                            if (item.EmailReplyStatus.ToUpper() == "YES")
                            {
                                //If Exception Status is "Pending"
                                objError.WriteLog(0, "OutgoingMailExceptionHandlingData", "MainFlow1", "Ex Status " + item.ExceptionStatus);
                                if (If_Exception_Status_is_Ongoing(item.ExceptionStatus) == true)
                                {
                                    OldStatus = item.ExceptionStatus;
                                    //Set Exception Status = "Closed"
                                    item.ExceptionStatus = ExceptionStatusDefinitions.Closed;
                                    item.ProcessStage = ProcessStageDefinitions.Customer_Replied_Yes;
                                    item.Status = BatchStatusDefinitions.Received;
                                    //system Specify the Auto Remark
                                    //system_Specify_the_Auto_Remark();
                                    OutgoingMailExceptionHandling_Data.UpdateOutgoingExceptionStatus(item, OldStatus);
                                    objError.WriteLog(0, "OutgoingMailExceptionHandlingData", "MainFlow1", "Ex Status " + item.ExceptionStatus);
                                    objError.WriteLog(0, "OutgoingMailExceptionHandlingData", "MainFlow1", "Ex ProcessStage " + item.ProcessStage);
                                }
                                else
                                {
                                    OldStatus = item.ExceptionStatus;
                                    item.ProcessStage = ProcessStageDefinitions.Customer_Replied_Yes;
                                    OutgoingMailExceptionHandling_Data.UpdateOutgoingExceptionStatus(item, OldStatus);
                                    objError.WriteLog(0, "OutgoingMailExceptionHandlingData", "MainFlow1", "Ex Status " + item.ExceptionStatus);
                                    objError.WriteLog(0, "OutgoingMailExceptionHandlingData", "MainFlow1", "Ex ProcessStage " + item.ProcessStage);
                                }
                            }
                            else
                            {
                                //If Exception Status is "Pending"
                                if (If_Exception_Status_is_Ongoing(item.ExceptionStatus) == true)
                                {
                                    OldStatus = item.ExceptionStatus;
                                    //Set Exception Status =  "Pending Return Confirmation"
                                    //item.ExceptionStatus = "Pending Return Confirmation";
                                    item.ProcessStage = ProcessStageDefinitions.Customer_Replied_No;

                                    //EmailSendingObject_ExceptionHandling model = get_batchno_details_ExceptionEmail(item.BatchNo);

                                    //EmailSender_Related.Send_Returned_Mail_Acknowledgement_Discrepancy_Email_Notification(model);

                                    //system Specify the Auto Remark
                                    //system_Specify_the_Auto_Remark();
                                    OutgoingMailExceptionHandling_Data.UpdateOutgoingExceptionStatus(item, OldStatus);
                                }
                                else
                                {
                                    item.ProcessStage = ProcessStageDefinitions.Customer_Replied_No;
                                    OldStatus = item.ExceptionStatus;
                                    OutgoingMailExceptionHandling_Data.UpdateOutgoingExceptionStatus(item, OldStatus);
                                }
                            }
                        }
                        else
                        {
                            //If   the Email is for   "Return    Confirmation"
                            if (If_the_Email_is_for_Return_Confirmation(item.EmailFor) == true)
                            {
                                //If     Customer Reply is     "Yes" 
                                if (item.EmailReplyStatus.ToUpper() == "YES")
                                {
                                    OldStatus = item.ExceptionStatus;
                                    //If Exception Status is"Pending Return Confirmation" or"Return not Received"
                                    //if (If_Exception_Status_is_Pending_Return_Confirmation_or_Return_not_Received(item.ExceptionStatus) == true)
                                    if (If_Exception_Status_is_Ongoing(item.ExceptionStatus) == true)
                                    {
                                        //Set Exception Status = "Returned"
                                        item.ExceptionStatus = ExceptionStatusDefinitions.Returned;// "Returned";
                                        item.ProcessStage = ProcessStageDefinitions.Exception_Closed_Customer_Replied;
                                        item.Status = BatchStatusDefinitions.Completed;
                                        //system Specify the Auto Remark
                                        //system_Specify_the_Auto_Remark();
                                        OutgoingMailExceptionHandling_Data.UpdateOutgoingExceptionStatus(item, OldStatus);
                                    }
                                    else
                                    {
                                        item.ProcessStage = ProcessStageDefinitions.Exception_Closed_Customer_Replied;
                                        OldStatus = item.ExceptionStatus;
                                        OutgoingMailExceptionHandling_Data.UpdateOutgoingExceptionStatus(item, OldStatus);
                                    }
                                }
                                else
                                {
                                    //If    Exception Status is    "Pending Return Confirmation" or"Return not Received"      
                                    //if (If_Exception_Status_is_Pending_Return_Confirmation_or_Return_not_Received(item.ExceptionStatus) == true)
                                    if (If_Exception_Status_is_Ongoing(item.ExceptionStatus) == true)
                                    {
                                        OldStatus = item.ExceptionStatus;
                                        //Set Exception Status = "Return not Received"
                                        //item.ExceptionStatus = ExceptionStatusDefinitions.;// "Return not Received";
                                        item.ProcessStage = ProcessStageDefinitions.Customer_Did_Not_Receive_Returned_Mails;
                                        //system Specify the Auto Remark
                                        //system_Specify_the_Auto_Remark();
                                        OutgoingMailExceptionHandling_Data.UpdateOutgoingExceptionStatus(item, OldStatus);
                                    }
                                    else
                                    {
                                        item.ProcessStage = ProcessStageDefinitions.Customer_Did_Not_Receive_Returned_Mails;
                                        OldStatus = item.ExceptionStatus;
                                        OutgoingMailExceptionHandling_Data.UpdateOutgoingExceptionStatus(item, OldStatus);
                                    }
                                }
                            }
                            //If    the Email is for    "No Mail     Received"
                            else if (If_the_Email_is_for_No_Mail_Received(item.EmailFor) == true)
                            {
                                //If     Customer Reply is     "Yes" 
                                if (item.EmailReplyStatus.ToUpper() == "YES")
                                {
                                    //If Exception Status is"Pending"
                                    if (If_Exception_Status_is_Pending(item.ExceptionStatus) == true)
                                    {
                                        OldStatus = item.ExceptionStatus;
                                        //Set Exception Status = "Canceled
                                        item.ExceptionStatus = ExceptionStatusDefinitions.Canceled;// "Canceled";
                                        item.ProcessStage = ProcessStageDefinitions.No_Mails_Received_Customer_Replied_Yes;
                                        item.Status = BatchStatusDefinitions.Cancelled;// "Canceled";
                                        //system Specify the Auto Remark
                                        //system_Specify_the_Auto_Remark();
                                        OutgoingMailExceptionHandling_Data.UpdateOutgoingExceptionStatus(item, OldStatus);
                                    }
                                    else
                                    {
                                        item.ProcessStage = ProcessStageDefinitions.No_Mails_Received_Customer_Replied_Yes;
                                        OldStatus = item.ExceptionStatus;
                                        OutgoingMailExceptionHandling_Data.UpdateOutgoingExceptionStatus(item, OldStatus);
                                    }
                                }
                                else
                                {
                                    OldStatus = item.ExceptionStatus;
                                    item.ProcessStage = ProcessStageDefinitions.No_Mails_Received_Customer_Reply_No;
                                    //system Specify the Auto Remark
                                    //system_Specify_the_Auto_Remark();
                                    OutgoingMailExceptionHandling_Data.UpdateOutgoingExceptionStatus(item, OldStatus);
                                }

                            }
                        }

                    }

                }
                catch (System.Exception ex)
                {
                    objUserHead = new ReturnResponse
                    {
                        resp = false,
                        msg = ex.Message.ToString()
                    };
                    objUserHeadList.Add(objUserHead);

                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "MainFlow1", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "MainFlow1", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "MainFlow1", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "MainFlow1", "Inner Exception Message: " + ex.InnerException.Message);
                    }
                }
                return objUserHeadList;
            }

            //private static void system_Specify_the_Auto_Remark()
            //{
            //    throw new NotImplementedException();
            //}

            //public static List<OutLookEamail_TransactionHeader> Get_Unread_Cutomer_Replied_Email_List_from_the_Inbox_by_Email_Received_Date_Date_ASC()
            //{
            //    List<OutLookEamail_TransactionHeader> objHeadList = new List<OutLookEamail_TransactionHeader>();

            //    objHeadList = read_notsyncedmail_with_transaction();

            //    return objHeadList;
            //}


            private static bool If_the_mail_is_for_Continue_the_Discrepancy(string EmailSubject)
            {
                //if (EmailSubject.ToUpper().Contains("DISCREPANCY"))
                if (EmailSubject == EmailHeaderDefinitions.Mail_Quantity_Discrepancy)
                { return true; }
                else { return false; }
            }

            private static bool If_the_Email_is_for_No_Mail_Received(string EmailSubject)
            {
                //if (EmailSubject.ToUpper().Contains("MAIL NOT RECEIVED"))
                if (EmailSubject == EmailHeaderDefinitions.Physical_Mail_Not_Received_by_Mailroom)
                { return true; }
                else { return false; }
            }

            private static bool If_the_Email_is_for_Return_Confirmation(string EmailSubject)
            {
                //if (EmailSubject.ToUpper().Contains("RETURN"))
                if (EmailSubject == EmailHeaderDefinitions.Returned_Mail_Acknowledgement_for_Mail_Quantity_Discrepancy)
                { return true; }
                else { return false; }
            }

            private static bool If_Exception_Status_is_Pending_Return_Confirmation_or_Return_not_Received(string Exception_Status)
            {
                if (Exception_Status == "Pending Return Confirmation" || Exception_Status == "Return Not Received")
                    return true;
                else
                    return false;
            }

            private static bool If_Exception_Status_is_Pending(string Exception_Status)
            {
                if (Exception_Status == ExceptionStatusDefinitions.Ongoing)//"Pending")
                    return true;
                else
                    return false;
            }
        }

        public static class MainFlow2_Related
        {
            public static void MainFlow2()
            {
                ReturnResponse objUserHead = new ReturnResponse();
                try
                {

                    //If the Current Batch Enabled for Email  Exception Notification sending
                    if (If_the_Current_Batch_Enabled_for_Email_Exception_Notification_sending() == true)
                    {
                        //While     End of Exception Batch     List where ExceptionStatus not in ("Closed", "Returned", "Cancelled")

                        List<OutLookEamail_TransactionHeader> objloop = While_End_of_Exception_Batch_List_where_Exception_Status_not_in_Closed_Returned_Cancelled();

                        int Discipany_Notify_Count = 0;
                        int Return_Confirmation_Notify_Count = 0;
                        int Return_Not_Received_Notify_Count = 0;
                        int No_Mail_Receive_Notify_Count = 0;
                        int Pending_Return_Confirmation_Notify_Count = 0;

                        //string Batch_Exception_Type = "";

                        List<NotificatioModel> notificationList = new List<NotificatioModel>();
                        //string CustomerName = "";

                        int SN = 0;
                        EmailSendingObject_ExceptionHandling obj = new EmailSendingObject_ExceptionHandling();
                        ExceptionMailReaderTable itemObj = new ExceptionMailReaderTable();
                        string OldStatus = "";

                        foreach (var item in objloop)
                        {

                            string logobject = JsonSerializer.Serialize(item);

                            new WhiteLog("MainFlow2 - update log" + logobject, "OutgoingMailExceptionHandling_Data", "MainFlow2", true, true);

                            if (string.IsNullOrEmpty(item.EmailAddress) == false)
                            {
                                OldStatus = item.ExceptionStatus;

                                Discipany_Notify_Count = item.Discipany_Notify_Count;
                                Return_Confirmation_Notify_Count = item.Return_Confirmation_Notify_Count;
                                Return_Not_Received_Notify_Count = item.Return_Not_Received_Notify_Count;
                                No_Mail_Receive_Notify_Count = item.No_Mail_Receive_Notify_Count;
                                Pending_Return_Confirmation_Notify_Count = item.Pending_Return_Confirmation_Notify_Count;

                                obj = new EmailSendingObject_ExceptionHandling()
                                {
                                    //batchdatetime = item.batchdatetime,
                                    BatchNo = item.BatchNumber,
                                    KioskNo = item.KioskNo,
                                    StaffID = item.StaffID,
                                    StaffName = item.StaffName,
                                    PCCode = item.PCCode,
                                    MailType = item.MailType,
                                    declaredQty = item.declaredQty,
                                    BatchCreatedOn = item.BatchCreatedOn,
                                    BatchReceivedOn = item.BatchReceivedOn,
                                    BatchProcessedOn = item.BatchProcessedOn,
                                    CentralMailroomNumber = item.CentralMailroomNumber,
                                    actualQty = item.actualQty,
                                    EmailAddress = item.EmailAddress,
                                    CustomerName = item.CustomerName,
                                    BusinessUnit = item.BusinessUnit
                                };

                                SN++;

                                // A.Exception Status -Ongoing, Process Stage -Send Notification Pending => Notification Sent Reply Pending
                                if (If_Exception_Status_is_Ongoing(item.ExceptionStatus) == true)
                                {
                                    if (item.ProcessStage == ProcessStageDefinitions.Send_Notification_Pending)
                                    {

                                        //    2 No Mail Received
                                        if (item.actualQty == 0)
                                        {
                                            EmailSender_Related.Send_No_Mail_Received_Email_Notification(obj);

                                            item.ProcessStage = ProcessStageDefinitions.Notification_Sent_and_Reply_Pending;
                                            item.Discipany_Notify_Count++;
                                            Discipany_Notify_Count = item.Discipany_Notify_Count;
                                            itemObj = EmailSenDBUpdate(Discipany_Notify_Count, Return_Confirmation_Notify_Count, Return_Not_Received_Notify_Count, No_Mail_Receive_Notify_Count, Pending_Return_Confirmation_Notify_Count, OldStatus, item);
                                        }
                                        //    1 Discrepency
                                        else if (item.actualQty != item.declaredQty)
                                        {
                                            EmailSender_Related.Send_Discrepancy_Email_Notification(obj);

                                            item.ProcessStage = ProcessStageDefinitions.Notification_Sent_and_Reply_Pending;
                                            item.Discipany_Notify_Count++;
                                            Discipany_Notify_Count = item.Discipany_Notify_Count;
                                            itemObj = EmailSenDBUpdate(Discipany_Notify_Count, Return_Confirmation_Notify_Count, Return_Not_Received_Notify_Count, No_Mail_Receive_Notify_Count, Pending_Return_Confirmation_Notify_Count, OldStatus, item);
                                        }


                                    }

                                    //B.Exception Status -Ongoing, Process Stage -Notification Sent Reply Pending
                                    else if (item.ProcessStage == ProcessStageDefinitions.Notification_Sent_and_Reply_Pending)
                                    {
                                        //    2 No Mail Received
                                        if (item.actualQty == 0)
                                        {
                                            if (If_Discrepancy_Notify_Count_Max_Discripancy_Notify_Count(Discipany_Notify_Count) == true)
                                            {
                                                //        if count is exceeded - exception status - expired, process stage -Exception Expired Customer Not Replied
                                                item.ExceptionStatus = ExceptionStatusDefinitions.Expired;
                                                item.ProcessStage = ProcessStageDefinitions.Exception_Expired_Customer_Not_Replied;
                                                //        send email to mailroom
                                                notificationList.Add(new NotificatioModel() { BatchTransactionNumber = item.BatchNumber, ExceptionType = item.ExceptionType, TransactionDate = item.BatchCreatedOn, SN = SN });
                                                itemObj = StatusDBUpdate(Discipany_Notify_Count, Return_Confirmation_Notify_Count, Return_Not_Received_Notify_Count, No_Mail_Receive_Notify_Count, Pending_Return_Confirmation_Notify_Count, OldStatus, item);
                                            }
                                            else
                                            {
                                                EmailSender_Related.Send_No_Mail_Received_Email_Notification(obj);

                                                item.Discipany_Notify_Count++;
                                                Discipany_Notify_Count = item.Discipany_Notify_Count;
                                                itemObj = EmailSenDBUpdate(Discipany_Notify_Count, Return_Confirmation_Notify_Count, Return_Not_Received_Notify_Count, No_Mail_Receive_Notify_Count, Pending_Return_Confirmation_Notify_Count, OldStatus, item);
                                            }
                                        }
                                        //    1 Discrepency
                                        else if (item.actualQty != item.declaredQty)
                                        {
                                            if (If_Discrepancy_Notify_Count_Max_Discripancy_Notify_Count(Discipany_Notify_Count) == true)
                                            {
                                                //        if count is exceeded - exception status - expired, process stage -Exception Expired Customer Not Replied
                                                item.ExceptionStatus = ExceptionStatusDefinitions.Expired;
                                                item.ProcessStage = ProcessStageDefinitions.Exception_Expired_Customer_Not_Replied;
                                                //        send email to mailroom
                                                notificationList.Add(new NotificatioModel() { BatchTransactionNumber = item.BatchNumber, ExceptionType = item.ExceptionType, TransactionDate = item.BatchCreatedOn, SN = SN });
                                                itemObj = StatusDBUpdate(Discipany_Notify_Count, Return_Confirmation_Notify_Count, Return_Not_Received_Notify_Count, No_Mail_Receive_Notify_Count, Pending_Return_Confirmation_Notify_Count, OldStatus, item);
                                            }
                                            else
                                            {
                                                EmailSender_Related.Send_Discrepancy_Email_Notification(obj);

                                                item.Discipany_Notify_Count++;
                                                Discipany_Notify_Count = item.Discipany_Notify_Count;
                                                itemObj = EmailSenDBUpdate(Discipany_Notify_Count, Return_Confirmation_Notify_Count, Return_Not_Received_Notify_Count, No_Mail_Receive_Notify_Count, Pending_Return_Confirmation_Notify_Count, OldStatus, item);
                                            }
                                        }

                                    }

                                    //C.Exception Stauts -Ongoing, Process Stage -Customer Replied No
                                    else if (item.ProcessStage == ProcessStageDefinitions.Customer_Replied_No)
                                    {
                                        //    2 No Mail Received
                                        //        (Current Date - Exception Created Date) >= n working Days => Cancellation email
                                        if (item.actualQty == 0)
                                        {
                                            if (If_Current_Date_Exception_Created_Date__n_working_Days(item.Exception_Created_Date) == true)
                                            {
                                                //Set Exception Status = "Cancelled"
                                                item.ExceptionStatus = ExceptionStatusDefinitions.Expired;
                                                item.Status = BatchStatusDefinitions.Cancelled;// "Cancelled";
                                                //Send Batch Cancellation Email
                                                EmailSender_Related.Send_Batch_Cancellation_Email(obj);
                                                itemObj = EmailSenDBUpdate(Discipany_Notify_Count, Return_Confirmation_Notify_Count, Return_Not_Received_Notify_Count, No_Mail_Receive_Notify_Count, Pending_Return_Confirmation_Notify_Count, OldStatus, item);
                                            }
                                        }
                                        //    1 Discrepency->Return Mail Ack for Mail quantity discrepency email
                                        else if (item.actualQty != item.declaredQty)
                                        {
                                            EmailSender_Related.Send_Returned_Mail_Acknowledgement_Discrepancy_Email_Notification(obj);

                                            //      process stage - return confitmation sent
                                            item.ProcessStage = ProcessStageDefinitions.Returned_Confirmation_Sent;
                                            itemObj = EmailSenDBUpdate(Discipany_Notify_Count, Return_Confirmation_Notify_Count, Return_Not_Received_Notify_Count, No_Mail_Receive_Notify_Count, Pending_Return_Confirmation_Notify_Count, OldStatus, item);
                                        }

                                    }

                                    else if (item.ProcessStage == ProcessStageDefinitions.Returned_Confirmation_Sent)
                                    {
                                        //D.Exception Status -Ongoing, Process Stage -Return Confirmation Sent

                                        //    1 Discrepency
                                        if (item.actualQty != item.declaredQty)
                                        {
                                            if (If_Pending_Return_Confirmation_Notify_Count_Max_Pending_Return_Confirmation_Notify_Count(Pending_Return_Confirmation_Notify_Count) == true)
                                            {
                                                //        if count is exceeded - exception status - expired, process stage -Exception Expired Customer Not Replied
                                                item.ExceptionStatus = ExceptionStatusDefinitions.Expired;
                                                item.ProcessStage = ProcessStageDefinitions.Exception_Expired_Customer_Not_Replied;

                                                //        send email to mailroom
                                                notificationList.Add(new NotificatioModel() { BatchTransactionNumber = item.BatchNumber, ExceptionType = item.ExceptionType, TransactionDate = item.BatchCreatedOn, SN = SN });
                                                itemObj = StatusDBUpdate(Discipany_Notify_Count, Return_Confirmation_Notify_Count, Return_Not_Received_Notify_Count, No_Mail_Receive_Notify_Count, Pending_Return_Confirmation_Notify_Count, OldStatus, item);
                                            }
                                        }
                                    }

                                    else if (item.ProcessStage == ProcessStageDefinitions.Customer_Did_Not_Receive_Returned_Mails)
                                    {
                                        //E.Exception Status -Ongoing, Process Stage -Customer Did Not Receive Returned Mails

                                        //    1 Discrepency
                                        if (item.actualQty != item.declaredQty)
                                        {
                                            if (If_Return_Not_Received_Notify_Count_Max_Return_Not_Received_Notify_Count(Return_Not_Received_Notify_Count) == true)
                                            {
                                                //        if count is exceeded - exception status - expired, process stage -Exception Expired Customer Not Replied
                                                item.ExceptionStatus = ExceptionStatusDefinitions.Expired;
                                                item.ProcessStage = ProcessStageDefinitions.Customer_Did_Not_Receive_Returned_Mails;
                                                //        send email to mailroom
                                                notificationList.Add(new NotificatioModel() { BatchTransactionNumber = item.BatchNumber, ExceptionType = item.ExceptionType, TransactionDate = item.BatchCreatedOn, SN = SN });
                                                itemObj = StatusDBUpdate(Discipany_Notify_Count, Return_Confirmation_Notify_Count, Return_Not_Received_Notify_Count, No_Mail_Receive_Notify_Count, Pending_Return_Confirmation_Notify_Count, OldStatus, item);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //Mailroom email should be a single email.
                        if (notificationList.Count > 0)
                        {
                            EmailSender_Related.Send_Email_Notification_to_Mail_Room_Staff_to_Handle_the_Exception_Manually(notificationList, "", ConfigCaller.Default_BusinessUnit);
                        }
                    }
                }
                catch (Exception ex)
                {
                    objUserHead = new ReturnResponse
                    {
                        resp = false,
                        msg = ex.Message.ToString()
                    };
                    objUserHeadList.Add(objUserHead);

                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "MainFlow2", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "MainFlow2", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "MainFlow2", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "MainFlow2", "Inner Exception Message: " + ex.InnerException.Message);
                    }

                }
            }

            private static ExceptionMailReaderTable EmailSenDBUpdate(int Discipany_Notify_Count, int Return_Confirmation_Notify_Count, int Return_Not_Received_Notify_Count, int No_Mail_Receive_Notify_Count, int Pending_Return_Confirmation_Notify_Count, string OldStatus, OutLookEamail_TransactionHeader item)
            {
                ExceptionMailReaderTable itemObj = new ExceptionMailReaderTable()
                {
                    BatchNo = item.BatchNumber,
                    Status = item.Status,
                    ExceptionStatus = item.ExceptionStatus,
                    ProcessStage = item.ProcessStage,
                    Discipany_Notify_Count = Discipany_Notify_Count,
                    Return_Confirmation_Notify_Count = Return_Confirmation_Notify_Count,
                    Return_Not_Received_Notify_Count = Return_Not_Received_Notify_Count,
                    No_Mail_Receive_Notify_Count = No_Mail_Receive_Notify_Count,
                    Pending_Return_Confirmation_Notify_Count = Pending_Return_Confirmation_Notify_Count,
                };
                OutgoingMailExceptionHandling_Data.UpdateOutgoingExceptionStatus_StatusOnly(itemObj, OldStatus);
                return itemObj;
            }

            private static ExceptionMailReaderTable StatusDBUpdate(int Discipany_Notify_Count, int Return_Confirmation_Notify_Count, int Return_Not_Received_Notify_Count, int No_Mail_Receive_Notify_Count, int Pending_Return_Confirmation_Notify_Count, string OldStatus, OutLookEamail_TransactionHeader item)
            {
                ExceptionMailReaderTable itemObj = new ExceptionMailReaderTable()
                {
                    BatchNo = item.BatchNumber,
                    Status = item.Status,
                    ExceptionStatus = item.ExceptionStatus,
                    ProcessStage = item.ProcessStage,
                    Discipany_Notify_Count = Discipany_Notify_Count,
                    Return_Confirmation_Notify_Count = Return_Confirmation_Notify_Count,
                    Return_Not_Received_Notify_Count = Return_Not_Received_Notify_Count,
                    No_Mail_Receive_Notify_Count = No_Mail_Receive_Notify_Count,
                    Pending_Return_Confirmation_Notify_Count = Pending_Return_Confirmation_Notify_Count,
                };
                OutgoingMailExceptionHandling_Data.UpdateOutgoingExceptionStatus_WithCounts(itemObj, OldStatus);
                return itemObj;
            }

            //public static void MainFlow2()
            //{
            //    ReturnResponse objUserHead = new ReturnResponse();
            //    try
            //    {

            //        //If the Current Batch Enabled for Email  Exception Notification sending
            //        if (If_the_Current_Batch_Enabled_for_Email_Exception_Notification_sending() == true)
            //        {
            //            //While     End of Exception Batch     List where ExceptionStatus not in ("Closed", "Returned", "Cancelled")

            //            List<OutLookEamail_TransactionHeader> objloop = While_End_of_Exception_Batch_List_where_Exception_Status_not_in_Closed_Returned_Cancelled();

            //            int Discipany_Notify_Count = 0;
            //            int Return_Confirmation_Notify_Count = 0;
            //            int Return_Not_Received_Notify_Count = 0;
            //            int No_Mail_Receive_Notify_Count = 0;
            //            int Pending_Return_Confirmation_Notify_Count = 0;

            //            //string Batch_Exception_Type = "";

            //            List<NotificatioModel> notificationList = new List<NotificatioModel>();
            //            //string CustomerName = "";

            //            int SN = 0;
            //            EmailSendingObject_ExceptionHandling obj = new EmailSendingObject_ExceptionHandling();
            //            ExceptionMailReaderTable itemObj = new ExceptionMailReaderTable();
            //            string OldStatus = "";

            //            foreach (var item in objloop)
            //            {
            //                OldStatus = item.ExceptionStatus;

            //                Discipany_Notify_Count = item.Discipany_Notify_Count;
            //                Return_Confirmation_Notify_Count = item.Return_Confirmation_Notify_Count;
            //                Return_Not_Received_Notify_Count = item.Return_Not_Received_Notify_Count;
            //                No_Mail_Receive_Notify_Count = item.No_Mail_Receive_Notify_Count;
            //                Pending_Return_Confirmation_Notify_Count = item.Pending_Return_Confirmation_Notify_Count;

            //                obj = new EmailSendingObject_ExceptionHandling()
            //                {
            //                    //batchdatetime = item.batchdatetime,
            //                    BatchNo = item.BatchNumber,
            //                    KioskNo = item.KioskNo,
            //                    StaffID = item.StaffID,
            //                    StaffName = item.StaffName,
            //                    PCCode = item.PCCode,
            //                    MailType = item.MailType,
            //                    declaredQty = item.declaredQty,
            //                    BatchCreatedOn = item.BatchCreatedOn,
            //                    BatchReceivedOn = item.BatchReceivedOn,
            //                    BatchProcessedOn = item.BatchProcessedOn,
            //                    CentralMailroomNumber = item.CentralMailroomNumber,
            //                    actualQty = item.actualQty,
            //                    EmailAddress = item.EmailAddress,
            //                    CustomerName = item.CustomerName,
            //                    BusinessUnit = item.BusinessUnit
            //                };

            //                SN++;

            //                //If    Batch exception Type is "Discrepancy"
            //                if (If_Batch_exception_Type_is_Discrepancy(item.ExceptionType) == true)
            //                {

            //                    //If     Exception Status is     "Pending"
            //                    if (If_Exception_Status_is_Ongoing(item.ExceptionStatus) == true)
            //                    {
            //                        if (item.ProcessStage == ProcessStageDefinitions.Customer_Replied_Yes)
            //                        {
            //                            //If    Discrepancy Notify Count >= Max Discripancy Notify Count
            //                            if (If_Discrepancy_Notify_Count_Max_Discripancy_Notify_Count(Discipany_Notify_Count) == true)
            //                            {
            //                                //Set Exception Status = "Pending-Expired"
            //                                item.ExceptionStatus = "Pending-Expired";
            //                                notificationList.Add(new NotificatioModel() { BatchTransactionNumber = item.BatchNumber, ExceptionType = item.ExceptionType, TransactionDate = item.BatchProcessedOn, SN = SN });
            //                                //Send Email Notification to Mail Room Staff to Handle the Exception Manually
            //                                EmailSender_Related.Send_Email_Notification_to_Mail_Room_Staff_to_Handle_the_Exception_Manually(notificationList, item.CustomerName, item.BusinessUnit);
            //                            }
            //                            else
            //                            {
            //                                //Send Discrepancy Email Notification
            //                                EmailSender_Related.Send_Discrepancy_Email_Notification(obj);
            //                                //Discipany Notify Count++
            //                                Discipany_Notify_Count++;
            //                            }
            //                        }
            //                        else if (item.ProcessStage == ProcessStageDefinitions.Customer_Replied_No)
            //                        {
            //                            //}
            //                            ////If Exception Status is "Pending Return Confirmation"
            //                            //else if (item.ExceptionStatus == "Pending Return Confirmation")
            //                            //{
            //                            //If   Pending Return   Confirmation Notify Count >= Max Pending Return Confirmation Notify Count
            //                            if (If_Pending_Return_Confirmation_Notify_Count_Max_Pending_Return_Confirmation_Notify_Count(Pending_Return_Confirmation_Notify_Count) == true)
            //                            {
            //                                //Set Exception Status = "Pending Return Confirmation - Expired"
            //                                item.ExceptionStatus = "Pending Return Confirmation - Expired";

            //                                //Send Email Notification to Mail Room Staff to Handle the Exception Manually
            //                                notificationList.Add(new NotificatioModel() { BatchTransactionNumber = item.BatchNumber, ExceptionType = item.ExceptionType, TransactionDate = item.BatchProcessedOn, SN = SN });
            //                                EmailSender_Related.Send_Email_Notification_to_Mail_Room_Staff_to_Handle_the_Exception_Manually(notificationList, item.CustomerName, item.BusinessUnit);
            //                            }
            //                            else
            //                            {
            //                                //Send Return Confirmation Email Notification
            //                                EmailSender_Related.Send_Return_Confirmation_Email_Notification(obj);
            //                                //Return Confirmation Notify Count +
            //                                Return_Confirmation_Notify_Count++;
            //                                Pending_Return_Confirmation_Notify_Count++;
            //                            }
            //                        }
            //                    }
            //                    //If Exception Status is "Return not Received"
            //                    else if (item.ExceptionStatus == ExceptionStatusDefinitions.ReturnNotReceived)// "Return Not Received")
            //                    {
            //                        //If Return Not Received Notify Count >= Max Return Not Received Notify Count
            //                        if (If_Return_Not_Received_Notify_Count_Max_Return_Not_Received_Notify_Count(Return_Not_Received_Notify_Count) == true)
            //                        {    //Set Exception Status = "Return not Received - Expired"
            //                            item.ExceptionStatus = "Return not Received - Expired";
            //                            //Send Email Notification to Mail Room Staff to Handle the Exception Manually
            //                            notificationList.Add(new NotificatioModel() { BatchTransactionNumber = item.BatchNumber, ExceptionType = item.ExceptionType, TransactionDate = item.BatchProcessedOn, SN = SN });
            //                            EmailSender_Related.Send_Email_Notification_to_Mail_Room_Staff_to_Handle_the_Exception_Manually(notificationList, item.CustomerName, item.BusinessUnit);
            //                        }
            //                        else
            //                        {
            //                            //Send Return Confirmation Email Notification
            //                            EmailSender_Related.Send_Return_Confirmation_Email_Notification(obj);
            //                            //Return Confirmation Notify Count +
            //                            Return_Confirmation_Notify_Count++;
            //                            Return_Not_Received_Notify_Count++;
            //                        }
            //                    }
            //                }

            //                //If Batch exceptionType is "No Mail Received"
            //                else if (If_Batch_exception_Type_is_No_Mail_Received(item.ExceptionType) == true)
            //                {
            //                    //If Exception Status is"Pending"
            //                    if (If_Exception_Status_is_Ongoing(item.ExceptionStatus) == true)
            //                    {
            //                        //If No Mail Receive NotifyCount is "0"
            //                        if (If_No_Mail_Receive_NotifyCount_is_0(No_Mail_Receive_Notify_Count) == true)
            //                        {
            //                            //Send No Mail Received Email Notification
            //                            EmailSender_Related.Send_No_Mail_Received_Email_Notification(obj);
            //                            //No Mail Receive Notify Count++
            //                            No_Mail_Receive_Notify_Count++;
            //                        }
            //                        //If(Current Date -Exception Created Date)>= n working Days
            //                        else if (If_Current_Date_Exception_Created_Date__n_working_Days(item.Exception_Created_Date) == true)
            //                        {
            //                            //Set Exception Status = "Cancelled"
            //                            item.ExceptionStatus = "Cancelled";
            //                            //Send Batch Cancellation Email
            //                            EmailSender_Related.Send_Batch_Cancellation_Email(obj);
            //                        }
            //                    }
            //                }

            //                itemObj = new ExceptionMailReaderTable()
            //                {
            //                    BatchNo = item.BatchNumber,
            //                    ExceptionStatus = item.ExceptionStatus
            //                };

            //                OutgoingMailExceptionHandling_Data.UpdateOutgoingExceptionStatus(itemObj, OldStatus);
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        objUserHead = new ReturnResponse
            //        {
            //            resp = false,
            //            msg = ex.Message.ToString()
            //        };
            //        objUserHeadList.Add(objUserHead);

            //        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "MainFlow2", "Stack Track: " + ex.StackTrace);
            //        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "MainFlow2", "Error Message: " + ex.Message);
            //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
            //        {
            //            objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "MainFlow2", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
            //            objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "MainFlow2", "Inner Exception Message: " + ex.InnerException.Message);
            //        }

            //    }
            //}

            private static bool If_Discrepancy_Notify_Count_Max_Discripancy_Notify_Count(int Discipany_Notify_Count)
            {
                //If Discrepancy Notify Count >= Max Discripancy Notify Count
                if (Discipany_Notify_Count >= ConfigCaller.OutgoingMailException_Max_Discripancy_Notify_Count)
                { return true; }
                else
                { return false; }
            }

            private static bool If_Return_Not_Received_Notify_Count_Max_Return_Not_Received_Notify_Count(int Return_Not_Received_Notify_Count)
            {
                //If Return Not Received Notify Count >= Max Return Not Received Notify Count
                if (Return_Not_Received_Notify_Count >= ConfigCaller.OutgoingMailException_Max_Return_Not_Received_Notify_Count)
                { return true; }
                else
                { return false; }
            }

            private static bool If_Pending_Return_Confirmation_Notify_Count_Max_Pending_Return_Confirmation_Notify_Count(int Pending_Return_Confirmation_Notify_Count)
            {
                //If   Pending Return   Confirmation Notify Count >= Max Pending Return Confirmation Notify Count
                if (Pending_Return_Confirmation_Notify_Count >= ConfigCaller.OutgoingMailException_Max_Pending_Return_Confirmation_Notify_Count)
                { return true; }
                else
                { return false; }
            }


            public static ReturnSystemPMModel get_system_parameter_single(string SP_ID)//ok
            {
                ReturnSystemPMModel objSPMData = new ReturnSystemPMModel();
                SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString);
                try
                {
                    if (lconn.State == ConnectionState.Closed)
                    {
                        lconn.Open();
                    }

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_system_parameter_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@SP_ID", SP_ID);
                        cmd.Parameters["@SP_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objSPMData = new ReturnSystemPMModel();

                                objSPMData.SP_ID = rdr["SP_ID"].ToString();
                                objSPMData.SP_Description = rdr["SP_Description"].ToString();
                                objSPMData.SP_Value = rdr["SP_Value"].ToString();
                                objSPMData.SP_Type = rdr["SP_Type"].ToString();
                                objSPMData.SP_DisplaySeq = Convert.ToInt32(rdr["SP_DisplaySeq"]);
                            }
                        }
                    }

                    if (lconn.State == ConnectionState.Open)
                    {
                        lconn.Close();
                    }

                    return objSPMData;

                }
                catch (System.Exception ex)
                {
                    if (lconn.State == ConnectionState.Open)
                    {
                        lconn.Close();
                    }
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "get_system_parameter_single", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "get_system_parameter_single", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "get_system_parameter_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "get_system_parameter_single", "Inner Exception Message: " + ex.InnerException.Message);
                    }
                }

                return objSPMData;

            }

            private static bool If_Current_Date_Exception_Created_Date__n_working_Days(DateTime Exception_Created_Date)
            {
                try
                {
                    //if (DateTime.Now - Exception_Created_Date)  >= n working Days
                    List<DateTime> lst = get_workingdays_from_calander();
                    List<DateTime> lst_NotExist = new List<DateTime>();

                    double datediff = (DateTime.Now.Date - Exception_Created_Date).TotalDays;

                    for (int i = 0; i < datediff; i++)
                    {
                        if (lst.Contains(Exception_Created_Date.AddDays(i)))
                        { }
                        else { lst_NotExist.Add(Exception_Created_Date.AddDays(i)); }
                    }

                    if (lst_NotExist.Count > ConfigCaller.Email_Notification_Batch_Email_Expiring_Days_Count)
                    { return true; }
                    else
                    { return false; }
                }
                catch (Exception ex)
                {
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "If_Current_Date_Exception_Created_Date__n_working_Days", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "If_Current_Date_Exception_Created_Date__n_working_Days", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "If_Current_Date_Exception_Created_Date__n_working_Days", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "If_Current_Date_Exception_Created_Date__n_working_Days", "Inner Exception Message: " + ex.InnerException.Message);
                    }
                }
                return false;
            }

            private static bool If_No_Mail_Receive_NotifyCount_is_0(int No_Mail_Receive_Notify_Count)
            {
                if (No_Mail_Receive_Notify_Count == 0)
                { return true; }
                else { return false; }
            }

            private static bool If_Batch_exception_Type_is_No_Mail_Received(string Batch_Exception_Type)
            {
                if (Batch_Exception_Type == "No Mail Received")
                { return true; }
                else { return false; }
            }

            private static bool If_Batch_exception_Type_is_Discrepancy(string Batch_Exception_Type)
            {
                //if (Batch_Exception_Type == "Discrepancy")
                if (Batch_Exception_Type == "Quantity Mismatch")
                {
                    return true;
                }
                else { return false; }
            }

            public static bool If_the_Current_Batch_Enabled_for_Email_Exception_Notification_sending()
            {
                ReturnSystemPMModel obj = get_system_parameter_single("Current_Batch_Enabled_Email_Notification");
                if (obj != null && obj.SP_Value == "1")
                {
                    ReturnSystemPMModel obj_SessionFrom = SystemParameter_Data.PredefinedProperties.ServiceRelated.Exceptions_OutgoingMail_Process_Session_From();
                    ReturnSystemPMModel obj_SessionTo = SystemParameter_Data.PredefinedProperties.ServiceRelated.Exceptions_OutgoingMail_Process_Session_To();

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
                            return true;
                        }

                    }
                    ////check time 1
                    //ReturnSystemPMModel obj_Session1 = get_system_parameter_single("Current_Batch_Enabled_Email_Notification_Session");
                    //if (obj_Session1 != null)
                    //{
                    //    if (DateTime.Now.Hour.ToString() == obj_Session1.SP_Value)
                    //    {
                    //        return true;
                    //    }
                    //}
                }
                return false;
            }



            public static List<OutLookEamail_TransactionHeader> While_End_of_Exception_Batch_List_where_Exception_Status_not_in_Closed_Returned_Cancelled()
            {
                List<OutLookEamail_TransactionHeader> objHeadList = new List<OutLookEamail_TransactionHeader>();
                OutLookEamail_TransactionHeader obj = new OutLookEamail_TransactionHeader();
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

                            cmd.CommandText = "sp_read_notsyncedmail_with_transaction_where_Exception_Status_not_in_Closed_Returned_Cancelled";
                            cmd.CommandType = CommandType.StoredProcedure;


                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = cmd;
                            DataSet ds = new DataSet();
                            da.Fill(ds);

                            string EmailAddress = "";
                            string USR_FirstName = "";
                            string USR_LastName = "";

                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow rdr in ds.Tables[0].Rows)
                                {
                                    using (SqlCommand cmdc = new SqlCommand())
                                    {
                                        cmdc.Connection = lconn;

                                        cmdc.CommandText = "sp_get_customer_user";
                                        cmdc.CommandType = CommandType.StoredProcedure;

                                        cmdc.Parameters.AddWithValue("@USER_ID", rdr["StaffID"].ToString());
                                        cmdc.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                                        cmdc.Parameters.AddWithValue("@TABLE", rdr["UserTable"].ToString());
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


                                    DateTime BatchCreatedOn = DateTime.MinValue;
                                    DateTime.TryParse(rdr["BatchCreatedOn"].ToString(), out BatchCreatedOn);

                                    DateTime BatchProcessedOn = DateTime.MinValue;
                                    DateTime.TryParse(rdr["BatchProcessedOn"].ToString(), out BatchProcessedOn);

                                    DateTime BatchReceivedOn = DateTime.MinValue;
                                    DateTime.TryParse(rdr["BatchReceivedOn"].ToString(), out BatchReceivedOn);

                                    obj = new OutLookEamail_TransactionHeader()
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
                                        Discipany_Notify_Count = Convert.ToInt32(rdr["Discipany_Notify_Count"].ToString()),
                                        Return_Confirmation_Notify_Count = Convert.ToInt32(rdr["Return_Confirmation_Notify_Count"].ToString()),
                                        Return_Not_Received_Notify_Count = Convert.ToInt32(rdr["Return_Not_Received_Notify_Count"].ToString()),
                                        No_Mail_Receive_Notify_Count = Convert.ToInt32(rdr["No_Mail_Receive_Notify_Count"].ToString()),
                                        Pending_Return_Confirmation_Notify_Count = Convert.ToInt32(rdr["Pending_Return_Confirmation_Notify_Count"].ToString()),


                                        ProcessStage = rdr["ProcessStage"].ToString(),
                                    };
                                    objHeadList.Add(obj);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "While_End_of_Exception_Batch_List_where_Exception_Status_not_in_Closed_Returned_Cancelled", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "While_End_of_Exception_Batch_List_where_Exception_Status_not_in_Closed_Returned_Cancelled", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "While_End_of_Exception_Batch_List_where_Exception_Status_not_in_Closed_Returned_Cancelled", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "While_End_of_Exception_Batch_List_where_Exception_Status_not_in_Closed_Returned_Cancelled", "Inner Exception Message: " + ex.InnerException.Message);
                    }
                }
                return objHeadList;
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

            //private static void system_Specify_the_Auto_Remark()
            //{
            //    throw new NotImplementedException();
            //}

            //public static List<OutLookEamail_TransactionHeader> read_notsyncedmail_with_transaction()
            //{
            //    List<OutLookEamail_TransactionHeader> objHeadList = new List<OutLookEamail_TransactionHeader>();

            //    OutLookEamail_TransactionHeader obj = new OutLookEamail_TransactionHeader();

            //    try
            //    {
            //        using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
            //        {
            //            if (lconn.State == ConnectionState.Closed)
            //            {
            //                lconn.Open();
            //            }

            //            using (SqlCommand cmd = new SqlCommand())
            //            {
            //                cmd.Connection = lconn;

            //                cmd.CommandText = "sp_read_notsyncedmail_with_transaction";
            //                cmd.CommandType = CommandType.StoredProcedure;


            //                SqlDataAdapter da = new SqlDataAdapter();
            //                da.SelectCommand = cmd;
            //                DataSet ds = new DataSet();
            //                da.Fill(ds);

            //                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //                {
            //                    foreach (DataRow rdr in ds.Tables[0].Rows)
            //                    {
            //                        obj = new OutLookEamail_TransactionHeader()
            //                        {
            //                            BatchNumber = rdr["BatchNumber"].ToString(),
            //                            CustomerID = rdr["CustomerID"].ToString(),
            //                            batchdatetime = rdr["batchdatetime"].ToString(),
            //                            BatchNo = rdr["BatchNo"].ToString(),
            //                            KioskNo = rdr["KioskNo"].ToString(),
            //                            StaffID = rdr["StaffID"].ToString(),
            //                            PCCode = rdr["PCCode"].ToString(),
            //                            MailType = rdr["MailType"].ToString(),
            //                            declaredQty = Convert.ToInt16(rdr["declaredQty"].ToString()),
            //                            BatchCreatedOn = Convert.ToDateTime(rdr["BatchCreatedOn"].ToString()),
            //                            StaffName = rdr["StaffName"].ToString(),
            //                            BatchProcessedOn = Convert.ToDateTime(rdr["BatchProcessedOn"].ToString()),
            //                            BatchReceivedOn = Convert.ToDateTime(rdr["BatchReceivedOn"].ToString()),
            //                            CentralMailroomNumber = rdr["CentralMailroomNumber"].ToString(),
            //                            actualQty = Convert.ToInt16(rdr["actualQty"].ToString()),
            //                            EmailSubject = rdr["EmailSubject"].ToString(),
            //                            Customer_Reply = rdr["Customer_Reply"].ToString(),
            //                            Exception_Created_Date = Convert.ToDateTime(rdr["Exception_Created_Date"].ToString()),
            //                        };
            //                        objHeadList.Add(obj);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "read_notsyncedmail_with_transaction", "Stack Track: " + ex.StackTrace);
            //        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "read_notsyncedmail_with_transaction", "Error Message: " + ex.Message);
            //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
            //        {
            //            objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "read_notsyncedmail_with_transaction", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
            //            objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "read_notsyncedmail_with_transaction", "Inner Exception Message: " + ex.InnerException.Message);
            //        }
            //    }

            //    return objHeadList;
            //}

            public static List<DateTime> get_workingdays_from_calander()
            {
                List<DateTime> objHeadList = new List<DateTime>();

                //DateTime obj = new DateTime();

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

                            cmd.CommandText = "sp_get_workingdays_from_calander";
                            cmd.CommandType = CommandType.StoredProcedure;


                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = cmd;
                            DataSet ds = new DataSet();
                            da.Fill(ds);

                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow rdr in ds.Tables[0].Rows)
                                {
                                    objHeadList.Add(Convert.ToDateTime(rdr["HolidayCalenderDate"].ToString()));
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "get_workingdays_from_calander", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "get_workingdays_from_calander", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "get_workingdays_from_calander", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "get_workingdays_from_calander", "Inner Exception Message: " + ex.InnerException.Message);
                    }
                }

                return objHeadList;
            }
        }

        public static class EmailSender_Related
        {
            public static List<ReturnResponse> Send_Return_Confirmation_Email_Notification(EmailSendingObject_ExceptionHandling model)
            {
                ReturnResponse objUserHead = new ReturnResponse();
                try
                {
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
                        string subject, Body;

                        string Header = "Outgoing Mail Transaction Batch No. [BatchNo] dated [batchdatetime] - Returned Mail Acknowledgement for Mail Quantity Discrepancy";
                        string EmailPath = ConfigCaller.OutgoingMailException_Send_Return_Confirmation_Email_Notification;

                        if (System.IO.File.Exists(EmailPath))
                        {
                            string filecontent = System.IO.File.ReadAllText(EmailPath);

                            subject = Header;
                            subject = subject.Replace("[batchdatetime]", model.BatchCreatedOn.ToString("dd-MMM-yyyy HH:mm:ss"));
                            subject = subject.Replace("[BatchNo]", model.BatchNo);

                            filecontent = filecontent.Replace("[BatchNo]", model.BatchNo);
                            filecontent = filecontent.Replace("[KioskNo]", model.KioskNo);
                            filecontent = filecontent.Replace("[Staff ID]", model.StaffID);
                            filecontent = filecontent.Replace("[Staff Name]", model.StaffName);
                            filecontent = filecontent.Replace("[PCCode]", model.PCCode);
                            filecontent = filecontent.Replace("[BatchCreatedOn]", model.BatchCreatedOn.ToString("dd-MMM-yyyy HH:mm:ss"));
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


                            Body = filecontent;

                            EmailAttachedFileDetails objFilesAttachment = new EmailAttachedFileDetails();
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
                            objUserHeadList.Add(rtn);
                        }
                        objError.WriteLog(2, "OutgoingMailExceptionHandling_Data", "Send_Return_Confirmation_Email_Notification", JsonSerializer.Serialize(objUserHeadList));
                    }
                }
                catch (Exception ex)
                {
                    objUserHead = new ReturnResponse
                    {
                        resp = false,
                        msg = ex.Message.ToString()
                    };
                    objUserHeadList.Add(objUserHead);

                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_Return_Confirmation_Email_Notification", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_Return_Confirmation_Email_Notification", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_Return_Confirmation_Email_Notification", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_Return_Confirmation_Email_Notification", "Inner Exception Message: " + ex.InnerException.Message);
                    }

                }
                return objUserHeadList;
            }

            public static List<ReturnResponse> Send_Email_Notification_to_Mail_Room_Staff_to_Handle_the_Exception_Manually(List<NotificatioModel> notificationList, string CustomerName, string BusinessUnit)
            {
                ReturnResponse objUserHead = new ReturnResponse();
                try
                {

                    string EmailAddress = "";
                    EmailAddress = ConfigCaller.HRM_MailRoomStaff_EmailList;

                    if (string.IsNullOrEmpty(EmailAddress))
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
                        int SN = 1;
                        foreach (var item in notificationList)
                        {
                            item.SN = SN;
                            SN++;
                        }

                        string subject, Body;

                        string Header = "Pending Outgoing Mail Batch Exception";
                        string EmailPath = ConfigCaller.OutgoingMailException_Send_Email_Notification_to_Mail_Room_Staff_to_Handle_the_Exception_Manually;

                        if (System.IO.File.Exists(EmailPath))
                        {
                            string filecontent = System.IO.File.ReadAllText(EmailPath);
                            string TrRows = "";

                            subject = Header;
                            //subject = Header.Replace("[Customer]", CustomerName);

                            foreach (var item in notificationList)
                            {

                                TrRows = TrRows + "<tr><td>" + item.SN + "</td><td>" + item.TransactionDate.ToString("dd-MMM-yyyy HH:mm:ss") + "</td><td>" + item.BatchTransactionNumber + "</td><td>" + item.ExceptionType + "</td></tr>";
                            }

                            Body = filecontent.Replace("[TableRow]", TrRows);

                            EmailAttachedFileDetails objFilesAttachment = new EmailAttachedFileDetails();
                            ReturnResponse rtn = Email_Sender_Preperation.Send(EmailAddress, Body, BusinessUnit, true, subject, objFilesAttachment);

                            //(bool messageid, string message) result = SendMail.Send_V1(BaseClassDBCallerData.userNameEmail, EmailAddress, "",
                            //          subject, Body, BaseClassDBCallerData.smtpServer, BaseClassDBCallerData.smtpPort,
                            //          BaseClassDBCallerData.security, BaseClassDBCallerData.userNameEmail, BaseClassDBCallerData.userpassword);

                            //objUserHead = new ReturnResponse
                            //{
                            //    resp = result.messageid,
                            //    msg = result.message,
                            //};
                            //objUserHeadList.Add(objUserHead);
                            objUserHeadList.Add(rtn);
                        }

                        objError.WriteLog(2, "OutgoingMailExceptionHandling_Data", "Send_Email_Notification_to_Mail_Room_Staff_to_Handle_the_Exception_Manually", JsonSerializer.Serialize(objUserHeadList));
                    }
                }
                catch (Exception ex)
                {
                    objUserHead = new ReturnResponse
                    {
                        resp = false,
                        msg = ex.Message.ToString()
                    };
                    objUserHeadList.Add(objUserHead);

                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_Email_Notification_to_Mail_Room_Staff_to_Handle_the_Exception_Manually", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_Email_Notification_to_Mail_Room_Staff_to_Handle_the_Exception_Manually", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_Email_Notification_to_Mail_Room_Staff_to_Handle_the_Exception_Manually", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_Email_Notification_to_Mail_Room_Staff_to_Handle_the_Exception_Manually", "Inner Exception Message: " + ex.InnerException.Message);
                    }

                }
                return objUserHeadList;
            }

            public static List<ReturnResponse> Send_Discrepancy_Email_Notification(EmailSendingObject_ExceptionHandling model)
            {
                ReturnResponse objUserHead = new ReturnResponse();
                try
                {
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
                        string subject, Body;

                        string Header = "Outgoing Mail Transaction Batch No. [BatchNo] dated [batchdatetime] - Mail Quantity Discrepancy";
                        string EmailPath = ConfigCaller.OutgoingMailException_Send_Discrepancy_Email_Notification;

                        if (System.IO.File.Exists(EmailPath))
                        {
                            string filecontent = System.IO.File.ReadAllText(EmailPath);

                            subject = Header;
                            subject = subject.Replace("[batchdatetime]", model.BatchCreatedOn.ToString("dd-MMM-yyyy HH:mm:ss"));
                            subject = subject.Replace("[BatchNo]", model.BatchNo);

                            filecontent = filecontent.Replace("[BatchNo]", model.BatchNo);
                            filecontent = filecontent.Replace("[KioskNo]", model.KioskNo);
                            filecontent = filecontent.Replace("[Staff ID]", model.StaffID);
                            filecontent = filecontent.Replace("[Staff Name]", model.StaffName);
                            filecontent = filecontent.Replace("[PCCode]", model.PCCode);
                            filecontent = filecontent.Replace("[BatchCreatedOn]", model.BatchCreatedOn.ToString("dd-MMM-yyyy HH:mm:ss"));
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


                            Body = filecontent;

                            EmailAttachedFileDetails objFilesAttachment = new EmailAttachedFileDetails();
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
                            objUserHeadList.Add(rtn);
                        }

                        objError.WriteLog(2, "OutgoingMailExceptionHandling_Data", "Send_Discrepancy_Email_Notification", JsonSerializer.Serialize(objUserHeadList));
                    }
                }
                catch (Exception ex)
                {
                    objUserHead = new ReturnResponse
                    {
                        resp = false,
                        msg = ex.Message.ToString()
                    };
                    objUserHeadList.Add(objUserHead);

                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_Discrepancy_Email_Notification", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_Discrepancy_Email_Notification", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_Discrepancy_Email_Notification", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_Discrepancy_Email_Notification", "Inner Exception Message: " + ex.InnerException.Message);
                    }

                }
                return objUserHeadList;
            }

            public static List<ReturnResponse> Send_Returned_Mail_Acknowledgement_Discrepancy_Email_Notification(EmailSendingObject_ExceptionHandling model)
            {
                ReturnResponse objUserHead = new ReturnResponse();
                try
                {
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
                        string subject, Body;

                        string Header = "Outgoing Mail Transaction Batch No. [BatchNo] dated [batchdatetime] - Returned Mail Acknowledgement for Mail Quantity Discrepancy";
                        string EmailPath = ConfigCaller.Email_Notification_to_Returned_Mail_Acknowledgement_Discrepancy_Email_Notification;

                        if (System.IO.File.Exists(EmailPath))
                        {
                            string filecontent = System.IO.File.ReadAllText(EmailPath);

                            subject = Header;
                            subject = subject.Replace("[batchdatetime]", model.BatchCreatedOn.ToString("dd-MMM-yyyy HH:mm:ss"));
                            subject = subject.Replace("[BatchNo]", model.BatchNo);

                            filecontent = filecontent.Replace("[BatchNo]", model.BatchNo);
                            filecontent = filecontent.Replace("[KioskNo]", model.KioskNo);
                            filecontent = filecontent.Replace("[Staff ID]", model.StaffID);
                            filecontent = filecontent.Replace("[Staff Name]", model.StaffName);
                            filecontent = filecontent.Replace("[PCCode]", model.PCCode);
                            filecontent = filecontent.Replace("[BatchCreatedOn]", model.BatchCreatedOn.ToString("dd-MMM-yyyy HH:mm:ss"));
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


                            Body = filecontent;

                            EmailAttachedFileDetails objFilesAttachment = new EmailAttachedFileDetails();
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
                            objUserHeadList.Add(rtn);
                        }

                        objError.WriteLog(2, "OutgoingMailExceptionHandling_Data", "Send_Returned_Mail_Acknowledgement_Discrepancy_Email_Notification", JsonSerializer.Serialize(objUserHeadList));
                    }
                }
                catch (Exception ex)
                {
                    objUserHead = new ReturnResponse
                    {
                        resp = false,
                        msg = ex.Message.ToString()
                    };
                    objUserHeadList.Add(objUserHead);

                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_Discrepancy_Email_Notification", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_Discrepancy_Email_Notification", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_Discrepancy_Email_Notification", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_Discrepancy_Email_Notification", "Inner Exception Message: " + ex.InnerException.Message);
                    }

                }
                return objUserHeadList;
            }

            public static List<ReturnResponse> Send_Batch_Cancellation_Email(EmailSendingObject_ExceptionHandling model)
            {
                ReturnResponse objUserHead = new ReturnResponse();
                try
                {
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
                        string subject, Body;

                        string Header = "Outgoing Mail Transaction Batch No. [BatchNo] dated [batchdatetime] - Physical Mail Not Received by Mailroom";
                        string EmailPath = ConfigCaller.OutgoingMailException_Send_Batch_Cancellation_Email_Notification;

                        if (System.IO.File.Exists(EmailPath))
                        {
                            string filecontent = System.IO.File.ReadAllText(EmailPath);

                            subject = Header;
                            subject = subject.Replace("[batchdatetime]", model.BatchCreatedOn.ToString("dd-MMM-yyyy HH:mm:ss"));
                            subject = subject.Replace("[BatchNo]", model.BatchNo);

                            filecontent = filecontent.Replace("[BatchNo]", model.BatchNo);
                            filecontent = filecontent.Replace("[KioskNo]", model.KioskNo);
                            filecontent = filecontent.Replace("[Staff ID]", model.StaffID);
                            filecontent = filecontent.Replace("[Staff Name]", model.StaffName);
                            filecontent = filecontent.Replace("[PCCode]", model.PCCode);
                            filecontent = filecontent.Replace("[BatchCreatedOn]", model.BatchCreatedOn.ToString("dd-MMM-yyyy HH:mm:ss"));
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


                            Body = filecontent;

                            EmailAttachedFileDetails objFilesAttachment = new EmailAttachedFileDetails();
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
                            objUserHeadList.Add(rtn);
                        }

                        objError.WriteLog(2, "OutgoingMailExceptionHandling_Data", "Send_Batch_Cancellation_Email", JsonSerializer.Serialize(objUserHeadList));
                    }
                }
                catch (Exception ex)
                {
                    objUserHead = new ReturnResponse
                    {
                        resp = false,
                        msg = ex.Message.ToString()
                    };
                    objUserHeadList.Add(objUserHead);

                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_Batch_Cancellation_Email", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_Batch_Cancellation_Email", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_Batch_Cancellation_Email", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_Batch_Cancellation_Email", "Inner Exception Message: " + ex.InnerException.Message);
                    }

                }
                return objUserHeadList;
            }

            public static List<ReturnResponse> Send_No_Mail_Received_Email_Notification(EmailSendingObject_ExceptionHandling model)
            {
                ReturnResponse objUserHead = new ReturnResponse();
                try
                {
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

                        string Header = "Outgoing Mail Transaction Batch No. [BatchNo] dated [batchdatetime] - Physical Mail Not Received by Mailroom";
                        string EmailPath = ConfigCaller.OutgoingMailException_Send_No_Mail_Received_Email_Notification;

                        if (System.IO.File.Exists(EmailPath))
                        {
                            string filecontent = System.IO.File.ReadAllText(EmailPath);

                            subject = Header;
                            subject = subject.Replace("[batchdatetime]", model.BatchCreatedOn.ToString("dd-MMM-yyyy HH:mm:ss"));
                            subject = subject.Replace("[BatchNo]", model.BatchNo);

                            filecontent = filecontent.Replace("[BatchNo]", model.BatchNo);
                            filecontent = filecontent.Replace("[KioskNo]", model.KioskNo);
                            filecontent = filecontent.Replace("[Staff ID]", model.StaffID);
                            filecontent = filecontent.Replace("[Staff Name]", model.StaffName);
                            filecontent = filecontent.Replace("[PCCode]", model.PCCode);
                            filecontent = filecontent.Replace("[BatchCreatedOn]", model.BatchCreatedOn.ToString("dd-MMM-yyyy HH:mm:ss"));
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


                            Body = filecontent;

                            EmailAttachedFileDetails objFilesAttachment = new EmailAttachedFileDetails();
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
                            objUserHeadList.Add(rtn);
                        }
                    }

                    objError.WriteLog(2, "OutgoingMailExceptionHandling_Data", "Send_No_Mail_Received_Email_Notification", JsonSerializer.Serialize(objUserHeadList));
                }
                catch (Exception ex)
                {
                    objUserHead = new ReturnResponse
                    {
                        resp = false,
                        msg = ex.Message.ToString()
                    };
                    objUserHeadList.Add(objUserHead);

                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_No_Mail_Received_Email_Notification", "Stack Track: " + ex.StackTrace);
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_No_Mail_Received_Email_Notification", "Error Message: " + ex.Message);
                    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                    {
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_No_Mail_Received_Email_Notification", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                        objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "Send_No_Mail_Received_Email_Notification", "Inner Exception Message: " + ex.InnerException.Message);
                    }

                }
                return objUserHeadList;
            }
        }

        public static EmailSendingObject_ExceptionHandling get_batchno_details_ExceptionEmail(string BatchNo)
        {
            EmailSendingObject_ExceptionHandling objEnquiryDetail = new EmailSendingObject_ExceptionHandling();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_batchno_details_ExceptionEmail";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BatchNo", BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        string EmailAddress = "";
                        string USR_FirstName = "";
                        string USR_LastName = "";

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                using (SqlCommand cmdc = new SqlCommand())
                                {
                                    cmdc.Connection = lconn;

                                    cmdc.CommandText = "sp_get_customer_user";
                                    cmdc.CommandType = CommandType.StoredProcedure;

                                    cmdc.Parameters.AddWithValue("@USER_ID", rdr["StaffID"].ToString());
                                    cmdc.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                                    cmdc.Parameters.AddWithValue("@TABLE", rdr["UserTable"].ToString());
                                    cmdc.Parameters["@TABLE"].Direction = ParameterDirection.Input;

                                    SqlDataAdapter dtac = new SqlDataAdapter();
                                    dtac.SelectCommand = cmdc;
                                    DataSet Dsc = new DataSet();
                                    dtac.Fill(Dsc);

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


                                DateTime BatchCreatedOn = DateTime.MinValue;
                                DateTime.TryParse(rdr["TransactionDateTime"].ToString(), out BatchCreatedOn);

                                DateTime BatchProcessedOn = DateTime.MinValue;
                                DateTime.TryParse(rdr["BatchProcessedOn"].ToString(), out BatchProcessedOn);

                                DateTime BatchReceivedOn = DateTime.MinValue;
                                DateTime.TryParse(rdr["BatchReceivedOn"].ToString(), out BatchReceivedOn);

                                objEnquiryDetail = new EmailSendingObject_ExceptionHandling()
                                {
                                    BatchNo = rdr["BatchNumber"].ToString(),
                                    KioskNo = rdr["KioskNo"].ToString(),
                                    StaffID = rdr["StaffID"].ToString(),
                                    PCCode = rdr["PCCode"].ToString(),
                                    MailType = rdr["MailType"].ToString(),
                                    declaredQty = Convert.ToDecimal(rdr["declaredQty"].ToString()),
                                    BatchCreatedOn = BatchCreatedOn,
                                    StaffName = USR_FirstName + " " + USR_LastName,// rdr["StaffName"].ToString(),
                                    BatchProcessedOn = BatchProcessedOn,
                                    BatchReceivedOn = BatchReceivedOn,
                                    CentralMailroomNumber = rdr["CentralMailroomNumber"].ToString(),
                                    actualQty = Convert.ToDecimal(rdr["actualQty"].ToString()),
                                    EmailAddress = EmailAddress,
                                    BusinessUnit = rdr["BusinessUnit"].ToString(),
                                    CustomerName = rdr["CustomerName"].ToString(),
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "get_batchno_details_ExceptionEmail", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "get_batchno_details_ExceptionEmail", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "get_batchno_details_ExceptionEmail", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "get_batchno_details_ExceptionEmail", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objEnquiryDetail;
        }

        public static void UpdateOutgoingExceptionStatus(/*OutLookEamail_TransactionHeader*/ExceptionMailReaderTable model, string OldStatus)
        {
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    if (lconn.State == ConnectionState.Closed)
                    {
                        lconn.Open();
                    }

                    string AutoRemark = "Status Changed To " + model.ExceptionStatus + " From " + OldStatus + " On " + System.DateTime.Now.ToString();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_UpdateOutgoingExceptionStatus";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ExceptionStatus", model.ExceptionStatus);
                        cmd.Parameters["@ExceptionStatus"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ProcessStage", model.ProcessStage);
                        cmd.Parameters["@ProcessStage"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BatchNo", model.BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@AutoRemark", AutoRemark);
                        cmd.Parameters["@AutoRemark"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Status", model.Status);
                        cmd.Parameters["@Status"].Direction = ParameterDirection.Input;


                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "UpdateOutgoingExceptionStatus", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "UpdateOutgoingExceptionStatus", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "UpdateOutgoingExceptionStatus", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "UpdateOutgoingExceptionStatus", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
        }

        public static void UpdateOutgoingExceptionStatus_WithCounts(/*OutLookEamail_TransactionHeader*/ExceptionMailReaderTable model, string OldStatus)
        {
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    if (lconn.State == ConnectionState.Closed)
                    {
                        lconn.Open();
                    }

                    string AutoRemark = "Status Changed To " + model.ExceptionStatus + " From " + OldStatus + " On " + System.DateTime.Now.ToString();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_UpdateOutgoingExceptionStatus_withcounts";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ExceptionStatus", model.ExceptionStatus);
                        cmd.Parameters["@ExceptionStatus"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ProcessStage", model.ProcessStage);
                        cmd.Parameters["@ProcessStage"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BatchNo", model.BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@AutoRemark", AutoRemark);
                        cmd.Parameters["@AutoRemark"].Direction = ParameterDirection.Input;


                        cmd.Parameters.AddWithValue("@Discipany_Notify_Count", model.Discipany_Notify_Count);
                        cmd.Parameters["@Discipany_Notify_Count"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Return_Confirmation_Notify_Count", model.Return_Confirmation_Notify_Count);
                        cmd.Parameters["@Return_Confirmation_Notify_Count"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Return_Not_Received_Notify_Count", model.Return_Not_Received_Notify_Count);
                        cmd.Parameters["@Return_Not_Received_Notify_Count"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@No_Mail_Receive_Notify_Count", model.No_Mail_Receive_Notify_Count);
                        cmd.Parameters["@No_Mail_Receive_Notify_Count"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Pending_Return_Confirmation_Notify_Count", model.Pending_Return_Confirmation_Notify_Count);
                        cmd.Parameters["@Pending_Return_Confirmation_Notify_Count"].Direction = ParameterDirection.Input;


                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "UpdateOutgoingExceptionStatus_WithCounts", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "UpdateOutgoingExceptionStatus_WithCounts", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "UpdateOutgoingExceptionStatus_WithCounts", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "UpdateOutgoingExceptionStatus_WithCounts", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
        }

        public static void UpdateOutgoingExceptionStatus_StatusOnly(/*OutLookEamail_TransactionHeader*/ExceptionMailReaderTable model, string OldStatus)
        {
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    if (lconn.State == ConnectionState.Closed)
                    {
                        lconn.Open();
                    }

                    string AutoRemark = "Status Changed To " + model.ExceptionStatus + " From " + OldStatus + " On " + System.DateTime.Now.ToString();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_UpdateOutgoingExceptionStatus_statusonly";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ExceptionStatus", model.ExceptionStatus);
                        cmd.Parameters["@ExceptionStatus"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ProcessStage", model.ProcessStage);
                        cmd.Parameters["@ProcessStage"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BatchNo", model.BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@AutoRemark", AutoRemark);
                        cmd.Parameters["@AutoRemark"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Discipany_Notify_Count", model.Discipany_Notify_Count);
                        cmd.Parameters["@Discipany_Notify_Count"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Return_Confirmation_Notify_Count", model.Return_Confirmation_Notify_Count);
                        cmd.Parameters["@Return_Confirmation_Notify_Count"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Return_Not_Received_Notify_Count", model.Return_Not_Received_Notify_Count);
                        cmd.Parameters["@Return_Not_Received_Notify_Count"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@No_Mail_Receive_Notify_Count", model.No_Mail_Receive_Notify_Count);
                        cmd.Parameters["@No_Mail_Receive_Notify_Count"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Pending_Return_Confirmation_Notify_Count", model.Pending_Return_Confirmation_Notify_Count);
                        cmd.Parameters["@Pending_Return_Confirmation_Notify_Count"].Direction = ParameterDirection.Input;

                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "UpdateOutgoingExceptionStatus_StatusOnly", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "UpdateOutgoingExceptionStatus_StatusOnly", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "UpdateOutgoingExceptionStatus_StatusOnly", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "OutgoingMailExceptionHandling_Data", "UpdateOutgoingExceptionStatus_StatusOnly", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
        }

        public static bool If_Exception_Status_is_Ongoing(string Exception_Status)
        {
            if (Exception_Status == ExceptionStatusDefinitions.Ongoing)// "Ongoing")
                return true;
            else
                return false;
        }
    }

    public class NotificatioModel
    {
        public int SN { get; set; }
        public string BatchTransactionNumber { get; set; }
        public string ExceptionType { get; set; }
        public DateTime TransactionDate { get; set; }
    }

    public class OutLookEamail_TransactionHeader
    {
        public string BatchNumber { get; set; }
        public string CustomerID { get; set; }
        public string batchdatetime { get; set; }
        //public string BatchNo { get; set; }
        public string KioskNo { get; set; }
        public string StaffID { get; set; }
        public string PCCode { get; set; }
        public string MailType { get; set; }
        public int declaredQty { get; set; }
        public DateTime BatchCreatedOn { get; set; }
        public string StaffName { get; set; }
        public DateTime BatchProcessedOn { get; set; }
        public DateTime BatchReceivedOn { get; set; }
        public string CentralMailroomNumber { get; set; }
        public int actualQty { get; set; }
        public string EmailSubject { get; set; }
        public string ExceptionStatus { get; set; }
        public string Customer_Reply { get; set; }
        public DateTime Exception_Created_Date { get; set; }
        public string EmailAddress { get; set; }
        public string CustomerName { get; set; }
        public string BusinessUnit { get; set; }
        public string ExceptionType { get; set; }
        public string UserTable { get; set; }
        public string AutoRemark { get; set; }
        public int Discipany_Notify_Count { get; set; }
        public int Return_Confirmation_Notify_Count { get; set; }
        public int Return_Not_Received_Notify_Count { get; set; }
        public int No_Mail_Receive_Notify_Count { get; set; }
        public int Pending_Return_Confirmation_Notify_Count { get; set; }
        public string ProcessStage { get; set; }
        public string Status { get; set; }

        public string FilePathReference_Processing_ItemLevel_Local { get; set; }
        public string FilePathReference_Processing_ItemLevel_Oversea { get; set; }

        public bool AttachDocsToEmail { get; set; }
    }

    public class EmailSendingObject_ExceptionHandling
    {
        //public string batchdatetime { get; set; }
        public string BatchNo { get; set; }
        public string KioskNo { get; set; }
        public string StaffID { get; set; }
        public string StaffName { get; set; }
        public string PCCode { get; set; }
        public string MailType { get; set; }
        public decimal declaredQty { get; set; }
        public DateTime BatchCreatedOn { get; set; }
        public DateTime BatchReceivedOn { get; set; }
        public DateTime BatchProcessedOn { get; set; }
        public string CentralMailroomNumber { get; set; }
        public string EmailAddress { get; set; }
        public decimal actualQty { get; set; }
        public string CustomerName { get; set; }
        public string BusinessUnit { get; set; }
    }

    public class ExceptionMailReaderTable
    {
        public string BatchNo { get; set; }
        public string Status { get; set; }
        public string EmailReplyStatus { get; set; }
        public string Subject { get; set; }
        public string EmailFrom { get; set; }
        //public string ReadTime { get; set; }// = DateTime.Now;
        public bool IsSynced { get; set; } = false;
        public string MailBody { get; set; }
        public string TransactionDateTime { get; set; }
        public string ExceptionStatus { get; set; }
        public string EmailFor { get; set; }
        public string AutoRemark { get; set; }
        public string ProcessStage { get; set; }
        public int Discipany_Notify_Count { get; internal set; }
        public int Return_Confirmation_Notify_Count { get; internal set; }
        public int Return_Not_Received_Notify_Count { get; internal set; }
        public int No_Mail_Receive_Notify_Count { get; internal set; }
        public int Pending_Return_Confirmation_Notify_Count { get; internal set; }
    }

    public class ProcessStageDefinitions
    {
        public const string Send_Notification_Pending = "Send Notification Pending";
        public const string Notification_Sent_and_Reply_Pending = "Notification Sent and Reply Pending";
        public const string Customer_Replied_Yes = "Customer Replied - Yes";
        public const string Customer_Replied_No = "Customer Replied - No";
        public const string Returned_Confirmation_Sent = "Returned Confirmation Sent";
        public const string Exception_Closed_Customer_Replied = "Exception Closed - Customer Replied";
        //public const string Returned_Customer_Replied_Yes = "Returned - Customer Replied - Yes";
        public const string Exception_Closed_Customer_Not_Replied = "Exception Closed - Customer Not Replied";
        public const string Customer_Did_Not_Receive_Returned_Mails = "Customer Did Not Receive Returned Mails";
        public const string Exception_Expired_Customer_Not_Replied = "Exception Expired - Customer Not Replied";
        public const string No_Mails_Received_Customer_Replied_Yes = "No Mails - Customer Replied Yes";
        public const string No_Mails_Received_Customer_Reply_No = "No Mails - Customer Replied No";
    }

    public class ExceptionStatusDefinitions
    {
        public static string Ongoing = "Ongoing";
        public static string Returned = "Returned";
        public static string Closed = "Closed";
        public static string Canceled = "Canceled";
        public static string Expired = "Expired";
    }

    public class BatchStatusDefinitions
    {
        public static string YetToReceive = "Yet To Receive";
        public static string Created = "Created";
        public static string Received = "Received";
        public static string Processed = "Processed";
        public static string Exception = "Exception";
        public static string Completed = "Completed";
        public static string Cancelled = "Cancelled";
    }

    public class EmailHeaderDefinitions
    {
        public const string Mail_Quantity_Discrepancy = "Mail Quantity Discrepancy";
        public const string Returned_Mail_Acknowledgement_for_Mail_Quantity_Discrepancy = "Returned Mail Acknowledgement for Mail Quantity Discrepancy";
        public const string Physical_Mail_Not_Received_by_Mailroom = "Physical Mail Not Received by Mailroom";
    }
}