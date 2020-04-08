using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using My.NetCore.ORM.SqlSugar;
using SqlSugar;
using System;
using System.Collections.Generic;

namespace My.NetCore.Startup
{
    public static class SqlSugarStartup
    {
        /// <summary>
        /// SqlSugar上下文注入
        /// </summary>
        /// <typeparam name="TSugarContext">要注册的上下文的类型</typeparam>
        /// <param name="serviceCollection"></param>
        /// <param name="configAction"></param>
        /// <param name="lifetime">用于在容器中注册TSugarClient服务的生命周期</param>
        /// <returns></returns>
        public static void AddSqlSugarStartup<TSugarContext>(this IServiceCollection services, Action<IServiceProvider, ConnectionConfig> configAction = null, ServiceLifetime lifetime = ServiceLifetime.Singleton) where TSugarContext : IDbFactory
        {
            if (configAction != null)
            {
                services.TryAdd(new ServiceDescriptor(typeof(ConnectionConfig), p => ConnectionConfigFactory(p, configAction), lifetime));
            }
            services.TryAdd(new ServiceDescriptor(typeof(TSugarContext), typeof(TSugarContext), lifetime));
        }

        private static ConnectionConfig ConnectionConfigFactory(IServiceProvider applicationServiceProvider, Action<IServiceProvider, ConnectionConfig> configAction)
        {
            var config = new ConnectionConfig();
            configAction.Invoke(applicationServiceProvider, config);
            return config;
        }
    }
}
