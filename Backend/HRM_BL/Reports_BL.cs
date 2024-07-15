using HRM_DAL.Models;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System;

namespace HRM_BL
{
    public class Reports_BL
    {
        public static List<ReportsReturnResponse> PrintContainerLabelWithQRSticker(PrintContainerRequestModel model)
        {
            return HRM_DAL.Data.Reports_Data.PrintContainerLabelWithQRSticker(model);
        }
    }

}

