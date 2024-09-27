using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class SalaryType_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnSalaryTypeModelHead> get_SalaryTypes_single(SalaryType model)//ok
        {
            return HRM_DAL.Data.SalaryType_Data.get_SalaryTypes_single(model);
        }
        public static List<ReturnSalaryTypeModelHead> get_SalaryType_all(SalaryTypeSearchModel model)//ok
        {
            return HRM_DAL.Data.SalaryType_Data.get_SalaryType_all(model);
        }


        public static List<ReturnResponse> add_new_SalaryType(SalaryTypeModel item)//ok
        {
            return HRM_DAL.Data.SalaryType_Data.add_new_SalaryType(item);
        }

        public static List<ReturnResponse> modify_SalaryType(SalaryTypeModel item)//ok
        {
            return HRM_DAL.Data.SalaryType_Data.modify_SalaryType(item);
        }

        public static List<ReturnResponse> inactivate_SalaryType(InactiveMDSTModel item)//ok
        {
            return HRM_DAL.Data.SalaryType_Data.inactivate_SalaryType(item);
        }


    }

}

