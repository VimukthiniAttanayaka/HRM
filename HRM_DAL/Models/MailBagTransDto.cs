﻿namespace HRM_DAL.Models
{
    public class MailBagTransDto : ReturnResponse
    {
        public int messageId { get; set; }
        public string message { get; set; }
        public MailBagTransResult result { get; set; }
    }
}
