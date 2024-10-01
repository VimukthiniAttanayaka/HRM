
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class AttendancePunch_MarkerSubmitModel : RequestBaseModel
    {
        public DateTime EAT_AttendanceDate { get; set; }
        public decimal EAT_Location_latitude { get; set; }
        public decimal EAT_Location_longitude { get; set; }
        public string EAT_EmployeeID { get; set; }
    }
    public class AttendancePunch_MobileSubmitModel : RequestBaseModel
    {
        public DateTime EAT_AttendanceDate { get; set; }
        public decimal EAT_Location_latitude { get; set; }
        public decimal EAT_Location_longitude { get; set; }
        public string EAT_EmployeeID { get; set; }
    }
    public class AttendanceGridSubmitModel : RequestBaseModel
    {
        public int EAT_ID { get; set; }
        public string EAT_EmployeeID { get; set; }
        public TimeSpan EAT_InTime { get; set; }
        public TimeSpan EAT_OutTime { get; set; }
        public string EAT_Reason { get; set; }
        public decimal EAT_Total { get; set; }
        public DateTime EAT_AttendanceDate { get; set; }
        public bool EAT_Status { get; set; }
        public string EAT_CreatedBy { get; set; }
        public DateTime EAT_CreatedDateTime { get; set; }
        public string EAT_ModifiedBy { get; set; }
        public DateTime EAT_ModifiedDateTime { get; set; }
        public string EAT_Remarks { get; set; }
        public string EAT_ApprovedBy { get; set; }
        public string EAT_RejectedBy { get; set; }
        public DateTime EAT_ApprovedDateTime { get; set; }
        public string EAT_ApprovedReason { get; set; }
        public DateTime EAT_RejectedDateTime { get; set; }
        public string EAT_RejectedReason { get; set; }
        public string EAT_Location_latitude { get; set; }
        public string EAT_Location_longitude { get; set; }

    }
    public class AttendanceRequestModel : RequestBaseModel
    {
        public int EAT_ID { get; set; }
    }
    public class AttendanceSubmitResponceModel : ReturnResponse
    {
        public List<AttendanceGridViewModel> Attendance { get; set; } = new List<AttendanceGridViewModel>();
    }

    #region Grid Sction

    public class AttendanceGridRequestModel : RequestGridBaseModel
    {
        public string EAT_EmployeeID { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
    }

    public class AttendanceGridViewHeaderModel : ReturnResponse
    {
        public List<AttendanceGridViewModel> Attendance { get; set; } = new List<AttendanceGridViewModel>();
    }

    public class AttendanceGridViewModel : ReturnResponseGridViewBaseModel
    {
        public int EAT_ID { get; set; }
        public string EAT_EmployeeID { get; set; }
        public TimeSpan EAT_InTime { get; set; }
        public TimeSpan EAT_OutTime { get; set; }
        public string EAT_Reason { get; set; }
        public decimal EAT_Total { get; set; }
        public DateTime EAT_AttendanceDate { get; set; }
        public bool EAT_Status { get; set; }
        public string EAT_CreatedBy { get; set; }
        public DateTime EAT_CreatedDateTime { get; set; }
        public string EAT_ModifiedBy { get; set; }
        public DateTime EAT_ModifiedDateTime { get; set; }
        public string EAT_Remarks { get; set; }
        public string EAT_ApprovedBy { get; set; }
        public string EAT_RejectedBy { get; set; }
        public DateTime EAT_ApprovedDateTime { get; set; }
        public string EAT_ApprovedReason { get; set; }
        public DateTime EAT_RejectedDateTime { get; set; }
        public string EAT_RejectedReason { get; set; }
        public string SN { get; set; }
        public TimeSpan EAT_Total_TimeSpan { get; internal set; }
        public string EAT_Location_latitude { get; set; }
        public string EAT_Location_longitude { get; set; }
    }
    #endregion Grid Sction
}
