using EmailReader_DL;
using System;
using System.Text;
using System.Threading;

namespace ExceptionEmailHandler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
       
        static void Main()
        {

            while (true)
            {
                WriteLog("EmailReader Before Start", "Email Reader Started");
                Console.WriteLine(errorLogPath);
                //EmailReader_DL.OutLookEmailRead.TriggerMailReader();
                WriteLog("EmailReader After Ended", "Email Reader Ended");
                
                Thread.Sleep(600000);
            }
            
        }

        static string errorLogPath = ConfigCaller.ErrorLogPath;

        public static bool WriteLog(string LogText, string Action)
        {

            try
            {
                if (errorLogPath == string.Empty)
                {
                    return false;
                }


                if (!System.IO.Directory.Exists(errorLogPath))
                {
                    System.IO.Directory.CreateDirectory(errorLogPath);
                }


                string strFileName = errorLogPath + "\\" + "EmailReader" + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

                StringBuilder strLog = new StringBuilder();
                strLog.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - ");
                strLog.Append(" KioskReader ");
                strLog.Append(" - " + Action);
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
