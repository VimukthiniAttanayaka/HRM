using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System;

namespace HRM_BL
{
    public class MailType_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_mail_type(MailTypeModel item)//ok
        {
            return HRM_DAL.Data.MailType_Data.add_new_mail_type(item);
        }

        public static List<ReturnResponse> modify_mail_type(MailTypeModel item)//ok
        {
            return HRM_DAL.Data.MailType_Data.modify_mail_type(item);
        }

        public static List<ReturnResponse> inactivate_mail_type(InactiveMailTypeModel item)//ok
        {
            return HRM_DAL.Data.MailType_Data.inactivate_mail_type(item);
        }

        public static List<ReturMailTypeModelHead> get_mail_type_single(GetMtsingleModel MTingle)
        {
            return HRM_DAL.Data.MailType_Data.get_mail_type_single(MTingle);
        }

        public static List<ReturMailTypeModelHead> get_mail_type_all(GetMtAllModel MTall)
        {
            return HRM_DAL.Data.MailType_Data.get_mail_type_all(MTall);
        }

    }
}








