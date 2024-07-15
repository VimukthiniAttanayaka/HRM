using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class systemssettings_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturCountryModelHead> get_country_all(GetCountryAllModel Coall)//ok
        {
            List<ReturCountryModelHead> objCouHeadList = new List<ReturCountryModelHead>();
            List<ReturnCountryAllModel> objCouList = new List<ReturnCountryAllModel>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    ReturCountryModelHead objCouHead = new ReturCountryModelHead();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        if (lconn.State == ConnectionState.Closed)
                        {
                            lconn.Open();
                        }
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_country_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", Coall.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", Coall.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@COU_Code", Coall.COU_Code);
                        cmd.Parameters["@COU_Code"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@COU_Name", Coall.COU_Name);
                        cmd.Parameters["@COU_Name"].Direction = ParameterDirection.Input;

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_country_count";
                            cmdrc.CommandType = CommandType.StoredProcedure;
                            SqlDataReader rdrrc = cmdrc.ExecuteReader();
                            rdrrc.Read();
                            RC = rdrrc["RC"].ToString();
                        }

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnCountryAllModel objCouData = new ReturnCountryAllModel();

                                objCouHead.resp = true;
                                objCouHead.msg = "Country";

                                objCouData.COU_Code = rdr["COU_Code"].ToString();
                                objCouData.COU_Name = rdr["COU_Name"].ToString();
                                objCouData.COU_ISO_AlphaCode = rdr["COU_ISO_AlphaCode"].ToString();
                                objCouData.COU_ISO_NumericCode = rdr["COU_ISO_NumericCode"].ToString();
                                objCouData.RC = RC;

                                //objUserData.UserGroup.Add(objUserHead);

                                objCouList.Add(objCouData);

                                if (objCouHead.country == null)
                                {
                                    objCouHead.country = new List<ReturnCountryAllModel>();
                                }

                                objCouHead.country.Add(objCouData);
                            }
                            objCouHeadList.Add(objCouHead);

                        }
                        else
                        {
                            objCouHead.resp = true;
                            objCouHead.msg = "";
                            objCouHeadList.Add(objCouHead);


                        }


                    }

                    if (lconn.State == ConnectionState.Open)
                    { 
                        lconn.Close();
                    }
                    return objCouHeadList;
                }
            }
            catch (Exception ex)
            {
             
                ReturCountryModelHead objCouHead = new ReturCountryModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCouHeadList.Add(objCouHead);

                objError.WriteLog(0, "UserController", "GetUser", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "GetUser", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "GetUser", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "GetUser", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCouHeadList;

        }

        public static List<ReturCountryModelHead> get_country_single(GetCountrysingleModel Cosingle)//ok
        {
            List<ReturCountryModelHead> objCouHeadList = new List<ReturCountryModelHead>();
            List<ReturnCountryAllModel> objCouList = new List<ReturnCountryAllModel>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    if (lconn.State == ConnectionState.Closed)
                    {
                        lconn.Open();
                    }

                    ReturCountryModelHead objCouHead = new ReturCountryModelHead();
                    using (SqlCommand cmd = new SqlCommand())
                    {                       
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_country_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@COU_Code", Cosingle.COU_Code);
                        cmd.Parameters["@COU_Code"].Direction = ParameterDirection.Input;


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnCountryAllModel objCouData = new ReturnCountryAllModel();

                                objCouHead.resp = true;
                                objCouHead.msg = "Country";

                                objCouData.COU_Code = rdr["COU_Code"].ToString();
                                objCouData.COU_Name = rdr["COU_Name"].ToString();
                                objCouData.COU_ISO_AlphaCode = rdr["COU_ISO_AlphaCode"].ToString();
                                objCouData.COU_ISO_NumericCode = rdr["COU_ISO_NumericCode"].ToString();
                                objCouData.RC = "1";
                                //objUserData.UserGroup.Add(objUserHead);

                                objCouList.Add(objCouData);

                                if (objCouHead.country == null)
                                {
                                    objCouHead.country = new List<ReturnCountryAllModel>();
                                }

                                objCouHead.country.Add(objCouData);
                            }
                            objCouHeadList.Add(objCouHead);

                        }
                        else
                        {
                            objCouHead.resp = true;
                            objCouHead.msg = "";
                            objCouHeadList.Add(objCouHead);
                        }
                    }

                    if (lconn.State == ConnectionState.Open)
                    {
                        lconn.Close();
                    }
                }
                
                
                return objCouHeadList;

            }
            catch (Exception ex)
            {
             
                ReturCountryModelHead objCouHead = new ReturCountryModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCouHeadList.Add(objCouHead);

                objError.WriteLog(0, "UserController", "GetUser", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "GetUser", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "GetUser", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "GetUser", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCouHeadList;

        }

        public static List<ReturCurrencyModelHead> get_currency_all(GetCurrencyAllModel Cuall)//ok
        {
            List<ReturCurrencyModelHead> objCurHeadList = new List<ReturCurrencyModelHead>();
            List<ReturnCurrencyAllModel> objCurList = new List<ReturnCurrencyAllModel>();


            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    ReturCurrencyModelHead objCurHead = new ReturCurrencyModelHead();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        if (lconn.State == ConnectionState.Closed)
                        {
                            lconn.Open();
                        }
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_currency_all";
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@PAGE_NO", Cuall.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", Cuall.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUR_Code", Cuall.CUR_Code);
                        cmd.Parameters["@CUR_Code"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUR_Name", Cuall.CUR_Name);
                        cmd.Parameters["@CUR_Name"].Direction = ParameterDirection.Input;


                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_currency_count";
                            cmdrc.CommandType = CommandType.StoredProcedure;
                            SqlDataReader rdrrc = cmdrc.ExecuteReader();
                            rdrrc.Read();
                            RC = rdrrc["RC"].ToString();
                        }

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnCurrencyAllModel objCurData = new ReturnCurrencyAllModel();


                                objCurHead.resp = true;
                                objCurHead.msg = "Currency";

                                objCurData.CUR_Code = rdr["CUR_Code"].ToString();
                                objCurData.CUR_Name = rdr["CUR_Name"].ToString();
                                objCurData.CUR_ISO_Code = rdr["CUR_ISO_Code"].ToString();
                                objCurData.RC = RC;




                                objCurList.Add(objCurData);

                                if (objCurHead.currency == null)
                                {
                                    objCurHead.currency = new List<ReturnCurrencyAllModel>();
                                }

                                objCurHead.currency.Add(objCurData);
                            }
                            objCurHeadList.Add(objCurHead);

                        }
                        else
                        {
                            objCurHead.resp = true;
                            objCurHead.msg = "";
                            objCurHeadList.Add(objCurHead);


                        }


                    }

                    if (lconn.State == ConnectionState.Open)
                    {
                        lconn.Close();
                    }
                    return objCurHeadList;
                }
            }
            catch (Exception ex)
            {
                ReturCurrencyModelHead objCurHead = new ReturCurrencyModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCurHeadList.Add(objCurHead);

                objError.WriteLog(0, "UserController", "GetUser", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "GetUser", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "GetUser", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "GetUser", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCurHeadList;

        }

        public static List<ReturCurrencyModelHead> get_currency_single(GetCurrencyAllModel Cusingle)//ok
        {
            List<ReturCurrencyModelHead> objCurHeadList = new List<ReturCurrencyModelHead>();
            List<ReturnCurrencyAllModel> objCurList = new List<ReturnCurrencyAllModel>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    ReturCurrencyModelHead objCurHead = new ReturCurrencyModelHead();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        if (lconn.State == ConnectionState.Closed)
                        {
                            lconn.Open();
                        }
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_currency_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CUR_Code", Cusingle.CUR_Code);
                        cmd.Parameters["@CUR_Code"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnCurrencyAllModel objCurData = new ReturnCurrencyAllModel();

                                objCurHead.resp = true;
                                objCurHead.msg = "Currency";

                                objCurData.CUR_Code = rdr["CUR_Code"].ToString();
                                objCurData.CUR_Name = rdr["CUR_Name"].ToString();
                                objCurData.CUR_ISO_Code = rdr["CUR_ISO_Code"].ToString();
                                objCurData.RC = "1";




                                objCurList.Add(objCurData);

                                if (objCurHead.currency == null)
                                {
                                    objCurHead.currency = new List<ReturnCurrencyAllModel>();
                                }

                                objCurHead.currency.Add(objCurData);

                            }
                            objCurHeadList.Add(objCurHead);

                        }
                        else
                        {
                            objCurHead.resp = true;
                            objCurHead.msg = "";
                            objCurHeadList.Add(objCurHead);


                        }


                    }

                    if (lconn.State == ConnectionState.Open)
                    {
                        lconn.Close();
                    }
                    return objCurHeadList;
                }
            }
            catch (Exception ex)
            {
            
                ReturCurrencyModelHead objCurHead = new ReturCurrencyModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCurHeadList.Add(objCurHead);

                objError.WriteLog(0, "UserController", "GetUser", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "GetUser", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "GetUser", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "GetUser", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCurHeadList;

        }




    }








}








