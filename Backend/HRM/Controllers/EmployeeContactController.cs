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

    public class EmployeeContactController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnEmployeeContactModelHead> get_EmployeeContact_single(EmployeeContact model)//ok
        {
            List<ReturnEmployeeContactModelHead> objEmployeeContactHeadList = new List<ReturnEmployeeContactModelHead>();
            //ReturnEmployeeContactModelHead obj = new ReturnEmployeeContactModelHead() { resp = false, msg = "sfsf" };
            //obj.EmployeeContact = new List<ReturnEmployeeContactModel>();
            //if (model.EEJ_JobDescriptionID == 1) obj.EmployeeContact.Add(new ReturnEmployeeContactModel() { EEJ_ID = 1, EEJ_EmployeeID = "test", EEJ_ContactID = "test", EEJ_Status = true });
            //if (model.EEJ_JobDescriptionID == 2) obj.EmployeeContact.Add(new ReturnEmployeeContactModel() { EEJ_ID = 2, EEJ_EmployeeID = "test1", EEJ_ContactID = "test1", EEJ_Status = true });
            //if (model.EEJ_JobDescriptionID == 3) obj.EmployeeContact.Add(new ReturnEmployeeContactModel() { EEJ_ID = 3, EEJ_EmployeeID = "test2", EEJ_ContactID = "test2", EEJ_Status = true });
            //objEmployeeContactHeadList.Add(obj);
            //return objEmployeeContactHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.EmployeeContact_BL.get_EmployeeContact_single(model);

            }
            catch (Exception ex)
            {

                ReturnEmployeeContactModelHead objEmployeeContactHead = new ReturnEmployeeContactModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objEmployeeContactHeadList.Add(objEmployeeContactHead);

                objError.WriteLog(0, "EmployeeContactController", "get_EmployeeContact_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeContactController", "get_EmployeeContact_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeContactController", "get_EmployeeContact_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeContactController", "get_EmployeeContact_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objEmployeeContactHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnEmployeeContactModelHead> get_EmployeeContact_all(EmployeeContactSearchModel model)//ok
        {
            List<ReturnEmployeeContactModelHead> objEmployeeContactHeadList = new List<ReturnEmployeeContactModelHead>();
            //ReturnEmployeeContactModelHead obj = new ReturnEmployeeContactModelHead() { resp = false, msg = "sfsf" };
            //obj.EmployeeContact = new List<ReturnEmployeeContactModel>();
            //obj.EmployeeContact.Add(new ReturnEmployeeContactModel() { EEJ_ID = 1, EEJ_EmployeeID = "test", EEJ_ContactID = "test", EEJ_Status = true });
            //obj.EmployeeContact.Add(new ReturnEmployeeContactModel() { EEJ_ID = 2, EEJ_EmployeeID = "test1", EEJ_ContactID = "test1", EEJ_Status = true });
            //obj.EmployeeContact.Add(new ReturnEmployeeContactModel() { EEJ_ID = 3, EEJ_EmployeeID = "test2", EEJ_ContactID = "test2", EEJ_Status = true });
            //objEmployeeContactHeadList.Add(obj);
            //return objEmployeeContactHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.EmployeeContact_BL.get_EmployeeContact_all(model);

            }
            catch (Exception ex)
            {

                ReturnEmployeeContactModelHead objEmployeeContactHead = new ReturnEmployeeContactModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objEmployeeContactHeadList.Add(objEmployeeContactHead);

                objError.WriteLog(0, "EmployeeContactController", "get_EmployeeContact_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeContactController", "get_EmployeeContact_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeContactController", "get_EmployeeContact_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeContactController", "get_EmployeeContact_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objEmployeeContactHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_EmployeeContact(EmployeeContactModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeContact_BL.add_new_EmployeeContact(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objEmployeeContactHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objEmployeeContactHead);

                objError.WriteLog(0, "EmployeeContactController", "add_new_EmployeeContact", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeContactController", "add_new_EmployeeContact", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeContactController", "add_new_EmployeeContact", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeContactController", "add_new_EmployeeContact", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_EmployeeContact(EmployeeContactModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeContact_BL.modify_EmployeeContact(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objEmployeeContactHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objEmployeeContactHead);

                objError.WriteLog(0, "EmployeeContactController", "modify_EmployeeContact", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeContactController", "modify_EmployeeContact", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeContactController", "modify_EmployeeContact", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeContactController", "modify_EmployeeContact", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_EmployeeContact(InactiveEECModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeContact_BL.inactivate_EmployeeContact(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objEmployeeContactHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objEmployeeContactHead);

                objError.WriteLog(0, "EmployeeContactController", "inactivate_EmployeeContact", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeContactController", "inactivate_EmployeeContact", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeContactController", "inactivate_EmployeeContact", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeContactController", "inactivate_EmployeeContact", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

