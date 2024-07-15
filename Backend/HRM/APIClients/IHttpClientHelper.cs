using System.Net.Http;
using System.Threading.Tasks;

namespace HRM.APIClients
{
    public interface IHttpClientHelper
    {
        HttpClient InitiateClient(string baseUrl);
        HttpClient GetHttpClient(string clientId, string clientSecret, string tokenUrl, string scopes);
        string GetUrl(string endpointUrl, string apiEndpoint, string methodName);
        Task<(string ErrorMessage, T list)> GetHTTPResponse<T>(HttpResponseMessage responseInfo, T defaultValue);
        string GetErrorMessage(string responseInfo);
    }
}
