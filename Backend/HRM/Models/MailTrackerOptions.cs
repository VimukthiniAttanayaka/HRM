namespace HRM.Models
{
    public class HRMOptions
    {
        public const string Position = "HRMAPIEndpoint";
        public string EndpointUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Scopes { get; set; }
        public string TockenUrl { get; set; }
    }
}
