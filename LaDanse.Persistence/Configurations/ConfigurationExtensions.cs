using LaDanse.Common.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Configurations
{
    public static class ConfigurationExtensions
    {
        public static EntityTypeBuilder<TEntity> BuildBaseEntity<TEntity, TKey>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : BaseEntity<TKey>
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();
            
            builder.Property(e => e.CreatedOn)
                .IsRequired();
            
            return builder;
        }
        
        public static EntityTypeBuilder<TEntity> BuildTemporalEntity<TEntity, TKey>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : TemporalEntity<TKey>
        {
            builder.Property(e => e.ValidFrom)
                .IsRequired();

            builder.Property(e => e.ValidUntil);
            
            return builder;
        }
    }
}