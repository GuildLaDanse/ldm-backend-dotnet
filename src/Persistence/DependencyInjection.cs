using LaDanse.Application.Common.Interfaces;
using LaDanse.Common.Configuration;
using LaDanse.Domain.GameData.Repositories;
using LaDanse.Persistence.Repositories.GameData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LaDanse.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            #region GameData
            
            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<LaDanseDbContext>(options =>
                    options.UseNpgsql(configuration.GetEnvironmentValue(EnvNames.LaDanseDatabaseConnection)));
            
            services.AddScoped<ILaDanseDbContext>(provider => provider.GetService<LaDanseDbContext>());
            
            #endregion
            
            #region GameData

            services.AddTransient<IRealmRepository, RealmRepository>();

            #endregion

            return services;
        }
    }
}
