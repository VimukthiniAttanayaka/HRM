using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class departmentpaymentchargecode_BL
    {
        private static LogError objError = new LogError();
        public static List<ReturnResponse> add_new_departmentpcc(DepartmentPCCModel item)//ok
        {
            return HRM_DAL.Data.DepartmentPaymentChargeCode_Data.add_new_departmentpcc(item);
        }
        public static List<ReturnResponse> modify_departmentpcc(DepartmentPCCModel item)//ok
        {
            return HRM_DAL.Data.DepartmentPaymentChargeCode_Data.modify_departmentpcc(item);
        }

        public static List<ReturnResponse> inactivate_departmentpcc(InactiveDepartmentPCCModel item)//ok
        {
            return HRM_DAL.Data.DepartmentPaymentChargeCode_Data.inactivate_departmentpcc(item);
        }

        public static List<ReturDepartmentPCCModelHead> get_departmentpcc_all(GetDepartmentPCCAllModel item)//ok
        {
            return HRM_DAL.Data.DepartmentPaymentChargeCode_Data.get_departmentpcc_all(item);
        }

        public static List<ReturDepartmentPCCModelHead> get_departmentpcc_single(GetDepartmentPCCSingleModel item)
        {
            return HRM_DAL.Data.DepartmentPaymentChargeCode_Data.get_departmentpcc_single(item);
        }



    }








}








