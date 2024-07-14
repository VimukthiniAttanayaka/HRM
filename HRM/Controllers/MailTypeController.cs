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

    public class MailTypeController : ControllerBase
    {
        private LogError objError = new LogError();

        //POST api/<MailTypeController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_mail_type(MailTypeModel item)//ok
        {
            List<ReturnResponse> objMTHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objMTHeadList = MailType_BL.add_new_mail_type(item);
                return objMTHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objMTHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMTHeadList.Add(objMTHead);

                objError.WriteLog(0, "MailTypeController", "add_new_mail_type", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MailTypeController", "add_new_mail_type", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MailTypeController", "add_new_mail_type", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MailTypeController", "add_new_mail_type", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objMTHeadList;
        }

        //POST api/<MailTypeController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_mail_type(MailTypeModel item)//ok
        {
            List<ReturnResponse> objMTHeadList = new List<ReturnResponse>();
            List<SPResponse> objResponseList = new List<SPResponse>();


            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objMTHeadList = MailType_BL.modify_mail_type(item);
                return objMTHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objMTHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMTHeadList.Add(objMTHead);

                objError.WriteLog(0, "MailTypeController", "modify_mail_type", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MailTypeController", "modify_mail_type", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MailTypeController", "modify_mail_type", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MailTypeController", "modify_mail_type", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objMTHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_mail_type(InactiveMailTypeModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            List<SPResponse> objResponseList = new List<SPResponse>();
            

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objUserHeadList = MailType_BL.inactivate_mail_type(item);
                return objUserHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objUserHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "MailTypeController", "inactivate_mail_type", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MailTypeController", "inactivate_mail_type", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MailTypeController", "inactivate_mail_type", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MailTypeController", "inactivate_mail_type", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturMailTypeModelHead> get_mail_type_single(GetMtsingleModel MTingle)
        {
            List<ReturMailTypeModelHead> objMTHeadList = new List<ReturMailTypeModelHead>();
            List<ReturnMailTypeModel> objMTList = new List<ReturnMailTypeModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, MTingle);

                objMTHeadList = MailType_BL.get_mail_type_single(MTingle);
                return objMTHeadList;
            }
            catch (Exception ex)
            {
            
                ReturMailTypeModelHead objMTHead = new ReturMailTypeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMTHeadList.Add(objMTHead);

                objError.WriteLog(0, "MailTypeController", "get_mail_type_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MailTypeController", "get_mail_type_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MailTypeController", "get_mail_type_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MailTypeController", "get_mail_type_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objMTHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturMailTypeModelHead> get_mail_type_all(GetMtAllModel MTall)
        {
            List<ReturMailTypeModelHead> objMTHeadList = new List<ReturMailTypeModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, MTall);

                objMTHeadList = MailType_BL.get_mail_type_all(MTall);
                return objMTHeadList;
            }
            catch (Exception ex)
            {
                ReturMailTypeModelHead objMTHead = new ReturMailTypeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMTHeadList.Add(objMTHead);

                objError.WriteLog(0, "MailTypeController", "get_mail_type_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MailTypeController", "get_mail_type_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MailTypeController", "get_mail_type_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MailTypeController", "get_mail_type_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objMTHeadList;
        }
    }
}








