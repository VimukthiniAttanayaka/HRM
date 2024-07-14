using error_handler;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using utility_handler.Data;


namespace sms_core
{
    public class SendSMS
    {
        //
        // GET: /Test2/
        private LogError objError = new LogError();
        public async Task<(bool status, string message)> SMSgateway_V2(string dst, string msg, string SMSURL, string SMSUsername,
                                            string SMSPassword,
                                            string type)
        {
            bool rtn;
            try
            {

                string res;
                using (var httpClientHandler = new HttpClientHandler())
                {
                    // NB: You should make this more robust by actually checking the certificate:
                    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                    using (var client = new HttpClient(httpClientHandler))
                    {

                        //SMSURL = "https://smsc.slt.lk:8093/api/sms?src=PRONTO&dst={MobileNo}&dr=0&type={type}&user={UserName}&password={Password}&msg={Message}";

                        SMSURL = SMSURL.Replace("{MobileNo}", dst);
                        SMSURL = SMSURL.Replace("{Message}", msg);
                        SMSURL = SMSURL.Replace("{UserName}", SMSUsername);
                        SMSURL = SMSURL.Replace("{type}", type);

                        InformationLog.WriteLog(0, "Mobile Address: " + dst +
                              " SMS URL: " + SMSURL + " SMS UserName: " + SMSUsername +
                              " Type: " + type, "SendSMS");

                        SMSURL = SMSURL.Replace("{Password}", SMSPassword);

                        client.BaseAddress = new Uri(SMSURL);

                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var response = await client.GetAsync(SMSURL);

                        if (response.IsSuccessStatusCode)
                        {
                            res = await response.Content.ReadAsStringAsync();
                            rtn = true;
                            //rtn = res.Contains("success");
                        }
                        else
                        {
                            res = "Internal server Error";
                            rtn = false;
                        }
                        objError.WriteLog(2, "SendSMS", "SMSgateway", "response : " + response + "MobileNo :"+ dst);


                    }
                }


                return (rtn, res);

            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "SendSMS", "SMSgateway", "MobileNo :" + dst + "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "SendSMS", "SMSgateway", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "SendSMS", "SMSgateway", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "SendSMS", "SMSgateway", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return (false, ex.Message);
            }

        }

        [Obsolete]
        public async Task<bool> SMSgateway(string dst, string msg)
        {
            bool rtn;
            try
            {

                string res;
                using (var httpClientHandler = new HttpClientHandler())
                {
                    // NB: You should make this more robust by actually checking the certificate:
                    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                    using (var client = new HttpClient(httpClientHandler))
                    {
                        client.BaseAddress = new Uri(BaseClassDBCallerData.SMSURL);

                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        String url2 = "sms?src=" + BaseClassDBCallerData.src + "&dst=" + dst +
                            "&dr=" + BaseClassDBCallerData.dr +
                            "&type=" + BaseClassDBCallerData.type +
                            "&user=" + BaseClassDBCallerData.SMSUsername +
                            "&password=" + BaseClassDBCallerData.SMSPassword +
                            "&msg=" + msg;

                        var response = await client.GetAsync(url2);

                        if (response.IsSuccessStatusCode)
                        {
                            res = await response.Content.ReadAsStringAsync();
                            rtn = res.Contains("success");
                        }
                        else
                        {
                            res = "Internal server Error";
                            rtn = true;
                        }


                    }
                }


                return rtn;

            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "SendSMS", "SMSgateway", "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "SendSMS", "SMSgateway", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "SendSMS", "SMSgateway", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "SendSMS", "SMSgateway", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return true;
            }

        }

        [Obsolete]
        public async Task<(bool status, string message)> SMSgateway_V1(string dst, string msg, string SMSURL, string SMSUsername,
                                            string SMSPassword,
                                            string type)
        {
            try
            {
                //string message = "test sms " + System.DateTime.Now.ToString("yyyyMMddHHmmss");

                //Construct Send Params.

                string response;

                string gateWay = SMSURL;// BaseClassDBCallerData.SMSURL /*"https://www.commzgate.net/gateway/SendMsg"*/ + "?";

                //Setup Params

                string paramData = "";

                paramData += "ID=" + SMSUsername /*BaseClassDBCallerData.SMSUsername*/ + "&";

                paramData += "Password=" + SMSPassword /*BaseClassDBCallerData.SMSPassword*/ + "&";

                paramData += "Mobile=" + dst + "&";

                paramData += "Type=" + type/*BaseClassDBCallerData.type*/ + "&";

                paramData += "Message=" + System.Uri.EscapeDataString(msg) + "&";

                //Ensure Ascii format

                ASCIIEncoding encoding = new ASCIIEncoding();

                byte[] ASCIIparamData = encoding.GetBytes(paramData);

                //Setting Request

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(gateWay);

                request.Method = "POST";

                request.Accept = "text/plain";

                request.ContentType = "application/x-www-form-urlencoded";

                request.ContentLength = ASCIIparamData.Length;

                //Sending Request.

                Stream streamReq = request.GetRequestStream();

                streamReq.Write(ASCIIparamData, 0, ASCIIparamData.Length);

                //Get Response

                HttpWebResponse HttpWResp = (HttpWebResponse)request.GetResponse();

                Stream streamResponse = HttpWResp.GetResponseStream();

                //Read the Response.. and open a dialog

                StreamReader reader = new StreamReader(streamResponse);

                response = reader.ReadToEnd();

                //Console.WriteLine("response >> " + response);
                objError.WriteLog(2, "SendSMS", "SMSgateway", "response : " + response + "MobileNo :" + dst);
                return (true, response);
            }
            catch (Exception ex)
            {
                objError.WriteLog(0, "SendSMS", "SMSgateway", "MobileNo :" + dst+ "Stack Track: " + ex.StackTrace);
                objError.WriteLog(0, "SendSMS", "SMSgateway", "Error Message: " + ex.Message);
                if (ex.InnerException != null && ex.InnerException.Message != string.Empty)
                {
                    objError.WriteLog(0, "SendSMS", "SMSgateway", "Inner Exception Stack Track: " + ex.InnerException.StackTrace);
                    objError.WriteLog(0, "SendSMS", "SMSgateway", "Inner Exception Message: " + ex.InnerException.Message);
                }
                return (true, ex.Message);
            }
        }
    }
}
