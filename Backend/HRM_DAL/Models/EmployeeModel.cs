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
        public string ECE_CustomerID { get; set; }
        public string ECE_DepartmentID { get; set; }
        public string ECE_EmployeeID { get; set; }
        public string ECE_FirstName { get; set; }
        public string ECE_LastName { get; set; }
        public string ECE_PrefferedName { get; set; }
        public string ECE_JobTitle_Code { get; set; }
        public string ECE_Address { get; set; }
        public string ECE_Address1 { get; set; }
        public string ECE_Address2 { get; set; }
        public string ECE_EmailAddress { get; set; }
        public string ECE_MobileNumber { get; set; }
        public string ECE_PhoneNumber1 { get; set; }
        public string ECE_PhoneNumber2 { get; set; }
        public string ECE_RankDescription { get; set; }
        public string ECE_StaffLocation { get; set; }
        public string ECE_Remarks { get; set; }
        public DateTime ECE_LastResetDateTime { get; set; }
        public DateTime ECE_SyncedDateTime { get; set; }
        public DateTime ECE_ActiveFrom { get; set; }
        public DateTime ECE_ActiveTo { get; set; }
        public bool ECE_Status { get; set; }
        public string ECE_CreatedBy { get; set; }
        public DateTime ECE_CreatedDateTime { get; set; }
        public string ECE_ModifiedBy { get; set; }
        public DateTime ECE_ModifiedDateTime { get; set; }
    }

    public class ReturnEmpResponse : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }

    }

    public class ReturnEmployeeModel
    {
        [Key]

        public string ECE_CustomerID { get; set; }
        public string ECE_DepartmentID { get; set; }
        public string ECE_EmployeeID { get; set; }
        public string ECE_FirstName { get; set; }
        public string ECE_LastName { get; set; }
        public string ECE_PrefferedName { get; set; }
        public string ECE_JobTitle_Code { get; set; }
        public string ECE_Address { get; set; }
        public string ECE_Address1 { get; set; }
        public string ECE_Address2 { get; set; }
        public string ECE_EmailAddress { get; set; }
        public string ECE_MobileNumber { get; set; }
        public string ECE_PhoneNumber1 { get; set; }
        public string ECE_PhoneNumber2 { get; set; }
        public string ECE_RankDescription { get; set; }
        public string ECE_StaffLocation { get; set; }
        public string ECE_Remarks { get; set; }
        public DateTime ECE_LastResetDateTime { get; set; }
        public DateTime ECE_SyncedDateTime { get; set; }
        public DateTime ECE_ActiveFrom { get; set; }
        public DateTime ECE_ActiveTo { get; set; }
        public bool ECE_Status { get; set; }
        public string ECE_CreatedBy { get; set; }
        public DateTime ECE_CreatedDateTime { get; set; }
        public string ECE_ModifiedBy { get; set; }
        public DateTime ECE_ModifiedDateTime { get; set; }
    }

    public class ReturnEmployeeAllModel
    {
        [Key]

        public string ECE_EmployeeID { get; set; }
        public string CUS_CompanyName { get; set; }
        public string CUS_Status { get; set; }
        public string RC { get; set; }
    }


    public class Employee : RequestBaseModel
    {
        public string ECE_EmployeeID { get; set; }


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

    public class EmployeeSearchModel : RequestBaseModel
    {
        public string ECE_EmployeeID { get; set; }
    }

    public class InactiveEmpModel : RequestBaseModel
    {

        public string ECE_EmployeeID { get; set; }
    }

    public class ReturnEmployeeSelectModel
    {
        public string ECE_EmployeeID { get; set; }
        public string CUS_CompanyName { get; set; }

    }
}
