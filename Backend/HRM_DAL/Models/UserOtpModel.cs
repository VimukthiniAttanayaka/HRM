using System.Collections.Generic;

namespace HRM_DAL.Models
{
    public class UserOtpModel
    {

        public string USER_ID { get; set; }
        public string USER_TABLE { get; set; }
        public int VFY_OTP { get; set; }
    }

    public class UserOtpSmsModel
    {
        //public string USER_ID { get; set; }
        public string UD_MobileNumber { get; set; }
        // public string UD_EmailAddress { get; set; }
        public int UD_Otp { get; set; }
    }
    public class SaveUserOtpModel
    {

        public string USER_ID { get; set; }
        //public string USER_TABLE { get; set; }
        //public string BU_ID { get; set; }
        public string USER_MOBILE { get; set; }
        //public string USER_MOBILE { get; set; }


    }

    public class RtnOTPModel
    {
        public bool resp { get; set; }
        public string msg { get; set; }


    }
    public class ReturnUserOtpDatatModel
    {
        public string USER_ID { get; set; }
        public string UPM_UserTableID { get; set; }


    }
    public class ReturnVerifyOTPModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnUserOtpDatatModel> userdata { get; set; }


    }


}
