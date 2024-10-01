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
    public class EmployeeSalary_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnEmployeeSalaryModelHead> get_EmployeeSalary_single(EmployeeSalary model)//ok
        {
            List<ReturnEmployeeSalaryModelHead> objEmployeeSalaryHeadList = new List<ReturnEmployeeSalaryModelHead>();
            ReturnEmployeeSalaryModelHead objEmployeeSalaryHead = new ReturnEmployeeSalaryModelHead();

            if (objEmployeeSalaryHead.EmployeeSalary == null)
            {
                objEmployeeSalaryHead.EmployeeSalary = new List<ReturnEmployeeSalaryModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objEmployeeSalaryHead.resp = false;
                objEmployeeSalaryHead.IsAuthenticated = false;
                objEmployeeSalaryHeadList.Add(objEmployeeSalaryHead);
                return objEmployeeSalaryHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_EmployeeSalary_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EES_ID", model.EES_ID);
                        cmd.Parameters["@EES_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnEmployeeSalaryModel objEmployeeSalary = new ReturnEmployeeSalaryModel();

                                objEmployeeSalaryHead.resp = true;
                                objEmployeeSalaryHead.msg = "Get EmployeeSalary";

                                objEmployeeSalary.EES_ID = Convert.ToInt32(rdr["EES_ID"].ToString());
                                objEmployeeSalary.EES_EmployeeID = rdr["EES_EmployeeID"].ToString();
                                objEmployeeSalary.EES_Salary = Convert.ToDecimal(rdr["EES_Salary"].ToString());
                                objEmployeeSalary.EES_ActiveFrom = Convert.ToDateTime(rdr["EES_ActiveFrom"].ToString());
                                objEmployeeSalary.EES_ActiveTo = Convert.ToDateTime(rdr["EES_ActiveTo"].ToString());
                                objEmployeeSalary.EES_Remarks = rdr["EES_Remarks"].ToString();
                                objEmployeeSalary.EES_SalaryType = rdr["EES_SalaryType"].ToString();

                                objEmployeeSalary.EES_Status = Convert.ToBoolean(rdr["EES_Status"].ToString());

                                objEmployeeSalaryHead.EmployeeSalary.Add(objEmployeeSalary);

                                objEmployeeSalaryHeadList.Add(objEmployeeSalaryHead);
                            }

                        }
                        else
                        {
                            ReturnEmployeeSalaryModel objEmployeeSalary = new ReturnEmployeeSalaryModel();
                            objEmployeeSalaryHead.resp = true;
                            objEmployeeSalaryHead.msg = "";
                            objEmployeeSalaryHeadList.Add(objEmployeeSalaryHead);


                        }


                    }
                    return objEmployeeSalaryHeadList;

                }
            }
            catch (Exception ex)
            {
                objEmployeeSalaryHead.resp = false;
                objEmployeeSalaryHead.msg = ex.Message.ToString();

                objEmployeeSalaryHeadList.Add(objEmployeeSalaryHead);

                objError.WriteLog(0, "EmployeeSalary_Data", "get_EmployeeSalary_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeSalary_Data", "get_EmployeeSalary_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeSalary_Data", "get_EmployeeSalary_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeSalary_Data", "get_EmployeeSalary_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objEmployeeSalaryHeadList;

        }

        public static List<ReturnEmployeeSalaryModelHead> get_EmployeeSalary_all(EmployeeSalarySearchModel model)//ok
        {
            List<ReturnEmployeeSalaryModelHead> objEmployeeSalaryHeadList = new List<ReturnEmployeeSalaryModelHead>();
            ReturnEmployeeSalaryModelHead objEmployeeSalaryHead = new ReturnEmployeeSalaryModelHead();

            if (objEmployeeSalaryHead.EmployeeSalary == null)
            {
                objEmployeeSalaryHead.EmployeeSalary = new List<ReturnEmployeeSalaryModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objEmployeeSalaryHead.resp = false;
                objEmployeeSalaryHead.IsAuthenticated = false;
                objEmployeeSalaryHeadList.Add(objEmployeeSalaryHead);
                return objEmployeeSalaryHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_EmployeeSalary_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EES_EmployeeID", model.EES_EmployeeID);
                        cmd.Parameters["@EES_EmployeeID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnEmployeeSalaryModel objEmployeeSalary = new ReturnEmployeeSalaryModel();

                                objEmployeeSalaryHead.resp = true;
                                objEmployeeSalaryHead.msg = "Get EmployeeSalary";

                                objEmployeeSalary.EES_ID = Convert.ToInt32(rdr["EES_ID"].ToString());
                                objEmployeeSalary.EES_EmployeeID = rdr["EES_EmployeeID"].ToString();
                                objEmployeeSalary.EES_Salary = Convert.ToDecimal(rdr["EES_Salary"].ToString());
                                objEmployeeSalary.EES_ActiveFrom = Convert.ToDateTime(rdr["EES_ActiveFrom"].ToString());
                                objEmployeeSalary.EES_ActiveTo = Convert.ToDateTime(rdr["EES_ActiveTo"].ToString());
                                objEmployeeSalary.EES_Remarks = rdr["EES_Remarks"].ToString();
                                objEmployeeSalary.EES_SalaryType = rdr["EES_SalaryType"].ToString();

                                objEmployeeSalary.EES_Status = Convert.ToBoolean(rdr["EES_Status"].ToString());

                                objEmployeeSalaryHead.EmployeeSalary.Add(objEmployeeSalary);

                                objEmployeeSalaryHeadList.Add(objEmployeeSalaryHead);
                            }

                        }
                        else
                        {
                            ReturnEmployeeSalaryModel objEmployeeSalary = new ReturnEmployeeSalaryModel();
                            objEmployeeSalaryHead.resp = true;
                            objEmployeeSalaryHead.msg = "";
                            objEmployeeSalaryHeadList.Add(objEmployeeSalaryHead);


                        }


                    }
                    return objEmployeeSalaryHeadList;

                }
            }
            catch (Exception ex)
            {
                objEmployeeSalaryHead.resp = false;
                objEmployeeSalaryHead.msg = ex.Message.ToString();

                objEmployeeSalaryHeadList.Add(objEmployeeSalaryHead);

                objError.WriteLog(0, "EmployeeSalary_Data", "get_EmployeeSalary_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeSalary_Data", "get_EmployeeSalary_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeSalary_Data", "get_EmployeeSalary_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeSalary_Data", "get_EmployeeSalary_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objEmployeeSalaryHeadList;

        }

        public static List<ReturnResponse> add_new_EmployeeSalary(EmployeeSalaryModel item)//ok
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


                        cmd.CommandText = "sp_insert_EmployeeSalary";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@EES_ID", item.EES_ID);
                        //cmd.Parameters["@EES_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EES_EmployeeID", item.EES_EmployeeID);
                        cmd.Parameters["@EES_EmployeeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EES_Salary", item.EES_Salary);
                        cmd.Parameters["@EES_Salary"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EES_ActiveFrom", item.EES_ActiveFrom);
                        cmd.Parameters["@EES_ActiveFrom"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EES_ActiveTo", item.EES_ActiveTo);
                        cmd.Parameters["@EES_ActiveTo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EES_Remarks", item.EES_Remarks);
                        cmd.Parameters["@EES_Remarks"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EES_SalaryType", item.EES_SalaryType);
                        cmd.Parameters["@EES_SalaryType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EES_Status", item.EES_Status);
                        cmd.Parameters["@EES_Status"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "EmployeeSalary_Data", "add_new_EmployeeSalary", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeSalary_Data", "add_new_EmployeeSalary", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeSalary_Data", "add_new_EmployeeSalary", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeSalary_Data", "add_new_EmployeeSalary", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> modify_EmployeeSalary(EmployeeSalaryModel item)//ok
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


                        cmd.CommandText = "sp_modify_EmployeeSalary";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EES_ID", item.EES_ID);
                        cmd.Parameters["@EES_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EES_EmployeeID", item.EES_EmployeeID);
                        cmd.Parameters["@EES_EmployeeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EES_Salary", item.EES_Salary);
                        cmd.Parameters["@EES_Salary"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EES_ActiveFrom", item.EES_ActiveFrom);
                        cmd.Parameters["@EES_ActiveFrom"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EES_ActiveTo", item.EES_ActiveTo);
                        cmd.Parameters["@EES_ActiveTo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EES_Remarks", item.EES_Remarks);
                        cmd.Parameters["@EES_Remarks"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EES_SalaryType", item.EES_SalaryType);
                        cmd.Parameters["@EES_SalaryType"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EES_Status", item.EES_Status);
                        cmd.Parameters["@EES_Status"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "EmployeeSalary_Data", "add_new_EmployeeSalary", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeSalary_Data", "add_new_EmployeeSalary", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeSalary_Data", "add_new_EmployeeSalary", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeSalary_Data", "add_new_EmployeeSalary", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_EmployeeSalary(InactiveEESModel item)//ok
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



                        cmd.CommandText = "sp_del_EmployeeSalary";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EES_ID", item.EES_ID);
                        cmd.Parameters["@EES_ID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "EmployeeSalary_Data", "inactivate_EmployeeSalary", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EmployeeSalary_Data", "inactivate_EmployeeSalary", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EmployeeSalary_Data", "inactivate_EmployeeSalary", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EmployeeSalary_Data", "inactivate_EmployeeSalary", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

