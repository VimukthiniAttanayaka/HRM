using error_handler;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using utility_handler.Data;
using static error_handler.ErrorLog;
//using static error_handler.InformationLog;
using HRM_DAL.Models;
using System.Text;
using HRM_DAL.Data;

namespace HRM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class logTracersController : ControllerBase
    {
        private LogError objError = new LogError();

        //// GET: api/<UserController>
        //[HttpPost]
        //[Route("[action]")]
        ////[Authorize]
        //public List<ReturnResponse> CreateUILogs(LogTracerModel obj)
        //{

        //    List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
        //    ReturnResponse objReturn = new ReturnResponse();

        //    try
        //    {
        //        objReturn = WriteLog(obj.logType, obj.ModuleName, obj.FunctionName, obj.LogText);

        //        //ReturnUserAccessModelHead objUserHead = new ReturnUserAccessModelHead
        //        //{
        //        //    resp = true,
        //        //    msg = "Create UI Logs"
        //        //};
        //        //objUserHeadList.Add(objUserHead);

        //        return objUserHeadList;
        //    }
        //    catch (Exception ex)
        //    {

        //        ReturnUserAccessModelHead objUserHead = new ReturnUserAccessModelHead
        //        {
        //            resp = false,
        //            msg = ex.Message.ToString()
        //        };
        //        objUserHeadList.Add(objUserHead);

        //        objError.WriteLog(0, "logTracersController", "CreateUILogs", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "logTracersController", "CreateUILogs", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "logTracersController", "CreateUILogs", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "logTracersController", "CreateUILogs", "Inner Exception Message: " + ex.InnerException.Message);
        //        }


        //    }
        //    return objUserHeadList;
        //}

        public class LogTracerModel
        {
            public LogType logType { get; set; }
            public string ModuleName { get; set; }
            public string FunctionName { get; set; }
            public string LogText { get; set; }
        }

        [NonAction]
        public ReturnResponse WriteLog(LogType logType, string ModuleName, string FunctionName, string LogText)
        {
            ReturnResponse templist = new ReturnResponse();

            try
            {
                if (ConfigCaller.UILogFilePath == string.Empty)
                {
                    return new ReturnResponse() { msg = ConfigCaller.UILogFilePath, resp = false };
                }

                //if ((int)logType <= intLogMode)
                //{
                if (!System.IO.Directory.Exists(ConfigCaller.UILogFilePath))
                {
                    System.IO.Directory.CreateDirectory(ConfigCaller.UILogFilePath);
                }

                string strFileName = ConfigCaller.UILogFilePath + "\\UI_Log_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";

                StringBuilder strLog = new StringBuilder();
                strLog.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - ");
                strLog.Append(" [HRM Web UI]");
                strLog.Append(" [" + logType + "]");
                strLog.Append(" [" + ModuleName + "]");
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
                //}

                return new ReturnResponse() { msg = ConfigCaller.UILogFilePath, resp = true };
            }
            catch (Exception ex)
            {
                return new ReturnResponse() { msg = ConfigCaller.UILogFilePath + ex.Message + ex.StackTrace, resp = false };
            }


        }
    }
}
