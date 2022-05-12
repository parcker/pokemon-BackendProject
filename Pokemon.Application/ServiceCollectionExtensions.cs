using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Pokemon.Application.Implementation;
using Pokemon.Application.Interface;
using Pokemon.ServiceProvider.PokemonProvider;

namespace Pokemon.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationExtensions(this IServiceCollection services)
        {
            services.TryAddScoped<IPokemonService, PokemonService>();
            return services;
        }
    }
}
