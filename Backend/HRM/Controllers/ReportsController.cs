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
using AspNetCore.Reporting;
using System.Drawing.Printing;
using Microsoft.Reporting.WebForms;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using HRM_DAL.Models.ResponceModels;
using HRM_DAL.Models.RequestModels;
using HRM_DAL.Data;
//using static error_handler.InformationLog;

namespace HRM.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class ReportsController : ControllerBase
    {
        private LogError objError = new LogError();

        ////POST api/<UserController>
        //[HttpPost]
        //[Route("[action]")]
        ////[Authorize]
        //public List<ReportsReturnResponse> PrintContainerLabelWithQRSticker(PrintContainerRequestModel model)
        //{
        //    List<ReportsReturnResponse> objUserHeadList = new List<ReportsReturnResponse>();

        //    try
        //    {
        //        return HRM_BL.Reports_BL.PrintContainerLabelWithQRSticker(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        ReportsReturnResponse objUserHead = new ReportsReturnResponse
        //        {
        //            resp = false,
        //            msg = ex.Message.ToString()
        //        };
        //        objUserHeadList.Add(objUserHead);

        //        objError.WriteLog(0, "ReportsController", "PrintContainerLabelWithQRSticker", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "ReportsController", "PrintContainerLabelWithQRSticker", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "ReportsController", "PrintContainerLabelWithQRSticker", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "ReportsController", "PrintContainerLabelWithQRSticker", "Inner Exception Message: " + ex.InnerException.Message);
        //        }
        //    }

        //    return objUserHeadList;
        //}

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnAttendanceReportsModelHead> get_AttendanceReport(RequestAttendance model)//ok
        {
            List<ReturnAttendanceReportsModelHead> objAccessGroupHeadList = new List<ReturnAttendanceReportsModelHead>();
            ReturnAttendanceReportsModelHead obj = new ReturnAttendanceReportsModelHead() { resp = false, msg = "sfsf" };
            obj.Attendance = new List<AttendanceReportModel>();



            obj.Attendance.Add(new AttendanceReportModel() { InTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), OutTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Reason = "ANU", EndDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Total = 0, DateString = "ANU", AttendanceDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), StartDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") });
            obj.Attendance.Add(new AttendanceReportModel() { InTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), OutTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Reason = "ANU", EndDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Total = 0, DateString = "ANU", AttendanceDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), StartDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") });
            obj.Attendance.Add(new AttendanceReportModel() { InTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), OutTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Reason = "ANU", EndDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Total = 0, DateString = "ANU", AttendanceDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), StartDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") });
            obj.Attendance.Add(new AttendanceReportModel() { InTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), OutTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Reason = "ANU", EndDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Total = 0, DateString = "ANU", AttendanceDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), StartDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") });
            obj.Attendance.Add(new AttendanceReportModel() { InTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), OutTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Reason = "ANU", EndDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Total = 0, DateString = "ANU", AttendanceDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), StartDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") });

            objAccessGroupHeadList.Add(obj);
            return objAccessGroupHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.Reports_BL.get_AttendanceReport(model);

            }
            catch (Exception ex)
            {

                ReturnAttendanceReportsModelHead objAccessGroupHead = new ReturnAttendanceReportsModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objAccessGroupHeadList.Add(objAccessGroupHead);

                objError.WriteLog(0, "ReportsController", "get_AttendanceReport", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportsController", "get_AttendanceReport", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportsController", "get_AttendanceReport", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportsController", "get_AttendanceReport", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objAccessGroupHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnBirthdayReportsModelHead> get_BirthdayReport(RequestBirthday model)//ok
        {
            List<ReturnBirthdayReportsModelHead> objAccessGroupHeadList = new List<ReturnBirthdayReportsModelHead>();
            ReturnBirthdayReportsModelHead obj = new ReturnBirthdayReportsModelHead() { resp = false, msg = "sfsf" };
            obj.Birthday = new List<BirthdayReportModel>();



            //obj.Birthday.Add(new BirthdayReportModel() { InTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), OutTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Reason = "ANU", EndDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Total = 0, DateString = "ANU", AttendanceDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), StartDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") });
            //obj.Birthday.Add(new BirthdayReportModel() { InTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), OutTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Reason = "ANU", EndDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Total = 0, DateString = "ANU", AttendanceDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), StartDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") });
            //obj.Birthday.Add(new BirthdayReportModel() { InTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), OutTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Reason = "ANU", EndDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Total = 0, DateString = "ANU", AttendanceDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), StartDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") });
            //obj.Birthday.Add(new BirthdayReportModel() { InTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), OutTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Reason = "ANU", EndDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Total = 0, DateString = "ANU", AttendanceDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), StartDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") });
            //obj.Birthday.Add(new BirthdayReportModel() { InTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), OutTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Reason = "ANU", EndDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), Total = 0, DateString = "ANU", AttendanceDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), StartDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") });

            objAccessGroupHeadList.Add(obj);
            return objAccessGroupHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.Reports_BL.get_BirthdayReport(model);

            }
            catch (Exception ex)
            {

                ReturnBirthdayReportsModelHead objAccessGroupHead = new ReturnBirthdayReportsModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objAccessGroupHeadList.Add(objAccessGroupHead);

                objError.WriteLog(0, "ReportsController", "get_BirthdayReport", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ReportsController", "get_BirthdayReport", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ReportsController", "get_BirthdayReport", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ReportsController", "get_BirthdayReport", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objAccessGroupHeadList;

        }
    }

}








