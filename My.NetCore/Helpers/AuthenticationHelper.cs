using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using My.NetCore.IOC;
using My.NetCore.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace My.NetCore.Helpers
{
    public class AuthenticationHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="model"></param>
        public static void SignIn(HttpContext content, TokenOption model)
        {
            var claimIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            claimIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, model.ID.ToString()));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Sid, model.UserCode));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Name, model.UserName));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Role, model.UserRole));
            claimIdentity.AddClaim(new Claim(ClaimTypes.AuthorizationDecision, model.UserWork));
            claimIdentity.AddClaim(new Claim(ClaimTypes.UserData, model.UserData));

            content.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                new ClaimsPrincipal(claimIdentity),
                                new AuthenticationProperties() { IsPersistent = true });

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        public static void SignOut(HttpContext content)
        {
            content.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jwtBearerOption"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string GetJwtToken(JwtBearerOption jwtBearerOption, TokenOption model)
        {
            //创建用户身份标识，可按需要添加更多信息
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, model.ID.ToString()),
                new Claim(ClaimTypes.Sid, model.UserCode), // 用户id
                new Claim(ClaimTypes.Name, model.UserName), // 用户名
                new Claim(ClaimTypes.Role, model.UserRole), // 是否是管理员
                new Claim(ClaimTypes.AuthorizationDecision,model.UserWork),
                new Claim(ClaimTypes.UserData, model.UserData)
            };

            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtBearerOption.SecurityKey));
            var Credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            //创建令牌
            var token = new JwtSecurityToken(
                issuer: jwtBearerOption.Issuer,
                audience: jwtBearerOption.Audience,
                signingCredentials: Credentials,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddSeconds(jwtBearerOption.ExpireSeconds)
            );

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }

        public static bool IsAuthenticated(HttpContext content)
        {
            return content.User.Identity.IsAuthenticated;
        }

        public static string GetToken(HttpContext content)
        {
            return content.Request.Headers["Authorization"].ObjectToString().Replace("Bearer ", "");
        }

        public static IEnumerable<Claim> GetClaimsIdentity(HttpContext content)
        {
            return content.User.Claims;
        }

        public static List<string> GetClaimValueByType(HttpContext content, string ClaimType)
        {
            return (from item in GetClaimsIdentity(content)
                    where item.Type == ClaimType
                    select item.Value).ToList();

        }
    }
}
