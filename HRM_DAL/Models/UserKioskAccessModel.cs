
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class UserKioskAccessModel
    {
        public string Mailbag_Location_ID { get; set; }
        public string Mailbag_CP_No { get; set; }
        public string Outgoing_Location_ID { get; set; }
        public string Outgoing_Kiosk_ID { get; set; }
    }
}
