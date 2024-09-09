using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class PerformanceAppriasalApproval_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnPerformanceAppriasalApprovalModelHead> get_PerformanceAppriasalApprovals_single(PerformanceAppriasalApproval model)//ok
        {
            return HRM_DAL.Data.PerformanceAppriasalApproval_Data.get_PerformanceAppriasalApprovals_single(model);
        }
        public static List<ReturnPerformanceAppriasalApprovalModelHead> get_PerformanceAppriasalApproval_all(PerformanceAppriasalApprovalSearchModel model)//ok
        {
            return HRM_DAL.Data.PerformanceAppriasalApproval_Data.get_PerformanceAppriasalApproval_all(model);
        }

        public static List<ReturncustResponse> add_new_PerformanceAppriasalApproval(PerformanceAppriasalApprovalModel item)//ok
        {
            return HRM_DAL.Data.PerformanceAppriasalApproval_Data.add_new_PerformanceAppriasalApproval(item);
        }

        public static List<ReturncustResponse> modify_PerformanceAppriasalApproval(PerformanceAppriasalApprovalModel item)//ok
        {
            return HRM_DAL.Data.PerformanceAppriasalApproval_Data.modify_PerformanceAppriasalApproval(item);
        }

        public static List<ReturnResponse> inactivate_PerformanceAppriasalApproval(InactivePAAPModel item)//ok
        {
            return HRM_DAL.Data.PerformanceAppriasalApproval_Data.inactivate_PerformanceAppriasalApproval(item);
        }


    }

}

