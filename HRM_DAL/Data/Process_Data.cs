using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using System.IO;
using System.Drawing;
using System.Transactions;
using System.Linq;
using Newtonsoft.Json;


namespace HRM_DAL.Data
{
    public class Process_Data
    {
        private static LogError objError = new LogError();

        public static List<ProcessSummeryHeaderModel> get_batch_details(ProcessRequestBatchNoModel ScannedText)
        {
            List<ProcessSummeryHeaderModel> objUserHeadList = new List<ProcessSummeryHeaderModel>();
            ProcessSummeryHeaderModel objUserHead = new ProcessSummeryHeaderModel();
            objUserHead.ProcessSummeryModelList = new List<ProcessSummeryModel>();

            if (login_Data.AuthenticationKeyValidateWithDB(ScannedText) == false)
            {
                objUserHead.resp = false;
                objUserHead.IsAuthenticated = false;
                objUserHeadList.Add(objUserHead);
                return objUserHeadList;
            }

            try
            {
                if (string.IsNullOrEmpty(ScannedText.BatchNo))
                {
                    objUserHead.resp = false;
                    objUserHead.msg = "QR Code cannot empty";
                    objUserHeadList.Add(objUserHead);
                    return objUserHeadList;
                }

                List<string> spitbyHash = ScannedText.BatchNo.Split('#').ToList();
                string BatchNo = "";
                if (spitbyHash.Count > 0)
                {
                    BatchNo = spitbyHash[0];
                }
                string DeviceNo = "";
                string StaffID = "";
                string MailType = "";
                string DeclaredQuantity = "";
                string PCCode = "";
                string TransactionDate = "";

                //QR Body
                //#1%A03#2%T001#3%R#4%25#5%P0001#6%20220920T10:27:43.10Z

                foreach (var item in spitbyHash)
                {
                    ////#1 - Device No – (A03)
                    //if (item.StartsWith("1%"))
                    //{
                    //    List<string> tempDe = item.Split('%').ToList();
                    //    DeviceNo = tempDe[1];
                    //}
                    //#2 - Staff ID – (T001)
                    if (item.StartsWith("1%"))
                    {
                        List<string> tempDe = item.Split('%').ToList();
                        StaffID = tempDe[1];
                    }
                    //#3 - Mail Type (C - Courier, O - Ordinary, R - Registered)
                    if (item.StartsWith("2%"))
                    {
                        List<string> tempDe = item.Split('%').ToList();
                        MailType = tempDe[1];
                    }
                    //#4 - Declared Quantity - (T001)
                    if (item.StartsWith("3%"))
                    {
                        List<string> tempDe = item.Split('%').ToList();
                        DeclaredQuantity = tempDe[1];
                    }
                    //#5 - PC Code – (P0001)
                    if (item.StartsWith("4%"))
                    {
                        List<string> tempDe = item.Split('%').ToList();
                        PCCode = tempDe[1];
                    }
                    //#6 – Transaction Date – (20220920T10:27:43.10Z)
                    if (item.StartsWith("5%"))
                    {
                        List<string> tempDe = item.Split('%').ToList();
                        TransactionDate = tempDe[1];
                    }
                }

                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_process_batch_details";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BatchNo", BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            objUserHead.resp = true;
                            objUserHead.msg = "";
                            foreach (DataTable rdd in Ds.Tables)
                            {
                                foreach (DataRow rdr in rdd.Rows)
                                {
                                    if (Ds.Tables[0].Columns.Contains("RTN_RESP"))
                                    {
                                        objUserHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                        objUserHead.msg = rdr["RTN_MSG"].ToString();
                                    }
                                    else
                                    {
                                        ProcessSummeryModel objUserDetail = new ProcessSummeryModel()
                                        {
                                            BatchNo = rdr["BatchNumber"].ToString(),
                                            DeviceNo = rdr["DeviceNo"].ToString(),
                                            StaffID = rdr["StaffID"].ToString(),
                                            StaffName = rdr["StaffName"].ToString(),
                                            MailType = rdr["MailTypeID"].ToString(),
                                            Quantity = rdr["Declared_Qty"].ToString(),
                                            Received_Qty = rdr["Received_Qty"].ToString(),
                                            PCCode = rdr["PCCode"].ToString(),
                                            DepartmentID = rdr["DepartmentID"].ToString(),
                                            DepartmentName = rdr["DepartmentName"].ToString(),
                                            IsOffLine = rdr["IsOffLine"].ToString() == "1" ? true : false
                                        };
                                        objUserHead.ProcessSummeryModelList.Add(objUserDetail);
                                    }
                                }

                            }
                            objUserHeadList.Add(objUserHead);
                        }
                        else
                        {
                            objUserHead.resp = true;
                            objUserHead.msg = "";
                            objUserHeadList.Add(objUserHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objUserHead.resp = false;
                objUserHead.msg = ex.Message.ToString();

                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "Process_Data", "get_batch_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Process_Data", "get_batch_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Process_Data", "get_batch_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Process_Data", "get_batch_details", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objUserHeadList;
        }

        public static List<ProcessSubmitBatchModel> insert_batch_submit(ProcessSubmitBatchNoModel model)
        {
            List<ProcessSubmitBatchModel> objSubmitBatchList = new List<ProcessSubmitBatchModel>();
            ProcessSubmitBatchModel objSubmitBatch = new ProcessSubmitBatchModel();

            string DATA = JsonConvert.SerializeObject(model);
            objError.WriteLog(2, "Process_Data", "insert_batch_submit", "Stack Track: Submit List:" + DATA);

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objSubmitBatch.resp = false;
                objSubmitBatch.IsAuthenticated = false;
                objSubmitBatchList.Add(objSubmitBatch);
                return objSubmitBatchList;
            }
            SqlTransaction trans = null;

            string FilePathReference_Processing_ItemLevel_Local = "";
            string FilePathReference_Processing_ItemLevel_Oversea = "";

            try
            {
                if (string.IsNullOrEmpty(model.BatchNo))
                {
                    objSubmitBatch.resp = false;
                    objSubmitBatch.msg = "Batch No cannot empty";
                    objSubmitBatchList.Add(objSubmitBatch);
                    return objSubmitBatchList;
                }

                List<string> spitbyHash = model.BatchNo.Split('#').ToList();
                string BatchNo = "";
                if (spitbyHash.Count > 0)
                {
                    BatchNo = spitbyHash[0];
                }


                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    lconn.Open();
                    trans = lconn.BeginTransaction();
                    SqlDataReader reader;

                    using (SqlCommand cmd = new SqlCommand("sp_insert_process_batch_submit", lconn))
                    {
                        cmd.Transaction = trans;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BatchNo", BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ProcessingDateTime", model.ProcessingDateTime);
                        cmd.Parameters["@ProcessingDateTime"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CustomerID", model.CustomerID);
                        cmd.Parameters["@CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@StaffID", model.StaffID);
                        cmd.Parameters["@StaffID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DepartmentID", model.DepartmentID);
                        cmd.Parameters["@DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@IsOffLine", model.IsOffLine);
                        cmd.Parameters["@IsOffLine"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PCCode", model.PCCode);
                        cmd.Parameters["@PCCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MailType", model.MailType);
                        cmd.Parameters["@MailType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DeclaredQty", model.DeclaredQty);
                        cmd.Parameters["@DeclaredQty"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@RecievedQty", model.RecievedQty);
                        cmd.Parameters["@RecievedQty"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                        cmd.Parameters["@CreatedBy"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DeviceNo", model.DeviceNo);
                        cmd.Parameters["@DeviceNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DeviceTypeID", model.DeviceTypeID);
                        cmd.Parameters["@DeviceTypeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@VendorID", model.VendorID);
                        cmd.Parameters["@VendorID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@LocationID", model.LocationID);
                        cmd.Parameters["@LocationID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TransactionDateTime", model.TransactionDateTime);
                        cmd.Parameters["@TransactionDateTime"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ServerSyncDatetime", model.ServerSyncDatetime);
                        cmd.Parameters["@ServerSyncDatetime"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@AttachDocsToEmail", model.AttachDocsToEmail);
                        cmd.Parameters["@AttachDocsToEmail"].Direction = ParameterDirection.Input;


                        ReturnResponse res_local = new ReturnResponse();
                        res_local = SaveImageToFileFolder(model.UploadedFile_Processing_ItemLevel_Local, BatchNo, "FilePathReference_Processing_ItemLevel_Local", model.UploadedFileFormat_Local);

                        if (res_local.resp == true)
                        {
                            FilePathReference_Processing_ItemLevel_Local = res_local.msg;
                        }
                        else
                        {
                            if (trans != null)
                            {
                                trans.Rollback();
                                trans.Dispose();
                            }

                            objSubmitBatch.resp = false;
                            objSubmitBatch.msg = "Error in File Save : Oversea";

                            objSubmitBatchList.Add(objSubmitBatch);
                            return objSubmitBatchList;
                        }


                        cmd.Parameters.AddWithValue("@FilePathReference_Processing_ItemLevel_Local", FilePathReference_Processing_ItemLevel_Local);
                        cmd.Parameters["@FilePathReference_Processing_ItemLevel_Local"].Direction = ParameterDirection.Input;

                        ReturnResponse res_oversea = new ReturnResponse();
                        res_oversea = SaveImageToFileFolder(model.UploadedFile_Processing_ItemLevel_Oversea, BatchNo, "FilePathReference_Processing_ItemLevel_Oversea", model.UploadedFileFormat_Oversea);


                        if (res_oversea.resp == true)
                        {
                            FilePathReference_Processing_ItemLevel_Oversea = res_oversea.msg;
                        }
                        else
                        {
                            if (trans != null)
                            {
                                trans.Rollback();
                                trans.Dispose();
                            }

                            objSubmitBatch.resp = false;
                            objSubmitBatch.msg = "Error in File Save : Oversea";

                            objSubmitBatchList.Add(objSubmitBatch);
                            return objSubmitBatchList;
                        }

                        cmd.Parameters.AddWithValue("@FilePathReference_Processing_ItemLevel_Oversea", FilePathReference_Processing_ItemLevel_Oversea);
                        cmd.Parameters["@FilePathReference_Processing_ItemLevel_Oversea"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Processing_ItemLevel_Local_Total", model.Processing_ItemLevel_Local_Total);
                        cmd.Parameters["@Processing_ItemLevel_Local_Total"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Processing_ItemLevel_Oversea_Total", model.Processing_ItemLevel_Oversea_Total);
                        cmd.Parameters["@Processing_ItemLevel_Oversea_Total"].Direction = ParameterDirection.Input;

                        reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            objSubmitBatch = new ProcessSubmitBatchModel();
                            objSubmitBatch.resp = Boolean.Parse(reader.GetValue("RTN_RESP").ToString());
                            objSubmitBatch.msg = reader.GetValue("RTN_MSG").ToString();
                            objSubmitBatchList.Add(objSubmitBatch);
                            break;
                        }

                        reader.Close();
                        if (objSubmitBatch.resp == true)
                        {
                            insert_batch_submit_Local(model, ref objSubmitBatchList, lconn, trans, reader, BatchNo);

                            insert_batch_submit_Oversea(model, ref objSubmitBatchList, lconn, trans, reader, BatchNo);
                        }
                    }

                    DATA = JsonConvert.SerializeObject(objSubmitBatchList);
                    objError.WriteLog(2, "Process_Data", "insert_batch_submit", "Stack Track: Return List:" + DATA);

                    var temp = objSubmitBatchList.Where(a => a.resp == false).ToList();
                    if (temp.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(FilePathReference_Processing_ItemLevel_Oversea) && File.Exists(FilePathReference_Processing_ItemLevel_Oversea))
                        { File.Delete(FilePathReference_Processing_ItemLevel_Oversea); }

                        if (!string.IsNullOrEmpty(FilePathReference_Processing_ItemLevel_Local) && File.Exists(FilePathReference_Processing_ItemLevel_Local))
                        { File.Delete(FilePathReference_Processing_ItemLevel_Local); }

                        trans.Rollback();
                        trans.Dispose();
                    }
                    else
                    {
                        trans.Commit();
                        trans.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                if (trans != null)
                {
                    if (!string.IsNullOrEmpty(FilePathReference_Processing_ItemLevel_Oversea) && File.Exists(FilePathReference_Processing_ItemLevel_Oversea))
                    { File.Delete(FilePathReference_Processing_ItemLevel_Oversea); }

                    if (!string.IsNullOrEmpty(FilePathReference_Processing_ItemLevel_Local) && File.Exists(FilePathReference_Processing_ItemLevel_Local))
                    { File.Delete(FilePathReference_Processing_ItemLevel_Local); }

                    trans.Rollback();
                    trans.Dispose();
                }

                objSubmitBatch.resp = false;
                objSubmitBatch.msg = ex.Message.ToString();

                objSubmitBatchList.Add(objSubmitBatch);

                objError.WriteLog(0, "Process_Data", "insert_batch_submit", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Process_Data", "insert_batch_submit", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Process_Data", "insert_batch_submit", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Process_Data", "insert_batch_submit", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objSubmitBatchList;
        }

        private static List<ProcessSubmitBatchModel> insert_batch_submit_Oversea(ProcessSubmitBatchNoModel model, ref List<ProcessSubmitBatchModel> objSubmitBatchList, SqlConnection lconn, SqlTransaction trans, SqlDataReader reader, string BatchNo)
        {
            int i = 0;
            foreach (var item in model.ProcessSubmitBatchNoModel_ItemLevel_Oversea)
            {
                using (SqlCommand cmd_O = new SqlCommand("sp_insert_process_batch_submit_oversea", lconn))
                {
                    item.SN = i;
                    cmd_O.Transaction = trans;
                    cmd_O.CommandType = CommandType.StoredProcedure;

                    cmd_O.Parameters.AddWithValue("@BatchNo", BatchNo);
                    cmd_O.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@SN", item.SN);
                    cmd_O.Parameters["@SN"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@PostageAmount", item.PostageAmount);
                    cmd_O.Parameters["@PostageAmount"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@TrackingNumber", item.TrackingNumber);
                    cmd_O.Parameters["@TrackingNumber"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@RecipentName", item.RecipentName);
                    cmd_O.Parameters["@RecipentName"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@Address", item.Address);
                    cmd_O.Parameters["@Address"].Direction = ParameterDirection.Input;

                    var countryArr = item.Country.Split("(");
                    //if (countryArr.Length < 2)
                    //{
                    //    ProcessSubmitBatchModel objSubmitBatch = new ProcessSubmitBatchModel();
                    //    objSubmitBatch.resp = false;
                    //    objSubmitBatch.msg = "Invalid Country";
                    //    objSubmitBatchList.Add(objSubmitBatch);
                    //    return objSubmitBatchList;
                    //}
                    //string countrycode = countryArr[1].Replace(")", "");
                    string country = countryArr[0].Trim();

                    cmd_O.Parameters.AddWithValue("@Country", country);
                    cmd_O.Parameters["@Country"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@MailItemType", item.MailItemType);
                    cmd_O.Parameters["@MailItemType"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@Quantity", item.Quantity);
                    cmd_O.Parameters["@Quantity"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@TotalCost", item.TotalCost);
                    cmd_O.Parameters["@TotalCost"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@Deliver_Courier_Company", item.Deliver_Courier_Company);
                    cmd_O.Parameters["@Deliver_Courier_Company"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@TrackedMail", item.TrackedMail);
                    cmd_O.Parameters["@TrackedMail"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@TrackedPackage", item.TrackedPackage);
                    cmd_O.Parameters["@TrackedPackage"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@BatchedRecord", item.BatchedRecord);
                    cmd_O.Parameters["@BatchedRecord"].Direction = ParameterDirection.Input;

                    //SqlDataReader reader;

                    reader = cmd_O.ExecuteReader();

                    while (reader.Read())
                    {
                        ProcessSubmitBatchModel objSubmitBatch = new ProcessSubmitBatchModel();
                        objSubmitBatch.resp = Boolean.Parse(reader.GetValue("RTN_RESP").ToString());
                        objSubmitBatch.msg = reader.GetValue("RTN_MSG").ToString();
                        objSubmitBatchList.Add(objSubmitBatch);
                        break;
                    }

                    reader.Close();
                    i++;
                }
            }
            return objSubmitBatchList;
        }

        private static List<ProcessSubmitBatchModel> insert_batch_submit_Local(ProcessSubmitBatchNoModel model, ref List<ProcessSubmitBatchModel> objSubmitBatchList, SqlConnection lconn, SqlTransaction trans, SqlDataReader reader, string BatchNo)
        {
            int i = 0;
            foreach (var item in model.ProcessSubmitBatchNoModel_ItemLevel_Local)
            {
                using (SqlCommand cmd_L = new SqlCommand("sp_insert_process_batch_submit_local", lconn))
                {
                    item.SN = i;
                    cmd_L.Transaction = trans;
                    cmd_L.CommandType = CommandType.StoredProcedure;

                    cmd_L.Parameters.AddWithValue("@BatchNo", BatchNo);
                    cmd_L.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@SN", item.SN);
                    cmd_L.Parameters["@SN"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@PostageAmount", item.PostageAmount);
                    cmd_L.Parameters["@PostageAmount"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@TrackingNumber", item.TrackingNumber);
                    cmd_L.Parameters["@TrackingNumber"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@RecipentName", item.RecipentName);
                    cmd_L.Parameters["@RecipentName"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@Address", item.Address);
                    cmd_L.Parameters["@Address"].Direction = ParameterDirection.Input;

                    var countryArr = item.Country.Split("(");
                    //if (countryArr.Length < 2)
                    //{
                    //    ProcessSubmitBatchModel objSubmitBatch = new ProcessSubmitBatchModel();
                    //    objSubmitBatch.resp = false;
                    //    objSubmitBatch.msg = "Invalid Country";
                    //    objSubmitBatchList.Add(objSubmitBatch);
                    //    return objSubmitBatchList;
                    //}
                    //string countrycode = countryArr[1].Replace(")", "");
                    string country = countryArr[0].Trim();

                    cmd_L.Parameters.AddWithValue("@Country", country);
                    cmd_L.Parameters["@Country"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@MailItemType", item.MailItemType);
                    cmd_L.Parameters["@MailItemType"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@Quantity", item.Quantity);
                    cmd_L.Parameters["@Quantity"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@TotalCost", item.TotalCost);
                    cmd_L.Parameters["@TotalCost"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@Deliver_Courier_Company", item.Deliver_Courier_Company);
                    cmd_L.Parameters["@Deliver_Courier_Company"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@TrackedMail", item.TrackedMail);
                    cmd_L.Parameters["@TrackedMail"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@TrackedPackage", item.TrackedPackage);
                    cmd_L.Parameters["@TrackedPackage"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@BatchedRecord", item.BatchedRecord);
                    cmd_L.Parameters["@BatchedRecord"].Direction = ParameterDirection.Input;

                    //SqlDataReader reader;

                    reader = cmd_L.ExecuteReader();

                    while (reader.Read())
                    {
                        ProcessSubmitBatchModel objSubmitBatch = new ProcessSubmitBatchModel();
                        objSubmitBatch.resp = Boolean.Parse(reader.GetValue("RTN_RESP").ToString());
                        objSubmitBatch.msg = reader.GetValue("RTN_MSG").ToString();
                        objSubmitBatchList.Add(objSubmitBatch);
                        break;
                    }

                    reader.Close();
                    i++;
                }
            }
            return objSubmitBatchList;
        }

        public static List<ProcessGridViewHeaderModel> get_batch_grid_details(ProcessGridRequestBatchNoModel gridmodel)
        {
            List<ProcessGridViewHeaderModel> objUserHeadList = new List<ProcessGridViewHeaderModel>();
            ProcessGridViewHeaderModel objUserHead = new ProcessGridViewHeaderModel();
            objUserHead.ProcessGridViewModelList = new List<ProcessGridViewModel>();

            if (login_Data.AuthenticationKeyValidateWithDB(gridmodel) == false)
            {
                objUserHead.resp = false;
                objUserHead.IsAuthenticated = false;
                objUserHeadList.Add(objUserHead);
                return objUserHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_process_batch_grid_details";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BatchNo", gridmodel.BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Staff_ID", gridmodel.Staff_ID);
                        cmd.Parameters["@Staff_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TrDateFrom", gridmodel.TrDateFrom);
                        cmd.Parameters["@TrDateFrom"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TrDateTo", gridmodel.TrDateTo);
                        cmd.Parameters["@TrDateTo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PCCode", gridmodel.PCCode);
                        cmd.Parameters["@PCCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MailTypeID", gridmodel.MailTypeID);
                        cmd.Parameters["@MailTypeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_ID", gridmodel.CUS_ID);
                        cmd.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ProcessedBy", gridmodel.ProcessedBy);
                        cmd.Parameters["@ProcessedBy"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_NO", gridmodel.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", gridmodel.PAGE_RECORDS_COUNT);
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

                                cmdrc.Parameters.AddWithValue("@CUS_ID", gridmodel.CUS_ID);
                                cmdrc.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

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
                                    objUserHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objUserHead.msg = rdr["RTN_MSG"].ToString();
                                }
                                else
                                {
                                    DateTime trdate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["TransactionDate"].ToString(), out trdate);

                                    decimal decQty = 0;
                                    decimal.TryParse(rdr["DeclaredQty"].ToString(), out decQty);

                                    decimal recQty = 0;
                                    decimal.TryParse(rdr["RecievedQty"].ToString(), out recQty);

                                    decimal localCost = 0;
                                    decimal.TryParse(rdr["LocalCost"].ToString(), out localCost);

                                    decimal overseaCost = 0;
                                    decimal.TryParse(rdr["OverseaCost"].ToString(), out overseaCost);

                                    objUserHead.resp = true;
                                    objUserHead.msg = "Process";

                                    ProcessGridViewModel objUserDetails = new ProcessGridViewModel()
                                    {
                                        BatchNo = rdr["BatchNumber"].ToString(),
                                        DeclaredQty = decQty,
                                        RecievedQty = recQty,
                                        StaffName = rdr["StaffName"].ToString(),
                                        Staff_ID = rdr["Staff_ID"].ToString(),
                                        TransactionDate = trdate,
                                        MailType = rdr["MailType"].ToString(),
                                        MailTypeID = rdr["MailTypeID"].ToString(),
                                        PCCode = rdr["PCCode"].ToString(),
                                        Location = rdr["Location"].ToString(),
                                        DepartmentID = rdr["DepartmentID"].ToString(),
                                        DepartmentName = rdr["DepartmentName"].ToString(),
                                        LocalCost = localCost,
                                        OverseaCost = overseaCost,
                                        RC = RC,
                                    };
                                    objUserHead.ProcessGridViewModelList.Add(objUserDetails);
                                }

                            }
                            objUserHeadList.Add(objUserHead);
                        }
                        else
                        {
                            objUserHead.resp = true;
                            objUserHead.msg = "";
                            objUserHeadList.Add(objUserHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objUserHead.resp = false;
                objUserHead.msg = ex.Message.ToString();
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "Process_Data", "get_batch_grid_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Process_Data", "get_batch_grid_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Process_Data", "get_batch_grid_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Process_Data", "get_batch_grid_details", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objUserHeadList;
        }

        private static ReturnResponse SaveImageToFileFolder(byte[] uploadedFile, string batchNo, string SP_ID, string filefornat)
        {
            ReturnResponse res = new ReturnResponse();

            string FilePathReference_Receiving = "";
            try
            {
                if (uploadedFile != null && uploadedFile.Length > 0)
                {
                    //Image img = null;
                    using (var ms = new MemoryStream(uploadedFile))
                    {
                        //img = Image.FromStream(ms);
                        string FilePathReference = "";

                        List<ReturSystemPMModelHead> tem = SystemParameter_Data.get_system_parameter_single(
                                    new GetSystemPMSingleModel()
                                    { SP_ID = SP_ID });

                        if (tem != null && tem.Count > 0 && tem[0].SystemPM != null && tem[0].SystemPM.Count > 0)
                        {
                            FilePathReference = tem[0].SystemPM[0].SP_Value;
                        }

                        if (!Directory.Exists(FilePathReference.Trim()))
                        {
                            Directory.CreateDirectory(FilePathReference.Trim());
                        }

                        if (string.IsNullOrEmpty(filefornat)) filefornat = "jpg";

                        FilePathReference_Receiving = FilePathReference.Trim() + "\\" + batchNo + "." + filefornat;

                        if (!File.Exists(FilePathReference_Receiving.Trim()))
                        {
                            //File.Create(FilePathReference_Receiving.Trim());
                            FileStream fs = File.Create(FilePathReference_Receiving);
                            BinaryWriter bw = new BinaryWriter(fs);
                            fs.Write(uploadedFile);
                            fs.Close();
                            fs.Dispose();
                            bw.Close();
                            bw.Dispose();
                        }
                        else
                        {
                            File.Delete(FilePathReference_Receiving);

                            FileStream fs = File.Create(FilePathReference_Receiving);
                            BinaryWriter bw = new BinaryWriter(fs);
                            fs.Write(uploadedFile);
                            fs.Close();
                            fs.Dispose();
                            bw.Close();
                            bw.Dispose();
                        }

                        //FilePathReference_Receiving = FilePathReference + "\\" + batchNo + ".Png";
                        //img.Save(FilePathReference_Receiving, System.Drawing.Imaging.ImageFormat.Png);

                        res = new ReturnResponse() { resp = true, msg = FilePathReference_Receiving, obj = new { bytelength = uploadedFile.Length } };
                    }
                }
                else
                {
                    res = new ReturnResponse() { resp = true, msg = "" };
                }
            }
            catch (Exception ex)
            {
                if (uploadedFile != null)
                {
                    res = new ReturnResponse() { resp = false, msg = "Error Message: " + ex.Message, obj = new { bytelength = uploadedFile.Length } };
                }
                else
                {
                    res = new ReturnResponse() { resp = false, msg = "Error Message: " + ex.Message, obj = new { bytelength = 0 } };
                }

                objError.WriteLog(0, "Process_Data", "SaveImageToFileFolder", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Process_Data", "SaveImageToFileFolder", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Process_Data", "SaveImageToFileFolder", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Process_Data", "SaveImageToFileFolder", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return res;

        }


        public static List<ProcessSubmitBatchModel> update_process_batch_submit(ProcessSubmitBatchNoModel model)
        {
            List<ProcessSubmitBatchModel> objSubmitBatchList = new List<ProcessSubmitBatchModel>();
            ProcessSubmitBatchModel objSubmitBatch = new ProcessSubmitBatchModel();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objSubmitBatch.resp = false;
                objSubmitBatch.IsAuthenticated = false;
                objSubmitBatchList.Add(objSubmitBatch);
                return objSubmitBatchList;
            }
            SqlTransaction trans = null;

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    lconn.Open();
                    trans = lconn.BeginTransaction();
                    SqlDataReader reader;

                    using (SqlCommand cmd = new SqlCommand("sp_update_process_batch_submit", lconn))
                    {
                        cmd.Transaction = trans;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BatchNo", model.BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ProcessingDateTime", model.ProcessingDateTime);
                        cmd.Parameters["@ProcessingDateTime"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CustomerID", model.CustomerID);
                        cmd.Parameters["@CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@StaffID", model.StaffID);
                        cmd.Parameters["@StaffID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DepartmentID", model.DepartmentID);
                        cmd.Parameters["@DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@IsOffLine", model.IsOffLine);
                        cmd.Parameters["@IsOffLine"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PCCode", model.PCCode);
                        cmd.Parameters["@PCCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MailType", model.MailType);
                        cmd.Parameters["@MailType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DeclaredQty", model.DeclaredQty);
                        cmd.Parameters["@DeclaredQty"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@RecievedQty", model.RecievedQty);
                        cmd.Parameters["@RecievedQty"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);
                        cmd.Parameters["@CreatedBy"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DeviceNo", model.DeviceNo);
                        cmd.Parameters["@DeviceNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DeviceTypeID", model.DeviceTypeID);
                        cmd.Parameters["@DeviceTypeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@VendorID", model.VendorID);
                        cmd.Parameters["@VendorID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@LocationID", model.LocationID);
                        cmd.Parameters["@LocationID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TransactionDateTime", model.TransactionDateTime);
                        cmd.Parameters["@TransactionDateTime"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ServerSyncDatetime", model.ServerSyncDatetime);
                        cmd.Parameters["@ServerSyncDatetime"].Direction = ParameterDirection.Input;


                        ReturnResponse res_local = new ReturnResponse();
                        res_local = SaveImageToFileFolder(model.UploadedFile_Processing_ItemLevel_Local, model.BatchNo, "FilePathReference_Processing_ItemLevel_Local", model.UploadedFileFormat_Local);

                        string FilePathReference_Processing_ItemLevel_Local = "";

                        if (res_local.resp == true)
                        {
                            FilePathReference_Processing_ItemLevel_Local = res_local.msg;
                        }
                        else
                        {
                            if (trans != null)
                            {
                                trans.Rollback();
                                trans.Dispose();
                            }

                            objSubmitBatch.resp = false;
                            objSubmitBatch.msg = "Error in File Save : Oversea";

                            objSubmitBatchList.Add(objSubmitBatch);
                            return objSubmitBatchList;
                        }


                        cmd.Parameters.AddWithValue("@FilePathReference_Processing_ItemLevel_Local", FilePathReference_Processing_ItemLevel_Local);
                        cmd.Parameters["@FilePathReference_Processing_ItemLevel_Local"].Direction = ParameterDirection.Input;

                        ReturnResponse res_oversea = new ReturnResponse();
                        res_oversea = SaveImageToFileFolder(model.UploadedFile_Processing_ItemLevel_Oversea, model.BatchNo, "FilePathReference_Processing_ItemLevel_Oversea", model.UploadedFileFormat_Oversea);

                        string FilePathReference_Processing_ItemLevel_Oversea = "";

                        if (res_oversea.resp == true)
                        {
                            FilePathReference_Processing_ItemLevel_Oversea = res_oversea.msg;
                        }
                        else
                        {
                            if (trans != null)
                            {
                                trans.Rollback();
                                trans.Dispose();
                            }

                            objSubmitBatch.resp = false;
                            objSubmitBatch.msg = "Error in File Save : Oversea";

                            objSubmitBatchList.Add(objSubmitBatch);
                            return objSubmitBatchList;
                        }

                        cmd.Parameters.AddWithValue("@FilePathReference_Processing_ItemLevel_Oversea", FilePathReference_Processing_ItemLevel_Oversea);
                        cmd.Parameters["@FilePathReference_Processing_ItemLevel_Oversea"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Processing_ItemLevel_Local_Total", model.Processing_ItemLevel_Local_Total);
                        cmd.Parameters["@Processing_ItemLevel_Local_Total"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Processing_ItemLevel_Oversea_Total", model.Processing_ItemLevel_Oversea_Total);
                        cmd.Parameters["@Processing_ItemLevel_Oversea_Total"].Direction = ParameterDirection.Input;



                        reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            objSubmitBatch = new ProcessSubmitBatchModel();
                            objSubmitBatch.resp = Boolean.Parse(reader.GetValue("RTN_RESP").ToString());
                            objSubmitBatch.msg = reader.GetValue("RTN_MSG").ToString();
                            objSubmitBatchList.Add(objSubmitBatch);
                            break;
                        }


                        reader.Close();
                        if (objSubmitBatch.resp == true)
                        {
                            update_process_batch_submit_Local(model, objSubmitBatchList, lconn, trans, reader);

                            update_process_batch_submit_Oversea(model, objSubmitBatchList, lconn, trans, reader);
                        }
                    }

                    trans.Commit();
                    trans.Dispose();
                }
            }
            catch (Exception ex)
            {
                if (trans != null)
                {
                    trans.Rollback();
                    trans.Dispose();
                }

                objSubmitBatch.resp = false;
                objSubmitBatch.msg = ex.Message.ToString();

                objSubmitBatchList.Add(objSubmitBatch);

                objError.WriteLog(0, "Process_Data", "update_process_batch_submit", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Process_Data", "update_process_batch_submit", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Process_Data", "update_process_batch_submit", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Process_Data", "update_process_batch_submit", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objSubmitBatchList;
        }

        private static List<ProcessSubmitBatchModel> update_process_batch_submit_Oversea(ProcessSubmitBatchNoModel model, List<ProcessSubmitBatchModel> objSubmitBatchList, SqlConnection lconn, SqlTransaction trans, SqlDataReader reader)
        {
            foreach (var item in model.ProcessSubmitBatchNoModel_ItemLevel_Oversea)
            {
                using (SqlCommand cmd_O = new SqlCommand("sp_update_process_batch_submit_oversea", lconn))
                {
                    cmd_O.Transaction = trans;
                    cmd_O.CommandType = CommandType.StoredProcedure;

                    cmd_O.Parameters.AddWithValue("@BatchNo", model.BatchNo);
                    cmd_O.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@SN", item.SN);
                    cmd_O.Parameters["@SN"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@PostageAmount", item.PostageAmount);
                    cmd_O.Parameters["@PostageAmount"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@TrackingNumber", item.TrackingNumber);
                    cmd_O.Parameters["@TrackingNumber"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@RecipentName", item.RecipentName);
                    cmd_O.Parameters["@RecipentName"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@Address", item.Address);
                    cmd_O.Parameters["@Address"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@Country", item.Country);
                    cmd_O.Parameters["@Country"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@MailItemType", item.MailItemType);
                    cmd_O.Parameters["@MailItemType"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@Quantity", item.Quantity);
                    cmd_O.Parameters["@Quantity"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@TotalCost", item.TotalCost);
                    cmd_O.Parameters["@TotalCost"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@Deliver_Courier_Company", item.Deliver_Courier_Company);
                    cmd_O.Parameters["@Deliver_Courier_Company"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@TrackedMail", item.TrackedMail);
                    cmd_O.Parameters["@TrackedMail"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@TrackedPackage", item.TrackedPackage);
                    cmd_O.Parameters["@TrackedPackage"].Direction = ParameterDirection.Input;

                    cmd_O.Parameters.AddWithValue("@BatchedRecord", item.BatchedRecord);
                    cmd_O.Parameters["@BatchedRecord"].Direction = ParameterDirection.Input;

                    //SqlDataReader reader;

                    reader = cmd_O.ExecuteReader();

                    while (reader.Read())
                    {
                        ProcessSubmitBatchModel objSubmitBatch = new ProcessSubmitBatchModel();
                        objSubmitBatch.resp = Boolean.Parse(reader.GetValue("RTN_RESP").ToString());
                        objSubmitBatch.msg = reader.GetValue("RTN_MSG").ToString();
                        objSubmitBatchList.Add(objSubmitBatch);
                        break;
                    }

                    reader.Close();
                }
            }
            return objSubmitBatchList;
        }

        private static List<ProcessSubmitBatchModel> update_process_batch_submit_Local(ProcessSubmitBatchNoModel model, List<ProcessSubmitBatchModel> objSubmitBatchList, SqlConnection lconn, SqlTransaction trans, SqlDataReader reader)
        {
            foreach (var item in model.ProcessSubmitBatchNoModel_ItemLevel_Local)
            {
                using (SqlCommand cmd_L = new SqlCommand("sp_update_process_batch_submit_local", lconn))
                {
                    cmd_L.Transaction = trans;
                    cmd_L.CommandType = CommandType.StoredProcedure;

                    cmd_L.Parameters.AddWithValue("@BatchNo", model.BatchNo);
                    cmd_L.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@SN", item.SN);
                    cmd_L.Parameters["@SN"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@PostageAmount", item.PostageAmount);
                    cmd_L.Parameters["@PostageAmount"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@TrackingNumber", item.TrackingNumber);
                    cmd_L.Parameters["@TrackingNumber"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@RecipentName", item.RecipentName);
                    cmd_L.Parameters["@RecipentName"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@Address", item.Address);
                    cmd_L.Parameters["@Address"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@Country", item.Country);
                    cmd_L.Parameters["@Country"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@MailItemType", item.MailItemType);
                    cmd_L.Parameters["@MailItemType"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@Quantity", item.Quantity);
                    cmd_L.Parameters["@Quantity"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@TotalCost", item.TotalCost);
                    cmd_L.Parameters["@TotalCost"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@Deliver_Courier_Company", item.Deliver_Courier_Company);
                    cmd_L.Parameters["@Deliver_Courier_Company"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@TrackedMail", item.TrackedMail);
                    cmd_L.Parameters["@TrackedMail"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@TrackedPackage", item.TrackedPackage);
                    cmd_L.Parameters["@TrackedPackage"].Direction = ParameterDirection.Input;

                    cmd_L.Parameters.AddWithValue("@BatchedRecord", item.BatchedRecord);
                    cmd_L.Parameters["@BatchedRecord"].Direction = ParameterDirection.Input;

                    //SqlDataReader reader;

                    reader = cmd_L.ExecuteReader();

                    while (reader.Read())
                    {
                        ProcessSubmitBatchModel objSubmitBatch = new ProcessSubmitBatchModel();
                        objSubmitBatch.resp = Boolean.Parse(reader.GetValue("RTN_RESP").ToString());
                        objSubmitBatch.msg = reader.GetValue("RTN_MSG").ToString();
                        objSubmitBatchList.Add(objSubmitBatch);
                        break;
                    }

                    reader.Close();
                }
            }
            return objSubmitBatchList;
        }

        public static List<FullProcessSummeryHeaderModel> get_batch_full_details(ProcessRequestBatchNoModel ScannedText)
        {
            List<FullProcessSummeryHeaderModel> objUserHeadList = new List<FullProcessSummeryHeaderModel>();
            FullProcessSummeryHeaderModel objUserHead = new FullProcessSummeryHeaderModel();
            objUserHead.ProcessSummeryModelList = new List<ProcessSummeryModel>();
            DayEndProcessDetail objD = new DayEndProcessDetail();


            if (login_Data.AuthenticationKeyValidateWithDB(ScannedText) == false)
            {
                objUserHead.resp = false;
                objUserHead.IsAuthenticated = false;
                objUserHeadList.Add(objUserHead);
                return objUserHeadList;
            }

            try
            {
                if (string.IsNullOrEmpty(ScannedText.BatchNo))
                {
                    objUserHead.resp = false;
                    objUserHead.msg = "QR Code cannot empty";
                    objUserHeadList.Add(objUserHead);
                    return objUserHeadList;
                }

                List<string> spitbyHash = ScannedText.BatchNo.Split('#').ToList();
                string BatchNo = "";
                if (spitbyHash.Count > 0)
                {
                    BatchNo = spitbyHash[0];
                }
                string DeviceNo = "";
                string StaffID = "";
                string MailType = "";
                string DeclaredQuantity = "";
                string PCCode = "";
                string TransactionDate = "";

                //QR Body
                //#1%A03#2%T001#3%R#4%25#5%P0001#6%20220920T10:27:43.10Z

                foreach (var item in spitbyHash)
                {
                    ////#1 - Device No – (A03)
                    //if (item.StartsWith("1%"))
                    //{
                    //    List<string> tempDe = item.Split('%').ToList();
                    //    DeviceNo = tempDe[1];
                    //}
                    //#2 - Staff ID – (T001)
                    if (item.StartsWith("1%"))
                    {
                        List<string> tempDe = item.Split('%').ToList();
                        StaffID = tempDe[1];
                    }
                    //#3 - Mail Type (C - Courier, O - Ordinary, R - Registered)
                    if (item.StartsWith("2%"))
                    {
                        List<string> tempDe = item.Split('%').ToList();
                        MailType = tempDe[1];
                    }
                    //#4 - Declared Quantity - (T001)
                    if (item.StartsWith("3%"))
                    {
                        List<string> tempDe = item.Split('%').ToList();
                        DeclaredQuantity = tempDe[1];
                    }
                    //#5 - PC Code – (P0001)
                    if (item.StartsWith("4%"))
                    {
                        List<string> tempDe = item.Split('%').ToList();
                        PCCode = tempDe[1];
                    }
                    //#6 – Transaction Date – (20220920T10:27:43.10Z)
                    if (item.StartsWith("5%"))
                    {
                        List<string> tempDe = item.Split('%').ToList();
                        TransactionDate = tempDe[1];
                    }
                }

                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_process_batch_full_details";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BatchNo", BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            objUserHead.resp = true;
                            objUserHead.msg = "";

                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                if (Ds.Tables[0].Columns.Contains("RTN_RESP"))
                                {
                                    objUserHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objUserHead.msg = rdr["RTN_MSG"].ToString();
                                }
                                else
                                {
                                    ProcessSummeryModel objUserDetail = new ProcessSummeryModel()
                                    {
                                        BatchNo = rdr["BatchNumber"].ToString(),
                                        DeviceNo = rdr["DeviceNo"].ToString(),
                                        StaffID = rdr["Staff_ID"].ToString(),
                                        StaffName = rdr["StaffName"].ToString(),
                                        MailType = rdr["MailTypeID"].ToString(),
                                        Quantity = rdr["Declared_Qty"].ToString(),
                                        Received_Qty = rdr["Received_Qty"].ToString(),
                                        PCCode = rdr["PCCode"].ToString(),
                                        DepartmentID = rdr["DepartmentID"].ToString(),
                                        DepartmentName = rdr["DepartmentName"].ToString(),
                                    };

                                    objUserDetail.DayEndProcessDetails = new List<DayEndProcessDetail>();

                                    foreach (DataRow rdrd in Ds.Tables[1].Rows)
                                    {
                                        if (rdr["BatchNumber"].ToString() == rdrd["BatchNumber"].ToString())
                                        {
                                            objD = new DayEndProcessDetail()
                                            {
                                                BatchNumber = rdrd["BatchNumber"].ToString(),
                                                SN = rdrd["SN"].ToString(),
                                                PostageAmount = rdrd["PostageAmount"].ToString(),
                                                TrackingNumber = rdrd["TrackingNumber"].ToString(),
                                                RecipentName = rdrd["RecipentName"].ToString(),
                                                Address = rdrd["Address"].ToString(),
                                                Country = rdrd["Country"].ToString(),
                                                MailItemType = rdrd["MailItemType"].ToString(),
                                                Quantity = Convert.ToDecimal(rdrd["Quantity"].ToString()),
                                                TotalCost = Convert.ToDecimal(rdrd["TotalCost"].ToString()),
                                                Deliver_Courier_Company = rdrd["Deliver_Courier_Company"].ToString(),
                                                TrackedMail = rdrd["TrackedMail"].ToString(),
                                                TrackedPackage = rdrd["TrackedPackage"].ToString(),
                                                BatchedRecord = rdrd["BatchedRecord"].ToString(),
                                            };
                                            objUserDetail.DayEndProcessDetails.Add(objD);
                                        }
                                    }
                                    objUserHead.ProcessSummeryModelList.Add(objUserDetail);
                                }

                            }
                            objUserHeadList.Add(objUserHead);
                        }
                        else
                        {
                            objUserHead.resp = true;
                            objUserHead.msg = "";
                            objUserHeadList.Add(objUserHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objUserHead.resp = false;
                objUserHead.msg = ex.Message.ToString();

                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "Process_Data", "get_batch_full_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Process_Data", "get_batch_full_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Process_Data", "get_batch_full_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Process_Data", "get_batch_full_details", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objUserHeadList;
        }

    }
}