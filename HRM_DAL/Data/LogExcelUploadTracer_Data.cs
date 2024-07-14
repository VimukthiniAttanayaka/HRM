using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class LogExcelUploadTracer_Data
    {
        private static LogError objError = new LogError();

        public static void User(ReturUserExcelUploadHead item, UserExcelUploadModel model)
        {
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_insert_excel_upload_data_tracer";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CUST_ID", model.DPT_CustomerID);
                        cmd.Parameters["@CUST_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@IMPORT_FILE_TYPE", "Staff");
                        cmd.Parameters["@IMPORT_FILE_TYPE"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@FULL_LIST", model.IsCompleteList);
                        cmd.Parameters["@FULL_LIST"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@IMPORTED_BY", model.USER_ID);
                        cmd.Parameters["@IMPORTED_BY"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@STATUS", item.msg);
                        cmd.Parameters["@STATUS"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UPLOADED_EXCEL_URL", item.FileNameWithPath);
                        cmd.Parameters["@UPLOADED_EXCEL_URL"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UPLOADED_EXCEL_NAME", item.FileName);
                        cmd.Parameters["@UPLOADED_EXCEL_NAME"].Direction = ParameterDirection.Input;

                        //RESPECTIVE_LOG_FILES = rdr["RESPECTIVE_LOG_FILES"].ToString(),

                        cmd.Parameters.AddWithValue("@SUCCESS_RECORD_COUNT", item.success_users.Count);
                        cmd.Parameters["@SUCCESS_RECORD_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ERROR_RECORD_COUNT", item.failed_users.Count);
                        cmd.Parameters["@ERROR_RECORD_COUNT"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);
                    }
                }
            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "LogExcelUploadTracer_Data", "User", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LogExcelUploadTracer_Data", "User", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LogExcelUploadTracer_Data", "User", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LogExcelUploadTracer_Data", "User", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
        }

        public static SearchTracerResponceModel SearchTracer(SearchTracerRequestModel item)
        {
            SearchTracerResponceModel ret = new SearchTracerResponceModel();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_search_excel_upload_data_tracer";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CUST_ID", item.CUST_ID);
                        cmd.Parameters["@CUST_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@IMPORT_FILE_TYPE", item.IMPORT_FILE_TYPE);
                        cmd.Parameters["@IMPORT_FILE_TYPE"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@FULL_LIST", item.FULL_LIST);
                        cmd.Parameters["@FULL_LIST"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@IMPORTED_DATE", item.IMPORTED_DATE);
                        cmd.Parameters["@IMPORTED_DATE"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@IMPORTED_BY", item.IMPORTED_BY);
                        cmd.Parameters["@IMPORTED_BY"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@STATUS", item.STATUS);
                        cmd.Parameters["@STATUS"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ret = new SearchTracerResponceModel
                                {
                                    resp = true,
                                    msg = "SearchTracer",
                                };
                                ret.list.Add(new SearchTracerResponce()
                                {
                                    CUST_ID = rdr["CUST_ID"].ToString(),
                                    IMPORT_FILE_TYPE = rdr["IMPORT_FILE_TYPE"].ToString(),
                                    FULL_LIST = rdr["FULL_LIST"].ToString(),
                                    IMPORTED_DATE = rdr["IMPORTED_DATE"].ToString(),
                                    IMPORTED_BY = rdr["IMPORTED_BY"].ToString(),
                                    UPLOADED_EXCEL_NAME = rdr["UPLOADED_EXCEL_NAME"].ToString(),
                                    UPLOADED_EXCEL_URL = rdr["UPLOADED_EXCEL_URL"].ToString(),
                                    //RESPECTIVE_LOG_FILES = rdr["RESPECTIVE_LOG_FILES"].ToString(),
                                    STATUS = rdr["STATUS"].ToString(),
                                    SUCCESS_RECORD_COUNT = rdr["SUCCESS_RECORD_COUNT"].ToString(),
                                    ERROR_RECORD_COUNT = rdr["ERROR_RECORD_COUNT"].ToString(),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ret = new SearchTracerResponceModel
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };

                objError.WriteLog(0, "LogExcelUploadTracer_Data", "SearchTracer", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LogExcelUploadTracer_Data", "SearchTracer", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LogExcelUploadTracer_Data", "SearchTracer", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LogExcelUploadTracer_Data", "SearchTracer", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return ret;
        }
    }

    public class SearchTracerResponceModel : ReturnResponse
    {
        public List<SearchTracerResponce> list { get; set; } = new List<SearchTracerResponce>();
    }

    public class SearchTracerResponce
    {
        public string CUST_ID { get; set; }
        public string IMPORT_FILE_TYPE { get; set; }
        public string FULL_LIST { get; set; }
        public string IMPORTED_DATE { get; set; }
        public string IMPORTED_BY { get; set; }
        public string UPLOADED_EXCEL_NAME { get; set; }
        public string RESPECTIVE_LOG_FILES { get; set; }
        public string STATUS { get; set; }
        public string SUCCESS_RECORD_COUNT { get; set; }
        public string ERROR_RECORD_COUNT { get; set; }
        public string UPLOADED_EXCEL_URL { get; set; }
    }

    public class SearchTracerRequestModel : RequestBaseModel
    {
        public string CUST_ID { get; set; }
        public string IMPORT_FILE_TYPE { get; set; }
        public string FULL_LIST { get; set; }
        public string IMPORTED_DATE { get; set; }
        public string IMPORTED_BY { get; set; }
        public string STATUS { get; set; }
    }
}