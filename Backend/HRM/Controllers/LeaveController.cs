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

    public class LeaveController : Controller
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<LeaveHeaderResponceModel> get_leave_details(LeaveRequestModel item)//ok
        {
            List<LeaveHeaderResponceModel> objLeaveList = new List<LeaveHeaderResponceModel>();
            try
            {

                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Leave_BL.get_leave_details(item);
            }
            catch (Exception ex)
            {
                LeaveHeaderResponceModel objLeaveHead = new LeaveHeaderResponceModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objLeaveList.Add(objLeaveHead);

                objError.WriteLog(0, "LeaveController", "get_leave_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveController", "get_leave_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveController", "get_leave_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveController", "get_leave_details", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objLeaveList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<LeaveGridViewHeaderModel> get_leave_all(LeaveGridRequestModel item)//ok
        {
            List<LeaveGridViewHeaderModel> objCountryHeadList = new List<LeaveGridViewHeaderModel>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "");

                return HRM_BL.Leave_BL.get_leave_grid_details(item);
            }
            catch (Exception ex)
            {
                LeaveGridViewHeaderModel objLeaveHead = new LeaveGridViewHeaderModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCountryHeadList.Add(objLeaveHead);

                objError.WriteLog(0, "LeaveController", "get_leave_grid_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveController", "get_leave_grid_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveController", "get_leave_grid_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveController", "get_leave_grid_details", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objCountryHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<LeaveSubmitResponceModel> applyleave(LeaveSubmitModel model)
        {
            List<LeaveSubmitResponceModel> objCountryHeadList = new List<LeaveSubmitResponceModel>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "");

                return HRM_BL.Leave_BL.applyleave(model);
            }
            catch (Exception ex)
            {
                LeaveSubmitResponceModel objLeaveHead = new LeaveSubmitResponceModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCountryHeadList.Add(objLeaveHead);

                objError.WriteLog(0, "LeaveController", "applyleave", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveController", "applyleave", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveController", "applyleave", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveController", "applyleave", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objCountryHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<LeaveSubmitResponceModel> cancelleave(LeaveCancelSubmitModel model)
        {
            List<LeaveSubmitResponceModel> objCountryHeadList = new List<LeaveSubmitResponceModel>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "");

                return HRM_BL.Leave_BL.cancelleave(model);
            }
            catch (Exception ex)
            {
                LeaveSubmitResponceModel objLeaveHead = new LeaveSubmitResponceModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCountryHeadList.Add(objLeaveHead);

                objError.WriteLog(0, "LeaveController", "cancelleave", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveController", "cancelleave", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveController", "cancelleave", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveController", "cancelleave", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objCountryHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<LeaveSubmitResponceModel> approveleave(LeaveApproveSubmitModel model)
        {
            List<LeaveSubmitResponceModel> objCountryHeadList = new List<LeaveSubmitResponceModel>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "");

                return HRM_BL.Leave_BL.approveleave(model);
            }
            catch (Exception ex)
            {
                LeaveSubmitResponceModel objLeaveHead = new LeaveSubmitResponceModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCountryHeadList.Add(objLeaveHead);

                objError.WriteLog(0, "LeaveController", "approveleave", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveController", "approveleave", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveController", "approveleave", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveController", "approveleave", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objCountryHeadList;

        }
    }
}
