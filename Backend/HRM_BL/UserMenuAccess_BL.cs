using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class UserMenuAccess_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnUserMenuAccessModelHead> get_UserMenuAccesss_single(UserMenuAccess model)//ok
        {
            return HRM_DAL.Data.UserMenuAccess_Data.get_UserMenuAccesss_single(model);
        }
        public static List<ReturnUserMenuAccessModelHead> get_UserMenuAccess_all(UserMenuAccessSearchModel model)//ok
        {
            return HRM_DAL.Data.UserMenuAccess_Data.get_UserMenuAccess_all(model);
        }


        public static List<ReturncustResponse> add_new_UserMenuAccess(UserMenuAccessModel item)//ok
        {
            return HRM_DAL.Data.UserMenuAccess_Data.add_new_UserMenuAccess(item);
        }

        public static List<ReturncustResponse> modify_UserMenuAccess(UserMenuAccessModel item)//ok
        {
            return HRM_DAL.Data.UserMenuAccess_Data.modify_UserMenuAccess(item);
        }

        public static List<ReturnResponse> inactivate_UserMenuAccess(InactiveUUMAModel item)//ok
        {
            return HRM_DAL.Data.UserMenuAccess_Data.inactivate_UserMenuAccess(item);
        }


    }

}

