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
    [Route("[controller]")]

    public class versionController : ControllerBase
    {


        private readonly ILogger<versionController> _logger;

        public versionController(ILogger<versionController> logger)
        {
            _logger = logger;
        }

        public async Task Login(string returnUrl = "/")
        {
            await HttpContext.ChallengeAsync("Auth0", new AuthenticationProperties() { RedirectUri = returnUrl });
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync("Auth0", new AuthenticationProperties()
            {
                RedirectUri = Url.Action("Index", "Home")
            });
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public IEnumerable<version> Get()
        {
            //    public UAGModel Get()
            //{
            //UAGModel um = new UAGModel();
            //um.ExistingUAG = new List<ExistingUAGModel>();
            //um.KioskAG = new List<KioskAGModel>();

            //um.ExistingUAG.Add(new ExistingUAGModel() { });
            //um.KioskAG.Add(new KioskAGModel() { });

            var rng = new Random();

            //LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "");

            return Enumerable.Range(1, 1).Select(index => new version
            {
                version1 = "1.0.0"

            })
            .ToArray();

            //return um;
        }

        // GET: api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> CheckLogs()
        {
            LogError objError = new LogError();
            List<ReturnResponse> templist = new List<ReturnResponse>();

            DateTime createddatetime = DateTime.Now;
            string datestring = createddatetime.ToString("yyyy-MM-ddThh:mm:ss.fffZ");

            templist.Add(new ReturnResponse()
            {
                resp = true,
                msg = datestring
            });

            var temp = objError.WriteLog(0, "versionController", "CheckLogs", "Stack Track: Test By API");
            templist.Add(new ReturnResponse() { resp = temp, msg = "Error API Log " });

            new HRM_DAL.Data.WhiteLog("versionController", "CheckLogs", "CheckLogs", true, true);

            new HRM_DAL.Data.WhiteLog("versionController", "CheckLogs", "CheckLogs", true, false);

            new HRM_DAL.Data.WhiteLog("versionController", "CheckLogs", "CheckLogs", false, false);

            var temp1 = InformationLog_Kioski.WriteLog(LogType.Trace, "Stack Track: Test By API", "CheckLogs", "versionController");
            templist.Add(new ReturnResponse() { resp = temp1, msg = "Error API Log " });

            var temp2 = InformationLog.WriteLog(LogType.Trace, "Stack Track: Test By API", "CheckLogs");
            templist.Add(new ReturnResponse() { resp = temp2, msg = "Error API Log " });

            templist.Add(new ReturnResponse() { msg = ErrorLog.strLogFilePath, resp = true });


            templist.Add(new ReturnResponse() { msg = ConfigCaller.RDLCReportPath, resp = true });

            templist.Add(new ReturnResponse() { msg = ConfigCaller.PDFReportPath, resp = true });

            templist.Add(WriteLog(LogType.Error, "Stack Track: Test By API", "CheckLogs", "WriteLog"));

            return templist;
        }

        // GET: api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> CheckEmailAddress(EmailChecker model)
        {
            List<ReturnResponse> templist = new List<ReturnResponse>();

            var test = !utility_handler.Utility.Misc.EmailValidator(model.EmailAddress);

            templist.Add(new ReturnResponse() { msg = model.EmailAddress, resp = test });

            return templist;
        }
        public class EmailChecker { public string EmailAddress { get; set; } }
        public ReturnResponse WriteLog(LogType logType, string ModuleName, string FunctionName, string LogText)
        {
            ReturnResponse templist = new ReturnResponse();

            try
            {
                if (strLogFilePath == string.Empty)
                {
                    return new ReturnResponse() { msg = ErrorLog.strLogFilePath, resp = false };
                }

                //if ((int)logType <= intLogMode)
                //{
                if (!System.IO.Directory.Exists(ErrorLog.strLogFilePath))
                {
                    System.IO.Directory.CreateDirectory(ErrorLog.strLogFilePath);
                }

                string strFileName = ErrorLog.strLogFilePath + "\\Log_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";

                StringBuilder strLog = new StringBuilder();
                strLog.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - ");
                strLog.Append(" [HRM Web API]");
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

                return new ReturnResponse() { msg = ErrorLog.strLogFilePath, resp = true };
            }
            catch (Exception ex)
            {
                return new ReturnResponse() { msg = ErrorLog.strLogFilePath + ex.Message + ex.StackTrace, resp = false };
            }


        }
    }
}
