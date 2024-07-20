using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class ReturnLeaveEntitlementModelHead : ReturnResponse
    {
        public List<ReturnLeaveEntitlementModel> LeaveEntitlement { get; set; }
    }

    public class LeaveEntitlementModel : RequestBaseModel
    {
        public int LVE_LeaveEntitlementID { get; set; }
        public string LVE_EmployeeID { get; set; }
        public string LVE_LeaveTypeID { get; set; }

        public string LVE_LeaveType { get; set; }
        public int LVE_LeaveAlotment { get; set; }
        public bool LVE_Status { get; set; }
        public string LVE_CreatedBy { get; set; }
        public DateTime LVE_CreatedDateTime { get; set; }
        public string LVE_ModifiedBy { get; set; }
        public DateTime LVE_ModifiedDateTime { get; set; }
    }

    public class ReturnLeaveEntitlementModel
    {
        [Key]
        public int LVE_LeaveEntitlementID { get; set; }
        public string LVE_EmployeeID { get; set; }
        public string LVE_LeaveTypeID { get; set; }

        public string LVE_LeaveType { get; set; }
        public int LVE_LeaveAlotment { get; set; }
        public bool LVE_Status { get; set; }
        public string LVE_CreatedBy { get; set; }
        public DateTime LVE_CreatedDateTime { get; set; }
        public string LVE_ModifiedBy { get; set; }
        public DateTime LVE_ModifiedDateTime { get; set; }
    }

    public class ReturnLeaveEntitlementAllModel
    {
        [Key]

        public int LVE_LeaveEntitlementID { get; set; }
        public string RC { get; set; }
    }


    public class LeaveEntitlement : RequestBaseModel
    {
        public int LVE_LeaveEntitlementID { get; set; }


    }

    public class ReturnLeaveEntitlementAllModelHead : ReturnResponse
    {
        public List<ReturnLeaveEntitlementAllModel> LeaveEntitlementall { get; set; }


    }

    public class LeaveEntitlementSearchModel : RequestBaseModel
    {
        public int LVE_LeaveEntitlementID { get; set; }
    }

    public class ReturnLeaveEntitlementSelectModel
    {
        public int LVE_LeaveEntitlementID { get; set; }

    }

    public class InactiveLVEModel : RequestBaseModel
    {
        public int LVE_LeaveEntitlementID { get; set; }

    }
}
