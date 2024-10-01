using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class ReturnLeaveTypeModelHead : ReturnResponse
    {
        public List<ReturnLeaveTypeModel> LeaveType { get; set; }
    }

    public class LeaveTypeModel : RequestBaseModel
    {
        public string MDLT_LeaveTypeID { get; set; }
        public string MDLT_LeaveType { get; set; }
        public int MDLT_LeaveAlotment { get; set; }
        public bool MDLT_Status { get; set; }
        public string MDLT_CreatedBy { get; set; }
        public DateTime MDLT_CreatedDateTime { get; set; }
        public string MDLT_ModifiedBy { get; set; }
        public DateTime MDLT_ModifiedDateTime { get; set; }
        public string MDLT_Description { get;  set; }
        public int MDLT_Duration { get; set; }
    }

    public class ReturnLeaveTypeModel
    {
        [Key]
        public string MDLT_LeaveTypeID { get; set; }
        public string MDLT_LeaveType { get; set; }
        public int MDLT_LeaveAlotment { get; set; }
        public bool MDLT_Status { get; set; }
        public string MDLT_CreatedBy { get; set; }
        public DateTime MDLT_CreatedDateTime { get; set; }
        public string MDLT_ModifiedBy { get; set; }
        public DateTime MDLT_ModifiedDateTime { get; set; }
        public string MDLT_Description { get; set; }
        public short MDLT_Duration { get;  set; }
    }

    public class ReturnLeaveTypeAllModel
    {
        [Key]

        public string MDLT_LeaveTypeID { get; set; }
        public string RC { get; set; }
    }


    public class LeaveType : RequestBaseModel
    {
        public string MDLT_LeaveTypeID { get; set; }


    }

    public class ReturnLeaveTypeAllModelHead : ReturnResponse
    {
        public List<ReturnLeaveTypeAllModel> leavetypeall { get; set; }


    }

    public class LeaveTypeSearchModel : RequestBaseModel
    {
        public string MDLT_LeaveTypeID { get; set; }
    }

    public class ReturnLeaveTypeSelectModel
    {
        public string MDLT_LeaveTypeID { get; set; }

    }

    public class InactiveMDLTModel : RequestBaseModel
    {
        public string MDLT_LeaveTypeID { get; set; }

    }
}
