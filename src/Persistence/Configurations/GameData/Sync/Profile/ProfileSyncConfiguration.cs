using LaDanse.Domain.Entities.GameData.Sync.Profile;
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Configurations.GameData.Sync.Profile
{
    public class ProfileSyncConfiguration : IEntityTypeConfiguration<ProfileSync>
    {
        public void Configure(EntityTypeBuilder<ProfileSync> builder)
        {
            builder.HasIndex(e => e.UserId)
                .HasDatabaseName("IDX_70D670C87D3656A4");

            builder.Property(e => e.UserId)
                .HasColumnName("userId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_70D670C87D3656A4");
        }
    }
}
