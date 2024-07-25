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

    public class JobRoleController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnJobRoleModelHead> get_JobRole_single(JobRole model)//ok
        {
            List<ReturnJobRoleModelHead> objJobRoleHeadList = new List<ReturnJobRoleModelHead>();
            ReturnJobRoleModelHead obj = new ReturnJobRoleModelHead() { resp = false, msg = "sfsf" };
            obj.JobRole = new List<ReturnJobRoleModel>();
            if (model.MDJR_JobRoleID == "CAS")
                obj.JobRole.Add(new ReturnJobRoleModel() { MDJR_JobRoleID = "CAS", MDJR_JobRole = "Casual", MDJR_Status = true });
            if (model.MDJR_JobRoleID == "ANU") obj.JobRole.Add(new ReturnJobRoleModel() { MDJR_JobRoleID = "ANU", MDJR_JobRole = "Annual", MDJR_Status = true });
            if (model.MDJR_JobRoleID == "MED") obj.JobRole.Add(new ReturnJobRoleModel() { MDJR_JobRoleID = "MED", MDJR_JobRole = "Medical", MDJR_Status = true });
            if (model.MDJR_JobRoleID == "MAT") obj.JobRole.Add(new ReturnJobRoleModel() { MDJR_JobRoleID = "MAT", MDJR_JobRole = "Matrinaty", MDJR_Status = true });
            objJobRoleHeadList.Add(obj);
            return objJobRoleHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.JobRole_BL.get_JobRoles_single(model);

            }
            catch (Exception ex)
            {

                ReturnJobRoleModelHead objJobRoleHead = new ReturnJobRoleModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objJobRoleHeadList.Add(objJobRoleHead);

                objError.WriteLog(0, "JobRoleController", "get_JobRole_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "JobRoleController", "get_JobRole_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "JobRoleController", "get_JobRole_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "JobRoleController", "get_JobRole_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objJobRoleHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnJobRoleModelHead> get_JobRole_all(JobRoleSearchModel model)//ok
        {
            List<ReturnJobRoleModelHead> objJobRoleHeadList = new List<ReturnJobRoleModelHead>();
            ReturnJobRoleModelHead obj = new ReturnJobRoleModelHead() { resp = false, msg = "sfsf" };
            obj.JobRole = new List<ReturnJobRoleModel>();
            obj.JobRole.Add(new ReturnJobRoleModel() { MDJR_JobRoleID = "CAS", MDJR_JobRole = "Casual", MDJR_Status = true });
            obj.JobRole.Add(new ReturnJobRoleModel() { MDJR_JobRoleID = "ANU", MDJR_JobRole = "Annual", MDJR_Status = true });
            obj.JobRole.Add(new ReturnJobRoleModel() { MDJR_JobRoleID = "MED", MDJR_JobRole = "Medical", MDJR_Status = true });
            obj.JobRole.Add(new ReturnJobRoleModel() { MDJR_JobRoleID = "MAT", MDJR_JobRole = "Matrinaty", MDJR_Status = true });
            objJobRoleHeadList.Add(obj);
            return objJobRoleHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.JobRole_BL.get_JobRole_all(model);

            }
            catch (Exception ex)
            {

                ReturnJobRoleModelHead objJobRoleHead = new ReturnJobRoleModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objJobRoleHeadList.Add(objJobRoleHead);

                objError.WriteLog(0, "JobRoleController", "get_JobRole_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "JobRoleController", "get_JobRole_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "JobRoleController", "get_JobRole_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "JobRoleController", "get_JobRole_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objJobRoleHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> add_new_JobRole(JobRoleModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.JobRole_BL.add_new_JobRole(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objJobRoleHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objJobRoleHead);

                objError.WriteLog(0, "JobRoleController", "add_new_JobRole", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "JobRoleController", "add_new_JobRole", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "JobRoleController", "add_new_JobRole", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "JobRoleController", "add_new_JobRole", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> modify_JobRole(JobRoleModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.JobRole_BL.modify_JobRole(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objJobRoleHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objJobRoleHead);

                objError.WriteLog(0, "JobRoleController", "modify_JobRole", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "JobRoleController", "modify_JobRole", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "JobRoleController", "modify_JobRole", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "JobRoleController", "modify_JobRole", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_JobRole(InactiveMDJRModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.JobRole_BL.inactivate_JobRole(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objJobRoleHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objJobRoleHead);

                objError.WriteLog(0, "JobRoleController", "inactivate_JobRole", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "JobRoleController", "inactivate_JobRole", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "JobRoleController", "inactivate_JobRole", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "JobRoleController", "inactivate_JobRole", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

