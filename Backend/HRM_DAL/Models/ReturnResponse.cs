namespace HRM_DAL.Models
{
    public class ReturnResponse
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public bool IsAuthenticated { get; set; } = true;
        public virtual object obj { get; set; }

    }
}