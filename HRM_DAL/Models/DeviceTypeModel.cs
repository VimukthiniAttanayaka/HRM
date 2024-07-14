
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM_DAL.Models
{
    public class DeviceTypeModel : RequestBaseModel
    {
        [Key]
        public string DT_ID { get; set; }
        public string DT_Name { get; set; }
        public string USER_ID { get; set; }
        public bool DT_Status { get; set; }

    }
    public class ReturnDeviceTypeModel
    {
        [Key]
        public string DT_ID { get; set; }
        public string DT_Name { get; set; }
        public string DT_Status { get; set; }
        public string DT_CreatedBy { get; set; }
        public string DT_CreatedDateTime { get; set; }
        public string DT_ModifiedBy { get; set; }
        public string DT_ModifiedDateTime { get; set; }
        public string RC { get; set; }
    }
    public class ReturnDeviceTypeAllModel
    {
        [Key]
        public string DT_ID { get; set; }
        public string DT_Name { get; set; }
        public string DT_Status { get; set; }
        public string RC { get; set; }


    }

    public class InactiveDeviceTypeModel : RequestBaseModel
    {

        public string DT_ID { get; set; }
        public string USER_ID { get; set; }
    }

    public class GetDeviceTypeAllModel : RequestBaseModel
    {

        public string PAGE_NO { get; set; }
        public string PAGE_RECORDS_COUNT { get; set; }
        public string DT_ID { get; set; }
        public string DT_Name { get; set; }
        public string DT_Status { get; set; }
    }
    public class GetDeviceTypesingleModel : RequestBaseModel
    {

        public string DT_ID { get; set; }

    }

    public class ReturnDeviceTypeModelHead : ReturnResponse
    {
        //public bool resp { get; set; }
        //public string msg { get; set; }
        public List<ReturnDeviceTypeModel> DeviceType { get; set; }


    }

    public class ReturnDeviceTypeAllModelHead
    {
        public bool resp { get; set; }
        public string msg { get; set; }
        public List<ReturnDeviceTypeAllModel> devicetypeall { get; set; }


    }







}
