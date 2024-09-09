using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class ReturnPerformanceAppriasalQuestionsModelHead : ReturnResponse
    {
        public List<ReturnPerformanceAppriasalQuestionsModel> PerformanceAppriasalQuestions { get; set; }
    }

    public class PerformanceAppriasalQuestionsModel : RequestBaseModel
    {
        public string PAAQ_ID { get; set; }
        public string PAAQ_PerformanceAppriasalQuestions { get; set; }
        public int PAAQ_LeaveAlotment { get; set; }
        public bool PAAQ_Status { get; set; }
        public string PAAQ_CreatedBy { get; set; }
        public DateTime PAAQ_CreatedDateTime { get; set; }
        public string PAAQ_ModifiedBy { get; set; }
        public DateTime PAAQ_ModifiedDateTime { get; set; }
    }

    public class ReturnPerformanceAppriasalQuestionsModel
    {
        [Key]
        public string PAAQ_ID { get; set; }
        public string PAAQ_PerformanceAppriasalQuestions { get; set; }
        public int PAAQ_LeaveAlotment { get; set; }
        public bool PAAQ_Status { get; set; }
        public string PAAQ_CreatedBy { get; set; }
        public DateTime PAAQ_CreatedDateTime { get; set; }
        public string PAAQ_ModifiedBy { get; set; }
        public DateTime PAAQ_ModifiedDateTime { get; set; }
    }

    public class ReturnPerformanceAppriasalQuestionsAllModel
    {
        [Key]

        public string PAAQ_ID { get; set; }
        public string RC { get; set; }
    }


    public class PerformanceAppriasalQuestions : RequestBaseModel
    {
        public string PAAQ_ID { get; set; }


    }

    public class ReturnPerformanceAppriasalQuestionsAllModelHead : ReturnResponse
    {
        public List<ReturnPerformanceAppriasalQuestionsAllModel> PerformanceAppriasalQuestionsall { get; set; }


    }

    public class PerformanceAppriasalQuestionsSearchModel : RequestBaseModel
    {
        public string PAAQ_ID { get; set; }
    }

    public class ReturnPerformanceAppriasalQuestionsSelectModel
    {
        public string PAAQ_ID { get; set; }

    }

    public class InactivePAAQModel : RequestBaseModel
    {
        public string PAAQ_ID { get; set; }

    }
}
