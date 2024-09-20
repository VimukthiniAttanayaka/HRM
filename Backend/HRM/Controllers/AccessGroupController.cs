﻿using HRM_DAL.Models;
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
            List<AccessGroupSelect> AccessGroups = new List<AccessGroupSelect>();
            AccessGroups.Add(new AccessGroupSelect() { value = "CAS", label = "CAS", Ischecked = true });
            AccessGroups.Add(new AccessGroupSelect() { value = "ANU", label = "ANU", Ischecked = true });
            AccessGroups.Add(new AccessGroupSelect() { value = "MED", label = "MED", Ischecked = true });

            if (model.UAG_AccessGroupID == "CAS")
                obj.AccessGroup.Add(new ReturnAccessGroupModel() { UAG_AccessGroupID = "CAS", UAG_AccessGroup = "Casual", UAG_Status = true, AccessGroups = AccessGroups });
            else if (model.UAG_AccessGroupID == "ANU") obj.AccessGroup.Add(new ReturnAccessGroupModel() { UAG_AccessGroupID = "ANU", UAG_AccessGroup = "Annual", UAG_Status = true, AccessGroups = AccessGroups });
            else if (model.UAG_AccessGroupID == "MED") obj.AccessGroup.Add(new ReturnAccessGroupModel() { UAG_AccessGroupID = "MED", UAG_AccessGroup = "Medical", UAG_Status = true, AccessGroups = AccessGroups });
            else if (model.UAG_AccessGroupID == "MAT") obj.AccessGroup.Add(new ReturnAccessGroupModel() { UAG_AccessGroupID = "MAT", UAG_AccessGroup = "Matrinaty", UAG_Status = true, AccessGroups = AccessGroups });

            else obj.AccessGroup.Add(new ReturnAccessGroupModel() { UAG_AccessGroupID = "MAT", UAG_AccessGroup = "Matrinaty", UAG_Status = true, AccessGroups = AccessGroups });

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
            obj.AccessGroup.Add(new ReturnAccessGroupModel() { UAG_AccessGroupID = "CAS", UAG_AccessGroup = "Casual", UAG_Status = true });
            obj.AccessGroup.Add(new ReturnAccessGroupModel() { UAG_AccessGroupID = "ANU", UAG_AccessGroup = "Annual", UAG_Status = true });
            obj.AccessGroup.Add(new ReturnAccessGroupModel() { UAG_AccessGroupID = "MED", UAG_AccessGroup = "Medical", UAG_Status = true });
            obj.AccessGroup.Add(new ReturnAccessGroupModel() { UAG_AccessGroupID = "MAT", UAG_AccessGroup = "Matrinaty", UAG_Status = true });
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

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnAccessGroupModelHead> get_accessgroup_all_ForUser(AccessGroupSearchModel model)//ok
        {
            List<ReturnAccessGroupModelHead> objAccessGroupHeadList = new List<ReturnAccessGroupModelHead>();
            ReturnAccessGroupModelHead obj = new ReturnAccessGroupModelHead() { resp = false, msg = "sfsf" };
            obj.AccessGroup = new List<ReturnAccessGroupModel>();
            obj.AccessGroup.Add(new ReturnAccessGroupModel() { UAG_AccessGroupID = "CAS", UAG_AccessGroup = "Casual", UAG_Status = true });
            obj.AccessGroup.Add(new ReturnAccessGroupModel() { UAG_AccessGroupID = "ANU", UAG_AccessGroup = "Annual", UAG_Status = true });
            obj.AccessGroup.Add(new ReturnAccessGroupModel() { UAG_AccessGroupID = "MED", UAG_AccessGroup = "Medical", UAG_Status = true });
            obj.AccessGroup.Add(new ReturnAccessGroupModel() { UAG_AccessGroupID = "MAT", UAG_AccessGroup = "Matrinaty", UAG_Status = true });
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

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> GrantAccess(GrantRemoveAccessModel model)
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                //return HRM_BL.AccessGroup_BL.add_new_AccessGroup(model);

            }
            catch (Exception ex)
            {

                ReturnResponse objAccessGroupHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objAccessGroupHead);

                objError.WriteLog(0, "AccessGroupController", "GrantAccess", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "AccessGroupController", "GrantAccess", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "AccessGroupController", "GrantAccess", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "AccessGroupController", "GrantAccess", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }
                  [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> RemoveAccess(GrantRemoveAccessModel model)
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                //return HRM_BL.AccessGroup_BL.add_new_AccessGroup(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objAccessGroupHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objAccessGroupHead);

                objError.WriteLog(0, "AccessGroupController", "RemoveAccess", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "AccessGroupController", "RemoveAccess", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "AccessGroupController", "RemoveAccess", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "AccessGroupController", "RemoveAccess", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
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

