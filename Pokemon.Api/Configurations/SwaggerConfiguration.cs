using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Pokemon.Api.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void ConfigSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Pokemon Api", 
                    Version = "v1",
                    Description = "Api for retrieving pokemon"
                    
                });
              
            });
        }
    }
}
