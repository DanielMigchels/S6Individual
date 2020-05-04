using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Models;
using System.Linq;

namespace Shared.Jwt
{
    public class JwtUtility
    {
        //TODO: Move this
        private static string key = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";

        private static JwtHeader Setup()
        {
            byte[] key = Encoding.UTF8.GetBytes(JwtUtility.key);

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            return new JwtHeader(credentials);
        }

        public static string GenerateJwt(User user)
        {
            JwtHeader header = Setup();

            var payload = new JwtPayload
            {
                { "user-id", user.Id }
            };

            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(secToken);
        }

        public static int ReadJwt(string JWT)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            JwtSecurityToken token = handler.ReadJwtToken(JWT);

            return int.Parse(token.Payload.First(payload => payload.Key == "user-id").Value.ToString());
        }
    }
}
