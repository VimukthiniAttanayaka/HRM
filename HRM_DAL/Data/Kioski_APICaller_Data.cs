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
    public class Kioski_APICaller_Data
    {
        private static LogError objError = new LogError();
        public static OZeroToken.Rootobject Get_OAuthToken(Get_OAuthToken_RequestModel model,string Authorization, string RequestReferenceID, string RequestType, string SmartKioskvendorID)
        {
            OZeroToken.Rootobject list = new OZeroToken.Rootobject();

            try
            {
                string html = string.Empty;
                string url = "";
                url = ConfigCaller.KioskiAPI_TokenURL;// @"https://sk-uat-app.transnational-grp.com/api/token";
                new WhiteLog("Step 3", "KioskiAPIClient", "GetToken", true, false);

                string DATA = JsonConvert.SerializeObject(new { grant_type = "client_credentials" });
                //var serializer = new JavaScriptSerializer();
                //string DATA = serializer.Serialize(new { grant_type = "client_credentials" });

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = DATA.Length;

                request.Headers.Add("Authorization", Authorization);
                request.Headers.Add("RequestReferenceID", RequestReferenceID);
                request.Headers.Add("RequestType", RequestType);
                request.Headers.Add("SmartKioskvendorID", SmartKioskvendorID);

                StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
                requestWriter.Write(DATA);
                requestWriter.Close();
                new WhiteLog("Step 4", "KioskiAPIClient", "GetToken", true, false);

                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        html = reader.ReadToEnd();
                        new WhiteLog(html, "KioskiAPIClient", "GetToken", true, false);
                    }

                    list = JsonConvert.DeserializeObject<OZeroToken.Rootobject>(html);
                    list.RequestReferenceID = RequestReferenceID;

                    return list;
                }
                catch (Exception ex)
                {
                    //CallAPI.WriteLog(ex.Message, "GetToken");
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                //CallAPI.WriteLog(ex.Message, "GetToken");
                throw;
            }
        }

        public static OZero_ReturnResponce Validate_OAuthToken(Get_OAuthToken_RequestModel model, string Authorization, string RequestReferenceID, string RequestType, string SmartKioskvendorID)
        {
            OZero_ReturnResponce list = new OZero_ReturnResponce();

            try
            {
                string html = string.Empty;
                string url = "";
                url = ConfigCaller.KioskiAPI_Validate_OAuthToken;// @"https://sk-uat-app.transnational-grp.com/api/token";
                new WhiteLog("Step 3", "KioskiAPIClient", "Validate_OAuthToken", true, true);

                string DATA = JsonConvert.SerializeObject(new { grant_type = "client_credentials" });
                //var serializer = new JavaScriptSerializer();
                //string DATA = serializer.Serialize(new { grant_type = "client_credentials" });

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = DATA.Length;

                request.Headers.Add("Authorization", Authorization);
                request.Headers.Add("RequestReferenceID", RequestReferenceID);
                request.Headers.Add("RequestType", RequestType);
                request.Headers.Add("SmartKioskvendorID", SmartKioskvendorID);

                StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
                requestWriter.Write(DATA);
                requestWriter.Close();
                new WhiteLog("Step 4", "KioskiAPIClient", "Validate_OAuthToken", true, false);

                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        html = reader.ReadToEnd();
                        new WhiteLog(html, "KioskiAPIClient", "Validate_OAuthToken", true, false);
                    }

                    list = JsonConvert.DeserializeObject<OZero_ReturnResponce>(html);

                    return list;
                }
                catch (Exception ex)
                {
                    //CallAPI.WriteLog(ex.Message, "GetToken");
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                //CallAPI.WriteLog(ex.Message, "GetToken");
                throw;
            }
        }
    }
}
