using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class ReportingManagerModel : RequestBaseModel
    {
        public int RM_ID { get; set; }
        public string RM_ReportingManagerID { get; set; }
        public string RM_EmployeeID { get; set; }
        public bool RM_Status { get; set; }
        public string RM_CreatedBy { get; set; }
        public DateTime RM_CreatedDateTime { get; set; }
        public string RM_ModifiedBy { get; set; }
        public DateTime RM_ModifiedDateTime { get; set; }
    }

    public class ReturnReportingManagerModel
    {
        [Key]

        public int RM_ID { get; set; }
        public string RM_ReportingManagerID { get; set; }
        public string RM_EmployeeID { get; set; }
        public bool RM_Status { get; set; }
        public string RM_CreatedBy { get; set; }
        public DateTime RM_CreatedDateTime { get; set; }
        public string RM_ModifiedBy { get; set; }
        public DateTime RM_ModifiedDateTime { get; set; }
    }

    public class ReportingManager : RequestBaseModel
    {
        public int RM_ID { get; set; }
    }
    public class InactiveRMModel : RequestBaseModel
    {
        public int RM_ID { get; set; }
    }
    public class ReturnReportingManagerModelHead : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnReportingManagerModel> ReportingManager { get; set; }


    }
    public class ReportingManagerSearchModel : RequestBaseModel
    {
        public int RM_ID { get; set; }
        public string RM_EmployeeID { get; set; }
    }
}
