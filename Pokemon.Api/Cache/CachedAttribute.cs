using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Pokemon.CachingService;
using Pokemon.Common.Options;
using Pokemon.Model.CacheingModels;
using Pokemon.Model.CachingModels;

namespace Pokemon.Api.Cache
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CachedAttribute:Attribute,IAsyncActionFilter
    {
        private readonly int _timeToLiveInSeconds;
        public CachedAttribute(int timeToLiveInSeconds)
        {
            _timeToLiveInSeconds = timeToLiveInSeconds;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cachedSettings = context.HttpContext.RequestServices.GetRequiredService<RedisOptions>();
            if (!cachedSettings.Enabled)
            {
                await next();
                return;
            }
            var cachedService = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();
            var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);
            var cachedResponse = await cachedService.GetCachedResponseAsync(cacheKey);
            if (!string.IsNullOrEmpty(cachedResponse))
            {
                var deserializeObjectResponse= JsonSerializer.Deserialize<CachedResponseObject>(cachedResponse);
                var contentResult = new ContentResult
                {
                    Content = JsonSerializer.Serialize(deserializeObjectResponse?.Value),
                    ContentType= "application/json",
                    StatusCode=200

                };
                context.Result = contentResult;
                return;
            }
            var excutedContext= await next();
            if(excutedContext.Result is OkObjectResult okObjectResult)
            {
                var cacheRequest = new CacheRequest
                {
                    TimeToLive= TimeSpan.FromSeconds(_timeToLiveInSeconds),
                    key= cacheKey,
                    Value= okObjectResult
                };
                await cachedService.CacheResponseAsync<string>(cacheRequest);
            }
            //After
        }

        private static string GenerateCacheKeyFromRequest(HttpRequest request)
        {
            var keybuilder = new StringBuilder();
            keybuilder.Append($"{request.Path}");
            foreach (var (key, value) in request.Query.OrderBy(x=>x.Key))
            {
                keybuilder.Append($"|{key}-{value}");
            }
            return keybuilder.ToString();
        }
    }
}
