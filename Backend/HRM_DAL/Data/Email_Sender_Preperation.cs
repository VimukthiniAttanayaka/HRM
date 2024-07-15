using email_sender;
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
using static HRM_DAL.Data.SMS_Sender_Preperation;
using email_sender.Models;

namespace HRM_DAL.Data
{
    public class Email_Sender_Preperation : EMAIL_SMS_Sender_Preperation
    {
        private static LogError objError = new LogError();

        //private static SendMail sendMail = new SendMail();

        public static ReturnResponse Send(string EmailAddress, string Body, string BU_ID, bool EmailOk, string subject, EmailAttachedFileDetails objFilesAttachment)
        {
            ReturnResponse ret = new ReturnResponse();

            GetSMS_BusinessUnitModel BU = SMS_Sender_Preperation.GetSMS_BusinessUnit(BU_ID);

            string EmailFromName = ConfigCaller.EmailFromName;
            //sendSMS.SMSgateway(MobileNumber, Body);

            if (BU == null)
            {
                if (EmailAddress.Contains(";"))
                {
                    (bool messageid, string message) result = SendMail.Send_V1_MultipleSender(BaseClassDBCallerData.From, EmailAddress, "",
                     subject, Body, BaseClassDBCallerData.smtpServer, BaseClassDBCallerData.smtpPort,
                     BaseClassDBCallerData.security, BaseClassDBCallerData.userNameEmail, BaseClassDBCallerData.userpassword, EmailFromName, objFilesAttachment);

                    ret.resp = result.messageid;
                    ret.msg = result.message;
                }
                else
                {
                    (bool messageid, string message) result = SendMail.Send_V1(BaseClassDBCallerData.From, EmailAddress, "",
                     subject, Body, BaseClassDBCallerData.smtpServer, BaseClassDBCallerData.smtpPort,
                     BaseClassDBCallerData.security, BaseClassDBCallerData.userNameEmail, BaseClassDBCallerData.userpassword, EmailFromName, objFilesAttachment);

                    ret.resp = result.messageid;
                    ret.msg = result.message;
                }
            }
            else
            {
                if (BU.BU_EMAIL_Enabled == true && EmailOk == true)
                {
                    if (EmailAddress.Contains(";"))
                    {
                        (bool messageid, string message) result = SendMail.Send_V1_MultipleSender(/*BaseClassDBCallerData.From*/BU.BU_EMAIL_SMTP_UID, EmailAddress, "", subject, Body, BU.BU_EMAIL_SMTP_HOST_IP,
                            BU.BU_EMAIL_SMTP_HOST_PORT, BU.BU_EMAIL_SMTP_SSL_ENABLE, BU.BU_EMAIL_SMTP_UID, BU.BU_EMAIL_SMTP_PWD, EmailFromName, objFilesAttachment);

                        ret.resp = result.messageid;
                        ret.msg = result.message;
                    }
                    else
                    {
                        (bool messageid, string message) result = SendMail.Send_V1(/*BaseClassDBCallerData.From*/BU.BU_EMAIL_SMTP_UID, EmailAddress, "", subject, Body, BU.BU_EMAIL_SMTP_HOST_IP,
                             BU.BU_EMAIL_SMTP_HOST_PORT, BU.BU_EMAIL_SMTP_SSL_ENABLE, BU.BU_EMAIL_SMTP_UID, BU.BU_EMAIL_SMTP_PWD, EmailFromName, objFilesAttachment);

                        ret.resp = result.messageid;
                        ret.msg = result.message;
                    }
                }
            }


            return ret;
        }
    }
}
