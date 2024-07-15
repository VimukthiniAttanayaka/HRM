using System;
using System.Collections.Generic;

namespace HRM_DAL.Models
{
    public class MailTransactionHeader
    {
        public string transactionNo { get; set; }
        public string transactionType { get; set; }
        public string tripNo { get; set; }
        public DateTime transactionDateTime { get; set; }
        public DateTime serverSyncDateTime { get; set; }
        public string deviceNo { get; set; }
        public string deviceTypeId { get; set; }
        public string vendorId { get; set; }
        public string locationId { get; set; }
        public string customerID { get; set; }
        public string cpCode { get; set; }
        public string isNoBag { get; set; }
        public string userId { get; set; }
        public List<MailBag> mailBags { get; set; }
    }
    public class MailBag
    {
        // Table: tbl_MailTransactionDetail
        public string containerId { get; set; }
        public string sealId { get; set; }
        public string bagType { get; set; }
        public string action { get; set; }
    }
}
