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
        public string LVT_LeaveTypeID { get; set; }
        public string LVT_LeaveType { get; set; }
        public int LVT_LeaveAlotment { get; set; }
        public bool LVT_Status { get; set; }
        public string LVT_CreatedBy { get; set; }
        public DateTime LVT_CreatedDateTime { get; set; }
        public string LVT_ModifiedBy { get; set; }
        public DateTime LVT_ModifiedDateTime { get; set; }
    }

    public class ReturnLeaveTypeModel
    {
        [Key]
        public string LVT_LeaveTypeID { get; set; }
        public string LVT_LeaveType { get; set; }
        public int LVT_LeaveAlotment { get; set; }
        public bool LVT_Status { get; set; }
        public string LVT_CreatedBy { get; set; }
        public DateTime LVT_CreatedDateTime { get; set; }
        public string LVT_ModifiedBy { get; set; }
        public DateTime LVT_ModifiedDateTime { get; set; }
    }

    public class ReturnLeaveTypeAllModel
    {
        [Key]

        public string LVT_LeaveTypeID { get; set; }
        public string RC { get; set; }
    }


    public class LeaveType : RequestBaseModel
    {
        public string LVT_LeaveTypeID { get; set; }


    }

    public class ReturnLeaveTypeAllModelHead : ReturnResponse
    {
        public List<ReturnLeaveTypeAllModel> leavetypeall { get; set; }


    }

    public class LeaveTypeSearchModel : RequestBaseModel
    {
        public string LVT_LeaveTypeID { get; set; }
    }

    public class ReturnLeaveTypeSelectModel
    {
        public string LVT_LeaveTypeID { get; set; }

    }

    public class InactiveLVTModel : RequestBaseModel
    {
        public string LVT_LeaveTypeID { get; set; }

    }
}
