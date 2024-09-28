using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{

    public class EmployeeSalaryModel : RequestBaseModel
    {
        public int EES_ID { get; set; }
        public string EES_EmployeeID { get; set; }
        public decimal EES_Salary { get; set; }
        public DateTime EES_ActiveFrom { get; set; }
        public DateTime EES_ActiveTo { get; set; }
        public bool EES_Status { get; set; }
        public string EES_CreatedBy { get; set; }
        public DateTime EES_CreatedDateTime { get; set; }
        public string EES_ModifiedBy { get; set; }
        public DateTime EES_ModifiedDateTime { get; set; }
        public string EES_Remarks { get; set; }
        public string EES_SalaryType { get; set; }

    }

    public class ReturnEmployeeSalaryModel
    {
        [Key]

        public int EES_ID { get; set; }
        public string EES_EmployeeID { get; set; }
        public decimal EES_Salary { get; set; }
        public DateTime EES_ActiveFrom { get; set; }
        public DateTime EES_ActiveTo { get; set; }
        public bool EES_Status { get; set; }
        public string EES_CreatedBy { get; set; }
        public DateTime EES_CreatedDateTime { get; set; }
        public string EES_ModifiedBy { get; set; }
        public DateTime EES_ModifiedDateTime { get; set; }
        public string EES_Remarks { get; set; }
        public string EES_SalaryType { get; set; }
    }


    public class EmployeeSalary : RequestBaseModel
    {
        public int EES_ID { get; set; }


    }
    public class ReturnEmployeeSalaryModelHead : ReturnResponse
    {
        public List<ReturnEmployeeSalaryModel> EmployeeSalary { get; set; }


    }
    public class ReturnEmployeeSalaryAllModelHead : ReturnResponse
    {
        public List<ReturnEmployeeSalaryModel> EmployeeSalary { get; set; }
    }

    public class EmployeeSalarySearchModel : RequestBaseModel
    {
        public int EES_ID { get; set; }
    }

    public class InactiveEESModel : RequestBaseModel
    {
        public int EES_ID { get; set; }
    }

    public class ReturnEmployeeSalarySelectModel
    {
        public int EES_ID { get; set; }

    }
}
