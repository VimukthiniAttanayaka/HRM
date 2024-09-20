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
    public class InternalUser_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnInternalUserModelHead> get_user_internal_single(GetInternalUserSingleModel CUser) //ok
        {
            return HRM_DAL.Data.InternalUser_Data.get_user_internal_single(CUser);
        }
     
        public static List<ReturnInternalUserAllModelHead> get_user_internal_all(GetUserAllModel CUserall)//ok
        {
            return HRM_DAL.Data.InternalUser_Data.get_user_internal_all(CUserall);
        }

        public static List<ReturnResponse> inactivate_user_internal(InactiveUserModel item)//ok
        {
            return HRM_DAL.Data.InternalUser_Data.inactivate_user_internal(item);
        }

        public static List<ReturnResponse> add_new_user_internal(InternalUserModel item)//ok
        {
            return HRM_DAL.Data.InternalUser_Data.add_new_user_internal(item);
        }

        public static List<ReturnResponse> modify_internal_user(InternalUserModel item)//ok
        {
            return HRM_DAL.Data.InternalUser_Data.modify_internal_user(item);
        }
    }

}

