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

    public class EmployeeTerminationController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnEmployeeTerminationModelHead> get_EmployeeTermination_single(EmployeeTermination model)//ok
        {
            List<ReturnEmployeeTerminationModelHead> objEmployeeTerminationHeadList = new List<ReturnEmployeeTerminationModelHead>();
            //ReturnEmployeeTerminationModelHead obj = new ReturnEmployeeTerminationModelHead() { resp = false, msg = "sfsf" };
            //obj.EmployeeTermination = new List<ReturnEmployeeTerminationModel>();
            //if (model.EEJ_JobDescriptionID == 1) obj.EmployeeTermination.Add(new ReturnEmployeeTerminationModel() { EEJ_ID = 1, EEJ_EmployeeID = "test", EEJ_TerminationID = "test", EEJ_Status = true });
            //if (model.EEJ_JobDescriptionID == 2) obj.EmployeeTermination.Add(new ReturnEmployeeTerminationModel() { EEJ_ID = 2, EEJ_EmployeeID = "test1", EEJ_TerminationID = "test1", EEJ_Status = true });
            //if (model.EEJ_JobDescriptionID == 3) obj.EmployeeTermination.Add(new ReturnEmployeeTerminationModel() { EEJ_ID = 3, EEJ_EmployeeID = "test2", EEJ_TerminationID = "test2", EEJ_Status = true });
            //objEmployeeTerminationHeadList.Add(obj);
            //return objEmployeeTerminationHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.EmployeeTermination_BL.get_EmployeeTermination_single(model);

            }
            catch (Exception ex)
            {

                ReturnEmployeeTerminationModelHead objEmployeeTerminationHead = new ReturnEmployeeTerminationModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objEmployeeTerminationHeadList.Add(objEmployeeTerminationHead);

                objError.WriteLog(0, "EmployeeTerminationController", "get_EmployeeTermination_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeTerminationController", "get_EmployeeTermination_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeTerminationController", "get_EmployeeTermination_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeTerminationController", "get_EmployeeTermination_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objEmployeeTerminationHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnEmployeeTerminationModelHead> get_EmployeeTermination_all(EmployeeTerminationSearchModel model)//ok
        {
            List<ReturnEmployeeTerminationModelHead> objEmployeeTerminationHeadList = new List<ReturnEmployeeTerminationModelHead>();
            //ReturnEmployeeTerminationModelHead obj = new ReturnEmployeeTerminationModelHead() { resp = false, msg = "sfsf" };
            //obj.EmployeeTermination = new List<ReturnEmployeeTerminationModel>();
            //obj.EmployeeTermination.Add(new ReturnEmployeeTerminationModel() { EEJ_ID = 1, EEJ_EmployeeID = "test", EEJ_TerminationID = "test", EEJ_Status = true });
            //obj.EmployeeTermination.Add(new ReturnEmployeeTerminationModel() { EEJ_ID = 2, EEJ_EmployeeID = "test1", EEJ_TerminationID = "test1", EEJ_Status = true });
            //obj.EmployeeTermination.Add(new ReturnEmployeeTerminationModel() { EEJ_ID = 3, EEJ_EmployeeID = "test2", EEJ_TerminationID = "test2", EEJ_Status = true });
            //objEmployeeTerminationHeadList.Add(obj);
            //return objEmployeeTerminationHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.EmployeeTermination_BL.get_EmployeeTermination_all(model);

            }
            catch (Exception ex)
            {

                ReturnEmployeeTerminationModelHead objEmployeeTerminationHead = new ReturnEmployeeTerminationModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objEmployeeTerminationHeadList.Add(objEmployeeTerminationHead);

                objError.WriteLog(0, "EmployeeTerminationController", "get_EmployeeTermination_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeTerminationController", "get_EmployeeTermination_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeTerminationController", "get_EmployeeTermination_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeTerminationController", "get_EmployeeTermination_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objEmployeeTerminationHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_EmployeeTermination(EmployeeTerminationModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeTermination_BL.add_new_EmployeeTermination(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objEmployeeTerminationHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objEmployeeTerminationHead);

                objError.WriteLog(0, "EmployeeTerminationController", "add_new_EmployeeTermination", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeTerminationController", "add_new_EmployeeTermination", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeTerminationController", "add_new_EmployeeTermination", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeTerminationController", "add_new_EmployeeTermination", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_EmployeeTermination(EmployeeTerminationModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeTermination_BL.modify_EmployeeTermination(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objEmployeeTerminationHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objEmployeeTerminationHead);

                objError.WriteLog(0, "EmployeeTerminationController", "modify_EmployeeTermination", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeTerminationController", "modify_EmployeeTermination", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeTerminationController", "modify_EmployeeTermination", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeTerminationController", "modify_EmployeeTermination", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_EmployeeTermination(InactiveEETModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.EmployeeTermination_BL.inactivate_EmployeeTermination(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objEmployeeTerminationHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objEmployeeTerminationHead);

                objError.WriteLog(0, "EmployeeTerminationController", "inactivate_EmployeeTermination", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeTerminationController", "inactivate_EmployeeTermination", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeTerminationController", "inactivate_EmployeeTermination", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeTerminationController", "inactivate_EmployeeTermination", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

