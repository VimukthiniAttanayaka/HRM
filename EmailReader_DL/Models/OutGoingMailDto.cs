﻿using Kioski_APIChecker_DL;

namespace MailTrak_DAL.Models
{
    public class OutGoingMailDto : ReturnResponse
    {
        public int messageId { get; set; }
        public string message { get; set; }
        public MailBagTransResult result { get; set; }
    }
}
