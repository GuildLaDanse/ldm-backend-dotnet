using LaDanse.Domain.GameData.Repositories;
using LaDanse.Persistence.Repositories.GameData;
using Microsoft.Extensions.DependencyInjection;

namespace LaDanse.Persistence
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLaDansePersistence(this IServiceCollection services)
        {
            #region GameData

            services.AddTransient<IRealmRepository, RealmRepository>();

            #endregion

            return services;
        }
    }
}
