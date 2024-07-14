using System;
using System.Collections.Generic;
using System.Text;

namespace HRM_DAL.Models.RequestModels
{
    public class Get_OAuthToken_RequestModel
    {
        public string grant_type { get; set; }
    }
    public class Acknowledge_OAuthToken_RequestModel
    {
        public string grant_type { get; set; }
        public string RequestReferenceID { get; set; }
        public string accessToken { get; set; }
        public int expiresIn { get; set; }

    }
}
