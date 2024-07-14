using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System;

namespace HRM_BL
{
    public class Recieve_BL
    {
        private static LogError objError = new LogError();


        public static List<ReceiveSummeryHeaderModel> get_batch_details(ProcessRequestQRStringModel BatchNo)
        {
            return HRM_DAL.Data.Recieve_Data.get_batch_details(BatchNo);
        }

        public static List<ReceiveGridViewHeaderModel> get_batch_grid_details(ReceiveGridRequestBatchNoModel gridmodel)
        {
            return HRM_DAL.Data.Recieve_Data.get_batch_grid_details(gridmodel);
        }

        public static List<ReceiveCreateNewBatchHeaderModel> create_new_batch(ReceiveCreateNewBatchModel model)
        {
            return HRM_DAL.Data.Recieve_Data.create_new_batch(model);
        }

        public static List<ReceiveSubmitBatchModel> insert_batch_submit(ReceiveSubmitBatchNoModel model)
        {
            return HRM_DAL.Data.Recieve_Data.insert_batch_submit(model);
        }

        public static List<ReceiveSummeryHeaderModel> get_receiving_pending(ReceivePendingModel model)
        {
            return HRM_DAL.Data.Recieve_Data.get_receiving_pending(model);
        }

        public static List<ServerDateTimeHeaderModel> get_server_Datetime(RequestBaseModel model)
        {
            return HRM_DAL.Data.Recieve_Data.get_server_Datetime(model);
        }

        public static List<ReportsReturnResponse_Image> PrintQRSticker(ReceiveRequestBatchNoModel model)
        {
            return HRM_DAL.Data.Recieve_Data.PrintQRSticker(model);
        }

        public static List<ReceiveSubmitBatchModel> ClearForm_Receive(ReceiveDeleteBatchNoModel model)
        {
            return HRM_DAL.Data.Recieve_Data.ClearForm_Receive(model);
        }
    }
}