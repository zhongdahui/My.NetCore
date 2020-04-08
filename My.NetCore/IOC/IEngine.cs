using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.IOC
{
    public interface IEngine
    {
        /// <summary>
        /// 构建类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object Resolve(Type type);

        T Resolve<T>() where T : class;
    }
}
