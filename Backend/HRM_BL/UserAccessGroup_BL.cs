using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class UserRoleAccessGroup_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnUserRoleAccessGroupModelHead> get_UserRoleAccessGroups_single(UserRoleAccessGroup model)//ok
        {
            return HRM_DAL.Data.UserRoleAccessGroup_Data.get_UserRoleAccessGroups_single(model);
        }
        public static List<ReturnUserRoleAccessGroupModelHead> get_UserRoleAccessGroup_all(UserRoleAccessGroupSearchModel model)//ok
        {
            return HRM_DAL.Data.UserRoleAccessGroup_Data.get_UserRoleAccessGroup_all(model);
        }


        public static List<ReturncustResponse> add_new_UserRoleAccessGroup(UserRoleAccessGroupModel item)//ok
        {
            return HRM_DAL.Data.UserRoleAccessGroup_Data.add_new_UserRoleAccessGroup(item);
        }

        public static List<ReturncustResponse> modify_UserRoleAccessGroup(UserRoleAccessGroupModel item)//ok
        {
            return HRM_DAL.Data.UserRoleAccessGroup_Data.modify_UserRoleAccessGroup(item);
        }

        public static List<ReturnResponse> inactivate_UserRoleAccessGroup(InactiveUUMAModel item)//ok
        {
            return HRM_DAL.Data.UserRoleAccessGroup_Data.inactivate_UserRoleAccessGroup(item);
        }


    }

}

