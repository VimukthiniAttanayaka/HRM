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
    public class LeaveType_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnLeaveTypeModelHead> get_LeaveTypes_single(LeaveType model)//ok
        {
            List<ReturnLeaveTypeModelHead> objLeaveTypeHeadList = new List<ReturnLeaveTypeModelHead>();
            ReturnLeaveTypeModelHead objLeaveTypeHead = new ReturnLeaveTypeModelHead();

            if (objLeaveTypeHead.LeaveType == null)
            {
                objLeaveTypeHead.LeaveType = new List<ReturnLeaveTypeModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objLeaveTypeHead.resp = false;
                objLeaveTypeHead.IsAuthenticated = false;
                objLeaveTypeHeadList.Add(objLeaveTypeHead);
                return objLeaveTypeHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_LeaveType_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MDLT_LeaveTypeID", model.MDLT_LeaveTypeID);
                        cmd.Parameters["@MDLT_LeaveTypeID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnLeaveTypeModel objLeaveType = new ReturnLeaveTypeModel();

                                objLeaveTypeHead.resp = true;
                                objLeaveTypeHead.msg = "Get LeaveType";

                                objLeaveType.MDLT_LeaveTypeID = rdr["MDLT_LeaveTypeID"].ToString();
                                objLeaveType.MDLT_Description = rdr["MDLT_Description"].ToString();
                                objLeaveType.MDLT_LeaveType = rdr["MDLT_LeaveType"].ToString();
                                objLeaveType.MDLT_Status = Convert.ToBoolean(rdr["MDLT_Status"].ToString());
                                objLeaveType.MDLT_LeaveAlotment = Convert.ToInt16(rdr["MDLT_LeaveAlotment"].ToString());
                                objLeaveType.MDLT_Duration = Convert.ToInt16(rdr["MDLT_Duration"].ToString());

                                objLeaveTypeHead.LeaveType.Add(objLeaveType);

                                objLeaveTypeHeadList.Add(objLeaveTypeHead);
                            }

                        }
                        else
                        {
                            ReturnLeaveTypeModel objLeaveType = new ReturnLeaveTypeModel();
                            objLeaveTypeHead.resp = true;
                            objLeaveTypeHead.msg = "";
                            objLeaveTypeHeadList.Add(objLeaveTypeHead);


                        }


                    }
                    return objLeaveTypeHeadList;

                }
            }
            catch (Exception ex)
            {
                objLeaveTypeHead = new ReturnLeaveTypeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objLeaveTypeHeadList.Add(objLeaveTypeHead);

                objError.WriteLog(0, "LeaveType_Data", "get_LeaveTypes_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveType_Data", "get_LeaveTypes_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveType_Data", "get_LeaveTypes_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveType_Data", "get_LeaveTypes_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objLeaveTypeHeadList;

        }

        public static List<ReturnLeaveTypeModelHead> get_LeaveType_all(LeaveTypeSearchModel model)//ok
        {
            List<ReturnLeaveTypeModelHead> objLeaveTypeHeadList = new List<ReturnLeaveTypeModelHead>();
            ReturnLeaveTypeModelHead objLeaveTypeHead = new ReturnLeaveTypeModelHead();

            if (objLeaveTypeHead.LeaveType == null)
            {
                objLeaveTypeHead.LeaveType = new List<ReturnLeaveTypeModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objLeaveTypeHead.resp = false;
                objLeaveTypeHead.IsAuthenticated = false;
                objLeaveTypeHeadList.Add(objLeaveTypeHead);
                return objLeaveTypeHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_LeaveType_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@MDLT_LeaveTypeID", model.MDLT_LeaveTypeID);
                        //cmd.Parameters["@MDLT_LeaveTypeID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnLeaveTypeModel objLeaveType = new ReturnLeaveTypeModel();

                                objLeaveTypeHead.resp = true;
                                objLeaveTypeHead.msg = "Get LeaveType";

                                objLeaveType.MDLT_LeaveTypeID = rdr["MDLT_LeaveTypeID"].ToString();
                                objLeaveType.MDLT_LeaveType = rdr["MDLT_LeaveType"].ToString();
                                objLeaveType.MDLT_Status = Convert.ToBoolean(rdr["MDLT_Status"].ToString());
                                objLeaveType.MDLT_LeaveAlotment = Convert.ToInt16(rdr["MDLT_LeaveAlotment"].ToString());
                                objLeaveType.MDLT_Duration = Convert.ToInt16(rdr["MDLT_Duration"].ToString());


                                objLeaveTypeHead.LeaveType.Add(objLeaveType);

                                objLeaveTypeHeadList.Add(objLeaveTypeHead);
                            }

                        }
                        else
                        {
                            ReturnLeaveTypeModel objLeaveType = new ReturnLeaveTypeModel();
                            objLeaveTypeHead.resp = true;
                            objLeaveTypeHead.msg = "";
                            objLeaveTypeHeadList.Add(objLeaveTypeHead);


                        }


                    }
                    return objLeaveTypeHeadList;

                }
            }
            catch (Exception ex)
            {
                objLeaveTypeHead.resp = false;
                objLeaveTypeHead.msg = ex.Message.ToString();

                objLeaveTypeHeadList.Add(objLeaveTypeHead);

                objError.WriteLog(0, "LeaveType_Data", "get_LeaveType_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveType_Data", "get_LeaveType_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveType_Data", "get_LeaveType_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveType_Data", "get_LeaveType_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objLeaveTypeHeadList;

        }

        public static List<ReturnResponse> add_new_LeaveType(LeaveTypeModel item)//ok
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


                        cmd.CommandText = "sp_insert_LeaveType";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDLT_LeaveTypeID", item.MDLT_LeaveTypeID);
                        cmd.Parameters["@MDLT_LeaveTypeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDLT_LeaveType", item.MDLT_LeaveType);
                        cmd.Parameters["@MDLT_LeaveType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDLT_Status", item.MDLT_Status);
                        cmd.Parameters["@MDLT_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDLT_Description", item.MDLT_Description);
                        cmd.Parameters["@MDLT_Description"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDLT_LeaveAlotment", item.MDLT_LeaveAlotment);
                        cmd.Parameters["@MDLT_LeaveAlotment"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDLT_Duration", item.MDLT_Duration);
                        cmd.Parameters["@MDLT_Duration"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "LeaveType_Data", "add_new_LeaveType", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveType_Data", "add_new_LeaveType", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveType_Data", "add_new_LeaveType", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveType_Data", "add_new_LeaveType", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> modify_LeaveType(LeaveTypeModel item)//ok
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


                        cmd.CommandText = "sp_modify_LeaveType";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDLT_LeaveTypeID", item.MDLT_LeaveTypeID);
                        cmd.Parameters["@MDLT_LeaveTypeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDLT_LeaveType", item.MDLT_LeaveType);
                        cmd.Parameters["@MDLT_LeaveType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDLT_Status", item.MDLT_Status);
                        cmd.Parameters["@MDLT_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDLT_Description", item.MDLT_Description);
                        cmd.Parameters["@MDLT_Description"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDLT_LeaveAlotment", item.MDLT_LeaveAlotment);
                        cmd.Parameters["@MDLT_LeaveAlotment"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDLT_Duration", item.MDLT_Duration);
                        cmd.Parameters["@MDLT_Duration"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "LeaveType_Data", "add_new_LeaveType", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveType_Data", "add_new_LeaveType", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveType_Data", "add_new_LeaveType", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveType_Data", "add_new_LeaveType", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_LeaveType(InactiveMDLTModel item)//ok
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



                        cmd.CommandText = "sp_del_LeaveType";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MDLT_LeaveTypeID", item.MDLT_LeaveTypeID);
                        cmd.Parameters["@MDLT_LeaveTypeID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "LeaveType_Data", "inactivate_LeaveType", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "LeaveType_Data", "inactivate_LeaveType", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "LeaveType_Data", "inactivate_LeaveType", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "LeaveType_Data", "inactivate_LeaveType", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

