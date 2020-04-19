using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using My.NetCore.Payment.Core.Gateways;
using My.NetCore.Payment.Core.Utils;
using System;

namespace My.NetCore.Payment.Core
{
    public static class ICanPayExtension
    {
        public static void AddICanPay(this IServiceCollection services, Func<IServiceProvider, IGateways> func)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient(func);
        }

        public static IApplicationBuilder UseICanPay(this IApplicationBuilder app)
        {
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            HttpUtil.Configure(httpContextAccessor);

            return app;
        }
    }
}
