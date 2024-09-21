using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class UserMenu_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnUserMenuModelHead> get_UserMenus_single(UserMenu model)//ok
        {
            return HRM_DAL.Data.UserMenu_Data.get_UserMenus_single(model);
        }
        public static List<ReturnUserMenuModelHead> get_UserMenu_all(UserMenuSearchModel model)//ok
        {
            return HRM_DAL.Data.UserMenu_Data.get_UserMenu_all(model);
        }


        public static List<ReturnResponse> add_new_UserMenu(UserMenuModel item)//ok
        {
            return HRM_DAL.Data.UserMenu_Data.add_new_UserMenu(item);
        }

        public static List<ReturnResponse> modify_UserMenu(UserMenuModel item)//ok
        {
            return HRM_DAL.Data.UserMenu_Data.modify_UserMenu(item);
        }

        public static List<ReturnResponse> inactivate_UserMenu(InactiveUUMModel item)//ok
        {
            return HRM_DAL.Data.UserMenu_Data.inactivate_UserMenu(item);
        }


    }

}

