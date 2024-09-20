using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System;
using HRM_DAL.Models.ResponceModels;

namespace HRM_BL
{
    public class ExternalUser_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnExternalUserModelHead> get_user_external_single(GetExternalUserSingleModel CUser) //ok
        {
            return HRM_DAL.Data.ExternalUser_Data.get_user_external_single(CUser);
        }
        public static List<ReturnExternalUserAllModelHead> get_user_external_all(GetUserAllModel CUserall)//ok
        {
            return HRM_DAL.Data.ExternalUser_Data.get_user_external_all(CUserall);
        }

        public static List<ReturnResponse> inactivate_user_external(InactiveUserModel item)//ok
        {
            return  HRM_DAL.Data.ExternalUser_Data.inactivate_user_external(item);
        }

        public static List<ReturnResponse> add_new_user_external(ExternalUserModel item)//ok
        {
            return HRM_DAL.Data.ExternalUser_Data.add_new_user_external(item);
        }

        public static List<ReturnResponse> modify_user_external(ExternalUserModel item)//ok
        {
            return HRM_DAL.Data.ExternalUser_Data.modify_user_external(item);
        }
      
    }

}

