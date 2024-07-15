using DayEndProcess_DL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace utility_handler.Data
{
    public class SystemParameter_Data
    {
        public static List<ReturSystemPMModelHead> get_system_parameter_all(GetSystemPMAllModel SPMall)//ok
        {
            List<ReturSystemPMModelHead> objSPMHeadList = new List<ReturSystemPMModelHead>();
            List<ReturnSystemPMModel> objSPMList = new List<ReturnSystemPMModel>();

            SqlConnection lconn = new SqlConnection(ConfigCaller.ConnectionString);
            try
            {
                if (lconn.State == ConnectionState.Closed)
                {
                    lconn.Open();
                }

                ReturSystemPMModelHead objSPMHead = new ReturSystemPMModelHead();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = lconn;

                    cmd.CommandText = "sp_get_system_parameter_all";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PAGE_NO", SPMall.PAGE_NO);
                    cmd.Parameters["@PAGE_NO"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@PAGE_RECORDS_COUNT", SPMall.PAGE_RECORDS_COUNT);
                    cmd.Parameters["@PAGE_RECORDS_COUNT"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@SP_ID", SPMall.SP_ID);
                    cmd.Parameters["@SP_ID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@SP_Description", SPMall.SP_Description);
                    cmd.Parameters["@SP_Description"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@SP_Value", SPMall.SP_Value);
                    cmd.Parameters["@SP_Value"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@SP_Type", SPMall.SP_Type);
                    cmd.Parameters["@SP_Type"].Direction = ParameterDirection.Input;

                    string RC;
                    using (SqlCommand cmdrc = new SqlCommand())
                    {
                        cmdrc.Connection = lconn;

                        cmdrc.CommandText = "sp_get_system_parameter_count";
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
                            ReturnSystemPMModel objSPMData = new ReturnSystemPMModel();


                            objSPMHead.resp = true;
                            objSPMHead.msg = "System Parameter";

                            objSPMData.SP_ID = rdr["SP_ID"].ToString();
                            objSPMData.SP_Description = rdr["SP_Description"].ToString();
                            objSPMData.SP_Value = rdr["SP_Value"].ToString();
                            objSPMData.SP_Type = rdr["SP_Type"].ToString();
                            objSPMData.SP_DisplaySeq = Convert.ToInt32(rdr["SP_DisplaySeq"]);
                            objSPMData.RC = RC;

                            objSPMList.Add(objSPMData);

                            if (objSPMHead.SystemPM == null)
                            {
                                objSPMHead.SystemPM = new List<ReturnSystemPMModel>();
                            }

                            objSPMHead.SystemPM.Add(objSPMData);

                            //objSPMHeadList.Add(objSPMHead);

                        }
                        objSPMHeadList.Add(objSPMHead);

                    }
                    else
                    {
                        objSPMHead.resp = true;
                        objSPMHead.msg = "";
                        objSPMHeadList.Add(objSPMHead);
                    }
                }

                if (lconn.State == ConnectionState.Open)
                {
                    lconn.Close();
                }

                return objSPMHeadList;

            }
            catch (Exception ex)
            {
                if (lconn.State == ConnectionState.Open)
                {
                    lconn.Close();
                }
                ReturSystemPMModelHead objSPMHead = new ReturSystemPMModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objSPMHeadList.Add(objSPMHead);

                DayEndProcess_Data.WriteLog("get_system_parameter_all", "Fail " + ex.Message + " - " + ex.StackTrace);
            }

            return objSPMHeadList;

        }

        public static List<ReturSystemPMModelHead> get_system_parameter_single(GetSystemPMSingleModel SPMsingle)//ok
        {
            List<ReturSystemPMModelHead> objSPMHeadList = new List<ReturSystemPMModelHead>();
            List<ReturnSystemPMModel> objSPMList = new List<ReturnSystemPMModel>();

            SqlConnection lconn = new SqlConnection(ConfigCaller.ConnectionString);
            try
            {
                if (lconn.State == ConnectionState.Closed)
                {
                    lconn.Open();
                }

                ReturSystemPMModelHead objSPMHead = new ReturSystemPMModelHead();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = lconn;

                    cmd.CommandText = "sp_get_system_parameter_single";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SP_ID", SPMsingle.SP_ID);
                    cmd.Parameters["@SP_ID"].Direction = ParameterDirection.Input;

                    SqlDataAdapter dta = new SqlDataAdapter();
                    dta.SelectCommand = cmd;
                    DataSet Ds = new DataSet();
                    dta.Fill(Ds);

                    if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow rdr in Ds.Tables[0].Rows)
                        {
                            ReturnSystemPMModel objSPMData = new ReturnSystemPMModel();


                            objSPMHead.resp = true;
                            objSPMHead.msg = "System Parameter";

                            objSPMData.SP_ID = rdr["SP_ID"].ToString();
                            objSPMData.SP_Description = rdr["SP_Description"].ToString();
                            objSPMData.SP_Value = rdr["SP_Value"].ToString();
                            objSPMData.SP_Type = rdr["SP_Type"].ToString();
                            objSPMData.SP_DisplaySeq = Convert.ToInt32(rdr["SP_DisplaySeq"]);
                            objSPMData.RC = "1";

                            objSPMList.Add(objSPMData);

                            if (objSPMHead.SystemPM == null)
                            {
                                objSPMHead.SystemPM = new List<ReturnSystemPMModel>();
                            }

                            objSPMHead.SystemPM.Add(objSPMData);

                            //objSPMHeadList.Add(objSPMHead);

                        }
                        objSPMHeadList.Add(objSPMHead);

                    }
                    else
                    {
                        objSPMHead.resp = true;
                        objSPMHead.msg = "";
                        objSPMHeadList.Add(objSPMHead);
                    }
                }

                if (lconn.State == ConnectionState.Open)
                {
                    lconn.Close();
                }

                return objSPMHeadList;

            }
            catch (Exception ex)
            {
                if (lconn.State == ConnectionState.Open)
                {
                    lconn.Close();
                }
                ReturSystemPMModelHead objSPMHead = new ReturSystemPMModelHead
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objSPMHeadList.Add(objSPMHead);

                DayEndProcess_Data.WriteLog("get_system_parameter_single", "Fail " + ex.Message + " - " + ex.StackTrace);
            }

            return objSPMHeadList;

        }

        public static List<ReturnResponse> modify_system_parameter(SystemPMModel item)//ok
        {
            List<ReturnResponse> objMTHeadList = new List<ReturnResponse>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(ConfigCaller.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_modify_system_parameter";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@SP_ID", item.SP_ID);
                        cmd.Parameters["@SP_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@SP_Description", item.SP_Description);
                        cmd.Parameters["@SP_Description"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@SP_Value", item.SP_Value);
                        cmd.Parameters["@SP_Value"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@SP_DisplaySeq", item.SP_DisplaySeq);
                        cmd.Parameters["@SP_DisplaySeq"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@SP_Type", item.SP_Type);
                        cmd.Parameters["@SP_Type"].Direction = ParameterDirection.Input;

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
                                ReturnResponse objMTHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objMTHeadList.Add(objMTHead);

                                //objUserSList.Add(objUserHead.objReturnUserModelList);


                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ReturnResponse objMTHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMTHeadList.Add(objMTHead);

                DayEndProcess_Data.WriteLog("modify_system_parameter", "Fail " + ex.Message + " - " + ex.StackTrace);

            }
            return objMTHeadList;
        }

        public static List<ReturnResponse> system_parameter_mark_inactive(string SP_ID, string User_ID)//ok
        {
            List<ReturnResponse> objMTHeadList = new List<ReturnResponse>();

            try
            {
                using (SqlConnection lconn = new SqlConnection(ConfigCaller.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_system_parameter_mark_inactive";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@SP_ID", SP_ID);
                        cmd.Parameters["@SP_ID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@USER_ID", User_ID);
                        cmd.Parameters["@USER_ID"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                ReturnResponse objMTHead = new ReturnResponse
                                {
                                    resp = Boolean.Parse(rdr["RTN_RESP"].ToString()),
                                    msg = rdr["RTN_MSG"].ToString()
                                };
                                objMTHeadList.Add(objMTHead);

                                //objUserSList.Add(objUserHead.objReturnUserModelList);


                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ReturnResponse objMTHead = new ReturnResponse
                {
                    resp = false,
                    msg = ex.Message.ToString()
                };
                objMTHeadList.Add(objMTHead);

                DayEndProcess_Data.WriteLog("system_parameter_mark_inactive", "Fail " + ex.Message + " - " + ex.StackTrace);

            }
            return objMTHeadList;
        }

        public class PredefinedProperties
        {
            public static ReturnSystemPMModel IsTransnationalPINUser()//ok
            {
                List<ReturSystemPMModelHead> tem = new List<ReturSystemPMModelHead>();

                try
                {
                    tem = get_system_parameter_single(new GetSystemPMSingleModel() { SP_ID = "IsTransnationalPINUser" });

                    if (tem != null && tem.Count > 0 && tem[0].SystemPM != null && tem[0].SystemPM.Count > 0)
                    {
                        return tem[0].SystemPM[0];
                    }
                }
                catch (Exception ex)
                {
                    DayEndProcess_Data.WriteLog("IsTransnationalPINUser", "Fail " + ex.Message + " - " + ex.StackTrace);
                }

                return null;

            }

            public class ServiceRelated
            {
                public static ReturnSystemPMModel DayEndProcess_Batch_Summery_Email_Active()//ok
                {
                    List<ReturSystemPMModelHead> tem = new List<ReturSystemPMModelHead>();

                    try
                    {
                        tem = get_system_parameter_single(new GetSystemPMSingleModel() { SP_ID = "DayEndProcess_Batch_Summery_Email_Active" });

                        if (tem != null && tem.Count > 0 && tem[0].SystemPM != null && tem[0].SystemPM.Count > 0)
                        {
                            return tem[0].SystemPM[0];
                        }
                    }
                    catch (Exception ex)
                    {
                        DayEndProcess_Data.WriteLog("DayEndProcess_Batch_Summery_Email_Active", "Fail " + ex.Message + " - " + ex.StackTrace);
                    }

                    return null;

                }

                public class UpdateRelated
                {
                    public static ReturnResponse DayEndProcess_Batch_Summery_Email_MarkInactive()//ok
                    {
                        string SP_ID = "DayEndProcess_Batch_Summery_Email_Active";

                        List<ReturnResponse> ret = new List<ReturnResponse>();
                        List<ReturSystemPMModelHead> tem = new List<ReturSystemPMModelHead>();

                        try
                        {
                            tem = get_system_parameter_single(new GetSystemPMSingleModel() { SP_ID = SP_ID });

                            if (tem != null && tem.Count > 0 && tem[0].SystemPM != null && tem[0].SystemPM.Count > 0)
                            {
                                ret = system_parameter_mark_inactive(SP_ID, "DayEndProces");
                            }
                        }
                        catch (Exception ex)
                        {
                            ret.Add(new ReturnResponse() { msg = ex.Message, resp = false });

                            DayEndProcess_Data.WriteLog("DayEndProcess_Batch_Summery_Email_MarkInactive", "Fail " + ex.Message + " - " + ex.StackTrace);
                        }

                        return ret.FirstOrDefault();

                    }
                }
            }
        }
        public class ReturnSystemPMModel
        {
            [Key]
            public string SP_ID { get; set; }
            public string SP_Description { get; set; }
            public string SP_Value { get; set; }
            public string SP_Type { get; set; }
            public int SP_DisplaySeq { get; set; }
            public string RC { get; set; }


        }
        public class SystemPMModel
        {
            [Key]
            public string SP_ID { get; set; }
            public string SP_Description { get; set; }
            public string SP_Value { get; set; }
            public string SP_Type { get; set; }
            public int SP_DisplaySeq { get; set; }
            public string USER_ID { get; set; }


        }
        public class GetSystemPMAllModel
        {

            public string PAGE_NO { get; set; }
            public string PAGE_RECORDS_COUNT { get; set; }
            public string SP_ID { get; set; }
            public string SP_Description { get; set; }
            public string SP_Value { get; set; }
            public string SP_Type { get; set; }



        }
        public class GetSystemPMSingleModel
        {

            public string SP_ID { get; set; }

        }

        public class ReturSystemPMModelHead
        {
            public bool resp { get; set; }
            public string msg { get; set; }
            public List<ReturnSystemPMModel> SystemPM { get; set; }


        }

        public class ReturSystemPMSingleModelHead
        {
            public bool resp { get; set; }
            public string msg { get; set; }
            public List<ReturnSystemPMSingleModel> systempmsingle { get; set; }


        }

        public class ReturnSystemPMSingleModel
        {
            [Key]
            public string SP_ID { get; set; }
            public string SP_Description { get; set; }
            public string SP_Value { get; set; }
            public string SP_Type { get; set; }
            public int SP_DisplaySeq { get; set; }



        }
    }
}






