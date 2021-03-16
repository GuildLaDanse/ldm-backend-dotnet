using LaDanse.External.Auth0.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace LaDanse.External.Auth0.Implementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuth0Api(
            this IServiceCollection services)
        {
            services.AddScoped<IAuth0ApiClientFactory, Auth0ApiClientFactory>();

            return services;
        }
    }
}