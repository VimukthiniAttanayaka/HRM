using error_handler;
using HRM_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class Enquiry_Data
    {
        private static LogError objError = new LogError();

        public static List<EnquiryHeaderResponceModel> modify_Enquiry(EnquirySubmitModel item)
        {
            List<EnquiryHeaderResponceModel> objEnquiryHeadList = new List<EnquiryHeaderResponceModel>();
            EnquiryHeaderResponceModel objEnquiryHead = new EnquiryHeaderResponceModel();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objEnquiryHead.resp = false;
                objEnquiryHead.IsAuthenticated = false;
                objEnquiryHeadList.Add(objEnquiryHead);
                return objEnquiryHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_upate_Enquiry";
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

                        cmd.Parameters.AddWithValue("@PostageTotal", item.PostageTotal);
                        cmd.Parameters["@PostageTotal"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                        cmd.Parameters["@Quantity"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TrackingNo", item.TrackingNo);
                        cmd.Parameters["@TrackingNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CreatedBy", item.CreatedBy);
                        cmd.Parameters["@CreatedBy"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_ID", item.CUS_ID);
                        cmd.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@SN", item.SN);
                        cmd.Parameters["@SN"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MailItemType", item.MailItemType);
                        cmd.Parameters["@MailItemType"].Direction = ParameterDirection.Input;

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
                                    objEnquiryHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objEnquiryHead.msg = rdr["RTN_MSG"].ToString();
                                }

                            }
                            if (Ds.Tables.Count > 1)
                            {
                                foreach (DataRow rdr in Ds.Tables[1].Rows)
                                {
                                    DateTime trdate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["TransactionDate"].ToString(), out trdate);

                                    decimal decQty = 0;
                                    decimal.TryParse(rdr["Quantity"].ToString(), out decQty);

                                    decimal recQty = 0;
                                    decimal.TryParse(rdr["PostageTotal"].ToString(), out recQty);

                                    EnquiryResponceModel objEnquiryDetail = new EnquiryResponceModel()
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
                                        TrackingNumber = rdr["TrackingNumber"].ToString(),
                                        Quantity = decQty,
                                        PostageTotal = recQty
                                    };
                                    objEnquiryHead.EnquiryResponceModelList.Add(objEnquiryDetail);
                                }
                            }
                            objEnquiryHeadList.Add(objEnquiryHead);
                        }
                        else
                        {
                            objEnquiryHead.resp = true;
                            objEnquiryHead.msg = "";
                            objEnquiryHeadList.Add(objEnquiryHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objEnquiryHead.resp = false;
                objEnquiryHead.msg = ex.Message.ToString();

                objEnquiryHeadList.Add(objEnquiryHead);

                objError.WriteLog(0, "Enquiry_Data", "modify_Enquiry", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Enquiry_Data", "modify_Enquiry", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Enquiry_Data", "modify_Enquiry", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Enquiry_Data", "modify_Enquiry", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objEnquiryHeadList;
        }

        public static List<EnquiryHeaderResponceModel> get_Enquiry_details(EnquiryRequestModel item)
        {
            List<EnquiryHeaderResponceModel> objEnquiryHeadList = new List<EnquiryHeaderResponceModel>();
            EnquiryHeaderResponceModel objEnquiryHead = new EnquiryHeaderResponceModel();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objEnquiryHead.resp = false;
                objEnquiryHead.IsAuthenticated = false;
                objEnquiryHeadList.Add(objEnquiryHead);
                return objEnquiryHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_Enquiry_details";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BatchNo", item.BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@SN", item.SN);
                        cmd.Parameters["@SN"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MailItemType", item.MailItemType);
                        cmd.Parameters["@MailItemType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_ID", item.CUS_ID);
                        cmd.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

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
                                    objEnquiryHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objEnquiryHead.msg = rdr["RTN_MSG"].ToString();
                                }
                                else
                                {
                                    objEnquiryHead.resp = true;
                                    objEnquiryHead.msg = "";

                                    DateTime trdate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["TransactionDate"].ToString(), out trdate);

                                    decimal decQty = 0;
                                    decimal.TryParse(rdr["Quantity"].ToString(), out decQty);

                                    decimal recQty = 0;
                                    decimal.TryParse(rdr["PostageTotal"].ToString(), out recQty);

                                    EnquiryResponceModel objEnquiryDetail = new EnquiryResponceModel()
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
                                        TrackingNumber = rdr["TrackingNumber"].ToString(),
                                        Quantity = decQty,
                                        PostageTotal = recQty,
                                        CPCode = rdr["CPCode"].ToString(),
                                        DepartmentID = rdr["DepartmentID"].ToString(),
                                        DepartmentName = rdr["DPT_Name"].ToString(),

                                        //•	Sender
                                        RecipentName = rdr["RecipentName"].ToString(),
                                        MailItemType = rdr["MailItemType"].ToString(),
                                        ProcessedBy = rdr["ProcessedBy"].ToString(),
                                        CUS_CompanyName = rdr["CUS_CompanyName"].ToString(),
                                        SN = rdr["SN"].ToString(),
                                    };
                                    objEnquiryHead.EnquiryResponceModelList.Add(objEnquiryDetail);
                                }

                            }
                            objEnquiryHeadList.Add(objEnquiryHead);
                        }
                        else
                        {
                            objEnquiryHead.resp = true;
                            objEnquiryHead.msg = "";
                            objEnquiryHeadList.Add(objEnquiryHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objEnquiryHead.resp = false;
                objEnquiryHead.msg = ex.Message.ToString();

                objEnquiryHeadList.Add(objEnquiryHead);

                objError.WriteLog(0, "Enquiry_Data", "get_Enquiry_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Enquiry_Data", "get_Enquiry_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Enquiry_Data", "get_Enquiry_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Enquiry_Data", "get_Enquiry_details", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objEnquiryHeadList;
        }

        public static List<EnquiryGridViewHeaderModel> get_Enquiry_grid_details(EnquiryGridRequestModel item)
        {
            List<EnquiryGridViewHeaderModel> objEnquiryHeadList = new List<EnquiryGridViewHeaderModel>();
            EnquiryGridViewHeaderModel objEnquiryHead = new EnquiryGridViewHeaderModel();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objEnquiryHead.resp = false;
                objEnquiryHead.IsAuthenticated = false;
                objEnquiryHeadList.Add(objEnquiryHead);
                return objEnquiryHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_Enquiry_grid_details";
                        cmd.CommandType = CommandType.StoredProcedure;



                        cmd.Parameters.AddWithValue("@BatchNo", item.BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TransactionDate", item.TransactionDate);
                        cmd.Parameters["@TransactionDate"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_ID", item.CUS_ID);
                        cmd.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PCCode", item.PCCode);
                        cmd.Parameters["@PCCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MailTypeID", item.MailTypeID);
                        cmd.Parameters["@MailTypeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Staff_ID", item.Staff_ID);
                        cmd.Parameters["@Staff_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TrackingNo", item.TrackingNo);
                        cmd.Parameters["@TrackingNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Status", item.Status);
                        cmd.Parameters["@Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_NO", item.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", item.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;



                        cmd.Parameters.AddWithValue("@MailingType", item.MailingType);
                        cmd.Parameters["@MailingType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DepartmentID", item.DepartmentID);
                        cmd.Parameters["@DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CPCode", item.CPCode);
                        cmd.Parameters["@CPCode"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@ExceptionStatus", item.ExceptionStatus);
                        //cmd.Parameters["@ExceptionStatus"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Receipent", item.Receipent);
                        cmd.Parameters["@Receipent"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@StatusChangedBy", item.StatusChangedBy);
                        //cmd.Parameters["@StatusChangedBy"].Direction = ParameterDirection.Input

                        cmd.Parameters.AddWithValue("@ProcessedBy", item.ProcessedBy);
                        cmd.Parameters["@ProcessedBy"].Direction = ParameterDirection.Input;



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

                                cmdrc.Parameters.AddWithValue("@CUS_ID", item.CUS_ID);
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
                                    objEnquiryHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objEnquiryHead.msg = rdr["RTN_MSG"].ToString();
                                }
                                else
                                {
                                    DateTime trdate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["TransactionDate"].ToString(), out trdate);

                                    objEnquiryHead.resp = true;
                                    objEnquiryHead.msg = "Enquiry";

                                    EnquiryGridViewModel objEnquiryDetail = new EnquiryGridViewModel()
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
                                        Enquirytatus = rdr["ExceptionStatus"].ToString(),
                                        TrackingNumber = rdr["TrackingNumber"].ToString(),
                                        KioskID = rdr["KioskID"].ToString(),
                                        PostageTotal = rdr["PostageTotal"].ToString(),
                                        Status = rdr["Status"].ToString(),
                                        Quantity = rdr["Quantity"].ToString(),
                                        Location = rdr["Location"].ToString(),
                                        CPCode = rdr["CPCode"].ToString(),
                                        DepartmentID = rdr["DepartmentID"].ToString(),
                                        DepartmentName = rdr["DPT_Name"].ToString(),

                                        //•	Sender
                                        RecipentName = rdr["RecipentName"].ToString(),
                                        MailItemType = rdr["MailItemType"].ToString(),
                                        ProcessedBy = rdr["ProcessedBy"].ToString(),
                                        CUS_CompanyName = rdr["CUS_CompanyName"].ToString(),
                                        SN = rdr["SN"].ToString(),

                                        //•	Customer


                                        //MailItemType = rdr["MailItemType"].ToString(),
                                        //CPCode = rdr["CPCode"].ToString(),
                                        RC = RC,
                                    };
                                    objEnquiryHead.EnquiryGridViewModelList.Add(objEnquiryDetail);
                                }

                            }
                            objEnquiryHeadList.Add(objEnquiryHead);
                        }
                        else
                        {
                            objEnquiryHead.resp = true;
                            objEnquiryHead.msg = "";
                            objEnquiryHeadList.Add(objEnquiryHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objEnquiryHead.resp = false;
                objEnquiryHead.msg = ex.Message.ToString();

                objEnquiryHeadList.Add(objEnquiryHead);

                objError.WriteLog(0, "Enquiry_Data", "get_Enquiry_grid_details", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Enquiry_Data", "get_Enquiry_grid_details", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Enquiry_Data", "get_Enquiry_grid_details", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Enquiry_Data", "get_Enquiry_grid_details", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objEnquiryHeadList;
        }

        public static List<EnquiryMailBagGridViewHeaderModel> get_Enquiry_grid_details_mailbag(MailBagEnquiryGridRequestModel item)
        {
            List<EnquiryMailBagGridViewHeaderModel> objEnquiryHeadList = new List<EnquiryMailBagGridViewHeaderModel>();
            EnquiryMailBagGridViewHeaderModel objEnquiryHead = new EnquiryMailBagGridViewHeaderModel();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objEnquiryHead.resp = false;
                objEnquiryHead.IsAuthenticated = false;
                objEnquiryHeadList.Add(objEnquiryHead);
                return objEnquiryHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_Enquiry_grid_details_mailbag";
                        cmd.CommandType = CommandType.StoredProcedure;



                        cmd.Parameters.AddWithValue("@TransactionNo", item.TransactionNo);
                        cmd.Parameters["@TransactionNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TransactionDate", item.TransactionDate);
                        cmd.Parameters["@TransactionDate"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_ID", item.CUS_ID);
                        cmd.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PCCode", item.PCCode);
                        cmd.Parameters["@PCCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UserID", item.UserID);
                        cmd.Parameters["@UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Status", item.Status);
                        cmd.Parameters["@Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_NO", item.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", item.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DepartmentID", item.DepartmentID);
                        cmd.Parameters["@DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CPCode", item.CPCode);
                        cmd.Parameters["@CPCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@KioskNumber", item.KioskNumber);
                        cmd.Parameters["@KioskNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@ContainerNumber", item.ContainerNumber);
                        cmd.Parameters["@ContainerNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BoxNumber", item.BoxNumber);
                        cmd.Parameters["@BoxNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TransactionType", item.TransactionType);
                        cmd.Parameters["@TransactionType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@StatusChangedBy", item.StatusChangedBy);
                        cmd.Parameters["@StatusChangedBy"].Direction = ParameterDirection.Input;



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

                                cmdrc.Parameters.AddWithValue("@CUS_ID", item.CUS_ID);
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
                                    objEnquiryHead.resp = Boolean.Parse(rdr["RTN_RESP"].ToString());
                                    objEnquiryHead.msg = rdr["RTN_MSG"].ToString();
                                }
                                else
                                {
                                    DateTime trdate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["TransactionDateTime"].ToString(), out trdate);

                                    DateTime srdate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["ServerSyncDateTime"].ToString(), out trdate);

                                    DateTime crdate = DateTime.MinValue;
                                    DateTime.TryParse(rdr["CreateDateTime"].ToString(), out trdate);

                                    objEnquiryHead.resp = true;
                                    objEnquiryHead.msg = "Enquiry";

                                    EnquiryMailBagGridViewModel objEnquiryDetail = new EnquiryMailBagGridViewModel()
                                    {
                                        AID = rdr["AID"].ToString(),
                                        TransactionNo = rdr["TransactionNo"].ToString(),
                                        BagType = rdr["BagType"].ToString(),
                                        ContainerID = rdr["ContainerID"].ToString(),
                                        SealID = rdr["SealID"].ToString(),
                                        Action = rdr["Action"].ToString(),
                                        BoxNo = rdr["BoxNo"].ToString(),
                                        TransactionType = rdr["TransactionType"].ToString(),
                                        CutomerID = rdr["CutomerID"].ToString(),
                                        TransactionDateTime = trdate,
                                        ServerSyncDateTime = srdate,
                                        TripNo = rdr["TripNo"].ToString(),
                                        UserID = rdr["UserID"].ToString(),
                                        DeviceNo = rdr["DeviceNo"].ToString(),
                                        DeviceTypeId = rdr["DeviceTypeId"].ToString(),
                                        VendorID = rdr["VendorID"].ToString(),
                                        LocationID = rdr["LocationID"].ToString(),
                                        CPCode = rdr["CPCode"].ToString(),
                                        IsNoBag = rdr["IsNoBag"].ToString(),
                                        CreateDateTime = crdate,
                                        IsAcknowledgedWithKioski = rdr["IsAcknowledgedWithKioski"].ToString(),
                                        RequestReferenceID = rdr["RequestReferenceID"].ToString(),
                                        isLooseMail = rdr["isLooseMail"].ToString(),


                                        RC = RC,
                                    };
                                    objEnquiryHead.EnquiryGridViewModelList.Add(objEnquiryDetail);
                                }

                            }
                            objEnquiryHeadList.Add(objEnquiryHead);
                        }
                        else
                        {
                            objEnquiryHead.resp = true;
                            objEnquiryHead.msg = "";
                            objEnquiryHeadList.Add(objEnquiryHead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objEnquiryHead.resp = false;
                objEnquiryHead.msg = ex.Message.ToString();

                objEnquiryHeadList.Add(objEnquiryHead);

                objError.WriteLog(0, "Enquiry_Data", "get_Enquiry_grid_details_mailbag", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Enquiry_Data", "get_Enquiry_grid_details_mailbag", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Enquiry_Data", "get_Enquiry_grid_details_mailbag", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Enquiry_Data", "get_Enquiry_grid_details_mailbag", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objEnquiryHeadList;
        }
    }
}