using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class EmployeeModel : RequestBaseModel
    {
        public string EME_CustomerID { get; set; }
        public string EME_DepartmentID { get; set; }
        [Key]
        public string EME_EmployeeID { get; set; }
        public string EME_FirstName { get; set; }
        public string EME_LastName { get; set; }
        public string EME_Gender { get; set; }
        public string EME_MaritalStatus { get; set; }
        public string EME_Nationality { get; set; }
        public string EME_BloodGroup { get; set; }
        public string EME_NIC { get; set; }
        public string EME_Passport { get; set; }
        public string EME_DrivingLicense { get; set; }
        public string EME_PrefferedName { get; set; }
        public string EME_JobTitle_Code { get; set; }
        public string EME_ReportingManager { get; set; }
        public string EME_EmployeeType { get; set; }
        public string EME_PayeeTaxNumber { get; set; }
        public decimal EME_Salary { get; set; }
        public string EME_Address { get; set; }
        public string EME_EmailAddress { get; set; }
        public string EME_MobileNumber { get; set; }
        public string EME_PhoneNumber1 { get; set; }
        public string EME_PhoneNumber2 { get; set; }
        public DateTime? EME_DateOfHire { get; set; }
        public bool EME_Status { get; set; }
        //public string EME_CreatedBy { get; set; }
        //public DateTime EME_CreatedDateTime { get; set; }
        //public string EME_ModifiedBy { get; set; }
        //public DateTime EME_ModifiedDateTime { get; set; }
        public DateTime? EME_DateOfBirth { get; set; }
    }

    public class ReturnEmpResponse : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }

    }

    public class ReturnEmployeeModel
    {

        public string EME_CustomerID { get; set; }
        public string EME_DepartmentID { get; set; }
        [Key]
        public string EME_EmployeeID { get; set; }
        public string EME_FirstName { get; set; }
        public string EME_LastName { get; set; }
        public string EME_Gender { get; set; }
        public string EME_MaritalStatus { get; set; }
        public string EME_Nationality { get; set; }
        public string EME_BloodGroup { get; set; }
        public string EME_NIC { get; set; }
        public string EME_Passport { get; set; }
        public string EME_DrivingLicense { get; set; }
        public string EME_PrefferedName { get; set; }
        public string EME_JobTitle_Code { get; set; }
        public string EME_ReportingManager { get; set; }
        public string EME_EmployeeType { get; set; }
        public string EME_PayeeTaxNumber { get; set; }
        public decimal EME_Salary { get; set; }
        public string EME_Address { get; set; }
        public string EME_EmailAddress { get; set; }
        public string EME_MobileNumber { get; set; }
        public string EME_PhoneNumber1 { get; set; }
        public string EME_PhoneNumber2 { get; set; }
        public DateTime EME_DateOfHire { get; set; }
        public bool EME_Status { get; set; }
        //public string EME_CreatedBy { get; set; }
        //public DateTime EME_CreatedDateTime { get; set; }
        //public string EME_ModifiedBy { get; set; }
        //public DateTime EME_ModifiedDateTime { get; set; }
        public DateTime EME_DateOfBirth { get; set; }
    }

    public class ReturnEmployeeAllModel
    {
        [Key]

        public string EME_EmployeeID { get; set; }
        public string CUS_CompanyName { get; set; }
        public string CUS_Status { get; set; }
        public string RC { get; set; }
    }


    public class Employee : RequestBaseModel
    {
        public string EME_EmployeeID { get; set; }


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
        public string EME_EmployeeID { get; set; }
    }

    public class EmployeeDocumentSearchModel : RequestBaseModel
    {
        public string EME_EmployeeID { get; set; }
        public string EED_EmployeeDocumentID { get; set; }
    }
    public class InactiveEmpModel : RequestBaseModel
    {

        public string EME_EmployeeID { get; set; }
    }

    public class ReturnEmployeeSelectModel
    {
        public string EME_EmployeeID { get; set; }
        public string CUS_CompanyName { get; set; }

    }
}
