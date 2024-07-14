using error_handler;
using HRM_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class Exceptions_Data
    {
        private static LogError objError = new LogError();

        public static List<ExceptionsHeaderResponceModel> modify_exceptions(ExceptionsSubmitModel item)
        {
            List<ExceptionsHeaderResponceModel> objExceptionsHeadList = new List<ExceptionsHeaderResponceModel>();
            ExceptionsHeaderResponceModel objExceptionsHead = new ExceptionsHeaderResponceModel();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objExceptionsHead.resp = false;
                objExceptionsHead.IsAuthenticated = false;
                objExceptionsHeadList.Add(objExceptionsHead);
                return objExceptionsHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_upate_exceptions";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BatchNo", item.BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TransactionDate", item.TransactionDate);
                        cmd.Parameters["@TransactionDate"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Location", item.Location);
                        cmd.Parameters["@Location"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@KioskID", item.KioskID);
                        cmd.Parameters["@KioskID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@StaffName", item.StaffName);
                        cmd.Parameters["@StaffName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PCCode", item.PCCode);
                        cmd.Parameters["@PCCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MailType", item.MailType);
                        cmd.Parameters["@MailType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ProcessStage", item.ProcessStage);
                        cmd.Parameters["@ProcessStage"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ExceptionType", item.ExceptionType);
                        cmd.Parameters["@ExceptionType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ExceptionStatus", item.ExceptionStatus);
                        cmd.Parameters["@ExceptionStatus"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DeclaredQty", item.DeclaredQty);
                        cmd.Parameters["@DeclaredQty"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ReceivedQty", item.ReceivedQty);
                        cmd.Parameters["@ReceivedQty"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CreatedBy", item.CreatedBy);
                        cmd.Parameters["@CreatedBy"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_ID", item.CUS_ID);
                        //cmd.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                if (Ds.Tables[0].Columns.Contains("RTN_RESP"))
                                {
                                    objExceptionsHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objExceptionsHead.msg = rdr["RTN_MSG"].ToString();
                                }
                            }

                            if (Ds.Tables.Count > 1)
                            {
                                objExceptionsHead.resp = true;
                                objExceptionsHead.msg = "";

                                foreach (DataRow rdr in Ds.Tables[1].Rows)
                                {
                                    DateTime trdate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["TransactionDate"].ToString(), out trdate);

                                    decimal decQty = 0;
                                    decimal.TryParse(rdr["Declared_Qty"].ToString(), out decQty);

                                    decimal recQty = 0;
                                    decimal.TryParse(rdr["Received_Qty"].ToString(), out recQty);

                                    ExceptionsResponceModel objExceptionsDetail = new ExceptionsResponceModel()
                                    {
                                        BatchNo = rdr["BatchNumber"].ToString(),
                                        TransactionDate = trdate,
                                        Location = rdr["Location"].ToString(),
                                        LocationID = rdr["LocationID"].ToString(),
                                        KioskID = rdr["KioskID"].ToString(),
                                        StaffName = rdr["StaffName"].ToString(),
                                        Staff_ID = rdr["Staff_ID"].ToString(),
                                        PCCode = rdr["PCCode"].ToString(),
                                        MailType = rdr["MailType"].ToString(),
                                        MailTypeID = rdr["MailTypeID"].ToString(),
                                        ProcessStage = rdr["ProcessStage"].ToString(),
                                        ExceptionType = rdr["ExceptionType"].ToString(),
                                        ExceptionStatus = rdr["ExceptionStatus"].ToString(),
                                        DeclaredQty = decQty,
                                        ReceivedQty = recQty,
                                    };
                                    objExceptionsHead.ExceptionsResponceModelList.Add(objExceptionsDetail);
                                }
                            }
                            objExceptionsHeadList.Add(objExceptionsHead);
                        }
                        else
                        {
                            objExceptionsHead.resp = true;
                            objExceptionsHead.msg = "";
                            objExceptionsHeadList.Add(objExceptionsHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objExceptionsHead.resp = false;
                objExceptionsHead.msg = ex.Message.ToString();

                objExceptionsHeadList.Add(objExceptionsHead);

                objError.WriteLog(0, "Exceptions_Data", "modify_exceptions", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Exceptions_Data", "modify_exceptions", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Exceptions_Data", "modify_exceptions", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Exceptions_Data", "modify_exceptions", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objExceptionsHeadList;
        }

        public static List<ExceptionsStatusHeaderResponceModel> modify_exceptionstatus(ExceptionsStatusSubmitModel item)
        {
            List<ExceptionsStatusHeaderResponceModel> objExceptionsHeadList = new List<ExceptionsStatusHeaderResponceModel>();
            ExceptionsStatusHeaderResponceModel objExceptionsHead = new ExceptionsStatusHeaderResponceModel();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objExceptionsHead.resp = false;
                objExceptionsHead.IsAuthenticated = false;
                objExceptionsHeadList.Add(objExceptionsHead);
                return objExceptionsHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_upate_exceptionstatus";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BatchNo", item.BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ExceptionStatus", item.ExceptionStatus);
                        cmd.Parameters["@ExceptionStatus"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CreatedBy", item.CreatedBy);
                        cmd.Parameters["@CreatedBy"].Direction = ParameterDirection.Input;


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                if (Ds.Tables[0].Columns.Contains("RTN_RESP"))
                                {
                                    objExceptionsHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objExceptionsHead.msg = rdr["RTN_MSG"].ToString();
                                }
                                else
                                {

                                }

                            }
                            objExceptionsHeadList.Add(objExceptionsHead);
                        }
                        else
                        {
                            objExceptionsHead.resp = true;
                            objExceptionsHead.msg = "";
                            objExceptionsHeadList.Add(objExceptionsHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objExceptionsHead.resp = false;
                objExceptionsHead.msg = ex.Message.ToString();

                objExceptionsHeadList.Add(objExceptionsHead);

                objError.WriteLog(0, "Exceptions_Data", "modify_exceptions", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Exceptions_Data", "modify_exceptions", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Exceptions_Data", "modify_exceptions", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Exceptions_Data", "modify_exceptions", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objExceptionsHeadList;
        }

        public static List<ExceptionsHeaderResponceModel> get_exceptions_details(ExceptionsRequestModel item)
        {
            List<ExceptionsHeaderResponceModel> objExceptionsHeadList = new List<ExceptionsHeaderResponceModel>();
            ExceptionsHeaderResponceModel objExceptionsHead = new ExceptionsHeaderResponceModel();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objExceptionsHead.resp = false;
                objExceptionsHead.IsAuthenticated = false;
                objExceptionsHeadList.Add(objExceptionsHead);
                return objExceptionsHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_exceptions_details";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BatchNo", item.BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_ID", item.CUS_ID);
                        //cmd.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                if (Ds.Tables[0].Columns.Contains("RTN_RESP"))
                                {
                                    objExceptionsHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objExceptionsHead.msg = rdr["RTN_MSG"].ToString();
                                }
                                else
                                {
                                    objExceptionsHead.resp = true;
                                    objExceptionsHead.msg = "";

                                    DateTime trdate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["TransactionDate"].ToString(), out trdate);

                                    decimal decQty = 0;
                                    decimal.TryParse(rdr["Declared_Qty"].ToString(), out decQty);

                                    decimal recQty = 0;
                                    decimal.TryParse(rdr["Received_Qty"].ToString(), out recQty);

                                    ExceptionsResponceModel objExceptionsDetail = new ExceptionsResponceModel()
                                    {
                                        BatchNo = rdr["BatchNumber"].ToString(),
                                        TransactionDate = trdate,
                                        Location = rdr["Location"].ToString(),
                                        LocationID = rdr["LocationID"].ToString(),
                                        KioskID = rdr["KioskID"].ToString(),
                                        StaffName = rdr["StaffName"].ToString(),
                                        Staff_ID = rdr["Staff_ID"].ToString(),
                                        PCCode = rdr["PCCode"].ToString(),
                                        MailType = rdr["MailType"].ToString(),
                                        MailTypeID = rdr["MailTypeID"].ToString(),
                                        ProcessStage = rdr["ProcessStage"].ToString(),
                                        ExceptionType = rdr["ExceptionType"].ToString(),
                                        ExceptionStatus = rdr["ExceptionStatus"].ToString(),
                                        DeclaredQty = decQty,
                                        ReceivedQty = recQty,
                                    };
                                    objExceptionsHead.ExceptionsResponceModelList.Add(objExceptionsDetail);
                                }

                            }
                            objExceptionsHeadList.Add(objExceptionsHead);
                        }
                        else
                        {
                            objExceptionsHead.resp = true;
                            objExceptionsHead.msg = "";
                            objExceptionsHeadList.Add(objExceptionsHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objExceptionsHead.resp = false;
                objExceptionsHead.msg = ex.Message.ToString();

                objExceptionsHeadList.Add(objExceptionsHead);

                objError.WriteLog(0, "Exceptions_Data", "get_exceptions_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Exceptions_Data", "get_exceptions_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Exceptions_Data", "get_exceptions_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Exceptions_Data", "get_exceptions_details", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objExceptionsHeadList;
        }

        public static List<ExceptionsGridViewHeaderModel> get_exceptions_grid_details(ExceptionsGridRequestModel item)
        {
            List<ExceptionsGridViewHeaderModel> objExceptionsHeadList = new List<ExceptionsGridViewHeaderModel>();
            ExceptionsGridViewHeaderModel objExceptionsHead = new ExceptionsGridViewHeaderModel();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objExceptionsHead.resp = false;
                objExceptionsHead.IsAuthenticated = false;
                objExceptionsHeadList.Add(objExceptionsHead);
                return objExceptionsHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_exceptions_grid_details";
                        cmd.CommandType = CommandType.StoredProcedure;



                        cmd.Parameters.AddWithValue("@BatchNo", item.BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TransactionDate", item.TransactionDate);
                        cmd.Parameters["@TransactionDate"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Staff_ID", item.Staff_ID);
                        cmd.Parameters["@Staff_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PCCode", item.PCCode);
                        cmd.Parameters["@PCCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MailTypeID", item.MailTypeID);
                        cmd.Parameters["@MailTypeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ProcessStage", item.ProcessStage);
                        cmd.Parameters["@ProcessStage"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ExceptionType", item.ExceptionType);
                        cmd.Parameters["@ExceptionType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ExceptionStatus", item.ExceptionStatus);
                        cmd.Parameters["@ExceptionStatus"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_ID", item.CUS_ID);
                        //cmd.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_NO", item.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", item.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        string RC;
                        using (SqlConnection lconn1 = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                        {
                            using (SqlCommand cmdrc = new SqlCommand())
                            {
                                lconn1.Open();
                                cmdrc.Connection = lconn1;

                                cmdrc.CommandText = "sp_get_OutgoingMailTransactionDetail_count";
                                cmdrc.CommandType = CommandType.StoredProcedure;

                                //cmdrc.Parameters.AddWithValue("@CUS_ID", item.CUS_ID);
                                //cmdrc.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

                                SqlDataReader rdrrc = cmdrc.ExecuteReader();
                                rdrrc.Read();
                                RC = rdrrc["RC"].ToString();
                            }
                        }

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                if (Ds.Tables[0].Columns.Contains("RTN_RESP"))
                                {
                                    objExceptionsHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objExceptionsHead.msg = rdr["RTN_MSG"].ToString();
                                }
                                else
                                {
                                    DateTime trdate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["TransactionDate"].ToString(), out trdate);

                                    objExceptionsHead.resp = true;
                                    objExceptionsHead.msg = "Exceptions";

                                    ExceptionsGridViewModel objExceptionsDetail = new ExceptionsGridViewModel()
                                    {
                                        BatchNo = rdr["BatchNumber"].ToString(),
                                        TransactionDate = trdate,
                                        StaffName = rdr["StaffName"].ToString(),
                                        Staff_ID = rdr["Staff_ID"].ToString(),
                                        PCCode = rdr["PCCode"].ToString(),
                                        MailType = rdr["MailType"].ToString(),
                                        MailTypeID = rdr["MailTypeID"].ToString(),
                                        ProcessStage = rdr["ProcessStage"].ToString(),
                                        ExceptionType = rdr["ExceptionType"].ToString(),
                                        ExceptionStatus = rdr["ExceptionStatus"].ToString(),
                                        DepartmentID = rdr["DepartmentID"].ToString(),
                                        KioskID = rdr["KioskID"].ToString(),
                                        DeviceTypeID = rdr["DeviceTypeID"].ToString(),
                                        VendorID = rdr["VendorID"].ToString(),
                                        LocationID = rdr["LocationID"].ToString(),
                                        Location = rdr["Location"].ToString(),
                                        Declared_Qty = rdr["Declared_Qty"].ToString(),
                                        Received_Qty = rdr["Received_Qty"].ToString(),
                                        Status = rdr["Status"].ToString(),
                                        ServerSyncDatetime = rdr["ServerSyncDatetime"].ToString(),
                                        Processing_Date = rdr["Processing_Date"].ToString(),
                                        IsOffline = rdr["IsOffline"].ToString(),
                                        IsManualBatch = rdr["IsManualBatch"].ToString(),
                                        IsManualBatchDataSync = rdr["IsManualBatchDataSync"].ToString(),
                                        TransactionSyncDateTime = rdr["TransactionSyncDateTime"].ToString(),
                                        RefBatchNo = rdr["RefBatchNo"].ToString(),
                                        StatusChangedBy = rdr["StatsuChangedBy"].ToString(),
                                        StatusChangedDatetime = rdr["StatusChangedDatetime"].ToString(),
                                        CreatedDatetime = rdr["CreatedDatetime"].ToString(),
                                        CreatedBy = rdr["CreatedBy"].ToString(),
                                        ReceivedDatetime = rdr["ReceivedDatetime"].ToString(),
                                        ReceivedBy = rdr["ReceivedBy"].ToString(),
                                        ProcessedDatetime = rdr["ProcessedDatetime"].ToString(),
                                        ProcessedBy = rdr["ProcessedBy"].ToString(),
                                        FilePathReference_Receiving = rdr["FilePathReference_Receiving"].ToString(),
                                        Processing_ItemLevel_Local_Total = rdr["Processing_ItemLevel_Local_Total"].ToString(),
                                        Processing_ItemLevel_Oversea_Total = rdr["Processing_ItemLevel_Oversea_Total"].ToString(),
                                        FilePathReference_Processing_ItemLevel_Local = rdr["FilePathReference_Processing_ItemLevel_Local"].ToString(),
                                        FilePathReference_Processing_ItemLevel_Oversea = rdr["FilePathReference_Processing_ItemLevel_Oversea"].ToString(),

                                        RC = RC,
                                    };
                                    objExceptionsHead.ExceptionsGridViewModelList.Add(objExceptionsDetail);
                                }

                            }
                            objExceptionsHeadList.Add(objExceptionsHead);
                        }
                        else
                        {
                            objExceptionsHead.resp = true;
                            objExceptionsHead.msg = "";
                            objExceptionsHeadList.Add(objExceptionsHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objExceptionsHead.resp = false;
                objExceptionsHead.msg = ex.Message.ToString();

                objExceptionsHeadList.Add(objExceptionsHead);

                objError.WriteLog(0, "Exceptions_Data", "get_exceptions_grid_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Exceptions_Data", "get_exceptions_grid_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Exceptions_Data", "get_exceptions_grid_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Exceptions_Data", "get_exceptions_grid_details", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objExceptionsHeadList;
        }
    }
}