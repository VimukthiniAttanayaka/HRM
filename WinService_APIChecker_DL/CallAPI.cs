using MailTrak_DAL.Models;
using MailTrak_DAL.Models.RequestModels;
using MailTrak_DAL.Models.ResponceModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Web.Script.Serialization;
using MailTrak;

namespace Kioski_APIChecker_DL
{
    public static class CallAPI
    {
        static string errorLogPath = ConfigCaller.ErrorLogPath;// @"D:\ForeignProjects\MailTrak_Backend_V1.0\APIChecker\ErrorLog";// System.Configuration.ConfigurationManager.AppSettings["ErrorLogPath"];

        public static bool CallMailTrackerToDoKioskProcess_MailBag()
        {
            return CallMailBagTransactions_GetMailBag();
        }

        public static void CallMailTrackerToDoKioskProcess_AckBulk()
        {
            CallMailBagTransactions_AckBulk();
        }

        private static void CallMailBagTransactions_AckBulk()
        {
            try
            {
                string html = string.Empty;
                string url = "";
                url = ConfigCaller.MailTracker_GetMailbagURL;
                WriteLog("Step 1 " + url, "CallMailBagTransactions_AckBulk");

                var serializer = new JavaScriptSerializer();
                string DATA = serializer.Serialize(new
                {
                    userId = ConfigCaller.SyncWithMailTrackKiosk_UserID,
                    maxTransCount = ConfigCaller.SyncWithMailTrackKiosk_maxTransCount
                });

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = DATA.Length;
                //var username = ConfigCaller.UserName; //"MT01";
                //var password = ConfigCaller.Password; //"tWmL4ZXaj9";
                //string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                //                               .GetBytes(username + ":" + password));
                //request.Headers.Add("Authorization", "Basic " + encoded);
                //request.Headers.Add("RequestReferenceID", "1");
                //request.Headers.Add("RequestType", "Get_OAuthToken");
                //request.Headers.Add("MailTrakID", "1");
                StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
                requestWriter.Write(DATA);
                requestWriter.Close();

                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        html = reader.ReadToEnd();
                    }

                    WriteLog(html, "CallMailBagTransactions_AckBulk");

                    List<MailBagTransDto> model = new List<MailBagTransDto>();
                    model = serializer.Deserialize<List<MailBagTransDto>>(html);
                    if (model.Count > 0)
                    {
                        WriteLog("Step 9 ", "CallMailBagTransactions_AckBulk");
                    }

                    WriteLog(html, "CallMailBagTransactions_AckBulk");
                }
                catch (Exception ex)
                {

                    CallAPI.WriteLog(ex.Message, "CallMailBagTransactions_AckBulk");
                    throw ex;
                }
            }
            catch (Exception ex)
            {

                CallAPI.WriteLog(ex.Message, "CallMailBagTransactions_AckBulk");
                throw;
            }
        }

        public static bool CallMailBagTransactions_GetMailBag()
        {
            bool HasMailBagRecords = false;
            try
            {
                string html = string.Empty;
                string url = "";
                url = ConfigCaller.MailTracker_GetMailbagURL;
                WriteLog("Step 1 " + url, "CallMailBagTransactions_GetMailBag");

                var serializer = new JavaScriptSerializer();
                string DATA = serializer.Serialize(new
                {
                    userId = ConfigCaller.SyncWithMailTrackKiosk_UserID,
                    maxTransCount = ConfigCaller.SyncWithMailTrackKiosk_maxTransCount
                });

                html = API_Setup(url, DATA);

                try
                {

                    WriteLog(html, "CallMailBagTransactions_GetMailBag");

                    List<MailBagTransDto> model = new List<MailBagTransDto>();
                    model = serializer.Deserialize<List<MailBagTransDto>>(html);
                    ReturnResponse res = model.FirstOrDefault(a => a.msg == MailTrak.Common.Messages.KioskHasMultipleRecords);

                    if (model.Count > 0)
                    {
                        if (res != null)
                        //if (model.Count == 1 && model.Count(a => a.result == null) == 1)
                        { HasMailBagRecords = true; }
                        else { HasMailBagRecords = false; }

                        WriteLog("Step 9 ", "CallMailBagTransactions_GetMailBag HasMailBagRecords:" + HasMailBagRecords.ToString());
                        //AckMailBagTransactions(model.FirstOrDefault());
                    }

                    WriteLog(html, "CallMailBagTransactions_GetMailBag");
                }
                catch (Exception ex)
                {

                    CallAPI.WriteLog(ex.Message, "CallMailBagTransactions_GetMailBag");
                    throw ex;
                }
            }
            catch (Exception ex)
            {

                CallAPI.WriteLog(ex.Message, "CallMailBagTransactions_GetMailBag");
                throw;
            }
            return HasMailBagRecords;
        }

        private static string API_Setup(string url, string DATA)
        {
            string html = "";


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = DATA.Length;

            ServicePointManager.ServerCertificateValidationCallback = new
                RemoteCertificateValidationCallback
                (
                   delegate { return true; }
                );

            //var username = ConfigCaller.UserName; //"MT01";
            //var password = ConfigCaller.Password; //"tWmL4ZXaj9";
            //string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
            //                               .GetBytes(username + ":" + password));
            //request.Headers.Add("Authorization", "Basic " + encoded);
            //request.Headers.Add("RequestReferenceID", "1");
            //request.Headers.Add("RequestType", "Get_OAuthToken");
            //request.Headers.Add("MailTrakID", "1");
            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            requestWriter.Write(DATA);
            requestWriter.Close();

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            return html;
        }

        public static void AckMailBagTransactions(MailBagTransDto model)
        {
            try
            {
                string html = string.Empty;
                string url = "";
                url = ConfigCaller.MailTracker_AckMailbagURL;


                Ack_MailBagTrans_RequestModel obj = new Ack_MailBagTrans_RequestModel()
                {
                    userId = ConfigCaller.SyncWithMailTrackKiosk_UserID,
                    reqTransReferenceId = model.result.reqTransReferenceId,
                    reqTransType = "Get_MailBagTrans",
                    syncStatus = 1
                };

                var serializer = new JavaScriptSerializer();
                string DATA = serializer.Serialize(obj);

                WriteLog(DATA, "AckMailBagTransactions");
                WriteLog(url, "AckMailBagTransactions");


                html = API_Setup(url, DATA);

                try
                {
                    //WriteLog("Before Read", "AckMailBagTransactions");
                    //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    //using (Stream stream = response.GetResponseStream())
                    //using (StreamReader reader = new StreamReader(stream))
                    //{
                    //    html = reader.ReadToEnd();
                    //}

                    //List<MailTrack_ReturnResponce> list = new List<MailTrack_ReturnResponce>();
                    //list = serializer.Deserialize<List<MailTrack_ReturnResponce>>(html);
                    WriteLog(html, "AckMailBagTransactions");
                }
                catch (Exception ex)
                {
                    WriteLog("Not Submitted", "AckMailBagTransactions");
                    CallAPI.WriteLog(ex.Message, "AckMailBagTransactions");
                    throw ex;
                }
            }
            catch (Exception ex)
            {

                CallAPI.WriteLog(ex.Message, "AckMailBagTransactions");
                throw;
            }
        }

        //public static void GetToken()
        //{
        //    try
        //    {
        //        string html = string.Empty;
        //        string url = "";// @"https://localhost:44388/api/ItemType/get_item_type_all_list";
        //        url = ConfigCaller.API_TokenURL;// @"https://sk-uat-app.transnational-grp.com/api/token";// ConfigurationManager.AppSettings["API_TokenURL"].ToString();

        //        var serializer = new JavaScriptSerializer();
        //        string DATA = serializer.Serialize(new { grant_type = "client_credentials" });

        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //        request.Method = "POST";
        //        request.ContentType = "application/json";
        //        request.ContentLength = DATA.Length;
        //        var username = ConfigCaller.UserName; //"MT01";
        //        var password = ConfigCaller.Password; //"tWmL4ZXaj9";
        //        string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
        //                                       .GetBytes(username + ":" + password));
        //        request.Headers.Add("Authorization", "Basic " + encoded);
        //        request.Headers.Add("RequestReferenceID", "1");
        //        request.Headers.Add("RequestType", "Get_OAuthToken");
        //        request.Headers.Add("MailTrakID", "1");
        //        StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
        //        requestWriter.Write(DATA);
        //        requestWriter.Close();

        //        try
        //        {
        //            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //            using (Stream stream = response.GetResponseStream())
        //            using (StreamReader reader = new StreamReader(stream))
        //            {
        //                html = reader.ReadToEnd();
        //            }

        //            Token.Rootobject list = new Token.Rootobject();
        //            list = serializer.Deserialize<Token.Rootobject>(html);
        //            if (list != null && list.messageId == 1)
        //            {
        //                //System.IO.File.AppendAllText(errorLogPath, html);
        //                WriteLog(html, "GetToken");
        //                GetDepartment(list);
        //                GetMailbagTransactions(list);
        //                AckMailbagTransactions(list);
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //            CallAPI.WriteLog(ex.Message, "GetToken");
        //            throw ex;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        CallAPI.WriteLog(ex.Message, "GetToken");
        //        throw;
        //    }
        //}

        //public static void GetDepartment(Token.Rootobject list)
        //{
        //    try
        //    {
        //        string html = string.Empty;
        //        string url = "";// @"https://localhost:44388/api/ItemType/get_item_type_all_list";
        //        url = ConfigCaller.API_URL;// @"https://sk-uat-app.transnational-grp.com/api/department";// ConfigurationManager.AppSettings["API_URL"].ToString();

        //        var serializer = new JavaScriptSerializer();
        //        string DATA = serializer.Serialize(new { customerId = "DBS" });

        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //        request.Method = "POST";
        //        request.ContentType = "application/json";
        //        request.ContentLength = DATA.Length;
        //        //var username = "MT01";
        //        //var password = "tWmL4ZXaj9";
        //        string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
        //                                       .GetBytes(list.result.accessToken));

        //        request.Headers.Add("Authorization", "Bearer " + list.result.accessToken);
        //        request.Headers.Add("RequestReferenceID", "1");
        //        request.Headers.Add("RequestType", "Get_Departments");
        //        request.Headers.Add("MailTrakID", "2");
        //        StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
        //        requestWriter.Write(DATA);
        //        requestWriter.Close();

        //        try
        //        {
        //            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //            using (Stream stream = response.GetResponseStream())
        //            using (StreamReader reader = new StreamReader(stream))
        //            {
        //                html = reader.ReadToEnd();
        //            }

        //            //System.IO.File.AppendAllText(errorLogPath, html);
        //            WriteLog(html, "GetDepartment");
        //            //Rootobject list = new Rootobject();
        //            //list = serializer.Deserialize<Rootobject>(html);
        //        }
        //        catch (Exception ex)
        //        {
        //            CallAPI.WriteLog(ex.Message, "GetDepartment");
        //            throw ex;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CallAPI.WriteLog(ex.Message, "GetDepartment");

        //        throw;
        //    }
        //}

        //public static mailbag.Rootobject GetMailbagTransactions(Token.Rootobject list)
        //{
        //    mailbag.Rootobject retObj = new mailbag.Rootobject();

        //    try
        //    {
        //        string html = string.Empty;
        //        string url = "";// @"https://localhost:44388/api/ItemType/get_item_type_all_list";
        //        url = ConfigCaller.API_GetMailbagTransactionsURL;//  @"https://sk-uat-app.transnational-grp.com/api/mailbag";// ConfigurationManager.AppSettings["API_GetMailbagTransactionsURL"].ToString();

        //        var serializer = new JavaScriptSerializer();
        //        string DATA = serializer.Serialize(new { maxTransCount = 1 });

        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //        request.Method = "POST";
        //        request.ContentType = "application/json";
        //        request.ContentLength = DATA.Length;
        //        //var username = "MT01";
        //        //var password = "tWmL4ZXaj9";
        //        string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
        //                                       .GetBytes(list.result.accessToken));

        //        request.Headers.Add("Authorization", "Bearer " + list.result.accessToken);
        //        request.Headers.Add("RequestReferenceID", "1");
        //        request.Headers.Add("RequestType", "Get_MailBagTrans");
        //        request.Headers.Add("MailTrakID", "1");
        //        StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
        //        requestWriter.Write(DATA);
        //        requestWriter.Close();

        //        try
        //        {
        //            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //            using (Stream stream = response.GetResponseStream())
        //            using (StreamReader reader = new StreamReader(stream))
        //            {
        //                html = reader.ReadToEnd();
        //            }

        //            //System.IO.File.AppendAllText(errorLogPath, html);
        //            WriteLog(html, "GetMailbagTransactions");
        //            //Rootobject list = new Rootobject();
        //            retObj = serializer.Deserialize<mailbag.Rootobject>(html);

        //            if (retObj.result.mailBagTrans != null && retObj.result.mailBagTrans.Count > 0)
        //            {
        //                foreach (mailbag.Mailbagtran item in retObj.result.mailBagTrans)
        //                {
        //                    //MailTrak_BL.add_new_mailbag_trans(ConfigCaller.UserName, item);
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //            CallAPI.WriteLog(ex.Message, "GetMailbagTransactions");
        //            throw ex;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CallAPI.WriteLog(ex.Message, "GetMailbagTransactions");
        //        throw;
        //    }
        //    return retlist;
        //}

        //public static void AckMailbagTransactions(Token.Rootobject list)
        //{
        //    try
        //    {
        //        string html = string.Empty;
        //        string url = "";// @"https://localhost:44388/api/ItemType/get_item_type_all_list";
        //        url = ConfigCaller.API_AckMailbagTransactionsURL;//  @"https://sk-uat-app.transnational-grp.com/api/mailbag";// ConfigurationManager.AppSettings["API_AckMailbagTransactionsURL"].ToString();

        //        var serializer = new JavaScriptSerializer();
        //        string DATA = serializer.Serialize(new AckMailbagTransactions_Request()
        //        {
        //            reqTransReferenceId = "ABC123",
        //            reqTransType = "Get_MailBagTrans",
        //            syncStatus = 1
        //        });

        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //        request.Method = "POST";
        //        request.ContentType = "application/json";
        //        request.ContentLength = DATA.Length;
        //        //var username = "MT01";
        //        //var password = "tWmL4ZXaj9";
        //        string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
        //                                       .GetBytes(list.result.accessToken));

        //        request.Headers.Add("Authorization", "Bearer " + list.result.accessToken);
        //        request.Headers.Add("RequestReferenceID", "2");
        //        request.Headers.Add("RequestType", "Ack_MailBagTrans");
        //        request.Headers.Add("MailTrakID", "1");
        //        StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
        //        requestWriter.Write(DATA);
        //        requestWriter.Close();

        //        try
        //        {
        //            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //            using (Stream stream = response.GetResponseStream())
        //            using (StreamReader reader = new StreamReader(stream))
        //            {
        //                html = reader.ReadToEnd();
        //            }

        //            //System.IO.File.AppendAllText(errorLogPath, html);
        //            WriteLog(html, "AckMailbagTransactions");
        //            //Rootobject list = new Rootobject();
        //            //list = serializer.Deserialize<Rootobject>(html);
        //        }
        //        catch (Exception ex)
        //        {

        //            CallAPI.WriteLog(ex.Message, "AckMailbagTransactions");
        //            throw ex;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CallAPI.WriteLog(ex.Message, "AckMailbagTransactions");
        //        throw;
        //    }
        //}

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


                string strFileName = errorLogPath + "\\" + "Kiosk" + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

                StringBuilder strLog = new StringBuilder();
                strLog.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - ");
                strLog.Append(" KioskReader ");
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

        public static void GetSystemParameter(string SP_ID)
        {
            try
            {
                string html = string.Empty;
                string url = "";
                url = ConfigCaller.MailTracker_GetSystemParameterURL;

                var serializer = new JavaScriptSerializer();
                string DATA = serializer.Serialize(new
                {
                    SP_ID = SP_ID
                });

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = DATA.Length;
                //var username = ConfigCaller.UserName; //"MT01";
                //var password = ConfigCaller.Password; //"tWmL4ZXaj9";
                //string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                //                               .GetBytes(username + ":" + password));
                //request.Headers.Add("Authorization", "Basic " + encoded);
                //request.Headers.Add("RequestReferenceID", "1");
                //request.Headers.Add("RequestType", "Get_OAuthToken");
                //request.Headers.Add("MailTrakID", "1");
                StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
                requestWriter.Write(DATA);
                requestWriter.Close();

                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        html = reader.ReadToEnd();
                    }

                    WriteLog(html, "GetSystemParameter");

                    List<MailBagTransDto> model = new List<MailBagTransDto>();
                    model = serializer.Deserialize<List<MailBagTransDto>>(html);
                    if (model.Count > 0)
                    {
                        AckMailBagTransactions(model.FirstOrDefault());
                    }

                    WriteLog(html, "GetSystemParameter");
                }
                catch (Exception ex)
                {

                    CallAPI.WriteLog(ex.Message, "GetSystemParameter");
                    throw ex;
                }
            }
            catch (Exception ex)
            {

                CallAPI.WriteLog(ex.Message, "CallMailBagTransactions");
                throw;
            }
        }


        //5.1.3.1 - Get Outgoing Mail Transactions
        /// <summary>
        /// This is use to save out going mail transaction data which is fetching from the kiosk API
        /// </summary>
        /// <param name="outMail"></param>
        /// <returns></returns>
        public static bool Get_OutGoingMailTrans()
        {
            bool HasOutGoingMailBagRecords = false;
            try
            {
                string html = string.Empty;
                string url = "";
                url = ConfigCaller.MailTracker_Get_OutGoingMailTransURL;
                WriteLog("Step 1 " + url, "Get_OutGoingMailTrans");

                var serializer = new JavaScriptSerializer();
                string DATA = serializer.Serialize(new
                {
                    userId = ConfigCaller.SyncWithMailTrackKiosk_UserID,
                    maxTransCount = ConfigCaller.SyncWithMailTrackKiosk_maxTransCount
                });


                html = API_Setup(url, DATA);

                try
                {
                    //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    //using (Stream stream = response.GetResponseStream())
                    //using (StreamReader reader = new StreamReader(stream))
                    //{
                    //    html = reader.ReadToEnd();
                    //}

                    WriteLog(html, "Get_OutGoingMailTrans");

                    List<OutGoingMailDto> model = new List<OutGoingMailDto>();
                    model = serializer.Deserialize<List<OutGoingMailDto>>(html);
                    ReturnResponse res = model.FirstOrDefault(a => a.msg == MailTrak.Common.Messages.KioskHasMultipleRecords);

                    if (model.Count > 0)
                    {
                        if (res != null)
                        //  if (model.Count == 1 && model.Count(a => a.result == null) == 1)
                        { HasOutGoingMailBagRecords = true; }
                        else { HasOutGoingMailBagRecords = false; }

                        WriteLog("Step 9 ", "Get_OutGoingMailTrans HasOutGoingMailBagRecords:" + HasOutGoingMailBagRecords.ToString());
                        AckOutGoingTransactions(model.FirstOrDefault());
                    }

                    WriteLog(html, "Get_OutGoingMailTrans");
                }
                catch (Exception ex)
                {

                    CallAPI.WriteLog(ex.Message, "Get_OutGoingMailTrans");
                    throw ex;
                }
            }
            catch (Exception ex)
            {

                CallAPI.WriteLog(ex.Message, "Get_OutGoingMailTrans");
                throw;
            }
            return HasOutGoingMailBagRecords;
        }

        public static void AckOutGoingTransactions(OutGoingMailDto model)
        {
            try
            {
                string html = string.Empty;
                string url = "";
                url = ConfigCaller.MailTracker_Ack_OutGoingMailTransURL;


                Ack_MailBagTrans_RequestModel obj = new Ack_MailBagTrans_RequestModel()
                {
                    reqTransReferenceId = model.result.reqTransReferenceId,
                    reqTransType = "AckOutGoingTransactions",
                    syncStatus = 1
                };

                var serializer = new JavaScriptSerializer();
                string DATA = serializer.Serialize(obj);

                WriteLog(DATA, "AckOutGoingTransactions");
                WriteLog(url, "AckOutGoingTransactions");


                html = API_Setup(url, DATA);

                try
                {
                    //WriteLog("Before Read", "AckOutGoingTransactions");
                    //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    //using (Stream stream = response.GetResponseStream())
                    //using (StreamReader reader = new StreamReader(stream))
                    //{
                    //    html = reader.ReadToEnd();
                    //}

                    List<MailTrack_ReturnResponce> list = new List<MailTrack_ReturnResponce>();
                    list = serializer.Deserialize<List<MailTrack_ReturnResponce>>(html);
                    WriteLog(html, "AckOutGoingTransactions");
                }
                catch (Exception ex)
                {
                    WriteLog("Not Submitted", "AckOutGoingTransactions");
                    CallAPI.WriteLog(ex.Message, "AckOutGoingTransactions");
                    throw ex;
                }
            }
            catch (Exception ex)
            {

                CallAPI.WriteLog(ex.Message, "AckOutGoingTransactions");
                throw;
            }
        }

        //5.1.4.1 - Set Departments
        /// <summary>
        /// This is use to fetch data from the local DB and send data to kiosk API
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public static void Set_Departments()
        {
            try
            {
                string html = string.Empty;
                string url = "";
                url = ConfigCaller.MailTracker_Set_DepartmentsURL;
                WriteLog("Step 1 " + url, "Set_Departments");

                var serializer = new JavaScriptSerializer();
                string DATA = serializer.Serialize(new
                {
                    userId = ConfigCaller.SyncWithMailTrackKiosk_UserID,
                    maxTransCount = ConfigCaller.SyncWithMailTrackKiosk_maxTransCount
                });

                html = API_Setup(url, DATA);

                try
                {
                    //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    //using (Stream stream = response.GetResponseStream())
                    //using (StreamReader reader = new StreamReader(stream))
                    //{
                    //    html = reader.ReadToEnd();
                    //}

                    WriteLog(html, "Set_Departments");

                    List<MailBagTransDto> model = new List<MailBagTransDto>();
                    model = serializer.Deserialize<List<MailBagTransDto>>(html);
                    if (model.Count > 0)
                    {
                        WriteLog("Step 9 ", "Set_Departments");
                    }

                    WriteLog(html, "Set_Departments");
                }
                catch (Exception ex)
                {

                    CallAPI.WriteLog(ex.Message, "Set_Departments");
                    throw ex;
                }
            }
            catch (Exception ex)
            {

                CallAPI.WriteLog(ex.Message, "Set_Departments");
                throw;
            }
        }

        //5.1.4.2 - Get Department
        /// <summary>
        /// This is use to get department data from the kiosk API and save in DB
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public static void Get_Departments()
        {
            try
            {
                string html = string.Empty;
                string url = "";
                url = ConfigCaller.MailTracker_Get_DepartmentsURL;
                WriteLog("Step 1 " + url, "Get_Departments");

                var serializer = new JavaScriptSerializer();
                string DATA = serializer.Serialize(new
                {
                    userId = ConfigCaller.SyncWithMailTrackKiosk_UserID,
                    maxTransCount = ConfigCaller.SyncWithMailTrackKiosk_maxTransCount
                });


                html = API_Setup(url, DATA);

                try
                {
                    //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    //using (Stream stream = response.GetResponseStream())
                    //using (StreamReader reader = new StreamReader(stream))
                    //{
                    //    html = reader.ReadToEnd();
                    //}

                    WriteLog(html, "Get_Departments");

                    List<MailBagTransDto> model = new List<MailBagTransDto>();
                    model = serializer.Deserialize<List<MailBagTransDto>>(html);
                    if (model.Count > 0)
                    {
                        WriteLog("Step 9 ", "Get_Departments");
                    }

                    WriteLog(html, "Get_Departments");
                }
                catch (Exception ex)
                {

                    CallAPI.WriteLog(ex.Message, "Get_Departments");
                    throw ex;
                }
            }
            catch (Exception ex)
            {

                CallAPI.WriteLog(ex.Message, "Get_Departments");
                throw;
            }
        }

        //5.1.4.3 - Get Locations
        /// <summary>
        /// This is use to get location data from the kiosk API and save in DB
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public static void Get_Locations()
        {
            try
            {
                string html = string.Empty;
                string url = "";
                url = ConfigCaller.MailTracker_Get_LocationsURL;
                WriteLog("Step 1 " + url, "Get_Locations");

                var serializer = new JavaScriptSerializer();
                string DATA = serializer.Serialize(new
                {
                    userId = ConfigCaller.SyncWithMailTrackKiosk_UserID,
                    maxTransCount = ConfigCaller.SyncWithMailTrackKiosk_maxTransCount
                });


                html = API_Setup(url, DATA);

                try
                {
                    //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    //using (Stream stream = response.GetResponseStream())
                    //using (StreamReader reader = new StreamReader(stream))
                    //{
                    //    html = reader.ReadToEnd();
                    //}

                    WriteLog(html, "Get_Locations");

                    List<MailBagTransDto> model = new List<MailBagTransDto>();
                    model = serializer.Deserialize<List<MailBagTransDto>>(html);
                    if (model.Count > 0)
                    {
                        WriteLog("Step 9 ", "Get_Locations");
                    }

                    WriteLog(html, "Get_Locations");
                }
                catch (Exception ex)
                {

                    CallAPI.WriteLog(ex.Message, "Get_Locations");
                    throw ex;
                }
            }
            catch (Exception ex)
            {

                CallAPI.WriteLog(ex.Message, "Get_Locations");
                throw;
            }
        }

        //5.1.4.4 - Get User Groups
        /// <summary>
        /// This is use to get user group data from the kiosk API and save in DB
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static void Get_UserGroups()
        {
            try
            {
                string html = string.Empty;
                string url = "";
                url = ConfigCaller.MailTracker_Get_UserGroupsURL;
                WriteLog("Step 1 " + url, "Get_UserGroups");

                var serializer = new JavaScriptSerializer();
                string DATA = serializer.Serialize(new
                {
                    userId = ConfigCaller.SyncWithMailTrackKiosk_UserID,
                    maxTransCount = ConfigCaller.SyncWithMailTrackKiosk_maxTransCount
                });


                html = API_Setup(url, DATA);

                try
                {
                    //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    //using (Stream stream = response.GetResponseStream())
                    //using (StreamReader reader = new StreamReader(stream))
                    //{
                    //    html = reader.ReadToEnd();
                    //}

                    WriteLog(html, "Get_UserGroups");

                    List<MailBagTransDto> model = new List<MailBagTransDto>();
                    model = serializer.Deserialize<List<MailBagTransDto>>(html);
                    if (model.Count > 0)
                    {
                        WriteLog("Step 9 ", "Get_UserGroups");
                    }

                    WriteLog(html, "Get_UserGroups");
                }
                catch (Exception ex)
                {

                    CallAPI.WriteLog(ex.Message, "Get_UserGroups");
                    throw ex;
                }
            }
            catch (Exception ex)
            {

                CallAPI.WriteLog(ex.Message, "Get_UserGroups");
                throw;
            }
        }

        //5.1.4.5. Set Users (Customer Staff + SmartKisk Web Users) 
        /// <summary>
        /// This is use to get user data from local DB and sent data to kiosk API
        /// </summary>
        /// <returns></returns>
        //public static void Set_Users()
        //{
        //    try
        //    {
        //        string html = string.Empty;
        //        string url = "";
        //        url = ConfigCaller.MailTracker_Set_UsersURL;
        //        WriteLog("Step 1 " + url, "Set_Users");

        //        var serializer = new JavaScriptSerializer();
        //        string DATA = serializer.Serialize(new
        //        {
        //            userId = ConfigCaller.SyncWithMailTrackKiosk_UserID,
        //            maxTransCount = ConfigCaller.SyncWithMailTrackKiosk_maxTransCount
        //        });


        //        html = API_Setup(url, DATA);


        //        try
        //        {
        //            //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //            //using (Stream stream = response.GetResponseStream())
        //            //using (StreamReader reader = new StreamReader(stream))
        //            //{
        //            //    html = reader.ReadToEnd();
        //            //}

        //            WriteLog(html, "Set_Users");

        //            List<MailBagTransDto> model = new List<MailBagTransDto>();
        //            model = serializer.Deserialize<List<MailBagTransDto>>(html);
        //            if (model.Count > 0)
        //            {
        //                WriteLog("Step 9 ", "Set_Users");
        //            }

        //            WriteLog(html, "Set_Users");
        //        }
        //        catch (Exception ex)
        //        {

        //            CallAPI.WriteLog(ex.Message, "Set_Users");
        //            throw ex;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        CallAPI.WriteLog(ex.Message, "Set_Users");
        //        throw;
        //    }
        //}

        //5.1.5.1 - Get Device Activities
        public static bool Get_DeviceActs()
        {
            bool HasDeviceActsRecords = false;
            try
            {
                string html = string.Empty;
                string url = "";
                url = ConfigCaller.MailTracker_Get_DeviceActsURL;
                WriteLog("Step 1 " + url, "Get_DeviceActs");

                var serializer = new JavaScriptSerializer();
                string DATA = serializer.Serialize(new
                {
                    userId = ConfigCaller.SyncWithMailTrackKiosk_UserID,
                    maxTransCount = ConfigCaller.SyncWithMailTrackKiosk_maxTransCount
                });


                html = API_Setup(url, DATA);

                try
                {
                    //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    //using (Stream stream = response.GetResponseStream())
                    //using (StreamReader reader = new StreamReader(stream))
                    //{
                    //    html = reader.ReadToEnd();
                    //}

                    WriteLog(html, "Get_DeviceActs");

                    List<ReturnResponse> model = new List<ReturnResponse>();
                    model = serializer.Deserialize<List<ReturnResponse>>(html);
                    ReturnResponse res = model.FirstOrDefault(a => a.msg == MailTrak.Common.Messages.KioskHasMultipleRecords);

                    if (model.Count > 0)
                    {
                        if (res != null)
                        //if (model.Count == 1 && model.Count(a => a.obj == null) == 1)
                        { HasDeviceActsRecords = true; }
                        else { HasDeviceActsRecords = false; }

                        WriteLog("Step 9 ", "Get_DeviceActs HasDeviceActsRecords:" + HasDeviceActsRecords.ToString());
                        //Ack_DeviceActs(model.FirstOrDefault());
                    }

                    //WriteLog(html, "Get_DeviceActs");
                }
                catch (Exception ex)
                {

                    CallAPI.WriteLog(ex.Message, "Get_DeviceActs");
                    throw ex;
                }
            }
            catch (Exception ex)
            {

                CallAPI.WriteLog(ex.Message, "Get_DeviceActs");
                throw;
            }
            return HasDeviceActsRecords;
        }

        private static void Ack_DeviceActs(MailBagTransDto model)
        {
            try
            {
                string html = string.Empty;
                string url = "";
                url = ConfigCaller.MailTracker_Ack_DeviceActsURL;


                Ack_MailBagTrans_RequestModel obj = new Ack_MailBagTrans_RequestModel()
                {
                    reqTransReferenceId = model.result.reqTransReferenceId,
                    reqTransType = "Ack_DeviceActs",
                    syncStatus = 1
                };

                var serializer = new JavaScriptSerializer();
                string DATA = serializer.Serialize(obj);

                WriteLog(DATA, "Ack_DeviceActs");
                WriteLog(url, "Ack_DeviceActs");


                html = API_Setup(url, DATA);

                try
                {
                    //WriteLog("Before Read", "AckMailBagTransactions");
                    //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    //using (Stream stream = response.GetResponseStream())
                    //using (StreamReader reader = new StreamReader(stream))
                    //{
                    //    html = reader.ReadToEnd();
                    //}

                    //List<MailTrack_ReturnResponce> list = new List<MailTrack_ReturnResponce>();
                    //list = serializer.Deserialize<List<MailTrack_ReturnResponce>>(html);
                    WriteLog(html, "Ack_DeviceActs");
                }
                catch (Exception ex)
                {
                    WriteLog("Not Submitted", "Ack_DeviceActs");
                    CallAPI.WriteLog(ex.Message, "Ack_DeviceActs");
                    throw ex;
                }
            }
            catch (Exception ex)
            {

                CallAPI.WriteLog(ex.Message, "Ack_DeviceActs");
                throw;
            }
        }
    }
}
