using System;
using System.Security.Claims;
using LaDanse.Application;
using LaDanse.Common.Configuration;
using LaDanse.Infrastructure;
using LaDanse.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using WebAPI.Filters;

namespace WebAPI
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

            services.AddInfrastructure(Configuration, Environment);
            services.AddPersistence(Configuration);
            services.AddApplication();

            services.AddHealthChecks()
                .AddDbContextCheck<LaDanseDbContext>();

            services.AddHttpContextAccessor();

            var domain = $"https://{Configuration["Auth0:Domain"]}/";

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
                        NameClaimType = ClaimTypes.NameIdentifier,
                        RoleClaimType = "https://www.ladanse.org/roles"
                    };
                });

            services.AddAuthorization();

            services.AddControllers(
                options =>
                {
                    options.Filters.Add<OperationCancelledExceptionFilter>();
                });

            services.AddApplicationInsightsTelemetry(Configuration["APPINSIGHTS_INSTRUMENTATIONKEY"]);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
            
            _services = services;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging();
            
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "La Danse API V1");
            });

            app.UseRouting();
            
            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void CheckEnvironmentVariables()
        {
            // check existence of database connection configuration
            CheckEnvironmentVariable(EnvNames.LaDanseDatabaseConnection);

            // check existence of Battle Net configuration
            CheckEnvironmentVariable(EnvNames.BattleNetClientId);
            CheckEnvironmentVariable(EnvNames.BattleNetClientSecret);

            // check existence of Auth0 configuration
            CheckEnvironmentVariable(EnvNames.Auth0Domain);
            CheckEnvironmentVariable(EnvNames.Auth0Audience);
            CheckEnvironmentVariable(EnvNames.Auth0ClientId);
            CheckEnvironmentVariable(EnvNames.Auth0ClientSecret);
            CheckEnvironmentVariable(EnvNames.Auth0DefaultConnection);
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