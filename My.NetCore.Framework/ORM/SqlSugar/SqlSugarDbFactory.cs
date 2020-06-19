using SqlSugar;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace My.NetCore.Framework.ORM.SqlSugar
{
    public class SqlSugarDbFactory
    {
        private static ConcurrentDictionary<string, SqlClient> _cache = new ConcurrentDictionary<string, SqlClient>();
        private static ThreadLocal<string> _threadLocal;
        private static readonly string _connStr = @"server=10.28.88.238;uid=root;pwd=3$%*(k/{]rtEE5;database=ha_test";

        static SqlSugarDbFactory()
        {
            _threadLocal = new ThreadLocal<string>();
        }

        private static SqlSugarClient CreatInstance()
        {
            SqlSugarClient client = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = _connStr, //必填
                DbType = DbType.MySql, //必填
                IsAutoCloseConnection = true, //默认false
                InitKeyType = InitKeyType.SystemTable
            });

            client.Aop.OnLogExecuted = (sql, pars) => //SQL执行完事件
            {
                Console.WriteLine($"OnLogExecuted({client.GetHashCode()})：" + sql);
            };
            client.Aop.OnLogExecuting = (sql, pars) => //SQL执行前事件
            {
                Console.WriteLine($"OnLogExecuting({client.GetHashCode()})：" + sql);
            };
            client.Aop.OnError = (exp) =>//执行SQL 错误事件
            {
                Console.WriteLine($"OnError({client.GetHashCode()})：" + exp.Message);
            };
            client.Aop.OnExecutingChangeSql = (sql, pars) => //SQL执行前 可以修改SQL
            {
                Console.WriteLine($"OnExecutingChangeSql({client.GetHashCode()})：" + sql);
                return new KeyValuePair<string, SugarParameter[]>(sql, pars);
            };

            var key = Guid.NewGuid().ToString().Replace("-", "");
            if (!_cache.ContainsKey(key))
            {
                _cache.TryAdd(key, new SqlClient(client));
                _threadLocal.Value = key;
                return client;
            }
            throw new Exception("创建SqlSugarClient失败");
        }

        public static SqlClient GetInstance()
        {
            var id = _threadLocal.Value;
            if (string.IsNullOrEmpty(id) || !_cache.ContainsKey(id))
                return new SqlClient(CreatInstance());
            return _cache[id];
        }

        public static void Release()
        {
            try
            {
                var id = GetId();
                if (!_cache.ContainsKey(id))
                    return;
                Remove(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static bool Remove(string id)
        {
            if (!_cache.ContainsKey(id)) return false;

            SqlClient client;

            int index = 0;
            bool result = false;
            while (!(result = _cache.TryRemove(id, out client)))
            {
                index++;
                Thread.Sleep(20);
                if (index > 3) break;
            }
            return result;
        }

        private static string GetId()
        {
            var id = _threadLocal.Value;
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("内部错误: SqlSugarClient已丢失.");
            }
            return id;
        }

        public static void BeginTran()
        {
            var instance = GetInstance();
            //开启事务
            if (!instance.IsBeginTran)
            {
                instance.SqlSugarClient.Ado.BeginTran();
                instance.IsBeginTran = true;
            }
        }

        public static void CommitTran()
        {
            var id = GetId();
            if (!_cache.ContainsKey(id))
                throw new Exception("内部错误: SqlSugarClient已丢失.");
            if (_cache[id].TranCount == 0)
            {
                _cache[id].SqlSugarClient.Ado.CommitTran();
                _cache[id].IsBeginTran = false;
            }
        }

        public static void RollbackTran()
        {
            var id = GetId();
            if (!_cache.ContainsKey(id))
                throw new Exception("内部错误: SqlSugarClient已丢失.");
            _cache[id].SqlSugarClient.Ado.RollbackTran();
            _cache[id].IsBeginTran = false;
            _cache[id].TranCount = 0;
        }

        public static void TranCountAddOne()
        {
            var id = GetId();
            if (!_cache.ContainsKey(id))
                throw new Exception("内部错误: SqlSugarClient已丢失.");
            _cache[id].TranCount++;
        }

        public static void TranCountMunisOne()
        {
            var id = GetId();
            if (!_cache.ContainsKey(id))
                throw new Exception("内部错误: SqlSugarClient已丢失.");
            _cache[id].TranCount--;
        }
    }
}
