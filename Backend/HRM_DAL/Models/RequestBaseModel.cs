using System.Collections.Generic;

namespace HRM_DAL.Models
{
    public class RequestBaseModel : AuthenticationRequestBaseModel
    {

    }
    public class AuthenticationRequestBaseModel
    {
        public string UD_UserID { get; set; }
        public string AUD_notificationToken { get; set; }
    }

    public class RequestGridBaseModel : RequestBaseModel
    {

        public int PAGE_NO { get; set; }
        public int PAGE_RECORDS_COUNT { get; set; }
        public object ColumnSpecialFilter { get; set; }
    }
}
