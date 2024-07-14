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

namespace HRM.Controllers
{
    //Unfinalized codes, cause of abnormal shut off of project!!!!!
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class DepartmentDeviceboxController : ControllerBase
    {
        private LogError objError = new LogError();



        //POST api/<DepartmentDeviceboxController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_departmentdevicebox(DepartmentDeviceboxModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.DepartmentDevicebox_BL.add_new_departmentdevicebox(item);
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

                objError.WriteLog(0, "DepartmentDeviceboxController", "add_new_departmentdevicebox", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentDeviceboxController", "add_new_departmentdevicebox", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentDeviceboxController", "add_new_departmentdevicebox", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentDeviceboxController", "add_new_departmentdevicebox", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        //POST api/<DepartmentDeviceboxController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_departmentdevicebox(DepartmentDeviceboxModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.DepartmentDevicebox_BL.modify_departmentdevicebox(item);
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

                objError.WriteLog(0, "DepartmentDeviceboxController", "modify_departmentdevicebox", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentDeviceboxController", "modify_departmentdevicebox", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentDeviceboxController", "modify_departmentdevicebox", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentDeviceboxController", "modify_departmentdevicebox", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_departmentdevicebox(InactiveDepartmentDeviceboxModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.DepartmentDevicebox_BL.inactivate_departmentdevicebox(item);
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

                objError.WriteLog(0, "DepartmentDeviceboxController", "inactivate_departmentdevicebox", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentDeviceboxController", "inactivate_departmentdevicebox", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentDeviceboxController", "inactivate_departmentdevicebox", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentDeviceboxController", "inactivate_departmentdevicebox", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objHeadList;
            }




        }


        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturDepartmentDeviceboxModelHead> get_departmentdevicebox_all(GetDepartmentDeviceboxAllModel item)//ok
        {
            List<ReturDepartmentDeviceboxModelHead> objHeadList = new List<ReturDepartmentDeviceboxModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.DepartmentDevicebox_BL.get_departmentdevicebox_all(item);
                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturDepartmentDeviceboxModelHead objHead = new ReturDepartmentDeviceboxModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentDeviceboxController", "get_departmentdevicebox_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentDeviceboxController", "get_departmentdevicebox_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentDeviceboxController", "get_departmentdevicebox_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentDeviceboxController", "get_departmentdevicebox_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }




        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturDepartmentDeviceboxModelHead> get_departmentdevicebox_single(GetDepartmentDeviceboxSingleModel item)
        {
            List<ReturDepartmentDeviceboxModelHead> objHeadList = new List<ReturDepartmentDeviceboxModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.MailTrack_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objHeadList = HRM_BL.DepartmentDevicebox_BL.get_departmentdevicebox_single(item);
                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturDepartmentDeviceboxModelHead objHead = new ReturDepartmentDeviceboxModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentDeviceboxController", "get_departmentdevicebox_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentDeviceboxController", "get_departmentdevicebox_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentDeviceboxController", "get_departmentdevicebox_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentDeviceboxController", "get_departmentdevicebox_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }



    }








}








