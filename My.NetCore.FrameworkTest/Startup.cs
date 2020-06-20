using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using My.NetCore.Framework.AOP;
using My.NetCore.Framework.IOC;
using My.NetCore.Framework.IOC.Attributes;
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
            services.AddTransient<TransactionAOP>();
            services.AddConfigureStartup(Configuration);
            //register controllers as services
            services.AddControllers().AddControllersAsServices();
            //replace `IControllerActivator` implement.
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, AutowiredControllerActivator>());
            //add config to ioc container
            //services.Configure<SnowflakeConfig>(Configuration.GetSection("Snowflake"));
            //use auto dependency injection
            services.AutoRegisterDependency(new List<string> { "My.NetCore.FrameworkTest" });
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

        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    // 在这里添加服务注册
        //    //builder.RegisterType<ProductService>().As<IProductService>();//注册 
        //    var cacheType = new List<Type>();

        //    builder.RegisterType<TransactionAOP>();
        //    cacheType.Add(typeof(TransactionAOP));

        //    var assemblys = Assembly.Load("My.NetCore.FrameworkTest");

        //    var assemblysServices = assemblys.GetExportedTypes().Where(w => w.IsClass && w.GetCustomAttribute(typeof(ServiceAttribute)) != null);
        //    var assemblysRepository = assemblys.GetExportedTypes().Where(w => w.IsClass && w.GetCustomAttribute(typeof(RepositoryAttribute)) != null);

        //    if (assemblysServices != null && assemblysServices.Any())
        //    {
        //        foreach (var item in assemblysServices)
        //        {
        //            builder.RegisterType(item)
        //                  .AsImplementedInterfaces()
        //                  .InstancePerDependency()
        //                  .EnableInterfaceInterceptors()//引用Autofac.Extras.DynamicProxy;
        //                  .InterceptedBy(cacheType.ToArray());//允许将拦截器服务的列表分配给注册。
        //        }
        //    }

        //    if (assemblysRepository != null && assemblysRepository.Any())
        //    {
        //        foreach (var item in assemblysRepository)
        //        {
        //            builder.RegisterType(item)
        //               .AsImplementedInterfaces()
        //               .InstancePerDependency();
        //        }
        //    }

        //    //注册所有控制器
        //    var controllersTypesInAssembly = typeof(Startup).Assembly.GetExportedTypes().Where(type => typeof(ControllerBase).IsAssignableFrom(type)).ToArray();
        //    builder.RegisterTypes(controllersTypesInAssembly).PropertiesAutowired();
        //}
    }
}
