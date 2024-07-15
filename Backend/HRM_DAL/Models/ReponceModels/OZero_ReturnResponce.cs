using System.Collections.Generic;

namespace HRM_DAL.Models.ResponceModels
{
    public class OZero_ReturnResponce
    {
        public int messageId { get; set; }
        public string message { get; set; }
        public List<ReturnResponse> responces { get; set; }
        public object request { get; set; }
    }
}
