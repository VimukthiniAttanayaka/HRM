using error_handler;
using HRM_DAL.Models;
using HRM_DAL.Utility;
using Newtonsoft.Json;
using sms_core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using utility_handler.Data;
using utility_handler.Utility;

namespace HRM_DAL.Data
{
    public class EMAIL_SMS_Sender_Preperation
    {
        private static LogError objError = new LogError();

        internal static GetSMS_BusinessUnitModel GetSMS_BusinessUnit(string BU_ID)
        {
            GetSMS_BusinessUnitModel ump = new GetSMS_BusinessUnitModel();
            try
            {
                using (SqlConnection lconn = new SqlConnection(BaseClassDBCallerData.ConnectionString))
                {
                    SqlCommand cmdpw = new SqlCommand
                    {
                        Connection = lconn,
                        CommandText = "GetSMS_BusinessUnit",
                        CommandType = CommandType.StoredProcedure
                    };

                    cmdpw.Parameters.AddWithValue("@BU_ID", BU_ID);
                    cmdpw.Parameters["@BU_ID"].Direction = ParameterDirection.Input;

                    SqlDataAdapter dta = new SqlDataAdapter();
                    dta.SelectCommand = cmdpw;
                    DataSet Ds = new DataSet();
                    dta.Fill(Ds);

                    bool blBU_SMS_Enabled = false;
                    bool blBU_EMAIL_Enabled = false;
                    bool blBU_SMS_BY_LINKURL = false;
                    //bool blSMSOk = false;
                    bool blBU_EMAIL_SMTP_TLS_ENABLE = false;
                    bool blBU_EMAIL_SMTP_SSL_ENABLE = false;
                    bool blBU_EMAIL_SMTP_SSL_PROTOCOLS = false;

                    int intBU_EMAIL_SMTP_HOST_PORT = 0;

                    if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow rdr in Ds.Tables[0].Rows)
                        {
                            ump = new GetSMS_BusinessUnitModel();

                            bool.TryParse(rdr["BU_SMS_Enabled"].ToString(), out blBU_SMS_Enabled);
                            bool.TryParse(rdr["BU_SMS_BY_LINKURL"].ToString(), out blBU_SMS_BY_LINKURL);
                            //bool.TryParse(rdr["SMSOk"].ToString(), out blSMSOk);

                            bool.TryParse(rdr["BU_EMAIL_Enabled"].ToString(), out blBU_EMAIL_Enabled);

                            ump.BU_SMS_Enabled = blBU_SMS_Enabled;
                            ump.BU_EMAIL_Enabled = blBU_EMAIL_Enabled;
                            ump.BU_SMS_GW_HOST_IP = rdr["BU_SMS_GW_HOST_IP"].ToString();

                            ump.BU_SMS_GW_HOST_PORT = rdr["BU_SMS_GW_HOST_PORT"].ToString();
                            ump.BU_SMS_GW_JID = rdr["BU_SMS_GW_JID"].ToString();
                            var BU_SMS_GW_PWD = rdr["BU_SMS_GW_PWD"].ToString();
                            ump.BU_SMS_GW_PWD = Misc.deCrypt(BU_SMS_GW_PWD);
                            ump.BU_SMS_GW_IIM_SVR = rdr["BU_SMS_GW_IIM_SVR"].ToString();
                            ump.BU_SMS_GW_SMS_LIMIT = rdr["BU_SMS_GW_SMS_LIMIT"].ToString();
                            ump.BU_SMS_GW_QUE_CAP = rdr["BU_SMS_GW_QUE_CAP"].ToString();
                            ump.BU_SMS_GW_MAX_CHAR = rdr["BU_SMS_GW_MAX_CHAR"].ToString();
                            ump.BU_SMS_GW_SENDER_ID = rdr["BU_SMS_GW_SENDER_ID"].ToString();
                            ump.BU_SMS_BY_LINKURL = blBU_SMS_BY_LINKURL;
                            //ump.SMSOk = blSMSOk;

                            bool.TryParse(rdr["BU_EMAIL_SMTP_TLS_ENABLE"].ToString(), out blBU_EMAIL_SMTP_TLS_ENABLE);
                            bool.TryParse(rdr["BU_EMAIL_SMTP_SSL_ENABLE"].ToString(), out blBU_EMAIL_SMTP_SSL_ENABLE);
                            bool.TryParse(rdr["BU_EMAIL_SMTP_SSL_PROTOCOLS"].ToString(), out blBU_EMAIL_SMTP_SSL_PROTOCOLS);

                            int.TryParse(rdr["BU_EMAIL_SMTP_HOST_PORT"].ToString(), out intBU_EMAIL_SMTP_HOST_PORT);

                            ump.BU_EMAIL_SMTP_HOST_IP = rdr["BU_EMAIL_SMTP_HOST_IP"].ToString();
                            ump.BU_EMAIL_SMTP_HOST_PORT = intBU_EMAIL_SMTP_HOST_PORT;
                            ump.BU_EMAIL_SMTP_UID = rdr["BU_EMAIL_SMTP_UID"].ToString();
                            var BU_EMAIL_SMTP_PWD = rdr["BU_EMAIL_SMTP_PWD"].ToString();
                            ump.BU_EMAIL_SMTP_PWD = Misc.deCrypt(BU_EMAIL_SMTP_PWD);
                            ump.BU_EMAIL_SMTP_AUTH = rdr["BU_EMAIL_SMTP_AUTH"].ToString();
                            ump.BU_EMAIL_SMTP_TLS_ENABLE = blBU_EMAIL_SMTP_TLS_ENABLE;
                            ump.BU_EMAIL_SMTP_SSL_ENABLE = blBU_EMAIL_SMTP_SSL_ENABLE;
                            ump.BU_EMAIL_SMTP_SSL_PROTOCOLS = blBU_EMAIL_SMTP_SSL_PROTOCOLS;
                            ump.BU_EMAIL_SMTP_SSL_SOCKET_FACTORY = rdr["BU_EMAIL_SMTP_SSL_SOCKET_FACTORY"].ToString();
                            ump.BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_CLASS = rdr["BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_CLASS"].ToString();
                            ump.BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_PORT = rdr["BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_PORT"].ToString();
                        }
                    }
                }

