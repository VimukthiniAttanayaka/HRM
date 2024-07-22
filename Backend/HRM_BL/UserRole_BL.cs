using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class UserRole_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnUserRoleModelHead> get_UserRoles_single(UserRole model)//ok
        {
            return HRM_DAL.Data.UserRole_Data.get_UserRoles_single(model);
        }
        public static List<ReturnUserRoleModelHead> get_UserRole_all(UserRoleSearchModel model)//ok
        {
            return HRM_DAL.Data.UserRole_Data.get_UserRole_all(model);
        }


        public static List<ReturncustResponse> add_new_UserRole(UserRoleModel item)//ok
        {
            return HRM_DAL.Data.UserRole_Data.add_new_UserRole(item);
        }

        public static List<ReturncustResponse> modify_UserRole(UserRoleModel item)//ok
        {
            return HRM_DAL.Data.UserRole_Data.modify_UserRole(item);
        }

        public static List<ReturnResponse> inactivate_UserRole(InactiveEURModel item)//ok
        {
            return HRM_DAL.Data.UserRole_Data.inactivate_UserRole(item);
        }


    }

}

