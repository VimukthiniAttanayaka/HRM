using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using HRM_DAL.Data;
using System;

namespace HRM_BL
{
    public class DayEndProcess_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> Batch_Summary_Email_Process()
        {
            return HRM_DAL.Data.DayEndProcess_Data.Batch_Summary_Email.Process();
        }
        public static List<ReturnResponse> Batch_Summary_Email_ManualProcess()
        {
            return HRM_DAL.Data.DayEndProcess_Data.Batch_Summary_Email.ManualProcess();
        }
    }
}