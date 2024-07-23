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

    public class MenuAccessGroupController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnMenuAccessModelHead> get_MenuAccessGroup_single(MenuAccess model)//ok
        {
            List<ReturnMenuAccessModelHead> objMenuAccessHeadList = new List<ReturnMenuAccessModelHead>();
            ReturnMenuAccessModelHead obj = new ReturnMenuAccessModelHead() { resp = false, msg = "sfsf" };
            obj.MenuAccessGroup = new List<ReturnMenuAccessModel>();

            if (model.UMA_MenuAccessID == "CAS") obj.MenuAccessGroup.Add(new ReturnMenuAccessModel() { UMA_MenuAccessID = 1, UMA_UserMenuID = "CAS", UMA_AccessGroupID = "CAS", UMA_Status = true });
            if (model.UMA_MenuAccessID == "ANU") obj.MenuAccessGroup.Add(new ReturnMenuAccessModel() { UMA_MenuAccessID = 2, UMA_UserMenuID = "ANU", UMA_AccessGroupID = "ANU", UMA_Status = true });
            if (model.UMA_MenuAccessID == "MED") obj.MenuAccessGroup.Add(new ReturnMenuAccessModel() { UMA_MenuAccessID = 3, UMA_UserMenuID = "MED", UMA_AccessGroupID = "MED", UMA_Status = true });
            if (model.UMA_MenuAccessID == "MAT") obj.MenuAccessGroup.Add(new ReturnMenuAccessModel() { UMA_MenuAccessID = 4, UMA_UserMenuID = "MAT", UMA_AccessGroupID = "MAT", UMA_Status = true });
            objMenuAccessHeadList.Add(obj);
            return objMenuAccessHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.MenuAccess_BL.get_MenuAccesss_single(model);

            }
            catch (Exception ex)
            {

                ReturnMenuAccessModelHead objMenuAccessHead = new ReturnMenuAccessModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMenuAccessHeadList.Add(objMenuAccessHead);

                objError.WriteLog(0, "MenuAccessGroupController", "get_MenuAccessGroup_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MenuAccessGroupController", "get_MenuAccessGroup_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MenuAccessGroupController", "get_MenuAccessGroup_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MenuAccessGroupController", "get_MenuAccessGroup_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objMenuAccessHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnMenuAccessModelHead> get_MenuAccessGroup_all(MenuAccessSearchModel model)//ok
        {
            List<ReturnMenuAccessModelHead> objMenuAccessHeadList = new List<ReturnMenuAccessModelHead>();
            ReturnMenuAccessModelHead obj = new ReturnMenuAccessModelHead() { resp = false, msg = "sfsf" };
            obj.MenuAccessGroup = new List<ReturnMenuAccessModel>();
            obj.MenuAccessGroup.Add(new ReturnMenuAccessModel() { UMA_MenuAccessID = 1, UMA_UserMenuID = "CAS", UMA_AccessGroupID = "CAS", UMA_Status = true });
            obj.MenuAccessGroup.Add(new ReturnMenuAccessModel() { UMA_MenuAccessID = 2, UMA_UserMenuID = "ANU", UMA_AccessGroupID = "ANU", UMA_Status = true });
            obj.MenuAccessGroup.Add(new ReturnMenuAccessModel() { UMA_MenuAccessID = 3, UMA_UserMenuID = "MED", UMA_AccessGroupID = "MED", UMA_Status = true });
            obj.MenuAccessGroup.Add(new ReturnMenuAccessModel() { UMA_MenuAccessID = 4, UMA_UserMenuID = "MAT", UMA_AccessGroupID = "MAT", UMA_Status = true });
            objMenuAccessHeadList.Add(obj);
            return objMenuAccessHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.MenuAccess_BL.get_MenuAccess_all(model);

            }
            catch (Exception ex)
            {

                ReturnMenuAccessModelHead objMenuAccessHead = new ReturnMenuAccessModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMenuAccessHeadList.Add(objMenuAccessHead);

                objError.WriteLog(0, "MenuAccessGroupController", "get_MenuAccessGroup_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MenuAccessGroupController", "get_MenuAccessGroup_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MenuAccessGroupController", "get_MenuAccessGroup_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MenuAccessGroupController", "get_MenuAccessGroup_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objMenuAccessHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> add_new_MenuAccess(MenuAccessModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.MenuAccess_BL.add_new_MenuAccess(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objMenuAccessHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objMenuAccessHead);

                objError.WriteLog(0, "MenuAccessGroupController", "add_new_MenuAccess", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MenuAccessGroupController", "add_new_MenuAccess", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MenuAccessGroupController", "add_new_MenuAccess", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MenuAccessGroupController", "add_new_MenuAccess", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> modify_MenuAccess(MenuAccessModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.MenuAccess_BL.modify_MenuAccess(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objMenuAccessHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objMenuAccessHead);

                objError.WriteLog(0, "MenuAccessGroupController", "modify_MenuAccess", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MenuAccessGroupController", "modify_MenuAccess", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MenuAccessGroupController", "modify_MenuAccess", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MenuAccessGroupController", "modify_MenuAccess", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_MenuAccess(InactiveUMAModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.MenuAccess_BL.inactivate_MenuAccess(item);

            }
            catch (Exception ex)
            {
                ;
                ReturnResponse objMenuAccessHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objMenuAccessHead);

                objError.WriteLog(0, "MenuAccessGroupController", "inactivate_MenuAccess", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MenuAccessGroupController", "inactivate_MenuAccess", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MenuAccessGroupController", "inactivate_MenuAccess", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MenuAccessGroupController", "inactivate_MenuAccess", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

