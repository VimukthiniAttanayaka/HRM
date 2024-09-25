using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System;

namespace HRM_BL
{
    public class EmployeeDocument_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> upload_employee_documents(List<EmployeeDocumentModel> item)//ok
        {
            return HRM_DAL.Data.EmployeeDocument_Data.upload_employee_documents(item);
        }

        public static List<ReturnEmployeeDocumentModelHead> get_employeeDocument_all(EmployeeDocumentSearchModel model)//ok
        {
            return HRM_DAL.Data.EmployeeDocument_Data.get_employeeDocument_all(model);
        }

        public static List<ReturnEmployeeDocumentModelHead> get_employeeDocument_single(EmployeeDocument model)//ok
        {
            return HRM_DAL.Data.EmployeeDocument_Data.get_employeeDocument_single(model);
        }

        public static List<ReturnResponse> add_new_employeedocument(EmployeeDocumentModel item)
        {
            return HRM_DAL.Data.EmployeeDocument_Data.add_new_employeedocument(item);
        }

        //public static List<ReturnResponse> modify_employeedocument(EmployeeDocumentModel item)
        //{
        //    return HRM_DAL.Data.EmployeeDocument_Data.modify_employeedocument(item);
        //}

        public static List<ReturnResponse> inactivate_employeedocument(InactiveEEDModel item)
        {
            return HRM_DAL.Data.EmployeeDocument_Data.inactivate_employeedocument(item);
        }
    }

}

