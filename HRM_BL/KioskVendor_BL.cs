using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class KioskVendor_BL 
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_kiosk_vendor(KVMasterModel item)//ok
        {
            return HRM_DAL.Data.KioskVendor_Data.add_new_kiosk_vendor(item);
        }

        public static List<ReturnResponse> modify_kiosk_vendor(KVMasterModel item)//ok
        {
            return HRM_DAL.Data.KioskVendor_Data.modify_kiosk_vendor(item);
        }

        public static List<ReturnResponse> inactivate_kiosk_vendor(InactiveKVMasterModel item)//ok
        {
            return HRM_DAL.Data.KioskVendor_Data.inactivate_kiosk_vendor(item);
        }

        public static List<ReturKVModelHead> get_kiosk_vendor_all(GetKVMasterAllModel KVall)//ok
        {
            return HRM_DAL.Data.KioskVendor_Data.get_kiosk_vendor_all(KVall);
        }

        public static List<ReturKVModelHead> get_kiosk_vendor_single(GetKVMasterModel KVsingle)
        {
            return HRM_DAL.Data.KioskVendor_Data.get_kiosk_vendor_single(KVsingle);
        }

    }
}








