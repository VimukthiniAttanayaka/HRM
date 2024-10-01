using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class EmployeeLeaveEntitlement_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnEmployeeLeaveEntitlementModelHead> get_EmployeeLeaveEntitlement_single(EmployeeLeaveEntitlement model)//ok
        {
            return HRM_DAL.Data.EmployeeLeaveEntitlement_Data.get_EmployeeLeaveEntitlement_single(model);
        }
        public static List<ReturnEmployeeLeaveEntitlementModelHead> get_EmployeeLeaveEntitlement_all(EmployeeLeaveEntitlementSearchModel model)//ok
        {
            return HRM_DAL.Data.EmployeeLeaveEntitlement_Data.get_EmployeeLeaveEntitlement_all(model);
        }


        public static List<ReturnResponse> add_new_EmployeeLeaveEntitlement(EmployeeLeaveEntitlementModel item)//ok
        {
            return HRM_DAL.Data.EmployeeLeaveEntitlement_Data.add_new_EmployeeLeaveEntitlement(item);
        }

        public static List<ReturnResponse> modify_EmployeeLeaveEntitlement(EmployeeLeaveEntitlementModel item)//ok
        {
            return HRM_DAL.Data.EmployeeLeaveEntitlement_Data.modify_EmployeeLeaveEntitlement(item);
        }

        public static List<ReturnResponse> inactivate_EmployeeLeaveEntitlement(InactiveEELEModel item)//ok
        {
            return HRM_DAL.Data.EmployeeLeaveEntitlement_Data.inactivate_EmployeeLeaveEntitlement(item);
        }


    }

}

