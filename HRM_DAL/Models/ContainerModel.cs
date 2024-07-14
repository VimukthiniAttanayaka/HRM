
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class ContainerModel : RequestBaseModel
    {
        [Key]
        public string CN_ID { get; set; }
        public string CN_CountryCode { get; set; }
        public string CN_CustomerID { get; set; }
        public string CN_DepartmentID { get; set; }
        public string CN_CostCentreNo { get; set; }
        public string CN_DispatchTypeCode { get; set; }
        public string CN_LabelFooterLine1 { get; set; }
        public string CN_LabelFooterLine2 { get; set; }
        public string CN_CostCentreName { get; set; }
        public string USER_ID { get; set; }
        public string CN_LastPrintedBy { get; set; }
        public string CN_LastPrintedDateTime { get; set; }
        public string CN_LastPrintedLabelTypeID { get; set; }
        public bool CN_Status { get; set; }


    }
    public class ReturnContainerModel
    {
        [Key]
        public string CN_ID { get; set; }
        public string CN_CostCentreNo { get; set; }
        public string CN_CountryCode { get; set; }
        public string COU_Name { get; set; }
        public string CN_CustomerID { get; set; }
        public string CUS_CompanyName { get; set; }
        public string CN_DepartmentID { get; set; }
        public string DPT_Name { get; set; }
        public string CN_Status { get; set; }
        public string CN_DispatchTypeCode { get; set; }
        public string CT_Name { get; set; }
        public string CN_LabelFooterLine1 { get; set; }
        public string CN_LabelFooterLine2 { get; set; }
        public string RC { get; set; }
        public string CN_LastPrintedBy { get; set; }
        public string CN_LastPrintedDateTime { get; set; }
        public string CN_CostCentreName { get; set; }
        public string CN_LastPrintedLabelTypeID { get; set; }
        public string CN_CreatedBy { get; set; }
        public string CN_CreatedDateTime { get; set; }
        public string CN_ModifiedBy { get; set; }
        public string CN_ModifiedDateTime { get; set; }
        public string DPCC_PCCode { get; set; }
    }

    public class ReturnContainerAllModel
    {
        [Key]
        public string CN_ID { get; set; }
        public string CN_CostCentreNo { get; set; }
        public string CUS_CompanyName { get; set; }
        public string BU_CompanyName { get; set; }
        public string DPT_Name { get; set; }
        public string CN_Status { get; set; }
        public string CT_Name { get; set; }
        public string RC { get; set; }

    }

    public class InactiveContainerModel : RequestBaseModel
    {

        public string CN_ID { get; set; }
        public string USER_ID { get; set; }
    }

    public class GetContainerAllModel : RequestBaseModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string CN_ID { get; set; }
        public string CN_CostCentreNo { get; set; }
        public string CUS_CompanyName { get; set; }
        public string CN_CustomerID { get; set; }
        public string CN_CountryCode { get; set; }
        public string DPT_ID { get; set; }
        public string CN_Status { get; set; }
        public string CT_Name { get; set; }
        public string CN_DispatchTypeCode { get; set; }
    }

    public class GetContainerSingleModel : RequestBaseModel
    {

        public string CN_ID { get; set; }

    }

    public class ReturnContainerModelHead : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnContainerModel> Container { get; set; }


    }
    public class ReturnContainerAllModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnContainerAllModel> containerall { get; set; }


    }







}
