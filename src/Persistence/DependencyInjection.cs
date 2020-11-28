using LaDanse.Application.Common.Interfaces;
using LaDanse.Configuration.Implementation;
using LaDanse.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LaDanse.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LaDanseDbContext>(options =>
                options.UseMySql(configuration.GetEnvironmentValue(EnvNames.LaDanseDatabaseConnection)));

            services.AddScoped<ILaDanseDbContext>(provider => provider.GetService<LaDanseDbContext>());

            return services;
        }
    }
}