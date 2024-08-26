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
        public List<ReturnUserLogReportsModelHead> get_UserLogReport(RequestUserLog model)//ok
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

                return HRM_BL.LogReports_BL.get_UserLogReport(model);

            }
            catch (Exception ex)
            {

                ReturnUserLogReportsModelHead objAccessGroupHead = new ReturnUserLogReportsModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objAccessGroupHeadList.Add(objAccessGroupHead);

                objError.WriteLog(0, "LogReportsController", "get_UserLogReport", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LogReportsController", "get_UserLogReport", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LogReportsController", "get_UserLogReport", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LogReportsController", "get_UserLogReport", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objAccessGroupHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnErrorLogReportsModelHead> get_ErrorLogReport(RequestErrorLog model)//ok
        {
            List<ReturnErrorLogReportsModelHead> objAccessGroupHeadList = new List<ReturnErrorLogReportsModelHead>();
            ReturnErrorLogReportsModelHead obj = new ReturnErrorLogReportsModelHead() { resp = false, msg = "sfsf" };
            obj.ErrorLog = new List<ErrorLogModel>();

            obj.ErrorLog.Add(new ErrorLogModel() { ErrorLogId = "ANU", ErrorDescription = "ANU", ErrorUserId = "ANU", ErrorDatetime = "ANU", ErrorLoggedIp = "ANU", ErrorRef = "ANU", ErrorPage = "ANU" });
            obj.ErrorLog.Add(new ErrorLogModel() { ErrorLogId = "ANU", ErrorDescription = "ANU", ErrorUserId = "ANU", ErrorDatetime = "ANU", ErrorLoggedIp = "ANU", ErrorRef = "ANU", ErrorPage = "ANU" });
            obj.ErrorLog.Add(new ErrorLogModel() { ErrorLogId = "ANU", ErrorDescription = "ANU", ErrorUserId = "ANU", ErrorDatetime = "ANU", ErrorLoggedIp = "ANU", ErrorRef = "ANU", ErrorPage = "ANU" });
            obj.ErrorLog.Add(new ErrorLogModel() { ErrorLogId = "ANU", ErrorDescription = "ANU", ErrorUserId = "ANU", ErrorDatetime = "ANU", ErrorLoggedIp = "ANU", ErrorRef = "ANU", ErrorPage = "ANU" });
            obj.ErrorLog.Add(new ErrorLogModel() { ErrorLogId = "ANU", ErrorDescription = "ANU", ErrorUserId = "ANU", ErrorDatetime = "ANU", ErrorLoggedIp = "ANU", ErrorRef = "ANU", ErrorPage = "ANU" });

            objAccessGroupHeadList.Add(obj);
            return objAccessGroupHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.LogReports_BL.get_ErrorLogReport(model);

            }
            catch (Exception ex)
            {

                ReturnErrorLogReportsModelHead objAccessGroupHead = new ReturnErrorLogReportsModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objAccessGroupHeadList.Add(objAccessGroupHead);

                objError.WriteLog(0, "LogReportsController", "get_ErrorLogReport", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LogReportsController", "get_ErrorLogReport", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LogReportsController", "get_ErrorLogReport", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LogReportsController", "get_ErrorLogReport", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objAccessGroupHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnAuditLogReportsModelHead> get_AuditLogReport(RequestAuditLog model)//ok
        {
            List<ReturnAuditLogReportsModelHead> objAccessGroupHeadList = new List<ReturnAuditLogReportsModelHead>();
            ReturnAuditLogReportsModelHead obj = new ReturnAuditLogReportsModelHead() { resp = false, msg = "sfsf" };
            obj.AuditLog = new List<AuditLogModel>();

            obj.AuditLog.Add(new AuditLogModel() { Action = "ANU", Description = "ANU", CreatedBy = "ANU", ClientIP = "ANU", CreatedDateTime = "ANU", SequenceNo = "ANU", Module = "ANU", Controler = "ANU", ActionType = "ANU", ActionMap_ID = "ANU" });
            obj.AuditLog.Add(new AuditLogModel() { Action = "ANU", Description = "ANU", CreatedBy = "ANU", ClientIP = "ANU", CreatedDateTime = "ANU", SequenceNo = "ANU", Module = "ANU", Controler = "ANU", ActionType = "ANU", ActionMap_ID = "ANU" });
            obj.AuditLog.Add(new AuditLogModel() { Action = "ANU", Description = "ANU", CreatedBy = "ANU", ClientIP = "ANU", CreatedDateTime = "ANU", SequenceNo = "ANU", Module = "ANU", Controler = "ANU", ActionType = "ANU", ActionMap_ID = "ANU" });
            obj.AuditLog.Add(new AuditLogModel() { Action = "ANU", Description = "ANU", CreatedBy = "ANU", ClientIP = "ANU", CreatedDateTime = "ANU", SequenceNo = "ANU", Module = "ANU", Controler = "ANU", ActionType = "ANU", ActionMap_ID = "ANU" });
            obj.AuditLog.Add(new AuditLogModel() { Action = "ANU", Description = "ANU", CreatedBy = "ANU", ClientIP = "ANU", CreatedDateTime = "ANU", SequenceNo = "ANU", Module = "ANU", Controler = "ANU", ActionType = "ANU", ActionMap_ID = "ANU" });

            objAccessGroupHeadList.Add(obj);
            return objAccessGroupHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.LogReports_BL.get_AuditLogReport(model);

            }
            catch (Exception ex)
            {

                ReturnAuditLogReportsModelHead objAccessGroupHead = new ReturnAuditLogReportsModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objAccessGroupHeadList.Add(objAccessGroupHead);

                objError.WriteLog(0, "LogReportsController", "get_AuditLogReport", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LogReportsController", "get_AuditLogReport", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LogReportsController", "get_AuditLogReport", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LogReportsController", "get_AuditLogReport", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objAccessGroupHeadList;

        }
    }
}
