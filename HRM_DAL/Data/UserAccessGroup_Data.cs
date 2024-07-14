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
    public class UserAccessGroup_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnUAGAllModelHead> get_t_user_access_group_all(GetUAGAllModel Userall)//ok
        {
            List<ReturnUAGAllModelHead> objHeadList = new List<ReturnUAGAllModelHead>();
            ReturnUAGAllModelHead objUserHead = new ReturnUAGAllModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(Userall) == false)
            {
                objUserHead.resp = false;
                objUserHead.IsAuthenticated = false;
                objHeadList.Add(objUserHead);
                return objHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        lconn.Open();
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_mtt_user_access_group_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", Userall.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", Userall.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UT_StaffID", Userall.UT_StaffID);
                        cmd.Parameters["@UT_StaffID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UT_FirstName", Userall.UT_FirstName);
                        cmd.Parameters["@UT_FirstName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UT_LastName", Userall.UT_LastName);
                        cmd.Parameters["@UT_LastName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UGM_Name", Userall.UGM_Name);
                        cmd.Parameters["@UGM_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_CompanyName", Userall.BU_CompanyName);
                        cmd.Parameters["@BU_CompanyName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@CUS_CompanyName", Userall.CUS_CompanyName);
                        cmd.Parameters["@CUS_CompanyName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_Status", Userall.UAG_Status);
                        cmd.Parameters["@UAG_Status"].Direction = ParameterDirection.Input;

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_transnational_user_count";
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
                                ReturnUAGModel objData = new ReturnUAGModel();


                                objUserHead.resp = true;
                                objUserHead.msg = "Get User";

                                objData.UT_StaffID = rdr["UT_StaffID"].ToString();
                                objData.UT_FirstName = rdr["UT_FirstName"].ToString();
                                objData.UT_LastName = rdr["UT_LastName"].ToString();
                                objData.UGM_Name = rdr["UGM_Name"].ToString();
                                objData.BU_CompanyName = rdr["BU_CompanyName"].ToString();
                                objData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objData.UAG_Status = rdr["UAG_Status"].ToString();
                                objData.UAG_GroupID = rdr["UAG_GroupID"].ToString();
                                objData.UAG_BusinessUnit = rdr["UAG_BusinessUnit"].ToString();
                                objData.UAG_CustomerID = rdr["UAG_CustomerID"].ToString();
                                objData.UAG_VendorID = rdr["UAG_VendorID"].ToString();
                                objData.RC = RC;

                                if (objUserHead.User == null)
                                {
                                    objUserHead.User = new List<ReturnUAGModel>();
                                }

                                objUserHead.User.Add(objData);
                            }

                            objHeadList.Add(objUserHead);

                        }
                        else
                        {
                            objUserHead.resp = true;
                            objUserHead.msg = "";
                            objHeadList.Add(objUserHead);

                        }
                    }
                    lconn.Close();
                }

                return objHeadList;

            }
            catch (Exception ex)
            {

                objUserHead = new ReturnUAGAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objUserHead);

                objError.WriteLog(0, "UserAccessGroup_Data", "get_t_user_access_group_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserAccessGroup_Data", "get_t_user_access_group_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserAccessGroup_Data", "get_t_user_access_group_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserAccessGroup_Data", "get_t_user_access_group_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        //public static List<ReturnResponse> modify_t_user_access_group(UAGModel item)
        //{
        //    List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
        //    ReturnResponse objUserHead = new ReturnResponse();
        //    SqlTransaction trans = null;

        //    if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
        //    {
        //        objUserHead.resp = false;
        //        objUserHead.IsAuthenticated = false;
        //        objUserHeadList.Add(objUserHead);
        //        return objUserHeadList;
        //    }

        //    try
        //    {
        //        using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
        //        {
        //            lconn.Open();
        //            trans = lconn.BeginTransaction();

        //            foreach (var itemGr in item.ExistingUAG)
        //            {
        //                foreach (var itemKio in item.KioskAG)
        //                {
        //                    using (SqlCommand cmdud = new SqlCommand())
        //                    {
        //                        cmdud.Connection = lconn;
        //                        cmdud.Transaction = trans;

        //                        cmdud.CommandText = "sp_sav_user_access_group";
        //                        cmdud.CommandType = CommandType.StoredProcedure;

        //                        cmdud.Parameters.AddWithValue("@USER_ID", item.USER_ID);
        //                        cmdud.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_UserID", itemGr.UAG_UserID);
        //                        cmdud.Parameters["@UAG_UserID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_GroupID", itemKio.UAG_GroupID);
        //                        cmdud.Parameters["@UAG_GroupID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_BusinessUnit", itemGr.UAG_BusinessUnit);
        //                        cmdud.Parameters["@UAG_BusinessUnit"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_CustomerID", itemGr.UAG_CustomerID);
        //                        cmdud.Parameters["@UAG_CustomerID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_VendorID", itemKio.UAG_VendorID);
        //                        cmdud.Parameters["@UAG_VendorID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_Type", itemGr.UAG_Type/* "MT"*/);
        //                        cmdud.Parameters["@UAG_Type"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_Status", itemGr.UAG_Status);
        //                        cmdud.Parameters["@UAG_Status"].Direction = ParameterDirection.Input;

        //                        SqlDataAdapter dta = new SqlDataAdapter(cmdud);
        //                        DataSet Ds = new DataSet();
        //                        dta.Fill(Ds);

        //                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        //                        {
        //                            foreach (DataRow rdr in Ds.Tables[0].Rows)
        //                            {
        //                                objUserHeadList.Add(new ReturnResponse { resp = Boolean.Parse(rdr["RTN_RESP"].ToString()), msg = rdr["RTN_MSG"].ToString() });
        //                            }
        //                        }
        //                        else
        //                        {
        //                            objUserHeadList.Add(new ReturnResponse { resp = true, msg = "" });
        //                        }

        //                        cmdud.Parameters.Clear();
        //                    }
        //                }
        //            }

        //            trans.Commit();
        //            trans.Dispose();

        //            objUserHead = new ReturnResponse
        //            {
        //                resp = true,
        //                msg = ""
        //            };

        //            objUserHeadList.Add(objUserHead);
        //            objUserHeadList.AddRange(User_Data.sync_t_user_kioski(new User() { USER_ID = item.UT_StaffID }));

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (trans != null)
        //        {
        //            trans.Rollback();
        //            trans.Dispose();
        //        }

        //        objUserHead = new ReturnResponse
        //        {
        //            resp = false,
        //            msg = ex.Message.ToString()
        //        };
        //        objUserHeadList.Add(objUserHead);

        //        objError.WriteLog(0, "UserAccessGroup_Data", "modify_t_user_access_group", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "UserAccessGroup_Data", "modify_t_user_access_group", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "UserAccessGroup_Data", "modify_t_user_access_group", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "UserAccessGroup_Data", "modify_t_user_access_group", "Inner Exception Message: " + ex.InnerException.Message);
        //        }

        //    }
        //    return objUserHeadList;
        //}

        //[Obsolete]
        //public static List<ReturnResponse> modify_c_user_access_group(UAGModel item)
        //{
        //    List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
        //    ReturnResponse objUserHead = new ReturnResponse();
        //    SqlTransaction trans = null;

        //    if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
        //    {
        //        objUserHead.resp = false;
        //        objUserHead.IsAuthenticated = false;
        //        objUserHeadList.Add(objUserHead);
        //        return objUserHeadList;
        //    }

        //    try
        //    {
        //        using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
        //        {
        //            lconn.Open();
        //            trans = lconn.BeginTransaction();

        //            foreach (var itemGr in item.ExistingUAG)
        //            {
        //                foreach (var itemKio in item.KioskAG)
        //                {
        //                    using (SqlCommand cmdud = new SqlCommand())
        //                    {
        //                        cmdud.Connection = lconn;
        //                        cmdud.Transaction = trans;

        //                        cmdud.CommandText = "sp_sav_customer_user_access_group";
        //                        cmdud.CommandType = CommandType.StoredProcedure;

        //                        cmdud.Parameters.AddWithValue("@USER_ID", item.USER_ID);
        //                        cmdud.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_UserID", itemGr.UAG_UserID);
        //                        cmdud.Parameters["@UAG_UserID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_GroupID", itemKio.UAG_GroupID);
        //                        cmdud.Parameters["@UAG_GroupID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_CustomerID", itemGr.UAG_CustomerID);
        //                        cmdud.Parameters["@UAG_CustomerID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_Status", itemGr.UAG_Status);
        //                        cmdud.Parameters["@UAG_Status"].Direction = ParameterDirection.Input;

        //                        ////cmdud.Parameters.AddWithValue("@UAG_VendorID", item.UAG_VendorID);
        //                        ////cmdud.Parameters["@UAG_VendorID"].Direction = ParameterDirection.Input;

        //                        ////cmdud.Parameters.AddWithValue("@UAG_Type", "MC");
        //                        ////cmdud.Parameters["@UAG_Type"].Direction = ParameterDirection.Input;

        //                        ////cmdud.Parameters.AddWithValue("@TABLE", item.TABLE);
        //                        ////cmdud.Parameters["@TABLE"].Direction = ParameterDirection.Input;


        //                        SqlDataAdapter dta = new SqlDataAdapter(cmdud);
        //                        DataSet Ds = new DataSet();
        //                        dta.Fill(Ds);

        //                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        //                        {
        //                            foreach (DataRow rdr in Ds.Tables[0].Rows)
        //                            {
        //                                objUserHeadList.Add(new ReturnResponse { resp = Boolean.Parse(rdr["RTN_RESP"].ToString()), msg = rdr["RTN_MSG"].ToString() });
        //                            }
        //                        }
        //                        else
        //                        {
        //                            objUserHeadList.Add(new ReturnResponse { resp = true, msg = "" });
        //                        }

        //                        cmdud.Parameters.Clear();
        //                    }
        //                }
        //            }

        //            trans.Commit();
        //            trans.Dispose();

        //            objUserHead = new ReturnResponse
        //            {
        //                resp = true,
        //                msg = ""
        //            };
        //            objUserHeadList.AddRange(User_Data.sync_c_user_kioski(new CUser() { USER_ID = item.UT_StaffID }));
        //            objUserHeadList.Add(objUserHead);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (trans != null)
        //        {
        //            trans.Rollback();
        //            trans.Dispose();
        //        }
        //        objUserHead = new ReturnResponse
        //        {
        //            resp = false,
        //            msg = ex.Message.ToString()
        //        };
        //        objUserHeadList.Add(objUserHead);

        //        objError.WriteLog(0, "UserAccessGroup_Data", "modify_c_user_access_group", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "UserAccessGroup_Data", "modify_c_user_access_group", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "UserAccessGroup_Data", "modify_c_user_access_group", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "UserAccessGroup_Data", "modify_c_user_access_group", "Inner Exception Message: " + ex.InnerException.Message);
        //        }

        //    }
        //    return objUserHeadList;
        //}

        public static List<ReturnUAGUsrAllModelHead> get_c_user_access_group_single(GetUAGSingleModel Userall)
        {
            List<ReturnUAGUsrAllModelHead> objHeadList = new List<ReturnUAGUsrAllModelHead>();
            ReturnUAGUsrAllModelHead objUserHead = new ReturnUAGUsrAllModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(Userall) == false)
            {
                objUserHead.resp = false;
                objUserHead.IsAuthenticated = false;
                objHeadList.Add(objUserHead);
                return objHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {                    
                        lconn.Open();
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_mtc_user_access_group_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UAG_UserID", Userall.UAG_UserID);
                        cmd.Parameters["@UAG_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_GroupID", Userall.UAG_GroupID);
                        cmd.Parameters["@UAG_GroupID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_BusinessUnit", Userall.UAG_BusinessUnit);
                        cmd.Parameters["@UAG_BusinessUnit"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_CustomerID", Userall.UAG_CustomerID);
                        cmd.Parameters["@UAG_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TABLE", Userall.TABLE);
                        cmd.Parameters["@TABLE"].Direction = ParameterDirection.Input;


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnUAGUsrModel objData = new ReturnUAGUsrModel();


                                objUserHead.resp = true;
                                objUserHead.msg = "Get User";

                                objData.USR_StaffID = rdr["USR_StaffID"].ToString();
                                objData.USR_FirstName = rdr["USR_FirstName"].ToString();
                                objData.USR_LastName = rdr["USR_LastName"].ToString();
                                objData.UGM_Name = rdr["UGM_Name"].ToString();
                                objData.BU_CompanyName = rdr["BU_CompanyName"].ToString();
                                objData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objData.UAG_Status = rdr["UAG_Status"].ToString();
                                objData.UAG_GroupID = rdr["UAG_GroupID"].ToString();
                                objData.UAG_BusinessUnit = rdr["UAG_BusinessUnit"].ToString();
                                objData.UAG_CustomerID = rdr["UAG_CustomerID"].ToString();
                                objData.UAG_VendorID = rdr["UAG_VendorID"].ToString();
                                objData.RC = "1";

                                if (objUserHead.User == null)
                                {
                                    objUserHead.User = new List<ReturnUAGUsrModel>();
                                }

                                objUserHead.User.Add(objData);
                            }

                            objHeadList.Add(objUserHead);

                        }
                        else
                        {
                            objUserHead.resp = true;
                            objUserHead.msg = "";
                            objHeadList.Add(objUserHead);

                        }
                    }
                    lconn.Close();
                }

                return objHeadList;

            }
            catch (Exception ex)
            {

                objUserHead = new ReturnUAGUsrAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objUserHead);

                objError.WriteLog(0, "UserAccessGroup_Data", "get_c_user_access_group_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserAccessGroup_Data", "get_c_user_access_group_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserAccessGroup_Data", "get_c_user_access_group_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserAccessGroup_Data", "get_c_user_access_group_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        public static List<ReturnUAGAllModelHead> get_t_user_access_group_single(GetUAGSingleModel Userall)
        {
            List<ReturnUAGAllModelHead> objHeadList = new List<ReturnUAGAllModelHead>();
            ReturnUAGAllModelHead objUserHead = new ReturnUAGAllModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(Userall) == false)
            {
                objUserHead.resp = false;
                objUserHead.IsAuthenticated = false;
                objHeadList.Add(objUserHead);
                return objHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        lconn.Open();
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_mtt_user_access_group_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UAG_UserID", Userall.UAG_UserID);
                        cmd.Parameters["@UAG_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_GroupID", Userall.UAG_GroupID);
                        cmd.Parameters["@UAG_GroupID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_BusinessUnit", Userall.UAG_BusinessUnit);
                        cmd.Parameters["@UAG_BusinessUnit"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_CustomerID", Userall.UAG_CustomerID);
                        cmd.Parameters["@UAG_CustomerID"].Direction = ParameterDirection.Input;


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnUAGModel objData = new ReturnUAGModel();


                                objUserHead.resp = true;
                                objUserHead.msg = "Get User";

                                objData.UT_StaffID = rdr["UT_StaffID"].ToString();
                                objData.UT_FirstName = rdr["UT_FirstName"].ToString();
                                objData.UT_LastName = rdr["UT_LastName"].ToString();
                                objData.UGM_Name = rdr["UGM_Name"].ToString();
                                objData.BU_CompanyName = rdr["BU_CompanyName"].ToString();
                                objData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objData.UAG_Status = rdr["UAG_Status"].ToString();
                                objData.UAG_GroupID = rdr["UAG_GroupID"].ToString();
                                objData.UAG_BusinessUnit = rdr["UAG_BusinessUnit"].ToString();
                                objData.UAG_CustomerID = rdr["UAG_CustomerID"].ToString();
                                objData.UAG_VendorID = rdr["UAG_VendorID"].ToString();
                                objData.RC = "1";

                                if (objUserHead.User == null)
                                {
                                    objUserHead.User = new List<ReturnUAGModel>();
                                }

                                objUserHead.User.Add(objData);
                            }

                            objHeadList.Add(objUserHead);

                        }
                        else
                        {
                            objUserHead.resp = true;
                            objUserHead.msg = "";
                            objHeadList.Add(objUserHead);

                        }
                    }
                    lconn.Close();
                }

                return objHeadList;

            }
            catch (Exception ex)
            {

                objUserHead = new ReturnUAGAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objUserHead);

                objError.WriteLog(0, "UserAccessGroup_Data", "get_t_user_access_group_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserAccessGroup_Data", "get_t_user_access_group_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserAccessGroup_Data", "get_t_user_access_group_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserAccessGroup_Data", "get_t_user_access_group_single", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        public static List<ReturnUAGUsrAllModelHead> get_c_user_access_group_multiple(GetUAGSingleModel Userall)
        {
            List<ReturnUAGUsrAllModelHead> objHeadList = new List<ReturnUAGUsrAllModelHead>();
            ReturnUAGUsrAllModelHead objUserHead = new ReturnUAGUsrAllModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(Userall) == false)
            {
                objUserHead.resp = false;
                objUserHead.IsAuthenticated = false;
                objHeadList.Add(objUserHead);
                return objHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {                    
                        lconn.Open();
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_mtc_user_access_group_multiple";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UAG_UserID", Userall.UAG_UserID);
                        cmd.Parameters["@UAG_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_GroupID", Userall.UAG_GroupID);
                        cmd.Parameters["@UAG_GroupID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_BusinessUnit", Userall.UAG_BusinessUnit);
                        cmd.Parameters["@UAG_BusinessUnit"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_CustomerID", Userall.UAG_CustomerID);
                        cmd.Parameters["@UAG_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TABLE", Userall.TABLE);
                        cmd.Parameters["@TABLE"].Direction = ParameterDirection.Input;


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnUAGUsrModel objData = new ReturnUAGUsrModel();


                                objUserHead.resp = true;
                                objUserHead.msg = "Get User";

                                objData.USR_StaffID = rdr["USR_StaffID"].ToString();
                                objData.USR_FirstName = rdr["USR_FirstName"].ToString();
                                objData.USR_LastName = rdr["USR_LastName"].ToString();
                                objData.UGM_Name = rdr["UGM_Name"].ToString();
                                objData.BU_CompanyName = rdr["BU_CompanyName"].ToString();
                                objData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objData.UAG_Status = rdr["UAG_Status"].ToString();
                                objData.UAG_GroupID = rdr["UAG_GroupID"].ToString();
                                objData.UAG_BusinessUnit = rdr["UAG_BusinessUnit"].ToString();
                                objData.UAG_CustomerID = rdr["UAG_CustomerID"].ToString();
                                objData.UAG_VendorID = rdr["UAG_VendorID"].ToString();
                                objData.RC = "1";

                                if (objUserHead.User == null)
                                {
                                    objUserHead.User = new List<ReturnUAGUsrModel>();
                                }

                                objUserHead.User.Add(objData);
                            }

                            objHeadList.Add(objUserHead);

                        }
                        else
                        {
                            objUserHead.resp = true;
                            objUserHead.msg = "";
                            objHeadList.Add(objUserHead);

                        }
                    }
                    lconn.Close();
                }

                return objHeadList;

            }
            catch (Exception ex)
            {

                objUserHead = new ReturnUAGUsrAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objUserHead);

                objError.WriteLog(0, "UserAccessGroup_Data", "get_c_user_access_group_multiple", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserAccessGroup_Data", "get_c_user_access_group_multiple", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserAccessGroup_Data", "get_c_user_access_group_multiple", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserAccessGroup_Data", "get_c_user_access_group_multiple", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        public static List<ReturnUAGAllModelHead> get_t_user_access_group_multiple(GetUAGSingleModel Userall)
        {
            List<ReturnUAGAllModelHead> objHeadList = new List<ReturnUAGAllModelHead>();
            ReturnUAGAllModelHead objUserHead = new ReturnUAGAllModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(Userall) == false)
            {
                objUserHead.resp = false;
                objUserHead.IsAuthenticated = false;
                objHeadList.Add(objUserHead);
                return objHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        lconn.Open();
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_mtt_user_access_group_multiple";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UAG_UserID", Userall.UAG_UserID);
                        cmd.Parameters["@UAG_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_GroupID", Userall.UAG_GroupID);
                        cmd.Parameters["@UAG_GroupID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_BusinessUnit", Userall.UAG_BusinessUnit);
                        cmd.Parameters["@UAG_BusinessUnit"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_CustomerID", Userall.UAG_CustomerID);
                        cmd.Parameters["@UAG_CustomerID"].Direction = ParameterDirection.Input;


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnUAGModel objData = new ReturnUAGModel();


                                objUserHead.resp = true;
                                objUserHead.msg = "Get User";

                                objData.UT_StaffID = rdr["UT_StaffID"].ToString();
                                objData.UT_FirstName = rdr["UT_FirstName"].ToString();
                                objData.UT_LastName = rdr["UT_LastName"].ToString();
                                objData.UGM_Name = rdr["UGM_Name"].ToString();
                                objData.BU_CompanyName = rdr["BU_CompanyName"].ToString();
                                objData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objData.UAG_Status = rdr["UAG_Status"].ToString();
                                objData.UAG_GroupID = rdr["UAG_GroupID"].ToString();
                                objData.UAG_BusinessUnit = rdr["UAG_BusinessUnit"].ToString();
                                objData.UAG_CustomerID = rdr["UAG_CustomerID"].ToString();
                                objData.UAG_VendorID = rdr["UAG_VendorID"].ToString();
                                objData.RC = "1";

                                if (objUserHead.User == null)
                                {
                                    objUserHead.User = new List<ReturnUAGModel>();
                                }

                                objUserHead.User.Add(objData);
                            }

                            objHeadList.Add(objUserHead);

                        }
                        else
                        {
                            objUserHead.resp = true;
                            objUserHead.msg = "";
                            objHeadList.Add(objUserHead);

                        }
                    }
                    lconn.Close();
                }

                return objHeadList;

            }
            catch (Exception ex)
            {

                objUserHead = new ReturnUAGAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objUserHead);

                objError.WriteLog(0, "UserAccessGroup_Data", "get_t_user_access_group_multiple", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserAccessGroup_Data", "get_t_user_access_group_multiple", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserAccessGroup_Data", "get_t_user_access_group_multiple", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserAccessGroup_Data", "get_t_user_access_group_multiple", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        public static List<ReturnUAGUsrAllModelHead> get_customer_user_access_group_multiple(GetUAGSingleModel Userall)
        {
            List<ReturnUAGUsrAllModelHead> objHeadList = new List<ReturnUAGUsrAllModelHead>();
            ReturnUAGUsrAllModelHead objUserHead = new ReturnUAGUsrAllModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(Userall) == false)
            {
                objUserHead.resp = false;
                objUserHead.IsAuthenticated = false;
                objHeadList.Add(objUserHead);
                return objHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        lconn.Open();
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_customer_user_access_group_multiple";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UAG_UserID", Userall.UAG_UserID);
                        cmd.Parameters["@UAG_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_GroupID", Userall.UAG_GroupID);
                        cmd.Parameters["@UAG_GroupID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_BusinessUnit", Userall.UAG_BusinessUnit);
                        cmd.Parameters["@UAG_BusinessUnit"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_CustomerID", Userall.UAG_CustomerID);
                        cmd.Parameters["@UAG_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_Type", Userall.UAG_Type);
                        cmd.Parameters["@UAG_Type"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TABLE", Userall.TABLE);
                        cmd.Parameters["@TABLE"].Direction = ParameterDirection.Input;


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnUAGUsrModel objData = new ReturnUAGUsrModel();


                                objUserHead.resp = true;
                                objUserHead.msg = "Get User";

                                objData.USR_StaffID = rdr["USR_StaffID"].ToString();
                                objData.USR_FirstName = rdr["USR_FirstName"].ToString();
                                objData.USR_LastName = rdr["USR_LastName"].ToString();
                                objData.UGM_Name = rdr["UGM_Name"].ToString();
                                objData.BU_CompanyName = rdr["BU_CompanyName"].ToString();
                                objData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objData.UAG_Status = rdr["UAG_Status"].ToString();
                                objData.UAG_GroupID = rdr["UAG_GroupID"].ToString();
                                objData.UAG_BusinessUnit = rdr["UAG_BusinessUnit"].ToString();
                                objData.UAG_CustomerID = rdr["UAG_CustomerID"].ToString();
                                objData.UAG_VendorID = rdr["UAG_VendorID"].ToString();
                                objData.RC = "1";

                                if (objUserHead.User == null)
                                {
                                    objUserHead.User = new List<ReturnUAGUsrModel>();
                                }

                                objUserHead.User.Add(objData);
                            }

                            objHeadList.Add(objUserHead);

                        }
                        else
                        {
                            objUserHead.resp = true;
                            objUserHead.msg = "";
                            objHeadList.Add(objUserHead);

                        }
                    }
                    lconn.Close();
                }

                return objHeadList;

            }
            catch (Exception ex)
            {

                objUserHead = new ReturnUAGUsrAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objUserHead);

                objError.WriteLog(0, "UserAccessGroup_Data", "get_customer_user_access_group_multiple", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserAccessGroup_Data", "get_customer_user_access_group_multiple", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserAccessGroup_Data", "get_customer_user_access_group_multiple", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserAccessGroup_Data", "get_customer_user_access_group_multiple", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        public static List<ReturnUAGAllModelHead> get_transnational_user_access_group_multiple(GetUAGSingleModel Userall)
        {
            List<ReturnUAGAllModelHead> objHeadList = new List<ReturnUAGAllModelHead>();
            ReturnUAGAllModelHead objUserHead = new ReturnUAGAllModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(Userall) == false)
            {
                objUserHead.resp = false;
                objUserHead.IsAuthenticated = false;
                objHeadList.Add(objUserHead);
                return objHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        lconn.Open();
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_transnational_user_access_group_multiple";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UAG_UserID", Userall.UAG_UserID);
                        cmd.Parameters["@UAG_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_GroupID", Userall.UAG_GroupID);
                        cmd.Parameters["@UAG_GroupID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_BusinessUnit", Userall.UAG_BusinessUnit);
                        cmd.Parameters["@UAG_BusinessUnit"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_CustomerID", Userall.UAG_CustomerID);
                        cmd.Parameters["@UAG_CustomerID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_Type", Userall.UAG_Type);
                        cmd.Parameters["@UAG_Type"].Direction = ParameterDirection.Input;


                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnUAGModel objData = new ReturnUAGModel();


                                objUserHead.resp = true;
                                objUserHead.msg = "Get User";

                                objData.UT_StaffID = rdr["UT_StaffID"].ToString();
                                objData.UT_FirstName = rdr["UT_FirstName"].ToString();
                                objData.UT_LastName = rdr["UT_LastName"].ToString();
                                objData.UGM_Name = rdr["UGM_Name"].ToString();
                                objData.BU_CompanyName = rdr["BU_CompanyName"].ToString();
                                objData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objData.UAG_Status = rdr["UAG_Status"].ToString();
                                objData.UAG_GroupID = rdr["UAG_GroupID"].ToString();
                                objData.UAG_BusinessUnit = rdr["UAG_BusinessUnit"].ToString();
                                objData.UAG_CustomerID = rdr["UAG_CustomerID"].ToString();
                                objData.UAG_VendorID = rdr["UAG_VendorID"].ToString();
                                objData.RC = "1";

                                if (objUserHead.User == null)
                                {
                                    objUserHead.User = new List<ReturnUAGModel>();
                                }

                                objUserHead.User.Add(objData);
                            }

                            objHeadList.Add(objUserHead);

                        }
                        else
                        {
                            objUserHead.resp = true;
                            objUserHead.msg = "";
                            objHeadList.Add(objUserHead);

                        }
                    }
                    lconn.Close();
                }

                return objHeadList;

            }
            catch (Exception ex)
            {

                objUserHead = new ReturnUAGAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objUserHead);

                objError.WriteLog(0, "UserAccessGroup_Data", "get_transnational_user_access_group_multiple", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserAccessGroup_Data", "get_transnational_user_access_group_multiple", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserAccessGroup_Data", "get_transnational_user_access_group_multiple", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserAccessGroup_Data", "get_transnational_user_access_group_multiple", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        //[Obsolete]
        //public static List<ReturnResponse> add_new_t_user_access_group(UAGModel item)//ok
        //{
        //    List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
        //    ReturnResponse objUserHead = new ReturnResponse();
        //    SqlTransaction trans = null;

        //    if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
        //    {
        //        objUserHead.resp = false;
        //        objUserHead.IsAuthenticated = false;
        //        objUserHeadList.Add(objUserHead);
        //        return objUserHeadList;
        //    }

        //    try
        //    {
        //        using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
        //        {
        //            lconn.Open();
        //            trans = lconn.BeginTransaction();

        //            foreach (var itemGr in item.ExistingUAG)
        //            {
        //                foreach (var itemKio in item.KioskAG)
        //                {
        //                    using (SqlCommand cmdud = new SqlCommand())
        //                    {
        //                        cmdud.Connection = lconn;
        //                        cmdud.Transaction = trans;

        //                        cmdud.CommandText = "sp_sav_user_access_group";
        //                        cmdud.CommandType = CommandType.StoredProcedure;

        //                        cmdud.Parameters.AddWithValue("@USER_ID", item.USER_ID);
        //                        cmdud.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_UserID", itemGr.UAG_UserID);
        //                        cmdud.Parameters["@UAG_UserID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_GroupID", itemKio.UAG_GroupID);
        //                        cmdud.Parameters["@UAG_GroupID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_BusinessUnit", itemGr.UAG_BusinessUnit);
        //                        cmdud.Parameters["@UAG_BusinessUnit"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_CustomerID", itemGr.UAG_CustomerID);
        //                        cmdud.Parameters["@UAG_CustomerID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_VendorID", itemKio.UAG_VendorID);
        //                        cmdud.Parameters["@UAG_VendorID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_Type", "MT");
        //                        cmdud.Parameters["@UAG_Type"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_Status", true);
        //                        cmdud.Parameters["@UAG_Status"].Direction = ParameterDirection.Input;

        //                        SqlDataAdapter dta = new SqlDataAdapter(cmdud);
        //                        DataSet Ds = new DataSet();
        //                        dta.Fill(Ds);

        //                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        //                        {
        //                            foreach (DataRow rdr in Ds.Tables[0].Rows)
        //                            {
        //                                objUserHeadList.Add(new ReturnResponse { resp = Boolean.Parse(rdr["RTN_RESP"].ToString()), msg = rdr["RTN_MSG"].ToString() });
        //                            }
        //                        }
        //                        else
        //                        {
        //                            objUserHeadList.Add(new ReturnResponse { resp = true, msg = "" });
        //                        }

        //                        cmdud.Parameters.Clear();
        //                    }
        //                }
        //            }
        //            trans.Commit();
        //            trans.Dispose();

        //            objUserHead = new ReturnResponse
        //            {
        //                resp = true,
        //                msg = ""
        //            };

        //            objUserHeadList.Add(objUserHead);
        //            objUserHeadList.AddRange(User_Data.sync_t_user_kioski(new User() { USER_ID = item.UT_StaffID }));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (trans != null)
        //        {
        //            trans.Rollback();
        //            trans.Dispose();
        //        }
        //        objUserHead = new ReturnResponse
        //        {
        //            resp = false,
        //            msg = ex.Message.ToString()
        //        };
        //        objUserHeadList.Add(objUserHead);

        //        objError.WriteLog(0, "UserAccessGroup_Data", "add_new_t_user_access_group", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "UserAccessGroup_Data", "add_new_t_user_access_group", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "UserAccessGroup_Data", "add_new_t_user_access_group", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "UserAccessGroup_Data", "add_new_t_user_access_group", "Inner Exception Message: " + ex.InnerException.Message);
        //        }

        //    }
        //    return objUserHeadList;
        //}

        //[Obsolete]
        //public static List<ReturnResponse> inactivate_t_user_access_group(UAGModel item)//ok
        //{
        //    List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
        //    ReturnResponse objUserHead = new ReturnResponse();
        //    SqlTransaction trans = null;

        //    if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
        //    {
        //        objUserHead.resp = false;
        //        objUserHead.IsAuthenticated = false;
        //        objUserHeadList.Add(objUserHead);
        //        return objUserHeadList;
        //    }

        //    try
        //    {
        //        using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
        //        {
        //            lconn.Open();
        //            trans = lconn.BeginTransaction();

        //            foreach (var itemGr in item.ExistingUAG)
        //            {
        //                foreach (var itemKio in item.KioskAG)
        //                {
        //                    using (SqlCommand cmdud = new SqlCommand())
        //                    {
        //                        cmdud.Connection = lconn;
        //                        cmdud.Transaction = trans;

        //                        cmdud.CommandText = "sp_sav_user_access_group";
        //                        cmdud.CommandType = CommandType.StoredProcedure;

        //                        cmdud.Parameters.AddWithValue("@USER_ID", item.USER_ID);
        //                        cmdud.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_UserID", itemGr.UAG_UserID);
        //                        cmdud.Parameters["@UAG_UserID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_GroupID", itemKio.UAG_GroupID);
        //                        cmdud.Parameters["@UAG_GroupID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_BusinessUnit", itemGr.UAG_BusinessUnit);
        //                        cmdud.Parameters["@UAG_BusinessUnit"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_CustomerID", itemGr.UAG_CustomerID);
        //                        cmdud.Parameters["@UAG_CustomerID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_VendorID", itemKio.UAG_VendorID);
        //                        cmdud.Parameters["@UAG_VendorID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_Type", "MT");
        //                        cmdud.Parameters["@UAG_Type"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_Status", false);
        //                        cmdud.Parameters["@UAG_Status"].Direction = ParameterDirection.Input;

        //                        SqlDataAdapter dta = new SqlDataAdapter(cmdud);
        //                        DataSet Ds = new DataSet();
        //                        dta.Fill(Ds);

        //                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        //                        {
        //                            foreach (DataRow rdr in Ds.Tables[0].Rows)
        //                            {
        //                                objUserHeadList.Add(new ReturnResponse { resp = Boolean.Parse(rdr["RTN_RESP"].ToString()), msg = rdr["RTN_MSG"].ToString() });
        //                            }
        //                        }
        //                        else
        //                        {
        //                            objUserHeadList.Add(new ReturnResponse { resp = true, msg = "" });
        //                        }

        //                        cmdud.Parameters.Clear();
        //                    }
        //                }
        //            }

        //            trans.Commit();
        //            trans.Dispose();

        //            objUserHead = new ReturnResponse
        //            {
        //                resp = true,
        //                msg = ""
        //            };
        //            objUserHeadList.AddRange(User_Data.sync_c_user_kioski(new CUser() { USER_ID = item.UT_StaffID }));
        //            objUserHeadList.Add(objUserHead);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (trans != null)
        //        {
        //            trans.Rollback();
        //            trans.Dispose();
        //        }
        //        objUserHead = new ReturnResponse
        //        {
        //            resp = false,
        //            msg = ex.Message.ToString()
        //        };
        //        objUserHeadList.Add(objUserHead);

        //        objError.WriteLog(0, "UserAccessGroup_Data", "inactivate_t_user_access_group", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "UserAccessGroup_Data", "inactivate_t_user_access_group", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "UserAccessGroup_Data", "inactivate_t_user_access_group", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "UserAccessGroup_Data", "inactivate_t_user_access_group", "Inner Exception Message: " + ex.InnerException.Message);
        //        }

        //    }
        //    return objUserHeadList;
        //}

        public static List<ReturnUAGUsrAllModelHead> get_c_user_access_group_all(GetUAGUsrAllModel Userall)//ok
        {
            List<ReturnUAGUsrAllModelHead> objHeadList = new List<ReturnUAGUsrAllModelHead>();
            ReturnUAGUsrAllModelHead objUserHead = new ReturnUAGUsrAllModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(Userall) == false)
            {
                objUserHead.resp = false;
                objUserHead.IsAuthenticated = false;
                objHeadList.Add(objUserHead);
                return objHeadList;
            }
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        lconn.Open();
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_mtc_user_access_group_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", Userall.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", Userall.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_StaffID", Userall.USR_StaffID);
                        cmd.Parameters["@USR_StaffID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_FirstName", Userall.USR_FirstName);
                        cmd.Parameters["@USR_FirstName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_LastName", Userall.USR_LastName);
                        cmd.Parameters["@USR_LastName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UGM_Name", Userall.UGM_Name);
                        cmd.Parameters["@UGM_Name"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BU_CompanyName", Userall.BU_CompanyName);
                        cmd.Parameters["@BU_CompanyName"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USR_DepartmentID", Userall.USR_DepartmentID);
                        cmd.Parameters["@USR_DepartmentID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_Status", Userall.UAG_Status);
                        cmd.Parameters["@UAG_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TABLE", Userall.TABLE);
                        cmd.Parameters["@TABLE"].Direction = ParameterDirection.Input;

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_customer_user_count";
                            cmdrc.CommandType = CommandType.StoredProcedure;

                            cmdrc.Parameters.AddWithValue("@TABLE", Userall.TABLE);
                            cmdrc.Parameters["@TABLE"].Direction = ParameterDirection.Input;

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
                                ReturnUAGUsrModel objData = new ReturnUAGUsrModel();


                                objUserHead.resp = true;
                                objUserHead.msg = "Get User";

                                objData.USR_StaffID = rdr["USR_StaffID"].ToString();
                                objData.USR_FirstName = rdr["USR_FirstName"].ToString();
                                objData.USR_LastName = rdr["USR_LastName"].ToString();
                                objData.UGM_Name = rdr["UGM_Name"].ToString();
                                objData.BU_CompanyName = rdr["BU_CompanyName"].ToString();
                                objData.CUS_CompanyName = rdr["CUS_CompanyName"].ToString();
                                objData.UAG_Status = rdr["UAG_Status"].ToString();
                                objData.UAG_GroupID = rdr["UAG_GroupID"].ToString();
                                objData.UAG_BusinessUnit = rdr["UAG_BusinessUnit"].ToString();
                                objData.UAG_CustomerID = rdr["UAG_CustomerID"].ToString();
                                objData.UAG_VendorID = rdr["UAG_VendorID"].ToString();
                                objData.RC = RC;

                                if (objUserHead.User == null)
                                {
                                    objUserHead.User = new List<ReturnUAGUsrModel>();
                                }

                                objUserHead.User.Add(objData);
                            }

                            objHeadList.Add(objUserHead);

                        }
                        else
                        {
                            objUserHead.resp = true;
                            objUserHead.msg = "";
                            objHeadList.Add(objUserHead);

                        }
                    }
                    lconn.Close();
                }

                return objHeadList;

            }
            catch (Exception ex)
            {

                objUserHead = new ReturnUAGUsrAllModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objUserHead);

                objError.WriteLog(0, "UserAccessGroup_Data", "get_c_user_access_group_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserAccessGroup_Data", "get_c_user_access_group_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserAccessGroup_Data", "get_c_user_access_group_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserAccessGroup_Data", "get_c_user_access_group_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        //public static List<ReturnResponse> add_new_c_user_access_group(UAGUsrModel item)//ok
        //{
        //    List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
        //    ReturnResponse objUserHead = new ReturnResponse();
        //    SqlTransaction trans = null;

        //    if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
        //    {
        //        objUserHead.resp = false;
        //        objUserHead.IsAuthenticated = false;
        //        objUserHeadList.Add(objUserHead);
        //        return objUserHeadList;
        //    }

        //    try
        //    {
        //        using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
        //        {
        //            lconn.Open();
        //            trans = lconn.BeginTransaction();

        //            foreach (var itemGr in item.ExistingUAG)
        //            {
        //                foreach (var itemKio in item.KioskAG)
        //                {
        //                    using (SqlCommand cmdud = new SqlCommand())
        //                    {
        //                        cmdud.Connection = lconn;
        //                        cmdud.Transaction = trans;

        //                        cmdud.CommandText = "sp_sav_customer_user_access_group";
        //                        cmdud.CommandType = CommandType.StoredProcedure;

        //                        cmdud.Parameters.AddWithValue("@USER_ID", item.USER_ID);
        //                        cmdud.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_UserID", itemGr.UAG_UserID);
        //                        cmdud.Parameters["@UAG_UserID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_GroupID", itemKio.UAG_GroupID);
        //                        cmdud.Parameters["@UAG_GroupID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_CustomerID", itemGr.UAG_CustomerID);
        //                        cmdud.Parameters["@UAG_CustomerID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_Status", true);
        //                        cmdud.Parameters["@UAG_Status"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_VendorID", itemKio.UAG_VendorID);
        //                        cmdud.Parameters["@UAG_VendorID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_Type", "MC");
        //                        cmdud.Parameters["@UAG_Type"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@TABLE", item.TABLE);
        //                        cmdud.Parameters["@TABLE"].Direction = ParameterDirection.Input;

        //                        SqlDataAdapter dta = new SqlDataAdapter(cmdud);
        //                        DataSet Ds = new DataSet();
        //                        dta.Fill(Ds);

        //                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        //                        {
        //                            foreach (DataRow rdr in Ds.Tables[0].Rows)
        //                            {
        //                                objUserHeadList.Add(new ReturnResponse { resp = Boolean.Parse(rdr["RTN_RESP"].ToString()), msg = rdr["RTN_MSG"].ToString() });
        //                            }
        //                        }
        //                        else
        //                        {
        //                            objUserHeadList.Add(new ReturnResponse { resp = true, msg = "" });
        //                        }

        //                        cmdud.Parameters.Clear();
        //                    }
        //                }
        //            }

        //            trans.Commit();
        //            trans.Dispose();

        //            objUserHead = new ReturnResponse
        //            {
        //                resp = true,
        //                msg = ""
        //            };

        //            objUserHeadList.AddRange(User_Data.sync_c_user_kioski(new CUser() { USER_ID = item.UT_StaffID }));
        //            objUserHeadList.Add(objUserHead);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (trans != null)
        //        {
        //            trans.Rollback();
        //            trans.Dispose();
        //        }
        //        objUserHead = new ReturnResponse
        //        {
        //            resp = false,
        //            msg = ex.Message.ToString()
        //        };
        //        objUserHeadList.Add(objUserHead);

        //        objError.WriteLog(0, "UserAccessGroup_Data", "add_new_c_user_access_group", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "UserAccessGroup_Data", "add_new_c_user_access_group", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "UserAccessGroup_Data", "add_new_c_user_access_group", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "UserAccessGroup_Data", "add_new_c_user_access_group", "Inner Exception Message: " + ex.InnerException.Message);
        //        }

        //    }
        //    return objUserHeadList;
        //}

        //public static List<ReturnResponse> inactivate_c_user_access_group(UAGUsrModel item)//ok
        //{
        //    List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
        //    ReturnResponse objUserHead = new ReturnResponse();
        //    SqlTransaction trans = null;

        //    if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
        //    {
        //        objUserHead.resp = false;
        //        objUserHead.IsAuthenticated = false;
        //        objUserHeadList.Add(objUserHead);
        //        return objUserHeadList;
        //    }

        //    try
        //    {
        //        using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
        //        {
        //            lconn.Open();
        //            trans = lconn.BeginTransaction();

        //            foreach (var itemGr in item.ExistingUAG)
        //            {
        //                foreach (var itemKio in item.KioskAG)
        //                {
        //                    using (SqlCommand cmdud = new SqlCommand())
        //                    {
        //                        cmdud.Connection = lconn;
        //                        cmdud.Transaction = trans;

        //                        cmdud.CommandText = "sp_sav_customer_user_access_group";
        //                        cmdud.CommandType = CommandType.StoredProcedure;

        //                        cmdud.Parameters.AddWithValue("@USER_ID", item.USER_ID);
        //                        cmdud.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_UserID", itemGr.UAG_UserID);
        //                        cmdud.Parameters["@UAG_UserID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_GroupID", itemKio.UAG_GroupID);
        //                        cmdud.Parameters["@UAG_GroupID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_CustomerID", itemGr.UAG_CustomerID);
        //                        cmdud.Parameters["@UAG_CustomerID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_Status", false);
        //                        cmdud.Parameters["@UAG_Status"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_VendorID", itemKio.UAG_VendorID);
        //                        cmdud.Parameters["@UAG_VendorID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_Type", "MC");
        //                        cmdud.Parameters["@UAG_Type"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@TABLE", item.TABLE);
        //                        cmdud.Parameters["@TABLE"].Direction = ParameterDirection.Input;

        //                        SqlDataAdapter dta = new SqlDataAdapter(cmdud);
        //                        DataSet Ds = new DataSet();
        //                        dta.Fill(Ds);

        //                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        //                        {
        //                            foreach (DataRow rdr in Ds.Tables[0].Rows)
        //                            {
        //                                objUserHeadList.Add(new ReturnResponse { resp = Boolean.Parse(rdr["RTN_RESP"].ToString()), msg = rdr["RTN_MSG"].ToString() });
        //                            }
        //                        }
        //                        else
        //                        {
        //                            objUserHeadList.Add(new ReturnResponse { resp = true, msg = "" });
        //                        }

        //                        cmdud.Parameters.Clear();
        //                    }
        //                }
        //            }

        //            trans.Commit();
        //            trans.Dispose();

        //            objUserHead = new ReturnResponse
        //            {
        //                resp = true,
        //                msg = ""
        //            };
        //            objUserHeadList.AddRange(User_Data.sync_c_user_kioski(new CUser() { USER_ID = item.UT_StaffID }));
        //            objUserHeadList.Add(objUserHead);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (trans != null)
        //        {
        //            trans.Rollback();
        //            trans.Dispose();
        //        }
        //        objUserHead = new ReturnResponse
        //        {
        //            resp = false,
        //            msg = ex.Message.ToString()
        //        };
        //        objUserHeadList.Add(objUserHead);

        //        objError.WriteLog(0, "UserAccessGroup_Data", "inactivate_c_user_access_group", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "UserAccessGroup_Data", "inactivate_c_user_access_group", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "UserAccessGroup_Data", "inactivate_c_user_access_group", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "UserAccessGroup_Data", "inactivate_c_user_access_group", "Inner Exception Message: " + ex.InnerException.Message);
        //        }

        //    }
        //    return objUserHeadList;
        //}


        //public static List<ReturnResponse> add_new_sk_user_access_group(UAGUsrModel item)//ok
        //{
        //    List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
        //    ReturnResponse objUserHead = new ReturnResponse();
        //    SqlTransaction trans = null;

        //    if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
        //    {
        //        objUserHead.resp = false;
        //        objUserHead.IsAuthenticated = false;
        //        objUserHeadList.Add(objUserHead);
        //        return objUserHeadList;
        //    }

        //    try
        //    {
        //        using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
        //        {
        //            lconn.Open();
        //            trans = lconn.BeginTransaction();

        //            foreach (var itemGr in item.ExistingUAG)
        //            {
        //                foreach (var itemKio in item.KioskAG)
        //                {
        //                    using (SqlCommand cmdud = new SqlCommand())
        //                    {
        //                        cmdud.Connection = lconn;
        //                        cmdud.Transaction = trans;

        //                        cmdud.CommandText = "sp_sav_customer_user_access_group";
        //                        cmdud.CommandType = CommandType.StoredProcedure;

        //                        cmdud.Parameters.AddWithValue("@USER_ID", item.USER_ID);
        //                        cmdud.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_UserID", itemGr.UAG_UserID);
        //                        cmdud.Parameters["@UAG_UserID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_GroupID", itemKio.UAG_GroupID);
        //                        cmdud.Parameters["@UAG_GroupID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_CustomerID", itemGr.UAG_CustomerID);
        //                        cmdud.Parameters["@UAG_CustomerID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_Status", true);
        //                        cmdud.Parameters["@UAG_Status"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_VendorID", itemKio.UAG_VendorID);
        //                        cmdud.Parameters["@UAG_VendorID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_Type", item.UAG_Type);
        //                        cmdud.Parameters["@UAG_Type"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@TABLE", item.TABLE);
        //                        cmdud.Parameters["@TABLE"].Direction = ParameterDirection.Input;

        //                        SqlDataAdapter dta = new SqlDataAdapter(cmdud);
        //                        DataSet Ds = new DataSet();
        //                        dta.Fill(Ds);

        //                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        //                        {
        //                            foreach (DataRow rdr in Ds.Tables[0].Rows)
        //                            {
        //                                objUserHeadList.Add(new ReturnResponse { resp = Boolean.Parse(rdr["RTN_RESP"].ToString()), msg = rdr["RTN_MSG"].ToString() });
        //                            }
        //                        }
        //                        else
        //                        {
        //                            objUserHeadList.Add(new ReturnResponse { resp = true, msg = "" });
        //                        }

        //                        cmdud.Parameters.Clear();
        //                    }
        //                }
        //            }

        //            trans.Commit();
        //            trans.Dispose();

        //            objUserHead = new ReturnResponse
        //            {
        //                resp = true,
        //                msg = ""
        //            };

        //            objUserHeadList.AddRange(User_Data.sync_c_user_kioski(new CUser() { USER_ID = item.UT_StaffID }));
        //            objUserHeadList.Add(objUserHead);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (trans != null)
        //        {
        //            trans.Rollback();
        //            trans.Dispose();
        //        }
        //        objUserHead = new ReturnResponse
        //        {
        //            resp = false,
        //            msg = ex.Message.ToString()
        //        };
        //        objUserHeadList.Add(objUserHead);

        //        objError.WriteLog(0, "UserAccessGroup_Data", "add_new_c_user_access_group", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "UserAccessGroup_Data", "add_new_c_user_access_group", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "UserAccessGroup_Data", "add_new_c_user_access_group", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "UserAccessGroup_Data", "add_new_c_user_access_group", "Inner Exception Message: " + ex.InnerException.Message);
        //        }

        //    }
        //    return objUserHeadList;
        //}

        //public static List<ReturnResponse> inactivate_sk_user_access_group(UAGUsrModel item)//ok
        //{
        //    List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
        //    ReturnResponse objUserHead = new ReturnResponse();
        //    SqlTransaction trans = null;

        //    if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
        //    {
        //        objUserHead.resp = false;
        //        objUserHead.IsAuthenticated = false;
        //        objUserHeadList.Add(objUserHead);
        //        return objUserHeadList;
        //    }

        //    try
        //    {
        //        using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
        //        {
        //            lconn.Open();
        //            trans = lconn.BeginTransaction();

        //            foreach (var itemGr in item.ExistingUAG)
        //            {
        //                foreach (var itemKio in item.KioskAG)
        //                {
        //                    using (SqlCommand cmdud = new SqlCommand())
        //                    {
        //                        cmdud.Connection = lconn;
        //                        cmdud.Transaction = trans;

        //                        cmdud.CommandText = "sp_sav_customer_user_access_group";
        //                        cmdud.CommandType = CommandType.StoredProcedure;

        //                        cmdud.Parameters.AddWithValue("@USER_ID", item.USER_ID);
        //                        cmdud.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_UserID", itemGr.UAG_UserID);
        //                        cmdud.Parameters["@UAG_UserID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_GroupID", itemKio.UAG_GroupID);
        //                        cmdud.Parameters["@UAG_GroupID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_CustomerID", itemGr.UAG_CustomerID);
        //                        cmdud.Parameters["@UAG_CustomerID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_Status", false);
        //                        cmdud.Parameters["@UAG_Status"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_VendorID", itemKio.UAG_VendorID);
        //                        cmdud.Parameters["@UAG_VendorID"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@UAG_Type", item.UAG_Type);
        //                        cmdud.Parameters["@UAG_Type"].Direction = ParameterDirection.Input;

        //                        cmdud.Parameters.AddWithValue("@TABLE", item.TABLE);
        //                        cmdud.Parameters["@TABLE"].Direction = ParameterDirection.Input;

        //                        SqlDataAdapter dta = new SqlDataAdapter(cmdud);
        //                        DataSet Ds = new DataSet();
        //                        dta.Fill(Ds);

        //                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        //                        {
        //                            foreach (DataRow rdr in Ds.Tables[0].Rows)
        //                            {
        //                                objUserHeadList.Add(new ReturnResponse { resp = Boolean.Parse(rdr["RTN_RESP"].ToString()), msg = rdr["RTN_MSG"].ToString() });
        //                            }
        //                        }
        //                        else
        //                        {
        //                            objUserHeadList.Add(new ReturnResponse { resp = true, msg = "" });
        //                        }

        //                        cmdud.Parameters.Clear();
        //                    }
        //                }
        //            }

        //            trans.Commit();
        //            trans.Dispose();

        //            objUserHead = new ReturnResponse
        //            {
        //                resp = true,
        //                msg = ""
        //            };
        //            objUserHeadList.AddRange(User_Data.sync_c_user_kioski(new CUser() { USER_ID = item.UT_StaffID }));
        //            objUserHeadList.Add(objUserHead);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (trans != null)
        //        {
        //            trans.Rollback();
        //            trans.Dispose();
        //        }
        //        objUserHead = new ReturnResponse
        //        {
        //            resp = false,
        //            msg = ex.Message.ToString()
        //        };
        //        objUserHeadList.Add(objUserHead);

        //        objError.WriteLog(0, "UserAccessGroup_Data", "inactivate_c_user_access_group", "Stack Track: " + ex.StackTrace);
        //        objError.WriteLog(0, "UserAccessGroup_Data", "inactivate_c_user_access_group", "Error Message: " + ex.Message);
        //        if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //        {
        //            objError.WriteLog(0, "UserAccessGroup_Data", "inactivate_c_user_access_group", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //            objError.WriteLog(0, "UserAccessGroup_Data", "inactivate_c_user_access_group", "Inner Exception Message: " + ex.InnerException.Message);
        //        }

        //    }
        //    return objUserHeadList;
        //}

        public static List<ReturnResponse> modify_sk_user_access_group(UAGUsrModel item)
        {
            List<ReturnResponse> objUserHeadList = new List<ReturnResponse>();
            ReturnResponse objUserHead = new ReturnResponse();
            SqlTransaction trans = null;

            if (login_Data.AuthenticationKeyValidateWithDB(item) == false)
            {
                objUserHead.resp = false;
                objUserHead.IsAuthenticated = false;
                objUserHeadList.Add(objUserHead);
                return objUserHeadList;
            }

            try
            {
                string logobject = JsonConvert.SerializeObject(item);

                new WhiteLog("modify_sk_user_access_group - request read" + logobject, "UserAccessGroup_Data", "modify_sk_user_access_group", true, true);

                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    lconn.Open();
                    trans = lconn.BeginTransaction();

                    foreach (var itemGr in item.ExistingUAG)
                    {
                        foreach (var itemKio in item.KioskAG)
                        {
                            using (SqlCommand cmdud = new SqlCommand())
                            {
                                cmdud.Connection = lconn;
                                cmdud.Transaction = trans;

                                cmdud.CommandText = "sp_sav_user_access_group";
                                cmdud.CommandType = CommandType.StoredProcedure;

                                cmdud.Parameters.AddWithValue("@USER_ID", item.USER_ID);
                                cmdud.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                                cmdud.Parameters.AddWithValue("@UAG_UserID", itemGr.UAG_UserID);
                                cmdud.Parameters["@UAG_UserID"].Direction = ParameterDirection.Input;

                                cmdud.Parameters.AddWithValue("@UAG_GroupID", itemKio.UAG_GroupID);
                                cmdud.Parameters["@UAG_GroupID"].Direction = ParameterDirection.Input;

                                cmdud.Parameters.AddWithValue("@UAG_BusinessUnit", itemGr.UAG_BusinessUnit);
                                cmdud.Parameters["@UAG_BusinessUnit"].Direction = ParameterDirection.Input;

                                cmdud.Parameters.AddWithValue("@UAG_CustomerID", itemGr.UAG_CustomerID);
                                cmdud.Parameters["@UAG_CustomerID"].Direction = ParameterDirection.Input;

                                cmdud.Parameters.AddWithValue("@UAG_VendorID", itemKio.UAG_VendorID);
                                cmdud.Parameters["@UAG_VendorID"].Direction = ParameterDirection.Input;

                                cmdud.Parameters.AddWithValue("@UAG_Type", itemGr.UAG_Type);
                                cmdud.Parameters["@UAG_Type"].Direction = ParameterDirection.Input;

                                cmdud.Parameters.AddWithValue("@UAG_Status", itemGr.UAG_Status);
                                cmdud.Parameters["@UAG_Status"].Direction = ParameterDirection.Input;
                                 
                                //cmdud.Parameters.AddWithValue("@TABLE", item.TABLE);
                                //cmdud.Parameters["@TABLE"].Direction = ParameterDirection.Input;

                                SqlDataAdapter dta = new SqlDataAdapter(cmdud);
                                DataSet Ds = new DataSet();
                                dta.Fill(Ds);

                                if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow rdr in Ds.Tables[0].Rows)
                                    {
                                        objUserHead=  new ReturnResponse { resp = Boolean.Parse(rdr["RTN_RESP"].ToString()), msg = rdr["RTN_MSG"].ToString() };
                                     
                                        objUserHeadList.Add(objUserHead);
                                    }
                                }
                                else
                                {
                                    objUserHeadList.Add(new ReturnResponse { resp = true, msg = "" });
                                }

                                cmdud.Parameters.Clear();
                            }
                        }
                    }

                    trans.Commit();
                    trans.Dispose();

                    objUserHead = new ReturnResponse
                    {
                        resp = true,
                        msg = ""
                    };

                    objUserHeadList.Add(objUserHead);

                    logobject = JsonConvert.SerializeObject(objUserHeadList);
                    new WhiteLog("modify_sk_user_access_group - request return" + logobject, "UserAccessGroup_Data", "modify_sk_user_access_group", true, true);


                }
            }
            catch (Exception ex)
            {
                if (trans != null)
                {
                    trans.Rollback();
                    trans.Dispose();
                }

                objUserHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserHeadList.Add(objUserHead);

                objError.WriteLog(0, "UserAccessGroup_Data", "modify_t_user_access_group", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserAccessGroup_Data", "modify_t_user_access_group", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserAccessGroup_Data", "modify_t_user_access_group", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserAccessGroup_Data", "modify_t_user_access_group", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objUserHeadList;
        }

    }
}








