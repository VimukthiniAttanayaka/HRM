﻿using HRM_DAL.Models;
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

    public class CustomerController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnCustomerModelHead> get_customers_single(Customer CUS_ID)//ok
        {
            List<ReturnCustomerModelHead> objCustomerHeadList = new List<ReturnCustomerModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, CUS_ID);

                return HRM_BL.Customer_BL.get_customers_single(CUS_ID);

            }
            catch (Exception ex)
            {

                ReturnCustomerModelHead objcustomerHead = new ReturnCustomerModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustomerHeadList.Add(objcustomerHead);

                objError.WriteLog(0, "CustomerController", "get_customers_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "CustomerController", "get_customers_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "CustomerController", "get_customers_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "CustomerController", "get_customers_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustomerHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnCustomerModelHead> get_customers_all(CustomerSearchModel model)//ok
        {
            List<ReturnCustomerModelHead> objcustomerHeadList = new List<ReturnCustomerModelHead>();
            ReturnCustomerModelHead obj = new ReturnCustomerModelHead() { resp = false, msg = "sfsf" };
            obj.Customer = new List<ReturnCustomerModel>();
            obj.Customer.Add(new ReturnCustomerModel() { CUS_CompanyName = "test", CUS_ID = "test" });
            obj.Customer.Add(new ReturnCustomerModel() { CUS_CompanyName = "test1", CUS_ID = "test1" });
            obj.Customer.Add(new ReturnCustomerModel() { CUS_CompanyName = "test2", CUS_ID = "test2" });
            objcustomerHeadList.Add(obj);
            return objcustomerHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.Customer_BL.get_customer_all(model);

            }
            catch (Exception ex)
            {

                ReturnCustomerModelHead objcustomerHead = new ReturnCustomerModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objcustomerHeadList.Add(objcustomerHead);

                objError.WriteLog(0, "customerController", "get_customer_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "customerController", "get_customer_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "customerController", "get_customer_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "customerController", "get_customer_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objcustomerHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> add_new_customer(CustomerModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Customer_BL.add_new_customer(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objcustomerHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objcustomerHead);

                objError.WriteLog(0, "CustomerController", "add_new_customer", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "CustomerController", "add_new_customer", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "CustomerController", "add_new_customer", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "CustomerController", "add_new_customer", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturncustResponse> modify_customer(CustomerModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Customer_BL.modify_customer(item);

            }
            catch (Exception ex)
            {

                ReturncustResponse objcustomerHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objcustomerHead);

                objError.WriteLog(0, "CustomerController", "modify_customer", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "CustomerController", "modify_customer", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "CustomerController", "modify_customer", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "CustomerController", "modify_customer", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_customer(InactiveCusModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            //objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            //return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.Customer_BL.inactivate_customer(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objcustomerHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objcustomerHead);

                objError.WriteLog(0, "CustomerController", "inactivate_customer", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "CustomerController", "inactivate_customer", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "CustomerController", "inactivate_customer", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "CustomerController", "inactivate_customer", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

