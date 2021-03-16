using LaDanse.External.Configuration.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace LaDanse.External.Configuration.Implementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLaDanseConfiguration(
            this IServiceCollection services)
        {
            services.AddSingleton<ILaDanseConfiguration, LaDanseConfiguration>();

            return services;
        }
    }
}