using Castle.DynamicProxy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using My.NetCore.Framework.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Framework.AOP
{
    [Filter]
    public class ActionLoggerAOP : IInterceptor
    {
        private readonly ILogger<ActionLoggerAOP> _logger;

        public ActionLoggerAOP(ILogger<ActionLoggerAOP> logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget ?? invocation.Method;

            //对当前方法的特性验证
            //如果需要验证
            if (method.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(ActionLoggerAttribute)) is ActionLoggerAttribute)
            {
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

                try
                {
                    _logger.LogInformation($"The method [{invocation.TargetType.FullName}.{method.Name}] begins.");
                    _logger.LogInformation($"The method [{invocation.TargetType.FullName}.{method.Name}] args => ({ string.Join(',', invocation.Arguments)}).");

                    sw.Start();
                    invocation.Proceed();
                    sw.Stop();

                    _logger.LogInformation($"The method [{invocation.TargetType.FullName}.{method.Name}] return <= {invocation.ReturnValue}.");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"The method [{invocation.TargetType.FullName}.{method.Name}] throw exception with => {ex.Message}");
                    throw ex;
                }
                finally
                {
                    TimeSpan ts = sw.Elapsed;
                    _logger.LogInformation($"The method [{invocation.TargetType.FullName}.{method.Name}] end. [{ts.TotalSeconds}s].");
                }
            }
            else
            {
                invocation.Proceed();//直接执行被拦截方法
            }
        }
    }
}