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
        public string UUM_UserMenuID { get; set; }
        public string UUM_UserMenu { get; set; }
        public bool UUM_Status { get; set; }
        public string UUM_CreatedBy { get; set; }
        public DateTime UUM_CreatedDateTime { get; set; }
        public string UUM_ModifiedBy { get; set; }
        public DateTime UUM_ModifiedDateTime { get; set; }
    }

    public class ReturnUserMenuModel
    {
        [Key]
        public string UUM_UserMenuID { get; set; }
        public string UUM_UserMenu { get; set; }
        public bool UUM_Status { get; set; }
        public string UUM_CreatedBy { get; set; }
        public DateTime UUM_CreatedDateTime { get; set; }
        public string UUM_ModifiedBy { get; set; }
        public DateTime UUM_ModifiedDateTime { get; set; }
    }

    public class ReturnUserMenuAllModel
    {
        [Key]

        public string UUM_UserMenuID { get; set; }
        public string RC { get; set; }
    }


    public class UserMenu : RequestBaseModel
    {
        public string UUM_UserMenuID { get; set; }


    }

    public class ReturnUserMenuAllModelHead : ReturnResponse
    {
        public List<ReturnUserMenuAllModel> UserMenuall { get; set; }


    }

    public class UserMenuSearchModel : RequestBaseModel
    {
        public string UUM_UserMenuID { get; set; }
    }

    public class ReturnUserMenuSelectModel
    {
        public string UUM_UserMenuID { get; set; }

    }

    public class InactiveUUMModel : RequestBaseModel
    {
        public string UUM_UserMenuID { get; set; }

    }
}
