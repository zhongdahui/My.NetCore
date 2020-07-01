using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Framework.Attributes
{
    /// <summary>
    /// 使用分布式事务锁（redis）
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class TransactionLockAttribute : Attribute
    {
        public string Name { get; set; }

        /// <summary>
        /// 锁定超时时间
        /// </summary>
        public int LockTime { get; set; }

        public TransactionLockAttribute()
        {

        }

        public TransactionLockAttribute(string name, int lockTime = 60)
        {
            Name = name;
            LockTime = lockTime;
        }
    }
}
