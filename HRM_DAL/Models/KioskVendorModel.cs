
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class KVMasterModel : RequestBaseModel
    {
        [Key]
        public string KV_ID { get; set; }
        public string KV_CompanyName { get; set; }
        public string USER_ID { get; set; }
        public bool KV_Status { get; set; }

    }

    public class ReturnKVMasterModel
    {
        [Key]
        public string KV_ID { get; set; }
        public string KV_CompanyName { get; set; }
        public string KV_Status { get; set; }
        public string RC { get; set; }
        public string KV_CreatedBy { get; set; }
        public string KV_CreatedDateTime { get; set; }
        public string KV_ModifiedBy { get; set; }
        public string KV_ModifiedDateTime { get; set; }
    }

    public class InactiveKVMasterModel : RequestBaseModel
    {

        public string KV_ID { get; set; }
        public string USER_ID { get; set; }
    }

    public class GetKVMasterAllModel : RequestBaseModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string KV_ID { get; set; }
        public string KV_CompanyName { get; set; }
        public string KV_Status { get; set; }
    }
    public class GetKVMasterModel : RequestBaseModel
    {

        public string KV_ID { get; set; }

    }

    public class ReturKVModelHead : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnKVMasterModel> KioskVendor { get; set; }


    }







}
