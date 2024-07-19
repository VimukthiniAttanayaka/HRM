using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class LeaveType_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnLeaveTypeModelHead> get_LeaveTypes_single(LeaveType model)//ok
        {
            return HRM_DAL.Data.LeaveType_Data.get_LeaveTypes_single(model);
        }
        public static List<ReturnLeaveTypeModelHead> get_LeaveType_all(LeaveTypeSearchModel model)//ok
        {
            return HRM_DAL.Data.LeaveType_Data.get_LeaveType_all(model);
        }


        public static List<ReturncustResponse> add_new_LeaveType(LeaveTypeModel item)//ok
        {
            return HRM_DAL.Data.LeaveType_Data.add_new_LeaveType(item);
        }

        public static List<ReturncustResponse> modify_LeaveType(LeaveTypeModel item)//ok
        {
            return HRM_DAL.Data.LeaveType_Data.modify_LeaveType(item);
        }

        public static List<ReturnResponse> inactivate_LeaveType(InactiveLVTModel item)//ok
        {
            return HRM_DAL.Data.LeaveType_Data.inactivate_LeaveType(item);
        }


    }

}

