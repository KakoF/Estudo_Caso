using Infra.Abstractions;
using Infra.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace Infra.Caching
{
    public class RedisStorageCache : CacheAbstraction, IRedisStorageCache
    {
        private readonly IDistributedCache _redisCache;
        private readonly DistributedCacheEntryOptions _redisOptions;

        public RedisStorageCache(IDistributedCache redisCache, IConfiguration configuration) : base(configuration)
        {
            _redisCache = redisCache;
            _redisOptions = new DistributedCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMilliseconds(Convert.ToInt32(configuration["ConnectionStrings:redis:expriration_millisecond"])),
            };

        }
        public override async Task<T> GetAsync<T>(string key)
        {
            var json = await _redisCache.GetStringAsync($"{_CACHE_KEY}:{key}");
            return (json == null) ? default(T) : JsonConvert.DeserializeObject<T>(json);
        }

        public async override Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> function)
        {
            var resultRedis = await GetAsync<T>(key);
            if (resultRedis != null) return resultRedis;

            var data = await function();

            Set(key, data);

            return data;
        }

        public override void Set<T>(string key, T data)
        {
            _redisCache.Set($"{_CACHE_KEY}:{key}", System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)), _redisOptions);
        }

        public override void Remove(string key)
        {
            _redisCache.Remove($"{_CACHE_KEY}:{key}");
        }

    }
}
