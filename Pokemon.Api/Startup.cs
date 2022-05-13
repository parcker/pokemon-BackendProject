using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pokemon.Api.Configurations;
using Pokemon.Api.ErrorHandling;
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
            services.AddDistributedMemoryCache();
       

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if(env.IsDevelopment()){ app.UseHttpsRedirection();}
           

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"swagger/v1/swagger.json", "Pokemon api v1");
                c.RoutePrefix = string.Empty;
            });
              
            
        }
    }
}
