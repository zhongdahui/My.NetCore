using Castle.DynamicProxy;
using My.NetCore.Attributes;
using My.NetCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.AOP
{
    public class RedisAOP : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget ?? invocation.Method;

            //对当前方法的特性验证
            //如果需要验证
            if (method.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(RedisAttribute)) is RedisAttribute)
            {
                var attributes = method.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(RedisAttribute));

                var attributesType = ((RedisAttribute)attributes).Type;
                var attributesTimeout = ((RedisAttribute)attributes).Timeout;
                var attributesKey = GetRedisKey(invocation);
                var attributesData = ((RedisAttribute)attributes).Data;

                switch (attributesType) 
                {
                    case RedisAttributeType.Query:
                        var ret = RedisCacheHelper.Get<object>(attributesKey);
                        if (ret != null)
                        {
                            invocation.ReturnValue = ret;
                        }
                        else
                        {
                            invocation.Proceed();
                            if (invocation.ReturnValue != null)
                            {
                                RedisCacheHelper.Set(attributesKey, invocation.ReturnValue, attributesTimeout);
                            }
                        }
                        break;
                    case RedisAttributeType.Insert:
                        invocation.Proceed();
                        if (invocation.ReturnValue != null && invocation.ReturnValue.ObjectToBool() == true)
                        {
                            var data = dic[attributesData];
                            RedisCacheHelper.Set(attributesKey, data, attributesTimeout);
                        }
                        break;
                    case RedisAttributeType.Update:
                        invocation.Proceed();
                        if (invocation.ReturnValue != null && invocation.ReturnValue.ObjectToBool() == true)
                        {
                            var data = dic[attributesData];
                            RedisCacheHelper.Set(attributesKey, data, attributesTimeout);
                        }
                        break;
                    case RedisAttributeType.Delete:
                        invocation.Proceed();
                        if (invocation.ReturnValue != null && invocation.ReturnValue.ObjectToBool() == true)
                        {
                            RedisCacheHelper.Del(attributesKey);
                        }
                        break;
                    case RedisAttributeType.Refresh:
                        break;
                }
            }
            else
            {
                invocation.Proceed();//直接执行被拦截方法
            }
        }

        Dictionary<string, object> dic = new Dictionary<string, object>();

        public string GetRedisKey(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget ?? invocation.Method;
            var attributes = method.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(RedisAttribute));

            string methodName = $"{invocation.TargetType.FullName}.{method.Name}";

            var attributesKey = ((RedisAttribute)attributes).Key;
            var attributesType = ((RedisAttribute)attributes).Type;
            var attributesTimeout = ((RedisAttribute)attributes).Timeout;

            object redisLockName = null;

            if (!string.IsNullOrEmpty(attributesKey))
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

                foreach (var item in attributesKey.Split('.'))
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
                return $"{methodName.Replace(".", "_")}";
            }
            else
            {
                return $"{methodName.Replace(".", "_")}_{redisLockName.ToString()}";
            }
        }

        public object GetModelValue(string name, object obj)
        {
            try
            {
                Type t = obj.GetType();
                return t.GetProperty(name).GetValue(obj, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
