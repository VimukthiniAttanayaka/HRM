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
    public class OutgoingMailExceptionHandling_BL
    {
        private static LogError objError = new LogError();


        public static List<ReturnResponse> RunProcess()
        {
            return HRM_DAL.Data.OutgoingMailExceptionHandling_Data.RunProcess();
        }

        public static List<ReturnResponse> MainFlow1(List<ExceptionMailReaderTable> mailList)
        {
            return HRM_DAL.Data.OutgoingMailExceptionHandling_Data.MainFlow1_Related.MainFlow1(mailList);
        }

    }
}