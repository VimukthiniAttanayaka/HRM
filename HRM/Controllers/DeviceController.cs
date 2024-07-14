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
namespace HRM.Controllers
{
    //Unfinalized codes, cause of abnormal shut off of project!!!!!
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class DeviceController : ControllerBase
    {
        private LogError objError = new LogError();



        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_device(DeviceModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            InformationLog.WriteLog(LogType.Info, "add_new_device : called", ModuleNames.MailTrack_API);

            try
            {
                objHeadList = Device_BL.add_new_device(item);
                return objHeadList;

            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DeviceController", "add_new_device", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DeviceController", "add_new_device", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DeviceController", "add_new_device", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DeviceController", "add_new_device", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_device(DeviceModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            InformationLog.WriteLog(LogType.Info, "modify_device : called", ModuleNames.MailTrack_API);

            try
            {
                objHeadList = Device_BL.modify_device(item);
                return objHeadList;

            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DeviceController", "modify_device", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DeviceController", "modify_device", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DeviceController", "modify_device", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DeviceController", "modify_device", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_device(InactiveDeviceModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            try
            {
                InformationLog.WriteLog(LogType.Info, "inactivate_device : called", ModuleNames.MailTrack_API);

                objHeadList = Device_BL.inactivate_device(item);

                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "UserController", "PostUsers", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "PostUsers", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "PostUsers", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "PostUsers", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objHeadList;
            }




        }


        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturDeviceModelHead> get_device_all(GetDeviceAllModel item)//ok
        {
            List<ReturDeviceModelHead> objHeadList = new List<ReturDeviceModelHead>();

            SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString);
            
            try
            {
                InformationLog.WriteLog(LogType.Info, "get_dvice_all : called", ModuleNames.MailTrack_API);

                objHeadList = Device_BL.get_device_all(item);

                return objHeadList;

            }
            catch (Exception ex)
            {
                if (lconn.State == ConnectionState.Open)
                {
                    lconn.Close();
                }
                ReturDeviceModelHead objHead = new ReturDeviceModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "UserController", "get_device_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "get_device_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "get_device_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "get_device_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }




        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturDeviceModelHead> get_device_single(GetDeviceSingleModel item)
        {
            List<ReturDeviceModelHead> objHeadList = new List<ReturDeviceModelHead>();

            SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString);
            
            try
            {
                InformationLog.WriteLog(LogType.Info, "get_device_single : called", ModuleNames.MailTrack_API);

                objHeadList = Device_BL.get_device_single(item);

                return objHeadList;
            }
            catch (Exception ex)
            {
                if (lconn.State == ConnectionState.Open)
                {
                    lconn.Close();
                }
                ReturDeviceModelHead objHead = new ReturDeviceModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "UserController", "GetUser", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "GetUser", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "GetUser", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "GetUser", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objHeadList;
        }
    }
}








