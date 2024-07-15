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

namespace Kioski_APIChecker_DL
{
    public static class CallAPI_DayEndProcess
    {
        static string errorLogPath = ConfigCaller.ErrorLogPath;// @"D:\ForeignProjects\MailTrak_Backend_V1.0\APIChecker\ErrorLog";// System.Configuration.ConfigurationManager.AppSettings["ErrorLogPath"];

        public static void CallDayEndProcess_Batch_Summary_Email()
        {
            try
            {
                string html = string.Empty;
                string url = "";
                url = ConfigCaller.DayEndProcess_Batch_Summary_Email_URL;
                WriteLog("Step 1 " + url, "CallDayEndProcess_Batch_Summary_Email");

                var serializer = new JavaScriptSerializer();
                string DATA = serializer.Serialize(new
                {
                    //userId = ConfigCaller.SyncWithMailTrackKiosk_UserID,
                    //maxTransCount = ConfigCaller.SyncWithMailTrackKiosk_maxTransCount
                });

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = DATA.Length;
                request.Timeout = 10000000;
                request.ReadWriteTimeout = 10000000;
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
                    WriteLog("Step 2 " + url, "CallDayEndProcess_Batch_Summary_Email");

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        html = reader.ReadToEnd();
                    }

                    WriteLog(html, "CallDayEndProcess_Batch_Summary_Email");

                    List<MailBagTransDto> model = new List<MailBagTransDto>();
                    model = serializer.Deserialize<List<MailBagTransDto>>(html);
                    if (model.Count > 0)
                    {
                        WriteLog("Step 9 ", "CallDayEndProcess_Batch_Summary_Email");
                    }

                    WriteLog(html, "CallDayEndProcess_Batch_Summary_Email");
                }
                catch (Exception ex)
                {

                    WriteLog(ex.Message, "CallDayEndProcess_Batch_Summary_Email");
                    throw ex;
                }
            }
            catch (Exception ex)
            {

                WriteLog(ex.Message, "CallDayEndProcess_Batch_Summary_Email");
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

                string strFileName = errorLogPath + "\\" + "DayEndProcess" + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

                StringBuilder strLog = new StringBuilder();
                strLog.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - ");
                strLog.Append(" DayEndProcess ");
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
}
