using Autofac;
using Autofac.Extras.DynamicProxy;
using My.NetCore.Framework.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace My.NetCore.Framework.Helpers
{
    public static class AutofacHelper
    {
        public static void ConfigureContainer(this ContainerBuilder builder)
        {
            string assemblys_list = "My.NetCore.FrameworkTest,My.NetCore.Framework";

            if (!string.IsNullOrEmpty(assemblys_list))
            {
                List<Type> assemblysServices = new List<Type>();
                List<Type> assemblysRepository = new List<Type>();
                List<Type> assemblysFilter = new List<Type>();
                List<Type> assemblysComponent = new List<Type>();
                List<Type> assemblysConfig = new List<Type>();

                foreach (var assemblys_item in assemblys_list.Split(','))
                {
                    var assemblys = Assembly.Load(assemblys_item);
                    var tmp_assemblysServices = assemblys.GetExportedTypes().Where(t => t.IsClass && (t.GetCustomAttribute(typeof(ServiceAttribute)) != null));
                    var tmp_assemblysRepository = assemblys.GetExportedTypes().Where(t => t.IsClass && (t.GetCustomAttribute(typeof(RepositoryAttribute)) != null));
                    var tmp_assemblysFilter = assemblys.GetExportedTypes().Where(t => t.IsClass && (t.GetCustomAttribute(typeof(FilterAttribute)) != null));
                    var tmp_assemblysComponent = assemblys.GetExportedTypes().Where(t => t.IsClass && (t.GetCustomAttribute(typeof(ComponentAttribute)) != null));
                    var tmp_assemblysConfig = assemblys.GetExportedTypes().Where(t => t.IsClass && (t.GetCustomAttribute(typeof(ConfigAttribute)) != null));

                    if (tmp_assemblysServices != null && tmp_assemblysServices.Any())
                    {
                        assemblysServices.AddRange(tmp_assemblysServices);
                    }
                    if (tmp_assemblysRepository != null && tmp_assemblysRepository.Any())
                    {
                        assemblysRepository.AddRange(tmp_assemblysRepository);
                    }
                    if (tmp_assemblysFilter != null && tmp_assemblysFilter.Any())
                    {
                        assemblysFilter.AddRange(tmp_assemblysFilter);
                    }
                    if (tmp_assemblysComponent != null && tmp_assemblysComponent.Any())
                    {
                        assemblysComponent.AddRange(tmp_assemblysComponent);
                    }
                    if (tmp_assemblysConfig != null && tmp_assemblysConfig.Any())
                    {
                        assemblysConfig.AddRange(tmp_assemblysConfig);
                    }
                }

                if (assemblysComponent != null && assemblysComponent.Any())
                {
                    builder.RegisterTypes(assemblysComponent.ToArray());
                }

                if (assemblysConfig != null && assemblysConfig.Any())
                {
                    builder.RegisterTypes(assemblysConfig.ToArray());
                }

                if (assemblysFilter != null && assemblysFilter.Any())
                {
                    builder.RegisterTypes(assemblysFilter.ToArray());
                }

                if (assemblysServices != null && assemblysServices.Any())
                {
                    builder.RegisterTypes(assemblysServices.ToArray())
                           .AsImplementedInterfaces()
                           .InstancePerDependency()
                           .EnableInterfaceInterceptors()//引用Autofac.Extras.DynamicProxy;
                           .InterceptedBy(assemblysFilter.ToArray());//允许将拦截器服务的列表分配给注册。

                }

                if (assemblysRepository != null && assemblysRepository.Any())
                {
                    builder.RegisterTypes(assemblysRepository.ToArray())
                           .AsImplementedInterfaces()
                           .InstancePerDependency();
                }
            }
        }
    }
}
