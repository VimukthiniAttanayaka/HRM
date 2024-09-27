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

    public class EmployeeSalaryController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnEmployeeSalaryModelHead> get_EmployeeSalary_single(EmployeeSalary model)//ok
        {
            List<ReturnEmployeeSalaryModelHead> objEmployeeSalaryHeadList = new List<ReturnEmployeeSalaryModelHead>();
            //ReturnEmployeeSalaryModelHead obj = new ReturnEmployeeSalaryModelHead() { resp = false, msg = "sfsf" };
            //obj.EmployeeSalary = new List<ReturnEmployeeSalaryModel>();
            //if (model.EEJ_JobDescriptionID == 1) obj.EmployeeSalary.Add(new ReturnEmployeeSalaryModel() { EEJ_ID = 1, EEJ_EmployeeID = "test", EEJ_SalaryID = "test", EEJ_Status = true });
            //if (model.EEJ_JobDescriptionID == 2) obj.EmployeeSalary.Add(new ReturnEmployeeSalaryModel() { EEJ_ID = 2, EEJ_EmployeeID = "test1", EEJ_SalaryID = "test1", EEJ_Status = true });
            //if (model.EEJ_JobDescriptionID == 3) obj.EmployeeSalary.Add(new ReturnEmployeeSalaryModel() { EEJ_ID = 3, EEJ_EmployeeID = "test2", EEJ_SalaryID = "test2", EEJ_Status = true });
            //objEmployeeSalaryHeadList.Add(obj);
            //return objEmployeeSalaryHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.EmployeeSalary_BL.get_EmployeeSalary_single(model);

            }
            catch (Exception ex)
            {

                ReturnEmployeeSalaryModelHead objEmployeeSalaryHead = new ReturnEmployeeSalaryModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objEmployeeSalaryHeadList.Add(objEmployeeSalaryHead);

                objError.WriteLog(0, "EmployeeSalaryController", "get_EmployeeSalary_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeSalaryController", "get_EmployeeSalary_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeSalaryController", "get_EmployeeSalary_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeSalaryController", "get_EmployeeSalary_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objEmployeeSalaryHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnEmployeeSalaryModelHead> get_EmployeeSalary_all(EmployeeSalarySearchModel model)//ok
        {
            List<ReturnEmployeeSalaryModelHead> objEmployeeSalaryHeadList = new List<ReturnEmployeeSalaryModelHead>();
            //ReturnEmployeeSalaryModelHead obj = new ReturnEmployeeSalaryModelHead() { resp = false, msg = "sfsf" };
            //obj.EmployeeSalary = new List<ReturnEmployeeSalaryModel>();
            //obj.EmployeeSalary.Add(new ReturnEmployeeSalaryModel() { EEJ_ID = 1, EEJ_EmployeeID = "test", EEJ_SalaryID = "test", EEJ_Status = true });
            //obj.EmployeeSalary.Add(new ReturnEmployeeSalaryModel() { EEJ_ID = 2, EEJ_EmployeeID = "test1", EEJ_SalaryID = "test1", EEJ_Status = true });
            //obj.EmployeeSalary.Add(new ReturnEmployeeSalaryModel() { EEJ_ID = 3, EEJ_EmployeeID = "test2", EEJ_SalaryID = "test2", EEJ_Status = true });
            //objEmployeeSalaryHeadList.Add(obj);
            //return objEmployeeSalaryHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.EmployeeSalary_BL.get_EmployeeSalary_all(model);

            }
            catch (Exception ex)
            {

                ReturnEmployeeSalaryModelHead objEmployeeSalaryHead = new ReturnEmployeeSalaryModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objEmployeeSalaryHeadList.Add(objEmployeeSalaryHead);

                objError.WriteLog(0, "EmployeeSalaryController", "get_EmployeeSalary_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeSalaryController", "get_EmployeeSalary_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeSalaryController", "get_EmployeeSalary_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeSalaryController", "get_EmployeeSalary_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objEmployeeSalaryHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_EmployeeSalary(EmployeeSalaryModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeSalary_BL.add_new_EmployeeSalary(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objEmployeeSalaryHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objEmployeeSalaryHead);

                objError.WriteLog(0, "EmployeeSalaryController", "add_new_EmployeeSalary", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeSalaryController", "add_new_EmployeeSalary", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeSalaryController", "add_new_EmployeeSalary", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeSalaryController", "add_new_EmployeeSalary", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_EmployeeSalary(EmployeeSalaryModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeSalary_BL.modify_EmployeeSalary(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objEmployeeSalaryHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objEmployeeSalaryHead);

                objError.WriteLog(0, "EmployeeSalaryController", "modify_EmployeeSalary", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeSalaryController", "modify_EmployeeSalary", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeSalaryController", "modify_EmployeeSalary", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeSalaryController", "modify_EmployeeSalary", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_EmployeeSalary(InactiveEESModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeSalary_BL.inactivate_EmployeeSalary(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objEmployeeSalaryHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objEmployeeSalaryHead);

                objError.WriteLog(0, "EmployeeSalaryController", "inactivate_EmployeeSalary", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeSalaryController", "inactivate_EmployeeSalary", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeSalaryController", "inactivate_EmployeeSalary", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeSalaryController", "inactivate_EmployeeSalary", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

