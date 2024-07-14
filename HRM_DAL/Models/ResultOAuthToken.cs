namespace HRM_DAL.Models
{
    public class ResultOAuthToken
    {
        public string accessToken { get; set; }
        public string tokenType { get; set; }
        public int expiresIn { get; set; }
        public string scope { get; set; }
    }
}
