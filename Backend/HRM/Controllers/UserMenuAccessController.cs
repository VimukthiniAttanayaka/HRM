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

    public class UserMenuAccessController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnUserMenuAccessModelHead> get_UserMenuAccess_single(UserMenuAccess model)//ok
        {
            List<ReturnUserMenuAccessModelHead> objUserMenuAccessHeadList = new List<ReturnUserMenuAccessModelHead>();
            ReturnUserMenuAccessModelHead obj = new ReturnUserMenuAccessModelHead() { resp = false, msg = "sfsf" };
            obj.UserMenuAccess = new List<ReturnUserMenuAccessModel>();
            if (model.UUMA_UserMenuAccessID == "CAS")
                obj.UserMenuAccess.Add(new ReturnUserMenuAccessModel() { UUMA_UserMenuAccessID = 1, UUMA_AccessGroupID = "CAS", UUMA_MenuAccessID = "CAS", UUMA_Status = true });
            if (model.UUMA_UserMenuAccessID == "ANU") obj.UserMenuAccess.Add(new ReturnUserMenuAccessModel() { UUMA_UserMenuAccessID = 2, UUMA_AccessGroupID = "ANU", UUMA_MenuAccessID = "ANU", UUMA_Status = true });
            if (model.UUMA_UserMenuAccessID == "MED") obj.UserMenuAccess.Add(new ReturnUserMenuAccessModel() { UUMA_UserMenuAccessID = 3, UUMA_AccessGroupID = "MED", UUMA_MenuAccessID = "MED", UUMA_Status = true });
            if (model.UUMA_UserMenuAccessID == "MAT") obj.UserMenuAccess.Add(new ReturnUserMenuAccessModel() { UUMA_UserMenuAccessID = 4, UUMA_AccessGroupID = "MAT", UUMA_MenuAccessID = "MAT", UUMA_Status = true });
            objUserMenuAccessHeadList.Add(obj);
            return objUserMenuAccessHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.UserMenuAccess_BL.get_UserMenuAccesss_single(model);

            }
            catch (Exception ex)
            {

                ReturnUserMenuAccessModelHead objUserMenuAccessHead = new ReturnUserMenuAccessModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserMenuAccessHeadList.Add(objUserMenuAccessHead);

                objError.WriteLog(0, "UserMenuAccessController", "get_UserMenuAccess_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenuAccessController", "get_UserMenuAccess_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenuAccessController", "get_UserMenuAccess_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenuAccessController", "get_UserMenuAccess_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objUserMenuAccessHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnUserMenuAccessModelHead> get_UserMenuAccess_all(UserMenuAccessSearchModel model)//ok
        {
            List<ReturnUserMenuAccessModelHead> objUserMenuAccessHeadList = new List<ReturnUserMenuAccessModelHead>();
            ReturnUserMenuAccessModelHead obj = new ReturnUserMenuAccessModelHead() { resp = false, msg = "sfsf" };
            obj.UserMenuAccess = new List<ReturnUserMenuAccessModel>();
            obj.UserMenuAccess.Add(new ReturnUserMenuAccessModel() { UUMA_UserMenuAccessID = 1, UUMA_AccessGroupID = "CAS", UUMA_MenuAccessID = "CAS", UUMA_Status = true });
            obj.UserMenuAccess.Add(new ReturnUserMenuAccessModel() { UUMA_UserMenuAccessID = 2, UUMA_AccessGroupID = "ANU", UUMA_MenuAccessID = "ANU", UUMA_Status = true });
            obj.UserMenuAccess.Add(new ReturnUserMenuAccessModel() { UUMA_UserMenuAccessID = 3, UUMA_AccessGroupID = "MED", UUMA_MenuAccessID = "MED", UUMA_Status = true });
            obj.UserMenuAccess.Add(new ReturnUserMenuAccessModel() { UUMA_UserMenuAccessID = 4, UUMA_AccessGroupID = "MAT", UUMA_MenuAccessID = "MAT", UUMA_Status = true });
            objUserMenuAccessHeadList.Add(obj);
            return objUserMenuAccessHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.UserMenuAccess_BL.get_UserMenuAccess_all(model);

            }
            catch (Exception ex)
            {

                ReturnUserMenuAccessModelHead objUserMenuAccessHead = new ReturnUserMenuAccessModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserMenuAccessHeadList.Add(objUserMenuAccessHead);

                objError.WriteLog(0, "UserMenuAccessController", "get_UserMenuAccess_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenuAccessController", "get_UserMenuAccess_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenuAccessController", "get_UserMenuAccess_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenuAccessController", "get_UserMenuAccess_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objUserMenuAccessHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> add_new_UserMenuAccess(UserMenuAccessModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.UserMenuAccess_BL.add_new_UserMenuAccess(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objUserMenuAccessHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objUserMenuAccessHead);

                objError.WriteLog(0, "UserMenuAccessController", "add_new_UserMenuAccess", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenuAccessController", "add_new_UserMenuAccess", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenuAccessController", "add_new_UserMenuAccess", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenuAccessController", "add_new_UserMenuAccess", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> modify_UserMenuAccess(UserMenuAccessModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.UserMenuAccess_BL.modify_UserMenuAccess(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objUserMenuAccessHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objUserMenuAccessHead);

                objError.WriteLog(0, "UserMenuAccessController", "modify_UserMenuAccess", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenuAccessController", "modify_UserMenuAccess", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenuAccessController", "modify_UserMenuAccess", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenuAccessController", "modify_UserMenuAccess", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_UserMenuAccess(InactiveUUMAModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.UserMenuAccess_BL.inactivate_UserMenuAccess(item);

            }
            catch (Exception ex)
            {
                ;
                ReturnResponse objUserMenuAccessHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserMenuAccessHead);

                objError.WriteLog(0, "UserMenuAccessController", "inactivate_UserMenuAccess", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenuAccessController", "inactivate_UserMenuAccess", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenuAccessController", "inactivate_UserMenuAccess", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenuAccessController", "inactivate_UserMenuAccess", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

