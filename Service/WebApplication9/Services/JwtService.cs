using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication9.Services
{
    public class JwtService
    {

        private static string JwtSecretSign = "ProEMLh5e_qnzdNUQrqdHPgp";
        private static string JwtSecretDecrypt = "ProEMLh5e_qnzdNU";
        private TimeSpan TokenNumMinutesToExtend = new TimeSpan(1, 1, 0);
        private TimeSpan TokenMaxMinutesSession = new TimeSpan(2, 0, 0);

        public const string TokenPrimaryKey = "UserId";
        public static SymmetricSecurityKey JwtSymmetricSecurityIssuerSigningKey => new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(JwtSecretSign));
        public static SymmetricSecurityKey JwtSymmetricSecurityTokenDecryptionKey => new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(JwtSecretDecrypt));

        public IHttpContextAccessor HttpContextAccessor { get; }
        public HttpRequest Request => HttpContextAccessor.HttpContext?.Request;

        public JwtService(IHttpContextAccessor http)
        {
            HttpContextAccessor = http;
        }
        //החלק שאוכף את הטוקן והוא מוגדר בstartup.cs
        public static TokenValidationParameters TokenValidationParameters => new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = JwtSymmetricSecurityIssuerSigningKey,
            TokenDecryptionKey = JwtSymmetricSecurityTokenDecryptionKey,
            ValidIssuer = "issuer",
            ValidAudience = "Audience",
            ValidateIssuer = true,
            ValidateAudience = true,
            RequireExpirationTime = true,
            ClockSkew = TimeSpan.Zero
        };

        //החלק שמחולל את המפתח -הטוקן
        public string GenerateToken(string tokenPrimaryValue)
        {
            DateTime expired = DateTime.Now.Add(TokenNumMinutesToExtend);


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "issuer",
                Audience = "Audience",
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(TokenPrimaryKey, tokenPrimaryValue),
                }),
                Expires = expired,
                SigningCredentials = new SigningCredentials(JwtSymmetricSecurityIssuerSigningKey, SecurityAlgorithms.HmacSha512),
                EncryptingCredentials = new EncryptingCredentials(JwtSymmetricSecurityTokenDecryptionKey, SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var tokenStr = $"Bearer {tokenHandler.WriteToken(token)}";

            return tokenStr;
        }


        public string GetTokenClaims()
        {
            string tokenString = Request.Headers["Authorization"];
            tokenString ??= "";
            tokenString = tokenString.Trim();

            if (string.IsNullOrEmpty(tokenString)) { throw new Exception("JwtService - Token Is Empty"); }
            if (tokenString.Length <= "Bearer ".Length) { throw new Exception("JwtService - Token Is Too Short"); }

            try
            {
                var accesToken = tokenString.Substring("Bearer ".Length);

                // משתמשים בפונקציה של JWT בכדי להוציא את הפרמטרים של המפתח
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(accesToken, TokenValidationParameters, out var securityToken);
                JwtSecurityToken jwtToken = ((JwtSecurityToken)securityToken);

                return jwtToken.Claims.ToList().FirstOrDefault(claim => claim.Type == TokenPrimaryKey)?.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"JwtService Error TokenClaims  Invalid Token - {ex.Message}");
            }
        }








        /*        private static string JwtSecretSign = "ProEMLh5e_qnzdNUQrqdHPgp";
                private static string JwtSecretDecrypt = "ProEMLh5e_qnzdNU";
                private TimeSpan TokenNumMinutesToExtend = new TimeSpan(1, 0, 0);
                private TimeSpan TokenMaxMinutesSession = new TimeSpan(2, 0, 0);

                public const string TokenPrimaryKey = "UserId";
                public static SymmetricSecurityKey JwtSymmetricSecurityIssuerSigningKey => new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(JwtSecretSign));
                public static SymmetricSecurityKey JwtSymmetricSecurityTokenDecryptionKey => new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(JwtSecretDecrypt));

                public IHttpContextAccessor HttpContextAccessor { get; }
                public HttpRequest Request => HttpContextAccessor.HttpContext?.Request;


                public static TokenValidationParameters TokenValidationParameters => new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = JwtSymmetricSecurityIssuerSigningKey,
                    TokenDecryptionKey = JwtSymmetricSecurityTokenDecryptionKey,
                    ValidIssuer = "issuer",
                    ValidAudience = "Audience",
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    //ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.Zero,
                    // LifetimeValidator = ValidateLifetime
                };

                public JwtService(IHttpContextAccessor http)
                {
                    HttpContextAccessor = http;
                }

                //public List<Claim> GetTokenClaims()
                //{
                //    string tokenString = Request.Headers["Authorization"];
                //    tokenString ??= "";
                //    tokenString = tokenString.Trim();

                //    if (string.IsNullOrEmpty(tokenString)) { throw new Exception("JwtService - Token Is Empty"); }
                //    if (tokenString.Length <= "Bearer ".Length) { throw new Exception("JwtService - Token Is Too Short"); }
                //    if (!tokenString.Substring(0, "Bearer".Length).EqualsIgnoreCase("bearer")) { throw new Exception("JwtService - Token Must Start With 'Bearer '"); }
                //    try
                //    {
                //        var accesToken = tokenString.Substring("Bearer ".Length);
                //        var tokenHandler = new JwtSecurityTokenHandler();
                //        tokenHandler.ValidateToken(accesToken, TokenValidationParameters, out var securityToken);

                //        JwtSecurityToken jwtToken = ((JwtSecurityToken)securityToken);
                //        return jwtToken.Claims.ToList();
                //    }
                //    catch (Exception ex)
                //    {
                //        throw new Exception($"JwtService Error TokenClaims  Invalid Token - {ex.Message}");
                //    }
                //}

                //public string GetTokenPrimaryValue()
                //{
                //    try
                //    {
                //        return GetTokenClaims().FirstOrDefault(claim => claim.Type == TokenPrimaryKey)?.Value;
                //    }
                //    catch (Exception ex)
                //    {
                //        throw new Exception($"JwtService Get Token PrimaryValue Error - Invalid Token - {ex.Message}");
                //    }
                //}



                public string GenerateToken(string tokenPrimaryValue)
                {
                    DateTime expired = DateTime.Now.Add(TokenNumMinutesToExtend);
                    //maxExpired ??= DateTime.UtcNow.Add(TokenMaxMinutesSession);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Issuer = "issuer",
                        Audience = "Audience",
                        Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(TokenPrimaryKey, tokenPrimaryValue),
                            //new Claim("MaxExpired",maxExpired.Value.ToString("yyyy-MM-dd HH:mm:ss")),
                            //new Claim("Expired",expired.Value.ToString("yyyy-MM-dd HH:mm:ss")),
                        }),
                        Expires = expired,
                        SigningCredentials = new SigningCredentials(JwtSymmetricSecurityIssuerSigningKey, SecurityAlgorithms.HmacSha512),
                        EncryptingCredentials = new EncryptingCredentials(JwtSymmetricSecurityTokenDecryptionKey, SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
                    var tokenStr = $"Bearer {tokenHandler.WriteToken(token)}";

                    return tokenStr;
                }

                //public static bool ValidateLifetime(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
                //{
                //    JwtSecurityToken jwtToken = ((JwtSecurityToken)securityToken);
                //    DateTime? expiresDate = jwtToken.Payload["Expired"].ToDate();
                //    DateTime? maxExpired = jwtToken.Payload["MaxExpired"].ToDate();

                //    if (expiresDate == null || !validationParameters.ValidateIssuer)
                //    {
                //        return false;
                //    }

                //    return expiresDate >= DateTime.UtcNow && maxExpired >= DateTime.UtcNow;
                //}*/

    }
}
