using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class ReturnAccessGroupModelHead : ReturnResponse
    {
        public List<ReturnAccessGroupModel> AccessGroup { get; set; }
    }

    public class AccessGroupModel : RequestBaseModel
    {
        public string UAG_AccessGroupID { get; set; }
        public string UAG_AccessGroup { get; set; }
        public bool UAG_Status { get; set; }
        public string UAG_CreatedBy { get; set; }
        public DateTime UAG_CreatedDateTime { get; set; }
        public string UAG_ModifiedBy { get; set; }
        public DateTime UAG_ModifiedDateTime { get; set; }
    }

    public class ReturnAccessGroupModel
    {
        [Key]
        public string UAG_AccessGroupID { get; set; }
        public string UAG_AccessGroup { get; set; }
        public bool UAG_Status { get; set; }
        public string UAG_CreatedBy { get; set; }
        public DateTime UAG_CreatedDateTime { get; set; }
        public string UAG_ModifiedBy { get; set; }
        public DateTime UAG_ModifiedDateTime { get; set; }
    }

    public class ReturnAccessGroupAllModel
    {
        [Key]

        public string UAG_AccessGroupID { get; set; }
        public string RC { get; set; }
    }


    public class AccessGroup : RequestBaseModel
    {
        public string UAG_AccessGroupID { get; set; }


    }

    public class ReturnAccessGroupAllModelHead : ReturnResponse
    {
        public List<ReturnAccessGroupAllModel> AccessGroupall { get; set; }


    }

    public class AccessGroupSearchModel : RequestBaseModel
    {
        public string UAG_AccessGroupID { get; set; }
    }

    public class ReturnAccessGroupSelectModel
    {
        public string UAG_AccessGroupID { get; set; }

    }

    public class InactiveEUGModel : RequestBaseModel
    {
        public string UAG_AccessGroupID { get; set; }

    }
}
