
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class DeliveryCourierCompanyModel : RequestBaseModel
    {
        [Key]
        public string DCC_ID { get; set; }
        public string DCC_Name { get; set; }
        public string DCC_Is_Local { get; set; }
        public string DCC_Is_Overseas { get; set; }
        public string USER_ID { get; set; }
        public bool DCC_Status { get; set; }


    }

    public class ReturnDCCompanyModel
    {
        [Key]
        public string DCC_ID { get; set; }
        public string DCC_Name { get; set; }
        public string DCC_Is_Local { get; set; }
        public string DCC_Is_Overseas { get; set; }
        public string DCC_Status { get; set; }
        public string DCC_CreatedBy { get; set; }
        public string DCC_CreatedDateTime { get; set; }
        public string DCC_ModifiedBy { get; set; }
        public string DCC_ModifiedDateTime { get; set; }
        public string RC { get; set; }
    }

    public class InactiveDCCompanyModel : RequestBaseModel
    {

        public string DCC_ID { get; set; }
        public string USER_ID { get; set; }
    }

    public class GetDCCompanyAllModel : RequestBaseModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string DCC_ID { get; set; }
        public string DCC_Name { get; set; }
        public string DCC_Is_Local { get; set; }
        public string DCC_Is_Overseas { get; set; }
        public string DCC_Status { get; set; }


    }
    public class GetDCCompanyModel : RequestBaseModel
    {

        public string DCC_ID { get; set; }

    }

    public class ReturDCCompanyModelHead : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnDCCompanyModel> DCCompany { get; set; }


    }







}
