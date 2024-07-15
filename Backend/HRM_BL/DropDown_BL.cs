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

        public static List<ReturnUserCustomerGroupsModelHead> get_user_customer_groups_dropdown_by_user(UserIdModel getuserdrop)//ok
        {
            return HRM_DAL.Data.DropDown_Data.get_user_customer_groups_dropdown_by_user(getuserdrop);
        }
    }
}








