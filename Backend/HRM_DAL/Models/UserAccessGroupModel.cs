using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class ReturnUserAccessGroupModelHead : ReturnResponse
    {
        public List<ReturnUserAccessGroupModel> UserAccessGroup { get; set; }
    }

    public class UserAccessGroupModel : RequestBaseModel
    {
        public int UUAG_UserAccessGroupID { get; set; }
        public string UUAG_MenuAccessID { get; set; }
        public string UUAG_UserName { get; set; }
        public bool UUAG_Status { get; set; }
        public string UUAG_CreatedBy { get; set; }
        public DateTime UUAG_CreatedDateTime { get; set; }
        public string UUAG_ModifiedBy { get; set; }
        public DateTime UUAG_ModifiedDateTime { get; set; }
    }

    public class ReturnUserAccessGroupModel
    {
        [Key]
        public int UUAG_UserAccessGroupID { get; set; }
        public string UUAG_MenuAccessID { get; set; }
        public string UUAG_UserName { get; set; }
        public bool UUAG_Status { get; set; }
        public string UUAG_CreatedBy { get; set; }
        public DateTime UUAG_CreatedDateTime { get; set; }
        public string UUAG_ModifiedBy { get; set; }
        public DateTime UUAG_ModifiedDateTime { get; set; }
    }

    public class ReturnUserAccessGroupAllModel
    {
        [Key]

        public string UUAG_UserAccessGroupID { get; set; }
        public string RC { get; set; }
    }


    public class UserAccessGroup : RequestBaseModel
    {
        public string UUAG_UserAccessGroupID { get; set; }


    }

    public class ReturnUserAccessGroupAllModelHead : ReturnResponse
    {
        public List<ReturnUserAccessGroupAllModel> UserAccessGroupall { get; set; }


    }

    public class UserAccessGroupSearchModel : RequestBaseModel
    {
        public string UUAG_UserAccessGroupID { get; set; }
    }

    public class ReturnUserAccessGroupSelectModel
    {
        public string UUAG_UserAccessGroupID { get; set; }

    }

    public class InactiveUUMAModel : RequestBaseModel
    {
        public string UUAG_UserAccessGroupID { get; set; }

    }
}
