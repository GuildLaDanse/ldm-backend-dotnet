using LaDanse.Domain.Entities.GameData.Sync;
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Configurations.GameData.Sync
{
    public class TrackedByConfiguration : IEntityTypeConfiguration<TrackedBy>
    {
        public void Configure(EntityTypeBuilder<TrackedBy> builder)
        {
            builder.ToTable("TrackedBy");

            builder.HasIndex(e => e.GameCharacterId)
                .HasDatabaseName("IDX_C2316E125AF690F3");

            builder.HasIndex(e => e.GameCharacterSourceId)
                .HasDatabaseName("IDX_C2316E122CDD71BB");

            builder.HasGuidKey();
            
            builder.TimeVersioned();

            builder.Property(e => e.GameCharacterId)
                .HasColumnName("gameCharacterId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.GameCharacter)
                .WithMany()
                .HasForeignKey(d => d.GameCharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_C2316E125AF690F3");

            builder.Property(e => e.GameCharacterSourceId)
                .HasColumnName("gameCharacterSourceId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.GameCharacterSource)
                .WithMany()
                .HasForeignKey(d => d.GameCharacterSourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_C2316E122CDD71BB");
        }
    }
}
