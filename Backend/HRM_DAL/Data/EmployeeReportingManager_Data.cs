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
    public class EmployeeReportingManager_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnEmployeeReportingManagerModelHead> get_EmployeeReportingManagers_single(EmployeeReportingManager model)//ok
        {
            List<ReturnEmployeeReportingManagerModelHead> objEmployeeReportingManagerHeadList = new List<ReturnEmployeeReportingManagerModelHead>();
            ReturnEmployeeReportingManagerModelHead objEmployeeReportingManagerHead = new ReturnEmployeeReportingManagerModelHead();

            if (objEmployeeReportingManagerHead.EmployeeReportingManager == null)
            {
                objEmployeeReportingManagerHead.EmployeeReportingManager = new List<ReturnEmployeeReportingManagerModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objEmployeeReportingManagerHead.resp = false;
                objEmployeeReportingManagerHead.IsAuthenticated = false;
                objEmployeeReportingManagerHeadList.Add(objEmployeeReportingManagerHead);
                return objEmployeeReportingManagerHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_EmployeeReportingManager_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EERM_ID", model.EERM_ID);
                        cmd.Parameters["@EERM_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnEmployeeReportingManagerModel objEmployeeReportingManager = new ReturnEmployeeReportingManagerModel();

                                objEmployeeReportingManagerHead.resp = true;
                                objEmployeeReportingManagerHead.msg = "Get EmployeeReportingManager";

                                objEmployeeReportingManager.EERM_ID = Convert.ToInt32(rdr["EERM_ID"].ToString());
                                objEmployeeReportingManager.EERM_EmployeeID = rdr["EERM_EmployeeID"].ToString();
                                objEmployeeReportingManager.EERM_ReportingManagerID = rdr["EERM_ReportingManagerID"].ToString();

                                if (!string.IsNullOrEmpty(rdr["EERM_ActiveFrom"].ToString()))
                                    objEmployeeReportingManager.EERM_ActiveFrom = Convert.ToDateTime(rdr["EERM_ActiveFrom"].ToString());

                                if (!string.IsNullOrEmpty(rdr["EERM_ActiveTo"].ToString()))
                                    objEmployeeReportingManager.EERM_ActiveTo = Convert.ToDateTime(rdr["EERM_ActiveTo"].ToString());

                                objEmployeeReportingManager.EERM_Status = Convert.ToBoolean(rdr["EERM_Status"].ToString());

                                objEmployeeReportingManagerHead.EmployeeReportingManager.Add(objEmployeeReportingManager);

                                objEmployeeReportingManagerHeadList.Add(objEmployeeReportingManagerHead);
                            }

                        }
                        else
                        {
                            objEmployeeReportingManagerHead.resp = true;
                            objEmployeeReportingManagerHead.msg = "";
                            objEmployeeReportingManagerHeadList.Add(objEmployeeReportingManagerHead);


                        }


                    }
                    return objEmployeeReportingManagerHeadList;

                }
            }
            catch (Exception ex)
            {
                objEmployeeReportingManagerHead.resp = false;
                objEmployeeReportingManagerHead.msg = ex.Message.ToString();

                objEmployeeReportingManagerHeadList.Add(objEmployeeReportingManagerHead);

                objError.WriteLog(0, "EmployeeReportingManager_Data", "get_EmployeeReportingManagers_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeReportingManager_Data", "get_EmployeeReportingManagers_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeReportingManager_Data", "get_EmployeeReportingManagers_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeReportingManager_Data", "get_EmployeeReportingManagers_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objEmployeeReportingManagerHeadList;

        }

        public static List<ReturnEmployeeReportingManagerModelHead> get_EmployeeReportingManager_all(EmployeeReportingManagerSearchModel model)//ok
        {
            List<ReturnEmployeeReportingManagerModelHead> objEmployeeReportingManagerHeadList = new List<ReturnEmployeeReportingManagerModelHead>();
            ReturnEmployeeReportingManagerModelHead objEmployeeReportingManagerHead = new ReturnEmployeeReportingManagerModelHead();

            if (objEmployeeReportingManagerHead.EmployeeReportingManager == null)
            {
                objEmployeeReportingManagerHead.EmployeeReportingManager = new List<ReturnEmployeeReportingManagerModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objEmployeeReportingManagerHead.resp = false;
                objEmployeeReportingManagerHead.IsAuthenticated = false;
                objEmployeeReportingManagerHeadList.Add(objEmployeeReportingManagerHead);
                return objEmployeeReportingManagerHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_EmployeeReportingManager_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EERM_EmployeeID", model.EERM_EmployeeID);
                        cmd.Parameters["@EERM_EmployeeID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnEmployeeReportingManagerModel objEmployeeReportingManager = new ReturnEmployeeReportingManagerModel();

                                objEmployeeReportingManagerHead.resp = true;
                                objEmployeeReportingManagerHead.msg = "Get EmployeeReportingManager";

                                objEmployeeReportingManager.EERM_ID = Convert.ToInt32(rdr["EERM_ID"].ToString());
                                objEmployeeReportingManager.EERM_EmployeeID = rdr["EERM_EmployeeID"].ToString();
                                objEmployeeReportingManager.EERM_ReportingManagerID = rdr["EERM_ReportingManagerID"].ToString();

                                if (!string.IsNullOrEmpty(rdr["EERM_ActiveFrom"].ToString()))
                                    objEmployeeReportingManager.EERM_ActiveFrom = Convert.ToDateTime(rdr["EERM_ActiveFrom"].ToString());

                                if (!string.IsNullOrEmpty(rdr["EERM_ActiveTo"].ToString()))
                                    objEmployeeReportingManager.EERM_ActiveTo = Convert.ToDateTime(rdr["EERM_ActiveTo"].ToString());

                                objEmployeeReportingManager.EERM_Status = Convert.ToBoolean(rdr["EERM_Status"].ToString());

                                objEmployeeReportingManagerHead.EmployeeReportingManager.Add(objEmployeeReportingManager);

                                objEmployeeReportingManagerHeadList.Add(objEmployeeReportingManagerHead);
                            }

                        }
                        else
                        {
                            objEmployeeReportingManagerHead.resp = true;
                            objEmployeeReportingManagerHead.msg = "";
                            objEmployeeReportingManagerHeadList.Add(objEmployeeReportingManagerHead);


                        }


                    }
                    return objEmployeeReportingManagerHeadList;

                }
            }
            catch (Exception ex)
            {
                objEmployeeReportingManagerHead.resp = false;
                objEmployeeReportingManagerHead.msg = ex.Message.ToString();

                objEmployeeReportingManagerHeadList.Add(objEmployeeReportingManagerHead);

                objError.WriteLog(0, "EmployeeReportingManager_Data", "get_EmployeeReportingManager_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeReportingManager_Data", "get_EmployeeReportingManager_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeReportingManager_Data", "get_EmployeeReportingManager_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeReportingManager_Data", "get_EmployeeReportingManager_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objEmployeeReportingManagerHeadList;

        }

        public static List<ReturnResponse> add_new_EmployeeReportingManager(EmployeeReportingManagerModel item)//ok
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


                        cmd.CommandText = "sp_insert_EmployeeReportingManager";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@EERM_ID", item.EERM_ID);
                        //cmd.Parameters["@EERM_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EERM_EmployeeID", item.EERM_EmployeeID);
                        cmd.Parameters["@EERM_EmployeeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EERM_ReportingManagerID", item.EERM_ReportingManagerID);
                        cmd.Parameters["@EERM_ReportingManagerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EERM_ActiveFrom", item.EERM_ActiveFrom);
                        cmd.Parameters["@EERM_ActiveFrom"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EERM_ActiveTo", item.EERM_ActiveTo);
                        cmd.Parameters["@EERM_ActiveTo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EERM_Status", item.EERM_Status);
                        cmd.Parameters["@EERM_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EERM_Remarks", item.EERM_Remarks);
                        cmd.Parameters["@EERM_Remarks"].Direction = ParameterDirection.Input;

                        string mailtypes = "";

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

                objError.WriteLog(0, "EmployeeReportingManager_Data", "add_new_EmployeeReportingManager", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeReportingManager_Data", "add_new_EmployeeReportingManager", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeReportingManager_Data", "add_new_EmployeeReportingManager", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeReportingManager_Data", "add_new_EmployeeReportingManager", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> modify_EmployeeReportingManager(EmployeeReportingManagerModel item)//ok
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


                        cmd.CommandText = "sp_modify_EmployeeReportingManager";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EERM_ID", item.EERM_ID);
                        cmd.Parameters["@EERM_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EERM_EmployeeID", item.EERM_EmployeeID);
                        cmd.Parameters["@EERM_EmployeeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EERM_ReportingManagerID", item.EERM_ReportingManagerID);
                        cmd.Parameters["@EERM_ReportingManagerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EERM_ActiveFrom", item.EERM_ActiveFrom);
                        cmd.Parameters["@EERM_ActiveFrom"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EERM_ActiveTo", item.EERM_ActiveTo);
                        cmd.Parameters["@EERM_ActiveTo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EERM_Status", item.EERM_Status);
                        cmd.Parameters["@EERM_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EERM_Remarks", item.EERM_Remarks);
                        cmd.Parameters["@EERM_Remarks"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "EmployeeReportingManager_Data", "add_new_EmployeeReportingManager", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeReportingManager_Data", "add_new_EmployeeReportingManager", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeReportingManager_Data", "add_new_EmployeeReportingManager", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeReportingManager_Data", "add_new_EmployeeReportingManager", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_EmployeeReportingManager(InactiveEERMModel item)//ok
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



                        cmd.CommandText = "sp_del_EmployeeReportingManager";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EERM_ID", item.EERM_ID);
                        cmd.Parameters["@EERM_ID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "EmployeeReportingManager_Data", "inactivate_EmployeeReportingManager", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeReportingManager_Data", "inactivate_EmployeeReportingManager", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeReportingManager_Data", "inactivate_EmployeeReportingManager", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeReportingManager_Data", "inactivate_EmployeeReportingManager", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

