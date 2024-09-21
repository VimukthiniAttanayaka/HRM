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
    public class AccessGroup_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnAccessGroupModelHead> get_AccessGroups_single(AccessGroup model)//ok
        {
            List<ReturnAccessGroupModelHead> objAccessGroupHeadList = new List<ReturnAccessGroupModelHead>();
            ReturnAccessGroupModelHead objAccessGroupHead = new ReturnAccessGroupModelHead();

            if (objAccessGroupHead.AccessGroup == null)
            {
                objAccessGroupHead.AccessGroup = new List<ReturnAccessGroupModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objAccessGroupHead.resp = false;
                objAccessGroupHead.IsAuthenticated = false;
                objAccessGroupHeadList.Add(objAccessGroupHead);
                return objAccessGroupHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_AccessGroup_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UAG_AccessGroupID", model.UAG_AccessGroupID);
                        cmd.Parameters["@UAG_AccessGroupID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnAccessGroupModel objAccessGroup = new ReturnAccessGroupModel();

                                objAccessGroupHead.resp = true;
                                objAccessGroupHead.msg = "Get AccessGroup";

                                objAccessGroup.UAG_AccessGroupID = rdr["UAG_AccessGroupID"].ToString();
                                objAccessGroup.UAG_AccessGroup = rdr["UAG_AccessGroup"].ToString();
                                objAccessGroup.UAG_Status = Convert.ToBoolean(rdr["UAG_Status"].ToString());


                                objAccessGroupHead.AccessGroup.Add(objAccessGroup);

                                objAccessGroupHeadList.Add(objAccessGroupHead);
                            }

                        }
                        else
                        {
                            ReturnAccessGroupModel objAccessGroup = new ReturnAccessGroupModel();
                            objAccessGroupHead.resp = true;
                            objAccessGroupHead.msg = "";
                            objAccessGroupHeadList.Add(objAccessGroupHead);


                        }


                    }
                    return objAccessGroupHeadList;

                }
            }
            catch (Exception ex)
            {
                objAccessGroupHead = new ReturnAccessGroupModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objAccessGroupHeadList.Add(objAccessGroupHead);

                objError.WriteLog(0, "AccessGroup_Data", "get_AccessGroups_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "AccessGroup_Data", "get_AccessGroups_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "AccessGroup_Data", "get_AccessGroups_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "AccessGroup_Data", "get_AccessGroups_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objAccessGroupHeadList;

        }

        public static List<ReturnAccessGroupModelHead> get_AccessGroup_all(AccessGroupSearchModel model)//ok
        {
            List<ReturnAccessGroupModelHead> objAccessGroupHeadList = new List<ReturnAccessGroupModelHead>();
            ReturnAccessGroupModelHead objAccessGroupHead = new ReturnAccessGroupModelHead();

            if (objAccessGroupHead.AccessGroup == null)
            {
                objAccessGroupHead.AccessGroup = new List<ReturnAccessGroupModel>();
            }

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objAccessGroupHead.resp = false;
                objAccessGroupHead.IsAuthenticated = false;
                objAccessGroupHeadList.Add(objAccessGroupHead);
                return objAccessGroupHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_AccessGroup_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@UAG_AccessGroupID", model.UAG_AccessGroupID);
                        //cmd.Parameters["@UAG_AccessGroupID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnAccessGroupModel objAccessGroup = new ReturnAccessGroupModel();

                                objAccessGroupHead.resp = true;
                                objAccessGroupHead.msg = "Get AccessGroup";

                                objAccessGroup.UAG_AccessGroupID = rdr["UAG_AccessGroupID"].ToString();
                                objAccessGroup.UAG_AccessGroup = rdr["UAG_AccessGroup"].ToString();
                                objAccessGroup.UAG_Status = Convert.ToBoolean(rdr["UAG_Status"].ToString());


                                objAccessGroupHead.AccessGroup.Add(objAccessGroup);

                                objAccessGroupHeadList.Add(objAccessGroupHead);
                            }            
                        }
                        else
                        {
                            ReturnAccessGroupModel objAccessGroup = new ReturnAccessGroupModel();
                            objAccessGroupHead.resp = true;
                            objAccessGroupHead.msg = "";
                            objAccessGroupHeadList.Add(objAccessGroupHead);
                        }
                    }
                    return objAccessGroupHeadList;
                }
            }
            catch (Exception ex)
            {
                objAccessGroupHead.resp = false;
                objAccessGroupHead.msg = ex.Message.ToString();

                objAccessGroupHeadList.Add(objAccessGroupHead);

                objError.WriteLog(0, "AccessGroup_Data", "get_AccessGroup_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "AccessGroup_Data", "get_AccessGroup_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "AccessGroup_Data", "get_AccessGroup_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "AccessGroup_Data", "get_AccessGroup_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objAccessGroupHeadList;

        }

        public static List<ReturnResponse> add_new_AccessGroup(AccessGroupModel item)//ok
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


                        cmd.CommandText = "sp_insert_AccessGroup";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_AccessGroupID", item.UAG_AccessGroupID);
                        cmd.Parameters["@UAG_AccessGroupID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_AccessGroup", item.UAG_AccessGroup);
                        cmd.Parameters["@UAG_AccessGroup"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_Status", item.UAG_Status);
                        cmd.Parameters["@UAG_Status"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "AccessGroup_Data", "add_new_AccessGroup", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "AccessGroup_Data", "add_new_AccessGroup", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "AccessGroup_Data", "add_new_AccessGroup", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "AccessGroup_Data", "add_new_AccessGroup", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> modify_AccessGroup(AccessGroupModel item)//ok
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


                        cmd.CommandText = "sp_modify_AccessGroup";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UAG_AccessGroupID", item.UAG_AccessGroupID);
                        cmd.Parameters["@UAG_AccessGroupID"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_CompanyName", item.CUS_CompanyName);
                        //cmd.Parameters["@CUS_CompanyName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_BlockBuildingNo", item.CUS_Adrs_BlockBuildingNo);
                        //cmd.Parameters["@CUS_Adrs_BlockBuildingNo"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_BuildingName", item.CUS_Adrs_BuildingName);
                        //cmd.Parameters["@CUS_Adrs_BuildingName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_UnitNumber", item.CUS_Adrs_UnitNumber);
                        //cmd.Parameters["@CUS_Adrs_UnitNumber"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_StreetName", item.CUS_Adrs_StreetName);
                        //cmd.Parameters["@CUS_Adrs_StreetName"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_City", item.CUS_Adrs_City);
                        //cmd.Parameters["@CUS_Adrs_City"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_CountryCode", item.CUS_Adrs_CountryCode);
                        //cmd.Parameters["@CUS_Adrs_CountryCode"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Adrs_PostalCode", item.CUS_Adrs_PostalCode);
                        //cmd.Parameters["@CUS_Adrs_PostalCode"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_ContactPerson", item.CUS_ContactPerson);
                        //cmd.Parameters["@CUS_ContactPerson"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_ContactNumber", item.CUS_ContactNumber);
                        //cmd.Parameters["@CUS_ContactNumber"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_PinOrPwd", item.CUS_PinOrPwd);
                        //cmd.Parameters["@CUS_PinOrPwd"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_OTP_By_SMS", item.CUS_OTP_By_SMS);
                        //cmd.Parameters["@CUS_OTP_By_SMS"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_OTP_By_Email", item.CUS_OTP_By_Email);
                        //cmd.Parameters["@CUS_OTP_By_Email"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@CUS_Status", item.CUS_Status);
                        //cmd.Parameters["@CUS_Status"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "AccessGroup_Data", "add_new_AccessGroup", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "AccessGroup_Data", "add_new_AccessGroup", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "AccessGroup_Data", "add_new_AccessGroup", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "AccessGroup_Data", "add_new_AccessGroup", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_AccessGroup(InactiveEUGModel item)//ok
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



                        cmd.CommandText = "sp_del_AccessGroup";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UAG_AccessGroupID", item.UAG_AccessGroupID);
                        cmd.Parameters["@UAG_AccessGroupID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "AccessGroup_Data", "inactivate_AccessGroup", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "AccessGroup_Data", "inactivate_AccessGroup", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "AccessGroup_Data", "inactivate_AccessGroup", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "AccessGroup_Data", "inactivate_AccessGroup", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

