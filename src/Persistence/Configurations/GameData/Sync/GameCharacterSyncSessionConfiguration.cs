using LaDanse.Domain.Entities.GameData.Sync;
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Configurations.GameData.Sync
{
    public class GameCharacterSyncSessionConfiguration : IEntityTypeConfiguration<GameCharacterSyncSession>
    {
        public void Configure(EntityTypeBuilder<GameCharacterSyncSession> builder)
        {
            builder.ToTable("GameCharacterSyncSession");

            builder.HasIndex(e => e.GameCharacterSourceId)
                .HasDatabaseName("IDX_EC73362CDD71BB");

            builder.HasGuidKey();

            builder.Property(e => e.FromTime)
                .IsRequired()
                .HasColumnName("fromTime")
                .HasColumnType(MySqlBuilderTypes.DateTime);
                
            builder.Property(e => e.EndTime)
                .HasColumnName("endTime")
                .HasColumnType(MySqlBuilderTypes.DateTime);

            builder.Property(e => e.Log)
                .HasColumnName("log")
                .HasUtf8ColumnType(MySqlBuilderTypes.LongText);

            builder.Property(e => e.GameCharacterSourceId)
                .HasColumnName("gameCharacterSourceId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.GameCharacterSource)
                .WithMany()
                .HasForeignKey(d => d.GameCharacterSourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EC73362CDD71BB");
        }
    }
}
