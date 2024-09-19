using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace HRM_DAL.Models
{
    public class ReturnInternalUserAllModel
    {

        [Key]
        public string UE_UserID { get; set; }
        public string UE_FirstName { get; set; }
        public string UE_LastName { get; set; }
        public string UE_EmailAddress { get; set; }
        public string UE_MobileNumber { get; set; }
        public string UE_PhoneNumber { get; set; }
        public string UE_Remarks { get; set; }
        public DateTime UE_ActiveFrom { get; set; }
        public DateTime UE_ActiveTo { get; set; }
        public bool UE_Status { get; set; }
        public string UE_Pwd { get; set; }
        public string UE_PwdSalt { get; set; }
        public DateTime UE_PwdLastResetDateTime { get; set; }
        public string UE_CreatedBy { get; set; }
        public string UE_CreatedDateTime { get; set; }
        public string UE_ModifiedBy { get; set; }
        public string UE_ModifiedDateTime { get; set; }
        public string UE_Otp { get; set; }
        public string UE_Otp_Generate_On { get; set; }
        public string UE_EmployeeID { get; set; }
    }

    public class ReturnInternalUserAllModelHead : ReturnResponse
    {
        public List<ReturnInternalUserAllModel> User { get; set; }

    }
    public class GetInternalUserSingleModel
    {
        public string UE_UserID { get; set; }
    }
    public class ReturnInternalUserModelHead : ReturnResponse
    {
        public List<ReturnInternalUserModel> User { get; set; }
    }
    public class ReturnInternalUserModel
    {

        [Key]
        public string UE_UserID { get; set; }
        public string UE_FirstName { get; set; }
        public string UE_LastName { get; set; }
        public string UE_EmailAddress { get; set; }
        public string UE_MobileNumber { get; set; }
        public string UE_PhoneNumber { get; set; }
        public string UE_Remarks { get; set; }
        public DateTime UE_ActiveFrom { get; set; }
        public DateTime UE_ActiveTo { get; set; }
        public bool UE_Status { get; set; }
        public string UE_Pwd { get; set; }
        public string UE_PwdSalt { get; set; }
        public DateTime UE_PwdLastResetDateTime { get; set; }
        public string UE_CreatedBy { get; set; }
        public string UE_CreatedDateTime { get; set; }
        public string UE_ModifiedBy { get; set; }
        public string UE_ModifiedDateTime { get; set; }
        public string UE_Otp { get; set; }
        public string UE_Otp_Generate_On { get; set; }
        public string authorizationToken { get; set; }
        public string UE_EmployeeID { get; set; }
    }
    public class InternalUserModel
    {
        public string UE_UserID { get; set; }
        public string UE_FirstName { get; set; }
        public string UE_LastName { get; set; }
        public string UE_EmailAddress { get; set; }
        public string UE_MobileNumber { get; set; }
        public string UE_PhoneNumber { get; set; }
        public string UE_Remarks { get; set; }
        public DateTime UE_ActiveFrom { get; set; }
        public DateTime UE_ActiveTo { get; set; }
        public bool UE_Status { get; set; }
        public string UE_Pwd { get; set; }
        public string UE_PwdSalt { get; set; }
        public DateTime UE_PwdLastResetDateTime { get; set; }
        public string UE_CreatedBy { get; set; }
        public string UE_CreatedDateTime { get; set; }
        public string UE_ModifiedBy { get; set; }
        public string UE_ModifiedDateTime { get; set; }
        public string UE_Otp { get; set; }
        public string UE_Otp_Generate_On { get; set; }
        public string authorizationToken { get; set; }
    }
}
