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
    public class UserMenu_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnUserMenuModelHead> get_UserMenus_single(UserMenu model)//ok
        {
            List<ReturnUserMenuModelHead> objUserMenuHeadList = new List<ReturnUserMenuModelHead>();
            ReturnUserMenuModelHead objUserMenuHead = new ReturnUserMenuModelHead();

            if (objUserMenuHead.UserMenu == null)
            {
                objUserMenuHead.UserMenu = new List<ReturnUserMenuModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objUserMenuHead.resp = false;
                objUserMenuHead.IsAuthenticated = false;
                objUserMenuHeadList.Add(objUserMenuHead);
                return objUserMenuHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_UserMenu_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UUM_UserMenuID", model.UUM_UserMenuID);
                        cmd.Parameters["@UUM_UserMenuID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnUserMenuModel objUserMenu = new ReturnUserMenuModel();

                                objUserMenuHead.resp = true;
                                objUserMenuHead.msg = "Get UserMenu";

                                objUserMenu.UUM_UserMenuID = rdr["UUM_UserMenuID"].ToString();
                                objUserMenu.UUM_UserMenu = rdr["UUM_UserMenu"].ToString();
                                objUserMenu.UUM_Status = Convert.ToBoolean(rdr["UUM_Status"].ToString());


                                objUserMenuHead.UserMenu.Add(objUserMenu);

                                objUserMenuHeadList.Add(objUserMenuHead);
                            }

                        }
                        else
                        {
                            ReturnUserMenuModel objUserMenu = new ReturnUserMenuModel();
                            objUserMenuHead.resp = true;
                            objUserMenuHead.msg = "";
                            objUserMenuHeadList.Add(objUserMenuHead);


                        }


                    }
                    return objUserMenuHeadList;

                }
            }
            catch (Exception ex)
            {
                objUserMenuHead.resp = false;
                objUserMenuHead.msg = ex.Message.ToString();

                objUserMenuHeadList.Add(objUserMenuHead);

                objError.WriteLog(0, "UserMenu_Data", "get_UserMenus_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenu_Data", "get_UserMenus_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenu_Data", "get_UserMenus_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenu_Data", "get_UserMenus_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserMenuHeadList;

        }

        public static List<ReturnUserMenuModelHead> get_UserMenu_all_ForAccessGroup(GrantRemoveUserMenuModel model)
        {
            List<ReturnUserMenuModelHead> objUserMenuHeadList = new List<ReturnUserMenuModelHead>();
            ReturnUserMenuModelHead objUserMenuHead = new ReturnUserMenuModelHead();

            if (objUserMenuHead.UserMenu == null)
            {
                objUserMenuHead.UserMenu = new List<ReturnUserMenuModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objUserMenuHead.resp = false;
                objUserMenuHead.IsAuthenticated = false;
                objUserMenuHeadList.Add(objUserMenuHead);
                return objUserMenuHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_UserMenu_all_ForAccessGroup";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UMA_AccessGroupID", model.UMA_AccessGroupID);
                        cmd.Parameters["@UMA_AccessGroupID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnUserMenuModel objUserMenu = new ReturnUserMenuModel();

                                objUserMenuHead.resp = true;
                                objUserMenuHead.msg = "Get UserMenu";

                                objUserMenu.UUM_UserMenuID = rdr["UUM_UserMenuID"].ToString();
                                objUserMenu.UUM_UserMenu = rdr["UUM_UserMenu"].ToString();
                                if (rdr["UUM_Status"].ToString() == "1")
                                    objUserMenu.UUM_Status = true;

                                objUserMenuHead.UserMenu.Add(objUserMenu);

                                objUserMenuHeadList.Add(objUserMenuHead);
                            }

                        }
                        else
                        {
                            ReturnUserMenuModel objUserMenu = new ReturnUserMenuModel();
                            objUserMenuHead.resp = true;
                            objUserMenuHead.msg = "";
                            objUserMenuHeadList.Add(objUserMenuHead);


                        }


                    }
                    return objUserMenuHeadList;

                }
            }
            catch (Exception ex)
            {
                objUserMenuHead.resp = false;
                objUserMenuHead.msg = ex.Message.ToString();

                objUserMenuHeadList.Add(objUserMenuHead);

                objError.WriteLog(0, "UserMenu_Data", "get_UserMenu_all_ForAccessGroup", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenu_Data", "get_UserMenu_all_ForAccessGroup", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenu_Data", "get_UserMenu_all_ForAccessGroup", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenu_Data", "get_UserMenu_all_ForAccessGroup", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserMenuHeadList;

        }

        public static List<ReturnResponse> GrantAccess(GrantRemoveUserMenuModel item)
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


                        cmd.CommandText = "sp_grantaccess_UserMenu";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ModifiedUser", item.UD_UserID);
                        cmd.Parameters["@ModifiedUser"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UMA_AccessGroupID", item.UMA_AccessGroupID);
                        cmd.Parameters["@UMA_AccessGroupID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UMA_UserMenuID", item.UMA_UserMenuID);
                        cmd.Parameters["@UMA_UserMenuID"].Direction = ParameterDirection.Input;

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

        public static List<ReturnResponse> RemoveAccess(GrantRemoveUserMenuModel item)
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


                        cmd.CommandText = "sp_removeaccess_UserMenu";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ModifiedUser", item.UD_UserID);
                        cmd.Parameters["@ModifiedUser"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UMA_AccessGroupID", item.UMA_AccessGroupID);
                        cmd.Parameters["@UMA_AccessGroupID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UMA_UserMenuID", item.UMA_UserMenuID);
                        cmd.Parameters["@UMA_UserMenuID"].Direction = ParameterDirection.Input;

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

        public static List<ReturnUserMenuModelHead> get_UserMenu_all(UserMenuSearchModel model)//ok
        {
            List<ReturnUserMenuModelHead> objUserMenuHeadList = new List<ReturnUserMenuModelHead>();
            ReturnUserMenuModelHead objUserMenuHead = new ReturnUserMenuModelHead();

            if (objUserMenuHead.UserMenu == null)
            {
                objUserMenuHead.UserMenu = new List<ReturnUserMenuModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objUserMenuHead.resp = false;
                objUserMenuHead.IsAuthenticated = false;
                objUserMenuHeadList.Add(objUserMenuHead);
                return objUserMenuHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_UserMenu_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@UUM_UserMenuID", model.UUM_UserMenuID);
                        //cmd.Parameters["@UUM_UserMenuID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnUserMenuModel objUserMenu = new ReturnUserMenuModel();

                                objUserMenuHead.resp = true;
                                objUserMenuHead.msg = "Get UserMenu";

                                objUserMenu.UUM_UserMenuID = rdr["UUM_UserMenuID"].ToString();
                                objUserMenu.UUM_UserMenu = rdr["UUM_UserMenu"].ToString();
                                objUserMenu.UUM_Status = Convert.ToBoolean(rdr["UUM_Status"].ToString());

                                objUserMenuHead.UserMenu.Add(objUserMenu);

                                objUserMenuHeadList.Add(objUserMenuHead);
                            }

                        }
                        else
                        {
                            ReturnUserMenuModel objUserMenu = new ReturnUserMenuModel();
                            objUserMenuHead.resp = true;
                            objUserMenuHead.msg = "";
                            objUserMenuHeadList.Add(objUserMenuHead);


                        }


                    }
                    return objUserMenuHeadList;

                }
            }
            catch (Exception ex)
            {
                objUserMenuHead.resp = false;
                objUserMenuHead.msg = ex.Message.ToString();

                objUserMenuHeadList.Add(objUserMenuHead);

                objError.WriteLog(0, "UserMenu_Data", "get_UserMenu_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenu_Data", "get_UserMenu_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenu_Data", "get_UserMenu_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenu_Data", "get_UserMenu_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserMenuHeadList;

        }

        public static List<ReturnResponse> add_new_UserMenu(UserMenuModel item)//ok
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


                        cmd.CommandText = "sp_insert_UserMenu";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UUM_UserMenu", item.UUM_UserMenu);
                        cmd.Parameters["@UUM_UserMenu"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UUM_UserMenuID", item.UUM_UserMenuID);
                        cmd.Parameters["@UUM_UserMenuID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UUM_Status", item.UUM_Status);
                        cmd.Parameters["@UUM_Status"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "UserMenu_Data", "add_new_UserMenu", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenu_Data", "add_new_UserMenu", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenu_Data", "add_new_UserMenu", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenu_Data", "add_new_UserMenu", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> modify_UserMenu(UserMenuModel item)//ok
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


                        cmd.CommandText = "sp_modify_UserMenu";
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UUM_UserMenu", item.UUM_UserMenu);
                        cmd.Parameters["@UUM_UserMenu"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UUM_UserMenuID", item.UUM_UserMenuID);
                        cmd.Parameters["@UUM_UserMenuID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UUM_Status", item.UUM_Status);
                        cmd.Parameters["@UUM_Status"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "UserMenu_Data", "add_new_UserMenu", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenu_Data", "add_new_UserMenu", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenu_Data", "add_new_UserMenu", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenu_Data", "add_new_UserMenu", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_UserMenu(InactiveUUMModel item)//ok
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



                        cmd.CommandText = "sp_del_UserMenu";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UUM_UserMenuID", item.UUM_UserMenuID);
                        cmd.Parameters["@UUM_UserMenuID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "UserMenu_Data", "inactivate_UserMenu", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserMenu_Data", "inactivate_UserMenu", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserMenu_Data", "inactivate_UserMenu", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserMenu_Data", "inactivate_UserMenu", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

