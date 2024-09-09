using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class ReturnPerformanceAppriasalApprovalModelHead : ReturnResponse
    {
        public List<ReturnPerformanceAppriasalApprovalModel> PerformanceAppriasalApproval { get; set; }
    }

    public class PerformanceAppriasalApprovalModel : RequestBaseModel
    {
        public string PAAP_ID { get; set; }
        public string PAAP_Comments { get; set; }
        public int PAAP_Score { get; set; }
        public int PAAP_ApprovedBy { get; set; }
        public bool PAAP_Status { get; set; }
        public string PAAP_CreatedBy { get; set; }
        public DateTime PAAP_CreatedDateTime { get; set; }
        public string PAAP_ModifiedBy { get; set; }
        public DateTime PAAP_ModifiedDateTime { get; set; }
    }

    public class ReturnPerformanceAppriasalApprovalModel
    {
        [Key]
        public string PAAP_ID { get; set; }
        public string PAAP_Comments { get; set; }
        public int PAAP_Score { get; set; }
        public int PAAP_ApprovedBy { get; set; }
        public bool PAAP_Status { get; set; }
        public string PAAP_CreatedBy { get; set; }
        public DateTime PAAP_CreatedDateTime { get; set; }
        public string PAAP_ModifiedBy { get; set; }
        public DateTime PAAP_ModifiedDateTime { get; set; }
    }

    public class ReturnPerformanceAppriasalApprovalAllModel
    {
        [Key]

        public string PAAP_ID { get; set; }
        public string RC { get; set; }
    }


    public class PerformanceAppriasalApproval : RequestBaseModel
    {
        public string PAAP_ID { get; set; }


    }

    public class ReturnPerformanceAppriasalApprovalAllModelHead : ReturnResponse
    {
        public List<ReturnPerformanceAppriasalApprovalAllModel> PerformanceAppriasalApprovalall { get; set; }


    }

    public class PerformanceAppriasalApprovalSearchModel : RequestBaseModel
    {
        public string PAAP_ID { get; set; }
    }

    public class ReturnPerformanceAppriasalApprovalSelectModel
    {
        public string PAAP_ID { get; set; }

    }

    public class InactivePAAPModel : RequestBaseModel
    {
        public string PAAP_ID { get; set; }

    }
}
