using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class EmployeeTermination_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnEmployeeTerminationModelHead> get_EmployeeTermination_single(EmployeeTermination model)//ok
        {
            return HRM_DAL.Data.EmployeeTermination_Data.get_EmployeeTermination_single(model);
        }
        public static List<ReturnEmployeeTerminationModelHead> get_EmployeeTermination_all(EmployeeTerminationSearchModel model)//ok
        {
            return HRM_DAL.Data.EmployeeTermination_Data.get_EmployeeTermination_all(model);
        }


        public static List<ReturnResponse> add_new_EmployeeTermination(EmployeeTerminationModel item)//ok
        {
            return HRM_DAL.Data.EmployeeTermination_Data.add_new_EmployeeTermination(item);
        }

        public static List<ReturnResponse> modify_EmployeeTermination(EmployeeTerminationModel item)//ok
        {
            return HRM_DAL.Data.EmployeeTermination_Data.modify_EmployeeTermination(item);
        }

        public static List<ReturnResponse> inactivate_EmployeeTermination(InactiveEETModel item)//ok
        {
            return HRM_DAL.Data.EmployeeTermination_Data.inactivate_EmployeeTermination(item);
        }


    }

}

