
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{

    public class ReturnUserGroupMasterModel
    {
        [Key]
        public string UGM_ID { get; set; }
        public string UGM_Name { get; set; }

        public string UGM_Type { get; set; }

        public string UGM_VendorID { get; set; }

        public string UGM_DisplaySeq { get; set; }

        public string UGM_Remarks { get; set; }

        public string UGM_Status { get; set; }
        public string RC { get; set; }


    }

    public class GetUGMAllModel : RequestBaseModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string UGM_Type { get; set; }
        public string UGM_Status { get; set; }

        public string UGM_VendorID { get; set; }
    }

    public class GetUGMSingleModel : RequestBaseModel
    {

        public string UGM_ID { get; set; }
    }
    public class ReturUserGroupMasterModelHead:ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnUserGroupMasterModel> UserGroupMaster { get; set; }


    }








}
