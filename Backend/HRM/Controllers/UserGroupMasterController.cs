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

    public class UserGroupMasterController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturUserGroupMasterModelHead> get_user_group_master_all(GetUGMAllModel UGMall)
        {
            List<ReturUserGroupMasterModelHead> objMTHeadList = new List<ReturUserGroupMasterModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, UGMall);

                objMTHeadList = UserGroupMaster_BL.get_user_group_master_all(UGMall);
                return objMTHeadList;
            }
            catch (Exception ex)
            {
                ReturUserGroupMasterModelHead objMTHead = new ReturUserGroupMasterModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMTHeadList.Add(objMTHead);

                objError.WriteLog(0, "UserGroupMasterController", "get_user_group_master_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserGroupMasterController", "get_user_group_master_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserGroupMasterController", "get_user_group_master_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserGroupMasterController", "get_user_group_master_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objMTHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturUserGroupMasterModelHead> get_user_group_master(GetUGMSingleModel UGMall)
        {
            List<ReturUserGroupMasterModelHead> objMTHeadList = new List<ReturUserGroupMasterModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, UGMall);

                objMTHeadList = UserGroupMaster_BL.get_user_group_master(UGMall);
                return objMTHeadList;
            }
            catch (Exception ex)
            {
                ReturUserGroupMasterModelHead objMTHead = new ReturUserGroupMasterModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMTHeadList.Add(objMTHead);

                objError.WriteLog(0, "UserGroupMasterController", "get_user_group_master", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserGroupMasterController", "get_user_group_master", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserGroupMasterController", "get_user_group_master", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserGroupMasterController", "get_user_group_master", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objMTHeadList;
        }
    }
}








