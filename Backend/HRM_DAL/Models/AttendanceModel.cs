
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class AttendancePunch_MarkerSubmitModel : RequestBaseModel
    {
        public DateTime AttendanceDate { get; set; }
        public string Location { get; set; }
    }
    public class AttendancePunch_MobileSubmitModel : RequestBaseModel
    {
        public DateTime AttendanceDate { get; set; }
        public string Location { get; set; }
    }
    public class AttendanceGridSubmitModel : RequestBaseModel
    {
        public TimeSpan InTime { get; set; }
        public TimeSpan OutTime { get; set; }
        public string Reason { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Total { get; set; }
        public DateTime AttendanceDate { get; set; }
        public DateTime StartDate { get; set; }
    }
    public class AttendanceRequestModel : RequestBaseModel
    {
        public DateTime AttendanceDate { get; set; }
    }
    public class AttendanceSubmitResponceModel : ReturnResponse
    {
        public List<AttendanceGridViewModel> AttendanceGridViewModelList { get; set; } = new List<AttendanceGridViewModel>();
    }

    #region Grid Sction

    public class AttendanceGridRequestModel : RequestGridBaseModel
    {
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
    }

    public class AttendanceGridViewHeaderModel : ReturnResponse
    {
        public List<AttendanceGridViewModel> AttendanceGridViewModelList { get; set; } = new List<AttendanceGridViewModel>();
    }

    public class AttendanceGridViewModel : ReturnResponseGridViewBaseModel
    {
        public TimeSpan InTime { get; set; }
        public TimeSpan OutTime { get; set; }
        public string Reason { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Total { get; set; }
        public string DateString { get; set; }
        public DateTime AttendanceDate { get; set; }
        public DateTime StartDate { get; set; }
        public string SN { get; set; }
    }
    #endregion Grid Sction
}
