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
    public class JobType_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnJobTypeModelHead> get_JobTypes_single(JobType model)//ok
        {
            List<ReturnJobTypeModelHead> objJobTypeHeadList = new List<ReturnJobTypeModelHead>();
            ReturnJobTypeModelHead objJobTypeHead = new ReturnJobTypeModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objJobTypeHead.resp = false;
                objJobTypeHead.IsAuthenticated = false;
                objJobTypeHeadList.Add(objJobTypeHead);
                return objJobTypeHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_JobTypes_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MDJT_JobTypeID", model.MDJT_JobTypeID);
                        cmd.Parameters["@MDJT_JobTypeID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnJobTypeModel objJobType = new ReturnJobTypeModel();

                                objJobTypeHead.resp = true;
                                objJobTypeHead.msg = "Get JobType";

                                objJobType.MDJT_JobTypeID = rdr["MDJT_JobTypeID"].ToString();
                                objJobType.MDJT_Description = rdr["MDJT_Description"].ToString();
                                objJobType.MDJT_JobType = rdr["MDJT_JobType"].ToString();
                                objJobType.MDJT_Status = Convert.ToBoolean(rdr["MDJT_Status"].ToString());

                                if (objJobTypeHead.JobType == null)
                                {
                                    objJobTypeHead.JobType = new List<ReturnJobTypeModel>();
                                }

                                objJobTypeHead.JobType.Add(objJobType);

                                objJobTypeHeadList.Add(objJobTypeHead);
                            }

                        }
                        else
                        {
                            ReturnJobTypeModel objJobType = new ReturnJobTypeModel();
                            objJobTypeHead.resp = true;
                            objJobTypeHead.msg = "";
                            objJobTypeHeadList.Add(objJobTypeHead);


                        }


                    }
                    return objJobTypeHeadList;

                }
            }
            catch (Exception ex)
            {
                objJobTypeHead = new ReturnJobTypeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objJobTypeHeadList.Add(objJobTypeHead);

                objError.WriteLog(0, "JobType_Data", "get_JobTypes_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "JobType_Data", "get_JobTypes_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "JobType_Data", "get_JobTypes_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "JobType_Data", "get_JobTypes_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objJobTypeHeadList;

        }

        public static List<ReturnJobTypeModelHead> get_JobType_all(JobTypeSearchModel model)//ok
        {
            List<ReturnJobTypeModelHead> objJobTypeHeadList = new List<ReturnJobTypeModelHead>();
            ReturnJobTypeModelHead objJobTypeHead = new ReturnJobTypeModelHead();

            if (objJobTypeHead.JobType == null)
            {
                objJobTypeHead.JobType = new List<ReturnJobTypeModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objJobTypeHead.resp = false;
                objJobTypeHead.IsAuthenticated = false;
                objJobTypeHeadList.Add(objJobTypeHead);
                return objJobTypeHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_JobType_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@MDJT_JobTypeID", model.MDJT_JobTypeID);
                        //cmd.Parameters["@MDJT_JobTypeID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnJobTypeModel objJobType = new ReturnJobTypeModel();

                                objJobTypeHead.resp = true;
                                objJobTypeHead.msg = "Get JobType";

                                objJobType.MDJT_JobTypeID = rdr["MDJT_JobTypeID"].ToString();
                                objJobType.MDJT_JobType = rdr["MDJT_JobType"].ToString();
                                objJobType.MDJT_Status = Convert.ToBoolean(rdr["MDJT_Status"].ToString());


                                objJobTypeHead.JobType.Add(objJobType);

                                objJobTypeHeadList.Add(objJobTypeHead);
                            }

                        }
                        else
                        {
                            ReturnJobTypeModel objJobType = new ReturnJobTypeModel();
                            objJobTypeHead.resp = true;
                            objJobTypeHead.msg = "";
                            objJobTypeHeadList.Add(objJobTypeHead);


                        }


                    }
                    return objJobTypeHeadList;

                }
            }
            catch (Exception ex)
            {
                objJobTypeHead.resp = false;
                objJobTypeHead.msg = ex.Message.ToString();

                objJobTypeHeadList.Add(objJobTypeHead);

                objError.WriteLog(0, "JobType_Data", "get_JobType_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "JobType_Data", "get_JobType_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "JobType_Data", "get_JobType_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "JobType_Data", "get_JobType_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objJobTypeHeadList;

        }

        public static List<ReturnResponse> add_new_JobType(JobTypeModel item)//ok
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


                        cmd.CommandText = "sp_insert_JobType";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDJT_JobTypeID", item.MDJT_JobTypeID);
                        cmd.Parameters["@MDJT_JobTypeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDJT_JobType", item.MDJT_JobType);
                        cmd.Parameters["@MDJT_JobType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDJT_Status", item.MDJT_Status);
                        cmd.Parameters["@MDJT_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDJT_Description", item.MDJT_Description);
                        cmd.Parameters["@MDJT_Description"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "JobType_Data", "add_new_JobType", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "JobType_Data", "add_new_JobType", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "JobType_Data", "add_new_JobType", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "JobType_Data", "add_new_JobType", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> modify_JobType(JobTypeModel item)//ok
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


                        cmd.CommandText = "sp_modify_JobType";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDJT_JobTypeID", item.MDJT_JobTypeID);
                        cmd.Parameters["@MDJT_JobTypeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDJT_JobType", item.MDJT_JobType);
                        cmd.Parameters["@MDJT_JobType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDJT_Status", item.MDJT_Status);
                        cmd.Parameters["@MDJT_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDJT_Description", item.MDJT_Description);
                        cmd.Parameters["@MDJT_Description"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "JobType_Data", "add_new_JobType", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "JobType_Data", "add_new_JobType", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "JobType_Data", "add_new_JobType", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "JobType_Data", "add_new_JobType", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_JobType(InactiveMDJTModel item)//ok
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



                        cmd.CommandText = "sp_del_JobType";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MDJT_JobTypeID", item.MDJT_JobTypeID);
                        cmd.Parameters["@MDJT_JobTypeID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "JobType_Data", "inactivate_JobType", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "JobType_Data", "inactivate_JobType", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "JobType_Data", "inactivate_JobType", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "JobType_Data", "inactivate_JobType", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

