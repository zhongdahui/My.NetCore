using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Framework.Attributes
{
    /// <summary>
    /// 添加监控方法执行日志
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class ActionLoggerAttribute : Attribute
    {

    }
}
