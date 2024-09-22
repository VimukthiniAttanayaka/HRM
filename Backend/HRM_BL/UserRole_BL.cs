using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System;

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


        public static List<ReturnResponse> add_new_UserRole(UserRoleModel item)//ok
        {
            return HRM_DAL.Data.UserRole_Data.add_new_UserRole(item);
        }

        public static List<ReturnResponse> modify_UserRole(UserRoleModel item)//ok
        {
            return HRM_DAL.Data.UserRole_Data.modify_UserRole(item);
        }

        public static List<ReturnResponse> inactivate_UserRole(InactiveUURModel item)//ok
        {
            return HRM_DAL.Data.UserRole_Data.inactivate_UserRole(item);
        }

        public static List<ReturnAccessGroupModelHead> get_AccessGroup_all_ForUserRole(UserRoleSearchModel model)
        {
            return HRM_DAL.Data.UserRole_Data.get_AccessGroup_all_ForUserRole(model);
        }

        public static List<ReturnResponse> RemoveAccess(GrantRemoveAccessModel item)
        {
            return HRM_DAL.Data.UserRole_Data.RemoveAccess(item);
        }

        public static List<ReturnResponse> GrantAccess(GrantRemoveAccessModel item)
        {
            return HRM_DAL.Data.UserRole_Data.GrantAccess(item);
        }
    }

}

