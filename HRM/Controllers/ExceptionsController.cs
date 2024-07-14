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
//using System.Web.Security;
//using static error_handler.InformationLog;

namespace HRM.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class ExceptionsController : Controller
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ExceptionsHeaderResponceModel> modify_exceptions(ExceptionsSubmitModel item)//ok
        {
            List<ExceptionsHeaderResponceModel> objExceptionsHeadList = new List<ExceptionsHeaderResponceModel>();

            try
            {

                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Exceptions_BL.modify_exceptions(item);
            }
            catch (Exception ex)
            {
                ExceptionsHeaderResponceModel objExceptionsHead = new ExceptionsHeaderResponceModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objExceptionsHeadList.Add(objExceptionsHead);

                objError.WriteLog(0, "ExceptionsController", "modify_exceptions", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ExceptionsController", "modify_exceptions", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ExceptionsController", "modify_exceptions", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ExceptionsController", "modify_exceptions", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objExceptionsHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ExceptionsHeaderResponceModel> get_exceptions_details(ExceptionsRequestModel item)//ok
        {
            List<ExceptionsHeaderResponceModel> objExceptionsList = new List<ExceptionsHeaderResponceModel>();
            try
            {

                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Exceptions_BL.get_exceptions_details(item);
            }
            catch (Exception ex)
            {
                ExceptionsHeaderResponceModel objExceptionsHead = new ExceptionsHeaderResponceModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objExceptionsList.Add(objExceptionsHead);

                objError.WriteLog(0, "ExceptionsController", "get_exceptions_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ExceptionsController", "get_exceptions_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ExceptionsController", "get_exceptions_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ExceptionsController", "get_exceptions_details", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objExceptionsList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ExceptionsGridViewHeaderModel> get_exceptions_grid_details(ExceptionsGridRequestModel item)//ok
        {
            List<ExceptionsGridViewHeaderModel> objCountryHeadList = new List<ExceptionsGridViewHeaderModel>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "");
                //ExceptionsGridRequestModel item = new ExceptionsGridRequestModel();
                return HRM_BL.Exceptions_BL.get_exceptions_grid_details(item);
            }
            catch (Exception ex)
            {
                ExceptionsGridViewHeaderModel objExceptionsHead = new ExceptionsGridViewHeaderModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCountryHeadList.Add(objExceptionsHead);

                objError.WriteLog(0, "ExceptionsController", "get_exceptions_grid_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ExceptionsController", "get_exceptions_grid_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ExceptionsController", "get_exceptions_grid_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ExceptionsController", "get_exceptions_grid_details", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objCountryHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ExceptionsStatusHeaderResponceModel> modify_exceptionstatus(ExceptionsStatusSubmitModel item)//ok
        {
            List<ExceptionsStatusHeaderResponceModel> objExceptionsHeadList = new List<ExceptionsStatusHeaderResponceModel>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "");

                return HRM_BL.Exceptions_BL.modify_exceptionstatus(item);
            }
            catch (Exception ex)
            {
                ExceptionsStatusHeaderResponceModel objExceptionsHead = new ExceptionsStatusHeaderResponceModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objExceptionsHeadList.Add(objExceptionsHead);

                objError.WriteLog(0, "ExceptionsController", "modify_exceptionstatus", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ExceptionsController", "modify_exceptionstatus", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ExceptionsController", "modify_exceptionstatus", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ExceptionsController", "modify_exceptionstatus", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objExceptionsHeadList;

        }
    }
}
