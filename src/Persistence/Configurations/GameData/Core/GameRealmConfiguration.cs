using LaDanse.Domain.Entities.GameData.Core;
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Configurations.GameData.Core
{
    public class GameRealmConfiguration : IEntityTypeConfiguration<GameRealm>
    {
        public void Configure(EntityTypeBuilder<GameRealm> builder)
        {
            builder.ToTable("GameRealm");

            builder.HasGuidKey();

            builder.Property(e => e.GameId)
                .IsRequired()
                .HasColumnName("gameId")
                .HasColumnType(MySqlBuilderTypes.UnsignedInt);
            
            builder.Property(e => e.GameSlug)
                .IsRequired()
                .HasColumnName("gameSlug")
                .HasUtf8ColumnType(MySqlBuilderTypes.String(100));

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasUtf8ColumnType(MySqlBuilderTypes.String(100));
        }
    }
}