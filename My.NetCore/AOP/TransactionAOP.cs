using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using My.NetCore.Attributes;
using My.NetCore.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace My.NetCore.AOP
{
    public class TransactionAOP : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget ?? invocation.Method;

            var attributes = method.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(TransactionAttribute));

            if (attributes != null && attributes is TransactionAttribute)
            {
                TransactionAttribute transaction = attributes as TransactionAttribute;

                TransactionOptions transactionOptions = new TransactionOptions();
                //设置事务隔离级别
                transactionOptions.IsolationLevel = transaction.IsolationLevel;
                //设置事务超时时间为60秒
                transactionOptions.Timeout = new TimeSpan(0, 0, transaction.Timeout);

                using (TransactionScope scope = new TransactionScope(transaction.ScopeOption, transactionOptions))
                {
                    try
                    {
                        //实现事务性工作
                        invocation.Proceed();
                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        // 记录异常
                        throw ex;
                    }
                }
            }
            else
            {
                invocation.Proceed();
            }
        }
    }
}