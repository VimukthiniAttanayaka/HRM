using HRM_DAL.Models;
using error_handler;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using utility_handler.Data;
using System.Reflection;

namespace HRM.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class ExitInterviewQuestionsController : ControllerBase
    {
        private LogError objError = new LogError();

        //POST api/<ExitInterviewQuestionsController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_ExitInterviewQuestions(ExitInterviewQuestionsModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            //List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.ExitInterviewQuestions_BL.add_new_ExitInterviewQuestions(item);
                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "ExitInterviewQuestionsController", "add_new_ExitInterviewQuestions", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ExitInterviewQuestionsController", "add_new_ExitInterviewQuestions", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ExitInterviewQuestionsController", "add_new_ExitInterviewQuestions", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ExitInterviewQuestionsController", "add_new_ExitInterviewQuestions", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_ExitInterviewQuestions(ExitInterviewQuestionsModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.ExitInterviewQuestions_BL.modify_ExitInterviewQuestions(item);
                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "ExitInterviewQuestionsController", "modify_ExitInterviewQuestions", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ExitInterviewQuestionsController", "modify_ExitInterviewQuestions", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ExitInterviewQuestionsController", "modify_ExitInterviewQuestions", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ExitInterviewQuestionsController", "modify_ExitInterviewQuestions", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_ExitInterviewQuestions(InactiveExitInterviewQuestionsModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.ExitInterviewQuestions_BL.inactivate_ExitInterviewQuestions(item);
                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "ExitInterviewQuestionsController", "inactivate_ExitInterviewQuestions", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ExitInterviewQuestionsController", "inactivate_ExitInterviewQuestions", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ExitInterviewQuestionsController", "inactivate_ExitInterviewQuestions", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ExitInterviewQuestionsController", "inactivate_ExitInterviewQuestions", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objHeadList;
            }




        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturExitInterviewQuestionsModelHead> get_ExitInterviewQuestions_all(GetExitInterviewQuestionsAllModel item)//ok
        {
            List<ReturExitInterviewQuestionsModelHead> objHeadList = new List<ReturExitInterviewQuestionsModelHead>();

            ReturExitInterviewQuestionsModelHead obj = new ReturExitInterviewQuestionsModelHead() { resp = false, msg = "sfsf" };
            obj.ExitInterviewQuestions = new List<ReturnExitInterviewQuestionsModel>();
            obj.ExitInterviewQuestions.Add(new ReturnExitInterviewQuestionsModel() { EIEIQ_ID = 1, EIEIQ_EntryType = "CAS", EIEIQ_Description = "Casual", EIEIQ_Status = true });
            obj.ExitInterviewQuestions.Add(new ReturnExitInterviewQuestionsModel() { EIEIQ_ID = 2, EIEIQ_EntryType = "ANU", EIEIQ_Description = "Annual", EIEIQ_Status = true });
            obj.ExitInterviewQuestions.Add(new ReturnExitInterviewQuestionsModel() { EIEIQ_ID = 3, EIEIQ_EntryType = "MED", EIEIQ_Description = "Medical", EIEIQ_Status = false });
            obj.ExitInterviewQuestions.Add(new ReturnExitInterviewQuestionsModel() { EIEIQ_ID = 4, EIEIQ_EntryType = "MAT", EIEIQ_Description = "Matrinaty", EIEIQ_Status = true });
            objHeadList.Add(obj);
            return objHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.ExitInterviewQuestions_BL.get_ExitInterviewQuestions_all(item);
                return objHeadList;

            }
            catch (Exception ex)
            {
                ReturExitInterviewQuestionsModelHead objHead = new ReturExitInterviewQuestionsModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "ExitInterviewQuestionsController", "get_ExitInterviewQuestions_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ExitInterviewQuestionsController", "get_ExitInterviewQuestions_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ExitInterviewQuestionsController", "get_ExitInterviewQuestions_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ExitInterviewQuestionsController", "get_ExitInterviewQuestions_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturExitInterviewQuestionsModelHead> get_ExitInterviewQuestions_single(GetExitInterviewQuestionsSingleModel item)
        {
            List<ReturExitInterviewQuestionsModelHead> objHeadList = new List<ReturExitInterviewQuestionsModelHead>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.ExitInterviewQuestions_BL.get_ExitInterviewQuestions_single(item);
                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturExitInterviewQuestionsModelHead objHead = new ReturExitInterviewQuestionsModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "ExitInterviewQuestionsController", "get_ExitInterviewQuestions_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ExitInterviewQuestionsController", "get_ExitInterviewQuestions_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ExitInterviewQuestionsController", "get_ExitInterviewQuestions_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ExitInterviewQuestionsController", "get_ExitInterviewQuestions_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }
    }

    public class ExitInterviewQuestionsExcelSampleModel
    {
        public string FileFullPath { get; set; }
    }
}








