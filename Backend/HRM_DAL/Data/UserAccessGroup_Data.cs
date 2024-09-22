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
    public class UserRoleAccessGroup_Data
    {
        private static LogError objError = new LogError();

        public static List<ReturnUserRoleAccessGroupModelHead> get_UserRoleAccessGroups_single(UserRoleAccessGroup model)//ok
        {
            List<ReturnUserRoleAccessGroupModelHead> objUserRoleAccessGroupHeadList = new List<ReturnUserRoleAccessGroupModelHead>();
            ReturnUserRoleAccessGroupModelHead objUserRoleAccessGroupHead = new ReturnUserRoleAccessGroupModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objUserRoleAccessGroupHead.resp = false;
                objUserRoleAccessGroupHead.IsAuthenticated = false;
                objUserRoleAccessGroupHeadList.Add(objUserRoleAccessGroupHead);
                return objUserRoleAccessGroupHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "sp_get_UserRoleAccessGroups_single";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UURAG_UserRoleAccessGroupID", model.UURAG_UserRoleAccessGroupID);
                        cmd.Parameters["@UURAG_UserRoleAccessGroupID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnUserRoleAccessGroupModel objUserRoleAccessGroup = new ReturnUserRoleAccessGroupModel();

                                objUserRoleAccessGroupHead.resp = true;
                                objUserRoleAccessGroupHead.msg = "Get UserRoleAccessGroup";

                                //objUserRoleAccessGroup.UURAG_UserRoleAccessGroupID = rdr["UURAG_UserRoleAccessGroupID"].ToString();
                                //objUserRoleAccessGroup.UURAG_LeaveAlotment = Convert.ToInt16(rdr["UURAG_LeaveAlotment"].ToString());
                                //objUserRoleAccessGroup.UURAG_UserRoleAccessGroup = rdr["UURAG_UserRoleAccessGroup"].ToString();
                                //objUserRoleAccessGroup.UURAG_Status = Convert.ToBoolean(rdr["UURAG_Status"].ToString());

                                if (objUserRoleAccessGroupHead.UserRoleAccessGroup == null)
                                {
                                    objUserRoleAccessGroupHead.UserRoleAccessGroup = new List<ReturnUserRoleAccessGroupModel>();
                                }

                                objUserRoleAccessGroupHead.UserRoleAccessGroup.Add(objUserRoleAccessGroup);

                                objUserRoleAccessGroupHeadList.Add(objUserRoleAccessGroupHead);
                            }

                        }
                        else
                        {
                            ReturnUserRoleAccessGroupModel objUserRoleAccessGroup = new ReturnUserRoleAccessGroupModel();
                            objUserRoleAccessGroupHead.resp = true;
                            objUserRoleAccessGroupHead.msg = "";
                            objUserRoleAccessGroupHeadList.Add(objUserRoleAccessGroupHead);


                        }


                    }
                    return objUserRoleAccessGroupHeadList;

                }
            }
            catch (Exception ex)
            {
                objUserRoleAccessGroupHead = new ReturnUserRoleAccessGroupModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserRoleAccessGroupHeadList.Add(objUserRoleAccessGroupHead);

                objError.WriteLog(0, "UserRoleAccessGroup_Data", "get_UserRoleAccessGroups_single", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserRoleAccessGroup_Data", "get_UserRoleAccessGroups_single", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserRoleAccessGroup_Data", "get_UserRoleAccessGroups_single", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserRoleAccessGroup_Data", "get_UserRoleAccessGroups_single", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserRoleAccessGroupHeadList;

        }

        public static List<ReturnUserRoleAccessGroupModelHead> get_UserRoleAccessGroup_all(UserRoleAccessGroupSearchModel model)//ok
        {
            List<ReturnUserRoleAccessGroupModelHead> objUserRoleAccessGroupHeadList = new List<ReturnUserRoleAccessGroupModelHead>();
            ReturnUserRoleAccessGroupModelHead objUserRoleAccessGroupHead = new ReturnUserRoleAccessGroupModelHead();

            if (login_Data.AuthenticationKeyValidateWithDB(model) == false)
            {
                objUserRoleAccessGroupHead.resp = false;
                objUserRoleAccessGroupHead.IsAuthenticated = false;
                objUserRoleAccessGroupHeadList.Add(objUserRoleAccessGroupHead);
                return objUserRoleAccessGroupHeadList;
            }

            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;
                        lconn.Open();

                        cmd.CommandText = "get_UserRoleAccessGroup_all";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UURAG_UserRoleAccessGroupID", model.UURAG_UserRoleAccessGroupID);
                        cmd.Parameters["@UURAG_UserRoleAccessGroupID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnUserRoleAccessGroupModel objUserRoleAccessGroup = new ReturnUserRoleAccessGroupModel();

                                objUserRoleAccessGroupHead.resp = true;
                                objUserRoleAccessGroupHead.msg = "Get UserRoleAccessGroup";

                                //objUserRoleAccessGroup.UURAG_UserRoleAccessGroupID = rdr["UURAG_UserRoleAccessGroupID"].ToString();
                                //objUserRoleAccessGroup.UURAG_LeaveAlotment = Convert.ToInt16(rdr["UURAG_LeaveAlotment"].ToString());
                                //objUserRoleAccessGroup.UURAG_UserRoleAccessGroup = rdr["UURAG_UserRoleAccessGroup"].ToString();
                                //objUserRoleAccessGroup.UURAG_Status = Convert.ToBoolean(rdr["UURAG_Status"].ToString());

                                if (objUserRoleAccessGroupHead.UserRoleAccessGroup == null)
                                {
                                    objUserRoleAccessGroupHead.UserRoleAccessGroup = new List<ReturnUserRoleAccessGroupModel>();
                                }

                                objUserRoleAccessGroupHead.UserRoleAccessGroup.Add(objUserRoleAccessGroup);

                                objUserRoleAccessGroupHeadList.Add(objUserRoleAccessGroupHead);
                            }

                        }
                        else
                        {
                            ReturnUserRoleAccessGroupModel objUserRoleAccessGroup = new ReturnUserRoleAccessGroupModel();
                            objUserRoleAccessGroupHead.resp = true;
                            objUserRoleAccessGroupHead.msg = "";
                            objUserRoleAccessGroupHeadList.Add(objUserRoleAccessGroupHead);


                        }


                    }
                    return objUserRoleAccessGroupHeadList;

                }
            }
            catch (Exception ex)
            {
                objUserRoleAccessGroupHead = new ReturnUserRoleAccessGroupModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objUserRoleAccessGroupHeadList.Add(objUserRoleAccessGroupHead);

                objError.WriteLog(0, "UserRoleAccessGroup_Data", "get_UserRoleAccessGroup_all", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserRoleAccessGroup_Data", "get_UserRoleAccessGroup_all", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserRoleAccessGroup_Data", "get_UserRoleAccessGroup_all", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserRoleAccessGroup_Data", "get_UserRoleAccessGroup_all", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }

            return objUserRoleAccessGroupHeadList;

        }

        public static List<ReturnResponse> add_new_UserRoleAccessGroup(UserRoleAccessGroupModel item)//ok
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


                        cmd.CommandText = "sp_insert_UserRoleAccessGroup";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UURAG_UserRoleAccessGroupID", item.UURAG_UserRoleAccessGroupID);
                        cmd.Parameters["@UURAG_UserRoleAccessGroupID"].Direction = ParameterDirection.Input;

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

                        string mailtypes = "";

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

                objError.WriteLog(0, "UserRoleAccessGroup_Data", "add_new_UserRoleAccessGroup", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserRoleAccessGroup_Data", "add_new_UserRoleAccessGroup", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserRoleAccessGroup_Data", "add_new_UserRoleAccessGroup", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserRoleAccessGroup_Data", "add_new_UserRoleAccessGroup", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> modify_UserRoleAccessGroup(UserRoleAccessGroupModel item)//ok
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


                        cmd.CommandText = "sp_modify_UserRoleAccessGroup";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UD_UserID", item.UD_UserID);
                        cmd.Parameters["@UD_UserID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@UURAG_UserRoleAccessGroupID", item.UURAG_UserRoleAccessGroupID);
                        cmd.Parameters["@UURAG_UserRoleAccessGroupID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "UserRoleAccessGroup_Data", "add_new_UserRoleAccessGroup", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserRoleAccessGroup_Data", "add_new_UserRoleAccessGroup", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserRoleAccessGroup_Data", "add_new_UserRoleAccessGroup", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserRoleAccessGroup_Data", "add_new_UserRoleAccessGroup", "Inner Exception Message: " + ex.InnerException.Message);
                }

            }
            return objCustHeadList;
        }

        public static List<ReturnResponse> inactivate_UserRoleAccessGroup(InactiveUUMAModel item)//ok
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



                        cmd.CommandText = "sp_del_UserRoleAccessGroup";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UURAG_UserRoleAccessGroupID", item.UURAG_UserRoleAccessGroupID);
                        cmd.Parameters["@UURAG_UserRoleAccessGroupID"].Direction = ParameterDirection.Input;

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

                objError.WriteLog(0, "UserRoleAccessGroup_Data", "inactivate_UserRoleAccessGroup", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "UserRoleAccessGroup_Data", "inactivate_UserRoleAccessGroup", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "UserRoleAccessGroup_Data", "inactivate_UserRoleAccessGroup", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "UserRoleAccessGroup_Data", "inactivate_UserRoleAccessGroup", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return objUserHeadList;
            }



        }
    }

}

