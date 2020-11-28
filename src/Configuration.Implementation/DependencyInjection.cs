using LaDanse.Configuration.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace LaDanse.Configuration.Implementation
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