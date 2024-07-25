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

    public class CountryController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnCountryModelHead> get_Country_single(Country model)//ok
        {
            List<ReturnCountryModelHead> objCountryHeadList = new List<ReturnCountryModelHead>();
            ReturnCountryModelHead obj = new ReturnCountryModelHead() { resp = false, msg = "sfsf" };
            obj.Country = new List<ReturnCountryModel>();
            if (model.MDCTY_CountryID == "CAS")
                obj.Country.Add(new ReturnCountryModel() { MDCTY_CountryID = "CAS", MDCTY_Country = "Casual", MDCTY_Status = true });
            if (model.MDCTY_CountryID == "ANU") obj.Country.Add(new ReturnCountryModel() { MDCTY_CountryID = "ANU", MDCTY_Country = "Annual", MDCTY_Status = true });
            if (model.MDCTY_CountryID == "MED") obj.Country.Add(new ReturnCountryModel() { MDCTY_CountryID = "MED", MDCTY_Country = "Medical", MDCTY_Status = true });
            if (model.MDCTY_CountryID == "MAT") obj.Country.Add(new ReturnCountryModel() { MDCTY_CountryID = "MAT", MDCTY_Country = "Matrinaty", MDCTY_Status = true });
            objCountryHeadList.Add(obj);
            return objCountryHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.Country_BL.get_Countrys_single(model);

            }
            catch (Exception ex)
            {

                ReturnCountryModelHead objCountryHead = new ReturnCountryModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCountryHeadList.Add(objCountryHead);

                objError.WriteLog(0, "CountryController", "get_Country_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "CountryController", "get_Country_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "CountryController", "get_Country_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "CountryController", "get_Country_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCountryHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnCountryModelHead> get_Country_all(CountrySearchModel model)//ok
        {
            List<ReturnCountryModelHead> objCountryHeadList = new List<ReturnCountryModelHead>();
            ReturnCountryModelHead obj = new ReturnCountryModelHead() { resp = false, msg = "sfsf" };
            obj.Country = new List<ReturnCountryModel>();
            obj.Country.Add(new ReturnCountryModel() { MDCTY_CountryID = "CAS", MDCTY_Country = "Casual", MDCTY_Status = true });
            obj.Country.Add(new ReturnCountryModel() { MDCTY_CountryID = "ANU", MDCTY_Country = "Annual", MDCTY_Status = true });
            obj.Country.Add(new ReturnCountryModel() { MDCTY_CountryID = "MED", MDCTY_Country = "Medical", MDCTY_Status = true });
            obj.Country.Add(new ReturnCountryModel() { MDCTY_CountryID = "MAT", MDCTY_Country = "Matrinaty", MDCTY_Status = true });
            objCountryHeadList.Add(obj);
            return objCountryHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.Country_BL.get_Country_all(model);

            }
            catch (Exception ex)
            {

                ReturnCountryModelHead objCountryHead = new ReturnCountryModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCountryHeadList.Add(objCountryHead);

                objError.WriteLog(0, "CountryController", "get_Country_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "CountryController", "get_Country_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "CountryController", "get_Country_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "CountryController", "get_Country_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCountryHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> add_new_Country(CountryModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Country_BL.add_new_Country(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objCountryHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objCountryHead);

                objError.WriteLog(0, "CountryController", "add_new_Country", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "CountryController", "add_new_Country", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "CountryController", "add_new_Country", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "CountryController", "add_new_Country", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> modify_Country(CountryModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Country_BL.modify_Country(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objCountryHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objCountryHead);

                objError.WriteLog(0, "CountryController", "modify_Country", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "CountryController", "modify_Country", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "CountryController", "modify_Country", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "CountryController", "modify_Country", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_Country(InactiveMDCTYModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Country_BL.inactivate_Country(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objCountryHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objCountryHead);

                objError.WriteLog(0, "CountryController", "inactivate_Country", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "CountryController", "inactivate_Country", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "CountryController", "inactivate_Country", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "CountryController", "inactivate_Country", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

