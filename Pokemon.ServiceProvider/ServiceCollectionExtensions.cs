using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Pokemon.ServiceProvider.PokemonProvider;
using Pokemon.ServiceProvider.ShakespeareTranslator;

namespace Pokemon.ServiceProvider
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceProviderExtensions(this IServiceCollection services)
        {
            services.TryAddScoped<IPokemonApiService, PokemonApiService>();
            services.TryAddScoped<IShakespeareTranslatorApiService, ShakespeareTranslatorApiService>();
            return services;
        }
    }
}
