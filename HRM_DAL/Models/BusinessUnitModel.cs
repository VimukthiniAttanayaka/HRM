using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class BusinessUnitModel : RequestBaseModel
    {
        [Key]
        public string BU_ID { get; set; }
        public string BU_CompanyName { get; set; }
        public string BU_Abbre { get; set; }
        public string BU_Adrs_BlockBuildingNo { get; set; }
        public string BU_Adrs_BuildingName { get; set; }
        public string BU_Adrs_UnitNumber { get; set; }
        public string BU_Adrs_StreetName { get; set; }
        public string BU_Adrs_City { get; set; }
        public string BU_Adrs_CountryCode { get; set; }
        public string BU_Adrs_PostalCode { get; set; }
        public string BU_CurrencyCode { get; set; }
        public string BU_CountryCode { get; set; }
        public bool BU_ChangeProcessDate { get; set; }
        public bool BU_Status { get; set; }
        public bool BU_SMS_Enabled { get; set; }
        public string BU_SMS_GW_HOST_IP { get; set; }
        public Int32 BU_SMS_GW_HOST_PORT { get; set; }
        public string BU_SMS_GW_JID { get; set; }
        public string BU_SMS_GW_PWD { get; set; }
        public string BU_SMS_GW_IIM_SVR { get; set; }
        public Int32 BU_SMS_GW_SMS_LIMIT { get; set; }
        public Int32 BU_SMS_GW_QUE_CAP { get; set; }
        public Int32 BU_SMS_GW_MAX_CHAR { get; set; }
        public string BU_SMS_GW_SENDER_ID { get; set; }
        public bool BU_EMAIL_Enabled { get; set; }
        public string BU_EMAIL_SMTP_HOST_IP { get; set; }
        public Int32 BU_EMAIL_SMTP_HOST_PORT { get; set; }
        public string BU_EMAIL_SMTP_UID { get; set; }
        public string BU_EMAIL_SMTP_PWD { get; set; }
        public bool BU_EMAIL_SMTP_AUTH { get; set; }
        public bool BU_EMAIL_SMTP_TLS_ENABLE { get; set; }
        public bool BU_EMAIL_SMTP_SSL_ENABLE { get; set; }
        public string BU_EMAIL_SMTP_SSL_PROTOCOLS { get; set; }
        public string BU_EMAIL_SMTP_SSL_SOCKET_FACTORY { get; set; }
        public string BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_CLASS { get; set; }
        public Int32 BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_PORT { get; set; }
        public string USER_ID { get; set; }
        public bool BU_SMS_BY_LINKURL { get; set; } = true;
    }
    public class ReturnBusinessUnitModel
    {
        [Key]
        public string BU_ID { get; set; }
        public string BU_CompanyName { get; set; }
        public string BU_Abbre { get; set; }
        public string BU_Adrs_BlockBuildingNo { get; set; }
        public string BU_Adrs_BuildingName { get; set; }
        public string BU_Adrs_UnitNumber { get; set; }
        public string BU_Adrs_StreetName { get; set; }
        public string BU_Adrs_City { get; set; }
        public string COU_Name { get; set; }
        public string BU_CurrencyCode { get; set; }
        public string BU_Adrs_PostalCode { get; set; }
        public string CUR_Name { get; set; }
        public string BU_CountryCode { get; set; }
        public bool BU_ChangeProcessDate { get; set; }
        public bool BU_Status { get; set; }
        public bool BU_SMS_Enabled { get; set; }
        public string BU_SMS_GW_HOST_IP { get; set; }
        public Int32 BU_SMS_GW_HOST_PORT { get; set; }
        public string BU_SMS_GW_JID { get; set; }
        public string BU_SMS_GW_PWD { get; set; }
        public string BU_SMS_GW_IIM_SVR { get; set; }
        public Int32 BU_SMS_GW_SMS_LIMIT { get; set; }
        public Int32 BU_SMS_GW_QUE_CAP { get; set; }
        public Int32 BU_SMS_GW_MAX_CHAR { get; set; }
        public string BU_SMS_GW_SENDER_ID { get; set; }
        public bool BU_EMAIL_Enabled { get; set; }
        public string BU_EMAIL_SMTP_HOST_IP { get; set; }
        public Int32 BU_EMAIL_SMTP_HOST_PORT { get; set; }
        public string BU_EMAIL_SMTP_UID { get; set; }
        public string BU_EMAIL_SMTP_PWD { get; set; }
        public bool BU_EMAIL_SMTP_AUTH { get; set; }
        public bool BU_EMAIL_SMTP_TLS_ENABLE { get; set; }
        public bool BU_EMAIL_SMTP_SSL_ENABLE { get; set; }
        public string BU_EMAIL_SMTP_SSL_PROTOCOLS { get; set; }
        public string BU_EMAIL_SMTP_SSL_SOCKET_FACTORY { get; set; }
        public string BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_CLASS { get; set; }
        public Int32 BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_PORT { get; set; }
        public string BU_Adrs_CountryCode { get; set; }
        public string BU_CreatedBy { get; set; }
        public string BU_CreatedDateTime { get; set; }
        public string BU_ModifiedBy { get; set; }
        public string BU_ModifiedDateTime { get; set; }
        public string RC { get; set; }
        public bool BU_SMS_BY_LINKURL { get;  set; }
    }
    public class ReturnBusinessUnitallModel
    {
        [Key]
        public string BU_ID { get; set; }
        public string BU_CompanyName { get; set; }
        public string BU_Abbre { get; set; }
        public string BU_Adrs_BlockBuildingNo { get; set; }
        public string BU_Adrs_BuildingName { get; set; }
        public string BU_Adrs_UnitNumber { get; set; }
        public string BU_Adrs_StreetName { get; set; }
        public string BU_Adrs_City { get; set; }
        public string BU_CurrencyCode { get; set; }
        public string CUR_Name { get; set; }
        public string BU_CountryCode { get; set; }
        public string COU_Name { get; set; }
        public bool BU_Status { get; set; }
        public string RC { get; set; }

    }


    public class InactiveModel : RequestBaseModel
    {

        public string BU_ID { get; set; }
        public string USER_ID { get; set; }
    }

    public class GetBuAllModel : RequestBaseModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string BU_ID { get; set; }
        public string BU_CompanyName { get; set; }
        public string BU_Abbre { get; set; }
        public string COU_Name { get; set; }
        public string BU_Status { get; set; }
    }
    public class GetBusingleModel : RequestBaseModel
    {

        public string BU_ID { get; set; }

    }

    public class ReturnBusinessUnitModelHead : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnBusinessUnitModel> BusinessUnit { get; set; }


    }
    public class ReturnBusinessUnitallModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnBusinessUnitallModel> BusinessUnitall { get; set; }


    }

    public class ReturnCountryModel
    {
        public string COU_Code { get; set; }
        public string COU_Name { get; set; }

    }

    public class ReturnCountryModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnCountryModel> Country { get; set; }


    }

    public class ReturnCurrencyModel
    {
        public string CUR_Code { get; set; }
        public string CUR_Name { get; set; }

    }

    public class ReturnCurrencyModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnCurrencyModel> Currency { get; set; }


    }




}
