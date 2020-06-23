using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Framework.IOC
{
    public class GeneralEngine : IEngine
    {
        private IServiceProvider _serviceProvider;

        public GeneralEngine(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        /// <summary>
        /// 构建类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public object Resolve(Type type)
        {
            return _serviceProvider.GetService(type);
        }

        public T Resolve<T>() where T : class
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }
    }
}
