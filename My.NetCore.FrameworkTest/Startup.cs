using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using My.NetCore.Framework.IOC;
using My.NetCore.Framework.IOC.Extensions;
using My.NetCore.Framework.ORM.EntityFramework;
using My.NetCore.Framework.Startup;
using My.NetCore.FrameworkTest.Config;

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
            //register controllers as services
            services.AddControllers().AddControllersAsServices();
            //replace `IControllerActivator` implement.
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, AutowiredControllerActivator>());
            //add config to ioc container
            services.Configure<SnowflakeConfig>(Configuration.GetSection("Snowflake"));
            //use auto dependency injection
            services.AutoRegisterDependency(new List<string> { "My.NetCore.FrameworkTest" });

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
    }
}
