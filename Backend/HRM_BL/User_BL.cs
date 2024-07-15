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
    public class user_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnCustomerUserModelHead> get_user_single(GetUserSingleModel CUser) //ok
        {
            return HRM_DAL.Data.User_Data.get_user_single(CUser);
        }

        public static List<ReturnCustomerUserAllModelHead> get_user_all(GetCustomerUserAllModel CUserall)//ok
        {
            return HRM_DAL.Data.User_Data.get_user_all(CUserall);
        }

        public static List<ReturnCustomerUserAllModelHead> get_user_all_unique(GetCustomerUserAllModel CUserall)//ok
        {
            return HRM_DAL.Data.User_Data.get_user_all_unique(CUserall);
        }

        public static List<ReturnResponse> inactivate_user(InactiveCUserModel item)//ok
        {
            return HRM_DAL.Data.User_Data.inactivate_user(item);
        }

        public static List<ReturnLoadUserDataModel> load_user_data()//ok
        {
            return HRM_DAL.Data.User_Data.load_user_data();
        }

        public static List<ReturnResponse> add_new_user(CUserModel item)//ok
        {
            return HRM_DAL.Data.User_Data.add_new_user(item);
        }

        public static List<ReturnResponse> modify_user(CUserModel item)//ok
        {
            return HRM_DAL.Data.User_Data.modify_user(item);
        }

        public static List<ReturnResponse> change_password(NewpwModel item)
        {
            return HRM_DAL.Data.User_Data.change_password(item);
        }

        public static List<ReturnResponse> update_notification_token(NotificationTokenModel UpNotTokModel, string userId)
        {
            return HRM_DAL.Data.User_Data.update_notification_token(UpNotTokModel, userId);
        }

        public static List<ReturnResponse> reset_password(ResetPasswordModel resetPassword, string baseUrl)
        {
            return HRM_DAL.Data.User_Data.reset_password(resetPassword, baseUrl);
        }

        public static string change_password_by_email(int userId, string email, string verificationCode)
        {
            return HRM_DAL.Data.User_Data.change_password_by_email(userId, email, verificationCode);
        }

    }

}

