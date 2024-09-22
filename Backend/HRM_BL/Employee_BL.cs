using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class Employee_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnEmployeeModelHead> get_employees_single(Employee model)//ok
        {
            return HRM_DAL.Data.Employee_Data.get_employees_single(model);
        }
        public static List<ReturnEmployeeModelHead> get_employee_all(EmployeeSearchModel model)//ok
        {
            return HRM_DAL.Data.Employee_Data.get_employee_all(model);
        }


        public static List<ReturnResponse> add_new_employee(EmployeeModel item)//ok
        {
            return HRM_DAL.Data.Employee_Data.add_new_employee(item);
        }
        public static List<ReturnResponse> upload_employee_documents(List<EmployeeAttachmentModel> item)//ok
        {
            return HRM_DAL.Data.Employee_Data.upload_employee_documents(item);
        }
        public static List<EmployeeAttachmentModel> get_employeeDocument_all(EmployeeSearchModel model)//ok
        {
            return HRM_DAL.Data.Employee_Data.get_employeeDocument_all(model);
        }
        public static List<ReturnResponse> modify_employee(EmployeeModel item)//ok
        {
            return HRM_DAL.Data.Employee_Data.modify_employee(item);
        }

        public static List<ReturnResponse> inactivate_employee(InactiveEmpModel item)//ok
        {
            return HRM_DAL.Data.Employee_Data.inactivate_employee(item);
        }


    }

}

