using HRM.APIClients;
using HRM.Common;
using HRM_BL;
using HRM_DAL.Data;
using HRM_DAL.Models;
using HRM_DAL.Models.RequestModels;
using HRM_DAL.Models.ResponceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using utility_handler.Data;
//using static error_handler.InformationLog;
using static error_handler.ErrorLog;
using System.Reflection;
using System.Collections.Generic;


namespace HRM.Controllers
{
    [ApiController]
    //[Authorize]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class KioskiController : Controller
    {
        private readonly IKioskiApiClient _KioskiApiClient;
        public KioskiController(IKioskiApiClient KioskiApiClient)
        {
            _KioskiApiClient = KioskiApiClient;
        }

        // 5.2.1 -  Get OAuth Token
        /// <summary>
        /// This is use to get the OAuth Token from the kiosk API
        /// </summary>
        /// <param name="grant_type"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Get_OAuthToken")]
        [HttpPost]
        public async Task<ActionResult> Get_OAuthToken(Get_OAuthToken_RequestModel model)
        {
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, "KioskiController", "Get_OAuthToken", model);

                if (string.IsNullOrEmpty(model.grant_type))
                    return BadRequest(Messages.ValidGrantType);

                string Authorization = Request.Headers["Authorization"];
                var authHeader = AuthenticationHeaderValue.Parse(Authorization);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);

                if (!(credentials[0] == ConfigCaller.KioskiClientID && credentials[1] == ConfigCaller.KioskiClientSecret))
                    return BadRequest(Messages.ValidAuthorization);

                //'client_id:client_secret'

                string RequestReferenceID = Request.Headers["RequestReferenceID"];
                string RequestType = Request.Headers["RequestType"];
                string SmartKioskvendorID = Request.Headers["SmartKioskvendorID"];

                var respResult = await _KioskiApiClient.Get_OAuthToken(model, Authorization, RequestReferenceID, RequestType, SmartKioskvendorID);

                if (!string.IsNullOrWhiteSpace(respResult.ErrorMessage))
                    return Json(respResult.ErrorMessage);

                Response.Headers.Add("RequestReferenceID", RequestReferenceID);
                Response.Headers.Add("RequestType", RequestType);
                Response.Headers.Add("SmartKioskvendorID", SmartKioskvendorID);

                return Json(respResult.bag);

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        // 5.2.2 -  Reset Password
        /// <summary>
        /// This is to use the re-set password
        /// </summary>
        /// <param name="resetPw"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Reset_Password")]
        [HttpPost]
        public async Task<OZero_ReturnResponce> Reset_Password(ResetPassword resetPw)
        {
            OZero_ReturnResponce respResult = new OZero_ReturnResponce();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, "KioskiController", "Reset_Password", resetPw);

                string Authorization = Request.Headers["Authorization"];
                if (string.IsNullOrEmpty(Authorization))
                    return new OZero_ReturnResponce() { message = Messages.ValidAuthorization, messageId = 0 };
                //return BadRequest(Messages.ValidAuthorization);

                string RequestReferenceID = Request.Headers["RequestReferenceID"];
                if (string.IsNullOrEmpty(RequestReferenceID))
                    return new OZero_ReturnResponce() { message = Messages.ValidRequestReferenceID, messageId = 0 };
                //return BadRequest(Messages.ValidRequestReferenceID);

                var authHeader = AuthenticationHeaderValue.Parse(Authorization);
                //var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                //var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                Authorization = authHeader.Parameter;
                //return BadRequest(Messages.ValidAuthorization);
                //
                string RequestType = Request.Headers["RequestType"];
                if (string.IsNullOrEmpty(RequestType))
                    return new OZero_ReturnResponce() { message = Messages.ValidRequestType, messageId = 0 };
                //return BadRequest(Messages.ValidRequestType);

                if (RequestType != "Reset_Password")
                    return new OZero_ReturnResponce() { message = Messages.ValidRequestType, messageId = 0 };
                //return BadRequest(Messages.ValidRequestType);

                string SmartKioskvendorID = Request.Headers["SmartKioskvendorID"];
                if (string.IsNullOrEmpty(SmartKioskvendorID))
                    return new OZero_ReturnResponce() { message = Messages.ValidSmartKioskvendorID, messageId = 0 };
                //return BadRequest(Messages.ValidSmartKioskvendorID);

                respResult = await _KioskiApiClient.Validate_OAuthToken(new Get_OAuthToken_RequestModel() { }, Authorization, RequestReferenceID, RequestType, SmartKioskvendorID);

                if (respResult != null && respResult.messageId == 1)
                {
                    respResult = await _KioskiApiClient.Reset_Password(resetPw, Authorization, RequestReferenceID, RequestType, SmartKioskvendorID);
                }
                else
                {
                    respResult = new OZero_ReturnResponce() { messageId = 1, message = "Authentication Error" };
                }

                //if (!string.IsNullOrWhiteSpace(respResult.ErrorMessage))
                //    return Json(respResult.ErrorMessage);

                Response.Headers.Add("RequestReferenceID", RequestReferenceID);
                Response.Headers.Add("RequestType", RequestType);
                Response.Headers.Add("SmartKioskvendorID", SmartKioskvendorID);

                return respResult;
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        // 5.2.2 -  Reset Password
        /// <summary>
        /// This is to use the re-set password
        /// </summary>
        /// <param name="resetPw"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Validate_OAuthToken")]
        [HttpPost]
        public async Task<OZero_ReturnResponce> Validate_OAuthToken(Get_OAuthToken_RequestModel model)
        {
            OZero_ReturnResponce respResult = new OZero_ReturnResponce();
            try
            {
                LogAuditData.AuditLogRequest(LogAuditData.ModuleNames.HRM_API, "KioskiController", "Validate_OAuthToken", model);

                string Authorization = Request.Headers["Authorization"];
                if (string.IsNullOrEmpty(Authorization))
                    return new OZero_ReturnResponce() { message = Messages.ValidAuthorization, messageId = 0 };
                //return BadRequest(Messages.ValidAuthorization);

                string RequestReferenceID = Request.Headers["RequestReferenceID"];
                if (string.IsNullOrEmpty(RequestReferenceID))
                    return new OZero_ReturnResponce() { message = Messages.ValidRequestReferenceID, messageId = 0 };
                //return BadRequest(Messages.ValidRequestReferenceID);

                var authHeader = AuthenticationHeaderValue.Parse(Authorization);
                //var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                //var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                Authorization = authHeader.Parameter;
                //return BadRequest(Messages.ValidAuthorization);
                //
                string RequestType = Request.Headers["RequestType"];
                if (string.IsNullOrEmpty(RequestType))
                    return new OZero_ReturnResponce() { message = Messages.ValidRequestType, messageId = 0 };
                //return BadRequest(Messages.ValidRequestType);

                string SmartKioskvendorID = Request.Headers["SmartKioskvendorID"];
                if (string.IsNullOrEmpty(SmartKioskvendorID))
                    return new OZero_ReturnResponce() { message = Messages.ValidSmartKioskvendorID, messageId = 0 };
                //return BadRequest(Messages.ValidSmartKioskvendorID);

                respResult = await _KioskiApiClient.Validate_OAuthToken(model, Authorization, RequestReferenceID, RequestType, SmartKioskvendorID);

                Response.Headers.Add("RequestReferenceID", RequestReferenceID);
                Response.Headers.Add("RequestType", RequestType);
                Response.Headers.Add("SmartKioskvendorID", SmartKioskvendorID);

                return respResult;
            }
            catch (System.Exception)
            {

                throw;
            }

        }
    }
}
