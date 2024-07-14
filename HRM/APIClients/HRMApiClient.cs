using HRM.Common;
using HRM.Models;
using HRM_DAL.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using HRM_DAL.Data;
using System;
//using System.Web.Script.Serialization;
using HRM_DAL.Models.RequestModels;
using HRM_DAL.Models.ResponceModels;
using HRM_BL;
using System.Collections.Generic;
using System.Linq;

namespace HRM.APIClients
{
    public class HRMApiClient : IHRMApiClient
    {
        private readonly HRMOptions _options;
        private readonly IHttpClientHelper _httpClientHelper;
        const string controllerUrl = "api/HRM/";

        public HRMApiClient(IOptions<HRMOptions> options, IHttpClientHelper httpClientHelper)
        {
            _options = options.Value;
            _httpClientHelper = httpClientHelper;
        }

        public async Task<(string ErrorMessage, HRMToken.Rootobject AuthenticationTokenMsg)> Get_OAuthToken(Get_OAuthToken_RequestModel model)
        {
            //if (string.IsNullOrWhiteSpace(_options.EndpointUrl))
            //{
            //    return (Messages.ApiAndPointNotConfigured, new HRMToken.Rootobject());
            //}

            HRMToken.Rootobject tok = new HRMToken.Rootobject();// HRM_APICaller_Data.GetToken();

            return ("", tok);
        }
   }
}
