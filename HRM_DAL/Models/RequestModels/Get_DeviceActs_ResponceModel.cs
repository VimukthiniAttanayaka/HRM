using HRM_DAL.Models.ResponceModels;
using System;
using System.Collections.Generic;

namespace HRM_DAL.Models.RequestModels
{
    public class Ack_DeviceActs_ResponceModel : HRM_ReturnResponce
    {
        //public Get_DeviceActs_ResponceModel_Result result { get; set; }
    }
    public class Get_DeviceActs_ResponceModel : HRM_ReturnResponce
    {
        public Get_DeviceActs_ResponceModel_Result result { get; set; }
    }
    public class Get_DeviceActs_ResponceModel_Result
    {
        public List<Get_DeviceActs_Deviceactivity> deviceActivities { get; set; }
        public string reqTransReferenceId { get; set; }
    }

    public class Get_DeviceActs_Deviceactivity
    {
        public string deviceNo { get; set; }
        public string deviceTypeId { get; set; }
        public string vendorId { get; set; }
        public string locationId { get; set; }
        public DateTime transactionDateTime { get; set; }
        public DateTime serverSyncDateTime { get; set; }
        public string userId { get; set; }
        public string activityType { get; set; }
        public string activityDescription { get; set; }
    }

}
