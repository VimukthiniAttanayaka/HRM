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
    public class Currency_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnCurrencyModelHead> get_Currencys_single(Currency model)//ok
        {
            List<ReturnCurrencyModelHead> objCurrencyHeadList = new List<ReturnCurrencyModelHead>();
            ReturnCurrencyModelHead objCurrencyHead = new ReturnCurrencyModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objCurrencyHead.resp = false;
                objCurrencyHead.IsAuthenticated = false;
                objCurrencyHeadList.Add(objCurrencyHead);
                return objCurrencyHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_Currencys_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MDCCY_CurrencyID", model.MDCCY_CurrencyID);
                        cmd.Parameters["@MDCCY_CurrencyID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnCurrencyModel objCurrency = new ReturnCurrencyModel();

                                objCurrencyHead.resp = true;
                                objCurrencyHead.msg = "Get Currency";

                                objCurrency.MDCCY_CurrencyID = rdr["MDCCY_CurrencyID"].ToString();
                                objCurrency.MDCCY_LeaveAlotment = Convert.ToInt16(rdr["MDCCY_LeaveAlotment"].ToString());
                                objCurrency.MDCCY_Currency = rdr["MDCCY_Currency"].ToString();
                                objCurrency.MDCCY_Status = Convert.ToBoolean(rdr["MDCCY_Status"].ToString());

                                if (objCurrencyHead.Currency == null)
                                {
                                    objCurrencyHead.Currency = new List<ReturnCurrencyModel>();
                                }

                                objCurrencyHead.Currency.Add(objCurrency);

                                objCurrencyHeadList.Add(objCurrencyHead);
                            }

                        }
                        else
                        {
                            ReturnCurrencyModel objCurrency = new ReturnCurrencyModel();
                            objCurrencyHead.resp = true;
                            objCurrencyHead.msg = "";
                            objCurrencyHeadList.Add(objCurrencyHead);


                        }


                    }
                    return objCurrencyHeadList;

                }
            }
            catch (Exception ex)
            {
                objCurrencyHead = new ReturnCurrencyModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCurrencyHeadList.Add(objCurrencyHead);

                objError.WriteLog(0, "Currency_Data", "get_Currencys_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Currency_Data", "get_Currencys_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Currency_Data", "get_Currencys_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Currency_Data", "get_Currencys_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objCurrencyHeadList;

        }

        public static List<ReturnCurrencyModelHead> get_Currency_all(CurrencySearchModel model)//ok
        {
            List<ReturnCurrencyModelHead> objCurrencyHeadList = new List<ReturnCurrencyModelHead>();
            ReturnCurrencyModelHead objCurrencyHead = new ReturnCurrencyModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objCurrencyHead.resp = false;
                objCurrencyHead.IsAuthenticated = false;
                objCurrencyHeadList.Add(objCurrencyHead);
                return objCurrencyHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "get_Currency_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MDCCY_CurrencyID", model.MDCCY_CurrencyID);
                        cmd.Parameters["@MDCCY_CurrencyID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnCurrencyModel objCurrency = new ReturnCurrencyModel();

                                objCurrencyHead.resp = true;
                                objCurrencyHead.msg = "Get Currency";

                                objCurrency.MDCCY_CurrencyID = rdr["MDCCY_CurrencyID"].ToString();
                                objCurrency.MDCCY_LeaveAlotment = Convert.ToInt16(rdr["MDCCY_LeaveAlotment"].ToString());
                                objCurrency.MDCCY_Currency = rdr["MDCCY_Currency"].ToString();
                                objCurrency.MDCCY_Status = Convert.ToBoolean(rdr["MDCCY_Status"].ToString());

                                if (objCurrencyHead.Currency == null)
                                {
                                    objCurrencyHead.Currency = new List<ReturnCurrencyModel>();
                                }

                                objCurrencyHead.Currency.Add(objCurrency);

                                objCurrencyHeadList.Add(objCurrencyHead);
                            }

                        }
                        else
                        {
                            ReturnCurrencyModel objCurrency = new ReturnCurrencyModel();
                            objCurrencyHead.resp = true;
                            objCurrencyHead.msg = "";
                            objCurrencyHeadList.Add(objCurrencyHead);


                        }


                    }
                    return objCurrencyHeadList;

                }
            }
            catch (Exception ex)
            {
                objCurrencyHead = new ReturnCurrencyModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCurrencyHeadList.Add(objCurrencyHead);

                objError.WriteLog(0, "Currency_Data", "get_Currency_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Currency_Data", "get_Currency_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Currency_Data", "get_Currency_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Currency_Data", "get_Currency_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objCurrencyHeadList;

        }

        public static List<ReturncustResponse> add_new_Currency(CurrencyModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();
            ReturncustResponse objCustHead = new ReturncustResponse();

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


                        cmd.CommandText = "sp_insert_Currency";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_StaffID", item.UD_StaffID);
                        cmd.Parameters["@UD_StaffID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDCCY_CurrencyID", item.MDCCY_CurrencyID);
                        cmd.Parameters["@MDCCY_CurrencyID"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_CompanyName", item.CUS_CompanyName);
                        //cmd.Parameters["@CUS_CompanyName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_BlockBuildingNo", item.CUS_Adrs_BlockBuildingNo);
                        //cmd.Parameters["@CUS_Adrs_BlockBuildingNo"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_BuildingName", item.CUS_Adrs_BuildingName);
                        //cmd.Parameters["@CUS_Adrs_BuildingName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_UnitNumber", item.CUS_Adrs_UnitNumber);
                        //cmd.Parameters["@CUS_Adrs_UnitNumber"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_StreetName", item.CUS_Adrs_StreetName);
                        //cmd.Parameters["@CUS_Adrs_StreetName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_City", item.CUS_Adrs_City);
                        //cmd.Parameters["@CUS_Adrs_City"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_CountryCode", item.CUS_Adrs_CountryCode);
                        //cmd.Parameters["@CUS_Adrs_CountryCode"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_PostalCode", item.CUS_Adrs_PostalCode);
                        //cmd.Parameters["@CUS_Adrs_PostalCode"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_ContactPerson", item.CUS_ContactPerson);
                        //cmd.Parameters["@CUS_ContactPerson"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_ContactNumber", item.CUS_ContactNumber);
                        //cmd.Parameters["@CUS_ContactNumber"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_PinOrPwd", item.CUS_PinOrPwd);
                        //cmd.Parameters["@CUS_PinOrPwd"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_OTP_By_SMS", item.CUS_OTP_By_SMS);
                        //cmd.Parameters["@CUS_OTP_By_SMS"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_OTP_By_Email", item.CUS_OTP_By_Email);
                        //cmd.Parameters["@CUS_OTP_By_Email"].Direction = ParameterDirection.Input;

                        string mailtypes = "";

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objCustHead = new ReturncustResponse
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
                objCustHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objCustHead);

                objError.WriteLog(0, "Currency_Data", "add_new_Currency", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Currency_Data", "add_new_Currency", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Currency_Data", "add_new_Currency", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Currency_Data", "add_new_Currency", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturncustResponse> modify_Currency(CurrencyModel item)//ok
        {
            List<ReturncustResponse> objCustHeadList = new List<ReturncustResponse>();
            ReturncustResponse objCustHead = new ReturncustResponse();

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


                        cmd.CommandText = "sp_modify_Currency";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_StaffID", item.UD_StaffID);
                        cmd.Parameters["@UD_StaffID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDCCY_CurrencyID", item.MDCCY_CurrencyID);
                        cmd.Parameters["@MDCCY_CurrencyID"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_CompanyName", item.CUS_CompanyName);
                        //cmd.Parameters["@CUS_CompanyName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_BlockBuildingNo", item.CUS_Adrs_BlockBuildingNo);
                        //cmd.Parameters["@CUS_Adrs_BlockBuildingNo"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_BuildingName", item.CUS_Adrs_BuildingName);
                        //cmd.Parameters["@CUS_Adrs_BuildingName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_UnitNumber", item.CUS_Adrs_UnitNumber);
                        //cmd.Parameters["@CUS_Adrs_UnitNumber"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_StreetName", item.CUS_Adrs_StreetName);
                        //cmd.Parameters["@CUS_Adrs_StreetName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_City", item.CUS_Adrs_City);
                        //cmd.Parameters["@CUS_Adrs_City"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_CountryCode", item.CUS_Adrs_CountryCode);
                        //cmd.Parameters["@CUS_Adrs_CountryCode"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_PostalCode", item.CUS_Adrs_PostalCode);
                        //cmd.Parameters["@CUS_Adrs_PostalCode"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_ContactPerson", item.CUS_ContactPerson);
                        //cmd.Parameters["@CUS_ContactPerson"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_ContactNumber", item.CUS_ContactNumber);
                        //cmd.Parameters["@CUS_ContactNumber"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_PinOrPwd", item.CUS_PinOrPwd);
                        //cmd.Parameters["@CUS_PinOrPwd"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_OTP_By_SMS", item.CUS_OTP_By_SMS);
                        //cmd.Parameters["@CUS_OTP_By_SMS"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_OTP_By_Email", item.CUS_OTP_By_Email);
                        //cmd.Parameters["@CUS_OTP_By_Email"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Status", item.CUS_Status);
                        //cmd.Parameters["@CUS_Status"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objCustHead = new ReturncustResponse
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
                objCustHead = new ReturncustResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustHeadList.Add(objCustHead);

                objError.WriteLog(0, "Currency_Data", "add_new_Currency", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Currency_Data", "add_new_Currency", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Currency_Data", "add_new_Currency", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Currency_Data", "add_new_Currency", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_Currency(InactiveMDCCYModel item)//ok
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



                        cmd.CommandText = "sp_del_Currency";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MDCCY_CurrencyID", item.MDCCY_CurrencyID);
                        cmd.Parameters["@MDCCY_CurrencyID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UD_StaffID", item.UD_StaffID);
                        cmd.Parameters["@UD_StaffID"].Direction = ParameterDirection.Input;



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

                objError.WriteLog(0, "Currency_Data", "inactivate_Currency", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Currency_Data", "inactivate_Currency", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Currency_Data", "inactivate_Currency", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Currency_Data", "inactivate_Currency", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

