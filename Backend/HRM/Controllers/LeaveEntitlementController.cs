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

    public class LeaveEntitlementController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnLeaveEntitlementModelHead> get_LeaveEntitlement_single(LeaveEntitlement model)//ok
        {
            List<ReturnLeaveEntitlementModelHead> objLeaveEntitlementHeadList = new List<ReturnLeaveEntitlementModelHead>();
            ReturnLeaveEntitlementModelHead obj = new ReturnLeaveEntitlementModelHead() { resp = false, msg = "sfsf" };
            obj.LeaveEntitlement = new List<ReturnLeaveEntitlementModel>();
            if (model.LVE_LeaveEntitlementID == 1)
                obj.LeaveEntitlement.Add(new ReturnLeaveEntitlementModel() { LVE_LeaveEntitlementID = 1, LVE_LeaveTypeID = "CAS", LVE_LeaveType = "Casual", LVE_Status = true, LVE_LeaveAlotment = 10, LVE_EmployeeID = "1" });
            if (model.LVE_LeaveEntitlementID == 2) obj.LeaveEntitlement.Add(new ReturnLeaveEntitlementModel() { LVE_LeaveEntitlementID = 2, LVE_LeaveTypeID = "ANU", LVE_LeaveType = "Annual", LVE_Status = true, LVE_LeaveAlotment = 10, LVE_EmployeeID = "1" });
            if (model.LVE_LeaveEntitlementID == 3) obj.LeaveEntitlement.Add(new ReturnLeaveEntitlementModel() { LVE_LeaveEntitlementID = 3, LVE_LeaveTypeID = "MED", LVE_LeaveType = "Medical", LVE_Status = true, LVE_LeaveAlotment = 10, LVE_EmployeeID = "1" });
            if (model.LVE_LeaveEntitlementID == 4) obj.LeaveEntitlement.Add(new ReturnLeaveEntitlementModel() { LVE_LeaveEntitlementID = 4, LVE_LeaveTypeID = "MAT", LVE_LeaveType = "Matrinaty", LVE_Status = true, LVE_LeaveAlotment = 10, LVE_EmployeeID = "1" });
            objLeaveEntitlementHeadList.Add(obj);
            return objLeaveEntitlementHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.LeaveEntitlement_BL.get_LeaveEntitlements_single(model);

            }
            catch (Exception ex)
            {

                ReturnLeaveEntitlementModelHead objLeaveEntitlementHead = new ReturnLeaveEntitlementModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objLeaveEntitlementHeadList.Add(objLeaveEntitlementHead);

                objError.WriteLog(0, "LeaveEntitlementController", "get_LeaveEntitlement_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveEntitlementController", "get_LeaveEntitlement_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveEntitlementController", "get_LeaveEntitlement_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveEntitlementController", "get_LeaveEntitlement_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objLeaveEntitlementHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnLeaveEntitlementModelHead> get_LeaveEntitlement_all(LeaveEntitlementSearchModel model)//ok
        {
            List<ReturnLeaveEntitlementModelHead> objLeaveEntitlementHeadList = new List<ReturnLeaveEntitlementModelHead>();
            ReturnLeaveEntitlementModelHead obj = new ReturnLeaveEntitlementModelHead() { resp = false, msg = "sfsf" };
            obj.LeaveEntitlement = new List<ReturnLeaveEntitlementModel>();
            if (model.LVE_EmployeeID == "test")
            {
                obj.LeaveEntitlement.Add(new ReturnLeaveEntitlementModel() { LVE_LeaveEntitlementID = 1, LVE_LeaveTypeID = "CAS", LVE_LeaveType = "Casual", LVE_Status = true });
                obj.LeaveEntitlement.Add(new ReturnLeaveEntitlementModel() { LVE_LeaveEntitlementID = 2, LVE_LeaveTypeID = "ANU", LVE_LeaveType = "Annual", LVE_Status = true, LVE_LeaveAlotment = 10 });
            }
            if (model.LVE_EmployeeID == "test1")
            {
                obj.LeaveEntitlement.Add(new ReturnLeaveEntitlementModel() { LVE_LeaveEntitlementID = 2, LVE_LeaveTypeID = "ANU", LVE_LeaveType = "Annual", LVE_Status = true, LVE_LeaveAlotment = 10 });
                obj.LeaveEntitlement.Add(new ReturnLeaveEntitlementModel() { LVE_LeaveEntitlementID = 3, LVE_LeaveTypeID = "MED", LVE_LeaveType = "Medical", LVE_Status = true, LVE_LeaveAlotment = 10 });
            }
            if (model.LVE_EmployeeID == "test2")
            {
                obj.LeaveEntitlement.Add(new ReturnLeaveEntitlementModel() { LVE_LeaveEntitlementID = 3, LVE_LeaveTypeID = "MED", LVE_LeaveType = "Medical", LVE_Status = true, LVE_LeaveAlotment = 10 });
                obj.LeaveEntitlement.Add(new ReturnLeaveEntitlementModel() { LVE_LeaveEntitlementID = 4, LVE_LeaveTypeID = "MAT", LVE_LeaveType = "Matrinaty", LVE_Status = true, LVE_LeaveAlotment = 10 });
            }
            else
            {
                obj.LeaveEntitlement.Add(new ReturnLeaveEntitlementModel() { LVE_LeaveEntitlementID = 1, LVE_LeaveTypeID = "CAS", LVE_LeaveType = "Casual", LVE_Status = true });
                obj.LeaveEntitlement.Add(new ReturnLeaveEntitlementModel() { LVE_LeaveEntitlementID = 2, LVE_LeaveTypeID = "ANU", LVE_LeaveType = "Annual", LVE_Status = true, LVE_LeaveAlotment = 10 });
                obj.LeaveEntitlement.Add(new ReturnLeaveEntitlementModel() { LVE_LeaveEntitlementID = 3, LVE_LeaveTypeID = "MED", LVE_LeaveType = "Medical", LVE_Status = true, LVE_LeaveAlotment = 10 });
                obj.LeaveEntitlement.Add(new ReturnLeaveEntitlementModel() { LVE_LeaveEntitlementID = 4, LVE_LeaveTypeID = "MAT", LVE_LeaveType = "Matrinaty", LVE_Status = true, LVE_LeaveAlotment = 10 });
            }
            objLeaveEntitlementHeadList.Add(obj);
            return objLeaveEntitlementHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.LeaveEntitlement_BL.get_LeaveEntitlement_all(model);

            }
            catch (Exception ex)
            {

                ReturnLeaveEntitlementModelHead objLeaveEntitlementHead = new ReturnLeaveEntitlementModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objLeaveEntitlementHeadList.Add(objLeaveEntitlementHead);

                objError.WriteLog(0, "LeaveEntitlementController", "get_LeaveEntitlement_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveEntitlementController", "get_LeaveEntitlement_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveEntitlementController", "get_LeaveEntitlement_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveEntitlementController", "get_LeaveEntitlement_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objLeaveEntitlementHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> add_new_LeaveEntitlement(LeaveEntitlementModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.LeaveEntitlement_BL.add_new_LeaveEntitlement(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objLeaveEntitlementHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objLeaveEntitlementHead);

                objError.WriteLog(0, "LeaveEntitlementController", "add_new_LeaveEntitlement", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveEntitlementController", "add_new_LeaveEntitlement", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveEntitlementController", "add_new_LeaveEntitlement", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveEntitlementController", "add_new_LeaveEntitlement", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> modify_LeaveEntitlement(LeaveEntitlementModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.LeaveEntitlement_BL.modify_LeaveEntitlement(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objLeaveEntitlementHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objLeaveEntitlementHead);

                objError.WriteLog(0, "LeaveEntitlementController", "modify_LeaveEntitlement", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveEntitlementController", "modify_LeaveEntitlement", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveEntitlementController", "modify_LeaveEntitlement", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveEntitlementController", "modify_LeaveEntitlement", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_LeaveEntitlement(InactiveLVEModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.LeaveEntitlement_BL.inactivate_LeaveEntitlement(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objLeaveEntitlementHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objLeaveEntitlementHead);

                objError.WriteLog(0, "LeaveEntitlementController", "inactivate_LeaveEntitlement", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveEntitlementController", "inactivate_LeaveEntitlement", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveEntitlementController", "inactivate_LeaveEntitlement", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveEntitlementController", "inactivate_LeaveEntitlement", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

