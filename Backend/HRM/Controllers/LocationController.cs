using HRM_DAL.Models;
using error_handler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using utility_handler.Data;
using static error_handler.ErrorLog;
//using static error_handler.InformationLog;
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

    public class locationController : ControllerBase
    {
        private LogError objError = new LogError();



        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnLocationAllModelHead> get_location_all(GetLocationAllModel item)//ok
        {
            List<ReturnLocationAllModelHead> objHeadList = new List<ReturnLocationAllModelHead>();
            List<ReturnLocationAllModel> objList = new List<ReturnLocationAllModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.Location_BL.get_location_all(item);
                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturnLocationAllModelHead objHead = new ReturnLocationAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "locationController", "get_location_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "locationController", "get_location_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "locationController", "get_location_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "locationController", "get_location_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }




        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnLocationModelHead> get_location_single(GetLocationSingleModel item)
        {
            List<ReturnLocationModelHead> objHeadList = new List<ReturnLocationModelHead>();
            List<ReturnLocationModel> objList = new List<ReturnLocationModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.Location_BL.get_location_single(item);
                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturnLocationModelHead objHead = new ReturnLocationModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "locationController", "get_location_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "locationController", "get_location_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "locationController", "get_location_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "locationController", "get_location_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }



    }








}








