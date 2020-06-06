using LaDanse.External.BattleNet.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace LaDanse.External.BattleNet.Implementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBattleNeApi(
            this IServiceCollection services)
        {
            services.AddScoped<IBattleNetApiClientFactory, BattleNetApiClientFactory>();

            return services;
        }
    }
}