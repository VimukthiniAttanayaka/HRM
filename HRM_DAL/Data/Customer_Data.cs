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
                                objcustomer.CUS_BusinessUnit = rdr["CUS_BusinessUnit"].ToString();
                                objcustomer.BU_CompanyName = rdr["BU_CompanyName"].ToString();
                                objcustomer.CUS_InputCourierShipmentCost = Convert.ToBoolean(rdr["CUS_InputCourierShipmentCost"]);
                                objcustomer.CUS_InputCountryOverseasMail = Convert.ToBoolean(rdr["CUS_InputCountryOverseasMail"]);
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

        public static List<ReturnCustomerModelHead> get_customers_all(GetReturnCustomerAllModel item)//ok
        {
            List<ReturnCustomerModelHead> objCustomerHeadList = new List<ReturnCustomerModelHead>();
            ReturnCustomerModelHead objcustomerHead = new ReturnCustomerModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
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

                        cmd.CommandText = "sp_get_customers_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", item.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", item.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_ID", item.CUS_ID);
                        cmd.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_CompanyName", item.CUS_CompanyName);
                        cmd.Parameters["@CUS_CompanyName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_ID", item.BU_ID);
                        cmd.Parameters["@BU_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_Status", item.CUS_Status);
                        cmd.Parameters["@CUS_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_customers_count";
                            cmdrc.CommandType = CommandType.StoredProcedure;

                            SqlDataReader rdrrc = cmdrc.ExecuteReader();
                            rdrrc.Read();
                            RC = rdrrc["RC"].ToString();
                            rdrrc.Close();
                        }


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
                                objcustomer.CUS_BusinessUnit = rdr["CUS_BusinessUnit"].ToString();
                                objcustomer.BU_CompanyName = rdr["BU_CompanyName"].ToString();
                                objcustomer.CUS_InputCourierShipmentCost = Convert.ToBoolean(rdr["CUS_InputCourierShipmentCost"]);
                                objcustomer.CUS_InputCountryOverseasMail = Convert.ToBoolean(rdr["CUS_InputCountryOverseasMail"]);
                                objcustomer.CUS_PinOrPwd = rdr["CUS_PinOrPwd"].ToString();
                                objcustomer.CUS_OTP_By_SMS = Convert.ToBoolean(rdr["CUS_OTP_By_SMS"]);
                                objcustomer.CUS_OTP_By_Email = Convert.ToBoolean(rdr["CUS_OTP_By_Email"]);
                                objcustomer.CUS_Status = rdr["CUS_Status"].ToString();

                                objcustomer.CUS_CreatedBy = rdr["CUS_CreatedBy"].ToString();
                                objcustomer.CUS_CreatedDateTime = rdr["CUS_CreatedDateTime"].ToString();
                                objcustomer.CUS_ModifiedBy = rdr["CUS_ModifiedBy"].ToString();
                                objcustomer.CUS_ModifiedDateTime = rdr["CUS_ModifiedDateTime"].ToString();
                                objcustomer.RC = RC;

                                if (objcustomerHead.Customer == null)
                                {
                                    objcustomerHead.Customer = new List<ReturnCustomerModel>();
                                }

                                objcustomerHead.Customer.Add(objcustomer);
                            }
                            objCustomerHeadList.Add(objcustomerHead);
                        }
                        else
                        {
                            objcustomerHead.resp = true;
                            objcustomerHead.msg = "";
                            objCustomerHeadList.Add(objcustomerHead);


                        }
                    }
                }
                return objCustomerHeadList;
            }
            catch (Exception ex)
            {

                objcustomerHead = new ReturnCustomerModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objCustomerHeadList.Add(objcustomerHead);

                objError.WriteLog(0, "Customer_Data", "get_customers_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Customer_Data", "get_customers_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Customer_Data", "get_customers_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Customer_Data", "get_customers_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objCustomerHeadList;

        }

        public static List<ReturnCustomerModel> get_customers_for_kioski_sync()
        {
            List<ReturnCustomerModel> objCustHeadList = new List<ReturnCustomerModel>();
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_customers_for_kioski_sync";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objCustHeadList.Add(new ReturnCustomerModel
                                {
                                    CUS_ID = rdr["CUS_ID"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                objError.WriteLog(0, "Customer_Data", "get_customers_for_kioski_sync", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Customer_Data", "get_customers_for_kioski_sync", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Customer_Data", "get_customers_for_kioski_sync", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Customer_Data", "get_customers_for_kioski_sync", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return objCustHeadList;

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

                        cmd.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

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

                        cmd.Parameters.AddWithValue("@CUS_BusinessUnit", item.CUS_BusinessUnit);
                        cmd.Parameters["@CUS_BusinessUnit"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_InputCourierShipmentCost", item.CUS_InputCourierShipmentCost);
                        cmd.Parameters["@CUS_InputCourierShipmentCost"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_InputCountryOverseasMail", item.CUS_InputCountryOverseasMail);
                        cmd.Parameters["@CUS_InputCountryOverseasMail"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_PinOrPwd", item.CUS_PinOrPwd);
                        cmd.Parameters["@CUS_PinOrPwd"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_OTP_By_SMS", item.CUS_OTP_By_SMS);
                        cmd.Parameters["@CUS_OTP_By_SMS"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_OTP_By_Email", item.CUS_OTP_By_Email);
                        cmd.Parameters["@CUS_OTP_By_Email"].Direction = ParameterDirection.Input;

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

                        cmd.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

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

                        cmd.Parameters.AddWithValue("@CUS_BusinessUnit", item.CUS_BusinessUnit);
                        cmd.Parameters["@CUS_BusinessUnit"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_InputCourierShipmentCost", item.CUS_InputCourierShipmentCost);
                        cmd.Parameters["@CUS_InputCourierShipmentCost"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_InputCountryOverseasMail", item.CUS_InputCountryOverseasMail);
                        cmd.Parameters["@CUS_InputCountryOverseasMail"].Direction = ParameterDirection.Input;

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

                        cmd.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;



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

        public static List<ReturnBUCustomerModelHead> get_customers_for_user_with_select(TCustomerUserModel item)
        {
            List<ReturnBUCustomerModelHead> objUserHeadList = new List<ReturnBUCustomerModelHead>();
            List<ReturnUserCustModel> objCustList = new List<ReturnUserCustModel>();
            ReturnBUCustomerModelHead objUserHead = new ReturnBUCustomerModelHead();

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
                    using (SqlCommand cmdCust = new SqlCommand())
                    {
                        cmdCust.Connection = lconn;

                        cmdCust.CommandText = "sp_get_t_user_customers_with_select";
                        cmdCust.CommandType = CommandType.StoredProcedure;

                        cmdCust.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmdCust.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmdCust.Parameters.AddWithValue("@BU_ID", item.BU_ID);
                        cmdCust.Parameters["@BU_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dtaCust = new SqlDataAdapter();
                        dtaCust.SelectCommand = cmdCust;
                        DataSet DsCust = new DataSet();
                        dtaCust.Fill(DsCust);

                        if (DsCust != null && DsCust.Tables.Count > 0 && DsCust.Tables[0].Rows.Count > 0)
                        {
                            objUserHead.resp = true;
                            objUserHead.msg = "Customer";

                            foreach (DataRow rdrCust in DsCust.Tables[0].Rows)
                            {
                                ReturnUserCustModel objCustData = new ReturnUserCustModel
                                {
                                    CUS_ID = rdrCust["CUS_ID"].ToString(),
                                    IndexNo = rdrCust["IndexNo"].ToString(),
                                    CUS_CompanyName = rdrCust["CUS_CompanyName"].ToString(),
                                    BU_CompanyName = rdrCust["BU_CompanyName"].ToString(),
                                    UAG_Select = Convert.ToBoolean(rdrCust["UAG_Select"])
                                };

                                if (objUserHead.Customer == null)
                                {
                                    objUserHead.Customer = new List<ReturnUserCustModel>();
                                }

                                objUserHead.Customer.Add(objCustData);

                            }

                            objUserHeadList.Add(objUserHead);
                        }
                        else
                        {
                            objUserHead.resp = true;
                            objUserHead.msg = "";
                            objUserHeadList.Add(objUserHead);
                        }
                    }
                }

                return objUserHeadList;

            }
            catch (Exception ex)
            {

                objUserHead = new ReturnBUCustomerModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "UserController", "get_customers_for_user_with_select", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserController", "get_customers_for_user_with_select", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserController", "get_customers_for_user_with_select", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserController", "get_customers_for_user_with_select", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objUserHeadList;

        }



    }

}

