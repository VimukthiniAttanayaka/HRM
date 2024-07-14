using System;
using System.Collections.Generic;

namespace HRM_DAL.Models.RequestModels
{
    public class SetUser_RequestModel
    {
        public int isCompleteList { get; set; }
        public List<User_RequestModel> users { get; set; }
    }
    public class User_RequestModel
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
        public List<Usergroup_RequestModel> userGroups { get; set; }
        public List<MailBagCPCodes_RequestModel> mailBagCPCodes { get; set; }

        public string activeStatus { get; set; }
        public string createdDateTime { get; set; }
        public string lastModifiedDateTime { get; set; }
        public bool isMailBagAccess { get; set; }
        public bool isOutgoingMailAccess { get; set; }
        public List<mailBagAccessLocations> mailBagAccessLocations { get; set; }
        public List<outgoingMailAccessLocations> outgoingMailAccessLocations { get; set; }
    }
    public class mailBagAccessLocations
    {
        public string locationId { get; set; }
        public List<mailBagCPCodes> mailBagCPCodes { get; set; }
    }
    public class mailBagCPCodes
    {
        public string cpCode { get; set; }
    }
    public class outgoingMailAccessLocations
    {
        public string locationId { get; set; }
        public List<outgoingMailDeviceIds> outgoingMailDeviceIds { get; set; }
    }
    public class outgoingMailDeviceIds
    {
        public string DeviceID { get; set; }
    }

    public class Usergroup_RequestModel
    {
        public string groupId { get; set; }
        public string customerId { get; set; }
    }
    public class MailBagCPCodes_RequestModel
    {
        public string cpCode { get; set; }
    }

}
