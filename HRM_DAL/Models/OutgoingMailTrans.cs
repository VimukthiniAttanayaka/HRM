using System;

namespace HRM_DAL.Models
{
    public class OutgoingMailTrans
    {
        //Table: tbl_OutgoingMailTransactionDetail

        public string batchNo { get; set; }
        public DateTime? transactionDateTime { get; set; }
        public DateTime? serverSyncDateTime { get; set; }
        public string deviceNo { get; set; }
        public string deviceTypeId { get; set; }
        public string vendorId { get; set; }
        public string locationId { get; set; }
        public string customerId { get; set; }
        public string staffId { get; set; }
        public string pcCode { get; set; }
        public string mailTypeId { get; set; }
        public decimal? qty { get; set; } // don't know the table and column
        public DateTime? userLoginDateTime { get; set; }
    }
}
