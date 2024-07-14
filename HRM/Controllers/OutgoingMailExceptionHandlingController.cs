using HRM_DAL.Models;
using error_handler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using utility_handler.Data;
//using static error_handler.InformationLog;
using static error_handler.ErrorLog;
using System.Reflection;
using static error_handler.InformationLog;
using static HRM_DAL.Data.OutgoingMailExceptionHandling_Data;
using HRM_DAL.Data;

namespace HRM.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class OutgoingMailExceptionHandlingController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> RunProcess()
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, new ReturnResponse() { });

                objHeadList = HRM_BL.OutgoingMailExceptionHandling_BL.RunProcess();

                return objHeadList;

            }
            catch (Exception ex)
            {
                ReturPCCodeModelHead objHead = new ReturPCCodeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "OutgoingMailExceptionHandlingController", "RunProcess", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "OutgoingMailExceptionHandlingController", "RunProcess", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "OutgoingMailExceptionHandlingController", "RunProcess", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "OutgoingMailExceptionHandlingController", "RunProcess", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> MainFlow1(List<ExceptionMailReaderTable> mailList)//triggering from emailread winsvc
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, new ReturnResponse() { });

                objHeadList = HRM_BL.OutgoingMailExceptionHandling_BL.MainFlow1(mailList);

                return objHeadList;

            }
            catch (Exception ex)
            {
                ReturPCCodeModelHead objHead = new ReturPCCodeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "OutgoingMailExceptionHandlingController", "MainFlow1", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "OutgoingMailExceptionHandlingController", "MainFlow1", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "OutgoingMailExceptionHandlingController", "MainFlow1", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "OutgoingMailExceptionHandlingController", "MainFlow1", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        public List<ReturnResponse> Send_Return_Confirmation_Email_Notification(HRM_DAL.Data.EmailSendingObject_ExceptionHandling model)
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            objHeadList = HRM_DAL.Data.OutgoingMailExceptionHandling_Data.EmailSender_Related.Send_Return_Confirmation_Email_Notification(model);

            return objHeadList;
        }

        public class ExceptioModel
        {
            public List<HRM_DAL.Data.NotificatioModel> notificationList { get; set; }
            public string CustomerName { get; set; }
            public string EmailAddress { get; set; }
        }

        //[HttpPost]
        //[Route("[action]")]
        //public List<ReturnResponse> Send_Email_Notification_to_Mail_Room_Staff_to_Handle_the_Exception_Manually(ExceptioModel model)
        //{
        //    List<ReturnResponse> objHeadList = new List<ReturnResponse>();

        //    objHeadList = HRM_DAL.Data.OutgoingMailExceptionHandling_Data.MainFlow2_Related.Send_Email_Notification_to_Mail_Room_Staff_to_Handle_the_Exception_Manually(model.notificationList, model.CustomerName);

        //    return objHeadList;
        //}

        [HttpPost]
        [Route("[action]")]
        public List<ReturnResponse> Send_Discrepancy_Email_Notification(HRM_DAL.Data.EmailSendingObject_ExceptionHandling model)
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            objHeadList = HRM_DAL.Data.OutgoingMailExceptionHandling_Data.EmailSender_Related.Send_Discrepancy_Email_Notification(model);

            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        public List<ReturnResponse> Send_Batch_Cancellation_Email(HRM_DAL.Data.EmailSendingObject_ExceptionHandling model)
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            objHeadList = HRM_DAL.Data.OutgoingMailExceptionHandling_Data.EmailSender_Related.Send_Batch_Cancellation_Email(model);

            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        public List<ReturnResponse> Send_No_Mail_Received_Email_Notification(HRM_DAL.Data.EmailSendingObject_ExceptionHandling model)
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            objHeadList = HRM_DAL.Data.OutgoingMailExceptionHandling_Data.EmailSender_Related.Send_No_Mail_Received_Email_Notification(model);

            return objHeadList;
        }
        //[HttpPost]
        //[Route("[action]")]
        //public List<HRM_DAL.Data.OutLookEamail_TransactionHeader> Get_Unread_Cutomer_Replied_Email_List_from_the_Inbox_by_Email_Received_Date_Date_ASC()
        //{
        //    List<HRM_DAL.Data.OutLookEamail_TransactionHeader> objHeadList = new List<HRM_DAL.Data.OutLookEamail_TransactionHeader>();

        //    objHeadList = HRM_DAL.Data.OutgoingMailExceptionHandling_Data.Get_Unread_Cutomer_Replied_Email_List_from_the_Inbox_by_Email_Received_Date_Date_ASC();

        //    return objHeadList;
        //}

        [HttpPost]
        [Route("[action]")]
        public List<HRM_DAL.Data.OutLookEamail_TransactionHeader> While_End_of_Exception_Batch_List_where_Exception_Status_not_in_Closed_Returned_Cancelled()
        {
            List<HRM_DAL.Data.OutLookEamail_TransactionHeader> objHeadList = new List<HRM_DAL.Data.OutLookEamail_TransactionHeader>();

            objHeadList = HRM_DAL.Data.OutgoingMailExceptionHandling_Data.MainFlow2_Related.While_End_of_Exception_Batch_List_where_Exception_Status_not_in_Closed_Returned_Cancelled();

            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        public EmailSendingObject_ExceptionHandling get_batchno_details_ExceptionEmail()
        {
            EmailSendingObject_ExceptionHandling objHeadList = new EmailSendingObject_ExceptionHandling();
            string BatchNo = "M_B1001-DBS-000-000-230600349";
            objHeadList = HRM_DAL.Data.OutgoingMailExceptionHandling_Data.get_batchno_details_ExceptionEmail(BatchNo);
            EmailSender_Related.Send_Returned_Mail_Acknowledgement_Discrepancy_Email_Notification(objHeadList);
            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        public void UpdateOutgoingExceptionStatus(HRM_DAL.Data.ExceptionMailReaderTable model)
        {
            HRM_DAL.Data.OutgoingMailExceptionHandling_Data.UpdateOutgoingExceptionStatus(model, model.ExceptionStatus);

        }

        [HttpPost]
        [Route("[action]")]
        public List<DateTime> get_workingdays_from_calander()
        {
            List<DateTime> objHeadList = new List<DateTime>();

            objHeadList = HRM_DAL.Data.OutgoingMailExceptionHandling_Data.MainFlow2_Related.get_workingdays_from_calander();

            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        public void If_the_Current_Batch_Enabled_for_Email_Exception_Notification_sending()
        {
            HRM_DAL.Data.OutgoingMailExceptionHandling_Data.MainFlow2_Related.If_the_Current_Batch_Enabled_for_Email_Exception_Notification_sending();
        }

    }
}
