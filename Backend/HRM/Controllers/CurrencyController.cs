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

    public class CurrencyController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnCurrencyModelHead> get_Currency_single(Currency model)//ok
        {
            List<ReturnCurrencyModelHead> objCurrencyHeadList = new List<ReturnCurrencyModelHead>();
            ReturnCurrencyModelHead obj = new ReturnCurrencyModelHead() { resp = false, msg = "sfsf" };
            obj.Currency = new List<ReturnCurrencyModel>();
            if (model.MDCCY_CurrencyID == "CAS")
                obj.Currency.Add(new ReturnCurrencyModel() { MDCCY_CurrencyID = "CAS", MDCCY_Currency = "Casual", MDCCY_Status = true });
            if (model.MDCCY_CurrencyID == "ANU") obj.Currency.Add(new ReturnCurrencyModel() { MDCCY_CurrencyID = "ANU", MDCCY_Currency = "Annual", MDCCY_Status = true, MDCCY_LeaveAlotment = 10 });
            if (model.MDCCY_CurrencyID == "MED") obj.Currency.Add(new ReturnCurrencyModel() { MDCCY_CurrencyID = "MED", MDCCY_Currency = "Medical", MDCCY_Status = true, MDCCY_LeaveAlotment = 10 });
            if (model.MDCCY_CurrencyID == "MAT") obj.Currency.Add(new ReturnCurrencyModel() { MDCCY_CurrencyID = "MAT", MDCCY_Currency = "Matrinaty", MDCCY_Status = true, MDCCY_LeaveAlotment = 10 });
            objCurrencyHeadList.Add(obj);
            return objCurrencyHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.Currency_BL.get_Currencys_single(model);

            }
            catch (Exception ex)
            {

                ReturnCurrencyModelHead objCurrencyHead = new ReturnCurrencyModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCurrencyHeadList.Add(objCurrencyHead);

                objError.WriteLog(0, "CurrencyController", "get_Currency_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "CurrencyController", "get_Currency_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "CurrencyController", "get_Currency_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "CurrencyController", "get_Currency_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCurrencyHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnCurrencyModelHead> get_Currency_all(CurrencySearchModel model)//ok
        {
            List<ReturnCurrencyModelHead> objCurrencyHeadList = new List<ReturnCurrencyModelHead>();
            ReturnCurrencyModelHead obj = new ReturnCurrencyModelHead() { resp = false, msg = "sfsf" };
            obj.Currency = new List<ReturnCurrencyModel>();
            obj.Currency.Add(new ReturnCurrencyModel() { MDCCY_CurrencyID = "CAS", MDCCY_Currency = "Casual", MDCCY_Status = true, MDCCY_LeaveAlotment = 10 });
            obj.Currency.Add(new ReturnCurrencyModel() { MDCCY_CurrencyID = "ANU", MDCCY_Currency = "Annual", MDCCY_Status = true, MDCCY_LeaveAlotment = 10 });
            obj.Currency.Add(new ReturnCurrencyModel() { MDCCY_CurrencyID = "MED", MDCCY_Currency = "Medical", MDCCY_Status = true, MDCCY_LeaveAlotment = 10 });
            obj.Currency.Add(new ReturnCurrencyModel() { MDCCY_CurrencyID = "MAT", MDCCY_Currency = "Matrinaty", MDCCY_Status = true, MDCCY_LeaveAlotment = 10 });
            objCurrencyHeadList.Add(obj);
            return objCurrencyHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.Currency_BL.get_Currency_all(model);

            }
            catch (Exception ex)
            {

                ReturnCurrencyModelHead objCurrencyHead = new ReturnCurrencyModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCurrencyHeadList.Add(objCurrencyHead);

                objError.WriteLog(0, "CurrencyController", "get_Currency_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "CurrencyController", "get_Currency_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "CurrencyController", "get_Currency_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "CurrencyController", "get_Currency_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCurrencyHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_Currency(CurrencyModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Currency_BL.add_new_Currency(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objCurrencyHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objCurrencyHead);

                objError.WriteLog(0, "CurrencyController", "add_new_Currency", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "CurrencyController", "add_new_Currency", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "CurrencyController", "add_new_Currency", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "CurrencyController", "add_new_Currency", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_Currency(CurrencyModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Currency_BL.modify_Currency(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objCurrencyHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objCurrencyHead);

                objError.WriteLog(0, "CurrencyController", "modify_Currency", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "CurrencyController", "modify_Currency", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "CurrencyController", "modify_Currency", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "CurrencyController", "modify_Currency", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_Currency(InactiveMDCCYModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Currency_BL.inactivate_Currency(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objCurrencyHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objCurrencyHead);

                objError.WriteLog(0, "CurrencyController", "inactivate_Currency", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "CurrencyController", "inactivate_Currency", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "CurrencyController", "inactivate_Currency", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "CurrencyController", "inactivate_Currency", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

