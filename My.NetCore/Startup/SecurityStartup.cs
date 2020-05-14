using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using My.NetCore.Helpers;
using My.NetCore.IOC;
using My.NetCore.Options;
using My.NetCore.Security;
using System;
using System.Text;

namespace My.NetCore.Startup
{
    public static class SecurityStartup
    {
        /// <summary>
        /// 启动身份认证
        /// Authentication
        /// Authorization
        /// </summary>
        /// <param name="services"></param>
        public static void AddAuthenticationStartup(this IServiceCollection services)
        {
            var option = EnginContext.Current.Resolve<IOptions<AppSettingOption>>();

            if(option==null) throw new ArgumentNullException(nameof(option));

            var authenticationOption = option.Value.Authentication;

            if (services == null) throw new ArgumentNullException(nameof(services));
            if (authenticationOption == null) throw new ArgumentNullException(nameof(authenticationOption));
            if (string.IsNullOrEmpty(authenticationOption.AuthenticationScheme)) throw new Exception("authentication is null");

            services.AddAuthentication(authenticationOption.AuthenticationScheme).AddCookie(authenticationOption.AuthenticationScheme, options =>
            {
                options.LoginPath = new PathString(authenticationOption.LoginPath);
                options.LogoutPath = new PathString(authenticationOption.LogoutPath);
                options.AccessDeniedPath = new PathString(authenticationOption.AccessDeniedPath);
            });
        }

        /// <summary>
        /// 启动Jwt身份认证
        /// </summary>
        /// <param name="services"></param>
        public static void AddJwtAuthenticationStartup(this IServiceCollection services)
        {
            var option = EnginContext.Current.Resolve<IOptions<AppSettingOption>>();

            if (option == null) throw new ArgumentNullException(nameof(option));

            var jwtBearerOption = option.Value.JwtBearer;

            if (services == null) throw new ArgumentNullException(nameof(services));
            if (jwtBearerOption == null) throw new ArgumentNullException(nameof(jwtBearerOption));
            if (string.IsNullOrEmpty(jwtBearerOption.AuthenticationScheme)) throw new Exception("authentication is null");

            //添加jwt验证：
            services.AddAuthentication(jwtBearerOption.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = jwtBearerOption.ValidateIssuer,//是否验证Issuer
                    ValidIssuer = jwtBearerOption.Issuer,//Issuer，这两项和前面签发jwt的设置一致
                    ValidateAudience = jwtBearerOption.ValidateAudience,//是否验证Audience
                    ValidAudience = jwtBearerOption.Audience,//Audience
                    ValidateLifetime = jwtBearerOption.ValidateLifetime,//是否验证失效时间
                    ClockSkew = TimeSpan.FromSeconds(jwtBearerOption.ExpireSeconds),
                    ValidateIssuerSigningKey = jwtBearerOption.ValidateIssuerSigningKey,//是否验证SecurityKey
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtBearerOption.SecurityKey))//拿到SecurityKey
                };
            });
        }

        /// <summary>
        /// 启动权限授权
        /// </summary>
        /// <param name="services"></param>
        public static void AddAuthorizationStartup(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
        }
    }
}
