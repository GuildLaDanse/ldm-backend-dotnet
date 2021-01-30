using LaDanse.Application;
using LaDanse.Common.Abstractions;
using LaDanse.External.BattleNet.Implementation;
using LaDanse.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
            
            services.AddBattleNetApi();

            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddTransient<IPasswordGenerator, PasswordGenerator>();

            return services;
        }
    }
}