using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class EmployeeContact_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnEmployeeContactModelHead> get_EmployeeContact_single(EmployeeContact model)//ok
        {
            return HRM_DAL.Data.EmployeeContact_Data.get_EmployeeContact_single(model);
        }
        public static List<ReturnEmployeeContactModelHead> get_EmployeeContact_all(EmployeeContactSearchModel model)//ok
        {
            return HRM_DAL.Data.EmployeeContact_Data.get_EmployeeContact_all(model);
        }


        public static List<ReturnResponse> add_new_EmployeeContact(EmployeeContactModel item)//ok
        {
            return HRM_DAL.Data.EmployeeContact_Data.add_new_EmployeeContact(item);
        }

        public static List<ReturnResponse> modify_EmployeeContact(EmployeeContactModel item)//ok
        {
            return HRM_DAL.Data.EmployeeContact_Data.modify_EmployeeContact(item);
        }

        public static List<ReturnResponse> inactivate_EmployeeContact(InactiveEECModel item)//ok
        {
            return HRM_DAL.Data.EmployeeContact_Data.inactivate_EmployeeContact(item);
        }


    }

}

