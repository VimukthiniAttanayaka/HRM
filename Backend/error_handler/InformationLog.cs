using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static error_handler.ErrorLog;

namespace error_handler
{
    public class InformationLog
    {
        //public enum LogType
        //{
        //    //Log Type used for unhandled exceptions
        //    Error = 0,
        //    //Configuration missing or data missing logs to use this type
        //    Warning = 1,
        //    //General information logs to use this type
        //    Info = 2,
        //    //Use this log type for development stack trace
        //    Trace = 3
        //};
        //private static string strLogFilePath = string.Empty;
        private static string strLogFilePath = error_handler.LogError.LogFilePath;
        private static int intLogMode = 3;

        public InformationLog(string LogFilePath, int LogMode)
        {
            strLogFilePath = LogFilePath;
            intLogMode = LogMode;
        }

        public class ModuleNames
        {
            public static string HRM_API = "HRM API";
        }


        public static bool WriteLog(LogType logType, string LogText, string Module)
        {

            try
            {
                if (strLogFilePath == string.Empty)
                {
                    return false;
                }

                if ((int)logType <= intLogMode)
                {
                    if (!System.IO.Directory.Exists(strLogFilePath))
                    {
                        System.IO.Directory.CreateDirectory(strLogFilePath);
                    }

                    
                    string strFileName = strLogFilePath + "\\" + Module + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

                    StringBuilder strLog = new StringBuilder();
                    strLog.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - ");
                    strLog.Append(" " + logType.ToString().ToUpper() + " - ");
                    strLog.Append(" HRM ");
                    strLog.Append(" - " + LogText);

                    if (!System.IO.File.Exists(strFileName))
                    {
                        using (System.IO.StreamWriter sw = System.IO.File.CreateText(strFileName))
                        {
                            sw.WriteLine(strLog.ToString());
                        }
                    }
                    else
                    {
                        using (System.IO.StreamWriter sw = System.IO.File.AppendText(strFileName))
                        {
                            sw.WriteLine(strLog.ToString());
                        }
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
