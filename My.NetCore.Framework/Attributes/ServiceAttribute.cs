using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class ServiceAttribute: Attribute
    {
    }
}
