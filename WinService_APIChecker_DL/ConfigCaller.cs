using System;
using System.Configuration;

namespace Kioski_APIChecker_DL
{
    public class ConfigCaller
    {
        public static string ErrorLogPath
        {
            get
            {
                return ConfigurationManager.AppSettings["ErrorLogPath"];
            }

        }
        public static int ExecutionInterval_MailBag
        {
            get
            {
                int executionInterval_MailBag = 1;
                int.TryParse(ConfigurationManager.AppSettings["ExecutionInterval_MailBag"], out executionInterval_MailBag);
                return executionInterval_MailBag;
            }

        }

        public static string SyncWithMailTrackKiosk_UserID
        {
            get
            {

                try
                {
                    return ConfigurationManager.AppSettings["SyncWithMailTrackKiosk_UserID"];
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static int SyncWithMailTrackKiosk_maxTransCount
        {
            get
            {

                try
                {
                    int count = 1;
                    int.TryParse(ConfigurationManager.AppSettings["SyncWithMailTrackKiosk_maxTransCount"], out count);
                    return count;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
        public static string MailTracker_GetMailbagURL
        {
            get
            {
                return ConfigurationManager.AppSettings["MailTracker_GetMailbagURL"];
            }
        }

        public static string MailTracker_AckMailbagURL
        {
            get
            {
                return ConfigurationManager.AppSettings["MailTracker_AckMailbagURL"];
            }
        }

        public static string MailTracker_AckMailbag_BulkURL
        {
            get
            {
                return ConfigurationManager.AppSettings["MailTracker_AckMailbag_BulkURL"];
            }
        }

        public static string MailTracker_GetSystemParameterURL
        {
            get
            {
                return ConfigurationManager.AppSettings["MailTracker_GetSystemParameterURL"];
            }
        }

        public static int ExecutionInterval_AckBulk
        {
            get
            {
                int executionInterval_AckBulk = 1;
                int.TryParse(ConfigurationManager.AppSettings["ExecutionInterval_AckBulk"], out executionInterval_AckBulk);
                return executionInterval_AckBulk;
            }
        }

        public static string MailTracker_Get_OutGoingMailTransURL
        {
            get
            {
                return ConfigurationManager.AppSettings["MailTracker_Get_OutGoingMailTransURL"];
            }
        }
        public static string MailTracker_Ack_OutGoingMailTransURL
        {
            get
            {
                return ConfigurationManager.AppSettings["MailTracker_Ack_OutGoingMailTransURL"];
            }
        }
        public static string MailTracker_Set_DepartmentsURL
        {
            get
            {
                return ConfigurationManager.AppSettings["MailTracker_Set_DepartmentsURL"];
            }
        }
        public static string MailTracker_Get_DepartmentsURL
        {
            get
            {
                return ConfigurationManager.AppSettings["MailTracker_Get_DepartmentsURL"];
            }
        }
        public static string MailTracker_Get_UserGroupsURL
        {
            get
            {
                return ConfigurationManager.AppSettings["MailTracker_Get_UserGroupsURL"];
            }
        }
        public static string MailTracker_Get_LocationsURL
        {
            get
            {
                return ConfigurationManager.AppSettings["MailTracker_Get_LocationsURL"];
            }
        }
        public static string MailTracker_Set_UsersURL
        {
            get
            {
                return ConfigurationManager.AppSettings["MailTracker_Set_UsersURL"];
            }
        }
        public static string MailTracker_Get_DeviceActsURL
        {
            get
            {
                return ConfigurationManager.AppSettings["MailTracker_Get_DeviceActsURL"];
            }
        }  
        
        public static string MailTracker_Ack_DeviceActsURL
        {
            get
            {
                return ConfigurationManager.AppSettings["MailTracker_Ack_DeviceActsURL"];
            }
        }
        public static int ExecutionInterval_Get_DeviceActs
        {
            get
            {
                int executionInterval_Get_DeviceActs = 1;
                int.TryParse(ConfigurationManager.AppSettings["ExecutionInterval_Get_DeviceActs"], out executionInterval_Get_DeviceActs);
                return executionInterval_Get_DeviceActs;
            }
        }

        public static int ExecutionInterval_SetDepartments
        {
            get
            {
                int executionInterval_SetDepartments = 1;
                int.TryParse(ConfigurationManager.AppSettings["ExecutionInterval_SetDepartments"], out executionInterval_SetDepartments);
                return executionInterval_SetDepartments;
            }
        }
        public static int ExecutionInterval_GetDepartments
        {
            get
            {
                int executionInterval_GetDepartments = 1;
                int.TryParse(ConfigurationManager.AppSettings["ExecutionInterval_GetDepartments"], out executionInterval_GetDepartments);
                return executionInterval_GetDepartments;
            }
        }
        public static int ExecutionInterval_Get_OutGoingMailTrans
        {
            get
            {
                int executionInterval_Get_OutGoingMailTrans = 1;
                int.TryParse(ConfigurationManager.AppSettings["ExecutionInterval_Get_OutGoingMailTrans"], out executionInterval_Get_OutGoingMailTrans);
                return executionInterval_Get_OutGoingMailTrans;
            }
        }
        public static int ExecutionInterval_Get_UserGroups
        {
            get
            {
                int executionInterval_Get_UserGroups = 1;
                int.TryParse(ConfigurationManager.AppSettings["ExecutionInterval_Get_UserGroups"], out executionInterval_Get_UserGroups);
                return executionInterval_Get_UserGroups;
            }
        }
        public static int ExecutionInterval_Get_Locations
        {
            get
            {
                int executionInterval_Get_Locations = 1;
                int.TryParse(ConfigurationManager.AppSettings["ExecutionInterval_Get_Locations"], out executionInterval_Get_Locations);
                return executionInterval_Get_Locations;
            }
        }
        public static int ExecutionInterval_Set_Users
        {
            get
            {
                int executionInterval_Set_Users = 1;
                int.TryParse(ConfigurationManager.AppSettings["ExecutionInterval_Set_Users"], out executionInterval_Set_Users);
                return executionInterval_Set_Users;
            }
        }

        public static int ExecutionInterval_ExceptionEmail
        {
            get
            {
                int ExecutionInterval_ExceptionEmail = 1;
                int.TryParse(ConfigurationManager.AppSettings["ExecutionInterval_ExceptionEmail"], out ExecutionInterval_ExceptionEmail);
                return ExecutionInterval_ExceptionEmail;
            }
        }

        public static string MailTracker_ExceptionEmailURL
        {
            get
            {
                return ConfigurationManager.AppSettings["MailTracker_ExceptionEmailURL"];
            }
        }

        public static string MailTracker_OutlookEmailURL
        {
            get
            {
                return ConfigurationManager.AppSettings["MailTracker_OutlookEmailURL"];
            }
        }

        public static string MailTracker_MailRoomStaff_EmailList
        {
            get
            {
                return ConfigurationManager.AppSettings["MailTracker_MailRoomStaff_EmailList"];
            }
        }

        public static int ExecutionInterval_DayEndProcess_Batch_Summary_Email
        {
            get
            {
                int ExecutionInterval_ExceptionEmail = 1;
                int.TryParse(ConfigurationManager.AppSettings["ExecutionInterval_DayEndProcess_Batch_Summary_Email"], out ExecutionInterval_ExceptionEmail);
                return ExecutionInterval_ExceptionEmail;
            }
        }

        public static string DayEndProcess_Batch_Summary_Email_URL
        {
            get
            {
                return ConfigurationManager.AppSettings["DayEndProcess_Batch_Summary_Email_URL"];
            }
        }

        public static string UserPasswordAutoReset_URL
        {
            get
            {
                return ConfigurationManager.AppSettings["UserPasswordAutoReset_URL"];
            }
        }
    }
}