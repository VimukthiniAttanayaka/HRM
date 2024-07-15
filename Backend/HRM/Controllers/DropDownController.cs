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
//using static error_handler.InformationLog;

namespace HRM.Controllers
{
    //Unfinalized codes, cause of abnormal shut off of project!!!!!
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
        public List<ReturnCustomersDropDownModelHead> get_customers_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnCustomersDropDownModelHead> objHeadList = new List<ReturnCustomersDropDownModelHead>();
            List<ReturnCustomersDropdownModel> objUserSList = new List<ReturnCustomersDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, getuserdrop);

                objHeadList = HRM_BL.DropDown_BL.get_customers_dropdown_by_user(getuserdrop);
                return objHeadList;
            }
            catch (Exception ex)
            {

                ReturnCustomersDropDownModelHead objHead = new ReturnCustomersDropDownModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "dropdownController", "get_customers_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "dropdownController", "get_customers_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "dropdownController", "get_customers_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "dropdownController", "get_customers_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnCustomersDropDownModelHead> get_customers_dropdown_by_user_reports(UserIdModel getuserdrop)//ok
        {
            List<ReturnCustomersDropDownModelHead> objHeadList = new List<ReturnCustomersDropDownModelHead>();
            List<ReturnCustomersDropdownModel> objUserSList = new List<ReturnCustomersDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, getuserdrop);

                objHeadList = HRM_BL.DropDown_BL.get_customers_dropdown_by_user_reports(getuserdrop);

                return objHeadList;
            }
            catch (Exception ex)
            {

                ReturnCustomersDropDownModelHead objHead = new ReturnCustomersDropDownModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "dropdownController", "get_customers_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "dropdownController", "get_customers_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "dropdownController", "get_customers_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "dropdownController", "get_customers_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnBUDropDownModelHead> get_business_unit_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnBUDropDownModelHead> objHeadList = new List<ReturnBUDropDownModelHead>();
            List<ReturnBUDropdownModel> objList = new List<ReturnBUDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, getuserdrop);

                objHeadList = HRM_BL.DropDown_BL.get_business_unit_dropdown_by_user(getuserdrop);
                return objHeadList;
            }
            catch (Exception ex)
            {

                ReturnBUDropDownModelHead objHead = new ReturnBUDropDownModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "dropdownController", "get_business_unit_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "dropdownController", "get_business_unit_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "dropdownController", "get_business_unit_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "dropdownController", "get_business_unit_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objHeadList;
        }


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
        public List<ReturnContainerDPTypeModelHead> get_Containerdptype_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnContainerDPTypeModelHead> objHeadList = new List<ReturnContainerDPTypeModelHead>();
            List<ReturnContainerDPTypeDropdownModel> objList = new List<ReturnContainerDPTypeDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, getuserdrop);

                objHeadList = HRM_BL.DropDown_BL.get_Containerdptype_dropdown_by_user(getuserdrop);
                return objHeadList;
            }
            catch (Exception ex)
            {

                ReturnContainerDPTypeModelHead objHead = new ReturnContainerDPTypeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "dropdownController", "get_Containerdptype_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "dropdownController", "get_Containerdptype_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "dropdownController", "get_Containerdptype_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "dropdownController", "get_Containerdptype_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }
            return objHeadList;
        }


        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnUserTGroupsModelHead> get_user_transnational_groups_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnUserTGroupsModelHead> objHeadList = new List<ReturnUserTGroupsModelHead>();
            List<ReturnUserTGroupsDropdownModel> objList = new List<ReturnUserTGroupsDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, getuserdrop);

                objHeadList = HRM_BL.DropDown_BL.get_user_transnational_groups_dropdown_by_user(getuserdrop);
                return objHeadList;
            }
            catch (Exception ex)
            {

                ReturnUserTGroupsModelHead objHead = new ReturnUserTGroupsModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "dropdownController", "get_user_transnational_groups_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "dropdownController", "get_user_transnational_groups_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "dropdownController", "get_user_transnational_groups_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "dropdownController", "get_user_transnational_groups_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
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

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnUserDeliveryCourierCompanyModelHead> get_user_delivery_courier_company_dropdown_by_user(DCCUserIdModel getuserdrop)//ok
        {
            List<ReturnUserDeliveryCourierCompanyModelHead> objHeadList = new List<ReturnUserDeliveryCourierCompanyModelHead>();
            List<ReturnUserDeliveryCourierCompanyDropdownModel> objList = new List<ReturnUserDeliveryCourierCompanyDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, getuserdrop);

                objHeadList = HRM_BL.DropDown_BL.get_user_delivery_courier_company_dropdown_by_user(getuserdrop);

                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturnUserDeliveryCourierCompanyModelHead objHead = new ReturnUserDeliveryCourierCompanyModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "dropdownController", "get_user_delivery_courier_company_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "dropdownController", "get_user_delivery_courier_company_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "dropdownController", "get_user_delivery_courier_company_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "dropdownController", "get_user_delivery_courier_company_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnDeviceIDDropDownModelHead> get_deviceid_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnDeviceIDDropDownModelHead> objHeadList = new List<ReturnDeviceIDDropDownModelHead>();
            List<ReturnDeviceIDDropdownModel> objList = new List<ReturnDeviceIDDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, getuserdrop);

                objHeadList = HRM_BL.DropDown_BL.get_deviceid_dropdown_by_user(getuserdrop);
                return objHeadList;
            }
            catch (Exception ex)
            {

                ReturnDeviceIDDropDownModelHead objHead = new ReturnDeviceIDDropDownModelHead
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

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnCPCodeDropDownModelHead> get_cpcode_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnCPCodeDropDownModelHead> objHeadList = new List<ReturnCPCodeDropDownModelHead>();
            List<ReturnCPCodeDropdownModel> objList = new List<ReturnCPCodeDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, getuserdrop);

                objHeadList = HRM_BL.DropDown_BL.get_cpcode_dropdown_by_user(getuserdrop);

                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturnCPCodeDropDownModelHead objHead = new ReturnCPCodeDropDownModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "dropdownController", "get_cpcode_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "dropdownController", "get_cpcode_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "dropdownController", "get_cpcode_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "dropdownController", "get_cpcode_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objHeadList;
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        public List<ReturnThresholdsDropDownModelHead> get_Thresholds_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            List<ReturnThresholdsDropDownModelHead> objHeadList = new List<ReturnThresholdsDropDownModelHead>();
            List<ReturnThresholdsDropdownModel> objList = new List<ReturnThresholdsDropdownModel>();

            List<SPResponse> objResponseList = new List<SPResponse>();

            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, getuserdrop);

                objHeadList = HRM_BL.DropDown_BL.get_Thresholds_dropdown_by_user(getuserdrop);

                return objHeadList;
            }
            catch (Exception ex)
            {
                ReturnThresholdsDropDownModelHead objHead = new ReturnThresholdsDropDownModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "dropdownController", "get_Thresholds_dropdown_by_user", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "dropdownController", "get_Thresholds_dropdown_by_user", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "dropdownController", "get_Thresholds_dropdown_by_user", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "dropdownController", "get_Thresholds_dropdown_by_user", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objHeadList;
        }
  }








}








