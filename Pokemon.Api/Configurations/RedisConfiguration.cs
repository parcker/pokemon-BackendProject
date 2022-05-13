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

            var redisOptions = new RedisOptions();
            configuration.GetSection(nameof(RedisOptions)).Bind(redisOptions);
            services.AddSingleton(redisOptions);
            if (!redisOptions.Enabled)
            {
                return;
            }
            
            services.AddStackExchangeRedisExtensions(redisOptions.ConnectionString);


        }
    }
}
