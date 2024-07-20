using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System;

namespace HRM_BL
{
    public class LeaveSchedule_BL
    {
        private static LogError objError = new LogError();

        public static List<LeaveHeaderResponceModel> get_leave_details(LeaveRequestModel item)
        {
            return HRM_DAL.Data.LeaveSchedule_Data.get_leave_details(item);
        }

        public static List<LeaveGridViewHeaderModel> get_leave_grid_details(LeaveGridRequestModel gridmodel)
        {
            return HRM_DAL.Data.LeaveSchedule_Data.get_leave_grid_details(gridmodel);
        }

        public static List<LeaveSubmitResponceModel> applyleave(LeaveSubmitModel model)
        {
            return HRM_DAL.Data.LeaveSchedule_Data.applyleave(model);
        }

        public static List<LeaveSubmitResponceModel> cancelleave(LeaveCancelSubmitModel model)
        {
            return HRM_DAL.Data.LeaveSchedule_Data.cancelleave(model);
        }

        public static List<LeaveSubmitResponceModel> approveleave(LeaveApproveSubmitModel model)
        {
            return HRM_DAL.Data.LeaveSchedule_Data.approveleave(model);
        }

    }
}