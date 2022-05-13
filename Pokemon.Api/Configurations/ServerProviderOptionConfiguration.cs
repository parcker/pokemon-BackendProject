using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokemon.Common.Options;

namespace Pokemon.Api.Configurations
{
    public static class ServerProviderOptionConfiguration
    {
        public static void AddOptionsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PokeApiOptions>(configuration.GetSection(nameof(PokeApiOptions))); 
            services.Configure<ShakespeareOption>(configuration.GetSection(nameof(ShakespeareOption))); 
           
        }
    }
}