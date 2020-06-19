using SqlSugar;

namespace My.NetCore.Framework.ORM.SqlSugar
{
    public class SqlClient
    {
        public SqlSugarClient SqlSugarClient;
        public bool IsBeginTran = false;
        public int TranCount = 0;

        public SqlClient(SqlSugarClient sqlSugarClient)
        {
            this.SqlSugarClient = sqlSugarClient;
        }
    }
}
