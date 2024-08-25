using HRM_DAL.Models;
using error_handler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using utility_handler.Data;
using static error_handler.ErrorLog;
using System.Reflection;

namespace HRM.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class LogReportsController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnUserLogReportsModelHead> get_UerLogReport(AccessGroup model)//ok
        {
            List<ReturnUserLogReportsModelHead> objAccessGroupHeadList = new List<ReturnUserLogReportsModelHead>();
            ReturnUserLogReportsModelHead obj = new ReturnUserLogReportsModelHead() { resp = false, msg = "sfsf" };
            obj.UserLog = new List<UserLogModel>();

            obj.UserLog.Add(new UserLogModel() { LoggedDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), UserID = "ANU", UserLogId = "Annual", UserLogOffTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), UserName = "Annual" });
            obj.UserLog.Add(new UserLogModel() { LoggedDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), UserID = "ANU1", UserLogId = "Annual1", UserLogOffTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), UserName = "Annual1" });
            obj.UserLog.Add(new UserLogModel() { LoggedDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), UserID = "MED", UserLogId = "Medical", UserLogOffTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), UserName = "Medical" });
            obj.UserLog.Add(new UserLogModel() { LoggedDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), UserID = "MAT", UserLogId = "Matrinaty", UserLogOffTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), UserName = "Matrinaty" });
            obj.UserLog.Add(new UserLogModel() { LoggedDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), UserID = "MAT", UserLogId = "Matrinaty", UserLogOffTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), UserName = "Matrinaty" });

            objAccessGroupHeadList.Add(obj);
            return objAccessGroupHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                //return HRM_BL.AccessGroup_BL.get_AccessGroups_single(model);

            }
            catch (Exception ex)
            {

                ReturnUserLogReportsModelHead objAccessGroupHead = new ReturnUserLogReportsModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objAccessGroupHeadList.Add(objAccessGroupHead);

                objError.WriteLog(0, "LogReportsController", "get_UerLogReport", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LogReportsController", "get_UerLogReport", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LogReportsController", "get_UerLogReport", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LogReportsController", "get_UerLogReport", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objAccessGroupHeadList;

        }
    }
}
