﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using My.NetCore.Framework.Helpers;
using My.NetCore.Framework.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Framework.Startup
{
    public static class ConfigureStartup
    {
        public static void AddConfigureStartup(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSingleton(new ConfigHelper(Configuration));
            services.AddOptions();//提供依赖注入
            services.Configure<AppSettingOption>(Configuration.GetSection("AppConfig")); //绑定配置选项
        }
    }
}
