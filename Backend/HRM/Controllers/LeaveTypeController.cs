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

    public class LeaveTypeController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnLeaveTypeModelHead> get_leavetype_single(LeaveType model)//ok
        {
            List<ReturnLeaveTypeModelHead> objleavetypeHeadList = new List<ReturnLeaveTypeModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.LeaveType_BL.get_LeaveTypes_single(model);

            }
            catch (Exception ex)
            {

                ReturnLeaveTypeModelHead objleavetypeHead = new ReturnLeaveTypeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objleavetypeHeadList.Add(objleavetypeHead);

                objError.WriteLog(0, "leavetypeController", "get_leavetype_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "leavetypeController", "get_leavetype_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "leavetypeController", "get_leavetype_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "leavetypeController", "get_leavetype_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objleavetypeHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnLeaveTypeModelHead> get_leavetype_all(LeaveTypeSearchModel model)//ok
        {
            List<ReturnLeaveTypeModelHead> objleavetypeHeadList = new List<ReturnLeaveTypeModelHead>();
            ReturnLeaveTypeModelHead obj = new ReturnLeaveTypeModelHead() { resp = false, msg = "sfsf" };
            obj.LeaveType = new List<ReturnLeaveTypeModel>();
            obj.LeaveType.Add(new ReturnLeaveTypeModel() { LVT_LeaveTypeID="CAS",LVT_LeaveType="Casual",LVT_Status=true});
            obj.LeaveType.Add(new ReturnLeaveTypeModel() { LVT_LeaveTypeID = "ANU", LVT_LeaveType = "Annual", LVT_Status = true });
            obj.LeaveType.Add(new ReturnLeaveTypeModel() { LVT_LeaveTypeID = "MED", LVT_LeaveType = "Medical", LVT_Status = true });
            obj.LeaveType.Add(new ReturnLeaveTypeModel() { LVT_LeaveTypeID = "MAT", LVT_LeaveType = "Matrinaty", LVT_Status = true });
            objleavetypeHeadList.Add(obj);
            return objleavetypeHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.LeaveType_BL.get_LeaveType_all(model);

            }
            catch (Exception ex)
            {

                ReturnLeaveTypeModelHead objleavetypeHead = new ReturnLeaveTypeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objleavetypeHeadList.Add(objleavetypeHead);

                objError.WriteLog(0, "leavetypeController", "get_leavetype_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "leavetypeController", "get_leavetype_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "leavetypeController", "get_leavetype_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "leavetypeController", "get_leavetype_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objleavetypeHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> add_new_leavetype(LeaveTypeModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.LeaveType_BL.add_new_LeaveType(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objleavetypeHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objleavetypeHead);

                objError.WriteLog(0, "leavetypeController", "add_new_leavetype", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "leavetypeController", "add_new_leavetype", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "leavetypeController", "add_new_leavetype", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "leavetypeController", "add_new_leavetype", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> modify_leavetype(LeaveTypeModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.LeaveType_BL.modify_LeaveType(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objleavetypeHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objleavetypeHead);

                objError.WriteLog(0, "leavetypeController", "modify_leavetype", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "leavetypeController", "modify_leavetype", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "leavetypeController", "modify_leavetype", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "leavetypeController", "modify_leavetype", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_leavetype(InactiveLVTModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.LeaveType_BL.inactivate_LeaveType(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objleavetypeHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objleavetypeHead);

                objError.WriteLog(0, "leavetypeController", "inactivate_leavetype", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "leavetypeController", "inactivate_leavetype", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "leavetypeController", "inactivate_leavetype", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "leavetypeController", "inactivate_leavetype", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

