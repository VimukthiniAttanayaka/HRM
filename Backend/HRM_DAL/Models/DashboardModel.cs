
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class DashboardRequestModel : RequestBaseModel
    {
        public string User_ID { get; set; }
    }

    public class DashboardAlertResponseModel : ReturnResponse
    {
        public List<AlertDisplayModel> List { get; set; } = new List<AlertDisplayModel>();

    }
    public class AlertDisplayModel
    {
        public string DisplayName { get; set; }
        public int Value { get; set; }
    }

    public class ProgressGraphReturnResponseModel : ReturnResponse
    {
        public List<ProgressGraphModel> List { get; set; } = new List<ProgressGraphModel>();

    }
    public class ProgressFlatModel
    {
        public decimal Percentage { get; set; }
        public int Value { get; set; }
    }
    public class ProgressGraphModel
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public string MonthText { get; set; }
        public int Value { get; set; }
    }
    public class AnalysisDisplayModel
    {
        public string DisplayName { get; set; }
        public decimal Value { get; set; }
    }

    public class DeviceAnalysisReturnResponseModel : ReturnResponse
    {
        public Dictionary<string, double> List { get; set; } = new Dictionary<string, double>();
    }

    public class OutgoingMailYettoReceiveReturnResponseModel : ReturnResponse
    {
        public List<ProgressFlatModel> List { get; set; } = new List<ProgressFlatModel>();

    }

    public class ReturnMailPendingCustomerConfirmationReturnResponseModel : ReturnResponse
    {
        public List<ProgressFlatModel> List { get; set; } = new List<ProgressFlatModel>();

    }

    public class OutgoingMailYetToProcessReturnResponseModel : ReturnResponse
    {
        public List<ProgressFlatModel> List { get; set; } = new List<ProgressFlatModel>();

    }

    public class MailDiscrepancyPendingCustomerResponseReturnResponseModel : ReturnResponse
    {
        public List<ProgressFlatModel> List { get; set; } = new List<ProgressFlatModel>();

    }
}
