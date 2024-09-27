using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class ReturnSalaryTypeModelHead : ReturnResponseGridViewBaseModel
    {
        public List<ReturnSalaryTypeModel> SalaryType { get; set; }
    }

    public class ReturnSalaryTypeModel : RequestBaseModel
    {
        public string MDST_SalaryTypeID { get; set; }
        public string MDST_SalaryType { get; set; }
        public bool MDST_Status { get; set; }
        public string MDST_Description { get; set; }
        //public string MDST_CreatedBy { get; set; }
        //public DateTime MDST_CreatedDateTime { get; set; }
        //public string MDST_ModifiedBy { get; set; }
        //public DateTime MDST_ModifiedDateTime { get; set; }
    }

    public class SalaryTypeModel : RequestBaseModel
    {
        [Key]
        public string MDST_SalaryTypeID { get; set; }
        public string MDST_SalaryType { get; set; }
        public bool MDST_Status { get; set; }
        public string MDST_CreatedBy { get; set; }
        public DateTime MDST_CreatedDateTime { get; set; }
        public string MDST_ModifiedBy { get; set; }
        public DateTime MDST_ModifiedDateTime { get; set; }
        public string MDST_Description { get; set; }
    }
    public class ReturnSalaryTypeAllModel
    {
        [Key]

        public string MDST_SalaryTypeID { get; set; }
        public string RC { get; set; }
    }


    public class SalaryType : RequestBaseModel
    {
        public string MDST_SalaryTypeID { get; set; }


    }

    public class ReturnSalaryTypeAllModelHead : ReturnResponse
    {
        public List<ReturnSalaryTypeAllModel> SalaryTypeall { get; set; }


    }

    public class SalaryTypeSearchModel : RequestGridBaseModel
    {
        public string MDST_SalaryTypeID { get; set; }
    }

    public class ReturnSalaryTypeSelectModel
    {
        public string MDST_SalaryTypeID { get; set; }

    }

    public class InactiveMDSTModel : RequestBaseModel
    {
        public string MDST_SalaryTypeID { get; set; }

    }
}
