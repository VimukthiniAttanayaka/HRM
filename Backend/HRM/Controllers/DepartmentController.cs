using HRM_DAL.Models;
using error_handler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using utility_handler.Data;
//using static error_handler.InformationLog;
using static error_handler.ErrorLog;
using System.Reflection;
using static error_handler.InformationLog;
using System.Linq;
using System.Data.OleDb;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using HRM_DAL.Data;

namespace HRM.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class DepartmentController : ControllerBase
    {
        private LogError objError = new LogError();

        //POST api/<DepartmentController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_department(DepartmentModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            //List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.Department_BL.add_new_department(item);
                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentController", "add_new_department", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentController", "add_new_department", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentController", "add_new_department", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentController", "add_new_department", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_department(DepartmentModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.Department_BL.modify_department(item);
                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentController", "modify_department", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentController", "modify_department", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentController", "modify_department", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentController", "modify_department", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_department(InactiveDepartmentModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.Department_BL.inactivate_department(item);
                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentController", "inactivate_department", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentController", "inactivate_department", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentController", "inactivate_department", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentController", "inactivate_department", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objHeadList;
            }




        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturDepartmentModelHead> get_department_all(GetDepartmentAllModel item)//ok
        {
            List<ReturDepartmentModelHead> objHeadList = new List<ReturDepartmentModelHead>();
            ReturDepartmentModelHead obj = new ReturDepartmentModelHead() { resp = false, msg = "sfsf" };
            obj.Department = new List<ReturnDepartmentModel>();
            obj.Department.Add(new ReturnDepartmentModel() {MDD_DepartmentID  = "CAS", MDD_Department = "Casual", MDD_Status = true });
            obj.Department.Add(new ReturnDepartmentModel() { MDD_DepartmentID = "ANU", MDD_Department = "Annual", MDD_Status = true });
            obj.Department.Add(new ReturnDepartmentModel() { MDD_DepartmentID = "MED", MDD_Department = "Medical", MDD_Status = true });
            obj.Department.Add(new ReturnDepartmentModel() { MDD_DepartmentID = "MAT", MDD_Department = "Matrinaty", MDD_Status = true });
            objHeadList.Add(obj);
            return objHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.Department_BL.get_department_all(item);
                return objHeadList;

            }
            catch (Exception ex)
            {
                ReturDepartmentModelHead objHead = new ReturDepartmentModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentController", "get_department_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentController", "get_department_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentController", "get_department_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentController", "get_department_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturDepartmentModelHead> get_department_single(GetDepartmentSingleModel item)
        {
            List<ReturDepartmentModelHead> objHeadList = new List<ReturDepartmentModelHead>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.Department_BL.get_department_single(item);
                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturDepartmentModelHead objHead = new ReturDepartmentModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentController", "get_department_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentController", "get_department_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentController", "get_department_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentController", "get_department_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }
    }

    public class DepartmentExcelSampleModel
    {
        public string FileFullPath { get; set; }
    }
}








