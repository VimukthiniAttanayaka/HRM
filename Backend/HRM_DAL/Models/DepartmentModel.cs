
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class DepartmentBulkModel : RequestBaseModel
    {
        public List<DepartmentModel> deplist { get; set; }
    }
    public class DepartmentModel : RequestBaseModel
    {
        [Key]
        public string DPT_ID { get; set; }
        public string DPT_Name { get; set; }
        public string DPT_LocationCode { get; set; }
        public string DPT_Adrs_BlockBuildingNo { get; set; }
        public string DPT_Adrs_BuildingName { get; set; }
        public string DPT_Adrs_UnitNumber { get; set; }
        public string DPT_Adrs_StreetName { get; set; }
        public string DPT_Adrs_City { get; set; }
        public string DPT_Adrs_CountryCode { get; set; }
        public string DPT_Adrs_PostalCode { get; set; }
        public bool DPT_Status { get; set; }
    }

    public class ReturnDepartmentModel
    {
        [Key]
        public string DPT_ID { get; set; }
        public string DPT_CustomerID { get; set; }
        public string DPT_Name { get; set; }
        public string DPT_LocationCode { get; set; }
        public string DPT_Adrs_BlockBuildingNo { get; set; }
        public string DPT_Adrs_BuildingName { get; set; }
        public string DPT_Adrs_UnitNumber { get; set; }
        public string DPT_Adrs_StreetName { get; set; }
        public string DPT_Adrs_City { get; set; }
        public string DPT_Adrs_CountryCode { get; set; }
        public string DPT_Adrs_PostalCode { get; set; }
        public string CUS_CompanyName { get; set; }
        public bool DPT_Status { get; set; }
        public string DPT_CreatedBy { get; set; }
        public string DPT_CreatedDateTime { get; set; }
        public string DPT_ModifiedBy { get; set; }
        public string DPT_ModifiedDateTime { get; set; }
        public string RC { get; set; }
    }

    public class ReturnDepartmentAllModel //: ReturnResponse
    {
        [Key]
        public string DPT_ID { get; set; }
        public string DPT_Name { get; set; }
        public string DPT_Status { get; set; }
        public string RC { get; set; }

    }

    public class InactiveDepartmentModel : RequestBaseModel
    {

        public string DPT_ID { get; set; }

    }

    public class GetDepartmentAllModel : RequestBaseModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string DPT_ID { get; set; }
        public string DPT_Name { get; set; }
        public string DPT_Status { get; set; }
    }

    public class GetDepartmentSingleModel : RequestBaseModel
    {
        public string DPT_ID { get; set; }
    }

    public class ReturDepartmentModelHead : ReturnResponse
    {
        public List<ReturnDepartmentModel> Department { get; set; }
    }
}
