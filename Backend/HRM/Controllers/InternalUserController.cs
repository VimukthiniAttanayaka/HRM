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

    public class InternalUserController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnInternalUserModelHead> get_user_single(GetInternalUserSingleModel CUser)//ok
        {
            List<ReturnInternalUserModelHead> objCusUserHeadList = new List<ReturnInternalUserModelHead>();
            //ReturnUserModelHead obj = new ReturnUserModelHead() { resp = false, msg = "sfsf" };
            ////obj.User = new List<ReturnUserModel>();
            ////if (CUser.UD_UserName == "test")
            ////    obj.User.Add(new ReturnUserModel() { UD_UserName = "test", UD_EmployeeID = "test", UD_Status = true });
            ////if (CUser.UD_UserName == "test1") obj.User.Add(new ReturnUserModel() { UD_UserName = "test1", UD_EmployeeID = "test1", UD_Status = true });
            ////if (CUser.UD_UserName == "test2") obj.User.Add(new ReturnUserModel() { UD_UserName = "test2", UD_EmployeeID = "test2", UD_Status = true });
            //objCusUserHeadList.Add(obj);
            //return objCusUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, CUser);

                objCusUserHeadList = InternalUser_BL.get_user_internal_single(CUser);
                return objCusUserHeadList;
            }
            catch (Exception ex)
            {

                ReturnInternalUserModelHead objCusUserHead = new ReturnInternalUserModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCusUserHeadList.Add(objCusUserHead);

                objError.WriteLog(0, "InternalUserController", "get_user_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "InternalUserController", "get_user_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "InternalUserController", "get_user_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "InternalUserController", "get_user_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCusUserHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnInternalUserAllModelHead> get_user_all(GetUserAllModel CUserall)//ok
        {
            List<ReturnInternalUserAllModelHead> objCusUserHeadList = new List<ReturnInternalUserAllModelHead>();
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

                objCusUserHeadList = InternalUser_BL.get_user_internal_all(CUserall);
                return objCusUserHeadList;
            }
            catch (Exception ex)
            {

                ReturnInternalUserAllModelHead objCusUserHead = new ReturnInternalUserAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCusUserHeadList.Add(objCusUserHead);

                objError.WriteLog(0, "InternalUserController", "get_user_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "InternalUserController", "get_user_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "InternalUserController", "get_user_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "InternalUserController", "get_user_all", "Inner Exception Message: " + ex.InnerException.Message);
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

        //        objError.WriteLog(0, "InternalUserController", "inactivate_user", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "InternalUserController", "inactivate_user", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "InternalUserController", "inactivate_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "InternalUserController", "inactivate_user", "Inner Exception Message: " + ex.InnerException.Message);
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

                objError.WriteLog(0, "InternalUserController", "add_new_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "InternalUserController", "add_new_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "InternalUserController", "add_new_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "InternalUserController", "add_new_user", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCUserHeadList;
        }

        #region moved to ecelupload by V2
        ////POST api/<userController>
        //[HttpPost]
        //[Route("[action]")]
        ////[Authorize]
        //[Obsolete]
        //public ReturUserExcelUploadHead user_excelupload(UserExcelUploadModel model)//ok
        //{
        //    ReturUserExcelUploadHead objHeadList = new ReturUserExcelUploadHead();
        //    //List<SPResponse> objResponseList = new List<SPResponse>();

        //    try
        //    {
        //        LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

        //        if (model == null)
        //        {
        //            objHeadList = new ReturUserExcelUploadHead
        //            {
        //                resp = false,
        //                msg = "value cannot be null"
        //            };
        //            return objHeadList;
        //        }

        //        ReturUserExcelUploadHead tempObj = HRM_BL.user_BL.user_excelupload(model);

        //        if (tempObj.resp == false)
        //        {
        //            objHeadList = new ReturUserExcelUploadHead
        //            {
        //                resp = false,
        //                msg = tempObj.msg
        //            };
        //            return objHeadList;
        //        }

        //        List<ReturUserExcelUploadHead> retList = new List<ReturUserExcelUploadHead>();

        //        if (tempObj.users != null)
        //        {
        //            if (model.IsCompleteList == true)
        //            {
        //                HRM_BL.user_BL.markall_users_excel_inactive(model);
        //            }

        //            foreach (var item in tempObj.users)
        //            {
        //                item.USER_ID = model.USER_ID;
        //                item.UD_ID = model.DPT_ID;
        //                item.UD_HRMAccessFlag = false;
        //                //item.UD_MailBagCPCode = model.UD_MailBagCPCode;
        //                //item.UD_OutgoingMailCPCode = model.UD_OutgoingMailCPCode;
        //                //item.UD_OutgoingMailLocationCode = model.UD_OutgoingMailLocationCode;
        //                //item.UD_PostageUsageReportFrequency = model.UD_PostageUsageReportFrequency;
        //                item.TABLE = model.TABLE;
        //                item.UD_Status = true;
        //                //item.UAG_BusinessUnit = model.UAG_BusinessUnit;

        //                retList.Add(HRM_BL.user_BL.add_update_user_excel(item).FirstOrDefault());
        //            }

        //            LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, retList);

        //            var temp = retList.Where(a => !a.msg.Contains("kiosk")).Count(a => a.resp == true);

        //            if (temp > 0)
        //            {
        //                objHeadList = new ReturUserExcelUploadHead
        //                {
        //                    resp = true,
        //                    msg = "Success"
        //                };
        //            }
        //            else
        //            {
        //                objHeadList = new ReturUserExcelUploadHead
        //                {
        //                    resp = false,
        //                    msg = "Failed"
        //                };

        //            }

        //            objHeadList.FileNameWithPath = tempObj.FileNameWithPath;
        //            objHeadList.FileName = tempObj.FileName;

        //            var tmeps = retList.Where(b => !b.msg.Contains("kiosk") && b.resp == true).Select(a => new userresponcemodel_return() { StaffID = a.users.FirstOrDefault().UD_StaffID, Message = a.msg }).ToList();
        //            objHeadList.success_users = tmeps;

        //            var tmepsC = retList.Where(b => !b.msg.Contains("kiosk") && b.resp == false).Select(a => new userresponcemodel_return() { StaffID = a.users.FirstOrDefault().UD_StaffID, Message = a.msg }).ToList();
        //            objHeadList.failed_users = tmepsC;
        //        }

        //        LogExcelUploadTracer_Data.User(objHeadList, model);

        //        LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, objHeadList);

        //        return objHeadList;
        //    }
        //    catch (Exception ex)
        //    {
        //        objHeadList = new ReturUserExcelUploadHead
        //        {
        //            resp = false,
        //            msg = ex.Message.ToString()
        //        };

        //        objError.WriteLog(0, "userController", "user_excelupload", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "userController", "user_excelupload", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "userController", "user_excelupload", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "userController", "user_excelupload", "Inner Exception Message: " + ex.InnerException.Message);
        //        }

        //    }
        //    return objHeadList;
        //}
        #endregion moved to ecelupload by V2

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_user(InternalUserModel item)//ok
        {
            List<ReturnResponse> objCUserHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objCUserHeadList = InternalUser_BL.modify_internal_user(item);
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

                objError.WriteLog(0, "InternalUserController", "modify_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "InternalUserController", "modify_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "InternalUserController", "modify_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "InternalUserController", "modify_user", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCUserHeadList;
        }


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

        //        objError.WriteLog(0, "InternalUserController", "change_password", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "InternalUserController", "change_password", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "InternalUserController", "change_password", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "InternalUserController", "change_password", "Inner Exception Message: " + ex.InnerException.Message);
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

        //        objError.WriteLog(0, "InternalUserController", "update_notification_token", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "InternalUserController", "update_notification_token", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "InternalUserController", "update_notification_token", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "InternalUserController", "update_notification_token", "Inner Exception Message: " + ex.InnerException.Message);
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

        //        objError.WriteLog(0, "InternalUserController", "reset_password", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "InternalUserController", "reset_password", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "InternalUserController", "reset_password", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "InternalUserController", "reset_password", "Inner Exception Message: " + ex.InnerException.Message);
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

        //        objError.WriteLog(0, "InternalUserController", "change_password_by_email", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "InternalUserController", "change_password_by_email", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "InternalUserController", "change_password_by_email", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "InternalUserController", "change_password_by_email", "Inner Exception Message: " + ex.InnerException.Message);
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

    //public class UserExcelSampleModel
    //{
    //    public string FileFullPath { get; set; }
    //}
}

