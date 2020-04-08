using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Attributes
{
    /// <summary>
    /// 使用缓存
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class RedisAttribute : Attribute
    {
        public RedisAttributeType Type { get; set; } = RedisAttributeType.Query;

        public string Key { get; set; }

        public string Data { get; set; }

        public int Timeout { get; set; } = 7200;

        public RedisAttribute()
        {

        }

        public RedisAttribute(string key)
        {
            Key = key;
        }

        public RedisAttribute(string key, RedisAttributeType type)
        {
            Key = key;
            Type = type;
        }
    }

    public enum RedisAttributeType
    {
        Query,
        Insert,
        Update,
        Delete,
        Refresh
    }
}
