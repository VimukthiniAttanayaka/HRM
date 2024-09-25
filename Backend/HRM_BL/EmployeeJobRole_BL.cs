using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class EmployeeJobRole_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnEmployeeJobRoleModelHead> get_EmployeeJobRole_single(EmployeeJobRole model)//ok
        {
            return HRM_DAL.Data.EmployeeJobRole_Data.get_EmployeeJobRole_single(model);
        }
        public static List<ReturnEmployeeJobRoleModelHead> get_EmployeeJobRole_all(EmployeeJobRoleSearchModel model)//ok
        {
            return HRM_DAL.Data.EmployeeJobRole_Data.get_EmployeeJobRole_all(model);
        }


        public static List<ReturnResponse> add_new_EmployeeJobRole(EmployeeJobRoleModel item)//ok
        {
            return HRM_DAL.Data.EmployeeJobRole_Data.add_new_EmployeeJobRole(item);
        }

        public static List<ReturnResponse> modify_EmployeeJobRole(EmployeeJobRoleModel item)//ok
        {
            return HRM_DAL.Data.EmployeeJobRole_Data.modify_EmployeeJobRole(item);
        }

        public static List<ReturnResponse> inactivate_EmployeeJobRole(InactiveEEJRModel item)//ok
        {
            return HRM_DAL.Data.EmployeeJobRole_Data.inactivate_EmployeeJobRole(item);
        }


    }

}

