using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace My.NetCore.IOC
{
    public class EnginContext
    {
        private static IEngine _engine;

        /// <summary>
        /// 当前引擎
        /// </summary>
        public static IEngine Current
        {
            get
            {
                return _engine;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="engine"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]    //多线程同时只能访问一次 
        public static IEngine Initialize(IEngine engine)
        {
            if (_engine == null)
                _engine = engine;
            return _engine;
        }
    }
}
