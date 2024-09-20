using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;


namespace HRM_DAL.Models
{
    public class ReturnExternalUserAllModel
    {

        [Key]
        public string UE_UserID { get; set; }
        public string UE_FirstName { get; set; }
        public string UE_LastName { get; set; }
        public string UE_EmailAddress { get; set; }
        public string UE_MobileNumber { get; set; }
        public string UE_PhoneNumber { get; set; }
        public string UE_Remarks { get; set; }
        public DateTime? UE_ActiveFrom { get; set; }
        public DateTime? UE_ActiveTo { get; set; }
        public bool UE_Status { get; set; }
        public string UE_Pwd { get; set; }
        public string UE_PwdSalt { get; set; }
        public DateTime? UE_PwdLastResetDateTime { get; set; }
        public string UE_CreatedBy { get; set; }
        public string UE_CreatedDateTime { get; set; }
        public string UE_ModifiedBy { get; set; }
        public string UE_ModifiedDateTime { get; set; }
        public string UE_Otp { get; set; }
        public string UE_Otp_Generate_On { get; set; }
    }

    public class ReturnExternalUserAllModelHead : ReturnResponse
    {
        public List<ReturnExternalUserAllModel> User { get; set; }

    }

    public class GetExternalUserSingleModel
    {
        public string UE_UserID { get; set; }
    }

    public class ReturnExternalUserModelHead : ReturnResponse
    {
        public List<ReturnExternalUserModel> User { get; set; }
    }

    public class ReturnExternalUserModel
    {
        public string UE_UserID { get; set; }
        public string UE_FirstName { get; set; }
        public string UE_LastName { get; set; }
        public string UE_EmailAddress { get; set; }
        public string UE_MobileNumber { get; set; }
        public string UE_PhoneNumber { get; set; }
        public string UE_Remarks { get; set; }
        public DateTime? UE_ActiveFrom { get; set; }
        public DateTime? UE_ActiveTo { get; set; }
        public bool UE_Status { get; set; }
        public string UE_Pwd { get; set; }
        public string UE_PwdSalt { get; set; }
        public DateTime? UE_PwdLastResetDateTime { get; set; }
        public string UE_CreatedBy { get; set; }
        public string UE_CreatedDateTime { get; set; }
        public string UE_ModifiedBy { get; set; }
        public string UE_ModifiedDateTime { get; set; }
        public string UE_Otp { get; set; }
        public string UE_Otp_Generate_On { get; set; }
        public string authorizationToken { get; set; }
        //public List<MenuAccessModel> menuaccesslist { get; set; }
        //public List<UserRoleAccessGroupModel> userroleaccesslist { get; set; }
        //public List<ReturnUserAccessModel> UserAccessList { get; set; }
    }
    public class ExternalUserModel:RequestBaseModel
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
        //public string UE_Pwd { get; set; }
        //public string UE_PwdSalt { get; set; }
        //public DateTime? UE_PwdLastResetDateTime { get; set; }
        //public string UE_CreatedBy { get; set; }
        //public string UE_CreatedDateTime { get; set; }
        public string UE_ModifiedBy { get; set; }
        public string UE_ModifiedDateTime { get; set; }
        //public string UE_Otp { get; set; }
        //public string UE_Otp_Generate_On { get; set; }
        //public string authorizationToken { get; set; }
    }
}