using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System;

namespace HRM_BL
{
    public class UserAccessGroup_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnUAGAllModelHead> get_t_user_access_group_all(GetUAGAllModel all)
        {
            return HRM_DAL.Data.UserAccessGroup_Data.get_t_user_access_group_all(all);
        }

        //public static List<ReturnResponse> add_new_t_user_access_group(UAGModel item)
        //{
        //    return HRM_DAL.Data.UserAccessGroup_Data.add_new_t_user_access_group(item);
        //}

        //public static List<ReturnResponse> inactivate_t_user_access_group(UAGModel item)
        //{
        //    return HRM_DAL.Data.UserAccessGroup_Data.inactivate_t_user_access_group(item);
        //}

        public static List<ReturnUAGUsrAllModelHead> get_c_user_access_group_all(GetUAGUsrAllModel all)
        {
            return HRM_DAL.Data.UserAccessGroup_Data.get_c_user_access_group_all(all);
        }

        //public static List<ReturnResponse> add_new_c_user_access_group(UAGUsrModel item)
        //{
        //    return HRM_DAL.Data.UserAccessGroup_Data.add_new_c_user_access_group(item);
        //}

        //public static List<ReturnResponse> inactivate_c_user_access_group(UAGUsrModel item)
        //{
        //    return HRM_DAL.Data.UserAccessGroup_Data.inactivate_c_user_access_group(item);
        //}

        public static List<ReturnUAGAllModelHead> get_t_user_access_group_single(GetUAGSingleModel item)
        {
            return HRM_DAL.Data.UserAccessGroup_Data.get_t_user_access_group_single(item);
        }

        public static List<ReturnUAGUsrAllModelHead> get_c_user_access_group_single(GetUAGSingleModel item)
        {
            return HRM_DAL.Data.UserAccessGroup_Data.get_c_user_access_group_single(item);
        }

        public static List<ReturnUAGAllModelHead> get_t_user_access_group_multiple(GetUAGSingleModel item)
        {
            return HRM_DAL.Data.UserAccessGroup_Data.get_t_user_access_group_multiple(item);
        }

        public static List<ReturnUAGUsrAllModelHead> get_c_user_access_group_multiple(GetUAGSingleModel item)
        {
            return HRM_DAL.Data.UserAccessGroup_Data.get_c_user_access_group_multiple(item);
        }

        public static List<ReturnUAGUsrAllModelHead> get_customer_user_access_group_multiple(GetUAGSingleModel item)
        {
            return HRM_DAL.Data.UserAccessGroup_Data.get_customer_user_access_group_multiple(item);
        }

        public static List<ReturnUAGAllModelHead> get_transnational_user_access_group_multiple(GetUAGSingleModel item)
        {
            return HRM_DAL.Data.UserAccessGroup_Data.get_transnational_user_access_group_multiple(item);
        }

        //public static List<ReturnResponse> modify_c_user_access_group(UAGModel item)
        //{
        //    return HRM_DAL.Data.UserAccessGroup_Data.modify_c_user_access_group(item);
        //}

        //public static List<ReturnResponse> modify_t_user_access_group(UAGModel item)
        //{
        //    return HRM_DAL.Data.UserAccessGroup_Data.modify_t_user_access_group(item);
        //}

        //public static List<ReturnResponse> add_new_sk_user_access_group(UAGUsrModel item)
        //{
        //    return HRM_DAL.Data.UserAccessGroup_Data.add_new_sk_user_access_group(item);
        //}

        //public static List<ReturnResponse> inactivate_sk_user_access_group(UAGUsrModel item)
        //{
        //    return HRM_DAL.Data.UserAccessGroup_Data.inactivate_sk_user_access_group(item);
        //}

        public static List<ReturnResponse> modify_sk_user_access_group(UAGUsrModel item)
        {
            return HRM_DAL.Data.UserAccessGroup_Data.modify_sk_user_access_group(item);
        }
    }
}








