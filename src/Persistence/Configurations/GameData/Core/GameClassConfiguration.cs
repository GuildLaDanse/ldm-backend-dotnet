using LaDanse.Domain.Entities.GameData.Core;
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Configurations.GameData.Core
{
    public class GameClassConfiguration : IEntityTypeConfiguration<GameClass>
    {
        public void Configure(EntityTypeBuilder<GameClass> builder)
        {
            builder.ToTable("GameClass");

            builder.HasGuidKey();

            builder.Property(e => e.GameId)
                .HasColumnName("gameId")
                .HasColumnType(MySqlBuilderTypes.UnsignedInt);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasUtf8ColumnType(MySqlBuilderTypes.String(20));
        }
    }
}