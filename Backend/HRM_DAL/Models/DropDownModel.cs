
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
    public class ReturnCustomersDropDownModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnCustomersDropdownModel> customersdrop { get; set; }

    }

    //========================================================Business Unit Dropdown===========================================

    public class ReturnBUDropdownModel
    {

        public string BU_ID { get; set; }
        public string BU_CompanyName { get; set; }


    }
    public class ReturnBUDropDownModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnBUDropdownModel> businessunit { get; set; }

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
    //========================================================CPCode Dropdown===========================================

    public class ReturnCPCodeDropdownModel
    {

        public string DPT_CPCode { get; set; }
        //public string LOC_Name { get; set; }


    }
    public class ReturnCPCodeDropDownModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnCPCodeDropdownModel> CPCodes { get; set; }

    }
    //========================================================Thresholds Dropdown===========================================

    public class ReturnThresholdsDropdownModel
    {

        public string Value { get; set; }
        public string Code { get; set; }
        public string IsDefault { get; set; }


    }
    public class ReturnThresholdsDropDownModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnThresholdsDropdownModel> Thresholds { get; set; }

    }
    //========================================================DeviceID Dropdown===========================================

    public class ReturnDeviceIDDropdownModel
    {

        public string DeviceNo { get; set; }
        //public string LOC_Name { get; set; }


    }
    public class ReturnDeviceIDDropDownModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnDeviceIDDropdownModel> DeviceIDs { get; set; }

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


    //========================================================ContainerDPType Dropdown===========================================

    public class ReturnContainerDPTypeDropdownModel
    {

        public string CT_ID { get; set; }
        public string CT_Name { get; set; }


    }
    public class ReturnContainerDPTypeModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnContainerDPTypeDropdownModel> containerDPType { get; set; }

    }

    //========================================================User Transnational Groups Dropdown=====================================
    public class ReturnUserTGroupsDropdownModel
    {

        public string UGM_ID { get; set; }
        public string UGM_Name { get; set; }


    }
    public class ReturnUserTGroupsModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnUserTGroupsDropdownModel> Usertgroups { get; set; }

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

    //=========================================================delivery_courier_company Dropdown=====================================
    public class ReturnUserDeliveryCourierCompanyDropdownModel
    {
        public string DCC_ID { get; set; }
        public string DCC_Name { get; set; }
        public string DCC_Is_Local { get; set; }
        public string DCC_Is_Overseas { get; set; }
        public string DCC_Status { get; set; }
    }
    public class ReturnUserDeliveryCourierCompanyModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnUserDeliveryCourierCompanyDropdownModel> delivercompany { get; set; }

    }

}
