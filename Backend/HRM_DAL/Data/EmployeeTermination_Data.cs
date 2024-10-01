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
    public class EmployeeTermination_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnEmployeeTerminationModelHead> get_EmployeeTermination_single(EmployeeTermination model)//ok
        {
            List<ReturnEmployeeTerminationModelHead> objEmployeeTerminationHeadList = new List<ReturnEmployeeTerminationModelHead>();
            ReturnEmployeeTerminationModelHead objEmployeeTerminationHead = new ReturnEmployeeTerminationModelHead();

            if (objEmployeeTerminationHead.EmployeeTermination == null)
            {
                objEmployeeTerminationHead.EmployeeTermination = new List<ReturnEmployeeTerminationModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objEmployeeTerminationHead.resp = false;
                objEmployeeTerminationHead.IsAuthenticated = false;
                objEmployeeTerminationHeadList.Add(objEmployeeTerminationHead);
                return objEmployeeTerminationHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_EmployeeTermination_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EET_ID", model.EET_ID);
                        cmd.Parameters["@EET_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnEmployeeTerminationModel objEmployeeTermination = new ReturnEmployeeTerminationModel();

                                objEmployeeTerminationHead.resp = true;
                                objEmployeeTerminationHead.msg = "Get EmployeeTermination";

                                objEmployeeTermination.EET_ID = Convert.ToInt32(rdr["EET_ID"].ToString());
                                objEmployeeTermination.EET_EmployeeID = rdr["EET_EmployeeID"].ToString();
                                objEmployeeTermination.EET_Remarks = rdr["EET_Remarks"].ToString();
                                objEmployeeTermination.EET_IsForceTerminated = Convert.ToBoolean(rdr["EET_IsForceTerminated"].ToString());
                                objEmployeeTermination.EET_IsForceTerminated = Convert.ToBoolean(rdr["EET_IsForceTerminated"].ToString());
                                objEmployeeTermination.EET_Status = Convert.ToBoolean(rdr["EET_Status"].ToString());

                                objEmployeeTerminationHead.EmployeeTermination.Add(objEmployeeTermination);

                                objEmployeeTerminationHeadList.Add(objEmployeeTerminationHead);
                            }

                        }
                        else
                        {
                            ReturnEmployeeTerminationModel objEmployeeTermination = new ReturnEmployeeTerminationModel();
                            objEmployeeTerminationHead.resp = true;
                            objEmployeeTerminationHead.msg = "";
                            objEmployeeTerminationHeadList.Add(objEmployeeTerminationHead);


                        }


                    }
                    return objEmployeeTerminationHeadList;

                }
            }
            catch (Exception ex)
            {
                objEmployeeTerminationHead.resp = false;
                objEmployeeTerminationHead.msg = ex.Message.ToString();

                objEmployeeTerminationHeadList.Add(objEmployeeTerminationHead);

                objError.WriteLog(0, "EmployeeTermination_Data", "get_EmployeeTermination_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeTermination_Data", "get_EmployeeTermination_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeTermination_Data", "get_EmployeeTermination_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeTermination_Data", "get_EmployeeTermination_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objEmployeeTerminationHeadList;

        }

        public static List<ReturnEmployeeTerminationModelHead> get_EmployeeTermination_all(EmployeeTerminationSearchModel model)//ok
        {
            List<ReturnEmployeeTerminationModelHead> objEmployeeTerminationHeadList = new List<ReturnEmployeeTerminationModelHead>();
            ReturnEmployeeTerminationModelHead objEmployeeTerminationHead = new ReturnEmployeeTerminationModelHead();

            if (objEmployeeTerminationHead.EmployeeTermination == null)
            {
                objEmployeeTerminationHead.EmployeeTermination = new List<ReturnEmployeeTerminationModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objEmployeeTerminationHead.resp = false;
                objEmployeeTerminationHead.IsAuthenticated = false;
                objEmployeeTerminationHeadList.Add(objEmployeeTerminationHead);
                return objEmployeeTerminationHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_EmployeeTermination_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EET_EmployeeID", model.EET_EmployeeID);
                        cmd.Parameters["@EET_EmployeeID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnEmployeeTerminationModel objEmployeeTermination = new ReturnEmployeeTerminationModel();

                                objEmployeeTerminationHead.resp = true;
                                objEmployeeTerminationHead.msg = "Get EmployeeTermination";

                                objEmployeeTermination.EET_ID = Convert.ToInt32(rdr["EET_ID"].ToString());
                                objEmployeeTermination.EET_EmployeeID = rdr["EET_EmployeeID"].ToString();
                                objEmployeeTermination.EET_Remarks = rdr["EET_Remarks"].ToString();
                                objEmployeeTermination.EET_IsForceTerminated = Convert.ToBoolean(rdr["EET_IsForceTerminated"].ToString());
                                objEmployeeTermination.EET_IsForceTerminated = Convert.ToBoolean(rdr["EET_IsForceTerminated"].ToString());
                                objEmployeeTermination.EET_Status = Convert.ToBoolean(rdr["EET_Status"].ToString());

                                objEmployeeTerminationHead.EmployeeTermination.Add(objEmployeeTermination);

                                objEmployeeTerminationHeadList.Add(objEmployeeTerminationHead);
                            }

                        }
                        else
                        {
                            ReturnEmployeeTerminationModel objEmployeeTermination = new ReturnEmployeeTerminationModel();
                            objEmployeeTerminationHead.resp = true;
                            objEmployeeTerminationHead.msg = "";
                            objEmployeeTerminationHeadList.Add(objEmployeeTerminationHead);


                        }


                    }
                    return objEmployeeTerminationHeadList;

                }
            }
            catch (Exception ex)
            {
                objEmployeeTerminationHead.resp = false;
                  objEmployeeTerminationHead.msg = ex.Message.ToString();

                objEmployeeTerminationHeadList.Add(objEmployeeTerminationHead);

                objError.WriteLog(0, "EmployeeTermination_Data", "get_EmployeeTermination_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeTermination_Data", "get_EmployeeTermination_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeTermination_Data", "get_EmployeeTermination_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeTermination_Data", "get_EmployeeTermination_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objEmployeeTerminationHeadList;

        }

        public static List<ReturnResponse> add_new_EmployeeTermination(EmployeeTerminationModel item)//ok
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


                        cmd.CommandText = "sp_insert_EmployeeTermination";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@EET_ID", item.EET_ID);
                        //cmd.Parameters["@EET_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EET_EmployeeID", item.EET_EmployeeID);
                        cmd.Parameters["@EET_EmployeeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EET_IsForceTerminated", item.EET_IsForceTerminated);
                        cmd.Parameters["@EET_IsForceTerminated"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EET_IsBlackListed", item.EET_IsBlackListed);
                        cmd.Parameters["@EET_IsBlackListed"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EET_Remarks", item.EET_Remarks);
                        cmd.Parameters["@EET_Remarks"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "EmployeeTermination_Data", "add_new_EmployeeTermination", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeTermination_Data", "add_new_EmployeeTermination", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeTermination_Data", "add_new_EmployeeTermination", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeTermination_Data", "add_new_EmployeeTermination", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> modify_EmployeeTermination(EmployeeTerminationModel item)//ok
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


                        cmd.CommandText = "sp_modify_EmployeeTermination";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;


                        cmd.Parameters.AddWithValue("@EET_ID", item.EET_ID);
                        cmd.Parameters["@EET_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EET_EmployeeID", item.EET_EmployeeID);
                        cmd.Parameters["@EET_EmployeeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EET_IsForceTerminated", item.EET_IsForceTerminated);
                        cmd.Parameters["@EET_IsForceTerminated"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EET_IsBlackListed", item.EET_IsBlackListed);
                        cmd.Parameters["@EET_IsBlackListed"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EET_Status", item.EET_Status);
                        cmd.Parameters["@EET_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EET_Remarks", item.EET_Remarks);
                        cmd.Parameters["@EET_Remarks"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "EmployeeTermination_Data", "add_new_EmployeeTermination", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeTermination_Data", "add_new_EmployeeTermination", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeTermination_Data", "add_new_EmployeeTermination", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeTermination_Data", "add_new_EmployeeTermination", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_EmployeeTermination(InactiveEETModel item)//ok
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



                        cmd.CommandText = "sp_del_EmployeeTermination";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EET_ID", item.EET_ID);
                        cmd.Parameters["@EET_ID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "EmployeeTermination_Data", "inactivate_EmployeeTermination", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeTermination_Data", "inactivate_EmployeeTermination", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeTermination_Data", "inactivate_EmployeeTermination", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeTermination_Data", "inactivate_EmployeeTermination", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

