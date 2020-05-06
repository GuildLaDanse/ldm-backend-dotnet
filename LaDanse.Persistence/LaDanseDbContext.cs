using LaDanse.Core.GameData.Domain.Entities;
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LaDanse.Persistence
{
    public class LaDanseDbContext : DbContext
    {
        public LaDanseDbContext(DbContextOptions<LaDanseDbContext> options)
            : base(options)
        {
        }
        
        #region GameData
        
        public DbSet<Realm> Realm { get; set; }
        
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyAllConfigurations();
        }
    }
}
