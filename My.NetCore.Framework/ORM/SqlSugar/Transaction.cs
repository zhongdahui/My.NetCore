using SqlSugar;
using System;

namespace My.NetCore.Framework.ORM.SqlSugar
{
    public class Transaction : ITransaction
    {
        protected ISqlSugarClient DbClient { get; set; }

        public Transaction()
        {
            DbClient = SqlSugarDbFactory.GetInstance().SqlSugarClient;
        }

        public void BeginTran()
        {
            DbClient.Ado.CommitTran();
        }

        public void CommitTran()
        {
            DbClient.Ado.CommitTran();
        }

        public void RollbackTran()
        {
            DbClient.Ado.RollbackTran();
        }
    }
}
