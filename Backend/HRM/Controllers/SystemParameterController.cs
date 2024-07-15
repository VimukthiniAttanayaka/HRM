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

    public class SystemParameterController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturSystemPMModelHead> get_system_parameter_all(GetSystemPMAllModel SPMall)//ok
        {
            List<ReturSystemPMModelHead> objSPMHeadList = new List<ReturSystemPMModelHead>();


            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, SPMall);

                objSPMHeadList = SystemParameter_BL.get_system_parameter_all(SPMall);
                return objSPMHeadList;
            }
            catch (Exception ex)
            {
              
                ReturSystemPMModelHead objSPMHead = new ReturSystemPMModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objSPMHeadList.Add(objSPMHead);

                objError.WriteLog(0, "SystemParameterController", "get_system_parameter_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "SystemParameterController", "get_system_parameter_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "SystemParameterController", "get_system_parameter_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "SystemParameterController", "get_system_parameter_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objSPMHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturSystemPMModelHead> get_system_parameter_single(GetSystemPMSingleModel SPMsingle)//ok
        {
            List<ReturSystemPMModelHead> objSPMHeadList = new List<ReturSystemPMModelHead>();


            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, SPMsingle);

                objSPMHeadList = SystemParameter_BL.get_system_parameter_single(SPMsingle);
                return objSPMHeadList;
            }
            catch (Exception ex)
            {
              
                ReturSystemPMModelHead objSPMHead = new ReturSystemPMModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objSPMHeadList.Add(objSPMHead);

                objError.WriteLog(0, "SystemParameterController", "get_system_parameter_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "SystemParameterController", "get_system_parameter_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "SystemParameterController", "get_system_parameter_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "SystemParameterController", "get_system_parameter_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objSPMHeadList;

        }

        //POST api/<MailTypeController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_system_parameter(SystemPMModel item)//ok
        {
            List<ReturnResponse> objMTHeadList = new List<ReturnResponse>();
            List<SPResponse> objResponseList = new List<SPResponse>();


            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objMTHeadList = SystemParameter_BL.modify_system_parameter(item);
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

                objError.WriteLog(0, "MailTypeController", "modify_system_parameter", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "MailTypeController", "modify_system_parameter", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "MailTypeController", "modify_system_parameter", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "MailTypeController", "modify_system_parameter", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objMTHeadList;
        }






    }

}






