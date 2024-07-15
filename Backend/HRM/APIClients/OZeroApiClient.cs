using HRM.Common;
using HRM.Models;
using HRM_BL;
using HRM_DAL.Data;
using HRM_DAL.Models;
//using System.Web.Script.Serialization;
using HRM_DAL.Models.RequestModels;
using HRM_DAL.Models.ResponceModels;
using HRM_DAL.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Messages = HRM.Common.Messages;

namespace HRM.APIClients
{
    public class KioskiApiClient : IKioskiApiClient
    {
        private readonly HRMOptions _options;
        private readonly IHttpClientHelper _httpClientHelper;
        const string controllerUrl = "api/Kioski/";

        public KioskiApiClient(IOptions<HRMOptions> options, IHttpClientHelper httpClientHelper)
        {
            _options = options.Value;
            _httpClientHelper = httpClientHelper;
        }

        public async Task<(string ErrorMessage, OZeroToken.Rootobject bag)> Get_OAuthToken(Get_OAuthToken_RequestModel model, string Authorization, string RequestReferenceID, string RequestType, string SmartKioskvendorID)
        {
            new WhiteLog("Step 2", "KioskiApiClient", "Get_OAuthToken", true, true);

            //OZeroToken.Rootobject bag = Kioski_APICaller_Data.Get_OAuthToken(model, Authorization, RequestReferenceID, RequestType, SmartKioskvendorID);
            var generator = new PasswordGenerator(minimumLengthPassword: 100, maximumLengthPassword: 200);
            string password = generator.Generate();
            int expiresIn = HRM_DAL.Data.ConfigCaller.OZeroExpiresIn;

            OZeroToken.Rootobject tok = new OZeroToken.Rootobject()
            {
                message = "Success",
                messageId = 1,
                RequestReferenceID = RequestReferenceID,
                result = new OZeroToken.Result()
                {
                    accessToken = password,
                    expiresIn = expiresIn,
                    scope = "create",
                    tokenType = "Bearer"
                }
            };

            OZero_BL.Get_OAuthToken(model, RequestReferenceID, RequestType, SmartKioskvendorID, password, expiresIn);

            return ("", tok);
        }

        public async Task<OZero_ReturnResponce> Validate_OAuthToken(Get_OAuthToken_RequestModel model, string authorization, string requestReferenceID, string RequestType, string SmartKioskvendorID)
        {
            new WhiteLog("Step 2", "KioskiApiClient", "Validate_OAuthToken", true, true);

            OZero_ReturnResponce bag = OZero_BL.Validate_OAuthToken(authorization, requestReferenceID, RequestType, SmartKioskvendorID);
            //OZero_ReturnResponce bag = Kioski_APICaller_Data.Validate_OAuthToken(model, authorization, requestReferenceID, RequestType, SmartKioskvendorID);

            return bag;
        }

        public async Task<OZero_ReturnResponce> Reset_Password(ResetPassword resetPw, string Authorization, string RequestReferenceID, string RequestType, string SmartKioskvendorID)
        {
       
            OZero_ReturnResponce retObj = new OZero_ReturnResponce();


            //retObj = user_BL.reset_password_kioski(resetPw);

            return retObj;

        }

    }
}
