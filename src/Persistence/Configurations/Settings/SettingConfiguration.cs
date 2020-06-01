using LaDanse.Domain.Entities.Settings;
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Configurations.Settings
{
    public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable("Setting");

            builder.HasIndex(e => e.UserId)
                .HasName("IDX_50C9810462DEB3E8");

            builder.HasGuidKey();
            
            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasUtf8ColumnType(MySqlBuilderTypes.String(255));

            builder.Property(e => e.Value)
                .IsRequired()
                .HasColumnName("value")
                .HasUtf8ColumnType(MySqlBuilderTypes.String(2048));

            builder.Property(e => e.UserId)
                .HasColumnName("userId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_50C9810462DEB3E8");
        }
    }
}
