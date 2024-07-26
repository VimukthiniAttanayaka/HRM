
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
        public string MDD_DepartmentID { get; set; }
        public string MDD_Department { get; set; }
        public string MDD_LocationCode { get; set; }
        public string MDD_Adrs_BlockBuildingNo { get; set; }
        public string MDD_Adrs_BuildingName { get; set; }
        public string MDD_Adrs_UnitNumber { get; set; }
        public string MDD_Adrs_StreetName { get; set; }
        public string MDD_Adrs_City { get; set; }
        public string MDD_Adrs_CountryCode { get; set; }
        public string MDD_Adrs_PostalCode { get; set; }
        public bool MDD_Status { get; set; }
    }

    public class ReturnDepartmentModel
    {
        [Key]
        public string MDD_DepartmentID { get; set; }
        public string MDD_CustomerID { get; set; }
        public string MDD_Department { get; set; }
        public string MDD_LocationCode { get; set; }
        public string MDD_Adrs_BlockBuildingNo { get; set; }
        public string MDD_Adrs_BuildingName { get; set; }
        public string MDD_Adrs_UnitNumber { get; set; }
        public string MDD_Adrs_StreetName { get; set; }
        public string MDD_Adrs_City { get; set; }
        public string MDD_Adrs_CountryCode { get; set; }
        public string MDD_Adrs_PostalCode { get; set; }
        public string CUS_CompanyName { get; set; }
        public bool MDD_Status { get; set; }
        public string MDD_CreatedBy { get; set; }
        public string MDD_CreatedDateTime { get; set; }
        public string MDD_ModifiedBy { get; set; }
        public string MDD_ModifiedDateTime { get; set; }
        public string RC { get; set; }
    }

    public class ReturnDepartmentAllModel //: ReturnResponse
    {
        [Key]
        public string MDD_DepartmentID { get; set; }
        public string MDD_Department { get; set; }
        public string MDD_Status { get; set; }
        public string RC { get; set; }

    }

    public class InactiveDepartmentModel : RequestBaseModel
    {

        public string MDD_DepartmentID { get; set; }

    }

    public class GetDepartmentAllModel : RequestBaseModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string MDD_DepartmentID { get; set; }
        public string MDD_Department { get; set; }
        public string MDD_Status { get; set; }
    }

    public class GetDepartmentSingleModel : RequestBaseModel
    {
        public string MDD_DepartmentID { get; set; }
    }

    public class ReturDepartmentModelHead : ReturnResponse
    {
        public List<ReturnDepartmentModel> Department { get; set; }
    }
}
