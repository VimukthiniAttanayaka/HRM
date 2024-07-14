using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class DepartmentDevicebox_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_departmentdevicebox(DepartmentDeviceboxModel item)//ok
        {
            return HRM_DAL.Data.DepartmentDevicebox_Data.add_new_departmentdevicebox(item);
        }

        public static List<ReturnResponse> modify_departmentdevicebox(DepartmentDeviceboxModel item)//ok
        {
            return HRM_DAL.Data.DepartmentDevicebox_Data.modify_departmentdevicebox(item);
        }

        public static List<ReturnResponse> inactivate_departmentdevicebox(InactiveDepartmentDeviceboxModel item)//ok
        {
            return HRM_DAL.Data.DepartmentDevicebox_Data.inactivate_departmentdevicebox(item);
        }

        public static List<ReturDepartmentDeviceboxModelHead> get_departmentdevicebox_all(GetDepartmentDeviceboxAllModel item)//ok
        {
            return HRM_DAL.Data.DepartmentDevicebox_Data.get_departmentdevicebox_all(item);
        }

        public static List<ReturDepartmentDeviceboxModelHead> get_departmentdevicebox_single(GetDepartmentDeviceboxSingleModel item)
        {
            return HRM_DAL.Data.DepartmentDevicebox_Data.get_departmentdevicebox_single(item);
        }



    }








}








