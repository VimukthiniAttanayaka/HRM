using System.Collections.Generic;

namespace HRM_DAL.Models
{
    public class OutgoingMailResult
    {
        public List<OutgoingMailTrans> outgoingMailTrans { get; set; }
        public string reqTransReferenceId { get; set; }
    }
}
