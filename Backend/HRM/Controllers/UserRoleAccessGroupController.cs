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

    public class UserRoleAccessGroupController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnUserRoleAccessGroupModelHead> get_UserRoleAccessGroup_single(UserRoleAccessGroup model)//ok
        {
            List<ReturnUserRoleAccessGroupModelHead> objUserRoleAccessGroupHeadList = new List<ReturnUserRoleAccessGroupModelHead>();
            ReturnUserRoleAccessGroupModelHead obj = new ReturnUserRoleAccessGroupModelHead() { resp = false, msg = "sfsf" };
            obj.UserRoleAccessGroup = new List<ReturnUserRoleAccessGroupModel>();
            if (model.UURAG_UserRoleAccessGroupID == "CAS")
                obj.UserRoleAccessGroup.Add(new ReturnUserRoleAccessGroupModel() { UURAG_UserRoleAccessGroupID = 1, UURAG_UserName = "CAS", UURAG_MenuAccessID = "CAS", UURAG_Status = true });
            if (model.UURAG_UserRoleAccessGroupID == "ANU") obj.UserRoleAccessGroup.Add(new ReturnUserRoleAccessGroupModel() { UURAG_UserRoleAccessGroupID = 2, UURAG_UserName = "ANU", UURAG_MenuAccessID = "ANU", UURAG_Status = true });
            if (model.UURAG_UserRoleAccessGroupID == "MED") obj.UserRoleAccessGroup.Add(new ReturnUserRoleAccessGroupModel() { UURAG_UserRoleAccessGroupID = 3, UURAG_UserName = "MED", UURAG_MenuAccessID = "MED", UURAG_Status = true });
            if (model.UURAG_UserRoleAccessGroupID == "MAT") obj.UserRoleAccessGroup.Add(new ReturnUserRoleAccessGroupModel() { UURAG_UserRoleAccessGroupID = 4, UURAG_UserName = "MAT", UURAG_MenuAccessID = "MAT", UURAG_Status = true });
            objUserRoleAccessGroupHeadList.Add(obj);
            return objUserRoleAccessGroupHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.UserRoleAccessGroup_BL.get_UserRoleAccessGroups_single(model);

            }
            catch (Exception ex)
            {

                ReturnUserRoleAccessGroupModelHead objUserRoleAccessGroupHead = new ReturnUserRoleAccessGroupModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserRoleAccessGroupHeadList.Add(objUserRoleAccessGroupHead);

                objError.WriteLog(0, "UserRoleAccessGroupController", "get_UserRoleAccessGroup_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserRoleAccessGroupController", "get_UserRoleAccessGroup_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserRoleAccessGroupController", "get_UserRoleAccessGroup_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserRoleAccessGroupController", "get_UserRoleAccessGroup_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objUserRoleAccessGroupHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnUserRoleAccessGroupModelHead> get_UserRoleAccessGroup_all(UserRoleAccessGroupSearchModel model)//ok
        {
            List<ReturnUserRoleAccessGroupModelHead> objUserRoleAccessGroupHeadList = new List<ReturnUserRoleAccessGroupModelHead>();
            ReturnUserRoleAccessGroupModelHead obj = new ReturnUserRoleAccessGroupModelHead() { resp = false, msg = "sfsf" };
            obj.UserRoleAccessGroup = new List<ReturnUserRoleAccessGroupModel>();
            obj.UserRoleAccessGroup.Add(new ReturnUserRoleAccessGroupModel() { UURAG_UserRoleAccessGroupID = 1, UURAG_UserName = "CAS", UURAG_MenuAccessID = "CAS", UURAG_Status = true });
            obj.UserRoleAccessGroup.Add(new ReturnUserRoleAccessGroupModel() { UURAG_UserRoleAccessGroupID = 2, UURAG_UserName = "ANU", UURAG_MenuAccessID = "ANU", UURAG_Status = true });
            obj.UserRoleAccessGroup.Add(new ReturnUserRoleAccessGroupModel() { UURAG_UserRoleAccessGroupID = 3, UURAG_UserName = "MED", UURAG_MenuAccessID = "MED", UURAG_Status = true });
            obj.UserRoleAccessGroup.Add(new ReturnUserRoleAccessGroupModel() { UURAG_UserRoleAccessGroupID = 4, UURAG_UserName = "MAT", UURAG_MenuAccessID = "MAT", UURAG_Status = true });
            objUserRoleAccessGroupHeadList.Add(obj);
            return objUserRoleAccessGroupHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.UserRoleAccessGroup_BL.get_UserRoleAccessGroup_all(model);

            }
            catch (Exception ex)
            {

                ReturnUserRoleAccessGroupModelHead objUserRoleAccessGroupHead = new ReturnUserRoleAccessGroupModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserRoleAccessGroupHeadList.Add(objUserRoleAccessGroupHead);

                objError.WriteLog(0, "UserRoleAccessGroupController", "get_UserRoleAccessGroup_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserRoleAccessGroupController", "get_UserRoleAccessGroup_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserRoleAccessGroupController", "get_UserRoleAccessGroup_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserRoleAccessGroupController", "get_UserRoleAccessGroup_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objUserRoleAccessGroupHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> add_new_UserRoleAccessGroup(UserRoleAccessGroupModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.UserRoleAccessGroup_BL.add_new_UserRoleAccessGroup(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objUserRoleAccessGroupHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objUserRoleAccessGroupHead);

                objError.WriteLog(0, "UserRoleAccessGroupController", "add_new_UserRoleAccessGroup", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserRoleAccessGroupController", "add_new_UserRoleAccessGroup", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserRoleAccessGroupController", "add_new_UserRoleAccessGroup", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserRoleAccessGroupController", "add_new_UserRoleAccessGroup", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> modify_UserRoleAccessGroup(UserRoleAccessGroupModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.UserRoleAccessGroup_BL.modify_UserRoleAccessGroup(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objUserRoleAccessGroupHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objUserRoleAccessGroupHead);

                objError.WriteLog(0, "UserRoleAccessGroupController", "modify_UserRoleAccessGroup", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserRoleAccessGroupController", "modify_UserRoleAccessGroup", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserRoleAccessGroupController", "modify_UserRoleAccessGroup", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserRoleAccessGroupController", "modify_UserRoleAccessGroup", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_UserRoleAccessGroup(InactiveUUMAModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.UserRoleAccessGroup_BL.inactivate_UserRoleAccessGroup(item);

            }
            catch (Exception ex)
            {
                ;
                ReturnResponse objUserRoleAccessGroupHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserRoleAccessGroupHead);

                objError.WriteLog(0, "UserRoleAccessGroupController", "inactivate_UserRoleAccessGroup", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserRoleAccessGroupController", "inactivate_UserRoleAccessGroup", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserRoleAccessGroupController", "inactivate_UserRoleAccessGroup", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserRoleAccessGroupController", "inactivate_UserRoleAccessGroup", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

