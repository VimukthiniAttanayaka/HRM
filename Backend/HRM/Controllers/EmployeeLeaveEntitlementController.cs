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

    public class EmployeeLeaveEntitlementController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnEmployeeLeaveEntitlementModelHead> get_EmployeeLeaveEntitlement_single(EmployeeLeaveEntitlement model)//ok
        {
            List<ReturnEmployeeLeaveEntitlementModelHead> objEmployeeLeaveEntitlementHeadList = new List<ReturnEmployeeLeaveEntitlementModelHead>();
            //ReturnEmployeeLeaveEntitlementModelHead obj = new ReturnEmployeeLeaveEntitlementModelHead() { resp = false, msg = "sfsf" };
            //obj.EmployeeLeaveEntitlement = new List<ReturnEmployeeLeaveEntitlementModel>();
            //if (model.EEJ_JobDescriptionID == 1) obj.EmployeeLeaveEntitlement.Add(new ReturnEmployeeLeaveEntitlementModel() { EEJ_ID = 1, EEJ_EmployeeID = "test", EEJ_LeaveEntitlementID = "test", EEJ_Status = true });
            //if (model.EEJ_JobDescriptionID == 2) obj.EmployeeLeaveEntitlement.Add(new ReturnEmployeeLeaveEntitlementModel() { EEJ_ID = 2, EEJ_EmployeeID = "test1", EEJ_LeaveEntitlementID = "test1", EEJ_Status = true });
            //if (model.EEJ_JobDescriptionID == 3) obj.EmployeeLeaveEntitlement.Add(new ReturnEmployeeLeaveEntitlementModel() { EEJ_ID = 3, EEJ_EmployeeID = "test2", EEJ_LeaveEntitlementID = "test2", EEJ_Status = true });
            //objEmployeeLeaveEntitlementHeadList.Add(obj);
            //return objEmployeeLeaveEntitlementHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.EmployeeLeaveEntitlement_BL.get_EmployeeLeaveEntitlement_single(model);

            }
            catch (Exception ex)
            {

                ReturnEmployeeLeaveEntitlementModelHead objEmployeeLeaveEntitlementHead = new ReturnEmployeeLeaveEntitlementModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objEmployeeLeaveEntitlementHeadList.Add(objEmployeeLeaveEntitlementHead);

                objError.WriteLog(0, "EmployeeLeaveEntitlementController", "get_EmployeeLeaveEntitlement_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeLeaveEntitlementController", "get_EmployeeLeaveEntitlement_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeLeaveEntitlementController", "get_EmployeeLeaveEntitlement_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeLeaveEntitlementController", "get_EmployeeLeaveEntitlement_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objEmployeeLeaveEntitlementHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnEmployeeLeaveEntitlementModelHead> get_EmployeeLeaveEntitlement_all(EmployeeLeaveEntitlementSearchModel model)//ok
        {
            List<ReturnEmployeeLeaveEntitlementModelHead> objEmployeeLeaveEntitlementHeadList = new List<ReturnEmployeeLeaveEntitlementModelHead>();
            //ReturnEmployeeLeaveEntitlementModelHead obj = new ReturnEmployeeLeaveEntitlementModelHead() { resp = false, msg = "sfsf" };
            //obj.EmployeeLeaveEntitlement = new List<ReturnEmployeeLeaveEntitlementModel>();
            //obj.EmployeeLeaveEntitlement.Add(new ReturnEmployeeLeaveEntitlementModel() { EEJ_ID = 1, EEJ_EmployeeID = "test", EEJ_LeaveEntitlementID = "test", EEJ_Status = true });
            //obj.EmployeeLeaveEntitlement.Add(new ReturnEmployeeLeaveEntitlementModel() { EEJ_ID = 2, EEJ_EmployeeID = "test1", EEJ_LeaveEntitlementID = "test1", EEJ_Status = true });
            //obj.EmployeeLeaveEntitlement.Add(new ReturnEmployeeLeaveEntitlementModel() { EEJ_ID = 3, EEJ_EmployeeID = "test2", EEJ_LeaveEntitlementID = "test2", EEJ_Status = true });
            //objEmployeeLeaveEntitlementHeadList.Add(obj);
            //return objEmployeeLeaveEntitlementHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.EmployeeLeaveEntitlement_BL.get_EmployeeLeaveEntitlement_all(model);

            }
            catch (Exception ex)
            {

                ReturnEmployeeLeaveEntitlementModelHead objEmployeeLeaveEntitlementHead = new ReturnEmployeeLeaveEntitlementModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objEmployeeLeaveEntitlementHeadList.Add(objEmployeeLeaveEntitlementHead);

                objError.WriteLog(0, "EmployeeLeaveEntitlementController", "get_EmployeeLeaveEntitlement_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeLeaveEntitlementController", "get_EmployeeLeaveEntitlement_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeLeaveEntitlementController", "get_EmployeeLeaveEntitlement_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeLeaveEntitlementController", "get_EmployeeLeaveEntitlement_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objEmployeeLeaveEntitlementHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_EmployeeLeaveEntitlement(EmployeeLeaveEntitlementModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeLeaveEntitlement_BL.add_new_EmployeeLeaveEntitlement(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objEmployeeLeaveEntitlementHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objEmployeeLeaveEntitlementHead);

                objError.WriteLog(0, "EmployeeLeaveEntitlementController", "add_new_EmployeeLeaveEntitlement", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeLeaveEntitlementController", "add_new_EmployeeLeaveEntitlement", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeLeaveEntitlementController", "add_new_EmployeeLeaveEntitlement", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeLeaveEntitlementController", "add_new_EmployeeLeaveEntitlement", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_EmployeeLeaveEntitlement(EmployeeLeaveEntitlementModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeLeaveEntitlement_BL.modify_EmployeeLeaveEntitlement(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objEmployeeLeaveEntitlementHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objEmployeeLeaveEntitlementHead);

                objError.WriteLog(0, "EmployeeLeaveEntitlementController", "modify_EmployeeLeaveEntitlement", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeLeaveEntitlementController", "modify_EmployeeLeaveEntitlement", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeLeaveEntitlementController", "modify_EmployeeLeaveEntitlement", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeLeaveEntitlementController", "modify_EmployeeLeaveEntitlement", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_EmployeeLeaveEntitlement(InactiveEELEModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeLeaveEntitlement_BL.inactivate_EmployeeLeaveEntitlement(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objEmployeeLeaveEntitlementHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objEmployeeLeaveEntitlementHead);

                objError.WriteLog(0, "EmployeeLeaveEntitlementController", "inactivate_EmployeeLeaveEntitlement", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeLeaveEntitlementController", "inactivate_EmployeeLeaveEntitlement", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeLeaveEntitlementController", "inactivate_EmployeeLeaveEntitlement", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeLeaveEntitlementController", "inactivate_EmployeeLeaveEntitlement", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

