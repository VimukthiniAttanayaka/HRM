using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System;
using HRM_DAL.Data;

namespace HRM_BL
{
    public class DashboardBL
    {
        private static LogError objError = new LogError();

        public static ProgressGraphReturnResponseModel ProgressGraph(DashboardRequestModel model)
        {
            return new ProgressGraphReturnResponseModel();// Dashboard_Data.ProgressGraph(model);
        }
    }
}