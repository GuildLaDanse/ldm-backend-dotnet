using LaDanse.Domain.Entities.Settings;
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Configurations.Settings
{
    public class FeatureToggleConfiguration : IEntityTypeConfiguration<FeatureToggle>
    {
        public void Configure(EntityTypeBuilder<FeatureToggle> builder)
        {
            builder.ToTable("FeatureToggle");

            builder.HasIndex(e => e.UserId)
                .HasName("IDX_D25E05DD612E729E");

            builder.HasGuidKey();

            builder.Property(e => e.Feature)
                .IsRequired()
                .HasColumnName("feature")
                .HasUtf8ColumnType(MySqlBuilderTypes.String(255));

            builder.Property(e => e.Toggle)
                .HasColumnName("toggle");

            builder.Property(e => e.UserId)
                .HasColumnName("userId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_D25E05DD612E729E");
        }
    }
}