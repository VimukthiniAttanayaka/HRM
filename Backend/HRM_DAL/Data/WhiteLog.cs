using error_handler;
using System;
using static error_handler.ErrorLog;

namespace HRM_DAL.Data
{
    public class WhiteLog
    {
        private LogError objError = new LogError();
        public WhiteLog(Exception ex, string controllerName, string methodName)
        {
            WriteInToLog(ex, controllerName, methodName);
        }

        public WhiteLog(String ex, string controllerName, string methodName, bool IsTrace, bool IsKioski)
        {
            if (IsTrace == true)
            {
                if (IsKioski == true)
                {
                    InformationLog_Kioski.WriteLog(LogType.Trace, ex, methodName, controllerName);
                }
                else
                {
                   InformationLog.WriteLog(LogType.Trace, ex, methodName);
                }

            }
            else
               objError.WriteLog(0, controllerName, methodName, "Stack Track: " + ex);

        }

        private void WriteInToLog(Exception ex, string controllerName, string methodName)
        {
            objError.WriteLog(0, controllerName, methodName, "Stack Track: " + ex.StackTrace);
            objError.WriteLog(0, controllerName, methodName, "Error Message: " + ex.Message);
            if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
            {
                objError.WriteLog(0, controllerName, methodName, "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                objError.WriteLog(0, controllerName, methodName, "Inner Exception Message: " + ex.InnerException.Message);
            }
        }
    }
}
