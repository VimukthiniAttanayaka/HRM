using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System;
using HRM_DAL.Models.RequestModels;

namespace HRM_BL
{
    public class UserGroupMaster_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturUserGroupMasterModelHead> get_user_group_master_all(GetUGMAllModel UGMall)
        {
            return HRM_DAL.Data.UserGroupMaster_Data.get_user_group_master_all(UGMall);
        }

        public static List<ReturUserGroupMasterModelHead> get_user_group_master(GetUGMSingleModel UGMall)
        {
            return HRM_DAL.Data.UserGroupMaster_Data.get_user_group_master(UGMall);
        }

        public static UserGroupDto modify_user_group_master(Get_UserGroups_ResponceModel item)
        {
            return HRM_DAL.Data.UserGroupMaster_Data.modify_user_group_master(item);
        }

        public static UserGroupDto add_new_user_group_master(Get_UserGroups_ResponceModel item)
        {
            return HRM_DAL.Data.UserGroupMaster_Data.add_new_user_group_master(item);
        }
    }
}








