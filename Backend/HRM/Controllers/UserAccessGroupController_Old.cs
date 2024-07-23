using HRM_DAL.Models;
using error_handler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
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

namespace HRM.Controllerss
{
    //Unfinalized codes, cause of abnormal shut off of project!!!!!
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class UserAccessGroupController1 : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnUAGUsrAllModelHead> get_user_access_group_all(GetUAGUsrAllModel all)
        {
            List<ReturnUAGUsrAllModelHead> objMTHeadList = new List<ReturnUAGUsrAllModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, all);

                objMTHeadList = UserAccessGroup_BL.get_user_access_group_all(all);
                return objMTHeadList;
            }
            catch (Exception ex)
            {
                ReturnUAGUsrAllModelHead objMTHead = new ReturnUAGUsrAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMTHeadList.Add(objMTHead);

                objError.WriteLog(0, "UserAccessGroupController", "get_user_access_group_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserAccessGroupController", "get_user_access_group_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserAccessGroupController", "get_user_access_group_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserAccessGroupController", "get_user_access_group_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objMTHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_user_access_group(UAGUsrModel item)
        {
            List<ReturnResponse> objMTHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objMTHeadList = UserAccessGroup_BL.add_new_user_access_group(item);
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

                objError.WriteLog(0, "UserAccessGroupController", "add_new_user_access_group", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserAccessGroupController", "add_new_user_access_group", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserAccessGroupController", "add_new_user_access_group", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserAccessGroupController", "add_new_user_access_group", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objMTHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_user_access_group(UAGUsrModel item)
        {
            List<ReturnResponse> objMTHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objMTHeadList = UserAccessGroup_BL.inactivate_user_access_group(item);
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

                objError.WriteLog(0, "UserAccessGroupController", "inactivate_user_access_group", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserAccessGroupController", "inactivate_user_access_group", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserAccessGroupController", "inactivate_user_access_group", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserAccessGroupController", "inactivate_user_access_group", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objMTHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnUAGUsrAllModelHead> get_user_access_group_single(GetUAGSingleModel item)
        {
            List<ReturnUAGUsrAllModelHead> objMTHeadList = new List<ReturnUAGUsrAllModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objMTHeadList = UserAccessGroup_BL.get_user_access_group_single(item);
                return objMTHeadList;
            }
            catch (Exception ex)
            {
                ReturnUAGUsrAllModelHead objMTHead = new ReturnUAGUsrAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMTHeadList.Add(objMTHead);

                objError.WriteLog(0, "UserAccessGroupController", "get_user_access_group_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserAccessGroupController", "get_user_access_group_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserAccessGroupController", "get_user_access_group_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserAccessGroupController", "get_user_access_group_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objMTHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnUAGUsrAllModelHead> get_user_access_group_multiple(GetUAGSingleModel item)
        {
            List<ReturnUAGUsrAllModelHead> objMTHeadList = new List<ReturnUAGUsrAllModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objMTHeadList = UserAccessGroup_BL.get_user_access_group_multiple(item);
                return objMTHeadList;
            }
            catch (Exception ex)
            {
                ReturnUAGUsrAllModelHead objMTHead = new ReturnUAGUsrAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMTHeadList.Add(objMTHead);

                objError.WriteLog(0, "UserAccessGroupController", "get_user_access_group_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserAccessGroupController", "get_user_access_group_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserAccessGroupController", "get_user_access_group_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserAccessGroupController", "get_user_access_group_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objMTHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_user_access_group(UAGModel item)
        {
            List<ReturnResponse> objMTHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objMTHeadList = UserAccessGroup_BL.modify_user_access_group(item);
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

                objError.WriteLog(0, "UserAccessGroupController", "modify_user_access_group", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserAccessGroupController", "modify_user_access_group", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserAccessGroupController", "modify_user_access_group", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserAccessGroupController", "modify_user_access_group", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objMTHeadList;
        }
    }

}








