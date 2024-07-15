using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace utility_handler.Utility
{
    public class ConfigCaller
    {
        static IConfigurationRoot config = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json")
                  .Build();


        public static string SystemUserName
        {
            get
            {

                try
                {

                    var SystemUserName = config["appSettings:SystemUserName"];
                    return SystemUserName;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string SystemPassword
        {
            get
            {

                try
                {
                    var SystemPassword = config["appSettings:SystemPassword"];
                    return SystemPassword;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string AuthenticationFailMessage
        {
            get
            {

                try
                {
                    var AuthenticationFailMessage = config["appSettings:AuthenticationFailMessage"];
                    return AuthenticationFailMessage;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public static string ServiceName
        {
            get
            {

                try
                {
                    var ServiceName = config["appSettings:ServiceName"];
                    return ServiceName;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
