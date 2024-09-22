using HRM_DAL.Models;
using error_handler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using utility_handler.Data;
using static error_handler.ErrorLog;
using HRM_BL;
using System.Reflection;

namespace HRM.Controllers
{
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
            ReturnLocationAllModelHead obj = new ReturnLocationAllModelHead() { resp = false, msg = "sfsf" };
            obj.location = new List<ReturnLocationAllModel>();
            obj.location.Add(new ReturnLocationAllModel() {MDL_LocationID  = "CAS",MDL_Location  = "Casual", MDL_Status = true });
            obj.location.Add(new ReturnLocationAllModel() { MDL_LocationID = "ANU", MDL_Location = "Annual", MDL_Status = false });
            obj.location.Add(new ReturnLocationAllModel() { MDL_LocationID = "MED", MDL_Location = "Medical", MDL_Status = true });
            obj.location.Add(new ReturnLocationAllModel() { MDL_LocationID = "MAT", MDL_Location = "Matrinaty", MDL_Status = true });
            obj.location.Add(new ReturnLocationAllModel() { MDL_LocationID = "CAS", MDL_Location = "Casual", MDL_Status = true });
            objHeadList.Add(obj);
            return objHeadList;

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

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_Location(LocationModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Location_BL.add_new_Location(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objLocationHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objLocationHead);

                objError.WriteLog(0, "LocationController", "add_new_Location", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LocationController", "add_new_Location", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LocationController", "add_new_Location", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LocationController", "add_new_Location", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_Location(LocationModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Location_BL.modify_Location(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objLocationHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objLocationHead);

                objError.WriteLog(0, "LocationController", "modify_Location", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LocationController", "modify_Location", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LocationController", "modify_Location", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LocationController", "modify_Location", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_Location(InactiveMDLModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            //objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            //return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Location_BL.inactivate_Location(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objLocationHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objLocationHead);

                objError.WriteLog(0, "LocationController", "inactivate_Location", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LocationController", "inactivate_Location", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LocationController", "inactivate_Location", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LocationController", "inactivate_Location", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}








