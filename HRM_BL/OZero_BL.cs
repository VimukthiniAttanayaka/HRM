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
using HRM_DAL.Models.RequestModels;
using HRM_DAL.Models.ResponceModels;

namespace HRM_BL
{
    public class OZero_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> Get_OAuthToken(Get_OAuthToken_RequestModel model,string requestReferenceID, string RequestType, string SmartKioskvendorID, string accessToken, int expiresIn)
        {
            List<ReturnResponse> retres = new List<ReturnResponse>();

            try
            {
                retres = OZero_Data.Get_OAuthToken(model, requestReferenceID, RequestType, SmartKioskvendorID, accessToken, expiresIn);
                return retres;
            }
            catch (Exception ex)
            {
                ReturnResponse objretres = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message
                };
                retres.Add(objretres);

                objError.WriteLog(0, "OZero_BL", "Get_OAuthToken", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "OZero_BL", "Get_OAuthToken", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "OZero_BL", "Get_OAuthToken", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "OZero_BL", "Get_OAuthToken", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return retres;
        }

        public static OZero_ReturnResponce Validate_OAuthToken(string Authorization, string RequestReferenceID, string RequestType, string SmartKioskvendorID)
        {

            OZero_ReturnResponce retres = new OZero_ReturnResponce();

            try
            {
                retres = OZero_Data.Validate_OAuthToken(Authorization, RequestReferenceID, RequestType, SmartKioskvendorID);
                return retres;
            }
            catch (Exception ex)
            {
                OZero_ReturnResponce objretres = new OZero_ReturnResponce
                {
                    messageId = 0,
                    message = ex.Message.ToString()
                };

                objError.WriteLog(0, "OZero_BL", "Validate_OAuthToken", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "OZero_BL", "Validate_OAuthToken", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "OZero_BL", "Validate_OAuthToken", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "OZero_BL", "Validate_OAuthToken", "Inner Exception Message: " + ex.InnerException.Message);
                }

                //return objResponseList;
            }

            return retres;
        }
    }
}
