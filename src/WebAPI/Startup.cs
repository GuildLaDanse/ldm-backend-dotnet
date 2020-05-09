using System.Reflection;
using LaDanse.Application;
using LaDanse.Application.Behaviours;
using LaDanse.Common.Configuration;
using LaDanse.Core.Behaviours;
using LaDanse.Persistence;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Verify that all required environment variables are present.
            CheckEnvironmentVariables();
            
            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<LaDanseDbContext>(options =>
                    options.UseNpgsql(Configuration.GetEnvironmentValue(EnvNames.LaDanseDatabaseConnection)));
            
            // add MediatR pipeline behavior
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            // add assemblies to scan for MediatR handlers
            services.AddMediatR(
                typeof(LaDanseApplicationAssembly).GetTypeInfo().Assembly);
        
            services.AddControllers();

            services
                .AddLaDansePersistence();
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
