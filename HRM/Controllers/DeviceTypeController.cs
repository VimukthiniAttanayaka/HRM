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

    public class devicetypeController : ControllerBase
    {
        private LogError objError = new LogError();



        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_device_type(DeviceTypeModel item)//ok
        {
            List<ReturnResponse> objDTHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objDTHeadList = DeviceType_BL.add_new_device_type(item);
                return objDTHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objDTHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objDTHeadList.Add(objDTHead);

                objError.WriteLog(0, "UserController", "add_new_device_type", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "add_new_device_type", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "add_new_device_type", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "add_new_device_type", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objDTHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_device_type(DeviceTypeModel item)//ok
        {
            List<ReturnResponse> objDTHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objDTHeadList = DeviceType_BL.modify_device_type(item);
                return objDTHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objDTHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objDTHeadList.Add(objDTHead);

                objError.WriteLog(0, "UserController", "modify_device_type", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "modify_device_type", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "modify_device_type", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "modify_device_type", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objDTHeadList;
        }


        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_device_type(InactiveDeviceTypeModel item)//ok
        {
            List<ReturnResponse> objDTHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objDTHeadList = DeviceType_BL.inactivate_device_type(item);
                return objDTHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objDTHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objDTHeadList.Add(objDTHead);

                objError.WriteLog(0, "UserController", "PostUsers", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "PostUsers", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "PostUsers", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "PostUsers", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objDTHeadList;
            }







        }


        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnDeviceTypeModelHead> get_device_type_all(GetDeviceTypeAllModel DTall)//ok
        {
            List<ReturnDeviceTypeModelHead> objMTHeadList = new List<ReturnDeviceTypeModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, DTall);

                objMTHeadList = DeviceType_BL.get_device_type_all(DTall);
                return objMTHeadList;
            }
            catch (Exception ex)
            {
                ReturnDeviceTypeModelHead objMTHead = new ReturnDeviceTypeModelHead
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

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnDeviceTypeModelHead> get_device_type_single(GetDeviceTypesingleModel DTsingle)
        {
            List<ReturnDeviceTypeModelHead> objDTHeadList = new List<ReturnDeviceTypeModelHead>();
            List<ReturnDeviceTypeModel> objDTList = new List<ReturnDeviceTypeModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, DTsingle);

                objDTHeadList = DeviceType_BL.get_device_type_single(DTsingle);
                return objDTHeadList;

            }
            catch (Exception ex)
            {

                ReturnDeviceTypeModelHead objDTHead = new ReturnDeviceTypeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objDTHeadList.Add(objDTHead);

                objError.WriteLog(0, "DeviceTypeController", "get_device_type_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DeviceTypeController", "get_device_type_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DeviceTypeController", "get_device_type_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DeviceTypeController", "get_device_type_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objDTHeadList;

        }



    }




}








