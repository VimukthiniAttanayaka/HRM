using HRM_DAL.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HRM_DAL.Models
{
    public class UserModel
    {

        public string UD_StaffID { get; set; }
        public string UD_FirstName { get; set; }
        public string UD_LastName { get; set; }
        public string UD_EmailAddress { get; set; }
        public string UD_MobileNumber { get; set; }
        public string UD_PhoneNumber { get; set; }
        public string UD_Remarks { get; set; }
        public string authorizationToken { get; set; }
        public string UD_UserName { get; set; }
        public string UD_Password { get; set; }
        public List<UserGroupModel> UserGroup { get; set; }
        public List<UserBuModel> UserBU { get; set; }
        public List<UserCustModel> UserCustomer { get; set; }


    }
   
    public class LogdataModel
    {
        [Key]

        public string username { get; set; }
        public string password { get; set; }
    }

    public class ReturnUserDataModel
    {
        [Key]
        public string UD_StaffID { get; set; }
        public string UD_FirstName { get; set; }
        public string UD_LastName { get; set; }
        public string UD_EmailAddress { get; set; }
        public string UD_MobileNumber { get; set; }
        public string UD_PhoneNumber { get; set; }
        public string UD_Remarks { get; set; }
        public string authorizationToken { get; set; }
        public string UD_UserName { get; set; }
        public string UD_Password { get; set; }
        public string RC { get; set; }
        public List<ReturnUserGroupModel> UserGroup { get; set; }
        public List<ReturnUserBuModel> UserBU { get; set; }
        public List<ReturnUserCustModel> UserCustomer { get; set; }
    }

    public class ReturnUserallDataModel
    {
        [Key]
        public string UD_StaffID { get; set; }
        public string UD_FirstName { get; set; }
        public string UD_LastName { get; set; }
        public string UGM_Name { get; set; }
        public bool UAG_Status { get; set; }
        public string BU_CompanyName { get; set; }
        public string CUS_CompanyName { get; set; }
        public bool UD_Status { get; set; }
        public string RC { get; set; }


    }

    public class ReturnUserall_SingleDataModel
    {
        [Key]
        public string UD_StaffID { get; set; }
        public string UD_FirstName { get; set; }
        public string UD_LastName { get; set; }
        public bool UAG_Status { get; set; }
        public string BU_CompanyName { get; set; }
        public string CUS_CompanyName { get; set; }
        public bool UD_Status { get; set; }
        public string RC { get; set; }


    }

    public class ReturnLoadUserDataModel : ReturnResponse
    {
        [Key]

        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnUserGroupModel> usergroup { get; set; }
        public List<ReturnUserBuModel> userbu { get; set; }
        public List<ReturnUserCustModel> usercust { get; set; }

    }



    public class ReturnUserGroupModel
    {

        public string UGM_ID { get; set; }
        public string IndexNo { get; set; }
        public string UGM_Name { get; set; }
        public bool UAG_Select { get; set; }
        public string UGM_Type { get; set; }
        public string UAG_CustomerID { get; set; }
    }

    public class UserGroupModel
    {

        public string UGM_ID { get; set; }
        public string IndexNo { get; set; }
        public string UGM_Name { get; set; }

    }
    public class ReturnUserBuModel
    {
        public string BU_ID { get; set; }
        public string IndexNo { get; set; }
        public string BU_CompanyName { get; set; }
        public string BU_CountryCode { get; set; }
        public bool UAG_Select { get; set; }
    }

    public class UserBuModel
    {
        public string BU_ID { get; set; }
        public string IndexNo { get; set; }
        public string BU_CompanyName { get; set; }
        public string BU_CountryCode { get; set; }
    }

    public class ReturnUserCustModel
    {
        public string CUS_ID { get; set; }
        public string IndexNo { get; set; }
        public string CUS_CompanyName { get; set; }
        public string BU_CompanyName { get; set; }
        public bool UAG_Select { get; set; }

    }
    public class UserCustModel
    {
        public string CUS_ID { get; set; }
        public string IndexNo { get; set; }
        public string CUS_CompanyName { get; set; }
        public string BU_CompanyName { get; set; }

    }
    public class User
    {
        public string USER_ID { get; set; }
    }
    public class InactiveUserModel
    {
        public string UD_StaffID { get; set; }
        public string USER_ID { get; set; }
    }
    public class InactiveCUserModel
    {

        public string USR_StaffID { get; set; }
        public string TABLE { get; set; }
        public string USER_ID { get; set; }
    }
    public class GeUserAllModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string UD_StaffID { get; set; }
        public string UD_FirstName { get; set; }
        public string UD_LastName { get; set; }
        public string UGM_Name { get; set; }
        //public string BU_CompanyName { get; set; }
        //public string CUS_CompanyName { get; set; }

        public string BU_ID { get; set; }
        public string CUS_ID { get; set; }
        public string UD_Status { get; set; }


    }
    public class ReturnUserDataModelHead : ReturnResponse
    {
        public List<ReturnUserDataModel> User { get; set; }


    }


    public class ReturnUserallDataModelHead : ReturnResponse
    {
        public List<ReturnUserallDataModel> User { get; set; }
    }

    public class ReturnUserall_SingleDataModelHead : ReturnResponse
    {
        public List<ReturnUserall_SingleDataModel> User { get; set; }
    }



    public class ResetPasswordModel
    {
        public string email { get; set; }
    }

    public class ReturnUserModelHead : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnUserModel> user { get; set; }

    }
    public class RequestUserAccessModel
    {
        [Key]
        public string UD_StaffID { get; set; }
        public string UD_BusinessUnit { get; set; }
        public string UD_CustomerCode { get; set; }
    }

    public class ReturnUserModel
    {
        [Key]
        public string UD_StaffID { get; set; }
        public string UD_FirstName { get; set; }
        public string UD_LastName { get; set; }
        public string UD_EmailAddress { get; set; }
        public string UD_MobileNumber { get; set; }
        public string UD_PhoneNumber { get; set; }
        public string UD_Remarks { get; set; }
        public string authorizationToken { get; set; }
        public string UD_UserName { get; set; }
        public string UD_Password { get; set; }
        public List<ReturnUserAccessModel> UserAccessList { get; set; }
    }
    public class ReturnUserAccessModelHead : ReturnResponse
    {
        public List<ReturnUserAccessModel> UserAccessList { get; set; }
    }
    public class ReturnUserAccessModel
    {
        public string UD_StaffID { get; set; }
        public string Menu_Code { get; set; }
        public string Menu_Description { get; set; }
        public string Menu_Item_Type { get; set; }
        public string UAG_GroupID { get; set; }
    }

    public class NotificationTokenModel
    {
        [Key]
        public Int32 ID { get; set; }
        public string notification_token { get; set; }


    }
    public class UpNotTokModel
    {
        [Key]

        public List<NotificationTokenModel> objUpNotTokList { get; set; }


    }


    public class NewpwModel
    {

        public string USER_ID { get; set; }
        public string USER_TABLE { get; set; }
        public string USER_PW { get; set; }


    }


    public class GetActivityLog
    {
        [Key]
        public Int32 ID { get; set; }
        public string USER_NAME { get; set; }
        public string ACTIVITY_DESCRIPTION { get; set; }
        public string DATE { get; set; }
    }

    //=================================================CUSTOMER=================================
    public class ReturnCustomerUserModel
    {
        [Key]
        public string USR_CustomerID { get; set; }
        public string CUS_CompanyName { get; set; }
        public string USR_DepartmentID { get; set; }
        public string DPT_Name { get; set; }
        public string USR_StaffID { get; set; }
        public string USR_FirstName { get; set; }
        public string USR_LastName { get; set; }
        public string USR_PrefferedName { get; set; }
        public string USR_OrgStructuralLevel1 { get; set; }
        public string USR_OrgStructuralLevel2 { get; set; }
        public string USR_DepartmentDetail1 { get; set; }
        public string USR_DepartmentDetail2 { get; set; }
        public string USR_DepartmentDetail3 { get; set; }
        public string USR_JobCodeDescription { get; set; }
        public string USR_Address { get; set; }
        public string USR_EmailAddress { get; set; }
        public string USR_MobileNumber { get; set; }
        public string USR_PhoneNumber1 { get; set; }
        public string USR_PhoneNumber2 { get; set; }
        public string USR_RankDescription { get; set; }
        public string USR_StaffLocation { get; set; }
        public string USR_PCCode { get; set; }
        public string USR_PCDescription { get; set; }
        public string USR_Remarks { get; set; }
        public bool USR_OutgoingMailFlag { get; set; }
        public bool USR_HRMAccessFlag { get; set; }
        public bool USR_ChangePCCodeFlag { get; set; }
        public string USR_MailBagCPCode { get; set; }
        public string USR_OutgoingMailCPCode { get; set; }
        public string USR_OutgoingMailLocationCode { get; set; }
        public string USR_PostageUsageReportFrequency { get; set; }
        public string USR_Status { get; set; }
        public string USR_Pwd { get; set; }
        public string USR_PwdSalt { get; set; }
        public string USR_CreatedDateTime { get; set; }
        public string USR_ModifiedDateTime { get; set; }
        public string USR_ActiveFrom { get; set; }
        public string USR_ActiveTo { get; set; }
        public string BU_ID { get; set; }
        public string RC { get; set; }
        public List<ReturnCusUserGroupModel> cususergroup { get; set; }
        public List<ReturnCusUserGroupModel> cususergroupKioski { get; set; }
    }

    public class ReturnCusUserAllModel
    {

        public string USR_StaffID { get; set; }
        public string USR_FirstName { get; set; }
        public string USR_LastName { get; set; }
        public string UGM_Name { get; set; }
        public string DPT_Name { get; set; }
        public string CUS_CompanyName { get; set; }
        public string USR_Status { get; set; }
        public string RC { get; set; }
        public string BU_ID { get; set; }
        public string DPT_ID { get; set; }
        public string DPCC_PCCode { get; set; }
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
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnCusUserAllModel> User { get; set; }

    }

    public class CUser
    {
        public string USER_ID { get; set; }
        public string TABLE { get; set; }

    }

    public class GetCustomerUserAllModel
    {
        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string USR_StaffID { get; set; }
        public string USR_FirstName { get; set; }
        public string USR_LastName { get; set; }
        public string UGM_Name { get; set; }
        public string USR_Status { get; set; }
        public string TABLE { get; set; }
        public string BU_ID { get; set; }
        public string CUS_ID { get; set; }
        public string DPT_ID { get; set; }
    }
    public class CUserModel
    {
        public string USR_CustomerID { get; set; }
        public string USR_DepartmentID { get; set; }
        public string USR_StaffID { get; set; }
        public string USR_FirstName { get; set; }
        public string USR_LastName { get; set; }
        public string USR_PrefferedName { get; set; }
        public string USR_OrgStructuralLevel1 { get; set; }
        public string USR_OrgStructuralLevel2 { get; set; }
        public string USR_DepartmentDetail1 { get; set; }
        public string USR_DepartmentDetail2 { get; set; }
        public string USR_DepartmentDetail3 { get; set; }
        public string USR_JobCodeDescription { get; set; }
        public string USR_Address { get; set; }
        public string USR_EmailAddress { get; set; }
        public string USR_MobileNumber { get; set; }
        public string USR_PhoneNumber1 { get; set; }
        public string USR_PhoneNumber2 { get; set; }
        public string USR_RankDescription { get; set; }
        public string USR_StaffLocation { get; set; }
        public string USR_PCCode { get; set; }
        public string USR_PCDescription { get; set; }
        public string USR_Remarks { get; set; }
        public string USR_ActiveFrom { get; set; }
        public string USR_ActiveTo { get; set; }
        public bool USR_Status { get; set; }
        public string USER_ID { get; set; }
        public string TABLE { get; set; }
        public List<ReturnCusUserGroupModel> cususergroup { get; set; }
        public string UAG_BusinessUnit { get; set; }
        public string USR_EmployeeID { get; set; }
        public string USR_PwdSalt { get; set; }
        public string USR_Pwd { get; set; }
    }

}
