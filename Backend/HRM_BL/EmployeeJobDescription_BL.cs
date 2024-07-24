using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class EmployeeJobDescription_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnEmployeeJobDescriptionModelHead> get_EmployeeJobDescriptions_single(EmployeeJobDescription model)//ok
        {
            return HRM_DAL.Data.EmployeeJobDescription_Data.get_EmployeeJobDescriptions_single(model);
        }
        public static List<ReturnEmployeeJobDescriptionModelHead> get_EmployeeJobDescription_all(EmployeeJobDescriptionSearchModel model)//ok
        {
            return HRM_DAL.Data.EmployeeJobDescription_Data.get_EmployeeJobDescription_all(model);
        }


        public static List<ReturncustResponse> add_new_EmployeeJobDescription(EmployeeJobDescriptionModel item)//ok
        {
            return HRM_DAL.Data.EmployeeJobDescription_Data.add_new_EmployeeJobDescription(item);
        }

        public static List<ReturncustResponse> modify_EmployeeJobDescription(EmployeeJobDescriptionModel item)//ok
        {
            return HRM_DAL.Data.EmployeeJobDescription_Data.modify_EmployeeJobDescription(item);
        }

        public static List<ReturnResponse> inactivate_EmployeeJobDescription(InactiveEEJModel item)//ok
        {
            return HRM_DAL.Data.EmployeeJobDescription_Data.inactivate_EmployeeJobDescription(item);
        }


    }

}

