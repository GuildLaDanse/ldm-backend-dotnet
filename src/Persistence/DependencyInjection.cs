using System;
using LaDanse.Application.Common.Interfaces;
using LaDanse.Configuration.Implementation;
using LaDanse.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace LaDanse.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLaDansePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LaDanseDbContext>(options =>
                options.UseMySql(
                    configuration.GetEnvironmentValue(EnvNames.LaDanseDatabaseConnection),
                    new MySqlServerVersion(new Version(8, 0, 22)),
                    mySqlOptions => mySqlOptions
                        .CharSetBehavior(CharSetBehavior.NeverAppend)
                ));

            services.AddScoped<ILaDanseDbContext>(provider => provider.GetService<LaDanseDbContext>());

            return services;
        }
    }
}