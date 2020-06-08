using My.NetCore.Framework.IOC.Models;
using System;

namespace My.NetCore.Framework.IOC.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ComponentAttribute : Attribute
    {

        public Lifetime DependencyInjectionMode
        {
            get;
        } = Lifetime.Scoped;

        public Type ImplementInterface
        {
            get;
        } = null;

        public ComponentAttribute()
        {
        }


        public ComponentAttribute(Lifetime dependencyInjectionMode)
        {
            this.DependencyInjectionMode = dependencyInjectionMode;
        }
        public ComponentAttribute(Type implementInterface)
        {
            this.ImplementInterface = implementInterface;
        }
        public ComponentAttribute(Lifetime dependencyInjectionMode, Type implementInterface)
        {
            this.DependencyInjectionMode = dependencyInjectionMode;
            this.ImplementInterface = implementInterface;
        }

    }
}
