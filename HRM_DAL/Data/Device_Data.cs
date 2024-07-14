using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class Device_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_device(DeviceModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            ReturnResponse objHead = new ReturnResponse();
                
            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objHead.resp = false;
                objHead.IsAuthenticated = false;
                objHeadList.Add(objHead);
                return objHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_insert_device";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DV_ID", item.DV_ID);
                        cmd.Parameters["@DV_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DV_Name", item.DV_Name);
                        cmd.Parameters["@DV_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DV_Remarks", item.DV_Remarks);
                        cmd.Parameters["@DV_Remarks"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DV_VendorID", item.DV_VendorID);
                        cmd.Parameters["@DV_VendorID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DV_CustomerID", item.DV_CustomerID);
                        cmd.Parameters["@DV_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DV_LocationID", item.DV_LocationID);
                        cmd.Parameters["@DV_LocationID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DV_DeviceTypeID", item.DV_DeviceTypeID);
                        cmd.Parameters["@DV_DeviceTypeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DV_Level", item.DV_Level);
                        cmd.Parameters["@DV_Level"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objHeadList.Add(objHead);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "Device_Data", "add_new_device", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Device_Data", "add_new_device", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Device_Data", "add_new_device", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Device_Data", "add_new_device", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        public static List<ReturnResponse> modify_device(DeviceModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            ReturnResponse objHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objHead.resp = false;
                objHead.IsAuthenticated = false;
                objHeadList.Add(objHead);
                return objHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_modify_device";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DV_ID", item.DV_ID);
                        cmd.Parameters["@DV_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DV_Name", item.DV_Name);
                        cmd.Parameters["@DV_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DV_Remarks", item.DV_Remarks);
                        cmd.Parameters["@DV_Remarks"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DV_VendorID", item.DV_VendorID);
                        cmd.Parameters["@DV_VendorID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DV_CustomerID", item.DV_CustomerID);
                        cmd.Parameters["@DV_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DV_LocationID", item.DV_LocationID);
                        cmd.Parameters["@DV_LocationID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DV_Status", item.DV_Status);
                        cmd.Parameters["@DV_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DV_DeviceTypeID", item.DV_DeviceTypeID);
                        cmd.Parameters["@DV_DeviceTypeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DV_Level", item.DV_Level);
                        cmd.Parameters["@DV_Level"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objHeadList.Add(objHead);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "Device_Data", "modify_device", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Device_Data", "modify_device", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Device_Data", "modify_device", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Device_Data", "modify_device", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        public static List<ReturnResponse> inactivate_device(InactiveDeviceModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            ReturnResponse objHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objHead.resp = false;
                objHead.IsAuthenticated = false;
                objHeadList.Add(objHead);
                return objHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_del_device";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DV_ID", item.DV_ID);
                        cmd.Parameters["@DV_ID"].Direction = ParameterDirection.Input;

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
                                objHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objHeadList.Add(objHead);
                            }
                        }
                    }

                    return objHeadList;
                }
            }
            catch (Exception ex)
            {
                objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "Device_Data", "inactivate_device", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Device_Data", "inactivate_device", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Device_Data", "inactivate_device", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Device_Data", "inactivate_device", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objHeadList;
            }




        }

        public static List<ReturDeviceModelHead> get_device_all(GetDeviceAllModel item)//ok
        {
            List<ReturDeviceModelHead> objHeadList = new List<ReturDeviceModelHead>();
            ReturDeviceModelHead objHead = new ReturDeviceModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objHead.resp = false;
                objHead.IsAuthenticated = false;
                objHeadList.Add(objHead);
                return objHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    lconn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_device_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", item.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", item.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DV_ID", item.DV_ID);
                        cmd.Parameters["@DV_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DV_Name", item.DV_Name);
                        cmd.Parameters["@DV_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@KV_CompanyName", item.KV_CompanyName);
                        cmd.Parameters["@KV_CompanyName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DV_VendorID", item.DV_VendorID);
                        cmd.Parameters["@DV_VendorID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DV_DeviceTypeID", item.DV_DeviceTypeID);
                        cmd.Parameters["@DV_DeviceTypeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_CompanyName", item.CUS_CompanyName);
                        cmd.Parameters["@CUS_CompanyName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@LOC_Name", item.LOC_Name);
                        cmd.Parameters["@LOC_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DV_Status", item.DV_Status);
                        cmd.Parameters["@DV_Status"].Direction = ParameterDirection.Input;

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_device_count";
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
                                objHead.resp = true;
                                objHead.msg = "Device";

                                ReturnDeviceModel objData = new ReturnDeviceModel();

                                objData.DV_ID = rdr["DV_ID"].ToString();
                                objData.DV_Name = rdr["DV_Name"].ToString();
                                objData.DV_Remarks = rdr["DV_Remarks"].ToString();
                                objData.DV_VendorID = rdr["DV_VendorID"].ToString();
                                objData.KV_CompanyName = rdr["KV_CompanyName"].ToString();
                                objData.DV_CustomerID = rdr["DV_CustomerID"].ToString();
                                objData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objData.DV_LocationID = rdr["DV_LocationID"].ToString();
                                objData.LOC_Name = rdr["LOC_Name"].ToString();
                                objData.DV_Status = rdr["DV_Status"].ToString();

                                objData.DV_CreatedBy = rdr["DV_CreatedBy"].ToString();
                                objData.DV_CreatedDateTime = rdr["DV_CreatedDateTime"].ToString();
                                objData.DV_ModifiedBy = rdr["DV_ModifiedBy"].ToString();
                                objData.DV_ModifiedDateTime = rdr["DV_ModifiedDateTime"].ToString();
                                objData.DV_DeviceTypeID = rdr["DV_DeviceTypeID"].ToString();
                                objData.DT_Name = rdr["DT_Name"].ToString();
                                objData.DV_Level = rdr["DV_Level"].ToString();
                                objData.RC = RC;

                                //objUserData.UserGroup.Add(objUserHead);

                                if (objHead.Device == null)
                                {
                                    objHead.Device = new List<ReturnDeviceModel>();
                                }

                                objHead.Device.Add(objData);
                            }
                            objHeadList.Add(objHead);
                        }
                        else
                        {
                            objHead.resp = true;
                            objHead.msg = "";
                            objHeadList.Add(objHead);
                        }

                    }
                    return objHeadList;
                }
            }
            catch (Exception ex)
            {

                objHead = new ReturDeviceModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "Device_Data", "get_device_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Device_Data", "get_device_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Device_Data", "get_device_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Device_Data", "get_device_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        public static List<ReturDeviceModelHead> get_device_single(GetDeviceSingleModel item)
        {
            List<ReturDeviceModelHead> objHeadList = new List<ReturDeviceModelHead>();
            ReturDeviceModelHead objHead = new ReturDeviceModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objHead.resp = false;
                objHead.IsAuthenticated = false;
                objHeadList.Add(objHead);
                return objHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_device_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DV_ID", item.DV_ID);
                        cmd.Parameters["@DV_ID"].Direction = ParameterDirection.Input;

                        ReturnDeviceModel objData = new ReturnDeviceModel();

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {

                                objHead.resp = true;
                                objHead.msg = "Device";

                                objData.DV_ID = rdr["DV_ID"].ToString();
                                objData.DV_Name = rdr["DV_Name"].ToString();
                                objData.DV_Remarks = rdr["DV_Remarks"].ToString();
                                objData.DV_VendorID = rdr["DV_VendorID"].ToString();
                                objData.KV_CompanyName = rdr["KV_CompanyName"].ToString();
                                objData.DV_CustomerID = rdr["DV_CustomerID"].ToString();
                                objData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objData.DV_LocationID = rdr["DV_LocationID"].ToString();
                                objData.LOC_Name = rdr["LOC_Name"].ToString();
                                objData.DV_Status = rdr["DV_Status"].ToString();
                                objData.DV_DeviceTypeID = rdr["DV_DeviceTypeID"].ToString();
                                objData.DT_Name = rdr["DT_Name"].ToString();
                                objData.DV_Level = rdr["DV_Level"].ToString();
                                objData.RC = "1";

                                if (objHead.Device == null)
                                {
                                    objHead.Device = new List<ReturnDeviceModel>();
                                }

                                objHead.Device.Add(objData);
                            }
                            objHeadList.Add(objHead);

                        }
                        else
                        {
                            objHead.resp = true;
                            objHead.msg = "";
                            objHeadList.Add(objHead);
                        }
                    }
                    return objHeadList;
                }
            }
            catch (Exception ex)
            {

                objHead = new ReturDeviceModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "Device_Data", "get_device_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Device_Data", "get_device_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Device_Data", "get_device_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Device_Data", "get_device_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objHeadList;

        }

    }
}








