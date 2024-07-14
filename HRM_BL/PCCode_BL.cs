using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System;

namespace HRM_BL
{
    public class PCCode_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturPCCodeModelHead> get_PCCode_all(GetPCCodeAllModel item)//ok
        {
            return HRM_DAL.Data.PCCode_Data.get_PCCode_all(item);
        }

    public static List<ReturPCCodeDistinctModelHead> get_PCCode_all_Distinct(GetPCCodeAllModel item)//ok
        {
            return HRM_DAL.Data.PCCode_Data.get_PCCode_all_Distinct(item);
        }

        public static List<ReturPCCodeModelHead> get_PCCode_single(GetPCCodeSingleModel item)
        {
            return HRM_DAL.Data.PCCode_Data.get_PCCode_single(item);
        }

        public static List<ReturPCCodeModelHead> get_PCCode_By_Department(GetPCCodeDepartmentModel item)
        {
            return HRM_DAL.Data.PCCode_Data.get_PCCode_By_Department(item);
        }

        public static List<ReturPCCodeModelHead> get_PCCode_By_Department_Customer(GetPCCodeDepartmentModel item)
        {
            return HRM_DAL.Data.PCCode_Data.get_PCCode_By_Department_Customer(item);
        }
    }








}








