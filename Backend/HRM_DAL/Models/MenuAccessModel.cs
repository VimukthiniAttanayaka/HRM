using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class ReturnMenuAccessModelHead : ReturnResponse
    {
        public List<ReturnMenuAccessModel> MenuAccessGroup { get; set; }
    }

    public class MenuAccessModel : RequestBaseModel
    {
        public int UMA_MenuAccessID { get; set; }
        public string UMA_UserMenuID { get; set; }
        public string UMA_AccessGroupID { get; set; }
        public bool UMA_Status { get; set; }
        public string UMA_CreatedBy { get; set; }
        public DateTime UMA_CreatedDateTime { get; set; }
        public string UMA_ModifiedBy { get; set; }
        public DateTime UMA_ModifiedDateTime { get; set; }
        public string UAG_AccessGroup { get; set; }
        public string UUM_UserMenu { get; set; }
    }

    public class ReturnMenuAccessModel
    {
        [Key]
        public int UMA_MenuAccessID { get; set; }
        public string UMA_UserMenuID { get; set; }
        public string UMA_AccessGroupID { get; set; }
        public bool UMA_Status { get; set; }
        public string UMA_CreatedBy { get; set; }
        public DateTime UMA_CreatedDateTime { get; set; }
        public string UMA_ModifiedBy { get; set; }
        public DateTime UMA_ModifiedDateTime { get; set; }
    }

    public class ReturnMenuAccessAllModel
    {
        [Key]

        public string UMA_MenuAccessID { get; set; }
        public string RC { get; set; }
    }


    public class MenuAccess : RequestBaseModel
    {
        public string UMA_MenuAccessID { get; set; }


    }

    public class ReturnMenuAccessAllModelHead : ReturnResponse
    {
        public List<ReturnMenuAccessAllModel> MenuAccessall { get; set; }


    }

    public class MenuAccessSearchModel : RequestBaseModel
    {
        public string UMA_MenuAccessID { get; set; }
    }

    public class ReturnMenuAccessSelectModel
    {
        public string UMA_MenuAccessID { get; set; }

    }

    public class InactiveUMAModel : RequestBaseModel
    {
        public string UMA_MenuAccessID { get; set; }

    }
}
