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

    public class PerformanceAppriasalQuestionsController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnPerformanceAppriasalQuestionsModelHead> get_PerformanceAppriasalQuestions_single(PerformanceAppriasalQuestions model)//ok
        {
            List<ReturnPerformanceAppriasalQuestionsModelHead> objPerformanceAppriasalQuestionsHeadList = new List<ReturnPerformanceAppriasalQuestionsModelHead>();
            ReturnPerformanceAppriasalQuestionsModelHead obj = new ReturnPerformanceAppriasalQuestionsModelHead() { resp = false, msg = "sfsf" };
            obj.PerformanceAppriasalQuestions = new List<ReturnPerformanceAppriasalQuestionsModel>();
            if (model.PAAQ_ID == "CAS")
                obj.PerformanceAppriasalQuestions.Add(new ReturnPerformanceAppriasalQuestionsModel() { PAAQ_ID = "CAS", PAAQ_PerformanceAppriasalQuestions = "Casual", PAAQ_Status = true });
            if (model.PAAQ_ID == "ANU") obj.PerformanceAppriasalQuestions.Add(new ReturnPerformanceAppriasalQuestionsModel() { PAAQ_ID = "ANU", PAAQ_PerformanceAppriasalQuestions = "Annual", PAAQ_Status = true, PAAQ_LeaveAlotment = 10 });
            if (model.PAAQ_ID == "MED") obj.PerformanceAppriasalQuestions.Add(new ReturnPerformanceAppriasalQuestionsModel() { PAAQ_ID = "MED", PAAQ_PerformanceAppriasalQuestions = "Medical", PAAQ_Status = true, PAAQ_LeaveAlotment = 10 });
            if (model.PAAQ_ID == "MAT") obj.PerformanceAppriasalQuestions.Add(new ReturnPerformanceAppriasalQuestionsModel() { PAAQ_ID = "MAT", PAAQ_PerformanceAppriasalQuestions = "Matrinaty", PAAQ_Status = true, PAAQ_LeaveAlotment = 10 });
            objPerformanceAppriasalQuestionsHeadList.Add(obj);
            return objPerformanceAppriasalQuestionsHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.PerformanceAppriasalQuestions_BL.get_PerformanceAppriasalQuestions_single(model);

            }
            catch (Exception ex)
            {

                ReturnPerformanceAppriasalQuestionsModelHead objPerformanceAppriasalQuestionsHead = new ReturnPerformanceAppriasalQuestionsModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objPerformanceAppriasalQuestionsHeadList.Add(objPerformanceAppriasalQuestionsHead);

                objError.WriteLog(0, "PerformanceAppriasalQuestionsController", "get_PerformanceAppriasalQuestions_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalQuestionsController", "get_PerformanceAppriasalQuestions_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalQuestionsController", "get_PerformanceAppriasalQuestions_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalQuestionsController", "get_PerformanceAppriasalQuestions_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objPerformanceAppriasalQuestionsHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnPerformanceAppriasalQuestionsModelHead> get_PerformanceAppriasalQuestions_all(PerformanceAppriasalQuestionsSearchModel model)//ok
        {
            List<ReturnPerformanceAppriasalQuestionsModelHead> objPerformanceAppriasalQuestionsHeadList = new List<ReturnPerformanceAppriasalQuestionsModelHead>();
            ReturnPerformanceAppriasalQuestionsModelHead obj = new ReturnPerformanceAppriasalQuestionsModelHead() { resp = false, msg = "sfsf" };
            obj.PerformanceAppriasalQuestions = new List<ReturnPerformanceAppriasalQuestionsModel>();
            obj.PerformanceAppriasalQuestions.Add(new ReturnPerformanceAppriasalQuestionsModel() { PAAQ_ID = "CAS", PAAQ_PerformanceAppriasalQuestions = "Casual", PAAQ_Status = true, PAAQ_LeaveAlotment = 10 });
            obj.PerformanceAppriasalQuestions.Add(new ReturnPerformanceAppriasalQuestionsModel() { PAAQ_ID = "ANU", PAAQ_PerformanceAppriasalQuestions = "Annual", PAAQ_Status = true, PAAQ_LeaveAlotment = 10 });
            obj.PerformanceAppriasalQuestions.Add(new ReturnPerformanceAppriasalQuestionsModel() { PAAQ_ID = "MED", PAAQ_PerformanceAppriasalQuestions = "Medical", PAAQ_Status = true, PAAQ_LeaveAlotment = 10 });
            obj.PerformanceAppriasalQuestions.Add(new ReturnPerformanceAppriasalQuestionsModel() { PAAQ_ID = "MAT", PAAQ_PerformanceAppriasalQuestions = "Matrinaty", PAAQ_Status = true, PAAQ_LeaveAlotment = 10 });
            objPerformanceAppriasalQuestionsHeadList.Add(obj);
            return objPerformanceAppriasalQuestionsHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.PerformanceAppriasalQuestions_BL.get_PerformanceAppriasalQuestions_all(model);

            }
            catch (Exception ex)
            {

                ReturnPerformanceAppriasalQuestionsModelHead objPerformanceAppriasalQuestionsHead = new ReturnPerformanceAppriasalQuestionsModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objPerformanceAppriasalQuestionsHeadList.Add(objPerformanceAppriasalQuestionsHead);

                objError.WriteLog(0, "PerformanceAppriasalQuestionsController", "get_PerformanceAppriasalQuestions_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalQuestionsController", "get_PerformanceAppriasalQuestions_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalQuestionsController", "get_PerformanceAppriasalQuestions_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalQuestionsController", "get_PerformanceAppriasalQuestions_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objPerformanceAppriasalQuestionsHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> add_new_PerformanceAppriasalQuestions(PerformanceAppriasalQuestionsModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.PerformanceAppriasalQuestions_BL.add_new_PerformanceAppriasalQuestions(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objPerformanceAppriasalQuestionsHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objPerformanceAppriasalQuestionsHead);

                objError.WriteLog(0, "PerformanceAppriasalQuestionsController", "add_new_PerformanceAppriasalQuestions", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalQuestionsController", "add_new_PerformanceAppriasalQuestions", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalQuestionsController", "add_new_PerformanceAppriasalQuestions", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalQuestionsController", "add_new_PerformanceAppriasalQuestions", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> modify_PerformanceAppriasalQuestions(PerformanceAppriasalQuestionsModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.PerformanceAppriasalQuestions_BL.modify_PerformanceAppriasalQuestions(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objPerformanceAppriasalQuestionsHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objPerformanceAppriasalQuestionsHead);

                objError.WriteLog(0, "PerformanceAppriasalQuestionsController", "modify_PerformanceAppriasalQuestions", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalQuestionsController", "modify_PerformanceAppriasalQuestions", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalQuestionsController", "modify_PerformanceAppriasalQuestions", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalQuestionsController", "modify_PerformanceAppriasalQuestions", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_PerformanceAppriasalQuestions(InactivePAAQModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.PerformanceAppriasalQuestions_BL.inactivate_PerformanceAppriasalQuestions(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objPerformanceAppriasalQuestionsHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objPerformanceAppriasalQuestionsHead);

                objError.WriteLog(0, "PerformanceAppriasalQuestionsController", "inactivate_PerformanceAppriasalQuestions", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalQuestionsController", "inactivate_PerformanceAppriasalQuestions", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalQuestionsController", "inactivate_PerformanceAppriasalQuestions", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalQuestionsController", "inactivate_PerformanceAppriasalQuestions", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

