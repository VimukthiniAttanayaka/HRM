
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
        public string DPT_CustomerID { get; set; }
        public string DPT_ID { get; set; }
        public string DPT_Name { get; set; }
        public string DPT_CPCode { get; set; }
        public string DPT_LocationCode { get; set; }
        public string DPT_Adrs_BlockBuildingNo { get; set; }
        public string DPT_Adrs_BuildingName { get; set; }
        public string DPT_Adrs_UnitNumber { get; set; }
        public string DPT_Adrs_StreetName { get; set; }
        public string DPT_Adrs_City { get; set; }
        public string DPT_Adrs_CountryCode { get; set; }
        public string DPT_Adrs_PostalCode { get; set; }
        public string DPT_Contact1_StaffName { get; set; }
        public string DPT_Contact1_DeskContactNumber { get; set; }
        public string DPT_Contact1_MobileNo { get; set; }

        public string DPT_Contact1_EmailAddress { get; set; }

        public string DPT_Contact1_Comments { get; set; }
        public string DPT_Contact2_StaffName { get; set; }
        public string DPT_Contact2_DeskContactNumber { get; set; }
        public string DPT_Contact2_MobileNo { get; set; }

        public string DPT_Contact2_EmailAddress { get; set; }

        public string DPT_Contact2_Comments { get; set; }
        public string DPT_Contact3_StaffName { get; set; }
        public string DPT_Contact3_DeskContactNumber { get; set; }
        public string DPT_Contact3_MobileNo { get; set; }

        public string DPT_Contact3_EmailAddress { get; set; }

        public string DPT_Contact3_Comments { get; set; }
        public string DPT_Contact4_StaffName { get; set; }
        public string DPT_Contact4_DeskContactNumber { get; set; }
        public string DPT_Contact4_MobileNo { get; set; }
        public string DPT_Contact4_EmailAddress { get; set; }
        public string DPT_Contact4_Comments { get; set; }
        public string DPT_Contact5_StaffName { get; set; }
        public string DPT_Contact5_DeskContactNumber { get; set; }
        public string DPT_Contact5_MobileNo { get; set; }
        public string DPT_Contact5_EmailAddress { get; set; }
        public string DPT_Contact5_Comments { get; set; }
        public string USER_ID { get; set; }
        public bool DPT_Status { get; set; }
        public List<DepartmentPCCodes> pccodes { get; set; } = new List<DepartmentPCCodes>();
        public List<DepartmentDeviceBox> boxnos { get; set; } = new List<DepartmentDeviceBox>();
    }

    public class DepartmentDeviceBox
    {
        public string DPDB_CustomerID { get; set; }
        public string DPDB_DepartmentID { get; set; }
        public string DPDB_DeviceNo { get; set; }
        public string DPDB_BoxNo { get; set; }
        public string DPDB_DeviceTypeNo { get; set; }
        public string DPDB_VendorID { get; set; }
        public int DPDB_Status { get; set; }
        public string DPDB_CreatedBy { get; set; }
        public string DPDB_CreatedDateTime { get; set; }
        public string DPDB_ModifiedBy { get; set; }
        public string DPDB_ModifiedDateTime { get; set; }
        public string DPDB_DepartmentName { get; set; }
        public string DPDB_CPCode { get; set; }
        public string User_ID { get; set; }
    }

    public class DepartmentPCCodes
    {
        public string DPT_CustomerID { get; set; }
        public string DPT_ID { get; set; }
        public string DPT_PCCode { get; set; }
    }


    public class ReturnDepartmentModel
    {
        [Key]
        public string DPT_ID { get; set; }
        public string DPT_CustomerID { get; set; }
        public string DPT_Name { get; set; }
        public string DPT_LocationCode { get; set; }
        public string DPT_CPCode { get; set; }
        public string DPT_Adrs_BlockBuildingNo { get; set; }
        public string DPT_Adrs_BuildingName { get; set; }
        public string DPT_Adrs_UnitNumber { get; set; }
        public string DPT_Adrs_StreetName { get; set; }
        public string DPT_Adrs_City { get; set; }
        public string DPT_Adrs_CountryCode { get; set; }
        public string DPT_Adrs_PostalCode { get; set; }
        public string DPT_Contact1_StaffName { get; set; }
        public string DPT_Contact1_DeskContactNumber { get; set; }
        public string DPT_Contact1_MobileNo { get; set; }
        public string DPT_Contact1_EmailAddress { get; set; }

        public string DPT_Contact1_Comments { get; set; }
        public string DPT_Contact2_StaffName { get; set; }
        public string DPT_Contact2_DeskContactNumber { get; set; }
        public string DPT_Contact2_MobileNo { get; set; }

        public string DPT_Contact2_EmailAddress { get; set; }

        public string DPT_Contact2_Comments { get; set; }
        public string DPT_Contact3_StaffName { get; set; }
        public string DPT_Contact3_DeskContactNumber { get; set; }
        public string DPT_Contact3_MobileNo { get; set; }

        public string DPT_Contact3_EmailAddress { get; set; }

        public string DPT_Contact3_Comments { get; set; }
        public string DPT_Contact4_StaffName { get; set; }
        public string DPT_Contact4_DeskContactNumber { get; set; }
        public string DPT_Contact4_MobileNo { get; set; }
        public string DPT_Contact4_EmailAddress { get; set; }
        public string DPT_Contact4_Comments { get; set; }
        public string DPT_Contact5_StaffName { get; set; }
        public string DPT_Contact5_DeskContactNumber { get; set; }
        public string DPT_Contact5_MobileNo { get; set; }
        public string DPT_Contact5_EmailAddress { get; set; }
        public string DPT_Contact5_Comments { get; set; }

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
        public string DPT_CPCode { get; set; }
        public string CUS_CompanyName { get; set; }
        public string DPT_Status { get; set; }
        public string RC { get; set; }

    }

    public class InactiveDepartmentModel : RequestBaseModel
    {

        public string DPT_ID { get; set; }

        public string DPT_CustomerID { get; set; }
        public string USER_ID { get; set; }
    }

    public class GetDepartmentAllModel : RequestBaseModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string DPT_ID { get; set; }
        public string DPT_Name { get; set; }
        public string DPT_CPCode { get; set; }
        public string CUS_CompanyName { get; set; }
        public string DPT_Status { get; set; }
        public string BU_CompanyName { get; set; }
    }

    public class GetDepartmentSingleModel : RequestBaseModel
    {

        public string DPT_ID { get; set; }

        public string DPT_CustomerID { get; set; }

    }

    public class ReturDepartmentModelHead : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnDepartmentModel> Department { get; set; }


    }
}
