using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class ReturnUserMenuModelHead : ReturnResponse
    {
        public List<ReturnUserMenuModel> UserMenu { get; set; }
    }

    public class UserMenuModel : RequestBaseModel
    {
        public string EUM_UserMenuID { get; set; }
        public string EUM_UserMenu { get; set; }
        public bool EUM_Status { get; set; }
        public string EUM_CreatedBy { get; set; }
        public DateTime EUM_CreatedDateTime { get; set; }
        public string EUM_ModifiedBy { get; set; }
        public DateTime EUM_ModifiedDateTime { get; set; }
    }

    public class ReturnUserMenuModel
    {
        [Key]
        public string EUM_UserMenuID { get; set; }
        public string EUM_UserMenu { get; set; }
        public bool EUM_Status { get; set; }
        public string EUM_CreatedBy { get; set; }
        public DateTime EUM_CreatedDateTime { get; set; }
        public string EUM_ModifiedBy { get; set; }
        public DateTime EUM_ModifiedDateTime { get; set; }
    }

    public class ReturnUserMenuAllModel
    {
        [Key]

        public string EUM_UserMenuID { get; set; }
        public string RC { get; set; }
    }


    public class UserMenu : RequestBaseModel
    {
        public string EUM_UserMenuID { get; set; }


    }

    public class ReturnUserMenuAllModelHead : ReturnResponse
    {
        public List<ReturnUserMenuAllModel> UserMenuall { get; set; }


    }

    public class UserMenuSearchModel : RequestBaseModel
    {
        public string EUM_UserMenuID { get; set; }
    }

    public class ReturnUserMenuSelectModel
    {
        public string EUM_UserMenuID { get; set; }

    }

    public class InactiveEUMModel : RequestBaseModel
    {
        public string EUM_UserMenuID { get; set; }

    }
}
