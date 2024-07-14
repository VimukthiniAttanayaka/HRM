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
        private SendMail sendMail = new SendMail();
        private SendSMS sendSMS = new SendSMS();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnCustomerUserModelHead> get_c_user_single(CUser CUser)//ok
        {
            List<ReturnCustomerUserModelHead> objCusUserHeadList = new List<ReturnCustomerUserModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, CUser);

                objCusUserHeadList = user_BL.get_c_user_single(CUser);
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

                objError.WriteLog(0, "UserController", "get_c_user_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "get_c_user_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "get_c_user_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "get_c_user_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCusUserHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnCustomerUserAllModelHead> get_c_user_all(GetCustomerUserAllModel CUserall)//ok
        {
            List<ReturnCustomerUserAllModelHead> objCusUserHeadList = new List<ReturnCustomerUserAllModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, CUserall);

                objCusUserHeadList = user_BL.get_c_user_all(CUserall);
                return objCusUserHeadList;
            }
            catch (Exception ex)
            {

                ReturnCustomerUserAllModelHead objCusUserHead = new ReturnCustomerUserAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCusUserHeadList.Add(objCusUserHead);

                objError.WriteLog(0, "UserController", "get_c_user_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "get_c_user_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "get_c_user_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "get_c_user_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCusUserHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnCustomerUserAllModelHead> get_c_user_all_unique(GetCustomerUserAllModel CUserall)//ok
        {
            List<ReturnCustomerUserAllModelHead> objCusUserHeadList = new List<ReturnCustomerUserAllModelHead>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, CUserall);

                objCusUserHeadList = user_BL.get_c_user_all_unique(CUserall);
                return objCusUserHeadList;
            }
            catch (Exception ex)
            {

                ReturnCustomerUserAllModelHead objCusUserHead = new ReturnCustomerUserAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCusUserHeadList.Add(objCusUserHead);

                objError.WriteLog(0, "UserController", "get_c_user_all_unique", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "get_c_user_all_unique", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "get_c_user_all_unique", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "get_c_user_all_unique", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCusUserHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_c_user(InactiveCUserModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objUserHeadList = user_BL.inactivate_c_user(item);
                return objUserHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objUserHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "UserController", "inactivate_c_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "inactivate_c_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "inactivate_c_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "inactivate_c_user", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }




        }


        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnLoadUserDataModel> load_user_data()//ok
        {
            List<ReturnLoadUserDataModel> objUserHeadList = new List<ReturnLoadUserDataModel>();
            List<ReturnLoadUserDataModel> objUserSList = new List<ReturnLoadUserDataModel>();
            List<ReturnUserGroupModel> objGrpSList = new List<ReturnUserGroupModel>();
            List<ReturnUserBuModel> objBUList = new List<ReturnUserBuModel>();
            List<ReturnUserCustModel> objCustList = new List<ReturnUserCustModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "");

                objUserHeadList = user_BL.load_user_data();
                return objUserHeadList;
            }
            catch (Exception ex)
            {

                ReturnLoadUserDataModel objUserHead = new ReturnLoadUserDataModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "UserController", "load_user_data", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "load_user_data", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "load_user_data", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "load_user_data", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objUserHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_c_user(CUserModel item)//ok
        {
            List<ReturnResponse> objCUserHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objCUserHeadList = user_BL.add_new_c_user(item);
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

                objError.WriteLog(0, "UserController", "add_new_c_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "add_new_c_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "add_new_c_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "add_new_c_user", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCUserHeadList;
        }


        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_c_user_Bulk(CUserBulkModel model)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();

            try
            {
                if (model == null)
                {
                    ReturnResponse objHead = new ReturnResponse
                    {
                        resp = false,
                        msg = "value cannot be null"
                    };
                    objUserHeadList.Add(objHead);
                    return objUserHeadList;
                }
                if (model.userlist == null)
                {
                    ReturnResponse objHead = new ReturnResponse
                    {
                        resp = false,
                        msg = "value list cannot be null"
                    };
                    objUserHeadList.Add(objHead);
                    return objUserHeadList;
                }

                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                foreach (var item in model.userlist)
                {
                    List<ReturnCustomerUserModelHead> temp = HRM_BL.user_BL.get_c_user_single(new CUser() { USER_ID = item.USER_ID, TABLE = item.TABLE });
                    if (temp != null && temp.Count > 0 && temp[0].User != null && temp[0].User.Count > 0)
                    {
                        objUserHeadList.Add(user_BL.modify_c_user(item).FirstOrDefault());
                    }
                    else
                    {
                        objUserHeadList.Add(user_BL.add_new_c_user(item).FirstOrDefault());
                    }
                }
                return objUserHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objUserHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "UserController", "add_new_c_user_Bulk", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "add_new_c_user_Bulk", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "add_new_c_user_Bulk", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "add_new_c_user_Bulk", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objUserHeadList;
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
        //                item.USR_CustomerID = model.DPT_CustomerID;
        //                item.USR_HRMAccessFlag = false;
        //                //item.USR_MailBagCPCode = model.USR_MailBagCPCode;
        //                //item.USR_OutgoingMailCPCode = model.USR_OutgoingMailCPCode;
        //                //item.USR_OutgoingMailLocationCode = model.USR_OutgoingMailLocationCode;
        //                //item.USR_PostageUsageReportFrequency = model.USR_PostageUsageReportFrequency;
        //                item.TABLE = model.TABLE;
        //                item.USR_Status = true;
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

        //            var tmeps = retList.Where(b => !b.msg.Contains("kiosk") && b.resp == true).Select(a => new userresponcemodel_return() { StaffID = a.users.FirstOrDefault().USR_StaffID, Message = a.msg }).ToList();
        //            objHeadList.success_users = tmeps;

        //            var tmepsC = retList.Where(b => !b.msg.Contains("kiosk") && b.resp == false).Select(a => new userresponcemodel_return() { StaffID = a.users.FirstOrDefault().USR_StaffID, Message = a.msg }).ToList();
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
        public List<ReturnResponse> modify_c_user(CUserModel item)//ok
        {
            List<ReturnResponse> objCUserHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objCUserHeadList = user_BL.modify_c_user(item);
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

                objError.WriteLog(0, "UserController", "modify_c_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "modify_c_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "modify_c_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "modify_c_user", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCUserHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnUserDropModelHead> get_transuser_dropdown(User getuserdrop)//ok
        {
            List<ReturnUserDropModelHead> objUserHeadList = new List<ReturnUserDropModelHead>();
            List<GetTuserdropdownModel> objUserSList = new List<GetTuserdropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, getuserdrop);

                objUserHeadList = user_BL.get_transuser_dropdown(getuserdrop);
                return objUserHeadList;
            }
            catch (Exception ex)
            {

                ReturnUserDropModelHead objUserHead = new ReturnUserDropModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "UserController", "get_transuser_dropdown", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "get_transuser_dropdown", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "get_transuser_dropdown", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "get_transuser_dropdown", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }



        // POST api/<BankController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> change_password(NewpwModel item)
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                objUserHeadList = user_BL.change_password(item);
                return objUserHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objUserHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "UserController", "change_password", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "change_password", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "change_password", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "change_password", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }
        }


        // POST api/<BankController>
        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public List<ReturnResponse> update_notification_token(NotTokModel UpNotTokModel)
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, UpNotTokModel);

                var claimsIdentity = this.User.Identity as ClaimsIdentity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;

                objUserHeadList = user_BL.update_notification_token(UpNotTokModel, userId);
                return objUserHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objUserHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "UserController", "update_notification_token", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "update_notification_token", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "update_notification_token", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "update_notification_token", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> reset_password(ResetPasswordModel resetPassword)
        {

            List<ReturnResponse> objOtpHeadList = new List<ReturnResponse>();
            List<ResetPasswordModel> objList = new List<ResetPasswordModel>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, resetPassword);

                string baseUrl = $"{Request.Scheme}://{Request.Host}/api";
                objOtpHeadList = user_BL.reset_password(resetPassword, baseUrl);
                return objOtpHeadList;
            }
            catch (Exception ex)
            {
                ReturnResponse objOtpHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objOtpHeadList.Add(objOtpHead);

                objError.WriteLog(0, "UserController", "reset_password", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "reset_password", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "reset_password", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "reset_password", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objOtpHeadList;
        }

        [HttpGet]
        [Route("[action]")]
        //[Authorize]
        public string change_password_by_email(int userId, string email, string verificationCode)
        {
            string rtnMsg = "";
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, "userId :" + userId + ", email :" + email + ", verificationCode :" + verificationCode);

                rtnMsg = user_BL.change_password_by_email(userId, email, verificationCode);
                return rtnMsg;
            }
            catch (Exception ex)
            {

                rtnMsg = ex.Message.ToString();

                objError.WriteLog(0, "UserController", "change_password_by_email", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "change_password_by_email", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "change_password_by_email", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "change_password_by_email", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return rtnMsg;
            }
        }



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

