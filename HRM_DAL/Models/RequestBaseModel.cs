using System.Collections.Generic;

namespace HRM_DAL.Models
{
    public class RequestBaseModel : AuthenticationRequestBaseModel
    {

        public string CUS_ID { get; set; }
        public string BU_ID { get; set; }
    }
    public class AuthenticationRequestBaseModel
    {
        public string AUT_StaffID { get; set; }
        public string AUT_UserTableID { get; set; }
        public string AUT_notificationToken { get; set; }
    }

    public class RequestGridBaseModel : RequestBaseModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
    }
}
