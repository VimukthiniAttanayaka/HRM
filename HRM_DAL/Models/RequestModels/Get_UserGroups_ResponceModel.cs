using HRM_DAL.Models.ResponceModels;
using System;
using System.Collections.Generic;

namespace HRM_DAL.Models.RequestModels
{
    public class Get_UserGroups_ResponceModel : HRM_ReturnResponce
    {
        public List<UsergroupResult> result { get; set; }
    }

    public class UsergroupResult
    {
        public string VendorID { get; set; }
        public List<Usergroup> userGroups { get; set; }
    }

    public class Usergroup
    {
        public string groupId { get; set; }
        public string groupName { get; set; }
        public string activeStatus { get; set; }
        public DateTime? createDateTime { get; set; }
        public DateTime? lastModifiedDateTime { get; set; }
    }

}
