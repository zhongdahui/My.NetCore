using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Options
{
    public class RedisOption
    {
        /// <summary>
        /// 连接字符串（10.28.88.221:6379,defaultdatabase=1）
        /// </summary>
        public string Connection { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string InstanceName { get; set; } = "redis";
    }
}
