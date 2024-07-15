using HRM.APIClients;
using HRM.Common;
using HRM_DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM_DAL.Models.RequestModels;
using System;
using System.Linq;
using HRM_DAL.Data;

namespace HRM.Controllers
{
    [ApiController]
    //[Authorize]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class HRMController : Controller
    {
        private readonly IHRMApiClient _mailTrackerApiClient;
        public HRMController(IHRMApiClient mailTrackerApiClient)
        {
            _mailTrackerApiClient = mailTrackerApiClient;
        }

        // 5.1.1.1 -  Get OAuth Token
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
            if (string.IsNullOrEmpty(model.grant_type))
                return BadRequest(Messages.ValidGrantType);

            var respResult = await _mailTrackerApiClient.Get_OAuthToken(model);

            if (!string.IsNullOrWhiteSpace(respResult.ErrorMessage))
                return Json(respResult.ErrorMessage);

            return Json(respResult.AuthenticationTokenMsg);
        }
      
    }
}
