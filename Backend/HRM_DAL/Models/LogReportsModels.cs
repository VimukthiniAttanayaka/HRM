using System;
using System.Collections.Generic;
using System.Text;

namespace HRM_DAL.Models
{
    public class ReturnUserLogReportsModelHead : ReturnResponse
    {
        public List<UserLogModel> UserLog { get; set; }
    }

    public class UserLogModel
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string LoggedDateTime { get; set; }
        public string UserLogId { get; set; }
        public string UserLogOffTime { get; set; }
    }

    public class ReturnAuditLogReportsModelHead : ReturnResponse
    {
        public List<AuditLogModel> AuditLog { get; set; }
    }
    public class AuditLogModel
    {
        public string Action { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string ClientIP { get; set; }
        public string CreatedDateTime { get; set; }
        public string SequenceNo { get; set; }
        public string Module { get; set; }
        public string Controler { get; set; }
        public string ActionType { get; set; }
        public string ActionMap_ID { get; set; }
    }

    public class ReturnErrorLogReportsModelHead : ReturnResponse
    {
        public List<ErrorLogModel> ErrorLog { get; set; }
    }
    public class ErrorLogModel
    {
        public string ErrorLogId { get; set; }
        public string ErrorDescription { get; set; }
        public string ErrorUserId { get; set; }
        public string ErrorDatetime { get; set; }
        public string ErrorLoggedIp { get; set; }
        public string ErrorRef { get; set; }
        public string ErrorPage { get; set; }
    }
    public class RequestErrorLog : RequestBaseModel
    {
    }
    public class RequestUserLog : RequestBaseModel
    {
    }
    public class RequestAuditLog : RequestBaseModel
    {
    }
}
