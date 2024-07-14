using HRM_DAL.Models;
using HRM_BL;
using error_handler;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using email_sender;
using sms_core;
using System;
using HRM_DAL.Data;
using static HRM_DAL.Data.LogExcelUploadTracer_Data;

namespace HRM_BL
{
    public class LogExcelUploadTracer_BL
    {
        private static LogError objError = new LogError();

        public static SearchTracerResponceModel SearchTracer(SearchTracerRequestModel model)
        {
            SearchTracerResponceModel objRtnOTPHeadList = new SearchTracerResponceModel();

            try
            {
                objRtnOTPHeadList= LogExcelUploadTracer_Data.SearchTracer(model);
                return objRtnOTPHeadList;
            }
            catch (Exception ex)
            {
                objRtnOTPHeadList = new SearchTracerResponceModel
  {
                    resp = false,
                    msg = ex.Message
                };

                objError.WriteLog(0, "LogExcelUploadTracer_BL", "SearchTracer", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LogExcelUploadTracer_BL", "SearchTracer", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LogExcelUploadTracer_BL", "SearchTracer", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LogExcelUploadTracer_BL", "SearchTracer", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objRtnOTPHeadList;
        }
    }
}
