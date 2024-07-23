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

    public class UserAccessGroupController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnUserAccessGroupModelHead> get_UserAccessGroup_single(UserAccessGroup model)//ok
        {
            List<ReturnUserAccessGroupModelHead> objUserAccessGroupHeadList = new List<ReturnUserAccessGroupModelHead>();
            ReturnUserAccessGroupModelHead obj = new ReturnUserAccessGroupModelHead() { resp = false, msg = "sfsf" };
            obj.UserAccessGroup = new List<ReturnUserAccessGroupModel>();
            if (model.UUAG_UserAccessGroupID == "CAS")
                obj.UserAccessGroup.Add(new ReturnUserAccessGroupModel() { UUAG_UserAccessGroupID = 1, UUAG_UserName = "CAS", UUAG_MenuAccessID = "CAS", UUAG_Status = true });
            if (model.UUAG_UserAccessGroupID == "ANU") obj.UserAccessGroup.Add(new ReturnUserAccessGroupModel() { UUAG_UserAccessGroupID = 2, UUAG_UserName = "ANU", UUAG_MenuAccessID = "ANU", UUAG_Status = true });
            if (model.UUAG_UserAccessGroupID == "MED") obj.UserAccessGroup.Add(new ReturnUserAccessGroupModel() { UUAG_UserAccessGroupID = 3, UUAG_UserName = "MED", UUAG_MenuAccessID = "MED", UUAG_Status = true });
            if (model.UUAG_UserAccessGroupID == "MAT") obj.UserAccessGroup.Add(new ReturnUserAccessGroupModel() { UUAG_UserAccessGroupID = 4, UUAG_UserName = "MAT", UUAG_MenuAccessID = "MAT", UUAG_Status = true });
            objUserAccessGroupHeadList.Add(obj);
            return objUserAccessGroupHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.UserAccessGroup_BL.get_UserAccessGroups_single(model);

            }
            catch (Exception ex)
            {

                ReturnUserAccessGroupModelHead objUserAccessGroupHead = new ReturnUserAccessGroupModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserAccessGroupHeadList.Add(objUserAccessGroupHead);

                objError.WriteLog(0, "UserAccessGroupController", "get_UserAccessGroup_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserAccessGroupController", "get_UserAccessGroup_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserAccessGroupController", "get_UserAccessGroup_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserAccessGroupController", "get_UserAccessGroup_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objUserAccessGroupHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnUserAccessGroupModelHead> get_UserAccessGroup_all(UserAccessGroupSearchModel model)//ok
        {
            List<ReturnUserAccessGroupModelHead> objUserAccessGroupHeadList = new List<ReturnUserAccessGroupModelHead>();
            ReturnUserAccessGroupModelHead obj = new ReturnUserAccessGroupModelHead() { resp = false, msg = "sfsf" };
            obj.UserAccessGroup = new List<ReturnUserAccessGroupModel>();
            obj.UserAccessGroup.Add(new ReturnUserAccessGroupModel() { UUAG_UserAccessGroupID = 1, UUAG_UserName = "CAS", UUAG_MenuAccessID = "CAS", UUAG_Status = true });
            obj.UserAccessGroup.Add(new ReturnUserAccessGroupModel() { UUAG_UserAccessGroupID = 2, UUAG_UserName = "ANU", UUAG_MenuAccessID = "ANU", UUAG_Status = true });
            obj.UserAccessGroup.Add(new ReturnUserAccessGroupModel() { UUAG_UserAccessGroupID = 3, UUAG_UserName = "MED", UUAG_MenuAccessID = "MED", UUAG_Status = true });
            obj.UserAccessGroup.Add(new ReturnUserAccessGroupModel() { UUAG_UserAccessGroupID = 4, UUAG_UserName = "MAT", UUAG_MenuAccessID = "MAT", UUAG_Status = true });
            objUserAccessGroupHeadList.Add(obj);
            return objUserAccessGroupHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.UserAccessGroup_BL.get_UserAccessGroup_all(model);

            }
            catch (Exception ex)
            {

                ReturnUserAccessGroupModelHead objUserAccessGroupHead = new ReturnUserAccessGroupModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserAccessGroupHeadList.Add(objUserAccessGroupHead);

                objError.WriteLog(0, "UserAccessGroupController", "get_UserAccessGroup_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserAccessGroupController", "get_UserAccessGroup_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserAccessGroupController", "get_UserAccessGroup_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserAccessGroupController", "get_UserAccessGroup_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objUserAccessGroupHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> add_new_UserAccessGroup(UserAccessGroupModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.UserAccessGroup_BL.add_new_UserAccessGroup(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objUserAccessGroupHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objUserAccessGroupHead);

                objError.WriteLog(0, "UserAccessGroupController", "add_new_UserAccessGroup", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserAccessGroupController", "add_new_UserAccessGroup", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserAccessGroupController", "add_new_UserAccessGroup", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserAccessGroupController", "add_new_UserAccessGroup", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> modify_UserAccessGroup(UserAccessGroupModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.UserAccessGroup_BL.modify_UserAccessGroup(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objUserAccessGroupHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objUserAccessGroupHead);

                objError.WriteLog(0, "UserAccessGroupController", "modify_UserAccessGroup", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserAccessGroupController", "modify_UserAccessGroup", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserAccessGroupController", "modify_UserAccessGroup", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserAccessGroupController", "modify_UserAccessGroup", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_UserAccessGroup(InactiveUUMAModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.UserAccessGroup_BL.inactivate_UserAccessGroup(item);

            }
            catch (Exception ex)
            {
                ;
                ReturnResponse objUserAccessGroupHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserAccessGroupHead);

                objError.WriteLog(0, "UserAccessGroupController", "inactivate_UserAccessGroup", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserAccessGroupController", "inactivate_UserAccessGroup", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserAccessGroupController", "inactivate_UserAccessGroup", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserAccessGroupController", "inactivate_UserAccessGroup", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

