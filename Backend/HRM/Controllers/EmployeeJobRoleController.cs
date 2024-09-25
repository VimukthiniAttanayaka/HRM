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

    public class EmployeeJobRoleController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnEmployeeJobRoleModelHead> get_EmployeeJobRole_single(EmployeeJobRole model)//ok
        {
            List<ReturnEmployeeJobRoleModelHead> objEmployeeJobRoleHeadList = new List<ReturnEmployeeJobRoleModelHead>();
            //ReturnEmployeeJobRoleModelHead obj = new ReturnEmployeeJobRoleModelHead() { resp = false, msg = "sfsf" };
            //obj.EmployeeJobRole = new List<ReturnEmployeeJobRoleModel>();
            //if (model.EEJ_JobDescriptionID == 1) obj.EmployeeJobRole.Add(new ReturnEmployeeJobRoleModel() { EEJ_ID = 1, EEJ_EmployeeID = "test", EEJ_JobRoleID = "test", EEJ_Status = true });
            //if (model.EEJ_JobDescriptionID == 2) obj.EmployeeJobRole.Add(new ReturnEmployeeJobRoleModel() { EEJ_ID = 2, EEJ_EmployeeID = "test1", EEJ_JobRoleID = "test1", EEJ_Status = true });
            //if (model.EEJ_JobDescriptionID == 3) obj.EmployeeJobRole.Add(new ReturnEmployeeJobRoleModel() { EEJ_ID = 3, EEJ_EmployeeID = "test2", EEJ_JobRoleID = "test2", EEJ_Status = true });
            //objEmployeeJobRoleHeadList.Add(obj);
            //return objEmployeeJobRoleHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.EmployeeJobRole_BL.get_EmployeeJobRole_single(model);

            }
            catch (Exception ex)
            {

                ReturnEmployeeJobRoleModelHead objEmployeeJobRoleHead = new ReturnEmployeeJobRoleModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objEmployeeJobRoleHeadList.Add(objEmployeeJobRoleHead);

                objError.WriteLog(0, "EmployeeJobRoleController", "get_EmployeeJobRole_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeJobRoleController", "get_EmployeeJobRole_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeJobRoleController", "get_EmployeeJobRole_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeJobRoleController", "get_EmployeeJobRole_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objEmployeeJobRoleHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnEmployeeJobRoleModelHead> get_EmployeeJobRole_all(EmployeeJobRoleSearchModel model)//ok
        {
            List<ReturnEmployeeJobRoleModelHead> objEmployeeJobRoleHeadList = new List<ReturnEmployeeJobRoleModelHead>();
            //ReturnEmployeeJobRoleModelHead obj = new ReturnEmployeeJobRoleModelHead() { resp = false, msg = "sfsf" };
            //obj.EmployeeJobRole = new List<ReturnEmployeeJobRoleModel>();
            //obj.EmployeeJobRole.Add(new ReturnEmployeeJobRoleModel() { EEJ_ID = 1, EEJ_EmployeeID = "test", EEJ_JobRoleID = "test", EEJ_Status = true });
            //obj.EmployeeJobRole.Add(new ReturnEmployeeJobRoleModel() { EEJ_ID = 2, EEJ_EmployeeID = "test1", EEJ_JobRoleID = "test1", EEJ_Status = true });
            //obj.EmployeeJobRole.Add(new ReturnEmployeeJobRoleModel() { EEJ_ID = 3, EEJ_EmployeeID = "test2", EEJ_JobRoleID = "test2", EEJ_Status = true });
            //objEmployeeJobRoleHeadList.Add(obj);
            //return objEmployeeJobRoleHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.EmployeeJobRole_BL.get_EmployeeJobRole_all(model);

            }
            catch (Exception ex)
            {

                ReturnEmployeeJobRoleModelHead objEmployeeJobRoleHead = new ReturnEmployeeJobRoleModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objEmployeeJobRoleHeadList.Add(objEmployeeJobRoleHead);

                objError.WriteLog(0, "EmployeeJobRoleController", "get_EmployeeJobRole_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeJobRoleController", "get_EmployeeJobRole_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeJobRoleController", "get_EmployeeJobRole_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeJobRoleController", "get_EmployeeJobRole_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objEmployeeJobRoleHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_EmployeeJobRole(EmployeeJobRoleModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeJobRole_BL.add_new_EmployeeJobRole(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objEmployeeJobRoleHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objEmployeeJobRoleHead);

                objError.WriteLog(0, "EmployeeJobRoleController", "add_new_EmployeeJobRole", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeJobRoleController", "add_new_EmployeeJobRole", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeJobRoleController", "add_new_EmployeeJobRole", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeJobRoleController", "add_new_EmployeeJobRole", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_EmployeeJobRole(EmployeeJobRoleModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeJobRole_BL.modify_EmployeeJobRole(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objEmployeeJobRoleHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objEmployeeJobRoleHead);

                objError.WriteLog(0, "EmployeeJobRoleController", "modify_EmployeeJobRole", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeJobRoleController", "modify_EmployeeJobRole", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeJobRoleController", "modify_EmployeeJobRole", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeJobRoleController", "modify_EmployeeJobRole", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_EmployeeJobRole(InactiveEEJRModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeJobRole_BL.inactivate_EmployeeJobRole(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objEmployeeJobRoleHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objEmployeeJobRoleHead);

                objError.WriteLog(0, "EmployeeJobRoleController", "inactivate_EmployeeJobRole", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeJobRoleController", "inactivate_EmployeeJobRole", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeJobRoleController", "inactivate_EmployeeJobRole", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeJobRoleController", "inactivate_EmployeeJobRole", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

