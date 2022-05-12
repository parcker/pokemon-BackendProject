using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Pokemon.Model.CacheingModels;
using StackExchange.Redis;

namespace Pokemon.CachingService
{
    internal class RedisCacheService : IResponseCacheService
    {
        private readonly IDistributedCache _distributedCache;

        public RedisCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
       
       
        public async Task CacheResponseAsync<T>(CacheRequest data)
        {
            if(data.Value is null)
            {
                return;
            }
            var serializedResponse= JsonSerializer.Serialize(data.Value);
            await _distributedCache.SetStringAsync(data.key, serializedResponse, new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = data.TimeToLive
            }) ;

        }

        public async Task<string> GetCachedResponseAsync(string cachedkey)
        {
            var cachedResponse = await _distributedCache.GetStringAsync(cachedkey);
            return string.IsNullOrEmpty(cachedResponse) ? null : cachedResponse;
        }
    }
}
