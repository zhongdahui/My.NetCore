using Castle.DynamicProxy;
using My.NetCore.Attributes;
using My.NetCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.AOP
{
    /// <summary>
    /// 分布式锁（redis）
    /// </summary>
    public class TransactionLockAOP : IInterceptor
    {
        Dictionary<string, object> dic = new Dictionary<string, object>();

        public void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget ?? invocation.Method;
            //对当前方法的特性验证
            //如果需要验证
            if (method.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(TransactionLockAttribute)) is TransactionLockAttribute)
            {
                string name = GetLockName(invocation);

                RedisLock(name);
                invocation.Proceed();
                RedisUnLock(name);
            }
            else
            {
                invocation.Proceed();//直接执行被拦截方法
            }
        }

        public string GetLockName(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget ?? invocation.Method;
            var attributes = method.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(TransactionLockAttribute));

            string methodName = $"{invocation.TargetType.FullName}.{method.Name}";
            string attributesName = ((TransactionLockAttribute)attributes).Name;
            object redisLockName = null;

            if (!string.IsNullOrEmpty(attributesName))
            {
                var paramName = method.GetParameters();
                var paramValue = invocation.Arguments;

                if (paramName != null && paramValue != null && paramName.Length > 0 && paramValue.Length > 0)
                {
                    for (int i = 0; i < paramName.Length; i++)
                    {
                        dic.Add(paramName[i].Name, paramValue[i]);
                    }
                }

                foreach (var item in attributesName.Split('.'))
                {
                    if (redisLockName == null)
                    {
                        if (dic.ContainsKey(item))
                        {
                            redisLockName = dic[item];
                        }
                        else
                        {
                            throw new Exception($"{item}属性不存在");
                        }
                    }
                    else
                    {
                        redisLockName = GetModelValue(item, redisLockName);
                    }
                }
            }

            if (redisLockName == null)
            {
                return $"Lock_{methodName.Replace(".", "_")}";
            }
            else
            {
                return $"Lock_{methodName.Replace(".", "_")}_{redisLockName.ToString()}";
            }
        }

        /// 
        /// 获取类中的属性值
        /// 
        public object GetModelValue(string name, object obj)
        {
            try
            {
                Type t = obj.GetType();
                return t.GetProperty(name).GetValue(obj, null);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void RedisLock(string name = "")
        {
            string lock_data = RedisCacheHelper.Get(name);

            if (string.IsNullOrEmpty(lock_data))
            {
                var tmp = RedisCacheHelper.Set(name, "1", 100);
            }
            else
            {
                while (true)
                {
                    lock_data = RedisCacheHelper.Get(name);

                    if (string.IsNullOrEmpty(lock_data))
                    {
                        break;
                    }

                    System.Threading.Thread.Sleep(500);
                }
            }
        }

        private void RedisUnLock(string name = "")
        {
            var tmp = RedisCacheHelper.Del(name);
        }
    }
}
