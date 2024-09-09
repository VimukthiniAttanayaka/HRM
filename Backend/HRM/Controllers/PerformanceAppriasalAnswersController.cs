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

    public class PerformanceAppriasalAnswersController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnPerformanceAppriasalAnswersModelHead> get_PerformanceAppriasalAnswers_single(PerformanceAppriasalAnswers model)//ok
        {
            List<ReturnPerformanceAppriasalAnswersModelHead> objPerformanceAppriasalAnswersHeadList = new List<ReturnPerformanceAppriasalAnswersModelHead>();
            ReturnPerformanceAppriasalAnswersModelHead obj = new ReturnPerformanceAppriasalAnswersModelHead() { resp = false, msg = "sfsf" };
            obj.PerformanceAppriasalAnswers = new List<ReturnPerformanceAppriasalAnswersModel>();
            if (model.PAAN_ID == "CAS")
                obj.PerformanceAppriasalAnswers.Add(new ReturnPerformanceAppriasalAnswersModel() { PAAN_ID = "CAS", PAAN_Comments = "Casual", PAAN_Status = true });
            if (model.PAAN_ID == "ANU") obj.PerformanceAppriasalAnswers.Add(new ReturnPerformanceAppriasalAnswersModel() { PAAN_ID = "ANU", PAAN_Comments = "Annual", PAAN_Status = true });
            if (model.PAAN_ID == "MED") obj.PerformanceAppriasalAnswers.Add(new ReturnPerformanceAppriasalAnswersModel() { PAAN_ID = "MED", PAAN_Comments = "Medical", PAAN_Status = true });
            if (model.PAAN_ID == "MAT") obj.PerformanceAppriasalAnswers.Add(new ReturnPerformanceAppriasalAnswersModel() { PAAN_ID = "MAT", PAAN_Comments = "Matrinaty", PAAN_Status = true });
            objPerformanceAppriasalAnswersHeadList.Add(obj);
            return objPerformanceAppriasalAnswersHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.PerformanceAppriasalAnswers_BL.get_PerformanceAppriasalAnswers_single(model);

            }
            catch (Exception ex)
            {

                ReturnPerformanceAppriasalAnswersModelHead objPerformanceAppriasalAnswersHead = new ReturnPerformanceAppriasalAnswersModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objPerformanceAppriasalAnswersHeadList.Add(objPerformanceAppriasalAnswersHead);

                objError.WriteLog(0, "PerformanceAppriasalAnswersController", "get_PerformanceAppriasalAnswers_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalAnswersController", "get_PerformanceAppriasalAnswers_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalAnswersController", "get_PerformanceAppriasalAnswers_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalAnswersController", "get_PerformanceAppriasalAnswers_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objPerformanceAppriasalAnswersHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnPerformanceAppriasalAnswersModelHead> get_PerformanceAppriasalAnswers_all(PerformanceAppriasalAnswersSearchModel model)//ok
        {
            List<ReturnPerformanceAppriasalAnswersModelHead> objPerformanceAppriasalAnswersHeadList = new List<ReturnPerformanceAppriasalAnswersModelHead>();
            ReturnPerformanceAppriasalAnswersModelHead obj = new ReturnPerformanceAppriasalAnswersModelHead() { resp = false, msg = "sfsf" };
            obj.PerformanceAppriasalAnswers = new List<ReturnPerformanceAppriasalAnswersModel>();
            obj.PerformanceAppriasalAnswers.Add(new ReturnPerformanceAppriasalAnswersModel() { PAAN_ID = "CAS", PAAN_Comments = "Casual", PAAN_Status = true });
            obj.PerformanceAppriasalAnswers.Add(new ReturnPerformanceAppriasalAnswersModel() { PAAN_ID = "ANU", PAAN_Comments = "Annual", PAAN_Status = true });
            obj.PerformanceAppriasalAnswers.Add(new ReturnPerformanceAppriasalAnswersModel() { PAAN_ID = "MED", PAAN_Comments = "Medical", PAAN_Status = true });
            obj.PerformanceAppriasalAnswers.Add(new ReturnPerformanceAppriasalAnswersModel() { PAAN_ID = "MAT", PAAN_Comments = "Matrinaty", PAAN_Status = true });
            objPerformanceAppriasalAnswersHeadList.Add(obj);
            return objPerformanceAppriasalAnswersHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.PerformanceAppriasalAnswers_BL.get_PerformanceAppriasalAnswers_all(model);

            }
            catch (Exception ex)
            {

                ReturnPerformanceAppriasalAnswersModelHead objPerformanceAppriasalAnswersHead = new ReturnPerformanceAppriasalAnswersModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objPerformanceAppriasalAnswersHeadList.Add(objPerformanceAppriasalAnswersHead);

                objError.WriteLog(0, "PerformanceAppriasalAnswersController", "get_PerformanceAppriasalAnswers_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalAnswersController", "get_PerformanceAppriasalAnswers_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalAnswersController", "get_PerformanceAppriasalAnswers_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalAnswersController", "get_PerformanceAppriasalAnswers_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objPerformanceAppriasalAnswersHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> add_new_PerformanceAppriasalAnswers(PerformanceAppriasalAnswersModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.PerformanceAppriasalAnswers_BL.add_new_PerformanceAppriasalAnswers(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objPerformanceAppriasalAnswersHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objPerformanceAppriasalAnswersHead);

                objError.WriteLog(0, "PerformanceAppriasalAnswersController", "add_new_PerformanceAppriasalAnswers", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalAnswersController", "add_new_PerformanceAppriasalAnswers", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalAnswersController", "add_new_PerformanceAppriasalAnswers", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalAnswersController", "add_new_PerformanceAppriasalAnswers", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> modify_PerformanceAppriasalAnswers(PerformanceAppriasalAnswersModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.PerformanceAppriasalAnswers_BL.modify_PerformanceAppriasalAnswers(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objPerformanceAppriasalAnswersHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objPerformanceAppriasalAnswersHead);

                objError.WriteLog(0, "PerformanceAppriasalAnswersController", "modify_PerformanceAppriasalAnswers", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalAnswersController", "modify_PerformanceAppriasalAnswers", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalAnswersController", "modify_PerformanceAppriasalAnswers", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalAnswersController", "modify_PerformanceAppriasalAnswers", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_PerformanceAppriasalAnswers(InactivePAANModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.PerformanceAppriasalAnswers_BL.inactivate_PerformanceAppriasalAnswers(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objPerformanceAppriasalAnswersHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objPerformanceAppriasalAnswersHead);

                objError.WriteLog(0, "PerformanceAppriasalAnswersController", "inactivate_PerformanceAppriasalAnswers", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PerformanceAppriasalAnswersController", "inactivate_PerformanceAppriasalAnswers", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PerformanceAppriasalAnswersController", "inactivate_PerformanceAppriasalAnswers", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PerformanceAppriasalAnswersController", "inactivate_PerformanceAppriasalAnswers", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

