using System;
using System.Collections.Generic;
using System.Text;

namespace HRM_DAL.Models.RequestModels
{
    public class Ack_MailBagTrans_RequestModel
    {
        public string reqTransReferenceId { get; set; }
        public string reqTransType { get; set; }
        public int syncStatus { get; set; }
        public int maxTransCount { get; set; }
        public string userId { get; set; }
    }
    public class Ack_OutGoingMailTrans_RequestModel
    {
        public string reqTransReferenceId { get; set; }
        public string reqTransType { get; set; }
        public int syncStatus { get; set; }
        public int maxTransCount { get; set; }
        public string userId { get; set; }
    }   
 
    public class Get_Departments_RequestModel
    {
        public string customerId { get; set; }
        public string userId { get; set; }
    }

    public class Get_Departments_JsonUpload_RequestModel
    {
        public Get_Departments_Result result { get; set; }
        public int messageId { get; set; }
        public string message { get; set; }
        public bool resp { get; set; }
        public string msg { get; set; }
    }

    public class Get_OutGoingMailTrans_RequestModel
    {
        public string customerId { get; set; }
        public string userId { get; set; }
        public int maxTransCount { get; set; }
    }


    public class Get_Locations_RequestModel
    {
        public string customerId { get; set; }
        public string userId { get; set; }
    }

    public class Get_UserGroups_RequestModel
    {
        //public string customerId { get; set; }
        public string userId { get; set; }
    }

    public class Set_User_RequestModel
    {
        public string customerId { get; set; }
        public string userId { get; set; }
        public int maxTransCount { get; set; }
    }

    public class Get_DeviceActs_RequestModel
    {
        public string customerId { get; set; }
        public string userId { get; set; }
        public int maxTransCount { get; set; }
    }

    public class Ack_DeviceActs_RequestModel
    {
        public string reqTransReferenceId { get; set; }
        public string reqTransType { get; set; }
        public int syncStatus { get; set; }
        public int maxTransCount { get; set; }
        public string userId { get; set; }
    }

    public class Get_Departments_ResponceModel
    {
        public int messageId { get; set; }
        public string message { get; set; }
        public Get_Departments_Result result { get; set; } = new Get_Departments_Result();
        public string reqTransReferenceId { get; set; }
    }

    public class Get_Departments_Result
    {
        public string customerId { get; set; }
        public List<Department_ResponceModel> departments { get; set; }
    }

    public class Department_ResponceModel
    {
        public string deptId { get; set; }
        public string deptName { get; set; }
        public string cpCode { get; set; }
        public string deviceNo { get; set; }
        public string deviceTypeId { get; set; }
        public string vendorId { get; set; }
        public string activeStatus { get; set; }
        public DateTime? createdDateTime { get; set; }
        public DateTime? lastModifiedDateTime { get; set; }
        public List<string> boxnos { get; set; }
    }

}
