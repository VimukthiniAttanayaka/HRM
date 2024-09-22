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

    public class PerformanceAppriasalApprovalController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnPerformanceAppriasalApprovalModelHead> get_PerformanceAppriasalApproval_single(PerformanceAppriasalApproval model)//ok
        {
            List<ReturnPerformanceAppriasalApprovalModelHead> objPerformanceAppriasalApprovalHeadList = new List<ReturnPerformanceAppriasalApprovalModelHead>();
            ReturnPerformanceAppriasalApprovalModelHead obj = new ReturnPerformanceAppriasalApprovalModelHead() { resp = false, msg = "sfsf" };
            obj.PerformanceAppriasalApproval = new List<ReturnPerformanceAppriasalApprovalModel>();
            if (model.PAAP_ID == "CAS")
                obj.PerformanceAppriasalApproval.Add(new ReturnPerformanceAppriasalApprovalModel() { PAAP_ID = "CAS", PAAP_Comments = "Casual", PAAP_Status = true });
            if (model.PAAP_ID == "ANU") obj.PerformanceAppriasalApproval.Add(new ReturnPerformanceAppriasalApprovalModel() { PAAP_ID = "ANU", PAAP_Comments = "Annual", PAAP_Status = true });
            if (model.PAAP_ID == "MED") obj.PerformanceAppriasalApproval.Add(new ReturnPerformanceAppriasalApprovalModel() { PAAP_ID = "MED", PAAP_Comments = "Medical", PAAP_Status = true });
            if (model.PAAP_ID == "MAT") obj.PerformanceAppriasalApproval.Add(new ReturnPerformanceAppriasalApprovalModel() { PAAP_ID = "MAT", PAAP_Comments = "Matrinaty", PAAP_Status = true });
            objPerformanceAppriasalApprovalHeadList.Add(obj);
            return objPerformanceAppriasalApprovalHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.PerformanceAppriasalApproval_BL.get_PerformanceAppriasalApprovals_single(model);

            }
            catch (Exception ex)
            {

                ReturnPerformanceAppriasalApprovalModelHead objPerformanceAppriasalApprovalHead = new ReturnPerformanceAppriasalApprovalModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objPerformanceAppriasalApprovalHeadList.Add(objPerformanceAppriasalApprovalHead);

                objError.WriteLog(0, "PerformanceAppriasalAnswersApprovalController", "get_PerformanceAppriasalApproval_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalAnswersApprovalController", "get_PerformanceAppriasalApproval_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalAnswersApprovalController", "get_PerformanceAppriasalApproval_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalAnswersApprovalController", "get_PerformanceAppriasalApproval_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objPerformanceAppriasalApprovalHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnPerformanceAppriasalApprovalModelHead> get_PerformanceAppriasalApproval_all(PerformanceAppriasalApprovalSearchModel model)//ok
        {
            List<ReturnPerformanceAppriasalApprovalModelHead> objPerformanceAppriasalApprovalHeadList = new List<ReturnPerformanceAppriasalApprovalModelHead>();
            ReturnPerformanceAppriasalApprovalModelHead obj = new ReturnPerformanceAppriasalApprovalModelHead() { resp = false, msg = "sfsf" };
            obj.PerformanceAppriasalApproval = new List<ReturnPerformanceAppriasalApprovalModel>();
            obj.PerformanceAppriasalApproval.Add(new ReturnPerformanceAppriasalApprovalModel() { PAAP_ID = "CAS", PAAP_Comments = "Casual", PAAP_Status = true });
            obj.PerformanceAppriasalApproval.Add(new ReturnPerformanceAppriasalApprovalModel() { PAAP_ID = "ANU", PAAP_Comments = "Annual", PAAP_Status = true });
            obj.PerformanceAppriasalApproval.Add(new ReturnPerformanceAppriasalApprovalModel() { PAAP_ID = "MED", PAAP_Comments = "Medical", PAAP_Status = true });
            obj.PerformanceAppriasalApproval.Add(new ReturnPerformanceAppriasalApprovalModel() { PAAP_ID = "MAT", PAAP_Comments = "Matrinaty", PAAP_Status = true });
            objPerformanceAppriasalApprovalHeadList.Add(obj);
            return objPerformanceAppriasalApprovalHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.PerformanceAppriasalApproval_BL.get_PerformanceAppriasalApproval_all(model);

            }
            catch (Exception ex)
            {

                ReturnPerformanceAppriasalApprovalModelHead objPerformanceAppriasalApprovalHead = new ReturnPerformanceAppriasalApprovalModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objPerformanceAppriasalApprovalHeadList.Add(objPerformanceAppriasalApprovalHead);

                objError.WriteLog(0, "PerformanceAppriasalAnswersApprovalController", "get_PerformanceAppriasalApproval_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalAnswersApprovalController", "get_PerformanceAppriasalApproval_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalAnswersApprovalController", "get_PerformanceAppriasalApproval_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalAnswersApprovalController", "get_PerformanceAppriasalApproval_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objPerformanceAppriasalApprovalHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_PerformanceAppriasalApproval(PerformanceAppriasalApprovalModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.PerformanceAppriasalApproval_BL.add_new_PerformanceAppriasalApproval(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objPerformanceAppriasalApprovalHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objPerformanceAppriasalApprovalHead);

                objError.WriteLog(0, "PerformanceAppriasalAnswersApprovalController", "add_new_PerformanceAppriasalApproval", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalAnswersApprovalController", "add_new_PerformanceAppriasalApproval", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalAnswersApprovalController", "add_new_PerformanceAppriasalApproval", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalAnswersApprovalController", "add_new_PerformanceAppriasalApproval", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_PerformanceAppriasalApproval(PerformanceAppriasalApprovalModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.PerformanceAppriasalApproval_BL.modify_PerformanceAppriasalApproval(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objPerformanceAppriasalApprovalHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objPerformanceAppriasalApprovalHead);

                objError.WriteLog(0, "PerformanceAppriasalAnswersApprovalController", "modify_PerformanceAppriasalApproval", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalAnswersApprovalController", "modify_PerformanceAppriasalApproval", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalAnswersApprovalController", "modify_PerformanceAppriasalApproval", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalAnswersApprovalController", "modify_PerformanceAppriasalApproval", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_PerformanceAppriasalApproval(InactivePAAPModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.PerformanceAppriasalApproval_BL.inactivate_PerformanceAppriasalApproval(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objPerformanceAppriasalApprovalHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objPerformanceAppriasalApprovalHead);

                objError.WriteLog(0, "PerformanceAppriasalAnswersApprovalController", "inactivate_PerformanceAppriasalApproval", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalAnswersApprovalController", "inactivate_PerformanceAppriasalApproval", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalAnswersApprovalController", "inactivate_PerformanceAppriasalApproval", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalAnswersApprovalController", "inactivate_PerformanceAppriasalApproval", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

