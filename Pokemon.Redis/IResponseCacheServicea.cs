using System;
using System.Threading.Tasks;
using Pokemon.Model.CacheingModels;

namespace Pokemon.CachingService
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync<T>(CacheRequest data);
        Task<string> GetCachedResponseAsync(string key);  
    }
  
}
