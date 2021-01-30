using BlazorUI.Areas.Identity;
using LaDanse.Application;
using LaDanse.Configuration.Abstractions;
using LaDanse.Configuration.Implementation;
using LaDanse.Domain.Entities.Identity;
using LaDanse.Infrastructure;
using LaDanse.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace LaDanse.WebUI
{
    public class Startup
    {
        private readonly ILogger _logger = Log.ForContext<Startup>();
        
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
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<LaDanseDbContext>();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            
            services.AddHttpContextAccessor();
            
            services
                .AddAuthorization();
            
            services
                .AddLaDanseConfiguration()
                .AddLaDanseInfrastructure(Configuration, Environment)
                .AddLaDansePersistence(Configuration)
                .AddLaDanseApplication();
            
            services.AddScoped<
                AuthenticationStateProvider, 
                RevalidatingIdentityAuthenticationStateProvider<User>>();
            
            services.AddDatabaseDeveloperPageExceptionFilter();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILaDanseConfiguration laDanseConfiguration)
        {
            if (!laDanseConfiguration.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

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
    }
}
