using System.Reflection;
using LaDanse.Application.Common.Behaviours;
using LaDanse.Application.GameData.Sync.GuildSync;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace LaDanse.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLaDanseApplication(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestExceptionProcessorBehavior<,>));
            
            services.AddScoped<GuildSyncWorkflow>();

            return services;
        }
    }
}