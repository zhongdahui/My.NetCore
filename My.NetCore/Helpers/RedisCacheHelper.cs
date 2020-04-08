using CSRedis;
using Microsoft.Extensions.Options;
using My.NetCore.IOC;
using My.NetCore.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Helpers
{
    public class RedisCacheHelper
    {
        static CSRedisClient redisManger = null;
        static CSRedisClient GetClient()
        {
            return redisManger;
        }
        static RedisCacheHelper()
        {
            var config = EnginContext.Current.Resolve<IOptions<AppSettingOption>>();

            if (config == null)
                throw new ArgumentNullException(nameof(config));
            if (config.Value.Redis==null)
                throw new ArgumentNullException(nameof(config.Value.Redis));
            if(string.IsNullOrEmpty(config.Value.Redis.Connection))
                throw new ArgumentNullException(nameof(config.Value.Redis.Connection));

            redisManger = new CSRedisClient(config.Value.Redis.Connection);      //Redis的连接字符串

            Console.WriteLine(DateTime.Now.ToString() + ":" + redisManger.GetHashCode());
        }

        public static bool Set(string key, object value, int timeout = -1)
        {
            return GetClient().Set(key, value, timeout);
        }

        public static async Task<bool> SetAsync(string key, object value, int timeout = -1)
        {
            return await GetClient().SetAsync(key, value, timeout);
        }

        public static string Get(string key)
        {
            return GetClient().Get(key);
        }

        public static T Get<T>(string key)
        {
            return GetClient().Get<T>(key);
        }

        public static async Task<string> GetAsync(string key)
        {
            return await GetClient().GetAsync(key);
        }

        public static async Task<T> GetAsync<T>(string key)
        {
            return await GetClient().GetAsync<T>(key);
        }

        public static bool Del(params string[] key)
        {
            return GetClient().Del(key) > 0;
        }

        public static async Task<bool> DelAsync(params string[] key)
        {
            return await GetClient().DelAsync(key) > 0;
        }

        public static bool HSet(string key, string field, object value)
        {
            return GetClient().HSet(key, field, value);
        }

        public static async Task<bool> HSetAsync(string key, string field, object value)
        {
            return await GetClient().HSetAsync(key, field, value);
        }

        public static string HGet(string key, string field)
        {
            return GetClient().HGet(key, field);
        }

        public static async Task<string> HGetAsync(string key, string field)
        {
            return await GetClient().HGetAsync(key, field);
        }

        public static T HGet<T>(string key, string field)
        {
            return GetClient().HGet<T>(key, field);
        }

        public static async Task<T> HGetAsync<T>(string key, string field)
        {
            return await GetClient().HGetAsync<T>(key, field);
        }

        public static bool HDel(string key, params string[] fields)
        {
            return GetClient().HDel(key, fields) > 0;
        }

        public static async Task<bool> HDelAsync(string key, params string[] fields)
        {
            return await GetClient().HDelAsync(key, fields) > 0;
        }
    }
}
