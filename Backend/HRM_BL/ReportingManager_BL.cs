using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class ReportingManager_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnReportingManagerModelHead> get_ReportingManager_single(ReportingManager model)//ok
        {
            return HRM_DAL.Data.ReportingManager_Data.get_ReportingManager_single(model);
        }
        public static List<ReturnReportingManagerModelHead> get_ReportingManager_all(ReportingManagerSearchModel model)//ok
        {
            return HRM_DAL.Data.ReportingManager_Data.get_ReportingManager_all(model);
        }


        public static List<ReturncustResponse> add_new_ReportingManager(ReportingManagerModel item)//ok
        {
            return HRM_DAL.Data.ReportingManager_Data.add_new_ReportingManager(item);
        }

        public static List<ReturncustResponse> modify_ReportingManager(ReportingManagerModel item)//ok
        {
            return HRM_DAL.Data.ReportingManager_Data.modify_ReportingManager(item);
        }

        public static List<ReturnResponse> inactivate_ReportingManager(InactiveRMModel item)//ok
        {
            return HRM_DAL.Data.ReportingManager_Data.inactivate_ReportingManager(item);
        }


    }

}

