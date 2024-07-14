using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System;

namespace HRM_BL
{
    public class DropDown_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnCustomersDropDownModelHead> get_customers_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            return HRM_DAL.Data.DropDown_Data.get_customers_dropdown_by_user(getuserdrop);
        }

        public static List<ReturnCustomersDropDownModelHead> get_customers_dropdown_by_user_reports(UserIdModel getuserdrop)//ok
        {
            return HRM_DAL.Data.DropDown_Data.get_customers_dropdown_by_user_reports(getuserdrop);
        }

        public static List<ReturnBUDropDownModelHead> get_business_unit_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            return HRM_DAL.Data.DropDown_Data.get_business_unit_dropdown_by_user(getuserdrop);
        }

        public static List<ReturnDepartmentDropDownModelHead> get_department_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            return HRM_DAL.Data.DropDown_Data.get_department_dropdown_by_user(getuserdrop);
        }

        public static List<ReturnlocationDropDownModelHead> get_location_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            return HRM_DAL.Data.DropDown_Data.get_location_dropdown_by_user(getuserdrop);
        }

        public static List<ReturnVendorDropDownModelHead> get_vendor_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            return HRM_DAL.Data.DropDown_Data.get_vendor_dropdown_by_user(getuserdrop);
        }

        public static List<ReturnContainerDPTypeModelHead> get_Containerdptype_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            return HRM_DAL.Data.DropDown_Data.get_Containerdptype_dropdown_by_user(getuserdrop);
        }

        public static List<ReturnUserTGroupsModelHead> get_user_transnational_groups_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            return HRM_DAL.Data.DropDown_Data.get_user_transnational_groups_dropdown_by_user(getuserdrop);
        }

        public static List<ReturnUserCustomerGroupsModelHead> get_user_customer_groups_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            return HRM_DAL.Data.DropDown_Data.get_user_customer_groups_dropdown_by_user(getuserdrop);
        }

        public static List<ReturnUserDeliveryCourierCompanyModelHead> get_user_delivery_courier_company_dropdown_by_user(DCCUserIdModel getuserdrop)
        {
            return HRM_DAL.Data.DropDown_Data.get_user_delivery_courier_company_dropdown_by_user(getuserdrop);
        }

        public static List<ReturnDeviceIDDropDownModelHead> get_deviceid_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            return HRM_DAL.Data.DropDown_Data.get_deviceid_dropdown_by_user(getuserdrop);
        }

        public static List<ReturnCPCodeDropDownModelHead> get_cpcode_dropdown_by_user(UserIdModel getuserdrop)
        {
            return HRM_DAL.Data.DropDown_Data.get_cpcode_dropdown_by_user(getuserdrop);
        }

        public static List<ReturnThresholdsDropDownModelHead> get_Thresholds_dropdown_by_user(UserIdModel getuserdrop)
        {
            return HRM_DAL.Data.DropDown_Data.get_Thresholds_dropdown_by_user(getuserdrop);
        }

    }
}








