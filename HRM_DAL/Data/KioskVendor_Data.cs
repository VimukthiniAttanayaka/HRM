using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class KioskVendor_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_kiosk_vendor(KVMasterModel item)//ok
        {
            List<ReturnResponse> objKVHeadList = new List<ReturnResponse>();
            ReturnResponse objKVHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objKVHead.resp = false;
                objKVHead.IsAuthenticated = false;
                objKVHeadList.Add(objKVHead);
                return objKVHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_insert_kiosk_vendor";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@KV_ID", item.KV_ID);
                        cmd.Parameters["@KV_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@KV_CompanyName", item.KV_CompanyName);
                        cmd.Parameters["@KV_CompanyName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objKVHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objKVHeadList.Add(objKVHead);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objKVHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objKVHeadList.Add(objKVHead);

                objError.WriteLog(0, "KioskVendor_Data", "add_new_kiosk_vendor", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "KioskVendor_Data", "add_new_kiosk_vendor", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "KioskVendor_Data", "add_new_kiosk_vendor", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "KioskVendor_Data", "add_new_kiosk_vendor", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objKVHeadList;
        }

        public static List<ReturnResponse> modify_kiosk_vendor(KVMasterModel item)//ok
        {
            List<ReturnResponse> objKVHeadList = new List<ReturnResponse>();
            ReturnResponse objKVHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objKVHead.resp = false;
                objKVHead.IsAuthenticated = false;
                objKVHeadList.Add(objKVHead);
                return objKVHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_modify_kiosk_vendor";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@KV_ID", item.KV_ID);
                        cmd.Parameters["@KV_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@KV_CompanyName", item.KV_CompanyName);
                        cmd.Parameters["@KV_CompanyName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@KV_Status", item.KV_Status);
                        cmd.Parameters["@KV_Status"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);


                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objKVHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objKVHeadList.Add(objKVHead);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objKVHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objKVHeadList.Add(objKVHead);

                objError.WriteLog(0, "KioskVendor_Data", "modify_kiosk_vendor", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "KioskVendor_Data", "modify_kiosk_vendor", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "KioskVendor_Data", "modify_kiosk_vendor", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "KioskVendor_Data", "modify_kiosk_vendor", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objKVHeadList;
        }

        public static List<ReturnResponse> inactivate_kiosk_vendor(InactiveKVMasterModel item)//ok
        {
            List<ReturnResponse> objKVHeadList = new List<ReturnResponse>();
            ReturnResponse objKVHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objKVHead.resp = false;
                objKVHead.IsAuthenticated = false;
                objKVHeadList.Add(objKVHead);
                return objKVHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_del_kiosk_vendor";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@KV_ID", item.KV_ID);
                        cmd.Parameters["@KV_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objKVHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objKVHeadList.Add(objKVHead);
                            }
                        }
                    }

                    return objKVHeadList;
                }

                return objKVHeadList;
            }
            catch (Exception ex)
            {
                objKVHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objKVHeadList.Add(objKVHead);

                objError.WriteLog(0, "KioskVendor_Data", "inactivate_kiosk_vendor", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "KioskVendor_Data", "inactivate_kiosk_vendor", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "KioskVendor_Data", "inactivate_kiosk_vendor", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "KioskVendor_Data", "inactivate_kiosk_vendor", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objKVHeadList;
            }
        }

        public static List<ReturKVModelHead> get_kiosk_vendor_all(GetKVMasterAllModel KVall)//ok
        {
            List<ReturKVModelHead> objKVHeadList = new List<ReturKVModelHead>();
            ReturKVModelHead objKVHead = new ReturKVModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(KVall) == false)
            {
                objKVHead.resp = false;
                objKVHead.IsAuthenticated = false;
                objKVHeadList.Add(objKVHead);
                return objKVHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    //ReturKVModelHead objKVHead = new ReturKVModelHead();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_kiosk_vendor_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", KVall.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", KVall.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@KV_ID", KVall.KV_ID);
                        cmd.Parameters["@KV_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@KV_CompanyName", KVall.KV_CompanyName);
                        cmd.Parameters["@KV_CompanyName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@KV_Status", KVall.KV_Status);
                        cmd.Parameters["@KV_Status"].Direction = ParameterDirection.Input;

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_kiosk_vendor_count";
                            cmdrc.CommandType = CommandType.StoredProcedure;
                            SqlDataReader rdrrc = cmdrc.ExecuteReader();
                            rdrrc.Read();
                            RC = rdrrc["RC"].ToString();
                            rdrrc.Close();
                        }

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnKVMasterModel objKVData = new ReturnKVMasterModel();

                                objKVHead.resp = true;
                                objKVHead.msg = "Kiosk Vendor";

                                objKVData.KV_ID = rdr["KV_ID"].ToString();
                                objKVData.KV_CompanyName = rdr["KV_CompanyName"].ToString();
                                objKVData.KV_Status = rdr["KV_Status"].ToString();

                                objKVData.KV_CreatedBy = rdr["KV_CreatedBy"].ToString();
                                objKVData.KV_CreatedDateTime = rdr["KV_CreatedDateTime"].ToString();
                                objKVData.KV_ModifiedBy = rdr["KV_ModifiedBy"].ToString();
                                objKVData.KV_ModifiedDateTime = rdr["KV_ModifiedDateTime"].ToString();
                                objKVData.RC = RC;


                                //objUserData.UserGroup.Add(objUserHead);

                                if (objKVHead.KioskVendor == null)
                                {
                                    objKVHead.KioskVendor = new List<ReturnKVMasterModel>();
                                }

                                objKVHead.KioskVendor.Add(objKVData);
                            }
                            objKVHeadList.Add(objKVHead);

                        }
                        else
                        {
                            objKVHead.resp = true;
                            objKVHead.msg = "";
                            objKVHeadList.Add(objKVHead);


                        }


                    }

                    return objKVHeadList;
                }
            }

            catch (Exception ex)
            {

                objKVHead = new ReturKVModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objKVHeadList.Add(objKVHead);

                objError.WriteLog(0, "KioskVendor_Data", "get_kiosk_vendor_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "KioskVendor_Data", "get_kiosk_vendor_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "KioskVendor_Data", "get_kiosk_vendor_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "KioskVendor_Data", "get_kiosk_vendor_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objKVHeadList;

        }

        public static List<ReturKVModelHead> get_kiosk_vendor_single(GetKVMasterModel KVsingle)
        {
            List<ReturKVModelHead> objKVHeadList = new List<ReturKVModelHead>();
            ReturKVModelHead objKVHead = new ReturKVModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(KVsingle) == false)
            {
                objKVHead.resp = false;
                objKVHead.IsAuthenticated = false;
                objKVHeadList.Add(objKVHead);
                return objKVHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    objKVHead = new ReturKVModelHead();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_kiosk_vendor_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@KV_ID", KVsingle.KV_ID);
                        cmd.Parameters["@KV_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnKVMasterModel objKVData = new ReturnKVMasterModel();

                                objKVHead.resp = true;
                                objKVHead.msg = "Kiosk Vendor";

                                objKVData.KV_ID = rdr["KV_ID"].ToString();
                                objKVData.KV_CompanyName = rdr["KV_CompanyName"].ToString();
                                objKVData.KV_Status = rdr["KV_Status"].ToString();
                                objKVData.RC = "1";

                                if (objKVHead.KioskVendor == null)
                                {
                                    objKVHead.KioskVendor = new List<ReturnKVMasterModel>();
                                }

                                objKVHead.KioskVendor.Add(objKVData);
                            }
                            objKVHeadList.Add(objKVHead);

                        }
                        else
                        {
                            objKVHead.resp = true;
                            objKVHead.msg = "";
                            objKVHeadList.Add(objKVHead);


                        }

                    }

                    return objKVHeadList;
                }
            }
            catch (Exception ex)
            {

                objKVHead = new ReturKVModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objKVHeadList.Add(objKVHead);

                objError.WriteLog(0, "KioskVendor_Data", "get_kiosk_vendor_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "KioskVendor_Data", "get_kiosk_vendor_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "KioskVendor_Data", "get_kiosk_vendor_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "KioskVendor_Data", "get_kiosk_vendor_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objKVHeadList;

        }



    }




}








