using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using My.NetCore.Framework.Attributes;
using My.NetCore.Framework.Helpers;
using My.NetCore.Framework.ORM.EntityFramework;
using My.NetCore.Framework.Startup;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfigureStartup(Configuration);
            services.AddEngineStartup();
            //register controllers as services
            services.AddControllers();//.AddControllersAsServices();
            services.AddDbContext<EntityFrameworkDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

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
