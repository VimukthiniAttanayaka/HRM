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
    public class SalaryType_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnSalaryTypeModelHead> get_SalaryTypes_single(SalaryType model)//ok
        {
            List<ReturnSalaryTypeModelHead> objSalaryTypeHeadList = new List<ReturnSalaryTypeModelHead>();
            ReturnSalaryTypeModelHead objSalaryTypeHead = new ReturnSalaryTypeModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objSalaryTypeHead.resp = false;
                objSalaryTypeHead.IsAuthenticated = false;
                objSalaryTypeHeadList.Add(objSalaryTypeHead);
                return objSalaryTypeHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_SalaryType_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MDST_SalaryTypeID", model.MDST_SalaryTypeID);
                        cmd.Parameters["@MDST_SalaryTypeID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnSalaryTypeModel objSalaryType = new ReturnSalaryTypeModel();

                                objSalaryTypeHead.resp = true;
                                objSalaryTypeHead.msg = "Get SalaryType";

                                objSalaryType.MDST_SalaryTypeID = rdr["MDST_SalaryTypeID"].ToString();
                                objSalaryType.MDST_Description = rdr["MDST_Description"].ToString();
                                objSalaryType.MDST_SalaryType = rdr["MDST_SalaryType"].ToString();
                                objSalaryType.MDST_Status = Convert.ToBoolean(rdr["MDST_Status"].ToString());

                                if (objSalaryTypeHead.SalaryType == null)
                                {
                                    objSalaryTypeHead.SalaryType = new List<ReturnSalaryTypeModel>();
                                }

                                objSalaryTypeHead.SalaryType.Add(objSalaryType);

                                objSalaryTypeHeadList.Add(objSalaryTypeHead);
                            }

                        }
                        else
                        {
                            ReturnSalaryTypeModel objSalaryType = new ReturnSalaryTypeModel();
                            objSalaryTypeHead.resp = true;
                            objSalaryTypeHead.msg = "";
                            objSalaryTypeHeadList.Add(objSalaryTypeHead);


                        }


                    }
                    return objSalaryTypeHeadList;

                }
            }
            catch (Exception ex)
            {
                objSalaryTypeHead = new ReturnSalaryTypeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objSalaryTypeHeadList.Add(objSalaryTypeHead);

                objError.WriteLog(0, "SalaryType_Data", "get_SalaryTypes_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "SalaryType_Data", "get_SalaryTypes_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "SalaryType_Data", "get_SalaryTypes_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "SalaryType_Data", "get_SalaryTypes_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objSalaryTypeHeadList;

        }

        public static List<ReturnSalaryTypeModelHead> get_SalaryType_all(SalaryTypeSearchModel model)//ok
        {
            List<ReturnSalaryTypeModelHead> objSalaryTypeHeadList = new List<ReturnSalaryTypeModelHead>();
            ReturnSalaryTypeModelHead objSalaryTypeHead = new ReturnSalaryTypeModelHead();

            if (objSalaryTypeHead.SalaryType == null)
            {
                objSalaryTypeHead.SalaryType = new List<ReturnSalaryTypeModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objSalaryTypeHead.resp = false;
                objSalaryTypeHead.IsAuthenticated = false;
                objSalaryTypeHeadList.Add(objSalaryTypeHead);
                return objSalaryTypeHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_SalaryType_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@MDST_SalaryTypeID", model.MDST_SalaryTypeID);
                        //cmd.Parameters["@MDST_SalaryTypeID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnSalaryTypeModel objSalaryType = new ReturnSalaryTypeModel();

                                objSalaryTypeHead.resp = true;
                                objSalaryTypeHead.msg = "Get SalaryType";

                                objSalaryType.MDST_SalaryTypeID = rdr["MDST_SalaryTypeID"].ToString();
                                objSalaryType.MDST_SalaryType = rdr["MDST_SalaryType"].ToString();
                                objSalaryType.MDST_Status = Convert.ToBoolean(rdr["MDST_Status"].ToString());


                                objSalaryTypeHead.SalaryType.Add(objSalaryType);

                                objSalaryTypeHeadList.Add(objSalaryTypeHead);
                            }

                        }
                        else
                        {
                            ReturnSalaryTypeModel objSalaryType = new ReturnSalaryTypeModel();
                            objSalaryTypeHead.resp = true;
                            objSalaryTypeHead.msg = "";
                            objSalaryTypeHeadList.Add(objSalaryTypeHead);


                        }


                    }
                    return objSalaryTypeHeadList;

                }
            }
            catch (Exception ex)
            {
                objSalaryTypeHead.resp = false;
                objSalaryTypeHead.msg = ex.Message.ToString();

                objSalaryTypeHeadList.Add(objSalaryTypeHead);

                objError.WriteLog(0, "SalaryType_Data", "get_SalaryType_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "SalaryType_Data", "get_SalaryType_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "SalaryType_Data", "get_SalaryType_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "SalaryType_Data", "get_SalaryType_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objSalaryTypeHeadList;

        }

        public static List<ReturnResponse> add_new_SalaryType(SalaryTypeModel item)//ok
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


                        cmd.CommandText = "sp_insert_SalaryType";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDST_SalaryTypeID", item.MDST_SalaryTypeID);
                        cmd.Parameters["@MDST_SalaryTypeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDST_SalaryType", item.MDST_SalaryType);
                        cmd.Parameters["@MDST_SalaryType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDST_Status", item.MDST_Status);
                        cmd.Parameters["@MDST_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDST_Description", item.MDST_Description);
                        cmd.Parameters["@MDST_Description"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "SalaryType_Data", "add_new_SalaryType", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "SalaryType_Data", "add_new_SalaryType", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "SalaryType_Data", "add_new_SalaryType", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "SalaryType_Data", "add_new_SalaryType", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> modify_SalaryType(SalaryTypeModel item)//ok
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


                        cmd.CommandText = "sp_modify_SalaryType";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDST_SalaryTypeID", item.MDST_SalaryTypeID);
                        cmd.Parameters["@MDST_SalaryTypeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDST_SalaryType", item.MDST_SalaryType);
                        cmd.Parameters["@MDST_SalaryType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDST_Status", item.MDST_Status);
                        cmd.Parameters["@MDST_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDST_Description", item.MDST_Description);
                        cmd.Parameters["@MDST_Description"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "SalaryType_Data", "add_new_SalaryType", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "SalaryType_Data", "add_new_SalaryType", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "SalaryType_Data", "add_new_SalaryType", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "SalaryType_Data", "add_new_SalaryType", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_SalaryType(InactiveMDSTModel item)//ok
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



                        cmd.CommandText = "sp_del_SalaryType";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MDST_SalaryTypeID", item.MDST_SalaryTypeID);
                        cmd.Parameters["@MDST_SalaryTypeID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "SalaryType_Data", "inactivate_SalaryType", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "SalaryType_Data", "inactivate_SalaryType", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "SalaryType_Data", "inactivate_SalaryType", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "SalaryType_Data", "inactivate_SalaryType", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

