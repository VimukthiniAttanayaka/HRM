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

    public class DeliveryCourierCompanyController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_delivery_courier_company(DeliveryCourierCompanyModel item)//ok
        {
            List<ReturnResponse> objDCCHeadList = new List<ReturnResponse>();
            //List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objDCCHeadList = HRM_BL. deliverycouriercompany_BL.add_new_delivery_courier_company(item);
                return objDCCHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objDCCHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objDCCHeadList.Add(objDCCHead);

                objError.WriteLog(0, "DeliveryCourierCompanyController", "add_new_delivery_courier_company", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DeliveryCourierCompanyController", "add_new_delivery_courier_company", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DeliveryCourierCompanyController", "add_new_delivery_courier_company", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DeliveryCourierCompanyController", "add_new_delivery_courier_company", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objDCCHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_delivery_courier_company(DeliveryCourierCompanyModel item)//ok
        {
            List<ReturnResponse> objDCCHeadList = new List<ReturnResponse>();
            //List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objDCCHeadList = HRM_BL.deliverycouriercompany_BL.modify_delivery_courier_company(item);
                return objDCCHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objDCCHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objDCCHeadList.Add(objDCCHead);

                objError.WriteLog(0, "DeliveryCourierCompanyController", "modify_delivery_courier_company", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DeliveryCourierCompanyController", "modify_delivery_courier_company", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DeliveryCourierCompanyController", "modify_delivery_courier_company", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DeliveryCourierCompanyController", "modify_delivery_courier_company", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objDCCHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_delivery_courier_company(InactiveDCCompanyModel item)//ok
        {
            List<ReturnResponse> objDCCHeadList = new List<ReturnResponse>();
            //List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objDCCHeadList = HRM_BL.deliverycouriercompany_BL.inactivate_delivery_courier_company(item);

                return objDCCHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objDCCHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objDCCHeadList.Add(objDCCHead);

                objError.WriteLog(0, "DeliveryCourierCompanyController", "inactivate_delivery_courier_company", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DeliveryCourierCompanyController", "inactivate_delivery_courier_company", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DeliveryCourierCompanyController", "inactivate_delivery_courier_company", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DeliveryCourierCompanyController", "inactivate_delivery_courier_company", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objDCCHeadList;
            }




        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturDCCompanyModelHead> get_delivery_courier_company_all(GetDCCompanyAllModel Dccall)//ok
        {
            List<ReturDCCompanyModelHead> objDCCHeadList = new List<ReturDCCompanyModelHead>();
            //List<ReturnDCCompanyModel> objDCCList = new List<ReturnDCCompanyModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, Dccall);

                objDCCHeadList = HRM_BL.deliverycouriercompany_BL.get_delivery_courier_company_all(Dccall);

                return objDCCHeadList;

            }
            catch (Exception ex)
            {
               
                ReturDCCompanyModelHead objDCCHead = new ReturDCCompanyModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objDCCHeadList.Add(objDCCHead);

                objError.WriteLog(0, "DeliveryCourierCompanyController", "get_delivery_courier_company_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DeliveryCourierCompanyController", "get_delivery_courier_company_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DeliveryCourierCompanyController", "get_delivery_courier_company_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DeliveryCourierCompanyController", "get_delivery_courier_company_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objDCCHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturDCCompanyModelHead> get_delivery_courier_company_single(GetDCCompanyModel DCCsingle)
        {
            List<ReturDCCompanyModelHead> objDCCHeadList = new List<ReturDCCompanyModelHead>();
            //List<ReturnDCCompanyModel> objDCCList = new List<ReturnDCCompanyModel>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, DCCsingle);

                objDCCHeadList = HRM_BL.deliverycouriercompany_BL.get_delivery_courier_company_single(DCCsingle);

                return objDCCHeadList;

            }
            catch (Exception ex)
            {
           
                ReturDCCompanyModelHead objDCCHead = new ReturDCCompanyModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objDCCHeadList.Add(objDCCHead);

                objError.WriteLog(0, "DeliveryCourierCompanyController", "get_delivery_courier_company_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DeliveryCourierCompanyController", "get_delivery_courier_company_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DeliveryCourierCompanyController", "get_delivery_courier_company_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DeliveryCourierCompanyController", "get_delivery_courier_company_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objDCCHeadList;

        }



    }








}








