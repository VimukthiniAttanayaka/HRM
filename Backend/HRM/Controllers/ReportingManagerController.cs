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

    public class ReportingManagerController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnReportingManagerModelHead> get_ReportingManager_single(ReportingManager model)//ok
        {
            List<ReturnReportingManagerModelHead> objReportingManagerHeadList = new List<ReturnReportingManagerModelHead>();
            ReturnReportingManagerModelHead obj = new ReturnReportingManagerModelHead() { resp = false, msg = "sfsf" };
            obj.ReportingManager = new List<ReturnReportingManagerModel>();
            obj.ReportingManager.Add(new ReturnReportingManagerModel() { RM_ID = 1, RM_AllocatedTeam = 10, RM_ReportingManagerID = "test", RM_Status = true });
            obj.ReportingManager.Add(new ReturnReportingManagerModel() { RM_ID = 2, RM_AllocatedTeam = 10, RM_ReportingManagerID = "test1", RM_Status = true });
            obj.ReportingManager.Add(new ReturnReportingManagerModel() { RM_ID = 3, RM_AllocatedTeam = 10, RM_ReportingManagerID = "test2", RM_Status = true });
            objReportingManagerHeadList.Add(obj);
            return objReportingManagerHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.ReportingManager_BL.get_ReportingManager_single(model);

            }
            catch (Exception ex)
            {

                ReturnReportingManagerModelHead objReportingManagerHead = new ReturnReportingManagerModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objReportingManagerHeadList.Add(objReportingManagerHead);

                objError.WriteLog(0, "ReportingManagerController", "get_ReportingManager_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportingManagerController", "get_ReportingManager_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportingManagerController", "get_ReportingManager_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportingManagerController", "get_ReportingManager_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objReportingManagerHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnReportingManagerModelHead> get_ReportingManager_all(ReportingManagerSearchModel model)//ok
        {
            List<ReturnReportingManagerModelHead> objReportingManagerHeadList = new List<ReturnReportingManagerModelHead>();
            ReturnReportingManagerModelHead obj = new ReturnReportingManagerModelHead() { resp = false, msg = "sfsf" };
            obj.ReportingManager = new List<ReturnReportingManagerModel>();
            obj.ReportingManager.Add(new ReturnReportingManagerModel() { RM_ID = 1, RM_AllocatedTeam = 10, RM_ReportingManagerID = "test", RM_Status = true });
            obj.ReportingManager.Add(new ReturnReportingManagerModel() { RM_ID = 2, RM_AllocatedTeam = 10, RM_ReportingManagerID = "test1", RM_Status = true });
            obj.ReportingManager.Add(new ReturnReportingManagerModel() { RM_ID = 3, RM_AllocatedTeam = 10, RM_ReportingManagerID = "test2", RM_Status = true });
            objReportingManagerHeadList.Add(obj);
            return objReportingManagerHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.ReportingManager_BL.get_ReportingManager_all(model);

            }
            catch (Exception ex)
            {

                ReturnReportingManagerModelHead objReportingManagerHead = new ReturnReportingManagerModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objReportingManagerHeadList.Add(objReportingManagerHead);

                objError.WriteLog(0, "ReportingManagerController", "get_ReportingManager_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportingManagerController", "get_ReportingManager_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportingManagerController", "get_ReportingManager_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportingManagerController", "get_ReportingManager_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objReportingManagerHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_ReportingManager(ReportingManagerModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.ReportingManager_BL.add_new_ReportingManager(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objReportingManagerHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objReportingManagerHead);

                objError.WriteLog(0, "ReportingManagerController", "add_new_ReportingManager", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportingManagerController", "add_new_ReportingManager", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportingManagerController", "add_new_ReportingManager", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportingManagerController", "add_new_ReportingManager", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_ReportingManager(ReportingManagerModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.ReportingManager_BL.modify_ReportingManager(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objReportingManagerHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objReportingManagerHead);

                objError.WriteLog(0, "ReportingManagerController", "modify_ReportingManager", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportingManagerController", "modify_ReportingManager", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportingManagerController", "modify_ReportingManager", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportingManagerController", "modify_ReportingManager", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_ReportingManager(InactiveRMModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.ReportingManager_BL.inactivate_ReportingManager(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objReportingManagerHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objReportingManagerHead);

                objError.WriteLog(0, "ReportingManagerController", "inactivate_ReportingManager", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportingManagerController", "inactivate_ReportingManager", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportingManagerController", "inactivate_ReportingManager", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportingManagerController", "inactivate_ReportingManager", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

