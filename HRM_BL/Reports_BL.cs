using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System;

namespace HRM_BL
{
    public class Reports_BL
    {
        private static LogError objError = new LogError();

        public static List<ReportsReturnResponse> MailbagDailyActivityReports(MailbagDailyActivityRequestModel model)
        {
            return HRM_DAL.Data.Reports_Data.MailbagDailyActivityReports(model);
        }

        public static List<ReportsReturnResponse> MailbagDailyActivityReports_V1(MailbagDailyActivityRequestModel_V1 model)
        {
            return HRM_DAL.Data.Reports_Data.MailbagDailyActivityReports_V1(model);
        }

        public static List<ReportsReturnResponse> PrintContainerLabelWithQRSticker(PrintContainerRequestModel model)
        {
            return HRM_DAL.Data.Reports_Data.PrintContainerLabelWithQRSticker(model);
        }
    }
}