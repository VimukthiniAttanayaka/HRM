
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class LeaveRequestModel : RequestBaseModel
    {
        public int LV_LeaveID { get; set; }
    }
    public class LeaveApproveSubmitModel : RequestBaseModel
    {
        public int LV_LeaveID { get; set; }
        public string LV_Approve { get; set; }
        public string LV_ApprovedBy { get; set; }
        public string LV_ApprovedDate { get; set; }
    }
    public class LeaveCancelSubmitModel : RequestBaseModel
    {
        public int LV_LeaveID { get; set; }
        public string LV_Reject { get; set; }
        public string LV_RejectBy { get; set; }
        public string LV_RejectDate { get; set; }
    }
    public class LeaveSubmitModel : RequestBaseModel
    {
        public int LV_LeaveID { get; set; }
        public DateTime LV_LeaveEndDate { get; set; }
        public DateTime LV_LeaveStartDate { get; set; }
        public string LV_StaffID { get; set; }
        public string LV_LeaveTypeID { get; set; }
        public string LV_Approve { get; set; }
        public string LV_ApprovedBy { get; set; }
        public string LV_ApprovedDate { get; set; }
        public string LV_Status { get; set; }
    }


    public class LeaveSubmitResponceModel : ReturnResponse
    {
        public LeaveResponceModel model { get; set; }
    }

    public class LeaveResponceModel 
    {
        public int LV_LeaveID { get; set; }
        public DateTime LV_LeaveEndDate { get; set; }
        public DateTime LV_LeaveStartDate { get; set; }
        public string LV_StaffID { get; set; }
        public string LV_LeaveTypeID { get; set; }
        public bool LV_Approve { get; set; }
        public string LV_ApprovedBy { get; set; }
        public DateTime LV_ApprovedDate { get; set; }
        public string LV_Status { get; set; }
    }

    public class LeaveHeaderResponceModel : ReturnResponse
    {
        public List<LeaveResponceModel> LeaveResponceModelList { get; set; } = new List<LeaveResponceModel>();

    }
    public class LeaveStatusHeaderResponceModel : ReturnResponse
    {

    }

    #region Grid Sction

    public class LeaveGridRequestModel : RequestGridBaseModel
    {

    }

    public class LeaveGridViewModel : ReturnResponseGridViewBaseModel
    {
        public int LV_LeaveID { get; set; }
        public DateTime LV_LeaveEndDate { get; set; }
        public DateTime LV_LeaveStartDate { get; set; }
        public string LV_StaffID { get; set; }
        public string LV_LeaveTypeID { get; set; }
        public bool LV_Approve { get; set; }
        public string LV_ApprovedBy { get; set; }
        public DateTime LV_ApprovedDate { get; set; }
        public string LV_Status { get; set; }
    }

    public class LeaveGridViewHeaderModel : ReturnResponse
    {
        public List<LeaveGridViewModel> LeaveGridViewModelList { get; set; } = new List<LeaveGridViewModel>();
    }

    #endregion Grid Sction
}
