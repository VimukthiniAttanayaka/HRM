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
    public class UserOtpController : ControllerBase
    {
        private LogError objError = new LogError();
        private SendMail sendMail = new SendMail();
        //private SendSMS sendSMS = new SendSMS();

        // GET: api/<UserOtpController>
        [HttpPost]
        [Route("[action]")]
        public async Task<List<RtnOTPModel>> send_otp_via_sms(UserOtpSmsModel otp)
        {

            List<RtnOTPModel> objOtpHeadList = new List<RtnOTPModel>();
            //List<UserOtpModel> objOtpSList = new List<UserOtpModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, otp);

                RtnOTPModel objOtpHead = new RtnOTPModel();
                //objOtpHead.resp = true;
                //objOtpHead.msg = "Verify OTP";

                string dst = otp.UD_MobileNumber;

                string msg = "Dear User,Please use this OTP to verify your HRM login." + otp.UD_Otp + " This OTP will be valid for the next 5 mins.";


                ReturnResponse smsrtn = SMS_Sender_Preperation.SMSgateway(dst, msg, "", true);

                if (smsrtn.resp == false)
                {
                    objOtpHead.resp = false;
                    objOtpHead.msg = "There was an error in sending the OTP";
                }
                else
                {
                    objOtpHead.resp = true;
                    objOtpHead.msg = "Verify OTP";
                }

                // return objBankSList;
                objOtpHeadList.Add(objOtpHead);
            }
            catch (Exception ex)
            {
                RtnOTPModel objOtpHead = new RtnOTPModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objOtpHeadList.Add(objOtpHead);

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



        //POST api/<UserOtpController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnVerifyOTPModelHead> SaveUserOtp(SaveUserOtpModel saveotp)
        {
            List<ReturnVerifyOTPModelHead> objRtnOTPHeadList = new List<ReturnVerifyOTPModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, saveotp);

                objRtnOTPHeadList = UserOtp_BL.SaveUserOtp(saveotp);
                return objRtnOTPHeadList;

            }
            catch (Exception ex)
            {
                ReturnVerifyOTPModelHead objUserVerifyOTPHead = new ReturnVerifyOTPModelHead
                {
                    resp = false,
                    msg = ex.Message
                };
                objRtnOTPHeadList.Add(objUserVerifyOTPHead);

                objError.WriteLog(0, "UserOtpController", "SaveUserOtp", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserOtpController", "SaveUserOtp", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserOtpController", "SaveUserOtp", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserOtpController", "SaveUserOtp", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objRtnOTPHeadList;
        }


        // GET: api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<RtnOTPModel> VerifyOTP(UserOtpModel otp)
        {

            List<RtnOTPModel> objVerifyOTPList = new List<RtnOTPModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, otp);

                objVerifyOTPList = UserOtp_Data.VerifyOTP(otp);
                return objVerifyOTPList;
            }
            catch (Exception ex)
            {

                RtnOTPModel objVerifyOTP = new RtnOTPModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objVerifyOTPList.Add(objVerifyOTP);

                objError.WriteLog(0, "UserOtpController", "VerifyOTP", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserOtpController", "VerifyOTP", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserOtpController", "VerifyOTP", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserOtpController", "VerifyOTP", "Inner Exception Message: " + ex.InnerException.Message);
                }

                //return objResponseList;
            }

            return objVerifyOTPList;
        }
    }
}
