using System;
using System.Threading.Tasks;
using LaDanse.Application;
using LaDanse.Common.Configuration;
using LaDanse.Infrastructure;
using LaDanse.Persistence;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Serilog;

namespace LaDanse.WebUI
{
    public class Startup
    {
        private readonly ILogger _logger = Log.ForContext<Startup>();

        private IServiceCollection _services;

        private IConfiguration Configuration { get; }
        private IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Verify that all required environment variables are present.
            CheckEnvironmentVariables();

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddInfrastructure(Configuration, Environment);
            services.AddPersistence(Configuration);
            services.AddApplication();

            services.AddHttpContextAccessor();
            
            services
                .AddAuth0Authentication(Configuration)
                .AddAuthorization();

            /*
            services.AddControllers(
                options =>
                {
                    options.Filters.Add<OperationCancelledExceptionFilter>();
                });
            */

            services.AddApplicationInsightsTelemetry(Configuration["APPINSIGHTS_INSTRUMENTATIONKEY"]);

            // Register the Swagger generator, defining 1 or more Swagger documents
            //services.AddSwaggerGen();
            
            _services = services;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseSerilogRequestLogging();

            app.UseStaticFiles();

            /*
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "La Danse API V1");
            });
            */

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");                
            });
        }

        private void CheckEnvironmentVariables()
        {
            // check existence of database connection configuration
            CheckEnvironmentVariable(EnvNames.LaDanseDatabaseConnection);
            
            // check existence of various configuration values
            CheckEnvironmentVariable(EnvNames.LaDanseBaseUrl);

            // check existence of Battle Net configuration
            CheckEnvironmentVariable(EnvNames.BattleNetClientId);
            CheckEnvironmentVariable(EnvNames.BattleNetClientSecret);

            // check existence of Auth0 configuration
            CheckEnvironmentVariable(EnvNames.Auth0Domain);
            CheckEnvironmentVariable(EnvNames.Auth0ClientId);
            CheckEnvironmentVariable(EnvNames.Auth0ClientSecret);
            CheckEnvironmentVariable(EnvNames.Auth0AdminAudience);
            CheckEnvironmentVariable(EnvNames.Auth0AdminClientId);
            CheckEnvironmentVariable(EnvNames.Auth0AdminClientSecret);
            CheckEnvironmentVariable(EnvNames.Auth0AdminDefaultConnection);
        }

        private void CheckEnvironmentVariable(string envName)
        {
            var envValue = Configuration.GetEnvironmentValue(envName);

            if (string.IsNullOrEmpty(envValue))
            {
                _logger.Warning($"No value given for '{envName}'. Did you forgot to set the environment value?");
            }
            else
            {
                _logger.Information(Environment.IsDevelopment()
                    ? $"Found a value for '{envName}': '{envValue}'"
                    : $"Found a value for '{envName}'");
            }
        }
    }
}