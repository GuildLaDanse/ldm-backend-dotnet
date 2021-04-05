using LaDanse.ServiceBus.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace LaDanse.ServiceBus.Implementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLaDanseServiceBus(this IServiceCollection services)
        {
            services.AddScoped<IServiceBus, SimpleServiceBus>();

            return services;
        }
    }
}