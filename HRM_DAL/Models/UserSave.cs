using System;
using System.Collections.Generic;

namespace HRM_DAL.Models
{
    public class UserSave
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string userId { get; set; }
        public string pwd { get; set; }
        public string pwdSalt { get; set; }
        public string pcCode { get; set; }
        public string mailBagCPCode { get; set; }
        public string outgoingMailCPCode { get; set; }
        public string outgoingMailLocationId { get; set; }
        public string userType { get; set; }
        public List<UserGroupsSave> userGroups { get; set; }
        public string activeStatus { get; set; }
        public DateTime? createdDateTime { get; set; }
        public DateTime? lastModifiedDateTime { get; set; }
    }
}
