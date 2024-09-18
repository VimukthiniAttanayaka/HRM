using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class ReturnUserModelHead : ReturnResponse
    {
        public List<ReturnUserModel> user { get; set; }
    }
    public class LogDataRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class ReturnUserModel
    {
        public object UD_UserID { get; set; }
        public object UD_AuthorizationToken { get; set; }
        public string UD_FirstName { get; set; }
        public string UD_LastName { get; set; }
        public string UD_EmailAddress { get; set; }
        public string UD_MobileNumber { get; set; }
        public string UD_PhoneNumber { get; set; }
        public string UD_Remarks { get; set; }
        public List<MenuAccessModel> menuaccesslist { get; set; }
        public List<UserRoleAccessGroupModel> userroleaccesslist { get; set; }
        public List<ReturnUserAccessModel> UserAccessList { get; set; }
    }

    public class InactiveUserModel { }

    public class ReturnUserAccessModel
    {
        public string MNU_MenuName { get; set; }
        public bool MNU_Active { get; set; }
    }
    public class UserModel
    {
        public object UD_UserID { get; set; }
        public object UD_AuthorizationToken { get; set; }
        public string UD_FirstName { get; set; }
        public string UD_LastName { get; set; }
        public string UD_EmailAddress { get; set; }
        public string UD_MobileNumber { get; set; }
        public string UD_PhoneNumber { get; set; }
        public string UD_Remarks { get; set; }
        public List<MenuAccessModel> menuaccesslist { get; set; }
        public List<UserRoleAccessGroupModel> userroleaccesslist { get; set; }
        public List<ReturnUserAccessModel> UserAccessList { get; set; }
        public string UD_PrefferedName { get; set; }
        public string UD_DepartmentID { get; set; }
        public string UD_EmployeeID { get; set; }
        public string UD_PhoneNumber1 { get; set; }
        public string UD_RankDescription { get; set; }
        public string UD_Address { get; set; }
        public string UD_PhoneNumber2 { get; set; }
        public string UD_StaffLocation { get; set; }
        public string UD_CustomerID { get; set; }
        public string USER_ID { get; set; }
        public bool UD_Status { get; set; }
    }

    //=================================================CUSTOMER=================================
    public class ReturUserModel
    {
        [Key]
        public string UD_EmployeeID { get; set; }
        public string UD_FirstName { get; set; }
        public string UD_LastName { get; set; }
        public string UD_EmailAddress { get; set; }
        public string UD_MobileNumber { get; set; }
        public string UD_PhoneNumber { get; set; }
        public string UD_Remarks { get; set; }
        public string authorizationToken { get; set; }
        [Key]
        public string UD_UserName { get; set; }
        public string UD_Password { get; set; }
        //public List<ReturnCusUserGroupModel> cususergroup { get; set; }
        public bool UD_Status { get; set; }
    }

    public class GetUserAllModel
    {
        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string UD_UserName { get; set; }
        public string UD_FirstName { get; set; }
        public string UD_LastName { get; set; }
        public string UD_Status { get; set; }
    }



}
