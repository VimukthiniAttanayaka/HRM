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
    public class JobRole_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnJobRoleModelHead> get_JobRoles_single(JobRole model)//ok
        {
            List<ReturnJobRoleModelHead> objJobRoleHeadList = new List<ReturnJobRoleModelHead>();
            ReturnJobRoleModelHead objJobRoleHead = new ReturnJobRoleModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objJobRoleHead.resp = false;
                objJobRoleHead.IsAuthenticated = false;
                objJobRoleHeadList.Add(objJobRoleHead);
                return objJobRoleHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_JobRoles_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MDJR_JobRoleID", model.MDJR_JobRoleID);
                        cmd.Parameters["@MDJR_JobRoleID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnJobRoleModel objJobRole = new ReturnJobRoleModel();

                                objJobRoleHead.resp = true;
                                objJobRoleHead.msg = "Get JobRole";

                                objJobRole.MDJR_JobRoleID = rdr["MDJR_JobRoleID"].ToString();
                                
                                objJobRole.MDJR_JobRole = rdr["MDJR_JobRole"].ToString();
                                objJobRole.MDJR_Status = Convert.ToBoolean(rdr["MDJR_Status"].ToString());

                                if (objJobRoleHead.JobRole == null)
                                {
                                    objJobRoleHead.JobRole = new List<ReturnJobRoleModel>();
                                }

                                objJobRoleHead.JobRole.Add(objJobRole);

                                objJobRoleHeadList.Add(objJobRoleHead);
                            }

                        }
                        else
                        {
                            ReturnJobRoleModel objJobRole = new ReturnJobRoleModel();
                            objJobRoleHead.resp = true;
                            objJobRoleHead.msg = "";
                            objJobRoleHeadList.Add(objJobRoleHead);


                        }


                    }
                    return objJobRoleHeadList;

                }
            }
            catch (Exception ex)
            {
                objJobRoleHead = new ReturnJobRoleModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objJobRoleHeadList.Add(objJobRoleHead);

                objError.WriteLog(0, "JobRole_Data", "get_JobRoles_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "JobRole_Data", "get_JobRoles_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "JobRole_Data", "get_JobRoles_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "JobRole_Data", "get_JobRoles_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objJobRoleHeadList;

        }

        public static List<ReturnJobRoleModelHead> get_JobRole_all(JobRoleSearchModel model)//ok
        {
            List<ReturnJobRoleModelHead> objJobRoleHeadList = new List<ReturnJobRoleModelHead>();
            ReturnJobRoleModelHead objJobRoleHead = new ReturnJobRoleModelHead();

            if (objJobRoleHead.JobRole == null)
            {
                objJobRoleHead.JobRole = new List<ReturnJobRoleModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objJobRoleHead.resp = false;
                objJobRoleHead.IsAuthenticated = false;
                objJobRoleHeadList.Add(objJobRoleHead);
                return objJobRoleHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_JobRole_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@MDJR_JobRoleID", model.MDJR_JobRoleID);
                        //cmd.Parameters["@MDJR_JobRoleID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnJobRoleModel objJobRole = new ReturnJobRoleModel();

                                objJobRoleHead.resp = true;
                                objJobRoleHead.msg = "Get JobRole";

                                objJobRole.MDJR_JobRoleID = rdr["MDJR_JobRoleID"].ToString();                                
                                objJobRole.MDJR_JobRole = rdr["MDJR_JobRole"].ToString();
                                objJobRole.MDJR_Status = Convert.ToBoolean(rdr["MDJR_Status"].ToString());


                                objJobRoleHead.JobRole.Add(objJobRole);

                                objJobRoleHeadList.Add(objJobRoleHead);
                            }

                        }
                        else
                        {
                            ReturnJobRoleModel objJobRole = new ReturnJobRoleModel();
                            objJobRoleHead.resp = true;
                            objJobRoleHead.msg = "";
                            objJobRoleHeadList.Add(objJobRoleHead);


                        }


                    }
                    return objJobRoleHeadList;

                }
            }
            catch (Exception ex)
            {
                objJobRoleHead.resp = false;
                objJobRoleHead.msg = ex.Message.ToString();

                objJobRoleHeadList.Add(objJobRoleHead);

                objError.WriteLog(0, "JobRole_Data", "get_JobRole_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "JobRole_Data", "get_JobRole_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "JobRole_Data", "get_JobRole_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "JobRole_Data", "get_JobRole_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objJobRoleHeadList;

        }

        public static List<ReturnResponse> add_new_JobRole(JobRoleModel item)//ok
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


                        cmd.CommandText = "sp_insert_JobRole";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDJR_JobRoleID", item.MDJR_JobRoleID);
                        cmd.Parameters["@MDJR_JobRoleID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDJR_JobRole", item.MDJR_JobRole);
                        cmd.Parameters["@MDJR_JobRole"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDJR_Status", item.MDJR_Status);
                        cmd.Parameters["@MDJR_Status"].Direction = ParameterDirection.Input;

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
                        else
                        {
                            objCustHead = new ReturnResponse
                            {
                                resp = true,
                                msg = ""
                            };
                            objCustHeadList.Add(objCustHead);
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

                objError.WriteLog(0, "JobRole_Data", "add_new_JobRole", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "JobRole_Data", "add_new_JobRole", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "JobRole_Data", "add_new_JobRole", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "JobRole_Data", "add_new_JobRole", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> modify_JobRole(JobRoleModel item)//ok
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


                        cmd.CommandText = "sp_modify_JobRole";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDJR_JobRoleID", item.MDJR_JobRoleID);
                        cmd.Parameters["@MDJR_JobRoleID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDJR_JobRole", item.MDJR_JobRole);
                        cmd.Parameters["@MDJR_JobRole"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDJR_Status", item.MDJR_Status);
                        cmd.Parameters["@MDJR_Status"].Direction = ParameterDirection.Input;

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
                        else
                        {
                            objCustHead = new ReturnResponse
                            {
                                resp = true,
                                msg = ""
                            };
                            objCustHeadList.Add(objCustHead);
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

                objError.WriteLog(0, "JobRole_Data", "add_new_JobRole", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "JobRole_Data", "add_new_JobRole", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "JobRole_Data", "add_new_JobRole", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "JobRole_Data", "add_new_JobRole", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_JobRole(InactiveMDJRModel item)//ok
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



                        cmd.CommandText = "sp_del_JobRole";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MDJR_JobRoleID", item.MDJR_JobRoleID);
                        cmd.Parameters["@MDJR_JobRoleID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "JobRole_Data", "inactivate_JobRole", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "JobRole_Data", "inactivate_JobRole", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "JobRole_Data", "inactivate_JobRole", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "JobRole_Data", "inactivate_JobRole", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

