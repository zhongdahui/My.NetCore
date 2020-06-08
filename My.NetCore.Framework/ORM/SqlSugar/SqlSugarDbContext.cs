using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using My.NetCore.Framework.Options;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Framework.ORM.SqlSugar
{
    public class SqlSugarDbContext : IDbFactory
    {
        private readonly ILogger<SqlSugarDbContext> _logger;
        private ConnectionConfig _config;
        private readonly AppSettingOption _option;

        public SqlSugarDbContext(ILogger<SqlSugarDbContext> logger, IOptions<AppSettingOption> option, ConnectionConfig config = null)
        {
            if (config == null)
            {
                if (option == null)
                    throw new ArgumentNullException(nameof(option));
                if (option.Value.DbContext == null)
                    throw new ArgumentNullException(nameof(option.Value.DbContext));
                if (string.IsNullOrEmpty(option.Value.DbContext.ConnectionString))
                    throw new ArgumentNullException(nameof(option.Value.DbContext.ConnectionString));
                if (string.IsNullOrEmpty(option.Value.DbContext.ModelAssemblyName))
                    throw new ArgumentNullException(nameof(option.Value.DbContext.ModelAssemblyName));
                if (string.IsNullOrEmpty(option.Value.DbContext.DbType))
                    throw new ArgumentNullException(nameof(option.Value.DbContext.DbType));
            }

            _logger = logger;
            _option = option.Value;
            _config = config;
        }

        public SqlSugarClient GetDbContext(Action<Exception> onErrorEvent) => GetDbContext(null, null, onErrorEvent);
        public SqlSugarClient GetDbContext(Action<string, SugarParameter[]> onExecutedEvent) => GetDbContext(onExecutedEvent);
        public SqlSugarClient GetDbContext(Func<string, SugarParameter[], KeyValuePair<string, SugarParameter[]>> onExecutingChangeSqlEvent) => GetDbContext(null, onExecutingChangeSqlEvent);
        public SqlSugarClient GetDbContext(Action<string, SugarParameter[]> onExecutedEvent = null, Func<string, SugarParameter[], KeyValuePair<string, SugarParameter[]>> onExecutingChangeSqlEvent = null, Action<Exception> onErrorEvent = null)
        {
            if (_config == null || string.IsNullOrEmpty(_config.ConnectionString))
            {
                DbType dbType = DbType.MySql;

                switch (_option.DbContext.DbType.ToUpper())
                {
                    case "ORACLE":
                        dbType = DbType.Oracle;
                        break;
                    case "MYSQL":
                        dbType = DbType.MySql;
                        break;
                    case "SQLSERVER":
                        dbType = DbType.SqlServer;
                        break;
                    case "SQLITE":
                        dbType = DbType.Sqlite;
                        break;
                    case "MEMORY":
                        throw new NotSupportedException("Oracle for EF Core Database Provider is not yet available.");
                    case "POSTGRESQL":
                        dbType = DbType.PostgreSQL;
                        break;
                    default:
                        dbType = DbType.MySql;
                        break;
                }

                _config = new ConnectionConfig()
                {
                    ConnectionString = _option.DbContext.ConnectionString,
                    DbType = dbType,
                    IsAutoCloseConnection = true,
                    InitKeyType = InitKeyType.SystemTable,
                    IsShardSameThread = true
                };
            }
            SqlSugarClient db = new SqlSugarClient(_config)
            {
                Aop =
                {
                    OnExecutingChangeSql = onExecutingChangeSqlEvent,
                    OnError = onErrorEvent ?? ((Exception ex) => { _logger.LogError(ex, "ExecuteSql Error"); }),
                    OnLogExecuted = onExecutedEvent ?? ((string sql, SugarParameter[] pars) =>
                    {
                        var keyDic = new KeyValuePair<string, SugarParameter[]>(sql, pars);
                        _logger.LogInformation($"ExecuteSql：[{sql}] {GetParas(pars)}");
                    })
                }
            };

            return db;
        }

        private string GetParas(SugarParameter[] pars)
        {
            if (pars != null && pars.Count() > 0)
            {
                string key = "Parameter：";

                foreach (var param in pars)
                {
                    key += $"[{param.ParameterName}:{param.Value}]";
                }

                return key;
            }

            return "";
        }
    }
}
