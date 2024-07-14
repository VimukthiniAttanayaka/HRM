﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailReader_DL
{
    public class ErrorLog
    {
        public enum LogType
        {
            //Log Type used for unhandled exceptions
            Error = 0,
            //Configuration missing or data missing logs to use this type
            Warning = 1,
            //General information logs to use this type
            Info = 2,
            //Use this log type for development stack trace
            Trace = 3
        };
        private static string strLogFilePath = string.Empty;
        private static int intLogMode = 0;
      
        public static bool WriteLog(string FunctionName, string LogText)
        {

            try
            {
                if (strLogFilePath == string.Empty)
                {
                    return false;
                }

                
                if (!System.IO.Directory.Exists(strLogFilePath))
                {
                    System.IO.Directory.CreateDirectory(strLogFilePath);
                }

                string strFileName = strLogFilePath + "\\Log_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";

                StringBuilder strLog = new StringBuilder();
                strLog.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - ");
                strLog.Append(" [EmailReader_DL");
                strLog.Append(" [" + FunctionName + "]");
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
                

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

