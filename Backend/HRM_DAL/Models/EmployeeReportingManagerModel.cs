using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{

    public class EmployeeReportingManagerModel : RequestBaseModel
    {
        public int EERM_ID { get; set; }
        public string EERM_EmployeeID { get; set; }
        public string EERM_ReportingManagerID { get; set; }
        public string EERM_Remarks { get; set; }
        public DateTime EERM_ActiveFrom { get; set; }
        public DateTime EERM_ActiveTo { get; set; }
        public bool EERM_Status { get; set; }
        public string EERM_CreatedBy { get; set; }
        public DateTime EERM_CreatedDateTime { get; set; }
        public string EERM_ModifiedBy { get; set; }
        public DateTime EERM_ModifiedDateTime { get; set; }
    }

    public class ReturnEmployeeReportingManagerModel
    {
        [Key]

        public int EERM_ID { get; set; }
        public string EERM_EmployeeID { get; set; }
        public string EERM_ReportingManagerID { get; set; }
        public string EERM_Remarks { get; set; }
        public DateTime EERM_ActiveFrom { get; set; }
        public DateTime EERM_ActiveTo { get; set; }
        public bool EERM_Status { get; set; }
        public string EERM_CreatedBy { get; set; }
        public DateTime EERM_CreatedDateTime { get; set; }
        public string EERM_ModifiedBy { get; set; }
        public DateTime EERM_ModifiedDateTime { get; set; }

    }


    public class EmployeeReportingManager : RequestBaseModel
    {
        public int EERM_ID { get; set; }


    }
    public class ReturnEmployeeReportingManagerModelHead : ReturnResponse
    {
        public List<ReturnEmployeeReportingManagerModel> EmployeeReportingManager { get; set; }


    }
    public class ReturnEmployeeReportingManagerAllModelHead : ReturnResponse
    {
        public List<ReturnEmployeeReportingManagerModel> EmployeeReportingManager { get; set; }
    }

    public class EmployeeReportingManagerSearchModel : RequestBaseModel
    {
        public int EERM_ID { get; set; }
    }

    public class InactiveEERMModel : RequestBaseModel
    {

        public int EERM_ID { get; set; }
    }

    public class ReturnEmployeeReportingManagerSelectModel
    {
        public int EERM_JobDescriptionID { get; set; }

    }
}
