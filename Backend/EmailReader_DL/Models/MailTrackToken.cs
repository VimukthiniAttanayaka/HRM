using static MailTrak_DAL.Models.ResponceModels.MailTrack_MailBag;

namespace MailTrak_DAL.Models.ResponceModels
{
    public class MailTrackToken
    {
        public class Rootobject : MailTrack_ReturnResponce
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