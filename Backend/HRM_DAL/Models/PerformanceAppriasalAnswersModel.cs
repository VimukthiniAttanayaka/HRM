using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class ReturnPerformanceAppriasalAnswersModelHead : ReturnResponse
    {
        public List<ReturnPerformanceAppriasalAnswersModel> PerformanceAppriasalAnswers { get; set; }
    }

    public class PerformanceAppriasalAnswersModel : RequestBaseModel
    {
        public string PAAN_ID { get; set; }
        public string PAAN_PAAQ_ID { get; set; }
        public string PAAN_Comments { get; set; }
        public int PAAN_Score { get; set; }
        public int PAAP_FilledBy { get; set; }
        public bool PAAN_Status { get; set; }
        public string PAAN_CreatedBy { get; set; }
        public DateTime PAAN_CreatedDateTime { get; set; }
        public string PAAN_ModifiedBy { get; set; }
        public DateTime PAAN_ModifiedDateTime { get; set; }
    }

    public class ReturnPerformanceAppriasalAnswersModel
    {
        [Key]
        public string PAAN_ID { get; set; }
        public string PAAN_PAAQ_ID { get; set; }
        public string PAAN_Comments { get; set; }
        public int PAAN_Score { get; set; }
        public int PAAP_FilledBy { get; set; }
        public bool PAAN_Status { get; set; }
        public string PAAN_CreatedBy { get; set; }
        public DateTime PAAN_CreatedDateTime { get; set; }
        public string PAAN_ModifiedBy { get; set; }
        public DateTime PAAN_ModifiedDateTime { get; set; }
    }

    public class ReturnPerformanceAppriasalAnswersAllModel
    {
        [Key]

        public string PAAN_ID { get; set; }
        public string RC { get; set; }
    }


    public class PerformanceAppriasalAnswers : RequestBaseModel
    {
        public string PAAN_ID { get; set; }


    }

    public class ReturnPerformanceAppriasalAnswersAllModelHead : ReturnResponse
    {
        public List<ReturnPerformanceAppriasalAnswersAllModel> PerformanceAppriasalAnswersall { get; set; }


    }

    public class PerformanceAppriasalAnswersSearchModel : RequestBaseModel
    {
        public string PAAN_ID { get; set; }
    }

    public class ReturnPerformanceAppriasalAnswersSelectModel
    {
        public string PAAN_ID { get; set; }

    }

    public class InactivePAANModel : RequestBaseModel
    {
        public string PAAN_ID { get; set; }

    }
}
