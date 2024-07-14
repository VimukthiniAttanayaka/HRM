using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class PCCode_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturPCCodeModelHead> get_PCCode_all(GetPCCodeAllModel item)//ok
        {
            List<ReturPCCodeModelHead> objHeadList = new List<ReturPCCodeModelHead>();
            ReturPCCodeModelHead objHead = new ReturPCCodeModelHead();
            List<ReturnPCCodeModel> objList = new List<ReturnPCCodeModel>();

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

                    objHead = new ReturPCCodeModelHead();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_PCCode_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", item.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", item.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CustomerID", item.CUS_ID);
                        cmd.Parameters["@CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DepartmentID", item.DEPT_ID);
                        cmd.Parameters["@DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PCCode", item.PCCode);
                        cmd.Parameters["@PCCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Status", item.Status);
                        cmd.Parameters["@Status"].Direction = ParameterDirection.Input;

                        //SqlDataReader rdr = cmd.ExecuteReader();

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_PCCode_count";
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
                                ReturnPCCodeModel objData = new ReturnPCCodeModel();

                                objHead.resp = true;
                                objHead.msg = "PCCode";

                                objData.PCC_ID = rdr["DPCC_PCCode"].ToString();
                                //objData.PCC_Name = rdr["PCC_Name"].ToString();
                                //objData.PCC_Description = rdr["PCC_Description"].ToString();
                                objData.PCC_Status = rdr["DPCC_Status"].ToString();
                                //objData.PCC_CreatedBy = rdr["PCC_CreatedBy"].ToString();
                                //objData.PCC_CreatedDateTime = rdr["PCC_CreatedDateTime"].ToString();
                                //objData.PCC_ModifiedBy = rdr["PCC_ModifiedBy"].ToString();
                               // objData.PCC_ModifiedDateTime = rdr["PCC_ModifiedDateTime"].ToString();
                                objData.RC = RC;

                                //objUserData.UserGroup.Add(objUserHead);

                                objList.Add(objData);

                                if (objHead.PCCode == null)
                                {
                                    objHead.PCCode = new List<ReturnPCCodeModel>();
                                }

                                objHead.PCCode.Add(objData);

                                objList.Add(objData);

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

                objHead = new ReturPCCodeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "PCCode_Data", "get_PCCode_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PCCode_Data", "get_PCCode_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PCCode_Data", "get_PCCode_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PCCode_Data", "get_PCCode_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        public static List<ReturPCCodeDistinctModelHead> get_PCCode_all_Distinct(GetPCCodeAllModel item)//ok
        {
            List<ReturPCCodeDistinctModelHead> objHeadList = new List<ReturPCCodeDistinctModelHead>();
            ReturPCCodeDistinctModelHead objHead = new ReturPCCodeDistinctModelHead();
            List<ReturnPCCodeDistinctModel> objList = new List<ReturnPCCodeDistinctModel>();

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

                    objHead = new ReturPCCodeDistinctModelHead();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_PCCode_all_Distinct";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", item.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", item.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CustomerID", item.CUS_ID);
                        cmd.Parameters["@CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@DepartmentID", item.DEPT_ID);
                        cmd.Parameters["@DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PCCode", item.PCCode);
                        cmd.Parameters["@PCCode"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Status", item.Status);
                        cmd.Parameters["@Status"].Direction = ParameterDirection.Input;

                        //SqlDataReader rdr = cmd.ExecuteReader();

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_PCCode_count";
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
                                ReturnPCCodeDistinctModel objData = new ReturnPCCodeDistinctModel();

                                objHead.resp = true;
                                objHead.msg = "PCCode";

                                objData.PCC_ID = rdr["DPCC_PCCode"].ToString();
                                objData.RC = RC;

                                //objUserData.UserGroup.Add(objUserHead);

                                objList.Add(objData);

                                if (objHead.PCCode == null)
                                {
                                    objHead.PCCode = new List<ReturnPCCodeDistinctModel>();
                                }

                                objHead.PCCode.Add(objData);

                                objList.Add(objData);

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

                objHead = new ReturPCCodeDistinctModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "PCCode_Data", "get_PCCode_all_Distinct", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PCCode_Data", "get_PCCode_all_Distinct", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PCCode_Data", "get_PCCode_all_Distinct", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PCCode_Data", "get_PCCode_all_Distinct", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        public static List<ReturPCCodeModelHead> get_PCCode_By_Department_Customer(GetPCCodeDepartmentModel item)
        {
            List<ReturPCCodeModelHead> objHeadList = new List<ReturPCCodeModelHead>();
            List<ReturnPCCodeModel> objList = new List<ReturnPCCodeModel>();
            ReturPCCodeModelHead objHead = new ReturPCCodeModelHead();

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

                        cmd.CommandText = "get_PCCode_By_Department_Customer";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DPT_ID", item.DPT_ID);
                        cmd.Parameters["@DPT_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_ID", item.CUS_ID);
                        cmd.Parameters["@CUS_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_NO", item.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", item.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        //SqlDataReader rdr = cmd.ExecuteReader();

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_PCCode_count";
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
                                ReturnPCCodeModel objData = new ReturnPCCodeModel();

                                objHead.resp = true;
                                objHead.msg = "PCCode";

                                objData.PCC_ID = rdr["DPCC_PCCode"].ToString();
                                //objData.PCC_Name = rdr["PCC_Name"].ToString();
                                //objData.PCC_Description = rdr["PCC_Description"].ToString();
                                objData.PCC_Status = rdr["DPCC_Status"].ToString();
                                objData.RC = RC;

                                //objUserData.UserGroup.Add(objUserHead);

                                objList.Add(objData);

                                if (objHead.PCCode == null)
                                {
                                    objHead.PCCode = new List<ReturnPCCodeModel>();
                                }

                                objHead.PCCode.Add(objData);

                                objList.Add(objData);

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

                objHead = new ReturPCCodeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "PCCode_Data", "get_PCCode_By_Department_Customer", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PCCode_Data", "get_PCCode_By_Department_Customer", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PCCode_Data", "get_PCCode_By_Department_Customer", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PCCode_Data", "get_PCCode_By_Department_Customer", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;
        }

        public static List<ReturPCCodeModelHead> get_PCCode_By_Department(GetPCCodeDepartmentModel item)
        {
            List<ReturPCCodeModelHead> objHeadList = new List<ReturPCCodeModelHead>();
            List<ReturnPCCodeModel> objList = new List<ReturnPCCodeModel>();
   ReturPCCodeModelHead objHead = new ReturPCCodeModelHead();

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

                        cmd.CommandText = "get_PCCode_By_Department";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DPT_ID", item.DPT_ID);
                        cmd.Parameters["@DPT_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_NO", item.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", item.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        //SqlDataReader rdr = cmd.ExecuteReader();

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_PCCode_count";
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
                                ReturnPCCodeModel objData = new ReturnPCCodeModel();

                                objHead.resp = true;
                                objHead.msg = "PCCode";

                                objData.PCC_ID = rdr["DPCC_PCCode"].ToString();
                                //objData.PCC_Name = rdr["PCC_Name"].ToString();
                                //objData.PCC_Description = rdr["PCC_Description"].ToString();
                                objData.PCC_Status = rdr["DPCC_Status"].ToString();
                                objData.RC = RC;

                                //objUserData.UserGroup.Add(objUserHead);

                                objList.Add(objData);

                                if (objHead.PCCode == null)
                                {
                                    objHead.PCCode = new List<ReturnPCCodeModel>();
                                }

                                objHead.PCCode.Add(objData);

                                objList.Add(objData);

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

                 objHead = new ReturPCCodeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "PCCode_Data", "get_PCCode_By_Department", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PCCode_Data", "get_PCCode_By_Department", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PCCode_Data", "get_PCCode_By_Department", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PCCode_Data", "get_PCCode_By_Department", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        public static List<ReturPCCodeModelHead> get_PCCode_single(GetPCCodeSingleModel item)
        {
            List<ReturPCCodeModelHead> objHeadList = new List<ReturPCCodeModelHead>();
            List<ReturnPCCodeModel> objList = new List<ReturnPCCodeModel>();
            ReturPCCodeModelHead objHead = new ReturPCCodeModelHead();

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

                        cmd.CommandText = "sp_get_PCCode_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PCC_ID", item.PCC_ID);
                        cmd.Parameters["@PCC_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnPCCodeModel objData = new ReturnPCCodeModel();


                                objHead.resp = true;
                                objHead.msg = "PCCode";

                                objData.PCC_ID = rdr["PCC_ID"].ToString();
                               // objData.PCC_Name = rdr["PCC_Name"].ToString();
                                //objData.PCC_Description = rdr["PCC_Description"].ToString();
                                objData.PCC_Status = rdr["PCC_Status"].ToString();
                                objData.RC = "1";

                                objList.Add(objData);

                                if (objHead.PCCode == null)
                                {
                                    objHead.PCCode = new List<ReturnPCCodeModel>();
                                }

                                objHead.PCCode.Add(objData);

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
                 objHead = new ReturPCCodeModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objHead);

                objError.WriteLog(0, "PCCode_Data", "get_PCCode_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "PCCode_Data", "get_PCCode_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "PCCode_Data", "get_PCCode_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "PCCode_Data", "get_PCCode_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }



    }








}








