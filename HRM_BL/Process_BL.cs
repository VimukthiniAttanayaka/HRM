using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System;

namespace HRM_BL
{
    public class Process_BL
    {
        private static LogError objError = new LogError();


        public static List<ProcessSummeryHeaderModel> get_batch_details(ProcessRequestBatchNoModel BatchNo)
        {
            return HRM_DAL.Data.Process_Data.get_batch_details(BatchNo);
        }

        public static List<ProcessGridViewHeaderModel> get_batch_grid_details(ProcessGridRequestBatchNoModel gridmodel)
        {
            return HRM_DAL.Data.Process_Data.get_batch_grid_details(gridmodel);
        }

        public static List<ProcessSubmitBatchModel> insert_batch_submit(ProcessSubmitBatchNoModel model)
        {
            return HRM_DAL.Data.Process_Data.insert_batch_submit(model);
        }

        public static List<ProcessSubmitBatchModel> update_process_batch_submit(ProcessSubmitBatchNoModel model)
        {
            return HRM_DAL.Data.Process_Data.update_process_batch_submit(model);
        }

        public static List<FullProcessSummeryHeaderModel> get_batch_full_details(ProcessRequestBatchNoModel BatchNo)
        {
            return HRM_DAL.Data.Process_Data.get_batch_full_details(BatchNo);
        }
    }
}