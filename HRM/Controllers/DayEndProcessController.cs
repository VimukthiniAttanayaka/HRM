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
using Newtonsoft.Json;

namespace HRM.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class DayEndProcessController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> Batch_Summary_Email()
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, new ReturnResponse() { });

                objHeadList = HRM_BL.DayEndProcess_BL.Batch_Summary_Email_Process();

                string DATA = JsonConvert.SerializeObject(objHeadList);
                objError.WriteLog(2, "DayEndProcessController", "Batch_Summary_Email", "Stack Track: " + DATA);

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

                objError.WriteLog(0, "DayEndProcessController", "Batch_Summary_Email", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DayEndProcessController", "Batch_Summary_Email", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DayEndProcessController", "Batch_Summary_Email", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DayEndProcessController", "Batch_Summary_Email", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> Batch_Summary_Email_ManualProcess()
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, new ReturnResponse() { });

                objHeadList = HRM_BL.DayEndProcess_BL.Batch_Summary_Email_ManualProcess();

                string DATA = JsonConvert.SerializeObject(objHeadList);
                objError.WriteLog(2, "DayEndProcessController", "Batch_Summary_Email", "Stack Track: " + DATA);

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

                objError.WriteLog(0, "DayEndProcessController", "Batch_Summary_Email_ManualProcess", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DayEndProcessController", "Batch_Summary_Email_ManualProcess", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DayEndProcessController", "Batch_Summary_Email_ManualProcess", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DayEndProcessController", "Batch_Summary_Email_ManualProcess", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> Send_Batch_Summary_Email_Notification()
        {
            List<ReturnResponse> lst = DayEndProcess_Data.Batch_Summary_Email.Send_Batch_Summary_Email_Notification(
                new DayEndProcess_Data.DayEndProcessHeader()
                {
                    EmailAddress = "neelaka.karunasekara@transnational-grp.com",
                    BusinessUnit = "02",
                    BatchNumber="12465",
                    DayEndProcessDetails =
                new List<DayEndProcess_Data.DayEndProcessDetail>() { new DayEndProcess_Data.DayEndProcessDetail() { Country = "text", TrackingNumber = "text" } }
                });
            return lst;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<DayEndProcess_Data.DayEndProcessHeader> Batch_Summary_List_where_Status_Completed()
        {
            List<DayEndProcess_Data.DayEndProcessHeader> lst = DayEndProcess_Data.Batch_Summary_Email.Batch_Summary_List_where_Status_Completed();
            return lst;
        }
    }
}
