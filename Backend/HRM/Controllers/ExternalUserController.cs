using HRM_DAL.Models;
using email_sender;
using error_handler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using sms_core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using utility_handler.Data;
using HRM_BL;
using System.Reflection;
using System.Linq;
using HRM_DAL.Data;

namespace HRM.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class ExternalUserController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnExternalUserModelHead> get_user_single(GetExternalUserSingleModel CUser)//ok
        {
            List<ReturnExternalUserModelHead> objCusUserHeadList = new List<ReturnExternalUserModelHead>();
            //ReturnUserModelHead obj = new ReturnUserModelHead() { resp = false, msg = "sfsf" };
            //obj.user = new List<ReturnUserModel>();
            ////if (CUser.UD_UserID == "test")
            ////    obj.user.Add(new ReturnUserModel() { UD_UserName = "test", UD_EmployeeID = "test", UD_Status = true });
            ////if (CUser.UD_UserID == "test1") obj.user.Add(new ReturnUserModel() { UD_UserName = "test1", UD_EmployeeID = "test1", UD_Status = true });
            ////if (CUser.UD_UserID == "test2") obj.user.Add(new ReturnUserModel() { UD_UserName = "test2", UD_EmployeeID = "test2", UD_Status = true });
            //objCusUserHeadList.Add(obj);
            //return objCusUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, CUser);

                objCusUserHeadList = ExternalUser_BL.get_user_external_single(CUser);
                return objCusUserHeadList;
            }
            catch (Exception ex)
            {

                ReturnExternalUserModelHead objCusUserHead = new ReturnExternalUserModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCusUserHeadList.Add(objCusUserHead);

                objError.WriteLog(0, "ExternalUserController", "get_user_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ExternalUserController", "get_user_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ExternalUserController", "get_user_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ExternalUserController", "get_user_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCusUserHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnExternalUserAllModelHead> get_user_all(GetUserAllModel CUserall)//ok
        {
            List<ReturnExternalUserAllModelHead> objCusUserHeadList = new List<ReturnExternalUserAllModelHead>();
            //ReturnUserAllModelHead obj = new ReturnUserAllModelHead() { resp = false, msg = "sfsf" };
            //obj.User = new List<ReturnUserAllModel>();
            //obj.User.Add(new ReturnUserAllModel() { UD_UserName = "test", UD_EmployeeID = "test", UD_Status = true });
            //obj.User.Add(new ReturnUserAllModel() { UD_UserName = "test1", UD_EmployeeID = "test1", UD_Status = true });
            //obj.User.Add(new ReturnUserAllModel() { UD_UserName = "test2", UD_EmployeeID = "test2", UD_Status = true });
            //objCusUserHeadList.Add(obj);
            //return objCusUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, CUserall);

                objCusUserHeadList = ExternalUser_BL.get_user_external_all(CUserall);
                return objCusUserHeadList;
            }
            catch (Exception ex)
            {

                ReturnExternalUserAllModelHead objCusUserHead = new ReturnExternalUserAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCusUserHeadList.Add(objCusUserHead);

                objError.WriteLog(0, "ExternalUserController", "get_user_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ExternalUserController", "get_user_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ExternalUserController", "get_user_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ExternalUserController", "get_user_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCusUserHeadList;

        }

        //[HttpPost]
        //[Route("[action]")]
        ////[Authorize]
        //public List<ReturnResponse> inactivate_user(InactiveCUserModel item)//ok
        //{
        //    List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();

        //    try
        //    {
        //        LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

        //        objUserHeadList = user_BL.inactivate_user(item);
        //        return objUserHeadList;
        //    }
        //    catch (Exception ex)
        //    {
        //        ReturnResponse objUserHead = new ReturnResponse
        //        {
        //            resp = false,
        //            msg = ex.Message.ToString()
        //        };
        //        objUserHeadList.Add(objUserHead);

        //        objError.WriteLog(0, "ExternalUserController", "inactivate_user", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "ExternalUserController", "inactivate_user", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "ExternalUserController", "inactivate_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "ExternalUserController", "inactivate_user", "Inner Exception Message: " + ex.InnerException.Message);
        //        }
        //        return objUserHeadList;
        //    }




        //}

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_user(UserModel item)//ok
        {
            List<ReturnResponse> objCUserHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objCUserHeadList = ExternalUser_BL.add_new_user_external(item);
                return objCUserHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objCusUserHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCUserHeadList.Add(objCusUserHead);

                objError.WriteLog(0, "ExternalUserController", "add_new_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ExternalUserController", "add_new_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ExternalUserController", "add_new_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ExternalUserController", "add_new_user", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCUserHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_user(ExternalUserModel item)//ok
        {
            List<ReturnResponse> objCUserHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objCUserHeadList = ExternalUser_BL.modify_user_external(item);
                return objCUserHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objCusUserHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCUserHeadList.Add(objCusUserHead);

                objError.WriteLog(0, "ExternalUserController", "modify_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ExternalUserController", "modify_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ExternalUserController", "modify_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ExternalUserController", "modify_user", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCUserHeadList;
        }
    }
}