using System;

namespace HRM_DAL.Models
{
    public class ResetPassword
    {
        public string customerId { get; set; }  //
        public string userId { get; set; }  //tbl_user_profile_map.UPM_UserID
        public string userType { get; set; }  //tbl_user_profile_map.UPM_Type
        public string deviceNo { get; set; }  //tbl_department_devicebox.DPDB_DeviceNo
        public string deviceTypeId { get; set; }    //tbl_department_devicebox.DPDB_DeviceTypeNo
        public string vendorId { get; set; }    //tbl_department_devicebox.DPDB_VendorID
        public string locationId { get; set; }  //tbl_location.LOC_ID
        public DateTime requestedDateTime { get; set; }
    }
}
