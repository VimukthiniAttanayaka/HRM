using HRM_DAL.Models;
using HRM_BL;
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

namespace HRM.Controllers
{
    //Unfinalized codes, cause of abnormal shut off of project!!!!!
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class DepartmentPaymentChargeCodeController : ControllerBase
    {
        private LogError objError = new LogError();



        //POST api/<DepartmentPaymentChargeCodeController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_departmentpcc(DepartmentPCCModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            //List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = departmentpaymentchargecode_BL.add_new_departmentpcc(item);
            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentPaymentChargeCodeController", "add_new_departmentpcc", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentPaymentChargeCodeController", "add_new_departmentpcc", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentPaymentChargeCodeController", "add_new_departmentpcc", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentPaymentChargeCodeController", "add_new_departmentpcc", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        } 
        
        //POST api/<DepartmentPaymentChargeCodeController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_departmentpcc(DepartmentPCCModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            //List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = departmentpaymentchargecode_BL.modify_departmentpcc(item);
            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentPaymentChargeCodeController", "modify_departmentpcc", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentPaymentChargeCodeController", "modify_departmentpcc", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentPaymentChargeCodeController", "modify_departmentpcc", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentPaymentChargeCodeController", "modify_departmentpcc", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_departmentpcc(InactiveDepartmentPCCModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = departmentpaymentchargecode_BL.inactivate_departmentpcc(item);
            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentPaymentChargeCodeController", "inactivate_departmentpcc", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentPaymentChargeCodeController", "inactivate_departmentpcc", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentPaymentChargeCodeController", "inactivate_departmentpcc", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentPaymentChargeCodeController", "inactivate_departmentpcc", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;



        }


        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturDepartmentPCCModelHead> get_departmentpcc_all(GetDepartmentPCCAllModel item)//ok
        {
            List<ReturDepartmentPCCModelHead> objHeadList = new List<ReturDepartmentPCCModelHead>();
            List<ReturnDepartmentPCCAllModel> objList = new List<ReturnDepartmentPCCAllModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = departmentpaymentchargecode_BL.get_departmentpcc_all(item);
            }
            catch (Exception ex)
            {

                ReturDepartmentPCCModelHead objHead = new ReturDepartmentPCCModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentPaymentChargeCodeController", "get_departmentpcc_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentPaymentChargeCodeController", "get_departmentpcc_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentPaymentChargeCodeController", "get_departmentpcc_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentPaymentChargeCodeController", "get_departmentpcc_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturDepartmentPCCModelHead> get_departmentpcc_single(GetDepartmentPCCSingleModel item)
        {
            List<ReturDepartmentPCCModelHead> objHeadList = new List<ReturDepartmentPCCModelHead>();
            List<ReturnDepartmentPCCModel> objList = new List<ReturnDepartmentPCCModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = departmentpaymentchargecode_BL.get_departmentpcc_single(item);

                return objHeadList;
            }
            catch (Exception ex)
            {

                ReturDepartmentPCCModelHead objHead = new ReturDepartmentPCCModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentPaymentChargeCodeController", "get_departmentpcc_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentPaymentChargeCodeController", "get_departmentpcc_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentPaymentChargeCodeController", "get_departmentpcc_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentPaymentChargeCodeController", "get_departmentpcc_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }



    }








}








