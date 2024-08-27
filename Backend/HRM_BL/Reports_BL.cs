using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using HRM_DAL.Data;

namespace HRM_BL
{
    public class Reports_BL
    {
        private LogError objError = new LogError();

        public static List<ReturnAttendanceReportsModelHead> get_AttendanceReport(RequestAttendance model)//ok
        {
            return HRM_DAL.Data.Reports_Data.get_AttendanceReport(model);
        }

        public static List<ReturnBirthdayReportsModelHead> get_BirthdayReport(RequestBirthday model)//ok
        {
            return HRM_DAL.Data.Reports_Data.get_BirthdayReport(model);
        }
    }
}
