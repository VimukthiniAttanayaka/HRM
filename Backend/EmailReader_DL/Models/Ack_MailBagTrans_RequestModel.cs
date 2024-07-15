using System;
using System.Collections.Generic;
using System.Text;

namespace MailTrak_DAL.Models.RequestModels
{
    public class Ack_MailBagTrans_RequestModel
    {
        public string reqTransReferenceId { get; set; }
        public string reqTransType { get; set; }
        public int syncStatus { get; set; }
        public int maxTransCount { get; set; }
    }
}
