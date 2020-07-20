using LaDanse.Domain.Entities.Settings;
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Configurations.Settings
{
    public class CalendarExportConfiguration : IEntityTypeConfiguration<CalendarExport>
    {
        public void Configure(EntityTypeBuilder<CalendarExport> builder)
        {
            builder.ToTable("CalendarExport");

            builder.HasIndex(e => e.UserId)
                .HasName("IDX_6E28848862DEB3E8");

            builder.HasGuidKey();

            builder.Property(e => e.ExportAbsence)
                .IsRequired()
                .HasColumnName("exportAbsence");

            builder.Property(e => e.ExportNew)
                .IsRequired()
                .HasColumnName("exportNew");

            builder.Property(e => e.Secret)
                .IsRequired()
                .HasColumnName("secret")
                .HasUtf8ColumnType(MySqlBuilderTypes.String(100));

            builder.Property(e => e.UserId)
                .HasColumnName("userId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_6E28848862DEB3E8");
        }
    }
}