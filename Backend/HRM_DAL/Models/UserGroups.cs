using System;

namespace HRM_DAL.Models
{
    public class UserGroups
    {
        public string groupId { get; set; }
        public string groupName { get; set; }
        public string activeStatus { get; set; }
        public DateTime createdDateTime { get; set; }
        public DateTime? lastModifiedDateTime { get; set; }
    }
}
