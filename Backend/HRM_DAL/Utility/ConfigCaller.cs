using utility_handler.Utility;
using Microsoft.Extensions.Configuration;
using System;

namespace HRM_DAL.Data
{
    public class ConfigCaller
    {
        public ConfigCaller()
        {
        }
        static IConfigurationRoot config = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json")
                  .Build();

        public static string CustomerUserGroupID
        {
            get
            {

                try
                {

                    var CustomerUserGroupID = config["appSettings:CustomerUserGroupID"];

                    return CustomerUserGroupID;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
        public static string PasswordPepper
        {
            get
            {

                try
                {

                    var PasswordPepper = config["appSettings:PasswordPepper"];
                    string decryPasswordPepper = Misc.deCrypt(PasswordPepper);
                    return decryPasswordPepper;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string RDLCReportPath
        {
            get
            {

                try
                {

                    var RDLCReportPath = config["appSettings:RDLCReportPath"];
                    return RDLCReportPath;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string PDFReportPath
        {
            get
            {

                try
                {

                    var PDFReportPath = config["appSettings:PDFReportPath"];
                    return PDFReportPath;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string SMSpassword
        {
            get
            {

                try
                {

                    var password = config["appSettings:password"];
                    string decrypassword = Misc.deCrypt(password);
                    return decrypassword;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
        public static string SMTPuserpassword
        {
            get
            {

                try
                {

                    var userpassword = config["appSettings:userpassword"];
                    string decryuserpassword = Misc.deCrypt(userpassword);
                    return decryuserpassword;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string HRMUserName
        {
            get
            {

                try
                {
                    return config["appSettings:HRMUserName"];
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
        public static string HRMPassword
        {
            get
            {

                try
                {
                    var userpassword = config["appSettings:HRMPassword"];
                    string decryuserpassword = Misc.deCrypt(userpassword);
                    return decryuserpassword;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string HRMAPI_TokenURL
        {
            get
            {

                try
                {
                    return config["appSettings:API_TokenURL"];
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string API_GetMailbagTransactionsURL
        {
            get
            {

                try
                {
                    return config["appSettings:API_GetMailbagTransactionsURL"];
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string API_AckMailbagTransactionsURL
        {
            get
            {

                try
                {
                    return config["appSettings:API_AckMailbagTransactionsURL"];
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string SyncWithHRMKiosk_UserID
        {
            get
            {

                try
                {
                    return config["appSettings:SyncWithHRMKiosk_UserID"];
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static int SyncWithHRMKiosk_maxTransCount
        {
            get
            {

                try
                {
                    int count = 1;
                    int.TryParse(config["appSettings:SyncWithHRMKiosk_maxTransCount"], out count);
                    return count;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string API_SetDepartmentsURL
        {
            get
            {

                try
                {
                    return config["appSettings:API_SetDepartmentsURL"];
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string API_SetUserURL
        {
            get
            {

                try
                {
                    return config["appSettings:API_SetUserURL"];
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string API_Get_DepartmentsURL
        {
            get
            {

                try
                {
                    return config["appSettings:API_Get_DepartmentsURL"];
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string API_Get_UserGroupsURL
        {
            get
            {

                try
                {
                    return config["appSettings:API_Get_UserGroupsURL"];
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string API_Get_OutGoingMailTransURL
        {
            get
            {

                try
                {
                    return config["appSettings:API_Get_OutGoingMailTransURL"];
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string API_Get_DeviceActsURL
        {
            get
            {

                try
                {
                    return config["appSettings:API_Get_DeviceActsURL"];
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string API_Get_LocationsURL
        {
            get
            {

                try
                {
                    return config["appSettings:API_Get_LocationsURL"];
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string ExcelUpload_DefaultUserGroup
        {
            get
            {

                try
                {
                    return config["appSettings:ExcelUpload_DefaultUserGroup"];
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string KioskiClientSecret
        {
            get
            {

                try
                {
                    string userpassword = config["appSettings:KioskiClientSecret"];
                    string decryuserpassword = Misc.deCrypt(userpassword);
                    return decryuserpassword;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
        public static string KioskiClientID
        {
            get
            {

                try
                {
                    string userpassword = config["appSettings:KioskiClientID"];// config["appSettings:KioskiClientID"];
                    string decryuserpassword = Misc.deCrypt(userpassword);
                    return decryuserpassword;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string KioskiAPI_TokenURL
        {
            get
            {

                try
                {
                    string userpassword = config["appSettings:KioskiAPI_TokenURL"];// config["appSettings:KioskiClientID"];
                    return userpassword;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static int OZeroExpiresIn
        {
            get
            {

                try
                {
                    int count = 3600;
                    int.TryParse(config["appSettings:OZeroExpiresIn"], out count);
                    return count;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string KioskiAPI_Validate_OAuthToken
        {
            get
            {
                try
                {
                    string userpassword = config["appSettings:KioskiAPI_Validate_OAuthToken"];// config["appSettings:KioskiClientID"];
                    return userpassword;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string API_Ack_OutGoingMailTransURL
        {
            get
            {
                try
                {
                    string userpassword = config["appSettings:API_Ack_OutGoingMailTransURL"];// config["appSettings:KioskiClientID"];
                    return userpassword;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string API_Ack_DeviceActsURL
        {
            get
            {
                try
                {
                    string userpassword = config["appSettings:API_Ack_DeviceActsURL"];// config["appSettings:KioskiClientID"];
                    return userpassword;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static int OutgoingMailException_Max_Discripancy_Notify_Count
        {
            get
            {
                try
                {
                    int userpassword = Convert.ToInt32(config["appSettings:OutgoingMailException_Max_Discripancy_Notify_Count"]);// config["appSettings:KioskiClientID"];
                    return userpassword;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static int OutgoingMailException_Max_Return_Not_Received_Notify_Count
        {
            get
            {
                try
                {
                    int userpassword = Convert.ToInt32(config["appSettings:OutgoingMailException_Max_Return_Not_Received_Notify_Count"]);// config["appSettings:KioskiClientID"];
                    return userpassword;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static int OutgoingMailException_Max_Pending_Return_Confirmation_Notify_Count
        {
            get
            {
                try
                {
                    int userpassword = Convert.ToInt32(config["appSettings:OutgoingMailException_Max_Pending_Return_Confirmation_Notify_Count"]);// config["appSettings:KioskiClientID"];
                    return userpassword;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string OutgoingMailException_Send_Email_Notification_to_Mail_Room_Staff_to_Handle_the_Exception_Manually
        {
            get
            {
                try
                {
                    string mailurl = config["appSettings:OutgoingMailException_Send_Email_Notification_to_Mail_Room_Staff_to_Handle_the_Exception_Manually"];// config["appSettings:KioskiClientID"];
                    return mailurl;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
        public static string OutgoingMailException_Send_Return_Confirmation_Email_Notification
        {
            get
            {
                try
                {
                    string mailurl = config["appSettings:OutgoingMailException_Send_Return_Confirmation_Email_Notification"];// config["appSettings:KioskiClientID"];
                    return mailurl;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string OutgoingMailException_Send_No_Mail_Received_Email_Notification
        {
            get
            {
                try
                {
                    string mailurl = config["appSettings:OutgoingMailException_Send_No_Mail_Received_Email_Notification"];// config["appSettings:KioskiClientID"];
                    return mailurl;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string OutgoingMailException_Send_Batch_Cancellation_Email_Notification
        {
            get
            {
                try
                {
                    string mailurl = config["appSettings:OutgoingMailException_Send_Batch_Cancellation_Email_Notification"];// config["appSettings:KioskiClientID"];
                    return mailurl;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string OutgoingMailException_Send_Discrepancy_Email_Notification
        {
            get
            {
                try
                {
                    string mailurl = config["appSettings:OutgoingMailException_Send_Discrepancy_Email_Notification"];// config["appSettings:KioskiClientID"];
                    return mailurl;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
        public static string Email_Notification_to_Returned_Mail_Acknowledgement_Discrepancy_Email_Notification
        {
            get
            {
                try
                {
                    string mailurl = config["appSettings:Email_Notification_to_Returned_Mail_Acknowledgement_Discrepancy_Email_Notification"];// config["appSettings:KioskiClientID"];
                    return mailurl;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string HRM_MailRoomStaff_EmailList
        {
            get
            {
                string mailurl = config["appSettings:HRM_MailRoomStaff_EmailList"];// config["appSettings: KioskiClientID"];
                return mailurl;
            }
        }

        public static int Email_Notification_Batch_Email_Expiring_Days_Count
        {
            get
            {

                try
                {
                    int count = 0;
                    int.TryParse(config["appSettings:Email_Notification_Batch_Email_Expiring_Days_Count"], out count);
                    return count;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string Default_BusinessUnit
        {
            get
            {

                try
                {
                    string mailurl = config["appSettings:Default_BusinessUnit"];// config["appSettings: KioskiClientID"];
                    return mailurl;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string Email_Notification_to_Batch_Summary_Email_Notification
        {
            get
            {

                try
                {
                    string mailurl = config["appSettings:Email_Notification_to_Batch_Summary_Email_Notification"];// config["appSettings: KioskiClientID"];
                    return mailurl;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string KioskUserGroupID
        {
            get
            {

                try
                {
                    string mailurl = config["appSettings:KioskUserGroupID"];
                    return mailurl;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string UILogFilePath
        {
            get
            {

                try
                {
                    string mailurl = config["appSettings:UILogFilePath"];
                    return mailurl;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
        public static string HRMID
        {
            get
            {

                try
                {
                    string HRMID = config["appSettings:HRMID"];
                    return HRMID;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string EmailFromName
        {
            get
            {

                try
                {
                    string EmailFromName = config["appSettings:EmailFromName"];
                    return EmailFromName;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}