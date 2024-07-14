using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class DeviceType_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_device_type(DeviceTypeModel item)//ok
        {
            return HRM_DAL.Data.DeviceType_Data.add_new_device_type(item);
        }


        public static List<ReturnResponse> modify_device_type(DeviceTypeModel item)//ok
        {
            return HRM_DAL.Data.DeviceType_Data.modify_device_type(item);
        }

        public static List<ReturnResponse> inactivate_device_type(InactiveDeviceTypeModel item)//ok
        {
            return HRM_DAL.Data.DeviceType_Data.inactivate_device_type(item);
        }

        public static List<ReturnDeviceTypeModelHead> get_device_type_all(GetDeviceTypeAllModel DTall)//ok
        {
            return HRM_DAL.Data.DeviceType_Data.get_device_type_all(DTall);
        }

        public static List<ReturnDeviceTypeModelHead> get_device_type_single(GetDeviceTypesingleModel DTsingle)
        {
            return HRM_DAL.Data.DeviceType_Data.get_device_type_single(DTsingle);
        }



    }




}








