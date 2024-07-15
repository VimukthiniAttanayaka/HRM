using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HRM.Controllers.Services;
using error_handler;
using utility_handler.Utility;
using HRM_DAL.Models;

namespace HRM.Controllers.Helpers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserService _userService;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUserService userService
            )
            : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            LogError objError = new LogError();
            string strUserName = "";

            // skip authentication if endpoint has [AllowAnonymous] attribute
            var endpoint = Context.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
                return AuthenticateResult.NoResult();

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                StaticClasses.AuthenticateSuccess = false;
                objError.WriteLog(0, "BasicAuthenticationHandler", "HandleAuthenticateAsync", ConfigCaller.AuthenticationFailMessage + " : " +
                       "Missing Authorization Header");
                return AuthenticateResult.Fail("Missing Authorization Header");
            }

            AuthenticatedUserModel user = null;

            var claimsDummy = new[] {
                new Claim(ClaimTypes.NameIdentifier, ""),
                new Claim(ClaimTypes.Name, ""),
            };
            var identityDummy = new ClaimsIdentity(claimsDummy, Scheme.Name);
            var principalDummy = new ClaimsPrincipal(identityDummy);

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);

                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);

                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                //var username = credentials[0];
                //var password = credentials[1];
                //strUserName = username;
                string strAuthentication = "";
                user = await _userService.Authenticate(/*username, password*/strAuthentication);
            }
            catch
            {
                StaticClasses.AuthenticateSuccess = false;
                objError.WriteLog(0, "BasicAuthenticationHandler", "HandleAuthenticateAsync", ConfigCaller.AuthenticationFailMessage + " : " +
                     "UserName: " + strUserName);
                return AuthenticateResult.Success(new AuthenticationTicket(principalDummy, Scheme.Name));
            }

            if (user == null)
            {
                StaticClasses.AuthenticateSuccess = false;
                objError.WriteLog(0, "BasicAuthenticationHandler", "HandleAuthenticateAsync", ConfigCaller.AuthenticationFailMessage + " : " +
                       "UserName: " + strUserName);
                return AuthenticateResult.Success(new AuthenticationTicket(principalDummy, Scheme.Name));
            }

            var claims = new[] {
                new Claim(ClaimTypes.Name, user.Username),
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);

            StaticClasses.AuthenticateSuccess = true;
            return AuthenticateResult.Success(new AuthenticationTicket(principal, Scheme.Name));
        }
    }
}