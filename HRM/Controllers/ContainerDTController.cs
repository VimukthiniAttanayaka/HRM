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

    public class containerdtController : ControllerBase
    {
        private LogError objError = new LogError();


        //Unfinalized codes, cause of abnormal shut off of project!!!!!
        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_containerdt(ContainerDTModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.ContainerDT_BL.add_new_containerdt(item);
            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "containerDTController", "add_new_containerdt", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "containerDTController", "add_new_containerdt", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "containerDTController", "add_new_containerdt", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "containerDTController", "add_new_containerdt", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_containerdt(ContainerDTModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            try
            {
                InformationLog.WriteLog(LogType.Info, "modify_containerdt : called", LogAuditData.ModuleNames.MailTrack_API);

                return HRM_BL.ContainerDT_BL.modify_containerdt(item);
            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "containerDTController", "modify_containerdt", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "containerDTController", "modify_containerdt", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "containerDTController", "modify_containerdt", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "containerDTController", "modify_containerdt", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_containerdt(InactiveContainerDTModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.ContainerDT_BL.inactivate_containerdt(item);
            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "containerDTController", "inactivate_containerdt", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "containerDTController", "inactivate_containerdt", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "containerDTController", "inactivate_containerdt", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "containerDTController", "inactivate_containerdt", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }


        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnContainerDTModelHead> get_containerdt_all(GetContainerDTAllModel item)//ok
        {
            List<ReturnContainerDTModelHead> objHeadList = new List<ReturnContainerDTModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.ContainerDT_BL.get_containerdt_all(item);
            }
            catch (Exception ex)
            {
                ReturnContainerDTModelHead objHead = new ReturnContainerDTModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "containerDTController", "get_containerdt_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "containerDTController", "get_containerdt_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "containerDTController", "get_containerdt_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "containerDTController", "get_containerdt_all", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;

        }




        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnContainerDTModelHead> get_containerdt_single(GetContainerDTSingleModel item)
        {
            List<ReturnContainerDTModelHead> objHeadList = new List<ReturnContainerDTModelHead>();
            List<ReturnContainerDTModel> objList = new List<ReturnContainerDTModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.ContainerDT_BL.get_containerdt_single(item);
            }
            catch (Exception ex)
            {
                ReturnContainerDTModelHead objHead = new ReturnContainerDTModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "containerDTController", "get_containerdt_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "containerDTController", "get_containerdt_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "containerDTController", "get_containerdt_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "containerDTController", "get_containerdt_single", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }

            return objHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnContainerLTModelHead> get_container_label_types(GetContainerLTAllModel item)
        {
            List<ReturnContainerLTModelHead> objHeadList = new List<ReturnContainerLTModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.ContainerDT_BL.get_container_label_types(item);
            }
            catch (Exception ex)
            {
                ReturnContainerLTModelHead objHead = new ReturnContainerLTModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "containerDTController", "get_container_label_types", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "containerDTController", "get_container_label_types", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "containerDTController", "get_container_label_types", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "containerDTController", "get_container_label_types", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }

            return objHeadList;

        }



    }








}








