using LaDanse.Domain.GameData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Configurations.GameData
{
    public class RealmConfiguration : IEntityTypeConfiguration<Realm>
    {
        public void Configure(EntityTypeBuilder<Realm> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("RealmID")
                .ValueGeneratedNever();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(e => e.GameId)
                .IsRequired();

            builder.ToTable("Realms");
        }
    }
}