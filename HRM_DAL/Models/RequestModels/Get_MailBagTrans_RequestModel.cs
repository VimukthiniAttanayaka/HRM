using System;
using System.Collections.Generic;
using System.Text;

namespace HRM_DAL.Models.RequestModels
{
    public class Get_MailBagTrans_RequestModel
    {
        public int maxTransCount { get; set; }
        public string userId { get; set; }
    }
}
