using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class MenuAccess_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnMenuAccessModelHead> get_MenuAccesss_single(MenuAccess model)//ok
        {
            return HRM_DAL.Data.MenuAccess_Data.get_MenuAccesss_single(model);
        }
        public static List<ReturnMenuAccessModelHead> get_MenuAccess_all(MenuAccessSearchModel model)//ok
        {
            return HRM_DAL.Data.MenuAccess_Data.get_MenuAccess_all(model);
        }


        public static List<ReturncustResponse> add_new_MenuAccess(MenuAccessModel item)//ok
        {
            return HRM_DAL.Data.MenuAccess_Data.add_new_MenuAccess(item);
        }

        public static List<ReturncustResponse> modify_MenuAccess(MenuAccessModel item)//ok
        {
            return HRM_DAL.Data.MenuAccess_Data.modify_MenuAccess(item);
        }

        public static List<ReturnResponse> inactivate_MenuAccess(InactiveUMAModel item)//ok
        {
            return HRM_DAL.Data.MenuAccess_Data.inactivate_MenuAccess(item);
        }


    }

}

