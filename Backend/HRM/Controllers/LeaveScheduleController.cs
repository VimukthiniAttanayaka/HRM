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

    public class LeaveScheduleController : Controller
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<LeaveHeaderResponceModel> get_leave_single(LeaveRequestModel item)//ok
        {
            List<LeaveHeaderResponceModel> objLeaveList = new List<LeaveHeaderResponceModel>();
            LeaveHeaderResponceModel obj = new LeaveHeaderResponceModel() { resp = false, msg = "sfsf" };
            obj.LeaveResponceModelList = new List<LeaveResponceModel>();

            if (item.LV_LeaveID == 1)
                obj.LeaveResponceModelList.Add(new LeaveResponceModel() { LV_Reason = "1", LV_LeaveID = 1, LV_LeaveEntitlementID = 1, LV_LeaveTypeID = "CAS", LV_LeaveStartDate = DateTime.Now, LV_LeaveEndDate = DateTime.Now, LV_Status = true, LV_StaffID = "fsf", LV_LeaveStartTime = DateTime.Now.TimeOfDay, LV_LeaveEndTime = DateTime.Now.TimeOfDay });
            if (item.LV_LeaveID == 2) obj.LeaveResponceModelList.Add(new LeaveResponceModel() { LV_Reason = "2", LV_LeaveID = 2, LV_LeaveEntitlementID = 2, LV_LeaveTypeID = "ANU", LV_LeaveStartDate = DateTime.Now, LV_LeaveEndDate = DateTime.Now, LV_Status = true, LV_StaffID = "fsf", LV_LeaveStartTime = DateTime.Now.TimeOfDay, LV_LeaveEndTime = DateTime.Now.TimeOfDay });
            if (item.LV_LeaveID == 3) obj.LeaveResponceModelList.Add(new LeaveResponceModel() { LV_Reason = "3", LV_LeaveID = 3, LV_LeaveEntitlementID = 3, LV_LeaveTypeID = "MED", LV_LeaveStartDate = DateTime.Now, LV_LeaveEndDate = DateTime.Now, LV_Status = true, LV_StaffID = "fsf", LV_LeaveStartTime = DateTime.Now.TimeOfDay, LV_LeaveEndTime = DateTime.Now.TimeOfDay });
            if (item.LV_LeaveID == 4) obj.LeaveResponceModelList.Add(new LeaveResponceModel() { LV_Reason = "4", LV_LeaveID = 4, LV_LeaveEntitlementID = 4, LV_LeaveTypeID = "MAT", LV_LeaveStartDate = DateTime.Now, LV_LeaveEndDate = DateTime.Now, LV_Status = true, LV_StaffID = "fsf", LV_LeaveStartTime = DateTime.Now.TimeOfDay, LV_LeaveEndTime = DateTime.Now.TimeOfDay });
            objLeaveList.Add(obj);
            return objLeaveList;

            try
            {

                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.LeaveSchedule_BL.get_leave_details(item);
            }
            catch (Exception ex)
            {
                LeaveHeaderResponceModel objLeaveHead = new LeaveHeaderResponceModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objLeaveList.Add(objLeaveHead);

                objError.WriteLog(0, "LeaveScheduleController", "get_leave_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveScheduleController", "get_leave_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveScheduleController", "get_leave_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveScheduleController", "get_leave_details", "Inner Exception Message: " + ex.InnerException.Message);
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
            LeaveGridViewHeaderModel obj = new LeaveGridViewHeaderModel() { resp = false, msg = "sfsf" };
            obj.LeaveGridViewModelList = new List<LeaveGridViewModel>();
            obj.LeaveGridViewModelList.Add(new LeaveGridViewModel() { LV_LeaveID = 1, LV_LeaveEntitlementID = 1, LV_LeaveTypeID = "CAS", LV_LeaveStartDate = DateTime.Now, LV_LeaveEndDate = DateTime.Now, LV_Status = true, LV_StaffID = "fsf" });
            obj.LeaveGridViewModelList.Add(new LeaveGridViewModel() { LV_LeaveID = 2, LV_LeaveEntitlementID = 2, LV_LeaveTypeID = "ANU", LV_LeaveStartDate = DateTime.Now, LV_LeaveEndDate = DateTime.Now, LV_Status = true, LV_StaffID = "fsf" });
            obj.LeaveGridViewModelList.Add(new LeaveGridViewModel() { LV_LeaveID = 3, LV_LeaveEntitlementID = 3, LV_LeaveTypeID = "MED", LV_LeaveStartDate = DateTime.Now, LV_LeaveEndDate = DateTime.Now, LV_Status = true, LV_StaffID = "fsf" });
            obj.LeaveGridViewModelList.Add(new LeaveGridViewModel() { LV_LeaveID = 4, LV_LeaveEntitlementID = 4, LV_LeaveTypeID = "MAT", LV_LeaveStartDate = DateTime.Now, LV_LeaveEndDate = DateTime.Now, LV_Status = true, LV_StaffID = "fsf" });
            objCountryHeadList.Add(obj);
            return objCountryHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "");

                return HRM_BL.LeaveSchedule_BL.get_leave_grid_details(item);
            }
            catch (Exception ex)
            {
                LeaveGridViewHeaderModel objLeaveHead = new LeaveGridViewHeaderModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCountryHeadList.Add(objLeaveHead);

                objError.WriteLog(0, "LeaveScheduleController", "get_leave_grid_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveScheduleController", "get_leave_grid_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveScheduleController", "get_leave_grid_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveScheduleController", "get_leave_grid_details", "Inner Exception Message: " + ex.InnerException.Message);
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

                return HRM_BL.LeaveSchedule_BL.applyleave(model);
            }
            catch (Exception ex)
            {
                LeaveSubmitResponceModel objLeaveHead = new LeaveSubmitResponceModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCountryHeadList.Add(objLeaveHead);

                objError.WriteLog(0, "LeaveScheduleController", "applyleave", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveScheduleController", "applyleave", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveScheduleController", "applyleave", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveScheduleController", "applyleave", "Inner Exception Message: " + ex.InnerException.Message);
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

                return HRM_BL.LeaveSchedule_BL.cancelleave(model);
            }
            catch (Exception ex)
            {
                LeaveSubmitResponceModel objLeaveHead = new LeaveSubmitResponceModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCountryHeadList.Add(objLeaveHead);

                objError.WriteLog(0, "LeaveScheduleController", "cancelleave", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveScheduleController", "cancelleave", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveScheduleController", "cancelleave", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveScheduleController", "cancelleave", "Inner Exception Message: " + ex.InnerException.Message);
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

                return HRM_BL.LeaveSchedule_BL.approveleave(model);
            }
            catch (Exception ex)
            {
                LeaveSubmitResponceModel objLeaveHead = new LeaveSubmitResponceModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCountryHeadList.Add(objLeaveHead);

                objError.WriteLog(0, "LeaveScheduleController", "approveleave", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveScheduleController", "approveleave", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveScheduleController", "approveleave", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveScheduleController", "approveleave", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objCountryHeadList;

        }
    }
}
