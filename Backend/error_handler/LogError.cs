using Microsoft.Extensions.Configuration;
using System;

namespace error_handler
{
    public class LogError
    {
        static IConfigurationRoot config = new ConfigurationBuilder()
                                           .AddJsonFile("appsettings.json")
                                           .Build();

        public static string LogPath
        {
            get
            {

                try
                {
                    var logPath = config["appSettings:LogPath"];

                    return logPath;
                }
                catch (Exception ex)
                {

                    return ex.Message;
                }
            }
        }
        public static string LogFilePath
        {
            get
            {

                try
                {
                    var logPath = config["appSettings:LogFilePath"];

                    return logPath;
                }
                catch (Exception ex)
                {

                    return ex.Message;
                }
            }
        }

        public string LogMode
        {
            get
            {

                try
                {
                    var logMode = config["appSettings:LogMode"];

                    return logMode;
                }
                catch (Exception ex)
                {

                    return ex.Message;
                }
            }
        }

        public static string LogFilePath_Kioski
        {
            get
            {

                try
                {
                    var logPath = config["appSettings:LogFilePath_Kioski"];

                    return logPath;
                }
                catch (Exception ex)
                {

                    return ex.Message;
                }
            }
        }

        ErrorLog errLog;
        public bool WriteLog(int? logType, string moduleName, string functionName, string errorMessage)
        {
            string logPath = string.Empty;
            int logMode = 0;
            ErrorLog.LogType errLogType = ErrorLog.LogType.Error;
            try
            {
                logPath = LogPath;

                Int32.TryParse(LogMode, out logMode);

                errLog = new ErrorLog(logPath, logMode);

                if (logType == 0)
                {
                    errLogType = ErrorLog.LogType.Error;
                }
                else if (logType == 1)
                {
                    errLogType = ErrorLog.LogType.Warning;
                }
                else if (logType == 2)
                {
                    errLogType = ErrorLog.LogType.Info;
                }
                else if (logType == 3)
                {
                    errLogType = ErrorLog.LogType.Trace;
                }

                var temp = ErrorLog.WriteLog(errLogType, moduleName, functionName, errorMessage);

                return temp;

            }
            catch
            {
                return false;
            }
        }

    }
}
