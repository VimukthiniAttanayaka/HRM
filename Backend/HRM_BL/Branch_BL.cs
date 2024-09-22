using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class Branch_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnBranchModelHead> get_Branchs_single(Branch model)//ok
        {
            return HRM_DAL.Data.Branch_Data.get_Branchs_single(model);
        }
        public static List<ReturnBranchModelHead> get_Branch_all(BranchSearchModel model)//ok
        {
            return HRM_DAL.Data.Branch_Data.get_Branch_all(model);
        }


        public static List<ReturnResponse> add_new_Branch(BranchModel item)//ok
        {
            return HRM_DAL.Data.Branch_Data.add_new_Branch(item);
        }

        public static List<ReturnResponse> modify_Branch(BranchModel item)//ok
        {
            return HRM_DAL.Data.Branch_Data.modify_Branch(item);
        }

        public static List<ReturnResponse> inactivate_Branch(InactiveMDBModel item)//ok
        {
            return HRM_DAL.Data.Branch_Data.inactivate_Branch(item);
        }


    }

}

