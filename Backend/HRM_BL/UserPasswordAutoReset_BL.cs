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
    public class UserPasswordAutoReset_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> AutoReset()
        {
            return HRM_DAL.Data.UserPasswordAutoReset_Data.UserPasswordAutoReset.AutoReset();
        }
    }
}