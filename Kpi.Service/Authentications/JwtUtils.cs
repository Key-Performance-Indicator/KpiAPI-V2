using Kpi.Core.Authentications;
using Kpi.Core.Helpers;
using Kpi.Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Service.Authentications
{

  
    public class JwtUtils : IJwtUtils
    {
        private readonly AppSettings _appSettings;

        public JwtUtils(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string GenerateJwtToken(User user, List<Role> roles)
        {
            //// Generate a secure random key with at least 128 bits (16 bytes) length
            //byte[] key = new byte[32]; // Örneğin, 256 bitlik (32 byte) bir anahtar kullanalım
            //using (var rng = new RNGCryptoServiceProvider())
            //{
            //    rng.GetBytes(key);
            //}

            var claims = new List<Claim>
            {
             new Claim("id", user.Id.ToString()),
            new Claim("UserName", user.Username),
            };
            // Rolleri (claims) token'a eklemek
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //
            var token = new JwtSecurityToken(
                issuer : _appSettings.Issuer,
                audience : _appSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials : credentials
                );

            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(claims),
            //    Expires = DateTime.UtcNow.AddDays(1),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public int? ValidateJwtToken(string jwtToken)
        {

            if (jwtToken == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.Key);
            try
            {
                tokenHandler.ValidateToken(jwtToken, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                   
                    //ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var token = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(token.Claims.First(x => x.Type == "id").Value);

                // return user id from JWT token if validation successful
                return userId;
            }
            catch (Exception ex)  
            {
                throw ex;
                return null;
            }
        }
    }
}
