using utility_handler_DL.Models;
using email_sender;

namespace utility_handler.Data
{
    public class Email_Sender_Preperation : EMAIL_SMS_Sender_Preperation
    {
        //private static SendMail sendMail = new SendMail();

        public static ReturnResponse Send(string EmailAddress, string Body, string BU_ID, bool EmailOk, string subject)
        {
            ReturnResponse ret = new ReturnResponse();

            GetSMS_BusinessUnitModel BU = EMAIL_SMS_Sender_Preperation.GetSMS_BusinessUnit(BU_ID);

            //sendSMS.SMSgateway(MobileNumber, Body);

            if (BU == null)
            {
                if (EmailAddress.Contains(";"))
                {
                  ReturnResponse result = SendMail.Send_V1_MultipleSender(ConfigCaller.From, EmailAddress, "",
                     subject, Body, ConfigCaller.smtpServer, ConfigCaller.smtpPort,
                     ConfigCaller.security, ConfigCaller.userNameEmail, ConfigCaller.userpassword);

                    ret = result;
                }
                else
                {
                    ReturnResponse result = SendMail.Send_V1(ConfigCaller.From, EmailAddress, "",
                     subject, Body, ConfigCaller.smtpServer, ConfigCaller.smtpPort,
                     ConfigCaller.security, ConfigCaller.userNameEmail, ConfigCaller.userpassword);

                    ret = result;
                }
            }
            else
            {
                if (BU.BU_EMAIL_Enabled == true && EmailOk == true)
                {
                    if (EmailAddress.Contains(";"))
                    {
                        ReturnResponse result = SendMail.Send_V1_MultipleSender(/*BaseClassDBCallerData.From*/BU.BU_EMAIL_SMTP_UID, EmailAddress, "", subject, Body, BU.BU_EMAIL_SMTP_HOST_IP,
                            BU.BU_EMAIL_SMTP_HOST_PORT, BU.BU_EMAIL_SMTP_SSL_ENABLE, BU.BU_EMAIL_SMTP_UID, BU.BU_EMAIL_SMTP_PWD);

                        ret = result;
                    }
                    else
                    {
                        ReturnResponse result = SendMail.Send_V1(/*BaseClassDBCallerData.From*/BU.BU_EMAIL_SMTP_UID, EmailAddress, "", subject, Body, BU.BU_EMAIL_SMTP_HOST_IP,
                             BU.BU_EMAIL_SMTP_HOST_PORT, BU.BU_EMAIL_SMTP_SSL_ENABLE, BU.BU_EMAIL_SMTP_UID, BU.BU_EMAIL_SMTP_PWD);

                        ret = result;
                    }
                }
            }


            return ret;
        }
    }
}
