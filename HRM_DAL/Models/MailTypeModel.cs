
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class MailTypeModel : RequestBaseModel
    {
        [Key]
        public string MT_ID { get; set; }
        public string MT_Name { get; set; }
        public string USER_ID { get; set; }
        public bool MT_Status { get; set; }
    }
    public class ReturnMailTypeModel
    {
        [Key]
        public string MT_ID { get; set; }
        public string MT_Name { get; set; }
        public string MT_Status { get; set; }
        public string MT_CreatedBy { get; set; }
        public string MT_CreatedDateTime { get; set; }
        public string MT_ModifiedBy { get; set; }
        public string MT_ModifiedDateTime { get; set; }
        public string RC { get; set; }
    }
    public class ReturnMailTypeAllModel
    {
        [Key]
        public string MT_ID { get; set; }
        public string MT_Name { get; set; }
        public string MT_Status { get; set; }
        public string RC { get; set; }


    }

    public class InactiveMailTypeModel : RequestBaseModel
    {
        public string MT_ID { get; set; }
        public string USER_ID { get; set; }
    }

    public class GetMtAllModel : RequestBaseModel
    {
        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string MT_Name { get; set; }
        public string MT_Status { get; set; }
    }
    public class GetMtsingleModel : RequestBaseModel
    {
        public string MT_ID { get; set; }
    }

    public class ReturMailTypeModelHead : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnMailTypeModel> MailType { get; set; }


    }

    public class ReturMailTypeAllModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnMailTypeModel> mailtypeall { get; set; }


    }







}
