
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class ExitInterviewQuestionsBulkModel : RequestBaseModel
    {
        public List<ExitInterviewQuestionsModel> ExitInterviewQuestions { get; set; }
    }
    public class ExitInterviewQuestionsModel : RequestBaseModel
    {
        [Key]
        public int EIEIQ_ID { get; set; }
        public string EIEIQ_Description { get; set; }
        public string EIEIQ_EntryType { get; set; }
        public bool EIEIQ_Status { get; set; }
        //public string EIEIQ_CreatedBy { get; set; }
        //public DateTime EIEIQ_CreatedDateTime { get; set; }
        //public string EIEIQ_ModifiedBy { get; set; }
        //public DateTime EIEIQ_ModifiedDateTime { get; set; }
    }

    public class ReturnExitInterviewQuestionsModel
    {
        [Key]
        public int EIEIQ_ID { get; set; }
        public string EIEIQ_Description { get; set; }
        public string EIEIQ_EntryType { get; set; }
        public bool EIEIQ_Status { get; set; }
        public string EIEIQ_CreatedBy { get; set; }
        public DateTime EIEIQ_CreatedDateTime { get; set; }
        public string EIEIQ_ModifiedBy { get; set; }
        public DateTime EIEIQ_ModifiedDateTime { get; set; }
    }

    //public class ReturnExitInterviewQuestionsAllModel //: ReturnResponse
    //{
    //    [Key]
    //    public string EIEIQ_ExitInterviewQuestionsID { get; set; }
    //    public string EIEIQ_ExitInterviewQuestions { get; set; }
    //    public string EIEIQ_Status { get; set; }
    //    public string RC { get; set; }

    //}

    public class InactiveExitInterviewQuestionsModel : RequestBaseModel
    {

        public string EIEIQ_ID { get; set; }

    }

    public class GetExitInterviewQuestionsAllModel : RequestBaseModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string EIEIQ_ID { get; set; }
        public bool EIEIQ_Status { get; set; }
    }

    public class GetExitInterviewQuestionsSingleModel : RequestBaseModel
    {
        public string EIEIQ_ID { get; set; }
    }

    public class ReturExitInterviewQuestionsModelHead : ReturnResponse
    {
        public List<ReturnExitInterviewQuestionsModel> ExitInterviewQuestions { get; set; }
    }
}
