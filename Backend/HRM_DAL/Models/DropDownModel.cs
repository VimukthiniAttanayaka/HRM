
using System.Collections.Generic;

namespace HRM_DAL.Models
{

    //========================================================Customers Dropdown===========================================
    public class UserIdModel
    {
        public string USER_ID { get; set; }

        public string USERGROUP_ID { get; set; }
    }
    public class DCCUserIdModel
    {
        public string USER_ID { get; set; }

        public string USERGROUP_ID { get; set; }
        public bool DCC_Is_Local { get; set; }
        public bool DCC_Is_Overseas { get; set; }
    }

    public class ReturnCustomersDropdownModel
    {

        public string CUS_ID { get; set; }
        public string CUS_CompanyName { get; set; }


    }

    //========================================================Department Dropdown===========================================

    public class ReturnDepartmentDropdownModel
    {

        public string DPT_ID { get; set; }
        public string DPT_Name { get; set; }


    }
    public class ReturnDepartmentDropDownModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnDepartmentDropdownModel> department { get; set; }

    }

    //========================================================Location Dropdown===========================================

    public class ReturnlocationDropdownModel
    {

        public string LOC_ID { get; set; }
        public string LOC_Name { get; set; }


    }
    public class ReturnlocationDropDownModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnlocationDropdownModel> location { get; set; }

    }
    //========================================================Vendor Dropdown===========================================

    public class ReturnVendorDropdownModel
    {

        public string KV_ID { get; set; }
        public string KV_CompanyName { get; set; }


    }
    public class ReturnVendorDropDownModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnVendorDropdownModel> vendor { get; set; }

    }

    //=========================================================User Customer Groups Dropdown=====================================
    public class ReturnUserCustomerGroupsDropdownModel
    {

        public string UGM_ID { get; set; }
        public string UGM_Name { get; set; }


    }
    public class ReturnUserCustomerGroupsModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnUserCustomerGroupsDropdownModel> Usercgroups { get; set; }

    }

}
