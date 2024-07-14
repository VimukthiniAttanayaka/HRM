using System;

namespace HRM_DAL.Models
{
    public class DeviceActivity
    {
        // table: tbl_DeviceActivity
        public string deviceNo { get; set; }
        public string deviceTypeId { get; set; }
        public string vendorId { get; set; }
        public string locationId { get; set; }
        public DateTime transactionDateTime { get; set; }
        public DateTime serverSyncDateTime { get; set; }
        public string userId { get; set; }
        public string activityType { get; set; }
        public string activityDescription { get; set; }
    }
}
