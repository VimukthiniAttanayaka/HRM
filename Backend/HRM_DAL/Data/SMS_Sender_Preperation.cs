using error_handler;
using HRM_DAL.Models;
using HRM_DAL.Utility;
using sms_core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using utility_handler.Data;
using utility_handler.Utility;

namespace HRM_DAL.Data
{
    public class SMS_Sender_Preperation : EMAIL_SMS_Sender_Preperation
    {
        private static LogError objError = new LogError();

        private static SendSMS sendSMS = new SendSMS();

        public static ReturnResponse SMSgateway(string MobileNumber, string Body, string BU_ID, bool SMSOk)
        {
            ReturnResponse ret = new ReturnResponse();

            GetSMS_BusinessUnitModel BU = GetSMS_BusinessUnit(BU_ID);

            //sendSMS.SMSgateway(MobileNumber, Body);

            if (BU == null)
            {
                Task<(bool status, string message)> result = sendSMS.SMSgateway_V2(MobileNumber, Body, BaseClassDBCallerData.SMSURL, BaseClassDBCallerData.SMSUsername,
                                            BaseClassDBCallerData.SMSPassword,
                                            BaseClassDBCallerData.type);
                ret.resp = result.Result.status;
                ret.msg = "SMS : " + result.Result.message;
            }
            else
            {
                if (BU.BU_SMS_Enabled == true && SMSOk == true)
                {
                    if (BU.BU_SMS_BY_LINKURL == true)
                    {
                        Task<(bool status, string message)> result = sendSMS.SMSgateway_V2(MobileNumber, Body, BU.BU_SMS_GW_HOST_IP, BU.BU_SMS_GW_JID,
                                              BU.BU_SMS_GW_PWD,
                                              BU.BU_SMS_GW_IIM_SVR);
                        ret.resp = result.Result.status;
                        ret.msg = "SMS : "+ result.Result.message;
                    }
                    //else
                    //{
                    //    SmsHelper.SendSMSMessage(MobileNumber, Body, BU.BU_SMS_GW_HOST_PORT);
                    //    //Task<(bool status, string message)> result = sendSMS.SMSgateway(MobileNumber, Body, BU.BU_SMS_GW_HOST_IP, BaseClassDBCallerData.SMSUsername,
                    //    //                   BU.BU_SMS_GW_PWD,
                    //    //                   BaseClassDBCallerData.type);
                    //    //ret.resp = result.Result.status;
                    //    //ret.msg = result.Result.message;
                    //}
                }
            }


            return ret;
        }
    }

}
