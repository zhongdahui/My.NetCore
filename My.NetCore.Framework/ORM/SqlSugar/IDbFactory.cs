using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Framework.ORM.SqlSugar
{
    public interface IDbFactory
    {
        SqlSugarClient GetDbContext(Action<Exception> onErrorEvent);
        SqlSugarClient GetDbContext(Action<string, SugarParameter[]> onExecutedEvent);
        SqlSugarClient GetDbContext(Func<string, SugarParameter[], KeyValuePair<string, SugarParameter[]>> onExecutingChangeSqlEvent);
        SqlSugarClient GetDbContext(Action<string, SugarParameter[]> onExecutedEvent = null, Func<string, SugarParameter[], KeyValuePair<string, SugarParameter[]>> onExecutingChangeSqlEvent = null, Action<Exception> onErrorEvent = null);
    }
}
