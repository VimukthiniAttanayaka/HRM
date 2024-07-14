using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class ContainerDT_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_containerdt(ContainerDTModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            List<SPResponse> objResponseList = new List<SPResponse>();
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


                        cmd.CommandText = "sp_insert_container_dispatch_type";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CT_ID", item.CT_ID);
                        cmd.Parameters["@CT_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CT_Name", item.CT_Name);
                        cmd.Parameters["@CT_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CT_Description", item.CT_Description);
                        cmd.Parameters["@CT_Description"].Direction = ParameterDirection.Input;

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
                                //SqlDataReader rdr = cmd.ExecuteReader();

                                //if (rdr.HasRows)
                                //{
                                //    while (rdr.Read())
                                //    {

                                objHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objHeadList.Add(objHead);

                            }
                        }

                        //ActivityLog.ActivityLogRequest("Saved user details", item.ID);

                        //}

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

                objError.WriteLog(0, "ContainerDT_Data", "add_new_containerdt", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ContainerDT_Data", "add_new_containerdt", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ContainerDT_Data", "add_new_containerdt", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ContainerDT_Data", "add_new_containerdt", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        public static List<ReturnResponse> modify_containerdt(ContainerDTModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            List<SPResponse> objResponseList = new List<SPResponse>();
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


                        cmd.CommandText = "sp_modify_container_dispatch_type";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CT_ID", item.CT_ID);
                        cmd.Parameters["@CT_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CT_Name", item.CT_Name);
                        cmd.Parameters["@CT_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CT_Description", item.CT_Description);
                        cmd.Parameters["@CT_Description"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CT_Status", item.CT_Status);
                        cmd.Parameters["@CT_Status"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                //SqlDataReader rdr = cmd.ExecuteReader();

                                //if (rdr.HasRows)
                                //{
                                //    while (rdr.Read())
                                //    {

                                objHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objHeadList.Add(objHead);

                            }
                        }

                        //ActivityLog.ActivityLogRequest("Saved user details", item.ID);

                        //}

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

                objError.WriteLog(0, "ContainerDT_Data", "modify_containerdt", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ContainerDT_Data", "modify_containerdt", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ContainerDT_Data", "modify_containerdt", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ContainerDT_Data", "modify_containerdt", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        public static List<ReturnResponse> inactivate_containerdt(InactiveContainerDTModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            List<SPResponse> objResponseList = new List<SPResponse>();
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

                        cmd.CommandText = "sp_del_container_dispatch_type";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CT_ID", item.CT_ID);
                        cmd.Parameters["@CT_ID"].Direction = ParameterDirection.Input;

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

                                //SqlDataReader rdr = cmd.ExecuteReader();

                                //if (rdr.HasRows)
                                //{
                                //    while (rdr.Read())
                                //    {

                                objHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objHeadList.Add(objHead);

                            }
                        }

                        //ActivityLog.ActivityLogRequest("Saved user details", item.ID);
                        return objHeadList;


                        //}

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

                objError.WriteLog(0, "ContainerDT_Data", "inactivate_containerdt", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ContainerDT_Data", "inactivate_containerdt", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ContainerDT_Data", "inactivate_containerdt", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ContainerDT_Data", "inactivate_containerdt", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objHeadList;
            }




        }

        public static List<ReturnContainerDTModelHead> get_containerdt_all(GetContainerDTAllModel item)//ok
        {
            List<ReturnContainerDTModelHead> objHeadList = new List<ReturnContainerDTModelHead>();
            ReturnContainerDTModelHead objHead = new ReturnContainerDTModelHead();

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

                        cmd.CommandText = "sp_get_container_dispatch_type_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", item.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", item.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CT_ID", item.CT_ID);
                        cmd.Parameters["@CT_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CT_Name", item.CT_Name);
                        cmd.Parameters["@CT_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CT_Description", item.CT_Description);
                        cmd.Parameters["@CT_Description"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CT_Status", item.CT_Status);
                        cmd.Parameters["@CT_Status"].Direction = ParameterDirection.Input;



                        //SqlDataReader rdr = cmd.ExecuteReader();

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_container_dispatch_type_count";
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

                                //if (rdr.HasRows)
                                //{
                                //    while (rdr.Read())
                                //    {
                                ReturnContainerDTModel objData = new ReturnContainerDTModel();

                                objHead.resp = true;
                                objHead.msg = "Container Dispatch Type";

                                objData.CT_ID = rdr["CT_ID"].ToString();
                                objData.CT_Name = rdr["CT_Name"].ToString();
                                objData.CT_Description = rdr["CT_Description"].ToString();
                                objData.CT_Status = rdr["CT_Status"].ToString();

                                objData.CT_CreatedBy = rdr["CT_CreatedBy"].ToString();
                                objData.CT_CreatedDateTime = rdr["CT_CreatedDateTime"].ToString();
                                objData.CT_ModifiedBy = rdr["CT_ModifiedBy"].ToString();
                                objData.CT_ModifiedDateTime = rdr["CT_ModifiedDateTime"].ToString();
                                objData.RC = RC;

                                if (objHead.ContainerDT == null)
                                {
                                    objHead.ContainerDT = new List<ReturnContainerDTModel>();
                                }

                                objHead.ContainerDT.Add(objData);
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

                objHead = new ReturnContainerDTModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "ContainerDT_Data", "get_containerdt_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ContainerDT_Data", "get_containerdt_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ContainerDT_Data", "get_containerdt_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ContainerDT_Data", "get_containerdt_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        public static List<ReturnContainerDTModelHead> get_containerdt_single(GetContainerDTSingleModel item)
        {
            List<ReturnContainerDTModelHead> objHeadList = new List<ReturnContainerDTModelHead>();
            ReturnContainerDTModelHead objHead = new ReturnContainerDTModelHead();

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

                        cmd.CommandText = "sp_get_container_dispatch_type_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CT_ID", item.CT_ID);
                        cmd.Parameters["@CT_ID"].Direction = ParameterDirection.Input;



                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {

                                //SqlDataReader rdr = cmd.ExecuteReader();

                                //if (rdr.HasRows)
                                //{
                                //    while (rdr.Read())
                                //    {
                                ReturnContainerDTModel objData = new ReturnContainerDTModel();

                                objHead.resp = true;
                                objHead.msg = "Container Dispatch Type";

                                objData.CT_ID = rdr["CT_ID"].ToString();
                                objData.CT_Name = rdr["CT_Name"].ToString();
                                objData.CT_Description = rdr["CT_Description"].ToString();
                                objData.CT_Status = rdr["CT_Status"].ToString();
                                objData.RC = "1";

                                if (objHead.ContainerDT == null)
                                {
                                    objHead.ContainerDT = new List<ReturnContainerDTModel>();
                                }

                                objHead.ContainerDT.Add(objData);

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

                objHead = new ReturnContainerDTModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "ContainerDT_Data", "get_containerdt_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ContainerDT_Data", "get_containerdt_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ContainerDT_Data", "get_containerdt_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ContainerDT_Data", "get_containerdt_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        public static List<ReturnContainerLTModelHead> get_container_label_types(GetContainerLTAllModel item)
        {
            List<ReturnContainerLTModelHead> objHeadList = new List<ReturnContainerLTModelHead>();
            ReturnContainerLTModelHead objHead = new ReturnContainerLTModelHead();

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

                        cmd.CommandText = "sp_get_container_label_types";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", item.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", item.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CLT_ID", item.CLT_ID);
                        cmd.Parameters["@CLT_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CLT_Name", item.CLT_Name);
                        cmd.Parameters["@CLT_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CLT_Description", item.CLT_Description);
                        cmd.Parameters["@CLT_Description"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CLT_Status", item.CLT_Status);
                        cmd.Parameters["@CLT_Status"].Direction = ParameterDirection.Input;

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_container_label_types_count";
                            cmdrc.CommandType = CommandType.StoredProcedure;
                            SqlDataReader rdrrc = cmdrc.ExecuteReader();
                            rdrrc.Read();
                            RC = rdrrc["RC"].ToString();
                            rdrrc.Close();

                        }

                        if (lconn.State == ConnectionState.Closed)
                        {
                            lconn.Open();
                        }
                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {

                                //SqlDataReader rdr = cmd.ExecuteReader();

                                //if (rdr.HasRows)
                                //{
                                //    while (rdr.Read())
                                //    {
                                ReturnContainerLTModel objData = new ReturnContainerLTModel();

                                objHead.resp = true;
                                objHead.msg = "Container Label Type";

                                objData.CLT_ID = rdr["CLT_ID"].ToString();
                                objData.CLT_Name = rdr["CLT_Name"].ToString();
                                objData.CLT_Description = rdr["CLT_Description"].ToString();
                                objData.CLT_Status = rdr["CLT_Status"].ToString();
                                objData.RC = RC;

                                if (objHead.ContainerLT == null)
                                {
                                    objHead.ContainerLT = new List<ReturnContainerLTModel>();
                                }

                                objHead.ContainerLT.Add(objData);


                            }

                        }
                        else
                        {
                            objHead.resp = true;
                            objHead.msg = "";


                        }

                        objHeadList.Add(objHead);

                    }
                    return objHeadList;

                }
            }
            catch (Exception ex)
            {

                objHead = new ReturnContainerLTModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "ContainerDT_Data", "get_container_label_types", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "ContainerDT_Data", "get_container_label_types", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "ContainerDT_Data", "get_container_label_types", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "ContainerDT_Data", "get_container_label_types", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }
    }

}








