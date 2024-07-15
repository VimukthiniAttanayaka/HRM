﻿using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System;
using HRM_DAL.Data;

namespace HRM_BL
{
    public class Department_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_department(DepartmentModel item)//ok
        {
            return HRM_DAL.Data.Department_Data.add_new_department(item);
        }

        public static List<ReturnResponse> modify_department(DepartmentModel item)//ok
        {
            return HRM_DAL.Data.Department_Data.modify_department(item);
        }

        public static List<ReturnResponse> inactivate_department(InactiveDepartmentModel item)//ok
        {
            return HRM_DAL.Data.Department_Data.inactivate_department(item);
        }

        public static List<ReturDepartmentModelHead> get_department_all(GetDepartmentAllModel item)//ok
        {
            return HRM_DAL.Data.Department_Data.get_department_all(item);
        }

        public static List<ReturDepartmentModelHead> get_department_single(GetDepartmentSingleModel item)
        {
            return HRM_DAL.Data.Department_Data.get_department_single(item);
        }

    }
}