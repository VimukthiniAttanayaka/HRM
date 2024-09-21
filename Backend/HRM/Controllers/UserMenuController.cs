using HRM_DAL.Models;
using error_handler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using utility_handler.Data;
using static error_handler.ErrorLog;
using System.Reflection;

namespace HRM.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    //[BasicAuthorization]
    //[Authorize]

    public class UserMenuController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnUserMenuModelHead> get_UserMenu_single(UserMenu model)//ok
        {
            List<ReturnUserMenuModelHead> objUserMenuHeadList = new List<ReturnUserMenuModelHead>();
            //ReturnUserMenuModelHead obj = new ReturnUserMenuModelHead() { resp = false, msg = "sfsf" };
            //obj.UserMenu = new List<ReturnUserMenuModel>();
            //if (model.UUM_UserMenuID == "CAS")
            //    obj.UserMenu.Add(new ReturnUserMenuModel() { UUM_UserMenuID = "CAS", UUM_UserMenu = "Casual", UUM_Status = true });
            //if (model.UUM_UserMenuID == "ANU") obj.UserMenu.Add(new ReturnUserMenuModel() { UUM_UserMenuID = "ANU", UUM_UserMenu = "Annual", UUM_Status = true });
            //if (model.UUM_UserMenuID == "MED") obj.UserMenu.Add(new ReturnUserMenuModel() { UUM_UserMenuID = "MED", UUM_UserMenu = "Medical", UUM_Status = true });
            //if (model.UUM_UserMenuID == "MAT") obj.UserMenu.Add(new ReturnUserMenuModel() { UUM_UserMenuID = "MAT", UUM_UserMenu = "Matrinaty", UUM_Status = true });
            //objUserMenuHeadList.Add(obj);
            //return objUserMenuHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.UserMenu_BL.get_UserMenus_single(model);

            }
            catch (Exception ex)
            {

                ReturnUserMenuModelHead objUserMenuHead = new ReturnUserMenuModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserMenuHeadList.Add(objUserMenuHead);

                objError.WriteLog(0, "UserMenuController", "get_UserMenu_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenuController", "get_UserMenu_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenuController", "get_UserMenu_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenuController", "get_UserMenu_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objUserMenuHeadList;

        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnUserMenuModelHead> get_UserMenu_all(UserMenuSearchModel model)//ok
        {
            List<ReturnUserMenuModelHead> objUserMenuHeadList = new List<ReturnUserMenuModelHead>();
            //ReturnUserMenuModelHead obj = new ReturnUserMenuModelHead() { resp = false, msg = "sfsf" };
            //obj.UserMenu = new List<ReturnUserMenuModel>();
            //obj.UserMenu.Add(new ReturnUserMenuModel() { UUM_UserMenuID = "CAS", UUM_UserMenu = "Casual", UUM_Status = true });
            //obj.UserMenu.Add(new ReturnUserMenuModel() { UUM_UserMenuID = "ANU", UUM_UserMenu = "Annual", UUM_Status = true });
            //obj.UserMenu.Add(new ReturnUserMenuModel() { UUM_UserMenuID = "MED", UUM_UserMenu = "Medical", UUM_Status = true });
            //obj.UserMenu.Add(new ReturnUserMenuModel() { UUM_UserMenuID = "MAT", UUM_UserMenu = "Matrinaty", UUM_Status = true });
            //objUserMenuHeadList.Add(obj);
            //return objUserMenuHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, model);

                return HRM_BL.UserMenu_BL.get_UserMenu_all(model);

            }
            catch (Exception ex)
            {

                ReturnUserMenuModelHead objUserMenuHead = new ReturnUserMenuModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserMenuHeadList.Add(objUserMenuHead);

                objError.WriteLog(0, "UserMenuController", "get_UserMenu_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenuController", "get_UserMenu_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenuController", "get_UserMenu_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenuController", "get_UserMenu_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objUserMenuHeadList;

        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> add_new_UserMenu(UserMenuModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.UserMenu_BL.add_new_UserMenu(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objUserMenuHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objUserMenuHead);

                objError.WriteLog(0, "UserMenuController", "add_new_UserMenu", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenuController", "add_new_UserMenu", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenuController", "add_new_UserMenu", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenuController", "add_new_UserMenu", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        //POST api/<UserController>
        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> modify_UserMenu(UserMenuModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.UserMenu_BL.modify_UserMenu(item);

            }
            catch (Exception ex)
            {

                ReturnResponse objUserMenuHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objUserMenuHead);

                objError.WriteLog(0, "UserMenuController", "modify_UserMenu", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenuController", "modify_UserMenu", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenuController", "modify_UserMenu", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenuController", "modify_UserMenu", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnResponse> inactivate_UserMenu(InactiveUUMModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            objUserHeadList.Add(new ReturnResponse() { resp = true, msg = "saved" });
            return objUserHeadList;

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, item);

                return HRM_BL.UserMenu_BL.inactivate_UserMenu(item);

            }
            catch (Exception ex)
            {
                ;
                ReturnResponse objUserMenuHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserMenuHead);

                objError.WriteLog(0, "UserMenuController", "inactivate_UserMenu", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenuController", "inactivate_UserMenu", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenuController", "inactivate_UserMenu", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenuController", "inactivate_UserMenu", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objUserHeadList;
        }
    }

}

