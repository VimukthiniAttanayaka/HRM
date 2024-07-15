using HRM_DAL.Models;
using email_sender;
using error_handler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using sms_core;
using System;
using System.Collections.Generic;
using System.Data;
using utility_handler.Data;
using utility_handler.Utility;
using HRM_BL;
using System.Reflection;
using HRM_DAL.Data;
using Microsoft.AspNetCore.Authorization;
using email_sender.Models;

namespace HRM.Controllers
{
    //Unfinalized codes, cause of abnormal shut off of project!!!!!
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]

    public class loginController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        public List<ReturnUserModelHead> login(LogdataModel logdata)
        {

            List<ReturnUserModelHead> objUserHeadList = new List<ReturnUserModelHead>();

            try
            {
                List<ReturnUserModel> user = new List<ReturnUserModel>();
                List<ReturnUserAccessModel> UserAccessList = new List<ReturnUserAccessModel>();
                UserAccessList.Add(new ReturnUserAccessModel() { MNU_Active = true, MNU_MenuName = "HRM_Customer" });
                string token = JwToken.Authenticate(logdata.username);
                user.Add(new ReturnUserModel() {UD_AuthorizationToken= token, UserAccessList = UserAccessList });

                objUserHeadList.Add(new ReturnUserModelHead() { resp = true, msg = "Welcome To HRM", user = user });
                return objUserHeadList;

                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, logdata);

                objUserHeadList = login_BL.login(logdata);

                return objUserHeadList;
            }
            catch (Exception ex)
            {

                ReturnUserModelHead objUserHead = new ReturnUserModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "loginController", "login", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "loginController", "login", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "loginController", "login", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "loginController", "login", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }

        private bool SendOTP(string From, string to, string cc, int OTP, string smtpServer, int smtpPort, Boolean security, string userName, string password)
        {
            try
            {
                string subject = "HRM OTP";
                string body = "Use " + OTP.ToString() + " as the HRM OTP for current login. Valid for five minutes.";
                EmailAttachedFileDetails objFilesAttachment = new EmailAttachedFileDetails();
                (bool messageid, string message) rtn = SendMail.Send_V1(From, to, cc, subject, body, smtpServer, smtpPort, security, userName, password, HRM_DAL.Data.ConfigCaller.EmailFromName, objFilesAttachment);
                return rtn.messageid;
            }
            catch (Exception)
            {
                return false;
            }


        }

    }

}

