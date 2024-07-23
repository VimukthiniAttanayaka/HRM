using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class UserAccessGroup_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnUserAccessGroupModelHead> get_UserAccessGroups_single(UserAccessGroup model)//ok
        {
            return HRM_DAL.Data.UserAccessGroup_Data.get_UserAccessGroups_single(model);
        }
        public static List<ReturnUserAccessGroupModelHead> get_UserAccessGroup_all(UserAccessGroupSearchModel model)//ok
        {
            return HRM_DAL.Data.UserAccessGroup_Data.get_UserAccessGroup_all(model);
        }


        public static List<ReturncustResponse> add_new_UserAccessGroup(UserAccessGroupModel item)//ok
        {
            return HRM_DAL.Data.UserAccessGroup_Data.add_new_UserAccessGroup(item);
        }

        public static List<ReturncustResponse> modify_UserAccessGroup(UserAccessGroupModel item)//ok
        {
            return HRM_DAL.Data.UserAccessGroup_Data.modify_UserAccessGroup(item);
        }

        public static List<ReturnResponse> inactivate_UserAccessGroup(InactiveUUMAModel item)//ok
        {
            return HRM_DAL.Data.UserAccessGroup_Data.inactivate_UserAccessGroup(item);
        }


    }

}

