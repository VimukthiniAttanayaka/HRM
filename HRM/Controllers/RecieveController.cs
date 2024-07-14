using email_sender;
using error_handler;
using HRM_BL;
using HRM_DAL.Models;
using Microsoft.AspNetCore.Mvc;
using sms_core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using utility_handler.Data;

namespace HRM.Controllers
{
    //Unfinalized codes, cause of abnormal shut off of project!!!!!
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class RecieveController : ControllerBase
    {
        private LogError objError = new LogError();
        private SendMail sendMail = new SendMail();
        private SendSMS sendSMS = new SendSMS();

        [HttpPost]
        [Route("[action]")]
        public List<ReceiveSummeryHeaderModel> get_batch_details(ProcessRequestQRStringModel BatchNo)
        {
            List<ReceiveSummeryHeaderModel> objUserSList = new List<ReceiveSummeryHeaderModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, BatchNo);

                objUserSList = Recieve_BL.get_batch_details(BatchNo);
                return objUserSList;
            }
            catch (Exception ex)
            {

                ReceiveSummeryHeaderModel objUserHead = new ReceiveSummeryHeaderModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserSList.Add(objUserHead);

                objError.WriteLog(0, "RecieveController", "get_batch_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "RecieveController", "get_batch_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "RecieveController", "get_batch_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "RecieveController", "get_batch_details", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserSList;
        }

        [HttpPost]
        [Route("[action]")]
        public List<ReceiveSubmitBatchModel> insert_batch_submit(ReceiveSubmitBatchNoModel model)
        {
            List<ReceiveSubmitBatchModel> objUserSList = new List<ReceiveSubmitBatchModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                objUserSList = Recieve_BL.insert_batch_submit(model);
                return objUserSList;
            }
            catch (Exception ex)
            {

                ReceiveSubmitBatchModel objUserHead = new ReceiveSubmitBatchModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserSList.Add(objUserHead);

                objError.WriteLog(0, "RecieveController", "insert_batch_submit", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "RecieveController", "insert_batch_submit", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "RecieveController", "insert_batch_submit", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "RecieveController", "insert_batch_submit", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserSList;
        }

        [HttpPost]
        [Route("[action]")]
        public List<ReceiveGridViewHeaderModel> get_batch_grid_details(ReceiveGridRequestBatchNoModel gridmodel)
        {
            List<ReceiveGridViewHeaderModel> objUserSList = new List<ReceiveGridViewHeaderModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, gridmodel);

                objUserSList = Recieve_BL.get_batch_grid_details(gridmodel);
                return objUserSList;
            }
            catch (Exception ex)
            {

                ReceiveGridViewHeaderModel objUserHead = new ReceiveGridViewHeaderModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserSList.Add(objUserHead);

                objError.WriteLog(0, "RecieveController", "get_batch_grid_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "RecieveController", "get_batch_grid_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "RecieveController", "get_batch_grid_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "RecieveController", "get_batch_grid_details", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserSList;
        }

        [HttpPost]
        [Route("[action]")]
        public List<ReceiveCreateNewBatchHeaderModel> create_new_batch(ReceiveCreateNewBatchModel model)
        {
            List<ReceiveCreateNewBatchHeaderModel> objUserSList = new List<ReceiveCreateNewBatchHeaderModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                objUserSList = Recieve_BL.create_new_batch(model);
                return objUserSList;
            }
            catch (Exception ex)
            {

                ReceiveCreateNewBatchHeaderModel objUserHead = new ReceiveCreateNewBatchHeaderModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserSList.Add(objUserHead);

                objError.WriteLog(0, "RecieveController", "create_new_batch", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "RecieveController", "create_new_batch", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "RecieveController", "create_new_batch", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "RecieveController", "create_new_batch", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserSList;
        }

        [HttpPost]
        [Route("[action]")]
        public List<ReceiveSummeryHeaderModel> get_receiving_pending(ReceivePendingModel model)
        {
            List<ReceiveSummeryHeaderModel> objUserSList = new List<ReceiveSummeryHeaderModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                objUserSList = Recieve_BL.get_receiving_pending(model);
                return objUserSList;
            }
            catch (Exception ex)
            {
                ReceiveSummeryHeaderModel objUserHead = new ReceiveSummeryHeaderModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserSList.Add(objUserHead);

                objError.WriteLog(0, "RecieveController", "get_receiving_pending", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "RecieveController", "get_receiving_pending", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "RecieveController", "get_receiving_pending", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "RecieveController", "get_receiving_pending", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserSList;
        }

        [HttpPost]
        [Route("[action]")]
        public List<ServerDateTimeHeaderModel> get_server_Datetime(RequestBaseModel model)
        {
            List<ServerDateTimeHeaderModel> objUserSList = new List<ServerDateTimeHeaderModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                objUserSList = Recieve_BL.get_server_Datetime(model);
                return objUserSList;
            }
            catch (Exception ex)
            {
                ServerDateTimeHeaderModel objUserHead = new ServerDateTimeHeaderModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserSList.Add(objUserHead);

                objError.WriteLog(0, "RecieveController", "get_server_Datetime", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "RecieveController", "get_server_Datetime", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "RecieveController", "get_server_Datetime", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "RecieveController", "get_server_Datetime", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserSList;
        }

        //Kiosk Activity Report
        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReportsReturnResponse_Image> PrintQRSticker(ReceiveRequestBatchNoModel model)
        {
            List<ReportsReturnResponse_Image> objUserHeadList = new List<ReportsReturnResponse_Image>();

            try
            {
                return HRM_BL.Recieve_BL.PrintQRSticker(model);
            }
            catch (Exception ex)
            {
                ReportsReturnResponse_Image objUserHead = new ReportsReturnResponse_Image
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "RecieveController", "KioskActivityReport", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "RecieveController", "KioskActivityReport", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "RecieveController", "KioskActivityReport", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "RecieveController", "KioskActivityReport", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserHeadList;
        }

        //Kiosk Activity Report
        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReceiveSubmitBatchModel> ClearForm_Receive(ReceiveDeleteBatchNoModel model)
        {
            List<ReceiveSubmitBatchModel> objUserHeadList = new List<ReceiveSubmitBatchModel>();

            try
            {
                return HRM_BL.Recieve_BL.ClearForm_Receive(model);
            }
            catch (Exception ex)
            {
                ReceiveSubmitBatchModel objUserHead = new ReceiveSubmitBatchModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "RecieveController", "ClearForm_Receive", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "RecieveController", "ClearForm_Receive", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "RecieveController", "ClearForm_Receive", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "RecieveController", "ClearForm_Receive", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserHeadList;
        }
    }
}
