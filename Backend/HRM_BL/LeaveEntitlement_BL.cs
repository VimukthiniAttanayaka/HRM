using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class LeaveEntitlement_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnLeaveEntitlementModelHead> get_LeaveEntitlements_single(LeaveEntitlement model)//ok
        {
            return HRM_DAL.Data.LeaveEntitlement_Data.get_LeaveEntitlements_single(model);
        }
        public static List<ReturnLeaveEntitlementModelHead> get_LeaveEntitlement_all(LeaveEntitlementSearchModel model)//ok
        {
            return HRM_DAL.Data.LeaveEntitlement_Data.get_LeaveEntitlement_all(model);
        }


        public static List<ReturnResponse> add_new_LeaveEntitlement(LeaveEntitlementModel item)//ok
        {
            return HRM_DAL.Data.LeaveEntitlement_Data.add_new_LeaveEntitlement(item);
        }

        public static List<ReturnResponse> modify_LeaveEntitlement(LeaveEntitlementModel item)//ok
        {
            return HRM_DAL.Data.LeaveEntitlement_Data.modify_LeaveEntitlement(item);
        }

        public static List<ReturnResponse> inactivate_LeaveEntitlement(InactiveLVEModel item)//ok
        {
            return HRM_DAL.Data.LeaveEntitlement_Data.inactivate_LeaveEntitlement(item);
        }


    }

}

