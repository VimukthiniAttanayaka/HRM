
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class DepartmentDeviceboxModel : RequestBaseModel
    {
        [Key]
        public string DPDB_CustomerID { get; set; }
        public string DPDB_DepartmentID { get; set; }
        public string DPDB_DeviceNo { get; set; }
        public string DPDB_BoxNo { get; set; }
        public string DPDB_DeviceTypeNo { get; set; }
        public string DPDB_VendorID { get; set; }
        public string USER_ID { get; set; }

        public bool DPDB_Status { get; set; }


    }
    public class ReturnDepartmentDeviceboxModel
    {
        [Key]
        public string DPDB_CustomerID { get; set; }
        public string CUS_CompanyName { get; set; }
        public string DPDB_DepartmentID { get; set; }
        public string DPT_Name { get; set; }
        public string DPDB_DeviceNo { get; set; }
        public string DV_Name { get; set; }
        public string DPDB_BoxNo { get; set; }
        public string DPDB_DeviceTypeNo { get; set; }
        public string DT_Name { get; set; }
        public string DPDB_VendorID { get; set; }
        public string KV_CompanyName { get; set; }

        public string DPDB_Status { get; set; }
        public string DPDB_CreatedBy { get; set; }
        public string DPDB_CreatedDateTime { get; set; }
        public string DPDB_ModifiedBy { get; set; }
        public string DPDB_ModifiedDateTime { get; set; }

        public string RC { get; set; }
    }

    public class ReturnDepartmentDeviceboxAllModel
    {
        [Key]
        public string DPT_ID { get; set; }
        public string DPT_Name { get; set; }
        public string DPT_CPCode { get; set; }
        public string BU_CompanyName { get; set; }
        public string CUS_CompanyName { get; set; }
        public string DPT_Status { get; set; }
        public string RC { get; set; }

    }

    public class InactiveDepartmentDeviceboxModel : RequestBaseModel
    {

        public string DPDB_CustomerID { get; set; }
        public string DPDB_DepartmentID { get; set; }
        public string DPDB_DeviceNo { get; set; }
        public string DPDB_BoxNo { get; set; }
        public string USER_ID { get; set; }
    }

    public class GetDepartmentDeviceboxAllModel : RequestBaseModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string CUS_CompanyName { get; set; }
        public string DPT_Name { get; set; }
        public string DPDB_DeviceNo { get; set; }
        public string DPDB_BoxNo { get; set; }
        public string KV_CompanyName { get; set; }
        public string DPDB_Status { get; set; }



    }
    public class GetDepartmentDeviceboxSingleModel : RequestBaseModel
    {

        public string DPDB_CustomerID { get; set; }
        public string DPDB_DepartmentID { get; set; }
        public string DPDB_DeviceNo { get; set; }
        public string DPDB_BoxNo { get; set; }

    }

    public class ReturDepartmentDeviceboxModelHead : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnDepartmentDeviceboxModel> DepartmentDB { get; set; }


    }
    public class ReturDepartmentDeviceboxAllModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnDepartmentDeviceboxAllModel> departmentdevall { get; set; }


    }







}
