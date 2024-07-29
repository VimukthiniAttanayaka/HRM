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
        public ReturnUserModelHead login(LogdataModel logdata)
        {

            ReturnUserModelHead objUserHead = new ReturnUserModelHead();

            try
            {
                List<ReturnUserModel> user = new List<ReturnUserModel>();
                List<ReturnUserAccessModel> UserAccessList = new List<ReturnUserAccessModel>();
                UserAccessList.Add(new ReturnUserAccessModel() { MNU_Active = false, MNU_MenuName = "HRM_Customer" });
                UserAccessList.Add(new ReturnUserAccessModel() { MNU_Active = true, MNU_MenuName = "HRM_employee" });
                string token = JwToken.Authenticate(logdata.username);
                user.Add(new ReturnUserModel() { UD_AuthorizationToken = token, UserAccessList = UserAccessList });

                objUserHead = new ReturnUserModelHead() { resp = true, msg = "Welcome To HRM", user = user };
                return objUserHead;

                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, logdata);

                //objUserHead = login_BL.login(logdata);

                return objUserHead;
            }
            catch (Exception ex)
            {

                objUserHead = new ReturnUserModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };

                objError.WriteLog(0, "loginController", "login", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "loginController", "login", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "loginController", "login", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "loginController", "login", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHead;
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

