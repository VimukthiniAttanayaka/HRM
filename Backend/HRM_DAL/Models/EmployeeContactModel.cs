using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{

    public class EmployeeContactModel : RequestBaseModel
    {
        public int EEC_ID { get; set; }
        public string EEC_EmployeeID { get; set; }
        public string EEC_Address { get; set; }
        public string EEC_EmailAddress { get; set; }
        public string EEC_MobileNumber { get; set; }
        public string EEC_PhoneNumber1 { get; set; }
        public string EEC_PhoneNumber2 { get; set; }
        public bool EEC_Status { get; set; }
        public string EEC_CreatedBy { get; set; }
        public DateTime EEC_CreatedDateTime { get; set; }
        public string EEC_ModifiedBy { get; set; }
        public DateTime EEC_ModifiedDateTime { get; set; }
        public string EEC_Remarks { get;  set; }
    }

    public class ReturnEmployeeContactModel
    {
        [Key]

        public int EEC_ID { get; set; }

        public string EEC_EmployeeID { get; set; }
        public string EEC_Address { get; set; }
        public string EEC_EmailAddress { get; set; }
        public string EEC_MobileNumber { get; set; }
        public string EEC_PhoneNumber1 { get; set; }
        public string EEC_PhoneNumber2 { get; set; }
        public bool EEC_Status { get; set; }
        public string EEC_CreatedBy { get; set; }
        public DateTime EEC_CreatedDateTime { get; set; }
        public string EEC_ModifiedBy { get; set; }
        public DateTime EEC_ModifiedDateTime { get; set; }
        public string EEC_Remarks { get; set; }
    }


    public class EmployeeContact : RequestBaseModel
    {
        public int EEC_ID { get; set; }


    }
    public class ReturnEmployeeContactModelHead : ReturnResponse
    {
        public List<ReturnEmployeeContactModel> EmployeeContact { get; set; }


    }
    public class ReturnEmployeeContactAllModelHead : ReturnResponse
    {
        public List<ReturnEmployeeContactModel> EmployeeContact { get; set; }
    }

    public class EmployeeContactSearchModel : RequestBaseModel
    {      
        public string EEC_EmployeeID { get;  set; }
    }

    public class InactiveEECModel : RequestBaseModel
    {
        public int EEC_ID { get; set; }
    }

    public class ReturnEmployeeContactSelectModel
    {
        public int EEC_ID { get; set; }

    }
}
