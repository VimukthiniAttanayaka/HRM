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
    public class EmployeeContact_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnEmployeeContactModelHead> get_EmployeeContact_single(EmployeeContact model)//ok
        {
            List<ReturnEmployeeContactModelHead> objEmployeeContactHeadList = new List<ReturnEmployeeContactModelHead>();
            ReturnEmployeeContactModelHead objEmployeeContactHead = new ReturnEmployeeContactModelHead();

            if (objEmployeeContactHead.EmployeeContact == null)
            {
                objEmployeeContactHead.EmployeeContact = new List<ReturnEmployeeContactModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objEmployeeContactHead.resp = false;
                objEmployeeContactHead.IsAuthenticated = false;
                objEmployeeContactHeadList.Add(objEmployeeContactHead);
                return objEmployeeContactHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_EmployeeContact_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EEC_ID", model.EEC_ID);
                        cmd.Parameters["@EEC_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnEmployeeContactModel objEmployeeContact = new ReturnEmployeeContactModel();

                                objEmployeeContactHead.resp = true;
                                objEmployeeContactHead.msg = "Get EmployeeContact";

                                objEmployeeContact.EEC_ID = Convert.ToInt32(rdr["EEC_ID"].ToString());
                                objEmployeeContact.EEC_EmployeeID = rdr["EEC_EmployeeID"].ToString();
                                objEmployeeContact.EEC_Address = rdr["EEC_Address"].ToString();
                                objEmployeeContact.EEC_EmailAddress = rdr["EEC_EmailAddress"].ToString();
                                objEmployeeContact.EEC_MobileNumber = rdr["EEC_MobileNumber"].ToString();
                                objEmployeeContact.EEC_PhoneNumber1 = rdr["EEC_PhoneNumber1"].ToString();
                                objEmployeeContact.EEC_PhoneNumber2 = rdr["EEC_PhoneNumber2"].ToString();
                                objEmployeeContact.EEC_Remarks = rdr["EEC_Remarks"].ToString();

                                objEmployeeContact.EEC_Status = Convert.ToBoolean(rdr["EEC_Status"].ToString());

                                objEmployeeContactHead.EmployeeContact.Add(objEmployeeContact);

                                objEmployeeContactHeadList.Add(objEmployeeContactHead);
                            }

                        }
                        else
                        {
                            ReturnEmployeeContactModel objEmployeeContact = new ReturnEmployeeContactModel();
                            objEmployeeContactHead.resp = true;
                            objEmployeeContactHead.msg = "";
                            objEmployeeContactHeadList.Add(objEmployeeContactHead);


                        }


                    }
                    return objEmployeeContactHeadList;

                }
            }
            catch (Exception ex)
            {
                objEmployeeContactHead.resp = false;
                objEmployeeContactHead.msg = ex.Message.ToString();

                objEmployeeContactHeadList.Add(objEmployeeContactHead);

                objError.WriteLog(0, "EmployeeContact_Data", "get_EmployeeContact_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeContact_Data", "get_EmployeeContact_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeContact_Data", "get_EmployeeContact_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeContact_Data", "get_EmployeeContact_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objEmployeeContactHeadList;

        }

        public static List<ReturnEmployeeContactModelHead> get_EmployeeContact_all(EmployeeContactSearchModel model)//ok
        {
            List<ReturnEmployeeContactModelHead> objEmployeeContactHeadList = new List<ReturnEmployeeContactModelHead>();
            ReturnEmployeeContactModelHead objEmployeeContactHead = new ReturnEmployeeContactModelHead();

            if (objEmployeeContactHead.EmployeeContact == null)
            {
                objEmployeeContactHead.EmployeeContact = new List<ReturnEmployeeContactModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objEmployeeContactHead.resp = false;
                objEmployeeContactHead.IsAuthenticated = false;
                objEmployeeContactHeadList.Add(objEmployeeContactHead);
                return objEmployeeContactHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_EmployeeContact_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EEC_EmployeeID", model.EEC_EmployeeID);
                        cmd.Parameters["@EEC_EmployeeID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnEmployeeContactModel objEmployeeContact = new ReturnEmployeeContactModel();

                                objEmployeeContactHead.resp = true;
                                objEmployeeContactHead.msg = "Get EmployeeContact";

                                objEmployeeContact.EEC_ID = Convert.ToInt32(rdr["EEC_ID"].ToString());
                                objEmployeeContact.EEC_EmployeeID = rdr["EEC_EmployeeID"].ToString();
                                objEmployeeContact.EEC_Address = rdr["EEC_Address"].ToString();
                                objEmployeeContact.EEC_EmailAddress = rdr["EEC_EmailAddress"].ToString();
                                objEmployeeContact.EEC_MobileNumber = rdr["EEC_MobileNumber"].ToString();
                                objEmployeeContact.EEC_PhoneNumber1 = rdr["EEC_PhoneNumber1"].ToString();
                                objEmployeeContact.EEC_PhoneNumber2 = rdr["EEC_PhoneNumber2"].ToString();
                                objEmployeeContact.EEC_Status = Convert.ToBoolean(rdr["EEC_Status"].ToString());

                                objEmployeeContactHead.EmployeeContact.Add(objEmployeeContact);

                                objEmployeeContactHeadList.Add(objEmployeeContactHead);
                            }

                        }
                        else
                        {
                            ReturnEmployeeContactModel objEmployeeContact = new ReturnEmployeeContactModel();
                            objEmployeeContactHead.resp = true;
                            objEmployeeContactHead.msg = "";
                            objEmployeeContactHeadList.Add(objEmployeeContactHead);


                        }


                    }
                    return objEmployeeContactHeadList;

                }
            }
            catch (Exception ex)
            {
                objEmployeeContactHead.resp = false;
                objEmployeeContactHead.msg = ex.Message.ToString();

                objEmployeeContactHeadList.Add(objEmployeeContactHead);

                objError.WriteLog(0, "EmployeeContact_Data", "get_EmployeeContact_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeContact_Data", "get_EmployeeContact_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeContact_Data", "get_EmployeeContact_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeContact_Data", "get_EmployeeContact_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objEmployeeContactHeadList;

        }

        public static List<ReturnResponse> add_new_EmployeeContact(EmployeeContactModel item)//ok
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


                        cmd.CommandText = "sp_insert_EmployeeContact";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@EEC_ID", item.EEC_ID);
                        //cmd.Parameters["@EEC_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEC_EmployeeID", item.EEC_EmployeeID);
                        cmd.Parameters["@EEC_EmployeeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEC_Address", item.EEC_Address);
                        cmd.Parameters["@EEC_Address"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEC_EmailAddress", item.EEC_EmailAddress);
                        cmd.Parameters["@EEC_EmailAddress"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEC_MobileNumber", item.EEC_MobileNumber);
                        cmd.Parameters["@EEC_MobileNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEC_Status", item.EEC_Status);
                        cmd.Parameters["@EEC_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEC_PhoneNumber1", item.EEC_PhoneNumber1);
                        cmd.Parameters["@EEC_PhoneNumber1"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEC_PhoneNumber2", item.EEC_PhoneNumber2);
                        cmd.Parameters["@EEC_PhoneNumber2"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEC_Remarks", item.EEC_Remarks);
                        cmd.Parameters["@EEC_Remarks"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "EmployeeContact_Data", "add_new_EmployeeContact", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeContact_Data", "add_new_EmployeeContact", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeContact_Data", "add_new_EmployeeContact", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeContact_Data", "add_new_EmployeeContact", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> modify_EmployeeContact(EmployeeContactModel item)//ok
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


                        cmd.CommandText = "sp_modify_EmployeeContact";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEC_ID", item.EEC_ID);
                        cmd.Parameters["@EEC_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEC_EmployeeID", item.EEC_EmployeeID);
                        cmd.Parameters["@EEC_EmployeeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEC_Address", item.EEC_Address);
                        cmd.Parameters["@EEC_Address"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEC_EmailAddress", item.EEC_EmailAddress);
                        cmd.Parameters["@EEC_EmailAddress"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEC_MobileNumber", item.EEC_MobileNumber);
                        cmd.Parameters["@EEC_MobileNumber"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEC_Status", item.EEC_Status);
                        cmd.Parameters["@EEC_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEC_PhoneNumber1", item.EEC_PhoneNumber1);
                        cmd.Parameters["@EEC_PhoneNumber1"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEC_PhoneNumber2", item.EEC_PhoneNumber2);
                        cmd.Parameters["@EEC_PhoneNumber2"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EEC_Remarks", item.EEC_Remarks);
                        cmd.Parameters["@EEC_Remarks"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "EmployeeContact_Data", "add_new_EmployeeContact", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeContact_Data", "add_new_EmployeeContact", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeContact_Data", "add_new_EmployeeContact", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeContact_Data", "add_new_EmployeeContact", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_EmployeeContact(InactiveEECModel item)//ok
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



                        cmd.CommandText = "sp_del_EmployeeContact";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EEC_ID", item.EEC_ID);
                        cmd.Parameters["@EEC_ID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "EmployeeContact_Data", "inactivate_EmployeeContact", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeContact_Data", "inactivate_EmployeeContact", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeContact_Data", "inactivate_EmployeeContact", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeContact_Data", "inactivate_EmployeeContact", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

