using System;
using System.Collections.Generic;
using System.Text;

namespace HRM_DAL.Models
{
    public class ReturnAttendanceReportsModelHead : ReturnResponse
    {
        public List<AttendanceReportModel> Attendance { get; set; }
    }

    public class AttendanceReportModel
    {
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string Reason { get; set; }
        public string EndDate { get; set; }
        public decimal Total { get; set; }
        public string DateString { get; set; }
        public string AttendanceDate { get; set; }
        public string StartDate { get; set; }
    }

    public class ReturnBirthdayReportsModelHead : ReturnResponse
    {
        public List<BirthdayReportModel> Birthday { get; set; }
    }
    public class BirthdayReportModel
    {
        public string Action { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string ClientIP { get; set; }
        public string CreatedDateTime { get; set; }
        public string SequenceNo { get; set; }
        public string Module { get; set; }
        public string Controler { get; set; }
        public string ActionType { get; set; }
        public string ActionMap_ID { get; set; }
    }

    public class RequestAttendance : RequestBaseModel
    {
    }
    public class RequestBirthday : RequestBaseModel
    {
    }
}
