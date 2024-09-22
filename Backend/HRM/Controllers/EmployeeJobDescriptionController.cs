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

    public class EmployeeJobDescriptionController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnEmployeeJobDescriptionModelHead> get_EmployeeJobDescription_single(EmployeeJobDescription model)//ok
        {
            List<ReturnEmployeeJobDescriptionModelHead> objEmployeeJobDescriptionHeadList = new List<ReturnEmployeeJobDescriptionModelHead>();
            ReturnEmployeeJobDescriptionModelHead obj = new ReturnEmployeeJobDescriptionModelHead() { resp = false, msg = "sfsf" };
            obj.EmployeeJobDescription = new List<ReturnEmployeeJobDescriptionModel>();
        if (model.EEJ_EmployeeJobDescriptionID==1)    obj.EmployeeJobDescription.Add(new ReturnEmployeeJobDescriptionModel() { EEJ_EmployeeJobDescriptionID = 1, EEJ_EmployeeID = "test", EEJ_DepartmentID = "test", EEJ_JobDescriptionID = "test", EEJ_Status = true });
            if (model.EEJ_EmployeeJobDescriptionID == 2) obj.EmployeeJobDescription.Add(new ReturnEmployeeJobDescriptionModel() { EEJ_EmployeeJobDescriptionID = 2, EEJ_EmployeeID = "test1", EEJ_DepartmentID = "test1", EEJ_JobDescriptionID = "test1", EEJ_Status = true });
            if (model.EEJ_EmployeeJobDescriptionID == 3) obj.EmployeeJobDescription.Add(new ReturnEmployeeJobDescriptionModel() { EEJ_EmployeeJobDescriptionID = 3, EEJ_EmployeeID = "test2", EEJ_DepartmentID = "test2", EEJ_JobDescriptionID = "test2", EEJ_Status = true });
            objEmployeeJobDescriptionHeadList.Add(obj);
            return objEmployeeJobDescriptionHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.EmployeeJobDescription_BL.get_EmployeeJobDescriptions_single(model);

            }
            catch (Exception ex)
            {

                ReturnEmployeeJobDescriptionModelHead objEmployeeJobDescriptionHead = new ReturnEmployeeJobDescriptionModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objEmployeeJobDescriptionHeadList.Add(objEmployeeJobDescriptionHead);

                objError.WriteLog(0, "EmployeeJobDescriptionController", "get_EmployeeJobDescription_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeJobDescriptionController", "get_EmployeeJobDescription_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeJobDescriptionController", "get_EmployeeJobDescription_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeJobDescriptionController", "get_EmployeeJobDescription_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objEmployeeJobDescriptionHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnEmployeeJobDescriptionModelHead> get_EmployeeJobDescription_all(EmployeeJobDescriptionSearchModel model)//ok
        {
            List<ReturnEmployeeJobDescriptionModelHead> objEmployeeJobDescriptionHeadList = new List<ReturnEmployeeJobDescriptionModelHead>();
            ReturnEmployeeJobDescriptionModelHead obj = new ReturnEmployeeJobDescriptionModelHead() { resp = false, msg = "sfsf" };
            obj.EmployeeJobDescription = new List<ReturnEmployeeJobDescriptionModel>();
            obj.EmployeeJobDescription.Add(new ReturnEmployeeJobDescriptionModel() { EEJ_EmployeeJobDescriptionID =1 , EEJ_EmployeeID = "test", EEJ_DepartmentID= "test", EEJ_JobDescriptionID= "test", EEJ_Status=true});
            obj.EmployeeJobDescription.Add(new ReturnEmployeeJobDescriptionModel() { EEJ_EmployeeJobDescriptionID = 2, EEJ_EmployeeID = "test1", EEJ_DepartmentID = "test1", EEJ_JobDescriptionID = "test1", EEJ_Status = true });
            obj.EmployeeJobDescription.Add(new ReturnEmployeeJobDescriptionModel() { EEJ_EmployeeJobDescriptionID = 3, EEJ_EmployeeID = "test2", EEJ_DepartmentID = "test2", EEJ_JobDescriptionID = "test2", EEJ_Status = true });
            objEmployeeJobDescriptionHeadList.Add(obj);
            return objEmployeeJobDescriptionHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.EmployeeJobDescription_BL.get_EmployeeJobDescription_all(model);

            }
            catch (Exception ex)
            {

                ReturnEmployeeJobDescriptionModelHead objEmployeeJobDescriptionHead = new ReturnEmployeeJobDescriptionModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objEmployeeJobDescriptionHeadList.Add(objEmployeeJobDescriptionHead);

                objError.WriteLog(0, "EmployeeJobDescriptionController", "get_EmployeeJobDescription_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeJobDescriptionController", "get_EmployeeJobDescription_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeJobDescriptionController", "get_EmployeeJobDescription_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeJobDescriptionController", "get_EmployeeJobDescription_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objEmployeeJobDescriptionHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_EmployeeJobDescription(EmployeeJobDescriptionModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeJobDescription_BL.add_new_EmployeeJobDescription(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objEmployeeJobDescriptionHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objEmployeeJobDescriptionHead);

                objError.WriteLog(0, "EmployeeJobDescriptionController", "add_new_EmployeeJobDescription", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeJobDescriptionController", "add_new_EmployeeJobDescription", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeJobDescriptionController", "add_new_EmployeeJobDescription", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeJobDescriptionController", "add_new_EmployeeJobDescription", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_EmployeeJobDescription(EmployeeJobDescriptionModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeJobDescription_BL.modify_EmployeeJobDescription(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objEmployeeJobDescriptionHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objEmployeeJobDescriptionHead);

                objError.WriteLog(0, "EmployeeJobDescriptionController", "modify_EmployeeJobDescription", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeJobDescriptionController", "modify_EmployeeJobDescription", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeJobDescriptionController", "modify_EmployeeJobDescription", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeJobDescriptionController", "modify_EmployeeJobDescription", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_EmployeeJobDescription(InactiveEEJModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeJobDescription_BL.inactivate_EmployeeJobDescription(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objEmployeeJobDescriptionHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objEmployeeJobDescriptionHead);

                objError.WriteLog(0, "EmployeeJobDescriptionController", "inactivate_EmployeeJobDescription", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeJobDescriptionController", "inactivate_EmployeeJobDescription", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeJobDescriptionController", "inactivate_EmployeeJobDescription", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeJobDescriptionController", "inactivate_EmployeeJobDescription", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

