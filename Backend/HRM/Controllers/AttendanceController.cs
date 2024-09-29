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
//using static error_handler.InformationLog;

namespace HRM.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class AttendanceController : Controller
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<AttendanceSubmitResponceModel> modify_Attendance(AttendanceGridSubmitModel item)//ok
        {
            List<AttendanceSubmitResponceModel> objAttendanceHeadList = new List<AttendanceSubmitResponceModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Attendance_BL.modify_Attendance(item);
            }
            catch (Exception ex)
            {
                AttendanceSubmitResponceModel objAttendanceHead = new AttendanceSubmitResponceModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objAttendanceHeadList.Add(objAttendanceHead);

                objError.WriteLog(0, "AttendanceController", "modify_Attendance", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "AttendanceController", "modify_Attendance", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "AttendanceController", "modify_Attendance", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "AttendanceController", "modify_Attendance", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objAttendanceHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<AttendanceSubmitResponceModel> get_Attendance_details(AttendanceRequestModel item)//ok
        {
            List<AttendanceSubmitResponceModel> objAttendanceList = new List<AttendanceSubmitResponceModel>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Attendance_BL.get_Attendance_details(item);
            }
            catch (Exception ex)
            {
                AttendanceSubmitResponceModel objAttendanceHead = new AttendanceSubmitResponceModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objAttendanceList.Add(objAttendanceHead);

                objError.WriteLog(0, "AttendanceController", "get_Attendance_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "AttendanceController", "get_Attendance_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "AttendanceController", "get_Attendance_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "AttendanceController", "get_Attendance_details", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objAttendanceList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<AttendanceGridViewHeaderModel> get_Attendance_all(AttendanceGridRequestModel item)//ok
        {
            List<AttendanceGridViewHeaderModel> objCountryHeadList = new List<AttendanceGridViewHeaderModel>();
            //AttendanceGridViewHeaderModel obj = new AttendanceGridViewHeaderModel() { resp = false, msg = "sfsf" };
            //obj.Attendance = new List<AttendanceGridViewModel>();
            //obj.Attendance.Add(new AttendanceGridViewModel() { AttendanceDate = DateTime.Now, EndDate = DateTime.Now });
            //obj.Attendance.Add(new AttendanceGridViewModel() { AttendanceDate = DateTime.Now, EndDate = DateTime.Now });
            //obj.Attendance.Add(new AttendanceGridViewModel() { AttendanceDate = DateTime.Now, EndDate = DateTime.Now });
            //objCountryHeadList.Add(obj);
            //return objCountryHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "");

                return HRM_BL.Attendance_BL.get_Attendance_all(item);
            }
            catch (Exception ex)
            {
                AttendanceGridViewHeaderModel objAttendanceHead = new AttendanceGridViewHeaderModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCountryHeadList.Add(objAttendanceHead);

                objError.WriteLog(0, "AttendanceController", "get_Attendance_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "AttendanceController", "get_Attendance_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "AttendanceController", "get_Attendance_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "AttendanceController", "get_Attendance_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objCountryHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<AttendanceSubmitResponceModel> AttendancePunch_Marker(AttendancePunch_MarkerSubmitModel item)//ok
        {
            List<AttendanceSubmitResponceModel> objCountryHeadList = new List<AttendanceSubmitResponceModel>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "");

                return HRM_BL.Attendance_BL.AttendancePunch_Marker(item);
            }
            catch (Exception ex)
            {
                AttendanceSubmitResponceModel objAttendanceHead = new AttendanceSubmitResponceModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCountryHeadList.Add(objAttendanceHead);

                objError.WriteLog(0, "AttendanceController", "AttendancePunch_Marker", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "AttendanceController", "AttendancePunch_Marker", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "AttendanceController", "AttendancePunch_Marker", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "AttendanceController", "AttendancePunch_Marker", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objCountryHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<AttendanceSubmitResponceModel> AttendancePunch_Mobile(AttendancePunch_MobileSubmitModel item)//ok
        {
            List<AttendanceSubmitResponceModel> objCountryHeadList = new List<AttendanceSubmitResponceModel>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "");

                return HRM_BL.Attendance_BL.AttendancePunch_Mobile(item);
            }
            catch (Exception ex)
            {
                AttendanceSubmitResponceModel objAttendanceHead = new AttendanceSubmitResponceModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCountryHeadList.Add(objAttendanceHead);

                objError.WriteLog(0, "AttendanceController", "AttendancePunch_Mobile", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "AttendanceController", "AttendancePunch_Mobile", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "AttendanceController", "AttendancePunch_Mobile", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "AttendanceController", "AttendancePunch_Mobile", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objCountryHeadList;

        }

    }
}
