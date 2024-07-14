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
//using static error_handler.InformationLog;

namespace HRM.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class BusinessUnitController : ControllerBase
    {
        private LogError objError = new LogError();

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_business_unit(BusinessUnitModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.BusinessUnit_BL.add_new_business_unit(item);
            }
            catch (Exception ex)
            {
                ReturnResponse objUserHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "BusinessUnitController", "add_new_business_unit", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "BusinessUnitController", "add_new_business_unit", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "BusinessUnitController", "add_new_business_unit", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "BusinessUnitController", "add_new_business_unit", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_business_unit(BusinessUnitModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.BusinessUnit_BL.modify_business_unit(item);
            }
            catch (Exception ex)
            {
                ReturnResponse objUserHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "BusinessUnitController", "add_new_business_unit", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "BusinessUnitController", "add_new_business_unit", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "BusinessUnitController", "add_new_business_unit", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "BusinessUnitController", "add_new_business_unit", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_business_unit(InactiveModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.BusinessUnit_BL.inactivate_business_unit(item);
            }
            catch (Exception ex)
            {
                ReturnResponse objUserHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "BusinessUnitController", "inactivate_business_unit", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "BusinessUnitController", "inactivate_business_unit", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "BusinessUnitController", "inactivate_business_unit", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "BusinessUnitController", "inactivate_business_unit", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objUserHeadList;
        }


        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnBusinessUnitModelHead> get_business_unit_all(GetBuAllModel Buall)//ok
        {
            List<ReturnBusinessUnitModelHead> objBUHeadList = new List<ReturnBusinessUnitModelHead>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, Buall);

                return HRM_BL.BusinessUnit_BL.get_business_unit_all(Buall);
            }
            catch (Exception ex)
            {
                ReturnBusinessUnitModelHead objUserHead = new ReturnBusinessUnitModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objBUHeadList.Add(objUserHead);

                objError.WriteLog(0, "BusinessUnitController", "get_business_unit_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "BusinessUnitController", "get_business_unit_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "BusinessUnitController", "get_business_unit_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "BusinessUnitController", "get_business_unit_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objBUHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnCountryModelHead> get_country_with_select()//ok
        {
            List<ReturnCountryModelHead> objCountryHeadList = new List<ReturnCountryModelHead>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "");

                return HRM_BL.BusinessUnit_BL.get_country_with_select();
            }
            catch (Exception ex)
            {
                ReturnCountryModelHead objUserHead = new ReturnCountryModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCountryHeadList.Add(objUserHead);

                objError.WriteLog(0, "BusinessUnitController", "get_country_with_select", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "BusinessUnitController", "get_country_with_select", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "BusinessUnitController", "get_country_with_select", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "BusinessUnitController", "get_country_with_select", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objCountryHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnCurrencyModelHead> get_currency_with_select()//ok
        {
            List<ReturnCurrencyModelHead> objCurrencyHeadList = new List<ReturnCurrencyModelHead>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "");

                return HRM_BL.BusinessUnit_BL.get_currency_with_select();
            }
            catch (Exception ex)
            {
                ReturnCurrencyModelHead objUserHead = new ReturnCurrencyModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCurrencyHeadList.Add(objUserHead);

                objError.WriteLog(0, "BusinessUnitController", "get_currency_with_select", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "BusinessUnitController", "get_currency_with_select", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "BusinessUnitController", "get_currency_with_select", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "BusinessUnitController", "get_currency_with_select", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objCurrencyHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnBusinessUnitModelHead> get_business_unit_single(GetBusingleModel Busingle)
        {
            List<ReturnBusinessUnitModelHead> objBUHeadList = new List<ReturnBusinessUnitModelHead>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, Busingle);

                return HRM_BL.BusinessUnit_BL.get_business_unit_single(Busingle);
            }
            catch (Exception ex)
            {
                ReturnBusinessUnitModelHead objUserHead = new ReturnBusinessUnitModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objBUHeadList.Add(objUserHead);

                objError.WriteLog(0, "BusinessUnitController", "get_business_unit_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "BusinessUnitController", "get_business_unit_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "BusinessUnitController", "get_business_unit_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "BusinessUnitController", "get_business_unit_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objBUHeadList;

        }
    }

}








