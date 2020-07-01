using Castle.DynamicProxy;
using My.NetCore.Framework.Attributes;
using My.NetCore.Framework.ORM;
using My.NetCore.Framework.ORM.SqlSugar;
using System;
using System.Linq;
using System.Transactions;

namespace My.NetCore.Framework.AOP
{
    [Filter]
    public class TransactionAOP : IInterceptor
    {
        private readonly ITransaction _transaction;

        public TransactionAOP(ITransaction transaction)
        {
            _transaction = transaction;
        }

        public void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget ?? invocation.Method;

            var attributes = method.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(TransactionAttribute));

            if (attributes != null && attributes is TransactionAttribute)
            {
                try
                {
                    //SqlSugarDbFactory.BeginTran();
                    //SqlSugarDbFactory.TranCountAddOne();
                    _transaction.BeginTran();
                    //实现事务性工作
                    invocation.Proceed();
                    _transaction.CommitTran();
                    //SqlSugarDbFactory.TranCountMunisOne();
                    //SqlSugarDbFactory.CommitTran();
                }
                catch (Exception ex)
                {
                    _transaction.RollbackTran();
                    //SqlSugarDbFactory.RollbackTran();
                    // 记录异常
                   throw ex;
                }
            }
            else
            {
                invocation.Proceed();
            }
        }
    }
}