using My.NetCore.Framework.IOC.Models;
using System;

namespace My.NetCore.Framework.IOC.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ServiceAttribute : Attribute
    {
        public Lifetime DependencyInjectionMode
        {
            get;
        } = Lifetime.Scoped;

        public Type ImplementInterface
        {
            get;
        } = null;

        public ServiceAttribute()
        {
        }

        public ServiceAttribute(Lifetime dependencyInjectionMode)
        {
            this.DependencyInjectionMode = dependencyInjectionMode;
        }
        public ServiceAttribute(Type implementInterface)
        {
            this.ImplementInterface = implementInterface;
        }
        public ServiceAttribute(Lifetime dependencyInjectionMode, Type implementInterface)
        {
            this.DependencyInjectionMode = dependencyInjectionMode;
            this.ImplementInterface = implementInterface;
        }
    }
}
