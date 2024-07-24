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

    public class UserRoleController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnUserRoleModelHead> get_UserRole_single(UserRole model)//ok
        {
            List<ReturnUserRoleModelHead> objUserRoleHeadList = new List<ReturnUserRoleModelHead>();
            ReturnUserRoleModelHead obj = new ReturnUserRoleModelHead() { resp = false, msg = "sfsf" };
            obj.UserRole = new List<ReturnUserRoleModel>();
            List<AccessGroupSelect> AccessGroups = new List<AccessGroupSelect>();
            AccessGroups.Add(new AccessGroupSelect() { value = "CAS", label = "CAS", Ischecked = true });
            AccessGroups.Add(new AccessGroupSelect() { value = "ANU", label = "ANU", Ischecked = true });
            AccessGroups.Add(new AccessGroupSelect() { value = "MED", label = "MED", Ischecked = true });
            if (model.EUR_UserRoleID == "CAS")
                obj.UserRole.Add(new ReturnUserRoleModel() { EUR_UserRoleID = "CAS", EUR_UserRole = "Casual", EUR_Status = true, AccessGroups = AccessGroups });
            if (model.EUR_UserRoleID == "ANU") obj.UserRole.Add(new ReturnUserRoleModel() { EUR_UserRoleID = "ANU", EUR_UserRole = "Annual", EUR_Status = true, AccessGroups = AccessGroups });
            if (model.EUR_UserRoleID == "MED") obj.UserRole.Add(new ReturnUserRoleModel() { EUR_UserRoleID = "MED", EUR_UserRole = "Medical", EUR_Status = true, AccessGroups = AccessGroups });
            if (model.EUR_UserRoleID == "MAT") obj.UserRole.Add(new ReturnUserRoleModel() { EUR_UserRoleID = "MAT", EUR_UserRole = "Matrinaty", EUR_Status = true, AccessGroups = AccessGroups });
            objUserRoleHeadList.Add(obj);
            return objUserRoleHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.UserRole_BL.get_UserRoles_single(model);

            }
            catch (Exception ex)
            {

                ReturnUserRoleModelHead objUserRoleHead = new ReturnUserRoleModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserRoleHeadList.Add(objUserRoleHead);

                objError.WriteLog(0, "UserRoleController", "get_UserRole_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserRoleController", "get_UserRole_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserRoleController", "get_UserRole_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserRoleController", "get_UserRole_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objUserRoleHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnUserRoleModelHead> get_UserRole_all(UserRoleSearchModel model)//ok
        {
            List<ReturnUserRoleModelHead> objUserRoleHeadList = new List<ReturnUserRoleModelHead>();
            ReturnUserRoleModelHead obj = new ReturnUserRoleModelHead() { resp = false, msg = "sfsf" };
            obj.UserRole = new List<ReturnUserRoleModel>();
            obj.UserRole.Add(new ReturnUserRoleModel() { EUR_UserRoleID = "CAS", EUR_UserRole = "Casual", EUR_Status = true });
            obj.UserRole.Add(new ReturnUserRoleModel() { EUR_UserRoleID = "ANU", EUR_UserRole = "Annual", EUR_Status = true });
            obj.UserRole.Add(new ReturnUserRoleModel() { EUR_UserRoleID = "MED", EUR_UserRole = "Medical", EUR_Status = true });
            obj.UserRole.Add(new ReturnUserRoleModel() { EUR_UserRoleID = "MAT", EUR_UserRole = "Matrinaty", EUR_Status = true });
            objUserRoleHeadList.Add(obj);
            return objUserRoleHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.UserRole_BL.get_UserRole_all(model);

            }
            catch (Exception ex)
            {

                ReturnUserRoleModelHead objUserRoleHead = new ReturnUserRoleModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserRoleHeadList.Add(objUserRoleHead);

                objError.WriteLog(0, "UserRoleController", "get_UserRole_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserRoleController", "get_UserRole_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserRoleController", "get_UserRole_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserRoleController", "get_UserRole_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objUserRoleHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> add_new_UserRole(UserRoleModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.UserRole_BL.add_new_UserRole(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objUserRoleHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objUserRoleHead);

                objError.WriteLog(0, "UserRoleController", "add_new_UserRole", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserRoleController", "add_new_UserRole", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserRoleController", "add_new_UserRole", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserRoleController", "add_new_UserRole", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> modify_UserRole(UserRoleModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.UserRole_BL.modify_UserRole(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objUserRoleHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objUserRoleHead);

                objError.WriteLog(0, "UserRoleController", "modify_UserRole", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserRoleController", "modify_UserRole", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserRoleController", "modify_UserRole", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserRoleController", "modify_UserRole", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_UserRole(InactiveEURModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.UserRole_BL.inactivate_UserRole(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objUserRoleHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserRoleHead);

                objError.WriteLog(0, "UserRoleController", "inactivate_UserRole", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserRoleController", "inactivate_UserRole", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserRoleController", "inactivate_UserRole", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserRoleController", "inactivate_UserRole", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

