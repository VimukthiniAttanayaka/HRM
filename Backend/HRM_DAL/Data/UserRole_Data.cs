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
    public class UserRole_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnUserRoleModelHead> get_UserRoles_single(UserRole model)//ok
        {
            List<ReturnUserRoleModelHead> objUserRoleHeadList = new List<ReturnUserRoleModelHead>();
            ReturnUserRoleModelHead objUserRoleHead = new ReturnUserRoleModelHead();

            if (objUserRoleHead.UserRole == null)
            {
                objUserRoleHead.UserRole = new List<ReturnUserRoleModel>();
            }


            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objUserRoleHead.resp = false;
                objUserRoleHead.IsAuthenticated = false;
                objUserRoleHeadList.Add(objUserRoleHead);
                return objUserRoleHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_UserRole_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UUR_UserRoleID", model.UUR_UserRoleID);
                        cmd.Parameters["@UUR_UserRoleID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnUserRoleModel objUserRole = new ReturnUserRoleModel();

                                objUserRoleHead.resp = true;
                                objUserRoleHead.msg = "Get UserRole";

                                objUserRole.UUR_UserRoleID = rdr["UUR_UserRoleID"].ToString();
                                objUserRole.UUR_UserRole = rdr["UUR_UserRole"].ToString();
                                objUserRole.UUR_Status = Convert.ToBoolean(rdr["UUR_Status"].ToString());

                                if (objUserRoleHead.UserRole == null)
                                {
                                    objUserRoleHead.UserRole = new List<ReturnUserRoleModel>();
                                }

                                objUserRoleHead.UserRole.Add(objUserRole);

                                objUserRoleHeadList.Add(objUserRoleHead);
                            }

                        }
                        else
                        {
                            ReturnUserRoleModel objUserRole = new ReturnUserRoleModel();
                            objUserRoleHead.resp = true;
                            objUserRoleHead.msg = "";
                            objUserRoleHeadList.Add(objUserRoleHead);


                        }


                    }
                    return objUserRoleHeadList;

                }
            }
            catch (Exception ex)
            {
                objUserRoleHead.resp = false;
                objUserRoleHead.msg = ex.Message.ToString();

                objUserRoleHeadList.Add(objUserRoleHead);

                objError.WriteLog(0, "UserRole_Data", "get_UserRoles_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserRole_Data", "get_UserRoles_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserRole_Data", "get_UserRoles_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserRole_Data", "get_UserRoles_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserRoleHeadList;

        }

        public static List<ReturnAccessGroupModelHead> get_AccessGroup_all_ForUserRole(UserRoleSearchModel model)
        {
            List<ReturnAccessGroupModelHead> objUserRoleHeadList = new List<ReturnAccessGroupModelHead>();
            ReturnAccessGroupModelHead objUserRoleHead = new ReturnAccessGroupModelHead();

            if (objUserRoleHead.AccessGroup == null)
            {
                objUserRoleHead.AccessGroup = new List<ReturnAccessGroupModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objUserRoleHead.resp = false;
                objUserRoleHead.IsAuthenticated = false;
                objUserRoleHeadList.Add(objUserRoleHead);
                return objUserRoleHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_AccessGroup_all_ForUserRole";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UUR_UserRoleID", model.UUR_UserRoleID);
                        cmd.Parameters["@UUR_UserRoleID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnAccessGroupModel objUserRole = new ReturnAccessGroupModel();

                                objUserRoleHead.resp = true;
                                objUserRoleHead.msg = "Get UserRole";

                                objUserRole.UAG_AccessGroupID = rdr["UAG_AccessGroupID"].ToString();
                                objUserRole.UAG_AccessGroup = rdr["UAG_AccessGroup"].ToString();
                                if (rdr["UAG_Status"].ToString() == "1")
                                    objUserRole.UAG_Status = true;


                                objUserRoleHead.AccessGroup.Add(objUserRole);

                                objUserRoleHeadList.Add(objUserRoleHead);
                            }

                        }
                        else
                        {
                            ReturnAccessGroupModel objUserRole = new ReturnAccessGroupModel();
                            objUserRoleHead.resp = true;
                            objUserRoleHead.msg = "";
                            objUserRoleHeadList.Add(objUserRoleHead);


                        }


                    }
                    return objUserRoleHeadList;

                }
            }
            catch (Exception ex)
            {
                objUserRoleHead.resp = false;
                objUserRoleHead.msg = ex.Message.ToString();

                objUserRoleHeadList.Add(objUserRoleHead);

                objError.WriteLog(0, "UserRole_Data", "get_AccessGroup_all_ForUserRole", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserRole_Data", "get_AccessGroup_all_ForUserRole", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserRole_Data", "get_AccessGroup_all_ForUserRole", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserRole_Data", "get_AccessGroup_all_ForUserRole", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserRoleHeadList;
        }

        public static List<ReturnResponse> GrantAccess(GrantRemoveAccessModel item)
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


                        cmd.CommandText = "sp_grantaccess_UserGroup";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ModifiedUser", item.UD_UserID);
                        cmd.Parameters["@ModifiedUser"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UURAG_AccessGroupID", item.UURAG_AccessGroupID);
                        cmd.Parameters["@UURAG_AccessGroupID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UURAG_UserRoleID", item.UURAG_UserRoleID);
                        cmd.Parameters["@UURAG_UserRoleID"].Direction = ParameterDirection.Input;

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
                            objCustHead = new ReturnResponse();
                            objCustHead.resp = true;
                            objCustHead.msg = "";
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

                objError.WriteLog(0, "UserMenu_Data", "GrantAccess", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenu_Data", "GrantAccess", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenu_Data", "GrantAccess", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenu_Data", "GrantAccess", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> RemoveAccess(GrantRemoveAccessModel item)
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


                        cmd.CommandText = "sp_removeaccess_UserGroup";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ModifiedUser", item.UD_UserID);
                        cmd.Parameters["@ModifiedUser"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UURAG_AccessGroupID", item.UURAG_AccessGroupID);
                        cmd.Parameters["@UURAG_AccessGroupID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UURAG_UserRoleID", item.UURAG_UserRoleID);
                        cmd.Parameters["@UURAG_UserRoleID"].Direction = ParameterDirection.Input;

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
                            objCustHead = new ReturnResponse();
                            objCustHead.resp = true;
                            objCustHead.msg = "";
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

                objError.WriteLog(0, "UserMenu_Data", "RemoveAccess", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenu_Data", "RemoveAccess", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenu_Data", "RemoveAccess", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenu_Data", "RemoveAccess", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnUserRoleModelHead> get_UserRole_all(UserRoleSearchModel model)//ok
        {
            List<ReturnUserRoleModelHead> objUserRoleHeadList = new List<ReturnUserRoleModelHead>();
            ReturnUserRoleModelHead objUserRoleHead = new ReturnUserRoleModelHead();

            if (objUserRoleHead.UserRole == null)
            {
                objUserRoleHead.UserRole = new List<ReturnUserRoleModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objUserRoleHead.resp = false;
                objUserRoleHead.IsAuthenticated = false;
                objUserRoleHeadList.Add(objUserRoleHead);
                return objUserRoleHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_UserRole_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@UUR_UserRoleID", model.UUR_UserRoleID);
                        //cmd.Parameters["@UUR_UserRoleID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnUserRoleModel objUserRole = new ReturnUserRoleModel();

                                objUserRoleHead.resp = true;
                                objUserRoleHead.msg = "Get UserRole";

                                objUserRole.UUR_UserRoleID = rdr["UUR_UserRoleID"].ToString();
                                objUserRole.UUR_UserRole = rdr["UUR_UserRole"].ToString();
                                objUserRole.UUR_Status = Convert.ToBoolean(rdr["UUR_Status"].ToString());


                                objUserRoleHead.UserRole.Add(objUserRole);

                                objUserRoleHeadList.Add(objUserRoleHead);
                            }

                        }
                        else
                        {
                            ReturnUserRoleModel objUserRole = new ReturnUserRoleModel();
                            objUserRoleHead.resp = true;
                            objUserRoleHead.msg = "";
                            objUserRoleHeadList.Add(objUserRoleHead);


                        }


                    }
                    return objUserRoleHeadList;

                }
            }
            catch (Exception ex)
            {
                objUserRoleHead.resp = false;
                objUserRoleHead.msg = ex.Message.ToString();

                objUserRoleHeadList.Add(objUserRoleHead);

                objError.WriteLog(0, "UserRole_Data", "get_UserRole_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserRole_Data", "get_UserRole_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserRole_Data", "get_UserRole_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserRole_Data", "get_UserRole_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserRoleHeadList;

        }

        public static List<ReturncustResponse> add_new_UserRole(UserRoleModel item)//ok
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


                        cmd.CommandText = "sp_insert_UserRole";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UUR_UserRoleID", item.UUR_UserRoleID);
                        cmd.Parameters["@UUR_UserRoleID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UUR_UserRole", item.UUR_UserRole);
                        cmd.Parameters["@UUR_UserRole"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UUR_Status", item.UUR_Status);
                        cmd.Parameters["@UUR_Status"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "UserRole_Data", "add_new_UserRole", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserRole_Data", "add_new_UserRole", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserRole_Data", "add_new_UserRole", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserRole_Data", "add_new_UserRole", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturncustResponse> modify_UserRole(UserRoleModel item)//ok
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


                        cmd.CommandText = "sp_modify_UserRole";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UUR_UserRoleID", item.UUR_UserRoleID);
                        cmd.Parameters["@UUR_UserRoleID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UUR_UserRole", item.UUR_UserRole);
                        cmd.Parameters["@UUR_UserRole"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UUR_Status", item.UUR_Status);
                        cmd.Parameters["@UUR_Status"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "UserRole_Data", "add_new_UserRole", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserRole_Data", "add_new_UserRole", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserRole_Data", "add_new_UserRole", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserRole_Data", "add_new_UserRole", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_UserRole(InactiveUURModel item)//ok
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



                        cmd.CommandText = "sp_del_UserRole";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UUR_UserRoleID", item.UUR_UserRoleID);
                        cmd.Parameters["@UUR_UserRoleID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "UserRole_Data", "inactivate_UserRole", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserRole_Data", "inactivate_UserRole", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserRole_Data", "inactivate_UserRole", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserRole_Data", "inactivate_UserRole", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

