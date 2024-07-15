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

    public class dropdownController : ControllerBase
    {
        private LogError objError = new LogError();

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnDepartmentDropDownModelHead> get_department_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnDepartmentDropDownModelHead> objHeadList = new List<ReturnDepartmentDropDownModelHead>();
            List<ReturnDepartmentDropdownModel> objList = new List<ReturnDepartmentDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, getuserdrop);

                objHeadList = HRM_BL.DropDown_BL.get_department_dropdown_by_user(getuserdrop);
                return objHeadList;
            }
            catch (Exception ex)
            {

                ReturnDepartmentDropDownModelHead objHead = new ReturnDepartmentDropDownModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "dropdownController", "get_department_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "dropdownController", "get_department_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "dropdownController", "get_department_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "dropdownController", "get_department_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objHeadList;
        }



        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnlocationDropDownModelHead> get_location_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnlocationDropDownModelHead> objHeadList = new List<ReturnlocationDropDownModelHead>();
            List<ReturnlocationDropdownModel> objList = new List<ReturnlocationDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, getuserdrop);

                objHeadList = HRM_BL.DropDown_BL.get_location_dropdown_by_user(getuserdrop);
                return objHeadList;
            }
            catch (Exception ex)
            {

                ReturnlocationDropDownModelHead objHead = new ReturnlocationDropDownModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "dropdownController", "get_location_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "dropdownController", "get_location_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "dropdownController", "get_location_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "dropdownController", "get_location_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objHeadList;
        }


        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnVendorDropDownModelHead> get_vendor_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnVendorDropDownModelHead> objHeadList = new List<ReturnVendorDropDownModelHead>();
            List<ReturnVendorDropdownModel> objList = new List<ReturnVendorDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, getuserdrop);

                objHeadList = HRM_BL.DropDown_BL.get_vendor_dropdown_by_user(getuserdrop);
                return objHeadList;
            }
            catch (Exception ex)
            {

                ReturnVendorDropDownModelHead objHead = new ReturnVendorDropDownModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "dropdownController", "get_vendor_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "dropdownController", "get_vendor_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "dropdownController", "get_vendor_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "dropdownController", "get_vendor_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnUserCustomerGroupsModelHead> get_user_customer_groups_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnUserCustomerGroupsModelHead> objHeadList = new List<ReturnUserCustomerGroupsModelHead>();
            List<ReturnUserCustomerGroupsDropdownModel> objList = new List<ReturnUserCustomerGroupsDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, getuserdrop);

                objHeadList = HRM_BL.DropDown_BL.get_user_customer_groups_dropdown_by_user(getuserdrop);
                return objHeadList;
            }
            catch (Exception ex)
            {

                ReturnUserCustomerGroupsModelHead objHead = new ReturnUserCustomerGroupsModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "dropdownController", "get_user_customer_groups_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "dropdownController", "get_user_customer_groups_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "dropdownController", "get_user_customer_groups_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "dropdownController", "get_user_customer_groups_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objHeadList;
        }
    }
}








