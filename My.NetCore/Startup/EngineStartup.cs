﻿using Microsoft.Extensions.DependencyInjection;
using My.NetCore.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Startup
{
    public static class EngineStartup
    {
        public static void AddEngineStartup(this IServiceCollection services)
        {
            EnginContext.Initialize(new GeneralEngine(services.BuildServiceProvider()));
        }
    }
}
