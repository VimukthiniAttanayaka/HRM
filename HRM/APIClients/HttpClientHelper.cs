using HRM_DAL.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HRM.APIClients
{
    public class HttpClientHelper : IHttpClientHelper
    {
        public string GetErrorMessage(string responseInfo)
        {
            string errorMessage;

            try
            {
                throw new Exception(responseInfo)
                {
                    HelpLink = null,
                    HResult = 0,
                    Source = null
                };
            }
            catch (Exception e)
            {
                new WhiteLog(e, "HttpClientHelper", "GetErrorMessage");

                errorMessage = e.Message;

                if (errorMessage.ToLower().Contains("exception"))
                {
                    var jObject = JObject.Parse(errorMessage);
                    if (jObject.TryGetValue("Message", out var value))
                        return value.ToString();
                }
                errorMessage = JsonConvert.DeserializeObject<string>(errorMessage);
            }
            return errorMessage;
        }

        public HttpClient GetHttpClient(string clientId, string clientSecret, string tokenUrl, string scopes)
        {
            throw new NotImplementedException();
        }

        public async Task<(string ErrorMessage, T list)> GetHTTPResponse<T>(HttpResponseMessage responseInfo, T defaultValue)
        {
            if(responseInfo.IsSuccessStatusCode && (responseInfo.StatusCode == HttpStatusCode.OK ||  responseInfo.StatusCode == HttpStatusCode.Accepted || responseInfo.StatusCode == HttpStatusCode.Created))
            {
                var responseData = await responseInfo.Content.ReadAsStringAsync();
                var _response = JsonConvert.DeserializeObject<T>(responseData);
                return ("", _response);
            }

            var errorMessage = await responseInfo.Content.ReadAsStringAsync();
            return (GetErrorMessage(errorMessage), defaultValue);
        }

        public string GetUrl(string endpointUrl, string apiEndpoint, string methodName)
        {
            return (endpointUrl.EndsWith("/")) ? $"{endpointUrl}{apiEndpoint}{methodName}" : $"{endpointUrl}/{apiEndpoint}{methodName}";
        }

        public HttpClient InitiateClient(string baseUrl)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            return client;
        }
    }
}
