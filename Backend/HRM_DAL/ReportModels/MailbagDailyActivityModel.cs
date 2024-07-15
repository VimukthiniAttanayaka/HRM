namespace HRM_DAL.ReportModels
{
    public class MailbagDailyActivityModel
    {
        public string CustomerName { get; set; }
        public string Date { get; set; }
        public string TripNo { get; set; }
        public string CollectionLocation { get; set; }
        public string ContractTime { get; set; }
        public string ActualTime { get; set; }
        public string Variance { get; set; }
        public string Collection_BagNo { get; set; }
        public string Collection_SealNo { get; set; }
        public string Collection_Exeption { get; set; }
        public string Delivery_BagNo { get; set; }
        public string Delivery_SealNo { get; set; }
        public string Delivery_Exeption { get; set; }
        public string TotalNoLocations { get; set; }
        public string TotalNoPlannedJobs { get; set; }
        public string NoJobsCompleted { get; set; }
        public string TotalNoLateDelivery { get; set; }
        public string TotalNoDeliveryOnTime { get; set; }

        public string Delayed { get; set; }
        public string MisDelivered { get; set; }
        public string Timeliness { get; set; }
        public string Result { get; set; }

        public string NoSealedBagsCollected { get; set; }
        public string NoUnOpenedBagsCollected { get; set; }
        public string NoEmptyBagsCollected { get; set; }
        public string TotalNoOfCollectedContainers { get; set; }
        public string TotalNoOfDeliveredContainers { get; set; }
        public string CollectedBy_Date { get; set; }
        public string CollectedBy_Time { get; set; }
        public string CollectedBy_CollectedBy { get; set; }
        public string CPCode { get; set; }
        public string LooseMail { get; set; }
    }
}
