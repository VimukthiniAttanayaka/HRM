namespace HRM_DAL.Models
{
    public class LocationDto
    {
        public int messageId { get; set; }
        public string message { get; set; }
        public CustomerLocation result { get; set; } = new CustomerLocation();
        public string reqTransReferenceId { get;  set; }
        public bool resp { get; internal set; }
        public string msg { get; internal set; }
    }
}
