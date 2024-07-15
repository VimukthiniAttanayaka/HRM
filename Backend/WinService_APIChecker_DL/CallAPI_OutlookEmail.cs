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
    public static class CallAPI_OutlookEmail
    {
        static string errorLogPath = ConfigCaller.ErrorLogPath;// @"D:\ForeignProjects\MailTrak_Backend_V1.0\APIChecker\ErrorLog";// System.Configuration.ConfigurationManager.AppSettings["ErrorLogPath"];

        public class ExceptionMailReaderTable
        {
            public string BatchNo { get; set; }
            public string EmailReplyStatus { get; set; }
            public string Subject { get; set; }
            public string EmailFrom { get; set; }
            public DateTime ReadTime { get; set; } = DateTime.Now;
            public bool IsSynced { get; set; } = false;
            public string MailBody { get; set; }
            public string TransactionDateTime { get; set; }
            public string ExceptionStatus { get; set; }
            public string EmailFor { get; set; }
            public string Status { get; set; }
        }

        public static void CallMailTrackerToDoOutlookEmail(List<ExceptionMailReaderTable> mailList)
        {
            try
            {
                string html = string.Empty;
                string url = "";
                url = ConfigCaller.MailTracker_OutlookEmailURL;
                WriteLog("Step 1 " + url, "CallMailTrackerToDoOutlookEmail");

                var serializer = new JavaScriptSerializer();
                string DATA = serializer.Serialize(mailList);

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

                Console.WriteLine("CallMailTrackerToDoOutlookEmail Before Request");
                WriteLog(html, "CallMailTrackerToDoOutlookEmail Before Request");
                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        html = reader.ReadToEnd();
                    }
                    Console.WriteLine("CallMailTrackerToDoOutlookEmail After Request");
                    WriteLog(html, "CallMailTrackerToDoOutlookEmail After Request");

                    //List<MailBagTransDto> model = new List<MailBagTransDto>();
                    //model = serializer.Deserialize<List<MailBagTransDto>>(html);
                    //if (model.Count > 0)
                    //{
                    //    WriteLog("Step 9 ", "CallMailTrackerToDoOutlookEmail");
                    //}

                    //WriteLog(html, "CallMailTrackerToDoOutlookEmail");
                }
                catch (Exception ex)
                {

                    CallAPI_OutlookEmail.WriteLog(ex.Message, "CallMailTrackerToDoOutlookEmail");
                    Console.WriteLine("CallMailTrackerToDoOutlookEmail API Call: Exception : " + ex.Message);

                    //throw ex;
                }
            }
            catch (Exception ex)
            {

                CallAPI_OutlookEmail.WriteLog(ex.Message, "CallMailTrackerToDoOutlookEmail");
                Console.WriteLine("CallMailTrackerToDoOutlookEmail API Call: Exception : " + ex.Message);
                //throw;
            }
        }

        private static bool WriteLog(string LogText, string Action)
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


                string strFileName = errorLogPath + "\\" + "EmailReader_WinSvc" + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

                StringBuilder strLog = new StringBuilder();
                strLog.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - ");
                strLog.Append(" EmailReader_WinSvc ");
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
