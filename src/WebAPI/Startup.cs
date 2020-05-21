using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using LaDanse.Common.Configuration;
using LaDanse.Infrastructure;
using LaDanse.Persistence;
using LaDanse.Application;

namespace WebAPI
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

            services.AddHealthChecks()
                .AddDbContextCheck<LaDanseDbContext>();

            services.AddHttpContextAccessor();

            string domain = $"https://{Configuration["Auth0:Domain"]}/";

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.MetadataAddress = domain + ".well-known/openid-configuration";
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = domain,
                        ValidAudience = Configuration["Auth0:ApiIdentifier"],
                        ClockSkew = TimeSpan.Zero,
                        NameClaimType = ClaimTypes.NameIdentifier
                    };
                });

            services.AddAuthorization();

            _services = services;

            services.AddControllers();
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

            app.UseRouting();

            app.UseAuthentication();
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
