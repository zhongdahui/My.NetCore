using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Attributes
{
    /// <summary>
    /// 使用分布式事务锁（redis）
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class TransactionLockAttribute : Attribute
    {
        public string Name { get; set; }

        public TransactionLockAttribute()
        {

        }

        public TransactionLockAttribute(string name)
        {
            Name = name;
        }
    }
}
