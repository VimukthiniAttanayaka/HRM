
using System;
using System.Collections.Generic;

namespace HRM_DAL.Models
{
    public class ReportRequestBaseModel : RequestBaseModel
    {
        public string ExportMode { get; set; }
    }

    public class PrintContainerRequestModel : ReportRequestBaseModel
    {
        public List<string> CN_IDList { get; set; }
        public string LabelType { get; set; }
        public string UserID { get; set; }
        public int PrintCountPerLabel { get; set; }

    }
    public class PrintContainerQRModel
    {
        public string CN_ID { get; set; }

    }

    public class PortalExpensesRequestModel : ReportRequestBaseModel
    {
        public string CustomerID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

    }
    public class CourierExpensesRequestModel : ReportRequestBaseModel
    {
        public string CustomerID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

    }
    public class OutgoingMailExpensesRequestModel : ReportRequestBaseModel
    {
        public string CustomerID { get; set; }
        public string PCCode { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

    }

    public class KioskActivityRequestModel : ReportRequestBaseModel
    {
        public string CustomerID { get; set; }
        public string KioskNo { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

    }

    public class MailbagSummaryMonthlyRequestModel : ReportRequestBaseModel
    {
        public string CustomerID { get; set; }
        public int Threshold { get; set; }
        public string CPCode { get; set; }
        public string CostCentreID { get; set; }
        public string Location { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

    }

    public class MailbagDailyActivityRequestModel : ReportRequestBaseModel
    {
        public string CustomerID { get; set; }
        public DateTime Date { get; set; }

    }
    public class MailbagDailyActivityRequestModel_V1 : ReportRequestBaseModel
    {
        public string CustomerID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

    }
}