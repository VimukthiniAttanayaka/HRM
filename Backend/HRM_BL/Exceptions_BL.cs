using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System;

namespace HRM_BL
{
    public class Exceptions_BL
    {
        private static LogError objError = new LogError();

        public static List<ExceptionsHeaderResponceModel> modify_exceptions(ExceptionsSubmitModel item)
        {
            return HRM_DAL.Data.Exceptions_Data.modify_exceptions(item);
        }

        public static List<ExceptionsHeaderResponceModel> get_exceptions_details(ExceptionsRequestModel item)
        {
            return HRM_DAL.Data.Exceptions_Data.get_exceptions_details(item);
        }

        public static List<ExceptionsGridViewHeaderModel> get_exceptions_grid_details(ExceptionsGridRequestModel gridmodel)
        {
            return HRM_DAL.Data.Exceptions_Data.get_exceptions_grid_details(gridmodel);
        }

        public static List<ExceptionsStatusHeaderResponceModel> modify_exceptionstatus(ExceptionsStatusSubmitModel item)
        {
            return HRM_DAL.Data.Exceptions_Data.modify_exceptionstatus(item);
        }
    }
}