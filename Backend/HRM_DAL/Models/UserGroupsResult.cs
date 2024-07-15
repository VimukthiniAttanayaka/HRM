using System.Collections.Generic;

namespace HRM_DAL.Models
{
    public class UserGroupsResult
    {
        public string vendorId { get; set; }
        public List<UserGroups> userGroups { get; set; }
    }
}
