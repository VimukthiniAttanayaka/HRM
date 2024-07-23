using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class ReturnUserMenuAccessModelHead : ReturnResponse
    {
        public List<ReturnUserMenuAccessModel> UserMenuAccess { get; set; }
    }

    public class UserMenuAccessModel : RequestBaseModel
    {
        public int UUMA_UserMenuAccessID { get; set; }
        public string UUMA_MenuAccessID { get; set; }
        public string UUMA_AccessGroupID { get; set; }
        public bool UUMA_Status { get; set; }
        public string UUMA_CreatedBy { get; set; }
        public DateTime UUMA_CreatedDateTime { get; set; }
        public string UUMA_ModifiedBy { get; set; }
        public DateTime UUMA_ModifiedDateTime { get; set; }
    }

    public class ReturnUserMenuAccessModel
    {
        [Key]
        public int UUMA_UserMenuAccessID { get; set; }
        public string UUMA_MenuAccessID { get; set; }
        public string UUMA_AccessGroupID { get; set; }
        public bool UUMA_Status { get; set; }
        public string UUMA_CreatedBy { get; set; }
        public DateTime UUMA_CreatedDateTime { get; set; }
        public string UUMA_ModifiedBy { get; set; }
        public DateTime UUMA_ModifiedDateTime { get; set; }
    }

    public class ReturnUserMenuAccessAllModel
    {
        [Key]

        public string UUMA_UserMenuAccessID { get; set; }
        public string RC { get; set; }
    }


    public class UserMenuAccess : RequestBaseModel
    {
        public string UUMA_UserMenuAccessID { get; set; }


    }

    public class ReturnUserMenuAccessAllModelHead : ReturnResponse
    {
        public List<ReturnUserMenuAccessAllModel> UserMenuAccessall { get; set; }


    }

    public class UserMenuAccessSearchModel : RequestBaseModel
    {
        public string UUMA_UserMenuAccessID { get; set; }
    }

    public class ReturnUserMenuAccessSelectModel
    {
        public string UUMA_UserMenuAccessID { get; set; }

    }

    public class InactiveUUMAModel : RequestBaseModel
    {
        public string UUMA_UserMenuAccessID { get; set; }

    }
}
