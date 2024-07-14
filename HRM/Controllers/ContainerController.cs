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

    public class containerController : ControllerBase
    {
        private LogError objError = new LogError();


        //Unfinalized codes, cause of abnormal shut off of project!!!!!
        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_container(ContainerModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            //List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.container_BL.add_new_container(item);
            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "containerController", "add_new_container", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "containerController", "add_new_container", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "containerController", "add_new_container", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "containerController", "add_new_container", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_container(ContainerModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            //List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.container_BL.modify_container(item);
            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "containerController", "modify_container", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "containerController", "modify_container", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "containerController", "modify_container", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "containerController", "modify_container", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }


        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_container(InactiveContainerModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            //List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.container_BL.inactivate_container(item);
            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "containerController", "inactivate_container", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "containerController", "inactivate_container", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "containerController", "inactivate_container", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "containerController", "inactivate_container", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }


        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnContainerModelHead> get_container_all(GetContainerAllModel item)//ok
        {
            List<ReturnContainerModelHead> objHeadList = new List<ReturnContainerModelHead>();
            //List<ReturnContainerAllModel> objList = new List<ReturnContainerAllModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.container_BL.get_container_all(item);
            }
            catch (Exception ex)
            {
                ReturnContainerModelHead objHead = new ReturnContainerModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "containerController", "get_container_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "containerController", "get_container_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "containerController", "get_container_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "containerController", "get_container_all", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;

        }




        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnContainerModelHead> get_container_single(GetContainerSingleModel item)
        {
            List<ReturnContainerModelHead> objHeadList = new List<ReturnContainerModelHead>();
            //List<ReturnContainerModel> objList = new List<ReturnContainerModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.container_BL.get_container_single(item);
            }
            catch (Exception ex)
            {
                ReturnContainerModelHead objHead = new ReturnContainerModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "containerController", "get_container_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "containerController", "get_container_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "containerController", "get_container_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "containerController", "get_container_single", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }

            return objHeadList;

        }



    }








}








