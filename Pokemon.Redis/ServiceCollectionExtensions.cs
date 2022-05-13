using System;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Pokemon.CachingService
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddStackExchangeRedisExtensions(this IServiceCollection services, string connectionstring)
        {
            services.AddStackExchangeRedisCache(option => option.Configuration = connectionstring);
            services.AddSingleton<IResponseCacheService, RedisCacheService>();
            return services;
        }
    }
}
