using static HRM_DAL.Models.ResponceModels.HRM_MailBag;

namespace HRM_DAL.Models.ResponceModels
{
    public class HRMToken
    {
        public class Rootobject : HRM_ReturnResponce
        {
            public Result result { get; set; }
        }
        public class Result
        {
            public string accessToken { get; set; }
            public int expiresIn { get; set; }
            public string tokenType { get; set; }
            public string scope { get; set; }
        }
        public class AckMailbagTransactions_Request
        {
            public string reqTransReferenceId { get; set; }
            public string reqTransType { get; set; }
            public int syncStatus { get; set; }
        }
    }
}