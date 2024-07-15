namespace utility_handler.Data
{
    internal class AuditLog
    {
        public AuditLog()
        {
        }

        public string Module { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public int Identity { get; set; }
        public string ClientIP { get;  set; }
        public string Controler { get; internal set; }
        public string ActionType { get; internal set; }
    }
}