                GetSMS_BusinessUnitModel obj = ump.Clone() as GetSMS_BusinessUnitModel;
                if (obj != null)
                {
                    obj.BU_EMAIL_SMTP_PWD = "";
                    obj.BU_SMS_GW_PWD = "";
                }

                string logobject = JsonConvert.SerializeObject(obj);

                new WhiteLog("modify_sk_user_access_group - BU request read" + logobject, "EMAIL_SMS_Sender_Preperation", "GetSMS_BusinessUnit", true, false);
            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "EMAIL_SMS_Sender_Preperation", "GetSMS_BusinessUnit", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "EMAIL_SMS_Sender_Preperation", "GetSMS_BusinessUnit", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "EMAIL_SMS_Sender_Preperation", "GetSMS_BusinessUnit", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "EMAIL_SMS_Sender_Preperation", "GetSMS_BusinessUnit", "Inner Exception Message: " + ex.InnerException.Message);
                }
            }
            return ump;
        }

        internal class GetSMS_BusinessUnitModel : ICloneable
        {
            public bool BU_SMS_Enabled { get; set; }
            public string BU_SMS_GW_HOST_IP { get; set; }
            public string BU_SMS_GW_HOST_PORT { get; set; }
            public string BU_SMS_GW_JID { get; set; }
            public string BU_SMS_GW_PWD { get; set; }
            public string BU_SMS_GW_IIM_SVR { get; set; }
            public string BU_SMS_GW_SMS_LIMIT { get; set; }
            public string BU_SMS_GW_QUE_CAP { get; set; }
            public string BU_SMS_GW_MAX_CHAR { get; set; }
            public string BU_SMS_GW_SENDER_ID { get; set; }
            //public bool SMSOk { get; set; }
            public bool BU_SMS_BY_LINKURL { get; set; }
            public string BU_EMAIL_SMTP_HOST_IP { get; set; }
            public bool BU_EMAIL_Enabled { get; set; }
            public int BU_EMAIL_SMTP_HOST_PORT { get; set; }
            public string BU_EMAIL_SMTP_UID { get; set; }
            public string BU_EMAIL_SMTP_AUTH { get; set; }
            public bool BU_EMAIL_SMTP_TLS_ENABLE { get; set; }
            public string BU_EMAIL_SMTP_PWD { get; set; }
            public bool BU_EMAIL_SMTP_SSL_ENABLE { get; set; }
            public string BU_EMAIL_SMTP_SSL_SOCKET_FACTORY { get; set; }
            public string BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_CLASS { get; set; }
            public string BU_EMAIL_SMTP_SSL_SOCKET_FACTORY_PORT { get; set; }
            public bool BU_EMAIL_SMTP_SSL_PROTOCOLS { get; set; }

            public object Clone()
            {
                var person = (GetSMS_BusinessUnitModel)MemberwiseClone();
                //person.Address = (Address)Address.Clone();
                return person;
            }
        }
    }


}
