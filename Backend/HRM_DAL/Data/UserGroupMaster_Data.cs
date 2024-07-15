using HRM_DAL.Models;
using error_handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using utility_handler.Data;
using HRM_DAL.Models.RequestModels;

namespace HRM_DAL.Data
{
    public class UserGroupMaster_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturUserGroupMasterModelHead> get_user_group_master_all(GetUGMAllModel MTall)
        {
            List<ReturUserGroupMasterModelHead> objHeadList = new List<ReturUserGroupMasterModelHead>();
                    ReturUserGroupMasterModelHead objHead = new ReturUserGroupMasterModelHead();

            //if (login_Data.AuthenticationKeyValidateWithDB(MTall) == false)
            //{
            //    objHead.resp = false;
            //    objHead.IsAuthenticated = false;
            //    objHeadList.Add(objHead);
            //    return objHeadList;
            //}

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    lconn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_user_group_master_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PAGE_NO", MTall.PAGE_NO);
                        cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", MTall.PAGE_RECORDS_COUNT);
                        cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UGM_Type", MTall.UGM_Type);
                        cmd.Parameters["@UGM_Type"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UGM_Status", MTall.UGM_Status);
                        cmd.Parameters["@UGM_Status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UGM_VendorID", MTall.UGM_VendorID);
                        cmd.Parameters["@UGM_VendorID"].Direction = ParameterDirection.Input;

                        string RC;
                        using (SqlCommand cmdrc = new SqlCommand())
                        {
                            cmdrc.Connection = lconn;

                            cmdrc.CommandText = "sp_get_user_group_master_count";
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
                                ReturnUserGroupMasterModel objData = new ReturnUserGroupMasterModel();


                                objHead.resp = true;
                                objHead.msg = "UserGroup Master";

                                objData.UGM_ID = rdr["UGM_ID"].ToString();
                                objData.UGM_Name = rdr["UGM_Name"].ToString();
                                objData.UGM_Type = rdr["UGM_Type"].ToString();
                                objData.UGM_VendorID = rdr["UGM_VendorID"].ToString();
                                objData.UGM_DisplaySeq = rdr["UGM_DisplaySeq"].ToString();
                                objData.UGM_Status = rdr["UGM_Status"].ToString();

                                objData.RC = RC;

                                if (objHead.UserGroupMaster == null)
                                {
                                    objHead.UserGroupMaster = new List<ReturnUserGroupMasterModel>();
                                }

                                objHead.UserGroupMaster.Add(objData);

                                //objHeadList.Add(objHead);

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
                ReturUserGroupMasterModelHead objMTHead = new ReturUserGroupMasterModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objMTHead);

                objError.WriteLog(0, "UserGroupMaster_Data", "get_user_group_master_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserGroupMaster_Data", "get_user_group_master_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserGroupMaster_Data", "get_user_group_master_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserGroupMaster_Data", "get_user_group_master_all", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        public static List<ReturUserGroupMasterModelHead> get_user_group_master(GetUGMSingleModel MTall)
        {
            List<ReturUserGroupMasterModelHead> objHeadList = new List<ReturUserGroupMasterModelHead>();
            ReturUserGroupMasterModelHead objHead = new ReturUserGroupMasterModelHead();

            //if (login_Data.AuthenticationKeyValidateWithDB(MTall) == false)
            //{
            //    objHead.resp = false;
            //    objHead.IsAuthenticated = false;
            //    objHeadList.Add(objHead);
            //    return objHeadList;
            //}

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    lconn.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_user_group_master_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UGM_ID", MTall.UGM_ID);
                        cmd.Parameters["@UGM_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnUserGroupMasterModel objData = new ReturnUserGroupMasterModel();


                                objHead.resp = true;
                                objHead.msg = "UserGroup Master";

                                objData.UGM_ID = rdr["UGM_ID"].ToString();
                                objData.UGM_Name = rdr["UGM_Name"].ToString();
                                objData.UGM_Type = rdr["UGM_Type"].ToString();
                                objData.UGM_VendorID = rdr["UGM_VendorID"].ToString();
                                objData.UGM_DisplaySeq = rdr["UGM_DisplaySeq"].ToString();
                                objData.UGM_Status = rdr["UGM_Status"].ToString();

                                objData.RC = "1";

                                if (objHead.UserGroupMaster == null)
                                {
                                    objHead.UserGroupMaster = new List<ReturnUserGroupMasterModel>();
                                }

                                objHead.UserGroupMaster.Add(objData);

                                //objHeadList.Add(objHead);

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
                ReturUserGroupMasterModelHead objMTHead = new ReturUserGroupMasterModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objHeadList.Add(objMTHead);

                objError.WriteLog(0, "UserGroupMaster_Data", "get_user_group_master", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserGroupMaster_Data", "get_user_group_master", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserGroupMaster_Data", "get_user_group_master", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserGroupMaster_Data", "get_user_group_master", "Inner Exception Message: " + ex.InnerException.Message);
                }


            }

            return objHeadList;

        }

        public static UserGroupDto add_new_user_group_master(Get_UserGroups_ResponceModel item)
        {
            UserGroupDto objHeadList = new UserGroupDto();
            ReturUserGroupMasterModelHead objHead = new ReturUserGroupMasterModelHead();

            //if (login_Data.AuthenticationKeyValidateWithDB(MTall) == false)
            //{
            //    objHead.resp = false;
            //    objHead.IsAuthenticated = false;
            //    objHeadList.Add(objHead);
            //    return objHeadList;
            //}

            //try
            //{
            //    using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
            //    {
            //        lconn.Open();

            //        using (SqlCommand cmd = new SqlCommand())
            //        {
            //            cmd.Connection = lconn;

            //            cmd.CommandText = "sp_get_user_group_master_all";
            //            cmd.CommandType = CommandType.StoredProcedure;

            //            cmd.Parameters.AddWithValue("@PAGE_NO", MTall.PAGE_NO);
            //            cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

            //            cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", MTall.PAGE_RECORDS_COUNT);
            //            cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

            //            cmd.Parameters.AddWithValue("@UGM_Type", MTall.UGM_Type);
            //            cmd.Parameters["@UGM_Type"].Direction = ParameterDirection.Input;

            //            cmd.Parameters.AddWithValue("@UGM_Status", MTall.UGM_Status);
            //            cmd.Parameters["@UGM_Status"].Direction = ParameterDirection.Input;

            //            cmd.Parameters.AddWithValue("@UGM_VendorID", MTall.UGM_VendorID);
            //            cmd.Parameters["@UGM_VendorID"].Direction = ParameterDirection.Input;

            //            string RC;
            //            using (SqlCommand cmdrc = new SqlCommand())
            //            {
            //                cmdrc.Connection = lconn;

            //                cmdrc.CommandText = "sp_get_user_group_master_count";
            //                cmdrc.CommandType = CommandType.StoredProcedure;
            //                SqlDataReader rdrrc = cmdrc.ExecuteReader();
            //                rdrrc.Read();
            //                RC = rdrrc["RC"].ToString();
            //                rdrrc.Close();
            //            }

            //            SqlDataAdapter dta = new SqlDataAdapter();
            //            dta.SelectCommand = cmd;
            //            DataSet Ds = new DataSet();
            //            dta.Fill(Ds);

            //            if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
            //            {
            //                foreach (DataRow rdr in Ds.Tables[0].Rows)
            //                {
            //                    ReturnUserGroupMasterModel objData = new ReturnUserGroupMasterModel();


            //                    objHead.resp = true;
            //                    objHead.msg = "UserGroup Master";

            //                    objData.UGM_ID = rdr["UGM_ID"].ToString();
            //                    objData.UGM_Name = rdr["UGM_Name"].ToString();
            //                    objData.UGM_Type = rdr["UGM_Type"].ToString();
            //                    objData.UGM_VendorID = rdr["UGM_VendorID"].ToString();
            //                    objData.UGM_DisplaySeq = rdr["UGM_DisplaySeq"].ToString();
            //                    objData.UGM_Status = rdr["UGM_Status"].ToString();

            //                    objData.RC = RC;

            //                    if (objHead.UserGroupMaster == null)
            //                    {
            //                        objHead.UserGroupMaster = new List<ReturnUserGroupMasterModel>();
            //                    }

            //                    objHead.UserGroupMaster.Add(objData);

            //                    //objHeadList.Add(objHead);

            //                }
            //                objHeadList.Add(objHead);

            //            }
            //            else
            //            {
            //                objHead.resp = true;
            //                objHead.msg = "";
            //                objHeadList.Add(objHead);
            //            }
            //        }
            //        return objHeadList;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ReturUserGroupMasterModelHead objMTHead = new ReturUserGroupMasterModelHead
            //    {
            //        resp = false,
            //        msg = ex.Message.ToString()
            //    };
            //    objHeadList.Add(objMTHead);

            //    objError.WriteLog(0, "UserGroupMaster_Data", "add_new_user_group_master", "Stack Track: " + ex.StackTrace);
            //    objError.WriteLog(0, "UserGroupMaster_Data", "add_new_user_group_master", "Error Message: " + ex.Message);
            //    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
            //    {
            //        objError.WriteLog(0, "UserGroupMaster_Data", "add_new_user_group_master", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
            //        objError.WriteLog(0, "UserGroupMaster_Data", "add_new_user_group_master", "Inner Exception Message: " + ex.InnerException.Message);
            //    }


            //}

            return objHeadList;

        }

        public static UserGroupDto modify_user_group_master(Get_UserGroups_ResponceModel item)
        {
            UserGroupDto objHeadList = new UserGroupDto();
            ReturUserGroupMasterModelHead objHead = new ReturUserGroupMasterModelHead();

            //if (login_Data.AuthenticationKeyValidateWithDB(MTall) == false)
            //{
            //    objHead.resp = false;
            //    objHead.IsAuthenticated = false;
            //    objHeadList.Add(objHead);
            //    return objHeadList;
            //}

            //try
            //{
            //    using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
            //    {
            //        lconn.Open();

            //        using (SqlCommand cmd = new SqlCommand())
            //        {
            //            cmd.Connection = lconn;

            //            cmd.CommandText = "sp_get_user_group_master_all";
            //            cmd.CommandType = CommandType.StoredProcedure;

            //            cmd.Parameters.AddWithValue("@PAGE_NO", MTall.PAGE_NO);
            //            cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

            //            cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", MTall.PAGE_RECORDS_COUNT);
            //            cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

            //            cmd.Parameters.AddWithValue("@UGM_Type", MTall.UGM_Type);
            //            cmd.Parameters["@UGM_Type"].Direction = ParameterDirection.Input;

            //            cmd.Parameters.AddWithValue("@UGM_Status", MTall.UGM_Status);
            //            cmd.Parameters["@UGM_Status"].Direction = ParameterDirection.Input;

            //            cmd.Parameters.AddWithValue("@UGM_VendorID", MTall.UGM_VendorID);
            //            cmd.Parameters["@UGM_VendorID"].Direction = ParameterDirection.Input;

            //            string RC;
            //            using (SqlCommand cmdrc = new SqlCommand())
            //            {
            //                cmdrc.Connection = lconn;

            //                cmdrc.CommandText = "sp_get_user_group_master_count";
            //                cmdrc.CommandType = CommandType.StoredProcedure;
            //                SqlDataReader rdrrc = cmdrc.ExecuteReader();
            //                rdrrc.Read();
            //                RC = rdrrc["RC"].ToString();
            //                rdrrc.Close();
            //            }

            //            SqlDataAdapter dta = new SqlDataAdapter();
            //            dta.SelectCommand = cmd;
            //            DataSet Ds = new DataSet();
            //            dta.Fill(Ds);

            //            if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
            //            {
            //                foreach (DataRow rdr in Ds.Tables[0].Rows)
            //                {
            //                    ReturnUserGroupMasterModel objData = new ReturnUserGroupMasterModel();


            //                    objHead.resp = true;
            //                    objHead.msg = "UserGroup Master";

            //                    objData.UGM_ID = rdr["UGM_ID"].ToString();
            //                    objData.UGM_Name = rdr["UGM_Name"].ToString();
            //                    objData.UGM_Type = rdr["UGM_Type"].ToString();
            //                    objData.UGM_VendorID = rdr["UGM_VendorID"].ToString();
            //                    objData.UGM_DisplaySeq = rdr["UGM_DisplaySeq"].ToString();
            //                    objData.UGM_Status = rdr["UGM_Status"].ToString();

            //                    objData.RC = RC;

            //                    if (objHead.UserGroupMaster == null)
            //                    {
            //                        objHead.UserGroupMaster = new List<ReturnUserGroupMasterModel>();
            //                    }

            //                    objHead.UserGroupMaster.Add(objData);

            //                    //objHeadList.Add(objHead);

            //                }
            //                objHeadList.Add(objHead);

            //            }
            //            else
            //            {
            //                objHead.resp = true;
            //                objHead.msg = "";
            //                objHeadList.Add(objHead);
            //            }
            //        }
            //        return objHeadList;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ReturUserGroupMasterModelHead objMTHead = new ReturUserGroupMasterModelHead
            //    {
            //        resp = false,
            //        msg = ex.Message.ToString()
            //    };
            //    objHeadList.Add(objMTHead);

            //    objError.WriteLog(0, "UserGroupMaster_Data", "modify_user_group_master", "Stack Track: " + ex.StackTrace);
            //    objError.WriteLog(0, "UserGroupMaster_Data", "modify_user_group_master", "Error Message: " + ex.Message);
            //    if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
            //    {
            //        objError.WriteLog(0, "UserGroupMaster_Data", "modify_user_group_master", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
            //        objError.WriteLog(0, "UserGroupMaster_Data", "modify_user_group_master", "Inner Exception Message: " + ex.InnerException.Message);
            //    }


            //}

            return objHeadList;

        }
    }
}








