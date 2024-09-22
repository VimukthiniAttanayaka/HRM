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
    public class Country_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnCountryModelHead> get_Countrys_single(Country model)//ok
        {
            List<ReturnCountryModelHead> objCountryHeadList = new List<ReturnCountryModelHead>();
            ReturnCountryModelHead objCountryHead = new ReturnCountryModelHead();

            if (objCountryHead.Country == null)
            {
                objCountryHead.Country = new List<ReturnCountryModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objCountryHead.resp = false;
                objCountryHead.IsAuthenticated = false;
                objCountryHeadList.Add(objCountryHead);
                return objCountryHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_Countrys_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MDCTY_CountryID", model.MDCTY_CountryID);
                        cmd.Parameters["@MDCTY_CountryID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnCountryModel objCountry = new ReturnCountryModel();

                                objCountryHead.resp = true;
                                objCountryHead.msg = "Get Country";

                                objCountry.MDCTY_CountryID = rdr["MDCTY_CountryID"].ToString();
                                objCountry.MDCTY_Country = rdr["MDCTY_Country"].ToString();
                                objCountry.MDCTY_Status = Convert.ToBoolean(rdr["MDCTY_Status"].ToString());

                                objCountryHead.Country.Add(objCountry);

                                objCountryHeadList.Add(objCountryHead);
                            }

                        }
                        else
                        {
                            ReturnCountryModel objCountry = new ReturnCountryModel();
                            objCountryHead.resp = true;
                            objCountryHead.msg = "";
                            objCountryHeadList.Add(objCountryHead);


                        }


                    }
                    return objCountryHeadList;

                }
            }
            catch (Exception ex)
            {
                objCountryHead = new ReturnCountryModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCountryHeadList.Add(objCountryHead);

                objError.WriteLog(0, "Country_Data", "get_Countrys_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Country_Data", "get_Countrys_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Country_Data", "get_Countrys_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Country_Data", "get_Countrys_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objCountryHeadList;

        }

        public static List<ReturnCountryModelHead> get_Country_all(CountrySearchModel model)//ok
        {
            List<ReturnCountryModelHead> objCountryHeadList = new List<ReturnCountryModelHead>();
            ReturnCountryModelHead objCountryHead = new ReturnCountryModelHead();

            if (objCountryHead.Country == null)
            {
                objCountryHead.Country = new List<ReturnCountryModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objCountryHead.resp = false;
                objCountryHead.IsAuthenticated = false;
                objCountryHeadList.Add(objCountryHead);
                return objCountryHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_Country_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@MDCTY_CountryID", model.MDCTY_CountryID);
                        //cmd.Parameters["@MDCTY_CountryID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnCountryModel objCountry = new ReturnCountryModel();

                                objCountryHead.resp = true;
                                objCountryHead.msg = "Get Country";

                                objCountry.MDCTY_CountryID = rdr["MDCTY_CountryID"].ToString();
                                objCountry.MDCTY_Country = rdr["MDCTY_Country"].ToString();
                                objCountry.MDCTY_Status = Convert.ToBoolean(rdr["MDCTY_Status"].ToString());

                                objCountryHead.Country.Add(objCountry);

                                objCountryHeadList.Add(objCountryHead);
                            }

                        }
                        else
                        {
                            ReturnCountryModel objCountry = new ReturnCountryModel();
                            objCountryHead.resp = true;
                            objCountryHead.msg = "";
                            objCountryHeadList.Add(objCountryHead);


                        }


                    }
                    return objCountryHeadList;

                }
            }
            catch (Exception ex)
            {
                objCountryHead = new ReturnCountryModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCountryHeadList.Add(objCountryHead);

                objError.WriteLog(0, "Country_Data", "get_Country_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Country_Data", "get_Country_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Country_Data", "get_Country_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Country_Data", "get_Country_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objCountryHeadList;

        }

        public static List<ReturnResponse> add_new_Country(CountryModel item)//ok
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


                        cmd.CommandText = "sp_insert_Country";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDCTY_CountryID", item.MDCTY_CountryID);
                        cmd.Parameters["@MDCTY_CountryID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDCTY_Country", item.MDCTY_Country);
                        cmd.Parameters["@MDCTY_Country"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDCTY_Status", item.MDCTY_Status);
                        cmd.Parameters["@MDCTY_Status"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "Country_Data", "add_new_Country", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Country_Data", "add_new_Country", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Country_Data", "add_new_Country", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Country_Data", "add_new_Country", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> modify_Country(CountryModel item)//ok
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


                        cmd.CommandText = "sp_modify_Country";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDCTY_CountryID", item.MDCTY_CountryID);
                        cmd.Parameters["@MDCTY_CountryID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDCTY_Country", item.MDCTY_Country);
                        cmd.Parameters["@MDCTY_Country"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDCTY_Status", item.MDCTY_Status);
                        cmd.Parameters["@MDCTY_Status"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "Country_Data", "add_new_Country", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Country_Data", "add_new_Country", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Country_Data", "add_new_Country", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Country_Data", "add_new_Country", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_Country(InactiveMDCTYModel item)//ok
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



                        cmd.CommandText = "sp_del_Country";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MDCTY_CountryID", item.MDCTY_CountryID);
                        cmd.Parameters["@MDCTY_CountryID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "Country_Data", "inactivate_Country", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Country_Data", "inactivate_Country", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Country_Data", "inactivate_Country", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Country_Data", "inactivate_Country", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

