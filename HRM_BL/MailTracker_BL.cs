using error_handler;
using HRM_DAL.Models;
using HRM_DAL.Models.RequestModels;
using System;
using System.Collections.Generic;

namespace HRM_BL
{
    public class HRM_BL
    {
        private static LogError objError = new LogError();

        #region save data (data fetch from kiosk)

        public static List<ReturnResponse> add_update_location(string userId, LocationDto location)
        {
            return HRM_DAL.Data.HRM_Data.add_update_location(userId, location);
        }

        public static List<ReturnResponse> add_update_department(string userId, DepartmentDto department)
        {
            return HRM_DAL.Data.HRM_Data.add_update_department(userId, department);
        }

        public static List<ReturnResponse> add_update_usergroup(string userId, Get_UserGroups_ResponceModel userGroup)
        {
            return HRM_DAL.Data.HRM_Data.add_update_usergroup(userId, userGroup);
        }
        #endregion

        #region get data (from the db)

        //public static DepartmentRequestDto Set_Departments(string customerId)
        //{
        //    return HRM_DAL.Data.HRM_Data.Set_Departments(customerId);
        //}

        //public static UserRequestDto Set_Users()
        //{
        //    return HRM_DAL.Data.HRM_Data.Set_Users();
        //}

        //public static AcknowledgeMsg GetAcknowledge(string reqTransReferenceId, string reqTransType, int syncStatus)
        //{
        //    // TODO: Do the business validation
        //    return new AcknowledgeMsg
        //    {
        //        messageId = 1,
        //        message = "Success",
        //        result = new ResultOAuthToken()
        //    };
        //}

        public static void set_acknowledged_mails(Ack_MailBagTrans_RequestModel model)
        {
            HRM_DAL.Data.HRM_Data.set_acknowledged_mails(model);
        }
        public static void set_acknowledged_outgoingmails(Ack_OutGoingMailTrans_RequestModel model)
        {
            HRM_DAL.Data.HRM_Data.set_acknowledged_outgoingmails(model);
        }
  public static void set_acknowledged_deviceacts(Ack_DeviceActs_RequestModel model)
        {
            HRM_DAL.Data.HRM_Data.set_acknowledged_deviceacts(model);
        }

        #endregion
    }
}
