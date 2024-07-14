//using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MailTrak.Common
{
    public static class Messages
    {
        public static string ValidUser = "Please provide a valid user to proceed.";
        public static string ValidCustomer = "Please provide a valid customer to proceed.";
        public static string NoMailBagData = "No mail bag data found.";
        public static string NoOutGoingMailData = "No out going mail data found.";
        public static string NoLocationData = "No location data found.";
        public static string NoDepartmentData = "No department data found.";
        public static string NoUserGroupData = "No user group data found.";
        public static string NoDeviceActivityData = "No device activity data found.";
        public static string MaxRecords = "Please provide maximum records request to proceed.";
        public static string ApiAndPointNotConfigured = "API Endpoint is not configured.";
        public static string ValidGrantType = "Please provide a valid grant type to proceed.";
        public static string ValidTransReferenceId = "Please provide a valid trans reference Id to proceed.";
        public static string ValidTransType = "Please provide a valid trans type to proceed.";

        public static string ValidAuthorization = "Unauthorized";
        public static string ValidRequestReferenceID = "Please provide a valid request reference Id to proceed.";
        public static string ValidRequestType = "Please provide a valid request type to proceed.";
        public static string ValidSmartKioskvendorID = "Please provide a valid kioski vendor Id to proceed.";
        public static string KioskHasMultipleRecords = "KioskHasMultipleRecords";
    }
}
