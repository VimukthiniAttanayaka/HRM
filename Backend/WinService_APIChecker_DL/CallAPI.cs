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
using HRM;

namespace Kioski_APIChecker_DL
{
    public static class CallAPI
    {
        static string errorLogPath = ConfigCaller.ErrorLogPath;

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

        public static void GetToken()
        {
            try
            {
                string html = string.Empty;
                string url = "";// @"https://localhost:44388/api/ItemType/get_item_type_all_list";
                url = ConfigCaller.API_TokenURL;// @"https://sk-uat-app.transnational-grp.com/api/token";// ConfigurationManager.AppSettings["API_TokenURL"].ToString();

                var serializer = new JavaScriptSerializer();
                string DATA = serializer.Serialize(new { grant_type = "client_credentials" });

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = DATA.Length;
                var username = ConfigCaller.UserName; //"MT01";
                var password = ConfigCaller.Password; //"tWmL4ZXaj9";
                string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                                               .GetBytes(username + ":" + password));
                request.Headers.Add("Authorization", "Basic " + encoded);
                request.Headers.Add("RequestReferenceID", "1");
                request.Headers.Add("RequestType", "Get_OAuthToken");
                request.Headers.Add("MailTrakID", "1");
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

                    Token.Rootobject list = new Token.Rootobject();
                    list = serializer.Deserialize<Token.Rootobject>(html);
                    if (list != null && list.messageId == 1)
                    {
                        //System.IO.File.AppendAllText(errorLogPath, html);
                        WriteLog(html, "GetToken");
                        GetDepartment(list);
                        GetMailbagTransactions(list);
                        AckMailbagTransactions(list);
                    }
                }
                catch (Exception ex)
                {

                    CallAPI.WriteLog(ex.Message, "GetToken");
                    throw ex;
                }
            }
            catch (Exception ex)
            {

                CallAPI.WriteLog(ex.Message, "GetToken");
                throw;
            }
        }

        public static void GetDepartment(Token.Rootobject list)
        {
            try
            {
                string html = string.Empty;
                string url = "";// @"https://localhost:44388/api/ItemType/get_item_type_all_list";
                url = ConfigCaller.API_URL;// @"https://sk-uat-app.transnational-grp.com/api/department";// ConfigurationManager.AppSettings["API_URL"].ToString();

                var serializer = new JavaScriptSerializer();
                string DATA = serializer.Serialize(new { customerId = "DBS" });

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = DATA.Length;
                //var username = "MT01";
                //var password = "tWmL4ZXaj9";
                string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                                               .GetBytes(list.result.accessToken));

                request.Headers.Add("Authorization", "Bearer " + list.result.accessToken);
                request.Headers.Add("RequestReferenceID", "1");
                request.Headers.Add("RequestType", "Get_Departments");
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

                    //System.IO.File.AppendAllText(errorLogPath, html);
                    WriteLog(html, "GetDepartment");
                    //Rootobject list = new Rootobject();
                    //list = serializer.Deserialize<Rootobject>(html);
                }
                catch (Exception ex)
                {
                    CallAPI.WriteLog(ex.Message, "GetDepartment");
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                CallAPI.WriteLog(ex.Message, "GetDepartment");

                throw;
            }
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
    }
}
