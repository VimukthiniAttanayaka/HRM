using System;

namespace utility_handler.Model
{
    public class AuditLog
    {
        public string Module { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string ClientIP { get; set; }
        public int Identity { get; set; }
    }

    public class ActivityLogModel
    {
        public string ACTIVITY_DESCRIPTION { get; set; }
        public string USER_ID { get; set; }
        
    }
}