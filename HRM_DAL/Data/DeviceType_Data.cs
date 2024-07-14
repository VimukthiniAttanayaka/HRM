using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class DeviceType_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_device_type(DeviceTypeModel item)//ok
        {
            List<ReturnResponse> objDTHeadList = new List<ReturnResponse>();
            List<SPResponse> objResponseList = new List<SPResponse>();
            ReturnResponse objDTHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objDTHead.resp = false;
                objDTHead.IsAuthenticated = false;
                objDTHeadList.Add(objDTHead);
                return objDTHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_insert_device_type";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DT_ID", item.DT_ID);
                        cmd.Parameters["@DT_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DT_Name", item.DT_Name);
                        cmd.Parameters["@DT_Name"].Direction = ParameterDirection.Input;

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
                                objDTHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objDTHeadList.Add(objDTHead);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objDTHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objDTHeadList.Add(objDTHead);

                objError.WriteLog(0, "DeviceType_Data", "add_new_device_type", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DeviceType_Data", "add_new_device_type", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DeviceType_Data", "add_new_device_type", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DeviceType_Data", "add_new_device_type", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objDTHeadList;
        }

        public static List<ReturnResponse> modify_device_type(DeviceTypeModel item)//ok
        {
            List<ReturnResponse> objDTHeadList = new List<ReturnResponse>();
            ReturnResponse objDTHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objDTHead.resp = false;
                objDTHead.IsAuthenticated = false;
                objDTHeadList.Add(objDTHead);
                return objDTHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_modify_device_type";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DT_ID", item.DT_ID);
                        cmd.Parameters["@DT_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DT_Name", item.DT_Name);
                        cmd.Parameters["@DT_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DT_Status", item.DT_Status);
                        cmd.Parameters["@DT_Status"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objDTHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objDTHeadList.Add(objDTHead);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objDTHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objDTHeadList.Add(objDTHead);

                objError.WriteLog(0, "DeviceType_Data", "modify_device_type", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DeviceType_Data", "modify_device_type", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DeviceType_Data", "modify_device_type", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DeviceType_Data", "modify_device_type", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objDTHeadList;
        }


        public static List<ReturnResponse> inactivate_device_type(InactiveDeviceTypeModel item)//ok
        {
            List<ReturnResponse> objDTHeadList = new List<ReturnResponse>();
            ReturnResponse objDTHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objDTHead.resp = false;
                objDTHead.IsAuthenticated = false;
                objDTHeadList.Add(objDTHead);
                return objDTHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_del_devicetype";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DT_ID", item.DT_ID);
                        cmd.Parameters["@DT_ID"].Direction = ParameterDirection.Input;

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
                                objDTHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objDTHeadList.Add(objDTHead);

                            }
                        }
                    }

                    return objDTHeadList;
                }

                return objDTHeadList;
            }
            catch (Exception ex)
            {
                objDTHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objDTHeadList.Add(objDTHead);

                objError.WriteLog(0, "DeviceType_Data", "inactivate_device_type", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DeviceType_Data", "inactivate_device_type", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DeviceType_Data", "inactivate_device_type", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DeviceType_Data", "inactivate_device_type", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objDTHeadList;
            }
        }

        public static List<ReturnDeviceTypeModelHead> get_device_type_all(GetDeviceTypeAllModel DTall)//ok
        {
            List<ReturnDeviceTypeModelHead> objDTHeadList = new List<ReturnDeviceTypeModelHead>();
            ReturnDeviceTypeModelHead objDTHead = new ReturnDeviceTypeModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(DTall) == false)
            {
                objDTHead.resp = false;
                objDTHead.IsAuthenticated = false;
                objDTHeadList.Add(objDTHead);
                return objDTHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    lconn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_devicetype_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", DTall.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", DTall.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DT_ID", DTall.DT_ID);
                        cmd.Parameters["@DT_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DT_Name", DTall.DT_Name);
                        cmd.Parameters["@DT_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DT_Status", DTall.DT_Status);
                        cmd.Parameters["@DT_Status"].Direction = ParameterDirection.Input;

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_devicetype_count";
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
                                ReturnDeviceTypeModel objDTData = new ReturnDeviceTypeModel();

                                objDTHead.resp = true;
                                objDTHead.msg = "Device Type";

                                objDTData.DT_ID = rdr["DT_ID"].ToString();
                                objDTData.DT_Name = rdr["DT_Name"].ToString();
                                objDTData.DT_Status = rdr["DT_Status"].ToString();
                                objDTData.DT_CreatedBy = rdr["DT_CreatedBy"].ToString();
                                objDTData.DT_CreatedDateTime = rdr["DT_CreatedDateTime"].ToString();
                                objDTData.DT_ModifiedBy = rdr["DT_ModifiedBy"].ToString();
                                objDTData.DT_ModifiedDateTime = rdr["DT_ModifiedDateTime"].ToString();
                                objDTData.RC = RC;

                                //objUserData.UserGroup.Add(objUserHead);

                                if (objDTHead.DeviceType == null)
                                {
                                    objDTHead.DeviceType = new List<ReturnDeviceTypeModel>();
                                }

                                objDTHead.DeviceType.Add(objDTData);
                            }
                            objDTHeadList.Add(objDTHead);
                        }
                        else
                        {
                            objDTHead.resp = true;
                            objDTHead.msg = "";
                            objDTHeadList.Add(objDTHead);
                        }
                    }
                    return objDTHeadList;
                }
            }
            catch (Exception ex)
            {

                objDTHead = new ReturnDeviceTypeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objDTHeadList.Add(objDTHead);

                objError.WriteLog(0, "DeviceType_Data", "get_device_type_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DeviceType_Data", "get_device_type_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DeviceType_Data", "get_device_type_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DeviceType_Data", "get_device_type_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objDTHeadList;

        }

        public static List<ReturnDeviceTypeModelHead> get_device_type_single(GetDeviceTypesingleModel DTsingle)
        {
            List<ReturnDeviceTypeModelHead> objDTHeadList = new List<ReturnDeviceTypeModelHead>();
            ReturnDeviceTypeModelHead objDTHead = new ReturnDeviceTypeModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(DTsingle) == false)
            {
                objDTHead.resp = false;
                objDTHead.IsAuthenticated = false;
                objDTHeadList.Add(objDTHead);
                return objDTHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_devicetype_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DT_ID", DTsingle.DT_ID);
                        cmd.Parameters["@DT_ID"].Direction = ParameterDirection.Input;



                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnDeviceTypeModel objDTData = new ReturnDeviceTypeModel();

                                string RC;


                                objDTHead.resp = true;
                                objDTHead.msg = "Device Type";

                                objDTData.DT_ID = rdr["DT_ID"].ToString();
                                objDTData.DT_Name = rdr["DT_Name"].ToString();
                                objDTData.DT_Status = rdr["DT_Status"].ToString();
                                objDTData.RC = "1";

                                if (objDTHead.DeviceType == null)
                                {
                                    objDTHead.DeviceType = new List<ReturnDeviceTypeModel>();
                                }

                                objDTHead.DeviceType.Add(objDTData);

                                objDTHeadList.Add(objDTHead);

                            }

                        }
                        else
                        {
                            objDTHead.resp = true;
                            objDTHead.msg = "";
                            objDTHeadList.Add(objDTHead);


                        }
                    }

                    return objDTHeadList;

                }
            }
            catch (Exception ex)
            {
                objDTHead = new ReturnDeviceTypeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objDTHeadList.Add(objDTHead);

                objError.WriteLog(0, "DeviceType_Data", "get_device_type_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DeviceType_Data", "get_device_type_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DeviceType_Data", "get_device_type_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DeviceType_Data", "get_device_type_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objDTHeadList;

        }

    }
}