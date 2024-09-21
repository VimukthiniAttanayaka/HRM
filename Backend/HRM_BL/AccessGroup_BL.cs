using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class AccessGroup_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnAccessGroupModelHead> get_AccessGroups_single(AccessGroup model)//ok
        {
            return HRM_DAL.Data.AccessGroup_Data.get_AccessGroups_single(model);
        }
        public static List<ReturnAccessGroupModelHead> get_AccessGroup_all(AccessGroupSearchModel model)//ok
        {
            return HRM_DAL.Data.AccessGroup_Data.get_AccessGroup_all(model);
        }


        public static List<ReturnResponse> add_new_AccessGroup(AccessGroupModel item)//ok
        {
            return HRM_DAL.Data.AccessGroup_Data.add_new_AccessGroup(item);
        }

        public static List<ReturnResponse> modify_AccessGroup(AccessGroupModel item)//ok
        {
            return HRM_DAL.Data.AccessGroup_Data.modify_AccessGroup(item);
        }

        public static List<ReturnResponse> inactivate_AccessGroup(InactiveEUGModel item)//ok
        {
            return HRM_DAL.Data.AccessGroup_Data.inactivate_AccessGroup(item);
        }


    }

}

