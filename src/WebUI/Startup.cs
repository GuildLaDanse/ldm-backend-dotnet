using System.Reflection;
using LaDanse.Application;
using LaDanse.Application.Common.Behaviours;
using LaDanse.Common.Configuration;
using LaDanse.Infrastructure;
using LaDanse.Persistence;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using ILogger = Serilog.ILogger;

namespace LaDanse.WebAPI
{
    public class Startup
    {
        private static readonly ILogger Logger = Log.ForContext<Startup>();
        
        private IServiceCollection _services;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        private IConfiguration Configuration { get; }
        private IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Verify that all required environment variables are present.
            CheckEnvironmentVariables();

            services.AddInfrastructure(Configuration, Environment);
            services.AddPersistence(Configuration);
            services.AddApplication();

            services.AddHttpContextAccessor();
            
            services.AddControllers();
            
            _services = services;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // replace the 10+ logs per request by a summary log from Serilog
            app.UseSerilogRequestLogging();
            
            app.UseHttpsRedirection();

            // add routing decision middleware
            app.UseRouting();

            // add AuthorizationMiddleware to the pipeline
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        
        private void CheckEnvironmentVariables()
        {
            CheckEnvironmentVariable(EnvNames.LaDanseDatabaseConnection);
        }
        
        private void CheckEnvironmentVariable(string envName)
        {
            var envValue = Configuration.GetEnvironmentValue(envName);

            if (string.IsNullOrEmpty(envValue))
            {
                Logger.Warning($"No value given for '{envName}'. Did you forgot to set the environment value?");
            }
            else
            {
                Logger.Debug($"Found a value for '{envName}': '{envValue}'");
            }
        }
    }
}
