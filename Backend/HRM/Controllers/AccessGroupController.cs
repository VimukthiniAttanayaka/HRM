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

    public class AccessGroupController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnAccessGroupModelHead> get_AccessGroup_single(AccessGroup model)//ok
        {
            List<ReturnAccessGroupModelHead> objAccessGroupHeadList = new List<ReturnAccessGroupModelHead>();
            ReturnAccessGroupModelHead obj = new ReturnAccessGroupModelHead() { resp = false, msg = "sfsf" };
            obj.AccessGroup = new List<ReturnAccessGroupModel>();
            if (model.EUG_AccessGroupID == "CAS")
                obj.AccessGroup.Add(new ReturnAccessGroupModel() { EUG_AccessGroupID = "CAS", EUG_AccessGroup = "Casual", EUG_Status = true });
            if (model.EUG_AccessGroupID == "ANU") obj.AccessGroup.Add(new ReturnAccessGroupModel() { EUG_AccessGroupID = "ANU", EUG_AccessGroup = "Annual", EUG_Status = true });
            if (model.EUG_AccessGroupID == "MED") obj.AccessGroup.Add(new ReturnAccessGroupModel() { EUG_AccessGroupID = "MED", EUG_AccessGroup = "Medical", EUG_Status = true });
            if (model.EUG_AccessGroupID == "MAT") obj.AccessGroup.Add(new ReturnAccessGroupModel() { EUG_AccessGroupID = "MAT", EUG_AccessGroup = "Matrinaty", EUG_Status = true });
            objAccessGroupHeadList.Add(obj);
            return objAccessGroupHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.AccessGroup_BL.get_AccessGroups_single(model);

            }
            catch (Exception ex)
            {

                ReturnAccessGroupModelHead objAccessGroupHead = new ReturnAccessGroupModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objAccessGroupHeadList.Add(objAccessGroupHead);

                objError.WriteLog(0, "AccessGroupController", "get_AccessGroup_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "AccessGroupController", "get_AccessGroup_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "AccessGroupController", "get_AccessGroup_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "AccessGroupController", "get_AccessGroup_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objAccessGroupHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnAccessGroupModelHead> get_AccessGroup_all(AccessGroupSearchModel model)//ok
        {
            List<ReturnAccessGroupModelHead> objAccessGroupHeadList = new List<ReturnAccessGroupModelHead>();
            ReturnAccessGroupModelHead obj = new ReturnAccessGroupModelHead() { resp = false, msg = "sfsf" };
            obj.AccessGroup = new List<ReturnAccessGroupModel>();
            obj.AccessGroup.Add(new ReturnAccessGroupModel() { EUG_AccessGroupID = "CAS", EUG_AccessGroup = "Casual", EUG_Status = true });
            obj.AccessGroup.Add(new ReturnAccessGroupModel() { EUG_AccessGroupID = "ANU", EUG_AccessGroup = "Annual", EUG_Status = true });
            obj.AccessGroup.Add(new ReturnAccessGroupModel() { EUG_AccessGroupID = "MED", EUG_AccessGroup = "Medical", EUG_Status = true });
            obj.AccessGroup.Add(new ReturnAccessGroupModel() { EUG_AccessGroupID = "MAT", EUG_AccessGroup = "Matrinaty", EUG_Status = true });
            objAccessGroupHeadList.Add(obj);
            return objAccessGroupHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.AccessGroup_BL.get_AccessGroup_all(model);

            }
            catch (Exception ex)
            {

                ReturnAccessGroupModelHead objAccessGroupHead = new ReturnAccessGroupModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objAccessGroupHeadList.Add(objAccessGroupHead);

                objError.WriteLog(0, "AccessGroupController", "get_AccessGroup_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "AccessGroupController", "get_AccessGroup_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "AccessGroupController", "get_AccessGroup_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "AccessGroupController", "get_AccessGroup_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objAccessGroupHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> add_new_AccessGroup(AccessGroupModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.AccessGroup_BL.add_new_AccessGroup(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objAccessGroupHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objAccessGroupHead);

                objError.WriteLog(0, "AccessGroupController", "add_new_AccessGroup", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "AccessGroupController", "add_new_AccessGroup", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "AccessGroupController", "add_new_AccessGroup", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "AccessGroupController", "add_new_AccessGroup", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> modify_AccessGroup(AccessGroupModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.AccessGroup_BL.modify_AccessGroup(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objAccessGroupHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objAccessGroupHead);

                objError.WriteLog(0, "AccessGroupController", "modify_AccessGroup", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "AccessGroupController", "modify_AccessGroup", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "AccessGroupController", "modify_AccessGroup", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "AccessGroupController", "modify_AccessGroup", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_AccessGroup(InactiveEUGModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.AccessGroup_BL.inactivate_AccessGroup(item);

            }
            catch (Exception ex)
            {
                ;
                ReturnResponse objAccessGroupHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objAccessGroupHead);

                objError.WriteLog(0, "AccessGroupController", "inactivate_AccessGroup", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "AccessGroupController", "inactivate_AccessGroup", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "AccessGroupController", "inactivate_AccessGroup", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "AccessGroupController", "inactivate_AccessGroup", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

