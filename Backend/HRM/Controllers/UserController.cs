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

    public class userController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnCustomerUserModelHead> get_user_single(GetUserSingleModel CUser)//ok
        {
            List<ReturnCustomerUserModelHead> objCusUserHeadList = new List<ReturnCustomerUserModelHead>();
            ReturnCustomerUserModelHead obj = new ReturnCustomerUserModelHead() { resp = false, msg = "sfsf" };
            obj.User = new List<ReturnCustomerUserModel>();
            if (CUser.UD_UserName == "test")
                obj.User.Add(new ReturnCustomerUserModel() { UD_UserName = "test", UD_EmployeeID = "test", UD_Status = true, UD_FirstName = "test", UD_LastName = "test", UD_EmailAddress = "test" });
            if (CUser.UD_UserName == "test1") obj.User.Add(new ReturnCustomerUserModel() { UD_UserName = "test1", UD_EmployeeID = "test1", UD_Status = true, UD_FirstName = "test1", UD_LastName = "test1", UD_EmailAddress = "test1" });
            if (CUser.UD_UserName == "test2") obj.User.Add(new ReturnCustomerUserModel() { UD_UserName = "test2", UD_EmployeeID = "test2", UD_Status = true, UD_FirstName = "test2", UD_LastName = "test2", UD_EmailAddress = "test2" });
            objCusUserHeadList.Add(obj);
            return objCusUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, CUser);

                objCusUserHeadList = user_BL.get_user_single(CUser);
                return objCusUserHeadList;
            }
            catch (Exception ex)
            {

                ReturnCustomerUserModelHead objCusUserHead = new ReturnCustomerUserModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCusUserHeadList.Add(objCusUserHead);

                objError.WriteLog(0, "UserController", "get_user_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "get_user_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "get_user_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "get_user_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCusUserHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnCustomerUserModelHead> get_user_all(GetCustomerUserAllModel CUserall)//ok
        {
            List<ReturnCustomerUserModelHead> objCusUserHeadList = new List<ReturnCustomerUserModelHead>();
            ReturnCustomerUserModelHead obj = new ReturnCustomerUserModelHead() { resp = false, msg = "sfsf" };
            obj.User = new List<ReturnCustomerUserModel>();
            obj.User.Add(new ReturnCustomerUserModel() { UD_UserName = "test", UD_EmployeeID = "test", UD_Status = true, UD_FirstName = "test", UD_LastName = "test", UD_EmailAddress = "test" });
            obj.User.Add(new ReturnCustomerUserModel() { UD_UserName = "test1", UD_EmployeeID = "test1", UD_Status = true, UD_FirstName = "test1", UD_LastName = "test1", UD_EmailAddress = "test1" });
            obj.User.Add(new ReturnCustomerUserModel() { UD_UserName = "test2", UD_EmployeeID = "test2", UD_Status = true, UD_FirstName = "test2", UD_LastName = "test2", UD_EmailAddress = "test2" });
            objCusUserHeadList.Add(obj);
            return objCusUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, CUserall);

                //objCusUserHeadList = user_BL.get_user_all(CUserall);
                return objCusUserHeadList;
            }
            catch (Exception ex)
            {

                ReturnCustomerUserAllModelHead objCusUserHead = new ReturnCustomerUserAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                //objCusUserHeadList.Add(objCusUserHead);

                objError.WriteLog(0, "UserController", "get_user_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "get_user_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "get_user_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "get_user_all", "Inner Exception Message: " + ex.InnerException.Message);
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

        //        objError.WriteLog(0, "UserController", "inactivate_user", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "UserController", "inactivate_user", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "UserController", "inactivate_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "UserController", "inactivate_user", "Inner Exception Message: " + ex.InnerException.Message);
        //        }
        //        return objUserHeadList;
        //    }




        //}

        //// POST api/<BankController>
        //[HttpPost]
        //[Route("[action]")]
        ////[Authorize]
        //public List<ReturnResponse> change_password(NewpwModel item)
        //{
        //    List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();

        //    try
        //    {
        //        LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

        //        objUserHeadList = user_BL.change_password(item);
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

        //        objError.WriteLog(0, "UserController", "change_password", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "UserController", "change_password", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "UserController", "change_password", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "UserController", "change_password", "Inner Exception Message: " + ex.InnerException.Message);
        //        }
        //        return objUserHeadList;
        //    }
        //}


        //// POST api/<BankController>
        //[HttpPost]
        //[Route("[action]")]
        //[Authorize]
        //public List<ReturnResponse> update_notification_token(NotificationTokenModel UpNotTokModel)
        //{
        //    List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();

        //    try
        //    {
        //        LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, UpNotTokModel);

        //        var claimsIdentity = this.User.Identity as ClaimsIdentity;
        //        var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;

        //        objUserHeadList = user_BL.update_notification_token(UpNotTokModel, userId);
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

        //        objError.WriteLog(0, "UserController", "update_notification_token", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "UserController", "update_notification_token", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "UserController", "update_notification_token", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "UserController", "update_notification_token", "Inner Exception Message: " + ex.InnerException.Message);
        //        }
        //        return objUserHeadList;
        //    }
        //}

        //[HttpPost]
        //[Route("[action]")]
        ////[Authorize]
        //public List<ReturnResponse> reset_password(ResetPasswordModel resetPassword)
        //{

        //    List<ReturnResponse> objOtpHeadList = new List<ReturnResponse>();
        //    List<ResetPasswordModel> objList = new List<ResetPasswordModel>();

        //    try
        //    {
        //        LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, resetPassword);

        //        string baseUrl = $"{Request.Scheme}://{Request.Host}/api";
        //        objOtpHeadList = user_BL.reset_password(resetPassword, baseUrl);
        //        return objOtpHeadList;
        //    }
        //    catch (Exception ex)
        //    {
        //        ReturnResponse objOtpHead = new ReturnResponse
        //        {
        //            resp = false,
        //            msg = ex.Message.ToString()
        //        };
        //        objOtpHeadList.Add(objOtpHead);

        //        objError.WriteLog(0, "UserController", "reset_password", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "UserController", "reset_password", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "UserController", "reset_password", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "UserController", "reset_password", "Inner Exception Message: " + ex.InnerException.Message);
        //        }


        //    }
        //    return objOtpHeadList;
        //}

        //[HttpGet]
        //[Route("[action]")]
        ////[Authorize]
        //public string change_password_by_email(int userId, string email, string verificationCode)
        //{
        //    string rtnMsg = "";
        //    try
        //    {
        //        LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "userId :" + userId + ", email :" + email + ", verificationCode :" + verificationCode);

        //        rtnMsg = user_BL.change_password_by_email(userId, email, verificationCode);
        //        return rtnMsg;
        //    }
        //    catch (Exception ex)
        //    {

        //        rtnMsg = ex.Message.ToString();

        //        objError.WriteLog(0, "UserController", "change_password_by_email", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "UserController", "change_password_by_email", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "UserController", "change_password_by_email", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "UserController", "change_password_by_email", "Inner Exception Message: " + ex.InnerException.Message);
        //        }
        //        return rtnMsg;
        //    }
        //}

        public static string CreateRandomPassword(int PasswordLength)
        {
            string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ@#$&%";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }

    }
}

