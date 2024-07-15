
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{

    public class SystemPMModel
    {
        [Key]
        public string SP_ID { get; set; }
        public string SP_Description { get; set; }
        public string SP_Value { get; set; }
        public string SP_Type { get; set; }
        public int SP_DisplaySeq { get; set; }
        public string USER_ID { get; set; }


    }
    public class ReturnSystemPMModel
    {
        [Key]
        public string SP_ID { get; set; }
        public string SP_Description { get; set; }
        public string SP_Value { get; set; }
        public string SP_Type { get; set; }
        public int SP_DisplaySeq { get; set; }
        public string RC { get; set; }


    }

    public class ReturnSystemPMSingleModel
    {
        [Key]
        public string SP_ID { get; set; }
        public string SP_Description { get; set; }
        public string SP_Value { get; set; }
        public string SP_Type { get; set; }
        public int SP_DisplaySeq { get; set; }



    }

    //public class InactiveSystemPMModel
    //{

    //    public string SP_ID { get; set; }
    //    public string USER_ID { get; set; }
    //}

    public class GetSystemPMAllModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string SP_ID { get; set; }
        public string SP_Description { get; set; }
        public string SP_Value { get; set; }
        public string SP_Type { get; set; }



    }
    public class GetSystemPMSingleModel
    {

        public string SP_ID { get; set; }

    }

    public class ReturSystemPMModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnSystemPMModel> SystemPM { get; set; }


    }

    public class ReturSystemPMSingleModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnSystemPMSingleModel> systempmsingle { get; set; }


    }



}
