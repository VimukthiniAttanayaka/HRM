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

    public class EmployeeReportingManagerController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnEmployeeReportingManagerModelHead> get_EmployeeReportingManager_single(EmployeeReportingManager model)//ok
        {
            List<ReturnEmployeeReportingManagerModelHead> objEmployeeReportingManagerHeadList = new List<ReturnEmployeeReportingManagerModelHead>();
            //ReturnEmployeeReportingManagerModelHead obj = new ReturnEmployeeReportingManagerModelHead() { resp = false, msg = "sfsf" };
            //obj.EmployeeReportingManager = new List<ReturnEmployeeReportingManagerModel>();
            //if (model.EEJ_JobDescriptionID == 1) obj.EmployeeReportingManager.Add(new ReturnEmployeeReportingManagerModel() { EEJ_ID = 1, EEJ_EmployeeID = "test", EEJ_ReportingManagerID = "test", EEJ_Status = true });
            //if (model.EEJ_JobDescriptionID == 2) obj.EmployeeReportingManager.Add(new ReturnEmployeeReportingManagerModel() { EEJ_ID = 2, EEJ_EmployeeID = "test1", EEJ_ReportingManagerID = "test1", EEJ_Status = true });
            //if (model.EEJ_JobDescriptionID == 3) obj.EmployeeReportingManager.Add(new ReturnEmployeeReportingManagerModel() { EEJ_ID = 3, EEJ_EmployeeID = "test2", EEJ_ReportingManagerID = "test2", EEJ_Status = true });
            //objEmployeeReportingManagerHeadList.Add(obj);
            //return objEmployeeReportingManagerHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.EmployeeReportingManager_BL.get_EmployeeReportingManagers_single(model);

            }
            catch (Exception ex)
            {

                ReturnEmployeeReportingManagerModelHead objEmployeeReportingManagerHead = new ReturnEmployeeReportingManagerModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objEmployeeReportingManagerHeadList.Add(objEmployeeReportingManagerHead);

                objError.WriteLog(0, "EmployeeReportingManagerController", "get_EmployeeReportingManager_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeReportingManagerController", "get_EmployeeReportingManager_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeReportingManagerController", "get_EmployeeReportingManager_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeReportingManagerController", "get_EmployeeReportingManager_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objEmployeeReportingManagerHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnEmployeeReportingManagerModelHead> get_EmployeeReportingManager_all(EmployeeReportingManagerSearchModel model)//ok
        {
            List<ReturnEmployeeReportingManagerModelHead> objEmployeeReportingManagerHeadList = new List<ReturnEmployeeReportingManagerModelHead>();
            //ReturnEmployeeReportingManagerModelHead obj = new ReturnEmployeeReportingManagerModelHead() { resp = false, msg = "sfsf" };
            //obj.EmployeeReportingManager = new List<ReturnEmployeeReportingManagerModel>();
            //obj.EmployeeReportingManager.Add(new ReturnEmployeeReportingManagerModel() { EEJ_ID = 1, EEJ_EmployeeID = "test", EEJ_ReportingManagerID = "test", EEJ_Status = true });
            //obj.EmployeeReportingManager.Add(new ReturnEmployeeReportingManagerModel() { EEJ_ID = 2, EEJ_EmployeeID = "test1", EEJ_ReportingManagerID = "test1", EEJ_Status = true });
            //obj.EmployeeReportingManager.Add(new ReturnEmployeeReportingManagerModel() { EEJ_ID = 3, EEJ_EmployeeID = "test2", EEJ_ReportingManagerID = "test2", EEJ_Status = true });
            //objEmployeeReportingManagerHeadList.Add(obj);
            //return objEmployeeReportingManagerHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.EmployeeReportingManager_BL.get_EmployeeReportingManager_all(model);

            }
            catch (Exception ex)
            {

                ReturnEmployeeReportingManagerModelHead objEmployeeReportingManagerHead = new ReturnEmployeeReportingManagerModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objEmployeeReportingManagerHeadList.Add(objEmployeeReportingManagerHead);

                objError.WriteLog(0, "EmployeeReportingManagerController", "get_EmployeeReportingManager_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeReportingManagerController", "get_EmployeeReportingManager_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeReportingManagerController", "get_EmployeeReportingManager_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeReportingManagerController", "get_EmployeeReportingManager_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objEmployeeReportingManagerHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_EmployeeReportingManager(EmployeeReportingManagerModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeReportingManager_BL.add_new_EmployeeReportingManager(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objEmployeeReportingManagerHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objEmployeeReportingManagerHead);

                objError.WriteLog(0, "EmployeeReportingManagerController", "add_new_EmployeeReportingManager", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeReportingManagerController", "add_new_EmployeeReportingManager", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeReportingManagerController", "add_new_EmployeeReportingManager", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeReportingManagerController", "add_new_EmployeeReportingManager", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_EmployeeReportingManager(EmployeeReportingManagerModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeReportingManager_BL.modify_EmployeeReportingManager(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objEmployeeReportingManagerHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objEmployeeReportingManagerHead);

                objError.WriteLog(0, "EmployeeReportingManagerController", "modify_EmployeeReportingManager", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeReportingManagerController", "modify_EmployeeReportingManager", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeReportingManagerController", "modify_EmployeeReportingManager", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeReportingManagerController", "modify_EmployeeReportingManager", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_EmployeeReportingManager(InactiveEERMModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeReportingManager_BL.inactivate_EmployeeReportingManager(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objEmployeeReportingManagerHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objEmployeeReportingManagerHead);

                objError.WriteLog(0, "EmployeeReportingManagerController", "inactivate_EmployeeReportingManager", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeReportingManagerController", "inactivate_EmployeeReportingManager", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeReportingManagerController", "inactivate_EmployeeReportingManager", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeReportingManagerController", "inactivate_EmployeeReportingManager", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

