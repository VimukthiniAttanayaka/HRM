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

    public class EmployeeController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnEmployeeModelHead> get_employee_single(Employee USR_EmployeeID)//ok
        {
            List<ReturnEmployeeModelHead> objemployeeHeadList = new List<ReturnEmployeeModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, USR_EmployeeID);

                return HRM_BL.Employee_BL.get_employees_single(USR_EmployeeID);

            }
            catch (Exception ex)
            {

                ReturnEmployeeModelHead objemployeeHead = new ReturnEmployeeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objemployeeHeadList.Add(objemployeeHead);

                objError.WriteLog(0, "employeeController", "get_employee_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "employeeController", "get_employee_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "employeeController", "get_employee_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "employeeController", "get_employee_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objemployeeHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnEmployeeModelHead> get_employee_all(EmployeeSearchModel model)//ok
        {
            List<ReturnEmployeeModelHead> objemployeeHeadList = new List<ReturnEmployeeModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.Employee_BL.get_employee_all(model);

            }
            catch (Exception ex)
            {

                ReturnEmployeeModelHead objemployeeHead = new ReturnEmployeeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objemployeeHeadList.Add(objemployeeHead);

                objError.WriteLog(0, "employeeController", "get_employee_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "employeeController", "get_employee_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "employeeController", "get_employee_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "employeeController", "get_employee_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objemployeeHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> add_new_employee(EmployeeModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Employee_BL.add_new_employee(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objemployeeHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objemployeeHead);

                objError.WriteLog(0, "employeeController", "add_new_employee", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "employeeController", "add_new_employee", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "employeeController", "add_new_employee", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "employeeController", "add_new_employee", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> modify_employee(EmployeeModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Employee_BL.modify_employee(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objemployeeHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objemployeeHead);

                objError.WriteLog(0, "employeeController", "modify_employee", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "employeeController", "modify_employee", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "employeeController", "modify_employee", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "employeeController", "modify_employee", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_employee(InactiveEmpModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Employee_BL.inactivate_employee(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objemployeeHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objemployeeHead);

                objError.WriteLog(0, "employeeController", "inactivate_employee", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "employeeController", "inactivate_employee", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "employeeController", "inactivate_employee", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "employeeController", "inactivate_employee", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

