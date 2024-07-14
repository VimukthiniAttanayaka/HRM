
namespace HRM_DAL.Models.ResponceModels
{
    public class HRMToken
    {
        public class Rootobject : HRM_ReturnResponce
        {
            public Result result { get; set; }
            public string RequestReferenceID { get; set; }
        }
        public class Result
        {
            public string accessToken { get; set; }
            public int expiresIn { get; set; }
            public string tokenType { get; set; }
            public string scope { get; set; }
        }
    }
}