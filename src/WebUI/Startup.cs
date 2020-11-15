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
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie()
                .AddOpenIdConnect("Auth0", options => {
                    // Set the authority to your Auth0 domain
                    options.Authority = $"https://{Configuration.GetEnvironmentValue(EnvNames.Auth0Domain)}";

                    // Configure the Auth0 Client ID and Client Secret
                    options.ClientId = Configuration.GetEnvironmentValue(EnvNames.Auth0ClientId);
                    options.ClientSecret = Configuration.GetEnvironmentValue(EnvNames.Auth0ClientSecret);

                    // Set response type to code
                    options.ResponseType = OpenIdConnectResponseType.Code;
                    
                    options.SaveTokens = true;

                    // Configure the scope
                    options.Scope.Clear();
                    options.Scope.Add("openid");
                    options.Scope.Add("profile");

                    // Set the callback path, so Auth0 will call back to http://localhost:3000/callback
                    // Also ensure that you have added the URL as an Allowed Callback URL in your Auth0 dashboard
                    options.CallbackPath = new PathString("/callback");

                    // Configure the Claims Issuer to be Auth0
                    options.ClaimsIssuer = "Auth0";
                    
                    options.NonceCookie.SameSite = SameSiteMode.Unspecified;
                    options.CorrelationCookie.SameSite = SameSiteMode.Unspecified;
                    
                    options.Events = new OpenIdConnectEvents
                    {
                        // handle the logout redirection
                        OnRedirectToIdentityProviderForSignOut = (context) =>
                        {
                            var logoutUri = $"https://{Configuration.GetEnvironmentValue(EnvNames.Auth0Domain)}/v2/logout?client_id={Configuration.GetEnvironmentValue(EnvNames.Auth0ClientId)}";

                            var postLogoutUri = context.Properties.RedirectUri;
                            if (!string.IsNullOrEmpty(postLogoutUri))
                            {
                                if (postLogoutUri.StartsWith("/"))
                                {
                                    // transform to absolute
                                    var request = context.Request;
                                    postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                                }
                                logoutUri += $"&returnTo={ Uri.EscapeDataString(postLogoutUri)}";
                            }

                            context.Response.Redirect(logoutUri);
                            context.HandleResponse();

                            return Task.CompletedTask;
                        }
                    };
                });
            
            services.AddAuthorization();

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