
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class DeviceModel : RequestBaseModel
    {
        [Key]
        public string DV_ID { get; set; }
        public string DV_Name { get; set; }
        public string DV_Remarks { get; set; }
        public string DV_VendorID { get; set; }
        public string KV_CompanyName { get; set; }
        public string DV_CustomerID { get; set; }
        public string CUS_CompanyName { get; set; }
        public string DV_LocationID { get; set; }
        public string USER_ID { get; set; }
        public bool DV_Status { get; set; }
        public string DV_DeviceTypeID { get; set; }
        public string DV_Level { get; set; }

    }

    public class ReturnDeviceModel
    {
        [Key]
        public string DV_ID { get; set; }
        public string DV_Name { get; set; }
        public string DV_Remarks { get; set; }
        public string DV_VendorID { get; set; }
        public string KV_CompanyName { get; set; }
        public string DV_CustomerID { get; set; }
        public string CUS_CompanyName { get; set; }
        public string DV_LocationID { get; set; }
        public string LOC_Name { get; set; }

        public string DV_Status { get; set; }
        public string DV_CreatedBy { get; set; }
        public string DV_CreatedDateTime { get; set; }
        public string DV_ModifiedBy { get; set; }
        public string DV_ModifiedDateTime { get; set; }
        public string RC { get; set; }
        public string DV_DeviceTypeID { get; set; }
        public string DT_Name { get; set; }
        public string DV_Level { get; set; }
    }

    public class ReturnDeviceAllModel
    {
        [Key]
        public string DV_ID { get; set; }
        public string DV_Name { get; set; }
        public string KV_CompanyName { get; set; }
        public string CUS_CompanyName { get; set; }
        public string BU_CompanyName { get; set; }
        public string LOC_Name { get; set; }
        public string DV_Status { get; set; }
        public string DV_Level { get; set; }
        public string RC { get; set; }

    }

    public class InactiveDeviceModel : RequestBaseModel
    {

        public string DV_ID { get; set; }
        public string USER_ID { get; set; }
    }

    public class GetDeviceAllModel : RequestBaseModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string DV_ID { get; set; }
        public string DV_Name { get; set; }
        public string KV_CompanyName { get; set; }
        public string CUS_CompanyName { get; set; }
        public string DV_VendorID { get; set; }
        public string DV_DeviceTypeID { get; set; }
        public string LOC_Name { get; set; }
        public string DV_Status { get; set; }
        public string DV_Level { get; set; }



    }
    public class GetDeviceSingleModel : RequestBaseModel
    {

        public string DV_ID { get; set; }

    }

    public class ReturDeviceModelHead : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnDeviceModel> Device { get; set; }


    }
    public class ReturDeviceAllModelHead : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnDeviceAllModel> Device { get; set; }


    }







}
