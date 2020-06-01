using LaDanse.Domain.Entities.GameData.Core;
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Configurations.GameData.Core
{
    public class GameFactionConfiguration : IEntityTypeConfiguration<GameFaction>
    {
        public void Configure(EntityTypeBuilder<GameFaction> builder)
        {
            builder.ToTable("GameFaction");

            builder.HasGuidKey();

            builder.Property(e => e.GameId)
                .IsRequired()
                .HasColumnName("gameId")
                .HasColumnType(MySqlBuilderTypes.UnsignedInt);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasUtf8ColumnType(MySqlBuilderTypes.String(20));
        }
    }
}
