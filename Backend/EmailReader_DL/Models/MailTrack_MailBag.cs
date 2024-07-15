using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTrak_DAL.Models.ResponceModels
{
    public partial class MailTrack_MailBag
    {
        public class Rootobject : MailTrack_ReturnResponce
        {
            public Result result { get; set; }
        }
        public class Result
        {
            public List<MailTransactionHeader> mailBagTrans { get; set; }
            public string reqTransReferenceId { get; set; }
        }

        //public class Mailbagtran
        //{
        //    public string transactionNo { get; set; }
        //    public string transactionType { get; set; }
        //    public int tripNo { get; set; }
        //    public DateTime transactionDateTime { get; set; }
        //    public DateTime serverSyncDateTime { get; set; }
        //    public string deviceNo { get; set; }
        //    public string deviceTypeId { get; set; }
        //    public string vendorId { get; set; }
        //    public string locationId { get; set; }
        //    public string customerId { get; set; }
        //    public string cpCode { get; set; }
        //    public int isNoBag { get; set; }
        //    public string userId { get; set; }
        //    public List<Mailbag> mailBags { get; set; }
        //}

        //public class Mailbag
        //{
        //    public string containerId { get; set; }
        //    public string sealId { get; set; }
        //    public string bagType { get; set; }
        //    public string action { get; set; }
        //}

    }

}
