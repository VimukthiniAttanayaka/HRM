using HRM_DAL.Models;
using HRM_BL;
using email_sender;
using error_handler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using sms_core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using utility_handler.Data;
using HRM_DAL.Data;
using System.Reflection;

namespace HRM.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    public class SMSTesterController : ControllerBase
    {
        public class SMSgatewayModel
        {
            public string MobileNumber { get; set; }
            public string Body { get; set; }
            public string BU_ID { get; set; }
            public bool SMSOk { get; set; }
        }


        private LogError objError = new LogError();
        private SendMail sendMail = new SendMail();
        //private SendSMS sendSMS = new SendSMS();

        // GET: api/<UserOtpController>
        [HttpPost]
        [Route("[action]")]
        public async Task<ReturnResponse> SMSgateway(SMSgatewayModel model)
        {

            ReturnResponse objOtpHeadList = new ReturnResponse();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                if (string.IsNullOrEmpty(model.MobileNumber))
                {
                    objOtpHeadList = new ReturnResponse
                    {
                        resp = false,
                        msg = "Please Enter Mobile Number"
                    };
                    return objOtpHeadList;
                }
                if (string.IsNullOrEmpty(model.Body))
                {
                    objOtpHeadList = new ReturnResponse
                    {
                        resp = false,
                        msg = "Please Enter Message"
                    };
                    return objOtpHeadList;
                }

                ReturnResponse smsrtn = SMS_Sender_Preperation.SMSgateway(model.MobileNumber, model.Body, model.BU_ID, model.SMSOk);

                return smsrtn;
            }
            catch (Exception ex)
            {
                objOtpHeadList = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };

                objError.WriteLog(0, "UserOtpController", "GetUserOtp", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserOtpController", "GetUserOtp", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserOtpController", "GetUserOtp", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserOtpController", "GetUserOtp", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objOtpHeadList;
        }
    }
}
