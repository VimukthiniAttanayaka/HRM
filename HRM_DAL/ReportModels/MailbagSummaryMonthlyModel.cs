namespace HRM_DAL.ReportModels
{
    public class MailbagSummaryMonthlyModel
    {
        public string CustomerName { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string CostCentre { get; set; }
        public string BagType { get; set; }
        public string Date { get; set; }
        public int TotalNoScanningDelivery { get; set; }
        public int TotalNoLateDelivery { get; set; }
        public string MissedDelivery { get; set; }
        public string DeliveryAccuracy { get; set; }
        public string DeliveryTimeliness { get; set; }
        public string Location { get; set; }     

    }
    public class MailbagSummaryMonthlyModel_V1
    {
        public string CustomerName { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string Date { get; set; }
        public string Threshold { get; set; }
        public string LocationHeader { get; set; }

        public string CPCode { get; set; }
        public string PCCode { get; set; }
        public string Location { get; set; }
        public string Level { get; set; }
        public string LockerNumber { get; set; }
        public string Department { get; set; }
        public string TransDate { get; set; }
        public string Planned_Trip { get; set; }
        public string Number_OfTrips_Completed { get; set; }
        public string Actual_Bags_Scanned_Collection_Delivery_Kiosks { get; set; }
        public string Missed_Delivery_collection { get; set; }
        public string Delivery_collection_Accuracy { get; set; }
        public string Total_Delivery_Collection_Outside_Schedule { get; set; }
        public string Delivery_Timeliness { get; set; }

    }

    public class MailbagSummaryMonthly_ContractTime_Model
    {
        public string CPCode { get; set; }
        public string Trip { get; set; }
        public string Duration { get; set; }
    }
}
