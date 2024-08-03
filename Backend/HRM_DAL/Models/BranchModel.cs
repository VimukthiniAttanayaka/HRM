using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class ReturnBranchModelHead : ReturnResponse
    {
        public List<ReturnBranchModel> Branch { get; set; }
    }

    public class BranchModel : RequestBaseModel
    {
        public string MDB_BranchID { get; set; }
        public string MDB_Branch { get; set; }
        public bool MDB_Status { get; set; }
        //public string MDB_CreatedBy { get; set; }
        //public DateTime MDB_CreatedDateTime { get; set; }
        //public string MDB_ModifiedBy { get; set; }
        //public DateTime MDB_ModifiedDateTime { get; set; }
    }

    public class ReturnBranchModel
    {
        [Key]
        public string MDB_BranchID { get; set; }
        public string MDB_Branch { get; set; }
        public bool MDB_Status { get; set; }
        public string MDB_CreatedBy { get; set; }
        public DateTime MDB_CreatedDateTime { get; set; }
        public string MDB_ModifiedBy { get; set; }
        public DateTime MDB_ModifiedDateTime { get; set; }
    }
    public class ReturnBranchAllModel
    {
        [Key]

        public string MDB_BranchID { get; set; }
        public string RC { get; set; }
    }


    public class Branch : RequestBaseModel
    {
        public string MDB_BranchID { get; set; }


    }

    public class ReturnBranchAllModelHead : ReturnResponse
    {
        public List<ReturnBranchAllModel> Branchall { get; set; }


    }

    public class BranchSearchModel : RequestBaseModel
    {
        public string MDB_BranchID { get; set; }
    }

    public class ReturnBranchSelectModel
    {
        public string MDB_BranchID { get; set; }

    }

    public class InactiveMDBModel : RequestBaseModel
    {
        public string MDB_BranchID { get; set; }

    }
}
