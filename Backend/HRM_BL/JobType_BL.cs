using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_BL
{
    public class JobType_BL
    {
        private static LogError objError = new LogError();

        public static List<ReturnJobTypeModelHead> get_JobTypes_single(JobType model)//ok
        {
            return HRM_DAL.Data.JobType_Data.get_JobTypes_single(model);
        }
        public static List<ReturnJobTypeModelHead> get_JobType_all(JobTypeSearchModel model)//ok
        {
            return HRM_DAL.Data.JobType_Data.get_JobType_all(model);
        }


        public static List<ReturnResponse> add_new_JobType(JobTypeModel item)//ok
        {
            return HRM_DAL.Data.JobType_Data.add_new_JobType(item);
        }

        public static List<ReturnResponse> modify_JobType(JobTypeModel item)//ok
        {
            return HRM_DAL.Data.JobType_Data.modify_JobType(item);
        }

        public static List<ReturnResponse> inactivate_JobType(InactiveMDJTModel item)//ok
        {
            return HRM_DAL.Data.JobType_Data.inactivate_JobType(item);
        }


    }

}

