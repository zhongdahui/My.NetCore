using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using My.NetCore.Framework.IOC;
using My.NetCore.Framework.IOC.Attributes;
using My.NetCore.Framework.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace My.NetCore.Framework.Helpers
{
    public static class AuthenticationHelper
    {

        [Autowired]
        private static IOptions<AppSettingOption> Options { get; set; }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="content"></param>
        /// <param name="model"></param>
        public static void SignIn(this HttpContext content, TokenOption model, string scheme = CookieAuthenticationDefaults.AuthenticationScheme)
        {
            var claimIdentity = new ClaimsIdentity(scheme);
            claimIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, model.ID.ToString()));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Sid, model.UserCode));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Name, model.UserName));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Role, model.UserRole));
            claimIdentity.AddClaim(new Claim(ClaimTypes.AuthorizationDecision, model.UserWork));
            claimIdentity.AddClaim(new Claim(ClaimTypes.UserData, model.UserData));

            content.SignInAsync(scheme, new ClaimsPrincipal(claimIdentity), new AuthenticationProperties() { IsPersistent = true });
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="content"></param>
        public static void SignOut(this HttpContext content, string scheme = CookieAuthenticationDefaults.AuthenticationScheme)
        {
            content.SignOutAsync(scheme);
        }

        /// <summary>
        /// 获取api token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string GetJwtToken(TokenOption model)
        {
            var jwtBearerOption = Options;// EnginContext.Current.Resolve<IOptions<AppSettingOption>>();

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

            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtBearerOption.Value.JwtBearer.SecurityKey));
            var Credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            //创建令牌
            var token = new JwtSecurityToken(
                issuer: jwtBearerOption.Value.JwtBearer.Issuer,
                audience: jwtBearerOption.Value.JwtBearer.Audience,
                signingCredentials: Credentials,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddSeconds(jwtBearerOption.Value.JwtBearer.ExpireSeconds)
            );

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }

        /// <summary>
        /// 是否授权
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static bool IsAuthenticated(this HttpContext content)
        {
            return content.User.Identity.IsAuthenticated;
        }

        /// <summary>
        /// 获取当前token
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string GetToken(this HttpContext content)
        {
            return content.Request.Headers["Authorization"].ObjectToString().Replace("Bearer ", "");
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="content"></param>
        /// <param name="claim"></param>
        /// <returns></returns>
        public static string GetClaimValueByType(this HttpContext content, string claim)
        {
            return content.User.Claims.Where(w => w.Type == claim).FirstOrDefault().Value;
        }

        /// <summary>
        /// 获取登录编号
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string GetUserID(this HttpContext content)
        {
            return content.User.Claims.Where(w => w.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
        }

        /// <summary>
        /// 获取登录帐号编号
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string GetUserCode(this HttpContext content)
        {
            return content.User.Claims.Where(w => w.Type == ClaimTypes.Sid).FirstOrDefault().Value;
        }

        /// <summary>
        /// 获取登录帐号
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string GetUserName(this HttpContext content)
        {
            return content.User.Claims.Where(w => w.Type == ClaimTypes.Name).FirstOrDefault().Value;
        }
    }
}
