using Infra.Abstractions;
using Infra.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Infra.Caching
{
    public class MemoryStorageCache : CacheAbstraction, IMemoryStorageCache
    {
        private readonly IMemoryCache _memoryCache;
        private readonly TimeSpan _timeExpiration;
        public MemoryStorageCache(IMemoryCache memoryCache, IConfiguration configuration) : base(configuration)
        {
            _memoryCache = memoryCache;
            _timeExpiration = TimeSpan.FromMilliseconds(Convert.ToInt32(configuration["ConnectionStrings:memoryCache:expriration_millisecond"]));
        }
        public override Task<T> GetAsync<T>(string key)
        {
            return Task.FromResult(_memoryCache.Get<T>($"{_CACHE_KEY}:{key}"));
        }

        public override async Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> function)
        {
            var resultMemory = await GetAsync<T>(key);
            if (resultMemory != null) return resultMemory;

            var data = await function();

            Set(key, data);

            return data;
        }

        public override void Remove(string key)
        {
            _memoryCache.Remove($"{_CACHE_KEY}:{key}");
        }

        public override void Set<T>(string key, T data)
        {
            _memoryCache.Set($"{_CACHE_KEY}:{key}", data, _timeExpiration);
        }
    }
}