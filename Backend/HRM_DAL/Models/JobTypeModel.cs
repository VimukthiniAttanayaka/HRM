using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class ReturnJobTypeModelHead : ReturnResponseGridViewBaseModel
    {
        public List<ReturnJobTypeModel> JobType { get; set; }
    }

    public class ReturnJobTypeModel : RequestBaseModel
    {
        public string MDJT_JobTypeID { get; set; }
        public string MDJT_JobType { get; set; }
        public bool MDJT_Status { get; set; }
        public string MDJT_Description { get; set; }
        //public string MDJT_CreatedBy { get; set; }
        //public DateTime MDJT_CreatedDateTime { get; set; }
        //public string MDJT_ModifiedBy { get; set; }
        //public DateTime MDJT_ModifiedDateTime { get; set; }
    }

    public class JobTypeModel : RequestBaseModel
    {
        [Key]
        public string MDJT_JobTypeID { get; set; }
        public string MDJT_JobType { get; set; }
        public bool MDJT_Status { get; set; }
        public string MDJT_CreatedBy { get; set; }
        public DateTime MDJT_CreatedDateTime { get; set; }
        public string MDJT_ModifiedBy { get; set; }
        public DateTime MDJT_ModifiedDateTime { get; set; }
        public string MDJT_Description { get; set; }
    }
    public class ReturnJobTypeAllModel
    {
        [Key]

        public string MDJT_JobTypeID { get; set; }
        public string RC { get; set; }
    }


    public class JobType : RequestBaseModel
    {
        public string MDJT_JobTypeID { get; set; }


    }

    public class ReturnJobTypeAllModelHead : ReturnResponse
    {
        public List<ReturnJobTypeAllModel> JobTypeall { get; set; }


    }

    public class JobTypeSearchModel : RequestGridBaseModel
    {
        public string MDJT_JobTypeID { get; set; }
    }

    public class ReturnJobTypeSelectModel
    {
        public string MDJT_JobTypeID { get; set; }

    }

    public class InactiveMDJTModel : RequestBaseModel
    {
        public string MDJT_JobTypeID { get; set; }

    }
}
