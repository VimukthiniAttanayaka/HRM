using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using Newtonsoft.Json;

namespace HRM_DAL.Data
{
    public class EmployeeJobRole_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnEmployeeJobRoleModelHead> get_EmployeeJobRole_single(EmployeeJobRole model)//ok
        {
            List<ReturnEmployeeJobRoleModelHead> objEmployeeJobRoleHeadList = new List<ReturnEmployeeJobRoleModelHead>();
            ReturnEmployeeJobRoleModelHead objEmployeeJobRoleHead = new ReturnEmployeeJobRoleModelHead();

            if (objEmployeeJobRoleHead.EmployeeJobRole == null)
            {
                objEmployeeJobRoleHead.EmployeeJobRole = new List<ReturnEmployeeJobRoleModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objEmployeeJobRoleHead.resp = false;
                objEmployeeJobRoleHead.IsAuthenticated = false;
                objEmployeeJobRoleHeadList.Add(objEmployeeJobRoleHead);
                return objEmployeeJobRoleHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_EmployeeJobRole_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EEJR_ID", model.EEJR_ID);
                        cmd.Parameters["@EEJR_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnEmployeeJobRoleModel objEmployeeJobRole = new ReturnEmployeeJobRoleModel();

                                objEmployeeJobRoleHead.resp = true;
                                objEmployeeJobRoleHead.msg = "Get EmployeeJobRole";

                                objEmployeeJobRole.EEJR_ID = Convert.ToInt32(rdr["EEJR_ID"].ToString());
                                objEmployeeJobRole.EEJR_EmployeeID = rdr["EEJR_EmployeeID"].ToString();
                                objEmployeeJobRole.EEJR_JobRoleID = rdr["EEJR_JobRoleID"].ToString();
                                objEmployeeJobRole.EEJR_JobType = rdr["EEJR_JobType"].ToString();
                                objEmployeeJobRole.EEJR_Department = rdr["EEJR_Department"].ToString();

                                if (!string.IsNullOrEmpty(rdr["EEJR_ActiveFrom"].ToString()))
                                    objEmployeeJobRole.EEJR_ActiveFrom = Convert.ToDateTime(rdr["EEJR_ActiveFrom"].ToString());

                                if (!string.IsNullOrEmpty(rdr["EEJR_ActiveTo"].ToString()))
                                    objEmployeeJobRole.EEJR_ActiveTo = Convert.ToDateTime(rdr["EEJR_ActiveTo"].ToString());

                                objEmployeeJobRole.EEJR_Status = Convert.ToBoolean(rdr["EEJR_Status"].ToString());

                                objEmployeeJobRoleHead.EmployeeJobRole.Add(objEmployeeJobRole);

                                objEmployeeJobRoleHeadList.Add(objEmployeeJobRoleHead);
                            }

                        }
                        else
                        {
                            ReturnEmployeeJobRoleModel objEmployeeJobRole = new ReturnEmployeeJobRoleModel();
                            objEmployeeJobRoleHead.resp = true;
                            objEmployeeJobRoleHead.msg = "";
                            objEmployeeJobRoleHeadList.Add(objEmployeeJobRoleHead);


                        }


                    }
                    return objEmployeeJobRoleHeadList;

                }
            }
            catch (Exception ex)
            {
                objEmployeeJobRoleHead.resp = false;
                objEmployeeJobRoleHead.msg = ex.Message.ToString();

                objEmployeeJobRoleHeadList.Add(objEmployeeJobRoleHead);

                objError.WriteLog(0, "EmployeeJobRole_Data", "get_EmployeeJobRole_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeJobRole_Data", "get_EmployeeJobRole_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeJobRole_Data", "get_EmployeeJobRole_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeJobRole_Data", "get_EmployeeJobRole_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objEmployeeJobRoleHeadList;

        }

        public static List<ReturnEmployeeJobRoleModelHead> get_EmployeeJobRole_all(EmployeeJobRoleSearchModel model)//ok
        {
            List<ReturnEmployeeJobRoleModelHead> objEmployeeJobRoleHeadList = new List<ReturnEmployeeJobRoleModelHead>();
            ReturnEmployeeJobRoleModelHead objEmployeeJobRoleHead = new ReturnEmployeeJobRoleModelHead();

            if (objEmployeeJobRoleHead.EmployeeJobRole == null)
            {
                objEmployeeJobRoleHead.EmployeeJobRole = new List<ReturnEmployeeJobRoleModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objEmployeeJobRoleHead.resp = false;
                objEmployeeJobRoleHead.IsAuthenticated = false;
                objEmployeeJobRoleHeadList.Add(objEmployeeJobRoleHead);
                return objEmployeeJobRoleHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_EmployeeJobRole_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@EEJR_ID", model.EEJR_ID);
                        //cmd.Parameters["@EEJR_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnEmployeeJobRoleModel objEmployeeJobRole = new ReturnEmployeeJobRoleModel();

                                objEmployeeJobRoleHead.resp = true;
                                objEmployeeJobRoleHead.msg = "Get EmployeeJobRole";

                                objEmployeeJobRole.EEJR_ID = Convert.ToInt32(rdr["EEJR_ID"].ToString());
                                objEmployeeJobRole.EEJR_EmployeeID = rdr["EEJR_EmployeeID"].ToString();
                                objEmployeeJobRole.EEJR_JobRoleID = rdr["EEJR_JobRoleID"].ToString();

                                objEmployeeJobRole.EEJR_JobType = rdr["EEJR_JobType"].ToString();
                                objEmployeeJobRole.EEJR_Department = rdr["EEJR_Department"].ToString();

                                if (!string.IsNullOrEmpty(rdr["EEJR_ActiveFrom"].ToString()))
                                    objEmployeeJobRole.EEJR_ActiveFrom = Convert.ToDateTime(rdr["EEJR_ActiveFrom"].ToString());

                                if (!string.IsNullOrEmpty(rdr["EEJR_ActiveTo"].ToString()))
                                    objEmployeeJobRole.EEJR_ActiveTo = Convert.ToDateTime(rdr["EEJR_ActiveTo"].ToString());

                                objEmployeeJobRole.EEJR_Status = Convert.ToBoolean(rdr["EEJR_Status"].ToString());

                                objEmployeeJobRoleHead.EmployeeJobRole.Add(objEmployeeJobRole);

                                objEmployeeJobRoleHeadList.Add(objEmployeeJobRoleHead);
                            }

                        }
                        else
                        {
                            ReturnEmployeeJobRoleModel objEmployeeJobRole = new ReturnEmployeeJobRoleModel();
                            objEmployeeJobRoleHead.resp = true;
                            objEmployeeJobRoleHead.msg = "";
                            objEmployeeJobRoleHeadList.Add(objEmployeeJobRoleHead);


                        }


                    }
                    return objEmployeeJobRoleHeadList;

                }
            }
            catch (Exception ex)
            {
                objEmployeeJobRoleHead.resp = false;
                  objEmployeeJobRoleHead.msg = ex.Message.ToString();

                objEmployeeJobRoleHeadList.Add(objEmployeeJobRoleHead);

                objError.WriteLog(0, "EmployeeJobRole_Data", "get_EmployeeJobRole_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeJobRole_Data", "get_EmployeeJobRole_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeJobRole_Data", "get_EmployeeJobRole_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeJobRole_Data", "get_EmployeeJobRole_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objEmployeeJobRoleHeadList;

        }

        public static List<ReturnResponse> add_new_EmployeeJobRole(EmployeeJobRoleModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();
            ReturnResponse objCustHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objCustHead.resp = false;
                objCustHead.IsAuthenticated = false;
                objCustHeadList.Add(objCustHead);
                return objCustHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_insert_EmployeeJobRole";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@EEJR_ID", item.EEJR_ID);
                        //cmd.Parameters["@EEJR_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEJR_EmployeeID", item.EEJR_EmployeeID);
                        cmd.Parameters["@EEJR_EmployeeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEJR_JobRoleID", item.EEJR_JobRoleID);
                        cmd.Parameters["@EEJR_JobRoleID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEJR_ActiveFrom", item.EEJR_ActiveFrom);
                        cmd.Parameters["@EEJR_ActiveFrom"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEJR_ActiveTo", item.EEJR_ActiveTo);
                        cmd.Parameters["@EEJR_ActiveTo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEJR_Status", item.EEJR_Status);
                        cmd.Parameters["@EEJR_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEJR_Remarks", item.EEJR_Remarks);
                        cmd.Parameters["@EEJR_Remarks"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEJR_JobType", item.EEJR_JobType);
                        cmd.Parameters["@EEJR_JobType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEJR_Department", item.EEJR_Department);
                        cmd.Parameters["@EEJR_Department"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objCustHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objCustHeadList.Add(objCustHead);

                            }
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                objCustHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objCustHead);

                objError.WriteLog(0, "EmployeeJobRole_Data", "add_new_EmployeeJobRole", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeJobRole_Data", "add_new_EmployeeJobRole", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeJobRole_Data", "add_new_EmployeeJobRole", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeJobRole_Data", "add_new_EmployeeJobRole", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> modify_EmployeeJobRole(EmployeeJobRoleModel item)//ok
        {
            List<ReturnResponse> objCustHeadList = new List<ReturnResponse>();
            ReturnResponse objCustHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objCustHead.resp = false;
                objCustHead.IsAuthenticated = false;
                objCustHeadList.Add(objCustHead);
                return objCustHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_modify_EmployeeJobRole";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;


                        cmd.Parameters.AddWithValue("@EEJR_ID", item.EEJR_ID);
                        cmd.Parameters["@EEJR_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEJR_EmployeeID", item.EEJR_EmployeeID);
                        cmd.Parameters["@EEJR_EmployeeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEJR_JobRoleID", item.EEJR_JobRoleID);
                        cmd.Parameters["@EEJR_JobRoleID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEJR_ActiveFrom", item.EEJR_ActiveFrom);
                        cmd.Parameters["@EEJR_ActiveFrom"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEJR_ActiveTo", item.EEJR_ActiveTo);
                        cmd.Parameters["@EEJR_ActiveTo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEJR_Status", item.EEJR_Status);
                        cmd.Parameters["@EEJR_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEJR_Remarks", item.EEJR_Remarks);
                        cmd.Parameters["@EEJR_Remarks"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEJR_JobType", item.EEJR_JobType);
                        cmd.Parameters["@EEJR_JobType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEJR_Department", item.EEJR_Department);
                        cmd.Parameters["@EEJR_Department"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objCustHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objCustHeadList.Add(objCustHead);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objCustHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objCustHead);

                objError.WriteLog(0, "EmployeeJobRole_Data", "add_new_EmployeeJobRole", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeJobRole_Data", "add_new_EmployeeJobRole", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeJobRole_Data", "add_new_EmployeeJobRole", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeJobRole_Data", "add_new_EmployeeJobRole", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_EmployeeJobRole(InactiveEEJRModel item)//ok
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            ReturnResponse objUserHead = new ReturnResponse();
            List<SPResponse> objResponseList = new List<SPResponse>();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
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



                        cmd.CommandText = "sp_del_EmployeeJobRole";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EEJR_ID", item.EEJR_ID);
                        cmd.Parameters["@EEJR_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;



                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objUserHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objUserHeadList.Add(objUserHead);

                            }
                        }
                        return objUserHeadList;
                    }
                    return objUserHeadList;
                }
            }
            catch (Exception ex)
            {
                objUserHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "EmployeeJobRole_Data", "inactivate_EmployeeJobRole", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeJobRole_Data", "inactivate_EmployeeJobRole", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeJobRole_Data", "inactivate_EmployeeJobRole", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeJobRole_Data", "inactivate_EmployeeJobRole", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

