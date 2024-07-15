using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class Attendance_BL
    {
        private static LogError objError = new LogError();

        public static List<AttendanceSubmitResponceModel> modify_Attendance(AttendanceGridSubmitModel item)
        {
            return HRM_DAL.Data.Attendance_Data.modify_Attendance(item);
        }

        public static List<AttendanceSubmitResponceModel> get_Attendance_details(AttendanceRequestModel item)
        {
            return HRM_DAL.Data.Attendance_Data.get_Attendance_details(item);
        }

        public static List<AttendanceGridViewHeaderModel> get_Attendance_grid_details(AttendanceGridRequestModel gridmodel)
        {
            return HRM_DAL.Data.Attendance_Data.get_Attendance_grid_details(gridmodel);
        }
        public static List<AttendanceSubmitResponceModel> AttendancePunch_Marker(AttendancePunch_MarkerSubmitModel gridmodel)
        {
            return HRM_DAL.Data.Attendance_Data.AttendancePunch_Marker(gridmodel);
        }
        public static List<AttendanceSubmitResponceModel> AttendancePunch_Mobile(AttendancePunch_MobileSubmitModel gridmodel)
        {
            return HRM_DAL.Data.Attendance_Data.AttendancePunch_Mobile(gridmodel);
        }
    }
}