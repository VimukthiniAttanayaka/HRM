using System;
using System.Configuration;

namespace EmailReader_DL
{
    public class ConfigCaller
    {
        private static string _connectionString;
        public static string ErrorLogPath
        {
            get
            {
                return ConfigurationManager.AppSettings["ErrorLogPath"];
            }

        }
        public static int ExecutionInterval_OutLookEmail
        {
            get
            {
                int executionInterval_MailBag = 1;
                int.TryParse(ConfigurationManager.AppSettings["ExecutionInterval_OutLookEmail"], out executionInterval_MailBag);
                return executionInterval_MailBag;
            }
        }


        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    var ConStrign = ConfigurationManager.AppSettings["DefaultConnection"];
                    _connectionString = ConStrign;
                }

                return _connectionString;
            }
        }
    }

}