using LaDanse.Application;
using LaDanse.Common;
using LaDanse.External.Auth0.Implementation;
using LaDanse.External.BattleNet.Implementation;
using LaDanse.ServiceBus.Implementation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LaDanse.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLaDanseInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            services.AddScoped<ILaDanseRuntimeContext, LaDanseRuntimeContext>();

            services.AddAuth0Api();
            
            services.AddBattleNetApi();

            services.AddLaDanseServiceBus();

            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddTransient<IPasswordGenerator, PasswordGenerator>();

            return services;
        }
    }
}