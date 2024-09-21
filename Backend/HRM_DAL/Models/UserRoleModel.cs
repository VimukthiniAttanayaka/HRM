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
        public string UUR_UserRoleID { get; set; }
        public string UUR_UserRole { get; set; }
        public bool UUR_Status { get; set; }
        public string UUR_CreatedBy { get; set; }
        public DateTime UUR_CreatedDateTime { get; set; }
        public string UUR_ModifiedBy { get; set; }
        public DateTime UUR_ModifiedDateTime { get; set; }
    }

    public class ReturnUserRoleModel
    {
        [Key]
        public string UUR_UserRoleID { get; set; }
        public string UUR_UserRole { get; set; }
        public bool UUR_Status { get; set; }
        public string UUR_CreatedBy { get; set; }
        public DateTime UUR_CreatedDateTime { get; set; }
        public string UUR_ModifiedBy { get; set; }
        public DateTime UUR_ModifiedDateTime { get; set; }
        public List<AccessGroupSelect> AccessGroups { get; set; }
    }
    public class AccessGroupSelect
    {
        public string value { get; set; }
        public string label { get; set; }
        public bool Ischecked { get; set; }
    }

    public class ReturnUserRoleAllModel
    {
        [Key]

        public string UUR_UserRoleID { get; set; }
        public string RC { get; set; }
    }


    public class UserRole : RequestBaseModel
    {
        public string UUR_UserRoleID { get; set; }


    }

    public class ReturnUserRoleAllModelHead : ReturnResponse
    {
        public List<ReturnUserRoleAllModel> UserRoleall { get; set; }


    }

    public class UserRoleSearchModel : RequestBaseModel
    {
        public string UUR_UserRoleID { get; set; }
    }

    public class ReturnUserRoleSelectModel
    {
        public string UUR_UserRoleID { get; set; }

    }

    public class InactiveUURModel : RequestBaseModel
    {
        public string UUR_UserRoleID { get; set; }

    }


    public class GrantRemoveAccessModel : RequestBaseModel
    {
        public string UURAG_AccessGroupID { get; set; }
        public string UURAG_UserRoleID { get; set; }

    }
}
