using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class EmployeeSalary_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnEmployeeSalaryModelHead> get_EmployeeSalary_single(EmployeeSalary model)//ok
        {
            return HRM_DAL.Data.EmployeeSalary_Data.get_EmployeeSalary_single(model);
        }
        public static List<ReturnEmployeeSalaryModelHead> get_EmployeeSalary_all(EmployeeSalarySearchModel model)//ok
        {
            return HRM_DAL.Data.EmployeeSalary_Data.get_EmployeeSalary_all(model);
        }


        public static List<ReturnResponse> add_new_EmployeeSalary(EmployeeSalaryModel item)//ok
        {
            return HRM_DAL.Data.EmployeeSalary_Data.add_new_EmployeeSalary(item);
        }

        public static List<ReturnResponse> modify_EmployeeSalary(EmployeeSalaryModel item)//ok
        {
            return HRM_DAL.Data.EmployeeSalary_Data.modify_EmployeeSalary(item);
        }

        public static List<ReturnResponse> inactivate_EmployeeSalary(InactiveEESModel item)//ok
        {
            return HRM_DAL.Data.EmployeeSalary_Data.inactivate_EmployeeSalary(item);
        }


    }

}

