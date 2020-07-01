using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using My.NetCore.Framework.Filters;
using My.NetCore.Framework.Helpers;
using My.NetCore.Framework.ORM.EntityFramework;
using My.NetCore.Framework.Startup;
using My.NetCore.Framework.Utils;
using My.NetCore.FrameworkTest.Services;

namespace My.NetCore.FrameworkTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfigureStartup(Configuration);
            services.AddControllers(config => { config.Filters.Add(typeof(GlobalExceptionFilter)); }).AddControllersAsServices().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            });
            services.AddEngineStartup();
            //services.AddDbContext<EntityFrameworkDbContext>();
            services.AddJwtAuthenticationStartup();
            services.AddSwaggerStartup();
            services.AddCorsStartup();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerMiddleware();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCorsMiddleware();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.ConfigureContainer();
        }
    }
}
