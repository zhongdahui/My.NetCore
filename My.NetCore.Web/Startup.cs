using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using My.NetCore.AOP;
using My.NetCore.Attributes;
using My.NetCore.Startup;
using My.NetCore.Filters;
using My.NetCore.ORM.EntityFramework;

namespace My.NetCore.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfigureStartup(Configuration);
            services.AddControllersWithViews(config => { config.Filters.Add(typeof(GlobalExceptionFilter)); }).AddControllersAsServices();
            services.AddEngineStartup();
            services.AddSwaggerStartup();
            services.AddDbContext<EntityFrameworkDbContext>();
            services.AddAuthenticationStartup();
            services.AddJwtAuthenticationStartup();
            //services.AddDbContext<EntityFrameworkDbContext>(options =>
            //{
            //    //options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection"));
            //    options.UseMySql("server=10.28.88.238;uid=root;pwd=3$%*(k/{]rtEE5;database=ha_test");
            //});
            //services.AddSqlSugarStartup<SqlSugarDbContext>();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // 在这里添加服务注册
            //builder.RegisterType<ProductService>().As<IProductService>();//注册 
            var cacheType = new List<Type>();

            builder.RegisterType<ActionLoggerAOP>();
            cacheType.Add(typeof(ActionLoggerAOP));

            builder.RegisterType<TransactionAOP>();
            cacheType.Add(typeof(TransactionAOP));

            builder.RegisterType<TransactionLockAOP>();
            cacheType.Add(typeof(TransactionLockAOP));

            builder.RegisterType<RedisAOP>();
            cacheType.Add(typeof(RedisAOP));

            var assemblys = Assembly.Load("My.NetCore.Web");

            var assemblysServices = assemblys.GetExportedTypes().Where(w => w.IsClass && w.GetCustomAttribute(typeof(ServiceAttribute)) != null);
            var assemblysRepository = assemblys.GetExportedTypes().Where(w => w.IsClass && w.GetCustomAttribute(typeof(RepositoryAttribute)) != null);

            if (assemblysServices != null && assemblysServices.Any())
            {
                foreach (var item in assemblysServices)
                {
                    builder.RegisterType(item)
                          .AsImplementedInterfaces()
                          .InstancePerDependency()
                          .EnableInterfaceInterceptors()//引用Autofac.Extras.DynamicProxy;
                          .InterceptedBy(cacheType.ToArray());//允许将拦截器服务的列表分配给注册。
                }
            }

            if (assemblysRepository != null && assemblysRepository.Any())
            {
                foreach (var item in assemblysRepository)
                {
                    builder.RegisterType(item)
                       .AsImplementedInterfaces()
                       .InstancePerDependency();
                }
            }

            //注册所有控制器
            var controllersTypesInAssembly = typeof(Startup).Assembly.GetExportedTypes().Where(type => typeof(ControllerBase).IsAssignableFrom(type)).ToArray();
            builder.RegisterTypes(controllersTypesInAssembly).PropertiesAutowired();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseSwaggerMiddleware();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
