using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{

    public class EmployeeTerminationModel : RequestBaseModel
    {
        public int EET_ID { get; set; }
        public string EET_EmployeeID { get; set; }
        public string EET_Remarks { get; set; }
        public bool EET_IsForceTerminated { get; set; }
        public bool EET_IsBlackListed { get; set; }
        public bool EET_Status { get; set; }
        public string EET_CreatedBy { get; set; }
        public DateTime EET_CreatedDateTime { get; set; }
        public string EET_ModifiedBy { get; set; }
        public DateTime EET_ModifiedDateTime { get; set; }
    }

    public class ReturnEmployeeTerminationModel
    {
        [Key]

        public int EET_ID { get; set; }
        public string EET_EmployeeID { get; set; }
        public string EET_Remarks { get; set; }
        public bool EET_IsForceTerminated { get; set; }
        public bool EET_IsBlackListed { get; set; }
        public bool EET_Status { get; set; }
        public string EET_CreatedBy { get; set; }
        public DateTime EET_CreatedDateTime { get; set; }
        public string EET_ModifiedBy { get; set; }
        public DateTime EET_ModifiedDateTime { get; set; }

    }


    public class EmployeeTermination : RequestBaseModel
    {
        public int EET_ID { get; set; }


    }
    public class ReturnEmployeeTerminationModelHead : ReturnResponse
    {
        public List<ReturnEmployeeTerminationModel> EmployeeTermination { get; set; }


    }
    public class ReturnEmployeeTerminationAllModelHead : ReturnResponse
    {
        public List<ReturnEmployeeTerminationModel> EmployeeTermination { get; set; }
    }

    public class EmployeeTerminationSearchModel : RequestBaseModel
    {
        public string EET_EmployeeID { get; set; }
    }

    public class InactiveEETModel : RequestBaseModel
    {
        public int EET_ID { get; set; }
    }
}
