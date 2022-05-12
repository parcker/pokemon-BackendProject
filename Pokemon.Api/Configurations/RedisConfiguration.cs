using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokemon.CachingService;
using Pokemon.Common.Options;

namespace Pokemon.Api.Configurations
{
    public static class RedisConfiguration
    {
        public static void SetupRedis(this IServiceCollection services, IConfiguration configuration)
        {
           
            RedisOptions redisConfig = configuration.GetSection("RedisOptions").Get<RedisOptions>();
            services.AddSingleton<RedisOptions>();
            if (!redisConfig.Enabled)
            {
                return;
            }
            
            services.AddStackExchangeRedisExtensions(redisConfig.ConnectionString);


        }
    }
}
