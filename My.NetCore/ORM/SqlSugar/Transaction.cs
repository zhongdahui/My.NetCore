using SqlSugar;
using System;

namespace My.NetCore.ORM.SqlSugar
{
    public class Transaction : ITransaction
    {
        private ISqlSugarClient SqlSugarClient { get; set; }

        public Transaction(IDbFactory dbFactory)
        {
            SqlSugarClient = dbFactory.GetDbContext();
        }

        /// <summary>
        /// 获取DB，保证唯一性
        /// </summary>
        /// <returns></returns>
        public SqlSugarClient GetDbClient()
        {
            // 必须要as，后边会用到切换数据库操作
            return SqlSugarClient as SqlSugarClient;
        }

        public void BeginTran()
        {
            GetDbClient().BeginTran();
        }

        public void CommitTran()
        {
            try
            {
                GetDbClient().CommitTran();
            }
            catch (Exception ex)
            {
                GetDbClient().RollbackTran();
                throw ex;
            }
        }

        public void RollbackTran()
        {
            GetDbClient().RollbackTran();
        }
    }
}
