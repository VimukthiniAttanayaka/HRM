namespace HRM_DAL.Models.ResponceModels
{
    public class HRM_ReturnResponce
    {
        public int messageId { get; set; }
        public string message { get; set; }
        public bool resp { get; set; }
        public string msg { get; set; }
    }

    public class HRM_AckReturnResponce
    {
        public int messageId { get; set; }
        public string message { get; set; }
        public object result { get; set; }
        public bool resp { get; set; }
        public string msg { get; set; }
    }

}
