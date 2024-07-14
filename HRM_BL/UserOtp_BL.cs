using HRM_DAL.Models;
using HRM_BL;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using email_sender;
using sms_core;
using System;
using HRM_DAL.Data;

namespace HRM_BL
{
    public class UserOtp_BL
    {
        private static LogError objError = new LogError();
        //private static SendMail sendMail = new SendMail();
        //private static SendSMS sendSMS = new SendSMS();

        public static List<ReturnVerifyOTPModelHead> SaveUserOtp(SaveUserOtpModel saveotp)
        {
            List<ReturnVerifyOTPModelHead> objRtnOTPHeadList = new List<ReturnVerifyOTPModelHead>();

            try
            {
                objRtnOTPHeadList= UserOtp_Data.SaveUserOtp(saveotp);
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

                objError.WriteLog(0, "UserOtp_BL", "SaveUserOtp", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserOtp_BL", "SaveUserOtp", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserOtp_BL", "SaveUserOtp", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserOtp_BL", "SaveUserOtp", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objRtnOTPHeadList;
        }

        public static List<RtnOTPModel> VerifyOTP(UserOtpModel otp)
        {

            List<RtnOTPModel> objVerifyOTPList = new List<RtnOTPModel>();

            try
            {
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

                objError.WriteLog(0, "UserOtp_BL", "VerifyOTP", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserOtp_BL", "VerifyOTP", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserOtp_BL", "VerifyOTP", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserOtp_BL", "VerifyOTP", "Inner Exception Message: " + ex.InnerException.Message);
                }

                //return objResponseList;
            }

            return objVerifyOTPList;
        }
    }
}
