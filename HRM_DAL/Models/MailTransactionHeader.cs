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
        public int isNoBag { get; set; }
        public int isLooseMail { get; set; }
        public string userId { get; set; }
        public DateTime? userLoginDateTime { get; set; }
        public List<MailBag> mailBags { get; set; }
    }
}
