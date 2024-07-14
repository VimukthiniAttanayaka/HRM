using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class DepartmentPaymentChargeCode_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnResponse> add_new_departmentpcc(DepartmentPCCModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            ReturnResponse objHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objHead.resp = false;
                objHead.IsAuthenticated = false;
                objHeadList.Add(objHead);
                return objHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_insert_department_pccode";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DPCC_CustomerID", item.DPCC_CustomerID);
                        cmd.Parameters["@DPCC_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPCC_DepartmentID", item.DPCC_DepartmentID);
                        cmd.Parameters["@DPCC_DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPCC_PCCode", item.DPCC_PCCode);
                        cmd.Parameters["@DPCC_PCCode"].Direction = ParameterDirection.Input;

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
                                objHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objHeadList.Add(objHead);

                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentPaymentChargeCode_Data", "add_new_departmentpcc", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentPaymentChargeCode_Data", "add_new_departmentpcc", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentPaymentChargeCode_Data", "add_new_departmentpcc", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentPaymentChargeCode_Data", "add_new_departmentpcc", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        public static List<ReturnResponse> modify_departmentpcc(DepartmentPCCModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            ReturnResponse objHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objHead.resp = false;
                objHead.IsAuthenticated = false;
                objHeadList.Add(objHead);
                return objHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;


                        cmd.CommandText = "sp_modify_department_pccode";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DPCC_CustomerID", item.DPCC_CustomerID);
                        cmd.Parameters["@DPCC_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPCC_DepartmentID", item.DPCC_DepartmentID);
                        cmd.Parameters["@DPCC_DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPCC_PCCode", item.DPCC_PCCode);
                        cmd.Parameters["@DPCC_PCCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPCC_PCCode_Old", item.DPCC_PCCode_Old);
                        cmd.Parameters["@DPCC_PCCode_Old"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPCC_Status", item.DPCC_Status);
                        cmd.Parameters["@DPCC_Status"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                objHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objHeadList.Add(objHead);

                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentPaymentChargeCode_Data", "add_new_departmentpcc", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentPaymentChargeCode_Data", "add_new_departmentpcc", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentPaymentChargeCode_Data", "add_new_departmentpcc", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentPaymentChargeCode_Data", "add_new_departmentpcc", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objHeadList;
        }

        public static List<ReturnResponse> inactivate_departmentpcc(InactiveDepartmentPCCModel item)//ok
        {
            List<ReturnResponse> objHeadList = new List<ReturnResponse>();
            ReturnResponse objHead = new ReturnResponse();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objHead.resp = false;
                objHead.IsAuthenticated = false;
                objHeadList.Add(objHead);
                return objHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_del_department_pccode";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DPCC_CustomerID", item.DPCC_CustomerID);
                        cmd.Parameters["@DPCC_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPCC_DepartmentID", item.DPCC_DepartmentID);
                        cmd.Parameters["@DPCC_DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPCC_PCCode", item.DPCC_PCCode);
                        cmd.Parameters["@DPCC_PCCode"].Direction = ParameterDirection.Input;

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
                                objHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objHeadList.Add(objHead);
                            }
                        }
                    }
                    return objHeadList;
                }
            }
            catch (Exception ex)
            {
                objHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentPaymentChargeCode_Data", "inactivate_departmentpcc", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentPaymentChargeCode_Data", "inactivate_departmentpcc", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentPaymentChargeCode_Data", "inactivate_departmentpcc", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentPaymentChargeCode_Data", "inactivate_departmentpcc", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objHeadList;
            }




        }

        public static List<ReturDepartmentPCCModelHead> get_departmentpcc_all(GetDepartmentPCCAllModel item)//ok
        {
            List<ReturDepartmentPCCModelHead> objHeadList = new List<ReturDepartmentPCCModelHead>();
            ReturDepartmentPCCModelHead objHead = new ReturDepartmentPCCModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objHead.resp = false;
                objHead.IsAuthenticated = false;
                objHeadList.Add(objHead);
                return objHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_department_pccode_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", item.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", item.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPCC_CustomerID", item.DPCC_CustomerID);
                        cmd.Parameters["@DPCC_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPT_ID", item.DPT_ID);
                        cmd.Parameters["@DPT_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPT_Name", item.DPT_Name);
                        cmd.Parameters["@DPT_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPT_CPCode", item.DPT_CPCode);
                        cmd.Parameters["@DPT_CPCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_CompanyName", item.CUS_CompanyName);
                        cmd.Parameters["@CUS_CompanyName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPT_Status", item.DPT_Status);
                        cmd.Parameters["@DPT_Status"].Direction = ParameterDirection.Input;


                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_department_pccode_count";
                            cmdrc.CommandType = CommandType.StoredProcedure;
                            SqlDataReader rdrrc = cmdrc.ExecuteReader();
                            rdrrc.Read();
                            RC = rdrrc["RC"].ToString();
                            rdrrc.Close();
                        }
                        //ReturnDepartmentPCCModel objData = new ReturnDepartmentPCCModel();

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnDepartmentPCCModel objData = new ReturnDepartmentPCCModel();

                                objHead.resp = true;
                                objHead.msg = "Department Payment Charge Code";

                                objData.DPCC_CustomerID = rdr["DPCC_CustomerID"].ToString();
                                objData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objData.DPCC_DepartmentID = rdr["DPCC_DepartmentID"].ToString();
                                objData.DPT_Name = rdr["DPT_Name"].ToString();
                                objData.DPCC_PCCode = rdr["DPCC_PCCode"].ToString();
                                objData.DPCC_Status = rdr["DPCC_Status"].ToString();

                                objData.DPCC_CreatedBy = rdr["DPCC_CreatedBy"].ToString();
                                objData.DPCC_CreatedDateTime = rdr["DPCC_CreatedDateTime"].ToString();
                                objData.DPCC_ModifiedBy = rdr["DPCC_ModifiedBy"].ToString();
                                objData.DPCC_ModifiedDateTime = rdr["DPCC_ModifiedDateTime"].ToString();
                                objData.RC = RC;

                                if (objHead.DepartmentPCC == null)
                                {
                                    objHead.DepartmentPCC = new List<ReturnDepartmentPCCModel>();
                                }

                                objHead.DepartmentPCC.Add(objData);


                            }
                            objHeadList.Add(objHead);
                        }
                        else
                        {
                            objHead.resp = true;
                            objHead.msg = "";
                            objHeadList.Add(objHead);


                        }


                    }

                    return objHeadList;
                }
            }
            catch (Exception ex)
            {

                objHead = new ReturDepartmentPCCModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentPaymentChargeCode_Data", "get_departmentpcc_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentPaymentChargeCode_Data", "get_departmentpcc_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentPaymentChargeCode_Data", "get_departmentpcc_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentPaymentChargeCode_Data", "get_departmentpcc_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        public static List<ReturDepartmentPCCModelHead> get_departmentpcc_single(GetDepartmentPCCSingleModel item)
        {
            List<ReturDepartmentPCCModelHead> objHeadList = new List<ReturDepartmentPCCModelHead>();
            ReturDepartmentPCCModelHead objHead = new ReturDepartmentPCCModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objHead.resp = false;
                objHead.IsAuthenticated = false;
                objHeadList.Add(objHead);
                return objHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_department_pccode_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DPCC_CustomerID ", item.DPCC_CustomerID);
                        cmd.Parameters["@DPCC_CustomerID "].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPCC_DepartmentID", item.DPCC_DepartmentID);
                        cmd.Parameters["@DPCC_DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DPCC_PCCode", item.DPCC_PCCode);
                        cmd.Parameters["@DPCC_PCCode"].Direction = ParameterDirection.Input;


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnDepartmentPCCModel objData = new ReturnDepartmentPCCModel();

                                objHead.resp = true;
                                objHead.msg = "Department Payment Charge Code";

                                objData.DPCC_CustomerID = rdr["DPCC_CustomerID"].ToString();
                                objData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objData.DPCC_DepartmentID = rdr["DPCC_DepartmentID"].ToString();
                                objData.DPT_Name = rdr["DPT_Name"].ToString();
                                objData.DPCC_PCCode = rdr["DPCC_PCCode"].ToString();
                                objData.DPCC_Status = rdr["DPCC_Status"].ToString();
                                objData.RC = "1";

                                if (objHead.DepartmentPCC == null)
                                {
                                    objHead.DepartmentPCC = new List<ReturnDepartmentPCCModel>();
                                }

                                objHead.DepartmentPCC.Add(objData);
                                objHeadList.Add(objHead);
                            }
                        }
                        else
                        {
                            objHead.resp = true;
                            objHead.msg = "";
                            objHeadList.Add(objHead);

                        }

                    }
                    return objHeadList;
                }
            }
            catch (Exception ex)
            {

                objHead = new ReturDepartmentPCCModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "DepartmentPaymentChargeCode_Data", "get_departmentpcc_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "DepartmentPaymentChargeCode_Data", "get_departmentpcc_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "DepartmentPaymentChargeCode_Data", "get_departmentpcc_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "DepartmentPaymentChargeCode_Data", "get_departmentpcc_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }



    }








}








