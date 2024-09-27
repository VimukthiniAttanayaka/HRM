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

    public class JobTypeController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnJobTypeModelHead> get_JobType_single(JobType model)//ok
        {
            List<ReturnJobTypeModelHead> objJobTypeHeadList = new List<ReturnJobTypeModelHead>();
            //ReturnJobTypeModelHead obj = new ReturnJobTypeModelHead() { resp = false, msg = "sfsf" };
            //obj.JobType = new List<ReturnJobTypeModel>();
            //if (model.MDJT_JobTypeID == "CAS")
            //    obj.JobType.Add(new ReturnJobTypeModel() { MDJT_JobTypeID = "CAS", MDJT_JobType = "Casual", MDJT_Status = true });
            //if (model.MDJT_JobTypeID == "ANU") obj.JobType.Add(new ReturnJobTypeModel() { MDJT_JobTypeID = "ANU", MDJT_JobType = "Annual", MDJT_Status = true });
            //if (model.MDJT_JobTypeID == "MED") obj.JobType.Add(new ReturnJobTypeModel() { MDJT_JobTypeID = "MED", MDJT_JobType = "Medical", MDJT_Status = true });
            //if (model.MDJT_JobTypeID == "MAT") obj.JobType.Add(new ReturnJobTypeModel() { MDJT_JobTypeID = "MAT", MDJT_JobType = "Matrinaty", MDJT_Status = true });
            //objJobTypeHeadList.Add(obj);
            //return objJobTypeHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.JobType_BL.get_JobTypes_single(model);

            }
            catch (Exception ex)
            {

                ReturnJobTypeModelHead objJobTypeHead = new ReturnJobTypeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objJobTypeHeadList.Add(objJobTypeHead);

                objError.WriteLog(0, "JobTypeController", "get_JobType_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "JobTypeController", "get_JobType_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "JobTypeController", "get_JobType_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "JobTypeController", "get_JobType_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objJobTypeHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnJobTypeModelHead> get_JobType_all(JobTypeSearchModel model)//ok
        {
            List<ReturnJobTypeModelHead> objJobTypeHeadList = new List<ReturnJobTypeModelHead>();
            //ReturnJobTypeModelHead obj = new ReturnJobTypeModelHead() { resp = false, msg = "sfsf", RC = 100 };
            //obj.JobType = new List<ReturnJobTypeModel>();
            //obj.JobType.Add(new ReturnJobTypeModel() { MDJT_JobTypeID = "CAS", MDJT_JobType = "Casual", MDJT_Status = true });
            //obj.JobType.Add(new ReturnJobTypeModel() { MDJT_JobTypeID = "ANU", MDJT_JobType = "Annual", MDJT_Status = false });
            //obj.JobType.Add(new ReturnJobTypeModel() { MDJT_JobTypeID = "MED", MDJT_JobType = "Medical", MDJT_Status = true });
            //obj.JobType.Add(new ReturnJobTypeModel() { MDJT_JobTypeID = "MAT", MDJT_JobType = "Matrinaty", MDJT_Status = true });
            //obj.JobType.Add(new ReturnJobTypeModel() { MDJT_JobTypeID = "CAS", MDJT_JobType = "Casual", MDJT_Status = true });
            //for (int i = 0; i < 100; i++)
            //{
            //    obj.JobType.Add(new ReturnJobTypeModel() { MDJT_JobTypeID = "CAS", MDJT_JobType = "Casual", MDJT_Status = true });

            //}
            //objJobTypeHeadList.Add(obj);
            //return objJobTypeHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.JobType_BL.get_JobType_all(model);

            }
            catch (Exception ex)
            {

                ReturnJobTypeModelHead objJobTypeHead = new ReturnJobTypeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objJobTypeHeadList.Add(objJobTypeHead);

                objError.WriteLog(0, "JobTypeController", "get_JobType_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "JobTypeController", "get_JobType_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "JobTypeController", "get_JobType_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "JobTypeController", "get_JobType_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objJobTypeHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_JobType(JobTypeModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.JobType_BL.add_new_JobType(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objJobTypeHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objJobTypeHead);

                objError.WriteLog(0, "JobTypeController", "add_new_JobType", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "JobTypeController", "add_new_JobType", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "JobTypeController", "add_new_JobType", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "JobTypeController", "add_new_JobType", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_JobType(JobTypeModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.JobType_BL.modify_JobType(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objJobTypeHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objJobTypeHead);

                objError.WriteLog(0, "JobTypeController", "modify_JobType", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "JobTypeController", "modify_JobType", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "JobTypeController", "modify_JobType", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "JobTypeController", "modify_JobType", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_JobType(InactiveMDJTModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            //objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            //return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.JobType_BL.inactivate_JobType(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objJobTypeHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objJobTypeHead);

                objError.WriteLog(0, "JobTypeController", "inactivate_JobType", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "JobTypeController", "inactivate_JobType", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "JobTypeController", "inactivate_JobType", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "JobTypeController", "inactivate_JobType", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

