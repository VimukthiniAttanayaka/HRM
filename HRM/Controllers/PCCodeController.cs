using HRM_DAL.Models;
using error_handler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using utility_handler.Data;
//using static error_handler.InformationLog;
using static error_handler.ErrorLog;
using System.Reflection;
using static error_handler.InformationLog;

namespace HRM.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class PCCodeController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturPCCodeModelHead> get_PCCode_all(GetPCCodeAllModel item)//ok
        {
            List<ReturPCCodeModelHead> objHeadList = new List<ReturPCCodeModelHead>();
            //List<ReturnPCCodeAllModel> objList = new List<ReturnPCCodeAllModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.PCCode_BL.get_PCCode_all(item);
                return objHeadList;

            }
            catch (Exception ex)
            {
                ReturPCCodeModelHead objHead = new ReturPCCodeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "PCCodeController", "get_PCCode_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PCCodeController", "get_PCCode_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PCCodeController", "get_PCCode_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PCCodeController", "get_PCCode_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturPCCodeDistinctModelHead> get_PCCode_all_Distinct(GetPCCodeAllModel item)//ok
        {
            List<ReturPCCodeDistinctModelHead> objHeadList = new List<ReturPCCodeDistinctModelHead>();
            //List<ReturnPCCodeAllModel> objList = new List<ReturnPCCodeAllModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.PCCode_BL.get_PCCode_all_Distinct(item);
                return objHeadList;

            }
            catch (Exception ex)
            {
                ReturPCCodeDistinctModelHead objHead = new ReturPCCodeDistinctModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "PCCodeController", "get_PCCode_all_Distinct", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PCCodeController", "get_PCCode_all_Distinct", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PCCodeController", "get_PCCode_all_Distinct", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PCCodeController", "get_PCCode_all_Distinct", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturPCCodeModelHead> get_PCCode_single(GetPCCodeSingleModel item)
        {
            List<ReturPCCodeModelHead> objHeadList = new List<ReturPCCodeModelHead>();
            //List<ReturnPCCodeModel> objList = new List<ReturnPCCodeModel>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.PCCode_BL.get_PCCode_single(item);
                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturPCCodeModelHead objHead = new ReturPCCodeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "PCCodeController", "get_PCCode_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PCCodeController", "get_PCCode_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PCCodeController", "get_PCCode_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PCCodeController", "get_PCCode_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }


        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturPCCodeModelHead> get_PCCode_By_Department(GetPCCodeDepartmentModel item)//ok
        {
            List<ReturPCCodeModelHead> objHeadList = new List<ReturPCCodeModelHead>();
            //List<ReturnPCCodeAllModel> objList = new List<ReturnPCCodeAllModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.PCCode_BL.get_PCCode_By_Department(item);
                return objHeadList;

            }
            catch (Exception ex)
            {
                ReturPCCodeModelHead objHead = new ReturPCCodeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "PCCodeController", "get_PCCode_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PCCodeController", "get_PCCode_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PCCodeController", "get_PCCode_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PCCodeController", "get_PCCode_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }


        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturPCCodeModelHead> get_PCCode_By_Department_Customer(GetPCCodeDepartmentModel item)//ok
        {
            List<ReturPCCodeModelHead> objHeadList = new List<ReturPCCodeModelHead>();
            //List<ReturnPCCodeAllModel> objList = new List<ReturnPCCodeAllModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.PCCode_BL.get_PCCode_By_Department_Customer(item);
                return objHeadList;

            }
            catch (Exception ex)
            {
                ReturPCCodeModelHead objHead = new ReturPCCodeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "PCCodeController", "get_PCCode_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PCCodeController", "get_PCCode_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PCCodeController", "get_PCCode_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PCCodeController", "get_PCCode_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

    }








}








