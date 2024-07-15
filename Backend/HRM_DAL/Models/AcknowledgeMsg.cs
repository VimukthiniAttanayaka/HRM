namespace HRM_DAL.Models
{
    public class AcknowledgeMsg
    {
        public int messageId { get; set; }
        public string message { get; set; }
        public ResultOAuthToken result { get; set; }
    }
}
