using HRM_DAL.Models;
using error_handler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using utility_handler.Data;
using HRM_BL;
using static error_handler.ErrorLog;
using static error_handler.InformationLog;
using System.Reflection;

namespace HRM.Controllers
{
    //Unfinalized codes, cause of abnormal shut off of project!!!!!
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class KioskVendorController : ControllerBase
    {
        private LogError objError = new LogError();



        //POST api/<KioskVendorController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_kiosk_vendor(KVMasterModel item)//ok
        {
            List<ReturnResponse> objKVHeadList = new List<ReturnResponse>();
            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objKVHeadList = KioskVendor_BL.add_new_kiosk_vendor(item);
                return objKVHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objKVHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objKVHeadList.Add(objKVHead);

                objError.WriteLog(0, "KioskVendorController", "add_new_kiosk_vendor", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "KioskVendorController", "add_new_kiosk_vendor", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "KioskVendorController", "add_new_kiosk_vendor", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "KioskVendorController", "add_new_kiosk_vendor", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objKVHeadList;
        }

        //POST api/<MailTypeController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_kiosk_vendor(KVMasterModel item)//ok
        {
            List<ReturnResponse> objKVHeadList = new List<ReturnResponse>();
            List<SPResponse> objResponseList = new List<SPResponse>();


            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);
              
                objKVHeadList = KioskVendor_BL.modify_kiosk_vendor(item);
                return objKVHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objMTHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objKVHeadList.Add(objMTHead);

                objError.WriteLog(0, "MailTypeController", "modify_kiosk_vendor", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MailTypeController", "modify_kiosk_vendor", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MailTypeController", "modify_kiosk_vendor", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MailTypeController", "modify_kiosk_vendor", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objKVHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_kiosk_vendor(InactiveKVMasterModel item)//ok
        {
            List<ReturnResponse> objKVHeadList = new List<ReturnResponse>();
            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objKVHeadList = HRM_BL.KioskVendor_BL.inactivate_kiosk_vendor(item);
                return objKVHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objKVHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objKVHeadList.Add(objKVHead);

                objError.WriteLog(0, "KioskVendorController", "inactivate_kiosk_vendor", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "KioskVendorController", "inactivate_kiosk_vendor", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "KioskVendorController", "inactivate_kiosk_vendor", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "KioskVendorController", "inactivate_kiosk_vendor", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objKVHeadList;
            }







        }


        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturKVModelHead> get_kiosk_vendor_all(GetKVMasterAllModel KVall)//ok
        {
            List<ReturKVModelHead> objKVHeadList = new List<ReturKVModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, KVall);

                objKVHeadList = HRM_BL.KioskVendor_BL.get_kiosk_vendor_all(KVall);
                return objKVHeadList;
            }
            catch (Exception ex)
            {
            
                ReturKVModelHead objKVHead = new ReturKVModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objKVHeadList.Add(objKVHead);

                objError.WriteLog(0, "KioskVendorController", "get_kiosk_vendor_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "KioskVendorController", "get_kiosk_vendor_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "KioskVendorController", "get_kiosk_vendor_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "KioskVendorController", "get_kiosk_vendor_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objKVHeadList;

        }




        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturKVModelHead> get_kiosk_vendor_single(GetKVMasterModel KVsingle)
        {
            List<ReturKVModelHead> objKVHeadList = new List<ReturKVModelHead>();
            List<ReturnKVMasterModel> objKVList = new List<ReturnKVMasterModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, KVsingle);

                objKVHeadList = HRM_BL.KioskVendor_BL.get_kiosk_vendor_single(KVsingle);
                return objKVHeadList;
            }
            catch (Exception ex)
            {
             
                ReturKVModelHead objKVHead = new ReturKVModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objKVHeadList.Add(objKVHead);

                objError.WriteLog(0, "KioskVendorController", "get_kiosk_vendor_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "KioskVendorController", "get_kiosk_vendor_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "KioskVendorController", "get_kiosk_vendor_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "KioskVendorController", "get_kiosk_vendor_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objKVHeadList;

        }



    }




}








