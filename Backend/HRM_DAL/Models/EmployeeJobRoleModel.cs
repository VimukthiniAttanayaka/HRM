using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{

    public class EmployeeJobRoleModel : RequestBaseModel
    {
        public int EEJR_ID { get; set; }
        public string EEJR_EmployeeID { get; set; }
        public string EEJR_JobRoleID { get; set; }
        public string EEJR_Remarks { get; set; }
        public DateTime EEJR_ActiveFrom { get; set; }
        public DateTime EEJR_ActiveTo { get; set; }
        public bool EEJR_Status { get; set; }
        public string EEJR_CreatedBy { get; set; }
        public DateTime EEJR_CreatedDateTime { get; set; }
        public string EEJR_ModifiedBy { get; set; }
        public DateTime EEJR_ModifiedDateTime { get; set; }
    }

    public class ReturnEmployeeJobRoleModel
    {
        [Key]

        public int EEJR_ID { get; set; }
        public string EEJR_EmployeeID { get; set; }
        public string EEJR_JobRoleID { get; set; }
        public string EEJR_Remarks { get; set; }
        public DateTime EEJR_ActiveFrom { get; set; }
        public DateTime EEJR_ActiveTo { get; set; }
        public bool EEJR_Status { get; set; }
        public string EEJR_CreatedBy { get; set; }
        public DateTime EEJR_CreatedDateTime { get; set; }
        public string EEJR_ModifiedBy { get; set; }
        public DateTime EEJR_ModifiedDateTime { get; set; }

    }


    public class EmployeeJobRole : RequestBaseModel
    {
        public int EEJR_ID { get; set; }


    }
    public class ReturnEmployeeJobRoleModelHead : ReturnResponse
    {
        public List<ReturnEmployeeJobRoleModel> EmployeeJobRole { get; set; }


    }
    public class ReturnEmployeeJobRoleAllModelHead : ReturnResponse
    {
        public List<ReturnEmployeeJobRoleModel> EmployeeJobRole { get; set; }
    }

    public class EmployeeJobRoleSearchModel : RequestBaseModel
    {
        public int EEJR_ID { get; set; }
    }

    public class InactiveEEJRModel : RequestBaseModel
    {
        public int EEJR_ID { get; set; }
    }

    public class ReturnEmployeeJobRoleSelectModel
    {
        public int EEJR_JobDescriptionID { get; set; }

    }
}
