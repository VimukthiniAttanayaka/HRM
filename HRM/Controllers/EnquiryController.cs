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

    public class EnquiryController : Controller
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<EnquiryHeaderResponceModel> modify_Enquiry(EnquirySubmitModel item)//ok
        {
            List<EnquiryHeaderResponceModel> objEnquiryHeadList = new List<EnquiryHeaderResponceModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Enquiry_BL.modify_Enquiry(item);
            }
            catch (Exception ex)
            {
                EnquiryHeaderResponceModel objEnquiryHead = new EnquiryHeaderResponceModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objEnquiryHeadList.Add(objEnquiryHead);

                objError.WriteLog(0, "EnquiryController", "modify_Enquiry", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EnquiryController", "modify_Enquiry", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EnquiryController", "modify_Enquiry", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EnquiryController", "modify_Enquiry", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objEnquiryHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<EnquiryHeaderResponceModel> get_Enquiry_details(EnquiryRequestModel item)//ok
        {
            List<EnquiryHeaderResponceModel> objEnquiryList = new List<EnquiryHeaderResponceModel>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Enquiry_BL.get_Enquiry_details(item);
            }
            catch (Exception ex)
            {
                EnquiryHeaderResponceModel objEnquiryHead = new EnquiryHeaderResponceModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objEnquiryList.Add(objEnquiryHead);

                objError.WriteLog(0, "EnquiryController", "get_Enquiry_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EnquiryController", "get_Enquiry_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EnquiryController", "get_Enquiry_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EnquiryController", "get_Enquiry_details", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objEnquiryList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<EnquiryGridViewHeaderModel> get_Enquiry_grid_details(EnquiryGridRequestModel item)//ok
        {
            List<EnquiryGridViewHeaderModel> objCountryHeadList = new List<EnquiryGridViewHeaderModel>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "");

                return HRM_BL.Enquiry_BL.get_Enquiry_grid_details(item);
            }
            catch (Exception ex)
            {
                EnquiryGridViewHeaderModel objEnquiryHead = new EnquiryGridViewHeaderModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCountryHeadList.Add(objEnquiryHead);

                objError.WriteLog(0, "EnquiryController", "get_Enquiry_grid_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EnquiryController", "get_Enquiry_grid_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EnquiryController", "get_Enquiry_grid_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EnquiryController", "get_Enquiry_grid_details", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objCountryHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<EnquiryMailBagGridViewHeaderModel> get_Enquiry_grid_details_mailbag(MailBagEnquiryGridRequestModel item)//ok
        {
            List<EnquiryMailBagGridViewHeaderModel> objCountryHeadList = new List<EnquiryMailBagGridViewHeaderModel>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "");

                return HRM_BL.Enquiry_BL.get_Enquiry_grid_details_mailbag(item);
            }
            catch (Exception ex)
            {
                EnquiryMailBagGridViewHeaderModel objEnquiryHead = new EnquiryMailBagGridViewHeaderModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCountryHeadList.Add(objEnquiryHead);

                objError.WriteLog(0, "EnquiryController", "get_Enquiry_grid_details_mailbag", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EnquiryController", "get_Enquiry_grid_details_mailbag", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EnquiryController", "get_Enquiry_grid_details_mailbag", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EnquiryController", "get_Enquiry_grid_details_mailbag", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objCountryHeadList;

        }
    }
}
