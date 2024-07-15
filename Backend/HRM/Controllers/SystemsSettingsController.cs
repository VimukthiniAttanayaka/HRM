using HRM_DAL.Models;
using error_handler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using utility_handler.Data;
using HRM_BL;
using System.Reflection;

namespace HRM.Controllers
{
    //Unfinalized codes, cause of abnormal shut off of project!!!!!
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class systemssettingsController : ControllerBase
    {
        private LogError objError = new LogError();


        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturCountryModelHead> get_country_all(GetCountryAllModel Coall)//ok
        {
            List<ReturCountryModelHead> objCouHeadList = new List<ReturCountryModelHead>();
            
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, Coall);

                objCouHeadList = systemssettings_BL.get_country_all(Coall);
                return objCouHeadList;
            }
            catch (Exception ex)
            {
            
                ReturCountryModelHead objCouHead = new ReturCountryModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCouHeadList.Add(objCouHead);

                objError.WriteLog(0, "systemssettingsController", "get_country_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "systemssettingsController", "get_country_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "systemssettingsController", "get_country_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "systemssettingsController", "get_country_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCouHeadList;

        }
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturCountryModelHead> get_country_single(GetCountrysingleModel Cosingle)//ok
        {
            List<ReturCountryModelHead> objCouHeadList = new List<ReturCountryModelHead>();
                                   
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, Cosingle);

                objCouHeadList = systemssettings_BL.get_country_single(Cosingle);
                return objCouHeadList;
            }
            catch (Exception ex)
            {
            
                ReturCountryModelHead objCouHead = new ReturCountryModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCouHeadList.Add(objCouHead);

                objError.WriteLog(0, "systemssettingsController", "get_country_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "systemssettingsController", "get_country_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "systemssettingsController", "get_country_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "systemssettingsController", "get_country_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCouHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturCurrencyModelHead> get_currency_all(GetCurrencyAllModel Cuall)//ok
        {
            List<ReturCurrencyModelHead> objCurHeadList = new List<ReturCurrencyModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, Cuall);

                objCurHeadList = systemssettings_BL.get_currency_all(Cuall);
                return objCurHeadList;
            }
            catch (Exception ex)
            {
              
                ReturCurrencyModelHead objCurHead = new ReturCurrencyModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCurHeadList.Add(objCurHead);

                objError.WriteLog(0, "systemssettingsController", "get_currency_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "systemssettingsController", "get_currency_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "systemssettingsController", "get_currency_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "systemssettingsController", "get_currency_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCurHeadList;

        }
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturCurrencyModelHead> get_currency_single(GetCurrencyAllModel Cusingle)//ok
        {
            List<ReturCurrencyModelHead> objCurHeadList = new List<ReturCurrencyModelHead>();
            List<ReturnCurrencyAllModel> objCurList = new List<ReturnCurrencyAllModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, Cusingle);

                objCurHeadList = systemssettings_BL.get_currency_single(Cusingle);
                return objCurHeadList;
            }
            catch (Exception ex)
            {
             
                ReturCurrencyModelHead objCurHead = new ReturCurrencyModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCurHeadList.Add(objCurHead);

                objError.WriteLog(0, "systemssettingsController", "get_currency_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "systemssettingsController", "get_currency_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "systemssettingsController", "get_currency_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "systemssettingsController", "get_currency_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCurHeadList;

        }




    }








}








