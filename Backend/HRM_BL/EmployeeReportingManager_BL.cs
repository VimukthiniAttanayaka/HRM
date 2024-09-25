﻿using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class EmployeeReportingManager_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnEmployeeReportingManagerModelHead> get_EmployeeReportingManagers_single(EmployeeReportingManager model)//ok
        {
            return HRM_DAL.Data.EmployeeReportingManager_Data.get_EmployeeReportingManagers_single(model);
        }
        public static List<ReturnEmployeeReportingManagerModelHead> get_EmployeeReportingManager_all(EmployeeReportingManagerSearchModel model)//ok
        {
            return HRM_DAL.Data.EmployeeReportingManager_Data.get_EmployeeReportingManager_all(model);
        }


        public static List<ReturnResponse> add_new_EmployeeReportingManager(EmployeeReportingManagerModel item)//ok
        {
            return HRM_DAL.Data.EmployeeReportingManager_Data.add_new_EmployeeReportingManager(item);
        }

        public static List<ReturnResponse> modify_EmployeeReportingManager(EmployeeReportingManagerModel item)//ok
        {
            return HRM_DAL.Data.EmployeeReportingManager_Data.modify_EmployeeReportingManager(item);
        }

        public static List<ReturnResponse> inactivate_EmployeeReportingManager(InactiveEERMModel item)//ok
        {
            return HRM_DAL.Data.EmployeeReportingManager_Data.inactivate_EmployeeReportingManager(item);
        }


    }

}

