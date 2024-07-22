using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class ReturnUserRoleModelHead : ReturnResponse
    {
        public List<ReturnUserRoleModel> UserRole { get; set; }
    }

    public class UserRoleModel : RequestBaseModel
    {
        public string EUR_UserRoleID { get; set; }
        public string EUR_UserRole { get; set; }
        public bool EUR_Status { get; set; }
        public string EUR_CreatedBy { get; set; }
        public DateTime EUR_CreatedDateTime { get; set; }
        public string EUR_ModifiedBy { get; set; }
        public DateTime EUR_ModifiedDateTime { get; set; }
    }

    public class ReturnUserRoleModel
    {
        [Key]
        public string EUR_UserRoleID { get; set; }
        public string EUR_UserRole { get; set; }
        public bool EUR_Status { get; set; }
        public string EUR_CreatedBy { get; set; }
        public DateTime EUR_CreatedDateTime { get; set; }
        public string EUR_ModifiedBy { get; set; }
        public DateTime EUR_ModifiedDateTime { get; set; }
    }

    public class ReturnUserRoleAllModel
    {
        [Key]

        public string EUR_UserRoleID { get; set; }
        public string RC { get; set; }
    }


    public class UserRole : RequestBaseModel
    {
        public string EUR_UserRoleID { get; set; }


    }

    public class ReturnUserRoleAllModelHead : ReturnResponse
    {
        public List<ReturnUserRoleAllModel> UserRoleall { get; set; }


    }

    public class UserRoleSearchModel : RequestBaseModel
    {
        public string EUR_UserRoleID { get; set; }
    }

    public class ReturnUserRoleSelectModel
    {
        public string EUR_UserRoleID { get; set; }

    }

    public class InactiveEURModel : RequestBaseModel
    {
        public string EUR_UserRoleID { get; set; }

    }
}
