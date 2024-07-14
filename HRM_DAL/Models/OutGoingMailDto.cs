namespace HRM_DAL.Models
{
    public class OutGoingMailDto : ReturnResponse
    {
        public int messageId { get; set; }
        public string message { get; set; }
        public OutgoingMailResult result { get; set; }
    }
}
