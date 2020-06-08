using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Framework.Options
{
    public class DbContextOption
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// 实体程序集名称
        /// </summary>
        public string ModelAssemblyName { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public string DbType { get; set; } = "MySql";
    }

    /// <summary>
    /// 数据库类型枚举
    /// </summary>
    //public enum DbType
    //{
    //    MySql = 0,
    //    SqlServer = 1,
    //    Sqlite = 2,
    //    Oracle = 3,
    //    PostgreSQL = 4,
    //    Memory=5
    //}
}
