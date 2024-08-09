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
    public class Customer_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnCustomerModelHead> get_customers_single(Customer CUS_ID)//ok
        {
            List<ReturnCustomerModelHead> objCustomerHeadList = new List<ReturnCustomerModelHead>();
            ReturnCustomerModelHead objcustomerHead = new ReturnCustomerModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(CUS_ID) == false)
            {
                objcustomerHead.resp = false;
                objcustomerHead.IsAuthenticated = false;
                objCustomerHeadList.Add(objcustomerHead);
                return objCustomerHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_customers_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CUS_ID", CUS_ID.CUS_ID);
                        cmd.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnCustomerModel objcustomer = new ReturnCustomerModel();

                                objcustomerHead.resp = true;
                                objcustomerHead.msg = "Get Customer";

                                objcustomer.CUS_ID = rdr["CUS_ID"].ToString();
                                objcustomer.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objcustomer.CUS_Adrs_BlockBuildingNo = rdr["CUS_Adrs_BlockBuildingNo"].ToString();
                                objcustomer.CUS_Adrs_BuildingName = rdr["CUS_Adrs_BuildingName"].ToString();
                                objcustomer.CUS_Adrs_UnitNumber = rdr["CUS_Adrs_UnitNumber"].ToString();
                                objcustomer.CUS_Adrs_StreetName = rdr["CUS_Adrs_StreetName"].ToString();
                                objcustomer.CUS_Adrs_City = rdr["CUS_Adrs_City"].ToString();
                                objcustomer.CUS_Adrs_CountryCode = rdr["CUS_Adrs_CountryCode"].ToString();
                                objcustomer.CUS_Adrs_PostalCode = rdr["CUS_Adrs_PostalCode"].ToString();
                                objcustomer.CUS_ContactPerson = rdr["CUS_ContactPerson"].ToString();
                                objcustomer.CUS_ContactNumber = rdr["CUS_ContactNumber"].ToString();
                                objcustomer.CUS_PinOrPwd = rdr["CUS_PinOrPwd"].ToString();
                                objcustomer.CUS_OTP_By_SMS = Convert.ToBoolean(rdr["CUS_OTP_By_SMS"]);
                                objcustomer.CUS_OTP_By_Email = Convert.ToBoolean(rdr["CUS_OTP_By_Email"]);
                                objcustomer.CUS_Status = rdr["CUS_Status"].ToString();
                                objcustomer.RC = "1";

                                if (objcustomerHead.Customer == null)
                                {
                                    objcustomerHead.Customer = new List<ReturnCustomerModel>();
                                }

                                objcustomerHead.Customer.Add(objcustomer);

                                objCustomerHeadList.Add(objcustomerHead);
                            }

                        }
                        else
                        {
                            ReturnCustomerModel objcustomer = new ReturnCustomerModel();
                            objcustomerHead.resp = true;
                            objcustomerHead.msg = "";
                            objCustomerHeadList.Add(objcustomerHead);


                        }


                    }
                    return objCustomerHeadList;

                }
            }
            catch (Exception ex)
            {
                objcustomerHead = new ReturnCustomerModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustomerHeadList.Add(objcustomerHead);

                objError.WriteLog(0, "Customer_Data", "get_customers_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Customer_Data", "get_customers_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Customer_Data", "get_customers_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Customer_Data", "get_customers_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustomerHeadList;

        }

        public static List<ReturnCustomerModelHead> get_customer_all(CustomerSearchModel model)//ok
        {
            List<ReturnCustomerModelHead> objCustomerHeadList = new List<ReturnCustomerModelHead>();
            ReturnCustomerModelHead objcustomerHead = new ReturnCustomerModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objcustomerHead.resp = false;
                objcustomerHead.IsAuthenticated = false;
                objCustomerHeadList.Add(objcustomerHead);
                return objCustomerHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_customer_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnCustomerModel objcustomer = new ReturnCustomerModel();

                                objcustomerHead.resp = true;
                                objcustomerHead.msg = "Get Customer";

                                objcustomer.CUS_ID = rdr["CUS_ID"].ToString();
                                objcustomer.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objcustomer.CUS_Adrs_BlockBuildingNo = rdr["CUS_Adrs_BlockBuildingNo"].ToString();
                                objcustomer.CUS_Adrs_BuildingName = rdr["CUS_Adrs_BuildingName"].ToString();
                                objcustomer.CUS_Adrs_UnitNumber = rdr["CUS_Adrs_UnitNumber"].ToString();
                                objcustomer.CUS_Adrs_StreetName = rdr["CUS_Adrs_StreetName"].ToString();
                                objcustomer.CUS_Adrs_City = rdr["CUS_Adrs_City"].ToString();
                                objcustomer.CUS_Adrs_CountryCode = rdr["CUS_Adrs_CountryCode"].ToString();
                                objcustomer.CUS_Adrs_PostalCode = rdr["CUS_Adrs_PostalCode"].ToString();
                                objcustomer.CUS_ContactPerson = rdr["CUS_ContactPerson"].ToString();
                                objcustomer.CUS_ContactNumber = rdr["CUS_ContactNumber"].ToString();
                                objcustomer.CUS_PinOrPwd = rdr["CUS_PinOrPwd"].ToString();
                                objcustomer.CUS_OTP_By_SMS = Convert.ToBoolean(rdr["CUS_OTP_By_SMS"]);
                                objcustomer.CUS_OTP_By_Email = Convert.ToBoolean(rdr["CUS_OTP_By_Email"]);
                                objcustomer.CUS_Status = rdr["CUS_Status"].ToString();
                                objcustomer.RC = "1";

                                if (objcustomerHead.Customer == null)
                                {
                                    objcustomerHead.Customer = new List<ReturnCustomerModel>();
                                }

                                objcustomerHead.Customer.Add(objcustomer);

                                objCustomerHeadList.Add(objcustomerHead);
                            }

                        }
                        else
                        {
                            ReturnCustomerModel objcustomer = new ReturnCustomerModel();
                            objcustomerHead.resp = true;
                            objcustomerHead.msg = "";
                            objCustomerHeadList.Add(objcustomerHead);


                        }


                    }
                    return objCustomerHeadList;

                }
            }
            catch (Exception ex)
            {
                objcustomerHead = new ReturnCustomerModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustomerHeadList.Add(objcustomerHead);

                objError.WriteLog(0, "Customer_Data", "get_customer_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Customer_Data", "get_customer_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Customer_Data", "get_customer_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Customer_Data", "get_customer_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objCustomerHeadList;

        }

        public static List<ReturncustResponse> add_new_customer(CustomerModel item)//ok
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


                        cmd.CommandText = "sp_insert_customer";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_ID", item.CUS_ID);
                        cmd.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_CompanyName", item.CUS_CompanyName);
                        cmd.Parameters["@CUS_CompanyName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_Adrs_BlockBuildingNo", item.CUS_Adrs_BlockBuildingNo);
                        cmd.Parameters["@CUS_Adrs_BlockBuildingNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_Adrs_BuildingName", item.CUS_Adrs_BuildingName);
                        cmd.Parameters["@CUS_Adrs_BuildingName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_Adrs_UnitNumber", item.CUS_Adrs_UnitNumber);
                        cmd.Parameters["@CUS_Adrs_UnitNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_Adrs_StreetName", item.CUS_Adrs_StreetName);
                        cmd.Parameters["@CUS_Adrs_StreetName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_Adrs_City", item.CUS_Adrs_City);
                        cmd.Parameters["@CUS_Adrs_City"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_Adrs_CountryCode", item.CUS_Adrs_CountryCode);
                        cmd.Parameters["@CUS_Adrs_CountryCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_Adrs_PostalCode", item.CUS_Adrs_PostalCode);
                        cmd.Parameters["@CUS_Adrs_PostalCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_ContactPerson", item.CUS_ContactPerson);
                        cmd.Parameters["@CUS_ContactPerson"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_ContactNumber", item.CUS_ContactNumber);
                        cmd.Parameters["@CUS_ContactNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_PinOrPwd", item.CUS_PinOrPwd);
                        cmd.Parameters["@CUS_PinOrPwd"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_OTP_By_SMS", item.CUS_OTP_By_SMS);
                        cmd.Parameters["@CUS_OTP_By_SMS"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_OTP_By_Email", item.CUS_OTP_By_Email);
                        cmd.Parameters["@CUS_OTP_By_Email"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_Status", item.CUS_Status);
                        cmd.Parameters["@CUS_Status"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "Customer_Data", "add_new_customer", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Customer_Data", "add_new_customer", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Customer_Data", "add_new_customer", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Customer_Data", "add_new_customer", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturncustResponse> modify_customer(CustomerModel item)//ok
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


                        cmd.CommandText = "sp_modify_customer";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_ID", item.CUS_ID);
                        cmd.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_CompanyName", item.CUS_CompanyName);
                        cmd.Parameters["@CUS_CompanyName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_Adrs_BlockBuildingNo", item.CUS_Adrs_BlockBuildingNo);
                        cmd.Parameters["@CUS_Adrs_BlockBuildingNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_Adrs_BuildingName", item.CUS_Adrs_BuildingName);
                        cmd.Parameters["@CUS_Adrs_BuildingName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_Adrs_UnitNumber", item.CUS_Adrs_UnitNumber);
                        cmd.Parameters["@CUS_Adrs_UnitNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_Adrs_StreetName", item.CUS_Adrs_StreetName);
                        cmd.Parameters["@CUS_Adrs_StreetName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_Adrs_City", item.CUS_Adrs_City);
                        cmd.Parameters["@CUS_Adrs_City"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_Adrs_CountryCode", item.CUS_Adrs_CountryCode);
                        cmd.Parameters["@CUS_Adrs_CountryCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_Adrs_PostalCode", item.CUS_Adrs_PostalCode);
                        cmd.Parameters["@CUS_Adrs_PostalCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_ContactPerson", item.CUS_ContactPerson);
                        cmd.Parameters["@CUS_ContactPerson"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_ContactNumber", item.CUS_ContactNumber);
                        cmd.Parameters["@CUS_ContactNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_PinOrPwd", item.CUS_PinOrPwd);
                        cmd.Parameters["@CUS_PinOrPwd"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_OTP_By_SMS", item.CUS_OTP_By_SMS);
                        cmd.Parameters["@CUS_OTP_By_SMS"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_OTP_By_Email", item.CUS_OTP_By_Email);
                        cmd.Parameters["@CUS_OTP_By_Email"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_Status", item.CUS_Status);
                        cmd.Parameters["@CUS_Status"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "Customer_Data", "add_new_customer", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Customer_Data", "add_new_customer", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Customer_Data", "add_new_customer", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Customer_Data", "add_new_customer", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_customer(InactiveCusModel item)//ok
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



                        cmd.CommandText = "sp_del_customer";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CUS_ID", item.CUS_ID);
                        cmd.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "Customer_Data", "inactivate_customer", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Customer_Data", "inactivate_customer", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Customer_Data", "inactivate_customer", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Customer_Data", "inactivate_customer", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

