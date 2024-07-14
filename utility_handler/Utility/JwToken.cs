
using Microsoft.IdentityModel.Tokens;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace utility_handler.Utility
{
    public class JwToken
    {

        public static string Authenticate(string uid)
        {
            //claims
            var claims = new[]
            {
                //new Claim ("uid",uid),
                new Claim(ClaimTypes.Name, uid.ToString())
                //new Claim (JwtRegisteredClaimNames.,uid)
            };

            var KeyBytes = Encoding.UTF8.GetBytes(constants.Secret);

            var key = new SymmetricSecurityKey(KeyBytes);
            SigningCredentials sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var signingCredentials = sc;



            var token = new JwtSecurityToken(
                constants.Audience,
                constants.Ishuer,
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(12),
                signingCredentials);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            //return Ok(new {accessToken = tokenString });
            return tokenString;
        }


    }






}
