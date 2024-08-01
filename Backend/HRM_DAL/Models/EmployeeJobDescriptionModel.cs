using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{

    public class EmployeeJobDescriptionModel : RequestBaseModel
    {
        public int EEJ_EmployeeJobDescriptionID { get; set; }
        public string EEJ_EmployeeID { get; set; }
        public string EEJ_DepartmentID { get; set; }
        public string EEJ_JobDescriptionID { get; set; }
        public string EEJ_Remarks { get; set; }
        public DateTime EEJ_ActiveFrom { get; set; }
        public DateTime EEJ_ActiveTo { get; set; }
        public bool EEJ_Status { get; set; }
        public string EEJ_CreatedBy { get; set; }
        public DateTime EEJ_CreatedDateTime { get; set; }
        public string EEJ_ModifiedBy { get; set; }
        public DateTime EEJ_ModifiedDateTime { get; set; }
    }

    //public class ReturnEmpResponse : ReturnResponse
    //{
    //    //public bool resp { get; set; }
    //    //public string msg { get; set; }

    //}

    public class ReturnEmployeeJobDescriptionModel
    {
        [Key]

        public int EEJ_EmployeeJobDescriptionID { get; set; }
        public string EEJ_EmployeeID { get; set; }
        public string EEJ_DepartmentID { get; set; }
        public string EEJ_JobDescriptionID { get; set; }
        public string EEJ_Remarks { get; set; }
        public DateTime EEJ_ActiveFrom { get; set; }
        public DateTime EEJ_ActiveTo { get; set; }
        public bool EEJ_Status { get; set; }
        public string EEJ_CreatedBy { get; set; }
        public DateTime EEJ_CreatedDateTime { get; set; }
        public string EEJ_ModifiedBy { get; set; }
        public DateTime EEJ_ModifiedDateTime { get; set; }

    }

    public class ReturnEmployeeJobDescriptionAllModel
    {
        [Key]

        public string EEJ_EmployeeJobDescriptionID { get; set; }
        public string CUS_CompanyName { get; set; }
        public string CUS_Status { get; set; }
        public string RC { get; set; }
    }


    public class EmployeeJobDescription : RequestBaseModel
    {
        public int EEJ_EmployeeJobDescriptionID { get; set; }


    }
    public class ReturnEmployeeJobDescriptionModelHead : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnEmployeeJobDescriptionModel> EmployeeJobDescription { get; set; }


    }
    public class ReturnEmployeeJobDescriptionAllModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnEmployeeJobDescriptionAllModel> customerall { get; set; }


    }

    public class EmployeeJobDescriptionSearchModel : RequestBaseModel
    {
        public int EEJ_EmployeeJobDescriptionID { get; set; }
    }

    public class InactiveEEJModel : RequestBaseModel
    {

        public int EEJ_EmployeeJobDescriptionID { get; set; }
    }

    public class ReturnEmployeeJobDescriptionSelectModel
    {
        public int EEJ_EmployeeJobDescriptionID { get; set; }
        public string CUS_CompanyName { get; set; }

    }
}
