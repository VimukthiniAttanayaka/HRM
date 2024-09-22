﻿using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using Newtonsoft.Json;

namespace HRM_DAL.Data
{
    public class Branch_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnBranchModelHead> get_Branchs_single(Branch model)//ok
        {
            List<ReturnBranchModelHead> objBranchHeadList = new List<ReturnBranchModelHead>();
            ReturnBranchModelHead objBranchHead = new ReturnBranchModelHead();

            if (objBranchHead.Branch == null)
            {
                objBranchHead.Branch = new List<ReturnBranchModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objBranchHead.resp = false;
                objBranchHead.IsAuthenticated = false;
                objBranchHeadList.Add(objBranchHead);
                return objBranchHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_Branchs_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MDB_BranchID", model.MDB_BranchID);
                        cmd.Parameters["@MDB_BranchID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnBranchModel objBranch = new ReturnBranchModel();

                                objBranchHead.resp = true;
                                objBranchHead.msg = "Get Branch";

                                objBranch.MDB_BranchID = rdr["MDB_BranchID"].ToString();
                                
                                objBranch.MDB_Branch = rdr["MDB_Branch"].ToString();
                                objBranch.MDB_Status = Convert.ToBoolean(rdr["MDB_Status"].ToString());


                                objBranchHead.Branch.Add(objBranch);

                                objBranchHeadList.Add(objBranchHead);
                            }

                        }
                        else
                        {
                            ReturnBranchModel objBranch = new ReturnBranchModel();
                            objBranchHead.resp = true;
                            objBranchHead.msg = "";
                            objBranchHeadList.Add(objBranchHead);


                        }


                    }
                    return objBranchHeadList;

                }
            }
            catch (Exception ex)
            {
                objBranchHead = new ReturnBranchModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objBranchHeadList.Add(objBranchHead);

                objError.WriteLog(0, "Branch_Data", "get_Branchs_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Branch_Data", "get_Branchs_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Branch_Data", "get_Branchs_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Branch_Data", "get_Branchs_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objBranchHeadList;

        }

        public static List<ReturnBranchModelHead> get_Branch_all(BranchSearchModel model)//ok
        {
            List<ReturnBranchModelHead> objBranchHeadList = new List<ReturnBranchModelHead>();
            ReturnBranchModelHead objBranchHead = new ReturnBranchModelHead();

            if (objBranchHead.Branch == null)
            {
                objBranchHead.Branch = new List<ReturnBranchModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objBranchHead.resp = false;
                objBranchHead.IsAuthenticated = false;
                objBranchHeadList.Add(objBranchHead);
                return objBranchHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_Branch_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@MDB_BranchID", model.MDB_BranchID);
                        //cmd.Parameters["@MDB_BranchID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnBranchModel objBranch = new ReturnBranchModel();

                                objBranchHead.resp = true;
                                objBranchHead.msg = "Get Branch";

                                objBranch.MDB_BranchID = rdr["MDB_BranchID"].ToString();                                
                                objBranch.MDB_Branch = rdr["MDB_Branch"].ToString();
                                objBranch.MDB_Status = Convert.ToBoolean(rdr["MDB_Status"].ToString());

                                objBranchHead.Branch.Add(objBranch);

                                objBranchHeadList.Add(objBranchHead);
                            }

                        }
                        else
                        {
                            ReturnBranchModel objBranch = new ReturnBranchModel();
                            objBranchHead.resp = true;
                            objBranchHead.msg = "";
                            objBranchHeadList.Add(objBranchHead);


                        }


                    }
                    return objBranchHeadList;

                }
            }
            catch (Exception ex)
            {
                objBranchHead = new ReturnBranchModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objBranchHeadList.Add(objBranchHead);

                objError.WriteLog(0, "Branch_Data", "get_Branch_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Branch_Data", "get_Branch_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Branch_Data", "get_Branch_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Branch_Data", "get_Branch_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objBranchHeadList;

        }

        public static List<ReturnResponse> add_new_Branch(BranchModel item)//ok
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


                        cmd.CommandText = "sp_insert_Branch";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDB_BranchID", item.MDB_BranchID);
                        cmd.Parameters["@MDB_BranchID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDB_Branch", item.MDB_Branch);
                        cmd.Parameters["@MDB_Branch"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDB_Status", item.MDB_Status);
                        cmd.Parameters["@MDB_Status"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "Branch_Data", "add_new_Branch", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Branch_Data", "add_new_Branch", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Branch_Data", "add_new_Branch", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Branch_Data", "add_new_Branch", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> modify_Branch(BranchModel item)//ok
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


                        cmd.CommandText = "sp_modify_Branch";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDB_BranchID", item.MDB_BranchID);
                        cmd.Parameters["@MDB_BranchID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDB_Branch", item.MDB_Branch);
                        cmd.Parameters["@MDB_Branch"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@MDB_Status", item.MDB_Status);
                        cmd.Parameters["@MDB_Status"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "Branch_Data", "add_new_Branch", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Branch_Data", "add_new_Branch", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Branch_Data", "add_new_Branch", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Branch_Data", "add_new_Branch", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_Branch(InactiveMDBModel item)//ok
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



                        cmd.CommandText = "sp_del_Branch";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MDB_BranchID", item.MDB_BranchID);
                        cmd.Parameters["@MDB_BranchID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "Branch_Data", "inactivate_Branch", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "Branch_Data", "inactivate_Branch", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "Branch_Data", "inactivate_Branch", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "Branch_Data", "inactivate_Branch", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

