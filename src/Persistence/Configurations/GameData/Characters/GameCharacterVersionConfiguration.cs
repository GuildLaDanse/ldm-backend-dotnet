using LaDanse.Domain.Entities.GameData.Characters;
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Configurations.GameData.Characters
{
    public class GameCharacterVersionConfiguration : IEntityTypeConfiguration<GameCharacterVersion>
    {
        public void Configure(EntityTypeBuilder<GameCharacterVersion> builder)
        {
            builder.ToTable("GameCharacterVersion");

            builder.HasIndex(e => e.GameCharacterId)
                .HasName("IDX_A70EBD185AF690F3");

            builder.HasIndex(e => e.GameClassId)
                .HasName("IDX_A70EBD18F3B4E37B");

            builder.HasIndex(e => e.GameRaceId)
                .HasName("IDX_A70EBD18E036C39A");

            builder.HasGuidKey();

            builder.TemporalEntity();

            builder.Property(e => e.Level)
                .HasColumnName("level")
                .HasColumnType(MySqlBuilderTypes.UnsignedInt);

            builder.Property(e => e.GameCharacterId)
                .HasColumnName("gameCharacterId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.GameCharacter)
                .WithMany()
                .HasForeignKey(d => d.GameCharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_A70EBD185AF690F3");

            builder.Property(e => e.GameClassId)
                .HasColumnName("gameClassId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.GameClass)
                .WithMany()
                .HasForeignKey(d => d.GameClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_A70EBD18F3B4E37B");

            builder.Property(e => e.GameRaceId)
                .HasColumnName("gameRaceId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.GameRace)
                .WithMany()
                .HasForeignKey(d => d.GameRaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_A70EBD18E036C39A");
        }
    }
}