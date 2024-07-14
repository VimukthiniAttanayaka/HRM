using System.Collections.Generic;

namespace HRM_DAL.Models
{
    public class MailBagTransResult
    {
        public List<MailTransactionHeader> mailBagTrans { get; set; }
        public string reqTransReferenceId { get; set; }
    }
}
