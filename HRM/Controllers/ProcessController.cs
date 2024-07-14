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

    public class ProcessController : ControllerBase
    {
        private LogError objError = new LogError();
        private SendMail sendMail = new SendMail();
        private SendSMS sendSMS = new SendSMS();

        [HttpPost]
        [Route("[action]")]
        public List<ProcessSummeryHeaderModel> get_batch_details(ProcessRequestBatchNoModel BatchNo)
        {
            List<ProcessSummeryHeaderModel> objUserSList = new List<ProcessSummeryHeaderModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, BatchNo);

                objUserSList = Process_BL.get_batch_details(BatchNo);
                return objUserSList;
            }
            catch (Exception ex)
            {

                ProcessSummeryHeaderModel objUserHead = new ProcessSummeryHeaderModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserSList.Add(objUserHead);

                objError.WriteLog(0, "ProcessController", "get_batch_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ProcessController", "get_batch_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ProcessController", "get_batch_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ProcessController", "get_batch_details", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserSList;
        }

        [HttpPost]
        [Route("[action]")]
        public List<ProcessSubmitBatchModel> insert_batch_submit(ProcessSubmitBatchNoModel model)
        {
            List<ProcessSubmitBatchModel> objUserSList = new List<ProcessSubmitBatchModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                objUserSList = Process_BL.insert_batch_submit(model);
                return objUserSList;
            }
            catch (Exception ex)
            {

                ProcessSubmitBatchModel objUserHead = new ProcessSubmitBatchModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserSList.Add(objUserHead);

                objError.WriteLog(0, "ProcessController", "insert_batch_submit", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ProcessController", "insert_batch_submit", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ProcessController", "insert_batch_submit", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ProcessController", "insert_batch_submit", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserSList;
        }

        [HttpPost]
        [Route("[action]")]
        public List<ProcessGridViewHeaderModel> get_batch_grid_details(ProcessGridRequestBatchNoModel gridmodel)
        {
            List<ProcessGridViewHeaderModel> objUserSList = new List<ProcessGridViewHeaderModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, gridmodel);

                objUserSList = Process_BL.get_batch_grid_details(gridmodel);
                return objUserSList;
            }
            catch (Exception ex)
            {

                ProcessGridViewHeaderModel objUserHead = new ProcessGridViewHeaderModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserSList.Add(objUserHead);

                objError.WriteLog(0, "ProcessController", "get_batch_grid_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ProcessController", "get_batch_grid_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ProcessController", "get_batch_grid_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ProcessController", "get_batch_grid_details", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserSList;
        }

        [HttpPost]
        [Route("[action]")]
        public List<ProcessSubmitBatchModel> update_process_batch_submit(ProcessSubmitBatchNoModel model)
        {
            List<ProcessSubmitBatchModel> objUserSList = new List<ProcessSubmitBatchModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                objUserSList = Process_BL.update_process_batch_submit(model);

                return objUserSList;
            }
            catch (Exception ex)
            {

                ProcessSubmitBatchModel objUserHead = new ProcessSubmitBatchModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserSList.Add(objUserHead);

                objError.WriteLog(0, "ProcessController", "update_process_batch_submit", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ProcessController", "update_process_batch_submit", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ProcessController", "update_process_batch_submit", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ProcessController", "update_process_batch_submit", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserSList;
        }

        [HttpPost]
        [Route("[action]")]
        public List<FullProcessSummeryHeaderModel> get_batch_full_details(ProcessRequestBatchNoModel BatchNo)
        {
            List<FullProcessSummeryHeaderModel> objUserSList = new List<FullProcessSummeryHeaderModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, BatchNo);

                objUserSList = Process_BL.get_batch_full_details(BatchNo);
                return objUserSList;
            }
            catch (Exception ex)
            {

                FullProcessSummeryHeaderModel objUserHead = new FullProcessSummeryHeaderModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserSList.Add(objUserHead);

                objError.WriteLog(0, "ProcessController", "get_batch_full_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ProcessController", "get_batch_full_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ProcessController", "get_batch_full_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ProcessController", "get_batch_full_details", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserSList;
        }


    }
}
