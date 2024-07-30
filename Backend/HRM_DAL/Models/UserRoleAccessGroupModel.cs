using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class ReturnUserRoleAccessGroupModelHead : ReturnResponse
    {
        public List<ReturnUserRoleAccessGroupModel> UserRoleAccessGroup { get; set; }
    }

    public class UserRoleAccessGroupModel : RequestBaseModel
    {
        public int UURAG_UserRoleAccessGroupID { get; set; }
        public string UURAG_AccessGroupID { get; set; }
        public string UURAG_UserRoleID { get; set; }
        public bool UURAG_Status { get; set; }
        public string UURAG_CreatedBy { get; set; }
        public DateTime UURAG_CreatedDateTime { get; set; }
        public string UURAG_ModifiedBy { get; set; }
        public DateTime UURAG_ModifiedDateTime { get; set; }
    }

    public class ReturnUserRoleAccessGroupModel
    {
        [Key]
        public int UURAG_UserRoleAccessGroupID { get; set; }
        public string UURAG_MenuAccessID { get; set; }
        public string UURAG_UserName { get; set; }
        public bool UURAG_Status { get; set; }
        public string UURAG_CreatedBy { get; set; }
        public DateTime UURAG_CreatedDateTime { get; set; }
        public string UURAG_ModifiedBy { get; set; }
        public DateTime UURAG_ModifiedDateTime { get; set; }
    }

    public class ReturnUserRoleAccessGroupAllModel
    {
        [Key]

        public string UURAG_UserRoleAccessGroupID { get; set; }
        public string RC { get; set; }
    }


    public class UserRoleAccessGroup : RequestBaseModel
    {
        public string UURAG_UserRoleAccessGroupID { get; set; }


    }

    public class ReturnUserRoleAccessGroupAllModelHead : ReturnResponse
    {
        public List<ReturnUserRoleAccessGroupAllModel> UserRoleAccessGroupall { get; set; }


    }

    public class UserRoleAccessGroupSearchModel : RequestBaseModel
    {
        public string UURAG_UserRoleAccessGroupID { get; set; }
    }

    public class ReturnUserRoleAccessGroupSelectModel
    {
        public string UURAG_UserRoleAccessGroupID { get; set; }

    }

    public class InactiveUUMAModel : RequestBaseModel
    {
        public string UURAG_UserRoleAccessGroupID { get; set; }

    }
}
