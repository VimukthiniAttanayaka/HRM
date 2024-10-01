using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRM_DAL.Models
{
    public class ReturnEmployeeLeaveEntitlementModelHead : ReturnResponse
    {
        public List<ReturnEmployeeLeaveEntitlementModel> EmployeeLeaveEntitlement { get; set; }
    }

    public class EmployeeLeaveEntitlementModel : RequestBaseModel
    {
        public int EELE_ID { get; set; }
        public string EELE_EmployeeID { get; set; }
        public string EELE_LeaveTypeID { get; set; }
        public string EELE_LeaveType { get; set; }
        public decimal EELE_LeaveAlotment { get; set; }
        public bool EELE_Status { get; set; }
        public string EELE_CreatedBy { get; set; }
        public DateTime EELE_CreatedDateTime { get; set; }
        public string EELE_ModifiedBy { get; set; }
        public DateTime EELE_ModifiedDateTime { get; set; }
        public DateTime EELE_ActiveFrom { get; set; }
        public DateTime EELE_ActiveTo { get; set; }
        public decimal EELE_Remain { get; set; }
    }

    public class ReturnEmployeeLeaveEntitlementModel
    {
        [Key]
        public int EELE_ID { get; set; }
        public string EELE_EmployeeID { get; set; }
        public string EELE_LeaveTypeID { get; set; }
        public string EELE_LeaveType { get; set; }
        public decimal EELE_LeaveAlotment { get; set; }
        public bool EELE_Status { get; set; }
        public string EELE_CreatedBy { get; set; }
        public DateTime EELE_CreatedDateTime { get; set; }
        public string EELE_ModifiedBy { get; set; }
        public DateTime EELE_ModifiedDateTime { get; set; }
        public DateTime EELE_ActiveFrom { get; set; }
        public DateTime EELE_ActiveTo { get; set; }
        public decimal EELE_Remain { get; set; }
    }

    public class ReturnEmployeeLeaveEntitlementAllModel
    {
        [Key]

        public int EELE_ID { get; set; }
        public string RC { get; set; }
    }


    public class EmployeeLeaveEntitlement : RequestBaseModel
    {
        public int EELE_ID { get; set; }


    }

    public class ReturnEmployeeLeaveEntitlementAllModelHead : ReturnResponse
    {
        public List<ReturnEmployeeLeaveEntitlementAllModel> EmployeeLeaveEntitlement { get; set; }


    }

    public class EmployeeLeaveEntitlementSearchModel : RequestBaseModel
    {
        public int EELE_ID { get; set; }
        public string EELE_EmployeeID { get; set; }
}

    public class ReturnEmployeeLeaveEntitlementSelectModel
    {
        public int EELE_ID { get; set; }

    }

    public class InactiveEELEModel : RequestBaseModel
    {
        public int EELE_ID { get; set; }

    }
}
