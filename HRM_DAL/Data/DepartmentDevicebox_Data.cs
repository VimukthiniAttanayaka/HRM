using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class DepartmentDevicebox_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_departmentdevicebox(DepartmentDeviceboxModel item)//ok
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


                        cmd.CommandText = "sp_insert_department_devicebox";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DPDB_CustomerID", item.DPDB_CustomerID);
                        cmd.Parameters["@DPDB_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPDB_DepartmentID", item.DPDB_DepartmentID);
                        cmd.Parameters["@DPDB_DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPDB_DeviceNo", item.DPDB_DeviceNo);
                        cmd.Parameters["@DPDB_DeviceNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPDB_BoxNo", item.DPDB_BoxNo);
                        cmd.Parameters["@DPDB_BoxNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPDB_DeviceTypeNo", item.DPDB_DeviceTypeNo);
                        cmd.Parameters["@DPDB_DeviceTypeNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPDB_VendorID", item.DPDB_VendorID);
                        cmd.Parameters["@DPDB_VendorID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "DepartmentDevicebox_Data", "add_new_departmentdevicebox", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentDevicebox_Data", "add_new_departmentdevicebox", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentDevicebox_Data", "add_new_departmentdevicebox", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentDevicebox_Data", "add_new_departmentdevicebox", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        public static List<ReturnResponse> modify_departmentdevicebox(DepartmentDeviceboxModel item)//ok
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


                        cmd.CommandText = "sp_modify_department_devicebox";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DPDB_CustomerID", item.DPDB_CustomerID);
                        cmd.Parameters["@DPDB_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPDB_DepartmentID", item.DPDB_DepartmentID);
                        cmd.Parameters["@DPDB_DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPDB_DeviceNo", item.DPDB_DeviceNo);
                        cmd.Parameters["@DPDB_DeviceNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPDB_BoxNo", item.DPDB_BoxNo);
                        cmd.Parameters["@DPDB_BoxNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPDB_DeviceTypeNo", item.DPDB_DeviceTypeNo);
                        cmd.Parameters["@DPDB_DeviceTypeNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPDB_VendorID", item.DPDB_VendorID);
                        cmd.Parameters["@DPDB_VendorID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPDB_Status", item.DPDB_Status);
                        cmd.Parameters["@DPDB_Status"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "DepartmentDevicebox_Data", "modify_departmentdevicebox", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentDevicebox_Data", "modify_departmentdevicebox", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentDevicebox_Data", "modify_departmentdevicebox", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentDevicebox_Data", "modify_departmentdevicebox", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        public static List<ReturnResponse> inactivate_departmentdevicebox(InactiveDepartmentDeviceboxModel item)//ok
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


                        cmd.CommandText = "sp_del_department_devicebox";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DPDB_CustomerID", item.DPDB_CustomerID);
                        cmd.Parameters["@DPDB_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPDB_DepartmentID", item.DPDB_DepartmentID);
                        cmd.Parameters["@DPDB_DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPDB_DeviceNo", item.DPDB_DeviceNo);
                        cmd.Parameters["@DPDB_DeviceNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPDB_BoxNo", item.DPDB_BoxNo);
                        cmd.Parameters["@DPDB_BoxNo"].Direction = ParameterDirection.Input;

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
                        return objHeadList;

                    }
                }
                return objHeadList;
            }
            catch (Exception ex)
            {
                objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentDevicebox_Data", "PostUsers", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentDevicebox_Data", "PostUsers", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentDevicebox_Data", "PostUsers", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentDevicebox_Data", "PostUsers", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objHeadList;
            }




        }

        public static List<ReturDepartmentDeviceboxModelHead> get_departmentdevicebox_all(GetDepartmentDeviceboxAllModel item)//ok
        {
            List<ReturDepartmentDeviceboxModelHead> objHeadList = new List<ReturDepartmentDeviceboxModelHead>();
            ReturDepartmentDeviceboxModelHead objHead = new ReturDepartmentDeviceboxModelHead();

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
                        lconn.Open();

                        cmd.CommandText = "sp_get_department_devicebox_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", item.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", item.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_CompanyName", item.CUS_CompanyName);
                        cmd.Parameters["@CUS_CompanyName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPT_Name", item.DPT_Name);
                        cmd.Parameters["@DPT_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPDB_DeviceNo", item.DPDB_DeviceNo);
                        cmd.Parameters["@DPDB_DeviceNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPDB_BoxNo", item.DPDB_BoxNo);
                        cmd.Parameters["@DPDB_BoxNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@KV_CompanyName", item.KV_CompanyName);
                        cmd.Parameters["@KV_CompanyName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPDB_Status", item.DPDB_Status);
                        cmd.Parameters["@DPDB_Status"].Direction = ParameterDirection.Input;

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_department_devicebox_count";
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
                                ReturnDepartmentDeviceboxModel objData = new ReturnDepartmentDeviceboxModel();

                                objHead.resp = true;
                                objHead.msg = "Department Devicebox";

                                objData.DPDB_CustomerID = rdr["DPDB_CustomerID"].ToString();
                                objData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objData.DPDB_DepartmentID = rdr["DPDB_DepartmentID"].ToString();
                                objData.DPT_Name = rdr["DPT_Name"].ToString();
                                objData.DPDB_DeviceNo = rdr["DPDB_DeviceNo"].ToString();
                                objData.DV_Name = rdr["DV_Name"].ToString();
                                objData.DPDB_BoxNo = rdr["DPDB_BoxNo"].ToString();
                                objData.DPDB_DeviceTypeNo = rdr["DPDB_DeviceTypeNo"].ToString();
                                objData.DT_Name = rdr["DT_Name"].ToString();
                                objData.DPDB_VendorID = rdr["DPDB_VendorID"].ToString();
                                objData.KV_CompanyName = rdr["KV_CompanyName"].ToString();
                                objData.DPDB_Status = rdr["DPDB_Status"].ToString();

                                objData.DPDB_CreatedBy = rdr["DPDB_CreatedBy"].ToString();
                                objData.DPDB_CreatedDateTime = rdr["DPDB_CreatedDateTime"].ToString();
                                objData.DPDB_ModifiedBy = rdr["DPDB_ModifiedBy"].ToString();
                                objData.DPDB_ModifiedDateTime = rdr["DPDB_ModifiedDateTime"].ToString();
                                objData.RC = RC;


                                if (objHead.DepartmentDB == null)
                                {
                                    objHead.DepartmentDB = new List<ReturnDepartmentDeviceboxModel>();
                                }

                                objHead.DepartmentDB.Add(objData);

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

                objHead = new ReturDepartmentDeviceboxModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentDevicebox_Data", "get_departmentdevicebox_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentDevicebox_Data", "get_departmentdevicebox_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentDevicebox_Data", "get_departmentdevicebox_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentDevicebox_Data", "get_departmentdevicebox_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        public static List<ReturDepartmentDeviceboxModelHead> get_departmentdevicebox_single(GetDepartmentDeviceboxSingleModel item)
        {
            List<ReturDepartmentDeviceboxModelHead> objHeadList = new List<ReturDepartmentDeviceboxModelHead>();
            ReturDepartmentDeviceboxModelHead objHead = new ReturDepartmentDeviceboxModelHead();

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

                        cmd.CommandText = "sp_get_department_devicebox_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DPDB_CustomerID", item.DPDB_CustomerID);
                        cmd.Parameters["@DPDB_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPDB_DepartmentID", item.DPDB_DepartmentID);
                        cmd.Parameters["@DPDB_DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPDB_DeviceNo", item.DPDB_DeviceNo);
                        cmd.Parameters["@DPDB_DeviceNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPDB_BoxNo", item.DPDB_BoxNo);
                        cmd.Parameters["@DPDB_BoxNo"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnDepartmentDeviceboxModel objData = new ReturnDepartmentDeviceboxModel();

                                objHead.resp = true;
                                objHead.msg = "Department";

                                objData.DPDB_CustomerID = rdr["DPDB_CustomerID"].ToString();
                                objData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objData.DPDB_DepartmentID = rdr["DPDB_DepartmentID"].ToString();
                                objData.DPT_Name = rdr["DPT_Name"].ToString();
                                objData.DPDB_DeviceNo = rdr["DPDB_DeviceNo"].ToString();
                                objData.DV_Name = rdr["DV_Name"].ToString();
                                objData.DPDB_BoxNo = rdr["DPDB_BoxNo"].ToString();
                                objData.DPDB_DeviceTypeNo = rdr["DPDB_DeviceTypeNo"].ToString();
                                objData.DT_Name = rdr["DT_Name"].ToString();
                                objData.DPDB_VendorID = rdr["DPDB_VendorID"].ToString();
                                objData.KV_CompanyName = rdr["KV_CompanyName"].ToString();
                                objData.DPDB_Status = rdr["DPDB_Status"].ToString();
                                objData.RC = "1";

                                if (objHead.DepartmentDB == null)
                                {
                                    objHead.DepartmentDB = new List<ReturnDepartmentDeviceboxModel>();
                                }

                                objHead.DepartmentDB.Add(objData);

                                objHeadList.Add(objHead);

                            }

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

                objHead = new ReturDepartmentDeviceboxModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentDevicebox_Data", "get_departmentdevicebox_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentDevicebox_Data", "get_departmentdevicebox_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentDevicebox_Data", "get_departmentdevicebox_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentDevicebox_Data", "get_departmentdevicebox_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }



    }








}








