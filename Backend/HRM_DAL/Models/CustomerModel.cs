using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class CustomerModel : RequestBaseModel
    {
        public string CUS_ID { get; set; }
        public string CUS_CompanyName { get; set; }
        public string CUS_Adrs_BlockBuildingNo { get; set; }
        public string CUS_Adrs_BuildingName { get; set; }
        public string CUS_Adrs_UnitNumber { get; set; }
        public string CUS_Adrs_StreetName { get; set; }
        public string CUS_Adrs_City { get; set; }
        public string CUS_Adrs_CountryCode { get; set; }
        public string CUS_Adrs_PostalCode { get; set; }
        public string CUS_ContactPerson { get; set; }
        public string CUS_ContactNumber { get; set; }
        public string CUS_PinOrPwd { get; set; }
        public bool CUS_OTP_By_SMS { get; set; }
        public bool CUS_OTP_By_Email { get; set; }
        public bool CUS_Status { get; set; }
    }

    public class ReturncustResponse : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }

    }

    public class ReturnCustomerModel
    {
        [Key]

        public string CUS_ID { get; set; }
        public string CUS_CompanyName { get; set; }
        public string CUS_Adrs_BlockBuildingNo { get; set; }
        public string CUS_Adrs_BuildingName { get; set; }
        public string CUS_Adrs_UnitNumber { get; set; }
        public string CUS_Adrs_StreetName { get; set; }
        public string CUS_Adrs_City { get; set; }
        public string CUS_Adrs_CountryCode { get; set; }
        public string CUS_Adrs_PostalCode { get; set; }
        public string CUS_ContactPerson { get; set; }
        public string CUS_ContactNumber { get; set; }
        public string CUS_PinOrPwd { get; set; }
        public bool CUS_OTP_By_SMS { get; set; }
        public bool CUS_OTP_By_Email { get; set; }
        public string CUS_Status { get; set; }
        public string CUS_CreatedBy { get; set; }
        public string CUS_CreatedDateTime { get; set; }
        public string CUS_ModifiedBy { get; set; }
        public string CUS_ModifiedDateTime { get; set; }
        public string RC { get; set; }
    }

    public class ReturnCustomerAllModel
    {
        [Key]

        public string CUS_ID { get; set; }
        public string CUS_CompanyName { get; set; }
        public string CUS_Status { get; set; }
        public string RC { get; set; }
    }


    public class Customer : RequestBaseModel
    {
        public string CUS_ID { get; set; }


    }
    public class ReturnCustomerModelHead : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnCustomerModel> Customer { get; set; }


    }
    public class ReturnCustomerAllModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnCustomerAllModel> customerall { get; set; }


    }
    public class CustomerSearchModel : RequestBaseModel
    {
        public string CUS_ID { get; set; }
    }
    public class InactiveCusModel : RequestBaseModel
    {

        public string CUS_ID { get; set; }
    }

    public class ReturnCustomerSelectModel
    {
        public string CUS_ID { get; set; }
        public string CUS_CompanyName { get; set; }

    }
}
