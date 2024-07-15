using error_handler;
using HRM_DAL.Models;
using HRM_DAL.Models.RequestModels;
using HRM_DAL.Models.ResponceModels;
using HRM_DAL.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using utility_handler.Data;

namespace HRM_DAL.Data
{
    public class HRM_APICaller_Data
    {
        private static LogError objError = new LogError();
        //    public static HRMToken.Rootobject GetToken()
        //    {
        //        HRMToken.Rootobject list = new HRMToken.Rootobject();

        //        try
        //        {
        //            string html = string.Empty;
        //            string url = "";
        //            url = ConfigCaller.HRMAPI_TokenURL;// @"https://sk-uat-app.transnational-grp.com/api/token";
        //            new WhiteLog(url, "HRMAPIClient", "GetToken", true, true);

        //            string DATA = JsonConvert.SerializeObject(new { grant_type = "client_credentials" });
        //            //var serializer = new JavaScriptSerializer();
        //            //string DATA = serializer.Serialize(new { grant_type = "client_credentials" });

        //            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //            request.Method = "POST";
        //            request.ContentType = "application/json";
        //            request.ContentLength = DATA.Length;
        //            var username = ConfigCaller.HRMUserName; //"MT01";
        //            var password = ConfigCaller.HRMPassword; //"tWmL4ZXaj9";
        //            string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
        //                                           .GetBytes(username + ":" + password));
        //            request.Headers.Add("Authorization", "Basic " + encoded);
        //            string RequestReferenceID = System.DateTime.Now.ToString("ddMMyyyyHHmmss");
        //            request.Headers.Add("RequestReferenceID", RequestReferenceID);
        //            request.Headers.Add("RequestType", "Get_OAuthToken");
        //            request.Headers.Add("HRMID", ConfigCaller.HRMID);
        //            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
        //            requestWriter.Write(DATA);
        //            requestWriter.Close();

        //            try
        //            {
        //                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //                using (Stream stream = response.GetResponseStream())
        //                using (StreamReader reader = new StreamReader(stream))
        //                {
        //                    html = reader.ReadToEnd();
        //                }
        //                new WhiteLog(html, "HRMAPIClient", "GetToken", true, true);

        //                list = JsonConvert.DeserializeObject<HRMToken.Rootobject>(html);
        //                list.RequestReferenceID = RequestReferenceID;

        //                return list;
        //            }
        //            catch (Exception ex)
        //            {
        //                //CallAPI.WriteLog(ex.Message, "GetToken");
        //                throw ex;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            //CallAPI.WriteLog(ex.Message, "GetToken");
        //            throw;
        //        }
        //    }

        //    public static HRM_MailBag.Rootobject GetMailbagTransactions(HRMToken.Rootobject list, int maxTransCount)
        //    {
        //        HRM_MailBag.Rootobject retObj = new HRM_MailBag.Rootobject();
        //        string RequestReferenceID = System.DateTime.Now.ToString("ddMMyyyyHHmmss");

        //        try
        //        {
        //            string html = string.Empty;
        //            string url = "";
        //            url = ConfigCaller.API_GetMailbagTransactionsURL;
        //            new WhiteLog("GetMailbagTransactions - Step 1" + url, "HRMAPIClient", "GetMailbagTransactions", true, true);

        //            string DATA = JsonConvert.SerializeObject(new { maxTransCount = maxTransCount });

        //            new WhiteLog("GetMailbagTransactions - Step 2" + DATA, "HRMAPIClient", "GetMailbagTransactions", true, true);

        //            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //            request.Method = "POST";
        //            request.ContentType = "application/json";
        //            request.ContentLength = DATA.Length;
        //            //var username = "MT01";
        //            //var password = "tWmL4ZXaj9";
        //            string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
        //                                           .GetBytes(list.result.accessToken));

        //            request.Headers.Add("Authorization", "Bearer " + list.result.accessToken);
        //            request.Headers.Add("RequestReferenceID", RequestReferenceID);
        //            request.Headers.Add("RequestType", "Get_MailBagTrans");
        //            request.Headers.Add("HRMID", ConfigCaller.HRMID);
        //            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
        //            requestWriter.Write(DATA);
        //            requestWriter.Close();

        //            new WhiteLog("GetMailbagTransactions - Step 3 - request submit", "HRMAPIClient", "GetMailbagTransactions", true, true);

        //            try
        //            {
        //                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //                using (Stream stream = response.GetResponseStream())
        //                using (StreamReader reader = new StreamReader(stream))
        //                {
        //                    html = reader.ReadToEnd();
        //                }

        //                new WhiteLog("GetMailbagTransactions - Step 4 - request read" + html, "HRMAPIClient", "GetMailbagTransactions", true, true);

        //                retObj = JsonConvert.DeserializeObject<HRM_MailBag.Rootobject>(html);
        //                if (retObj.result == null)
        //                {
        //                    retObj.result = new HRM_MailBag.Result();
        //                }
        //                retObj.result.reqTransReferenceId = RequestReferenceID;

        //                new WhiteLog("GetMailbagTransactions - Step 5 - request read" + RequestReferenceID, "HRMAPIClient", "GetMailbagTransactions", true, true);
        //            }
        //            catch (Exception ex)
        //            {

        //                retObj = new HRM_MailBag.Rootobject
        //                {
        //                    resp = false,
        //                    msg = ex.Message.ToString()
        //                };
        //                retObj.result.reqTransReferenceId = RequestReferenceID;

        //                objError.WriteLog(0, "HRM_APICaller_Data", "GetMailbagTransactions", "Stack Track: " + ex.StackTrace);
        //                objError.WriteLog(0, "HRM_APICaller_Data", "GetMailbagTransactions", "Error Message: " + ex.Message);
        //                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //                {
        //                    objError.WriteLog(0, "HRM_APICaller_Data", "GetMailbagTransactions", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //                    objError.WriteLog(0, "HRM_APICaller_Data", "GetMailbagTransactions", "Inner Exception Message: " + ex.InnerException.Message);
        //                }


        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //            retObj = new HRM_MailBag.Rootobject
        //            {
        //                resp = false,
        //                msg = ex.Message.ToString()
        //            };

        //            objError.WriteLog(0, "HRM_APICaller_Data", "GetMailbagTransactions", "Stack Track: " + ex.StackTrace);
        //            objError.WriteLog(0, "HRM_APICaller_Data", "GetMailbagTransactions", "Error Message: " + ex.Message);
        //            if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
        //            {
        //                objError.WriteLog(0, "HRM_APICaller_Data", "GetMailbagTransactions", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
        //                objError.WriteLog(0, "HRM_APICaller_Data", "GetMailbagTransactions", "Inner Exception Message: " + ex.InnerException.Message);
        //            }


        //        }
        //        return retObj;
        //    }
        //}
    }
}