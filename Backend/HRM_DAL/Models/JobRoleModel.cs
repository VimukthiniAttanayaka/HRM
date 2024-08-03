using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class ReturnJobRoleModelHead : ReturnResponse
    {
        public List<ReturnJobRoleModel> JobRole { get; set; }
    }

    public class JobRoleModel : RequestBaseModel
    {
        public string MDJR_JobRoleID { get; set; }
        public string MDJR_JobRole { get; set; }
        public bool MDJR_Status { get; set; }
        //public string MDJR_CreatedBy { get; set; }
        //public DateTime MDJR_CreatedDateTime { get; set; }
        //public string MDJR_ModifiedBy { get; set; }
        //public DateTime MDJR_ModifiedDateTime { get; set; }
    }

    public class ReturnJobRoleModel
    {
        [Key]
        public string MDJR_JobRoleID { get; set; }
        public string MDJR_JobRole { get; set; }
        public bool MDJR_Status { get; set; }
        public string MDJR_CreatedBy { get; set; }
        public DateTime MDJR_CreatedDateTime { get; set; }
        public string MDJR_ModifiedBy { get; set; }
        public DateTime MDJR_ModifiedDateTime { get; set; }
    }
    public class ReturnJobRoleAllModel
    {
        [Key]

        public string MDJR_JobRoleID { get; set; }
        public string RC { get; set; }
    }


    public class JobRole : RequestBaseModel
    {
        public string MDJR_JobRoleID { get; set; }


    }

    public class ReturnJobRoleAllModelHead : ReturnResponse
    {
        public List<ReturnJobRoleAllModel> JobRoleall { get; set; }


    }

    public class JobRoleSearchModel : RequestBaseModel
    {
        public string MDJR_JobRoleID { get; set; }
    }

    public class ReturnJobRoleSelectModel
    {
        public string MDJR_JobRoleID { get; set; }

    }

    public class InactiveMDJRModel : RequestBaseModel
    {
        public string MDJR_JobRoleID { get; set; }

    }
}
