using LaDanse.Common;
using LaDanse.Common.Configuration;
using LaDanse.External.BattleNet.Implementation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LaDanse.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, 
            IConfiguration configuration, 
            IWebHostEnvironment environment)
        {
            services.AddBattleNeApi();
            
            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddTransient<ILaDanseConfiguration, LaDanseConfiguration>();

            // add MediatR pipeline behavior
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));

            return services;
        }
    }
}