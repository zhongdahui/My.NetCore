﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Startup
{
    public static class CorsStartup
    {
        private readonly static string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public static void AddCorsStartup(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins, builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
        }

        public static void UseCorsMiddleware(this IApplicationBuilder builder)
        {
            builder.UseCors(MyAllowSpecificOrigins);
        }
    }
}
