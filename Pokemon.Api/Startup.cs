using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pokemon.Api.Configurations;
using Pokemon.Application;
using Pokemon.ServiceProvider;

namespace Pokemon.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddHttpClient();
            services.AddLogging();
            services.AddOptions();
            services.AddCors(
                options =>
                    options.AddPolicy("CorsPolicy",
                        builder =>
                        {
                            builder.AllowAnyHeader()
                                .AllowAnyMethod()
                                .SetIsOriginAllowed(host => true)
                                .AllowCredentials();
                        }));
            services.AddRouting(options => options.LowercaseUrls = true);
            services.SetupRedis(Configuration);
            services.AddServiceProviderExtensions();
            services.AddApplicationExtensions();
            services.ConfigSwagger();
            services.AddOptionsConfiguration(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
              c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pokemon backend api v1"));
            
        }
    }
}
