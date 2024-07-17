using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class ReturnBUEmployeeModelHead : ReturnResponse
    {
        public List<ReturnUserCustModel> Employee { get; set; }
    }

    public class EmployeeModel : RequestBaseModel
    {
        public string USR_CustomerID { get; set; }
        public string USR_DepartmentID { get; set; }
        public string USR_EmployeeID { get; set; }
        public string USR_FirstName { get; set; }
        public string USR_LastName { get; set; }
        public string USR_PrefferedName { get; set; }
        public string USR_OrgStructuralLevel1 { get; set; }
        public string USR_OrgStructuralLevel2 { get; set; }
        public string USR_DepartmentDetail1 { get; set; }
        public string USR_DepartmentDetail2 { get; set; }
        public string USR_DepartmentDetail3 { get; set; }
        public string USR_JobCodeDescription { get; set; }
        public string USR_Address { get; set; }
        public string USR_EmailAddress { get; set; }
        public string USR_MobileNumber { get; set; }
        public string USR_PhoneNumber1 { get; set; }
        public string USR_PhoneNumber2 { get; set; }
        public string USR_RankDescription { get; set; }
        public string USR_StaffLocation { get; set; }
        public string USR_Remarks { get; set; }
        public string USR_Pwd { get; set; }
        public DateTime USR_LastResetDateTime { get; set; }
        public DateTime USR_SyncedDateTime { get; set; }
        public DateTime USR_ActiveFrom { get; set; }
        public DateTime USR_ActiveTo { get; set; }
        public bool USR_Status { get; set; }
        public string USR_CreatedBy { get; set; }
        public DateTime USR_CreatedDateTime { get; set; }
        public string USR_ModifiedBy { get; set; }
        public DateTime USR_ModifiedDateTime { get; set; }
    }

    public class ReturnEmpResponse : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }

    }

    public class ReturnEmployeeModel
    {
        [Key]

        public string USR_CustomerID { get; set; }
        public string USR_DepartmentID { get; set; }
        public string USR_EmployeeID { get; set; }
        public string USR_FirstName { get; set; }
        public string USR_LastName { get; set; }
        public string USR_PrefferedName { get; set; }
        public string USR_OrgStructuralLevel1 { get; set; }
        public string USR_OrgStructuralLevel2 { get; set; }
        public string USR_DepartmentDetail1 { get; set; }
        public string USR_DepartmentDetail2 { get; set; }
        public string USR_DepartmentDetail3 { get; set; }
        public string USR_JobCodeDescription { get; set; }
        public string USR_Address { get; set; }
        public string USR_EmailAddress { get; set; }
        public string USR_MobileNumber { get; set; }
        public string USR_PhoneNumber1 { get; set; }
        public string USR_PhoneNumber2 { get; set; }
        public string USR_RankDescription { get; set; }
        public string USR_StaffLocation { get; set; }
        public string USR_Remarks { get; set; }
        public string USR_Pwd { get; set; }
        public DateTime USR_LastResetDateTime { get; set; }
        public DateTime USR_SyncedDateTime { get; set; }
        public DateTime USR_ActiveFrom { get; set; }
        public DateTime USR_ActiveTo { get; set; }
        public bool USR_Status { get; set; }
        public string USR_CreatedBy { get; set; }
        public DateTime USR_CreatedDateTime { get; set; }
        public string USR_ModifiedBy { get; set; }
        public DateTime USR_ModifiedDateTime { get; set; }
    }

    public class ReturnEmployeeAllModel
    {
        [Key]

        public string USR_EmployeeID { get; set; }
        public string CUS_CompanyName { get; set; }
        public string CUS_Status { get; set; }
        public string RC { get; set; }
    }


    public class Employee : RequestBaseModel
    {
        public string USR_EmployeeID { get; set; }


    }
    public class ReturnEmployeeModelHead : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnEmployeeModel> Employee { get; set; }


    }
    public class ReturnEmployeeAllModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnEmployeeAllModel> customerall { get; set; }


    }

    public class InactiveEmpModel : RequestBaseModel
    {

        public string USR_EmployeeID { get; set; }
    }

    public class ReturnEmployeeSelectModel
    {
        public string USR_EmployeeID { get; set; }
        public string CUS_CompanyName { get; set; }

    }
}
