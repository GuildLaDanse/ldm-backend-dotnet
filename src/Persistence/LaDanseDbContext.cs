using LaDanse.Application.Common.Interfaces;
using LaDanse.Domain.GameData.Entities;
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LaDanse.Persistence
{
    public class LaDanseDbContext : DbContext, ILaDanseDbContext
    {
        public LaDanseDbContext(DbContextOptions<LaDanseDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Realm> Realms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyAllConfigurations();
        }
    }
}
