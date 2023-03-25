using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CourseApplicationWithWebApi.Service
{
    public class TokenGenerator : ITokenGenerator
    {
      
            public string GenerateToken(int id, string name)
            {
                //Claims
                var userClaims = new Claim[]
                {
                new Claim(JwtRegisteredClaimNames.Jti,new Guid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName,name),
                };
                //secret key-aabhinavkumarsinghh
                //encoding the Secret Key
                var userSecretKey = Encoding.UTF8.GetBytes("aabhinavkumarsinghh");
                //convert the encoded key to symmetric key
                var userSymmetricSecurityKey = new SymmetricSecurityKey(userSecretKey);
                //sign the token
                var userSigningCredentials = new SigningCredentials(userSymmetricSecurityKey, SecurityAlgorithms.HmacSha256);
                var userJwtsecurityToken = new JwtSecurityToken(
                    issuer: "MVCApp",
                    audience: "MVCAppUsers",
                    claims: userClaims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: userSigningCredentials);
                var userSecurityTokenHandler = new JwtSecurityTokenHandler().WriteToken(userJwtsecurityToken);

            string userJwtSecurityJsontokenHandler = JsonConvert.SerializeObject(new { Token = userSecurityTokenHandler ,Name=name});
                return userJwtSecurityJsontokenHandler;
            }
            #region SimpleValidation
            //public bool IsTokenValid(string userToken)
            //{
            //    if (userToken == null)
            //    {
            //        return true;
            //    }
            //    return false;
            //}
            #endregion

            public bool IsTokenValid(string userAudience, string userIssuer, string userSecretKey, string userToken)
            {
                var userSecretKeyInBytes = Encoding.UTF8.GetBytes(userSecretKey);
                var userSymmetricSecurityKey = new SymmetricSecurityKey(userSecretKeyInBytes);
                var tokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = userIssuer,

                    ValidateAudience = true,
                    ValidAudience = userAudience,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = userSymmetricSecurityKey,

                    ValidateLifetime = true,
                };
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                try
                {
                    tokenHandler.ValidateToken(userToken, tokenValidationParameters, out SecurityToken securityToken);
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }
    }



  