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

    //=================================================CUSTOMER=================================
    public class ReturnCustomerUserModel
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
        public List<ReturnCusUserGroupModel> cususergroup { get; set; }
        public bool UD_Status { get; set; }
    }

    public class GetCustomerUserAllModel
    {
        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string UD_UserName { get; set; }
        public string UD_FirstName { get; set; }
        public string UD_LastName { get; set; }
        public string UD_Status { get; set; }
    }

    public class ReturnCusUserAllModel
    {

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
        public bool UD_Status { get; set; }
    }

    public class ReturnCusUserGroupModel
    {
        public string UGM_ID { get; set; }
        public string IndexNo { get; set; }
        public string UGM_Name { get; set; }
        public bool UAG_Select { get; set; }
        public string UAG_CustomerID { get; set; }
    }

    public class ReturnCustomerUserModelHead : ReturnResponse
    {
        public List<ReturnCustomerUserModel> User { get; set; }
    }

    public class ReturnCustomerUserAllModelHead : ReturnResponse
    {
        public List<ReturnCusUserAllModel> User { get; set; }

    }

    public class GetUserSingleModel
    {
        public string UD_UserName { get; set; }
    }

    public class GetUserAllModel
    {
        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string UD_UserID { get; set; }
        public string UD_FirstName { get; set; }
        public string UD_LastName { get; set; }
        public string UGM_Name { get; set; }
        public string UD_Status { get; set; }
        public string CUS_ID { get; set; }
        public string DPT_ID { get; set; }
    }
    public class CUserModel
    {
        public string UD_CustomerID { get; set; }
        public string UD_DepartmentID { get; set; }
        public string UD_UserID { get; set; }
        public string UD_FirstName { get; set; }
        public string UD_LastName { get; set; }
        public string UD_PrefferedName { get; set; }
        public string UD_Address { get; set; }
        public string UD_EmailAddress { get; set; }
        public string UD_MobileNumber { get; set; }
        public string UD_PhoneNumber1 { get; set; }
        public string UD_PhoneNumber2 { get; set; }
        public string UD_RankDescription { get; set; }
        public string UD_StaffLocation { get; set; }
        public string UD_PCDescription { get; set; }
        public string UD_Remarks { get; set; }
        public string UD_ActiveFrom { get; set; }
        public string UD_ActiveTo { get; set; }
        public bool UD_Status { get; set; }
        public string USER_ID { get; set; }
        public List<ReturnCusUserGroupModel> cususergroup { get; set; }
        public string UD_EmployeeID { get; set; }
        public string UD_Pwd { get; set; }
    }

}
