using LaDanse.Domain.Entities.GameData.Sync;
using LaDanse.Domain.Entities.GameData.Sync.Guild;
using LaDanse.Domain.Entities.GameData.Sync.Profile;
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Configurations.GameData.Sync
{
    public class GameCharacterSourceConfiguration : IEntityTypeConfiguration<GameCharacterSource>
    {
        public void Configure(EntityTypeBuilder<GameCharacterSource> builder)
        {
            builder.ToTable("GameCharacterSource");

            builder.HasGuidKey();
            
            builder.HasDiscriminator<string>("discr")
                .HasValue<GameGuildSync>("GuildSync")
                .HasValue<ProfileSync>("ProfileSync");

            builder.Property("discr")
                .IsRequired()
                .HasColumnName("discr")
                .HasColumnType("char(15)");
        }
    }
}
