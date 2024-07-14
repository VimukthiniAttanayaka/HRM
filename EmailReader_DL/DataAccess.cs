using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using static EmailReader_DL.OutLookEmailRead;

namespace EmailReader_DL
{
    public class DataAccess
    {
        static string errorLogPath = ConfigCaller.ErrorLogPath;

        public bool insert_mail_records(ExceptionMailReaderTable model)
        {
            bool isSucess = true;

            try
            {
                using (SqlConnection lconn = new SqlConnection(ConfigCaller.ConnectionString))
                {
                    if (lconn.State == ConnectionState.Closed)
                    {
                        lconn.Open();
                    }

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_insert_mail_records";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@status", model.EmailReplyStatus);
                        cmd.Parameters["@status"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BatchNo", model.BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EmailFrom", model.EmailFrom);
                        cmd.Parameters["@EmailFrom"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@Subject", model.Subject);
                        cmd.Parameters["@Subject"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@TransactionDateTime", model.TransactionDateTime);
                        cmd.Parameters["@TransactionDateTime"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EmailBody", model.MailBody);
                        cmd.Parameters["@EmailBody"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@EmailFor", model.EmailFor);
                        cmd.Parameters["@EmailFor"].Direction = ParameterDirection.Input;

                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rdr in ds.Tables[0].Rows)
                            {
                                isSucess = Boolean.Parse(rdr["SuccessFlag"].ToString());
                            }
                        }
                        else
                        {
                            EmailReader_DL.DataAccess.WriteLog("insert_mail_records", "Empty Tables");
                            isSucess = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog("insert_mail_records", ex.Message);
                isSucess = false;
            }

            return isSucess;
        }

        public static void UpdateOutgoingExceptionStatus(ExceptionMailReaderTable model)
        {
            try
            {
                using (SqlConnection lconn = new SqlConnection(ConfigCaller.ConnectionString))
                {
                    if (lconn.State == ConnectionState.Closed)
                    {
                        lconn.Open();
                    }

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_UpdateOutgoingExceptionStatus";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ExceptionStatus", model.ExceptionStatus);
                        cmd.Parameters["@ExceptionStatus"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@BatchNo", model.BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;


                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                    }
                }
            }
            catch (System.Exception ex)
            {
                EmailReader_DL.DataAccess.WriteLog("MainFlow1", "Fail " + ex.Message + " - " + ex.StackTrace);
            }
        }

        public static ReturnSystemPMModel get_system_parameter_single(string SP_ID)//ok
        {
            ReturnSystemPMModel objSPMData = new ReturnSystemPMModel();
            SqlConnection lconn = new SqlConnection(ConfigCaller.ConnectionString);
            try
            {
                if (lconn.State == ConnectionState.Closed)
                {
                    lconn.Open();
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = lconn;

                    cmd.CommandText = "sp_get_system_parameter_single";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SP_ID", SP_ID);
                    cmd.Parameters["@SP_ID"].Direction = ParameterDirection.Input;

                    SqlDataAdapter dta = new SqlDataAdapter();
                    dta.SelectCommand = cmd;
                    DataSet Ds = new DataSet();
                    dta.Fill(Ds);

                    if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow rdr in Ds.Tables[0].Rows)
                        {
                            objSPMData = new ReturnSystemPMModel();

                            objSPMData.SP_ID = rdr["SP_ID"].ToString();
                            objSPMData.SP_Description = rdr["SP_Description"].ToString();
                            objSPMData.SP_Value = rdr["SP_Value"].ToString();
                            objSPMData.SP_Type = rdr["SP_Type"].ToString();
                            objSPMData.SP_DisplaySeq = Convert.ToInt32(rdr["SP_DisplaySeq"]);
                        }
                    }
                }

                if (lconn.State == ConnectionState.Open)
                {
                    lconn.Close();
                }

                return objSPMData;

            }
            catch (System.Exception ex)
            {
                if (lconn.State == ConnectionState.Open)
                {
                    lconn.Close();
                }
                EmailReader_DL.DataAccess.WriteLog("get_system_parameter_single", "Fail " + ex.Message + " - " + ex.StackTrace);
            }

            return objSPMData;

        }

        public static OutgoingmailBatchModel get_batchno_details_ExceptionEmail(string BatchNo)
        {
            OutgoingmailBatchModel objEnquiryDetail = new OutgoingmailBatchModel();

            try
            {
                using (SqlConnection lconn = new SqlConnection(ConfigCaller.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = lconn;

                        cmd.CommandText = "sp_get_batchno_details_ExceptionEmail";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@BatchNo", BatchNo);
                        cmd.Parameters["@BatchNo"].Direction = ParameterDirection.Input;

                        SqlDataAdapter dta = new SqlDataAdapter();
                        dta.SelectCommand = cmd;
                        DataSet Ds = new DataSet();
                        dta.Fill(Ds);

                        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                        {

                            foreach (DataRow rdr in Ds.Tables[0].Rows)
                            {
                                DateTime trdate = DateTime.MinValue;
                                DateTime.TryParse(rdr["TransactionDateTime"].ToString(), out trdate);

                                //decimal decQty = 0;
                                //decimal.TryParse(rdr["Quantity"].ToString(), out decQty);

                                //decimal recQty = 0;
                                //decimal.TryParse(rdr["PostageTotal"].ToString(), out recQty);

                                objEnquiryDetail = new OutgoingmailBatchModel()
                                {
                                    BatchNo = rdr["BatchNumber"].ToString(),
                                    TransactionDate = trdate,
                                    ExceptionType = rdr["ExceptionType"].ToString(),
                                    ExceptionStatus = rdr["ExceptionStatus"].ToString(),
                                    Status = rdr["Status"].ToString(),
                                    //Quantity = decQty,
                                    //PostageTotal = recQty
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EmailReader_DL.DataAccess.WriteLog("get_batchno_details_ExceptionEmail", "Fail " + ex.Message + " - " + ex.StackTrace);
            }

            return objEnquiryDetail;
        }

        public static bool WriteLog(string LogText, string Action)
        {

            try
            {
                if (errorLogPath == string.Empty)
                {
                    return false;
                }


                if (!System.IO.Directory.Exists(errorLogPath))
                {
                    System.IO.Directory.CreateDirectory(errorLogPath);
                }


                string strFileName = errorLogPath + "\\" + "EmailReader" + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

                StringBuilder strLog = new StringBuilder();
                strLog.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - ");
                strLog.Append(" EmailReader ");
                strLog.Append(" - " + Action);
                strLog.Append(" - " + LogText);

                if (!System.IO.File.Exists(strFileName))
                {
                    using (System.IO.StreamWriter sw = System.IO.File.CreateText(strFileName))
                    {
                        sw.WriteLine(strLog.ToString());
                    }
                }
                else
                {
                    using (System.IO.StreamWriter sw = System.IO.File.AppendText(strFileName))
                    {
                        sw.WriteLine(strLog.ToString());
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public class OutgoingmailBatchModel
    {
        public string BatchNo { get; set; }
        public DateTime TransactionDate { get; set; }
        //public string Location { get; set; }
        //public string LocationID { get; set; }
        //public string KioskID { get; set; }
        //public string StaffName { get; set; }
        //public string Staff_ID { get; set; }
        //public string PCCode { get; set; }
        //public string MailType { get; set; }
        //public string MailTypeID { get; set; }
        //public string TrackingNumber { get; set; }
        //public decimal Quantity { get; set; }
        //public decimal PostageTotal { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionStatus { get; set; }
        public string Status { get; set; }
    }
}
