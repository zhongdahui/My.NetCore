using Consul;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using My.NetCore.Microservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Startup
{
    public static class MicroserviceStartup
    {
        public static void AddConsulSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                consulConfig.Address = new Uri(configuration[""]);
            }));
            services.AddSingleton<IHostedService, ConsulHostedService>();
            services.AddHealthChecks();
        }
    }
}