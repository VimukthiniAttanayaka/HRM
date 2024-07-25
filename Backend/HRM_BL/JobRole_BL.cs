using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class JobRole_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnJobRoleModelHead> get_JobRoles_single(JobRole model)//ok
        {
            return HRM_DAL.Data.JobRole_Data.get_JobRoles_single(model);
        }
        public static List<ReturnJobRoleModelHead> get_JobRole_all(JobRoleSearchModel model)//ok
        {
            return HRM_DAL.Data.JobRole_Data.get_JobRole_all(model);
        }


        public static List<ReturncustResponse> add_new_JobRole(JobRoleModel item)//ok
        {
            return HRM_DAL.Data.JobRole_Data.add_new_JobRole(item);
        }

        public static List<ReturncustResponse> modify_JobRole(JobRoleModel item)//ok
        {
            return HRM_DAL.Data.JobRole_Data.modify_JobRole(item);
        }

        public static List<ReturnResponse> inactivate_JobRole(InactiveMDJRModel item)//ok
        {
            return HRM_DAL.Data.JobRole_Data.inactivate_JobRole(item);
        }


    }

}

