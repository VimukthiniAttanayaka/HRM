using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class Device_BL 
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_device(DeviceModel item)//ok
        {
            return HRM_DAL.Data.Device_Data.add_new_device(item);
        }

        public static List<ReturnResponse> modify_device(DeviceModel item)//ok
        {
            return HRM_DAL.Data.Device_Data.modify_device(item);
        }

        public static List<ReturnResponse> inactivate_device(InactiveDeviceModel item)//ok
        {
            return HRM_DAL.Data.Device_Data.inactivate_device(item);
        }

        public static List<ReturDeviceModelHead> get_device_all(GetDeviceAllModel item)//ok
        {
            return HRM_DAL.Data.Device_Data.get_device_all(item);
        }

        public static List<ReturDeviceModelHead> get_device_single(GetDeviceSingleModel item)
        {
            return HRM_DAL.Data.Device_Data.get_device_single(item);
        }
    }
}








