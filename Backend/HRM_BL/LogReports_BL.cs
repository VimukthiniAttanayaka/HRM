using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using HRM_DAL.Data;

namespace HRM_BL
{
    public class LogReports_BL
    {
        private LogError objError = new LogError();

        public static List<ReturnUserLogReportsModelHead> get_UserLogReport(RequestUserLog model)//ok
        {
            return HRM_DAL.Data.LogReports_Data.get_UserLogReport(model);
        }

        public static List<ReturnErrorLogReportsModelHead> get_ErrorLogReport(RequestErrorLog model)//ok
        {
            return HRM_DAL.Data.LogReports_Data.get_ErrorLogReport(model);
        }

        public static List<ReturnAuditLogReportsModelHead> get_AuditLogReport(RequestAuditLog model)//ok
        {
            return HRM_DAL.Data.LogReports_Data.get_AuditLogReport(model);
        }
    }
}
