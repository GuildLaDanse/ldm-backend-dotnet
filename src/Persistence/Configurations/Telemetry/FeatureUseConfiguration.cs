using LaDanse.Domain.Entities.Telemetry;
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Configurations.Telemetry
{
    public class FeatureUseConfiguration : IEntityTypeConfiguration<FeatureUse>
    {
        public void Configure(EntityTypeBuilder<FeatureUse> builder)
        {
            builder.ToTable("FeatureUse");   

            builder.HasIndex(e => e.UsedById)
                .HasDatabaseName("IDX_E504F432FCEF271C");

            builder.HasGuidKey();

            builder.Property(e => e.Feature)
                .IsRequired()
                .HasColumnName("feature")
                .HasUtf8ColumnType(MySqlBuilderTypes.String(255));

            builder.Property(e => e.RawData)
                .HasColumnName("rawData")
                .HasUtf8ColumnType(MySqlBuilderTypes.LongText);

            builder.Property(e => e.UsedOn)
                .HasColumnName("usedOn")
                .HasColumnType(MySqlBuilderTypes.DateTime);

            builder.Property(e => e.UsedById)
                .HasColumnName("usedById")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.UsedBy)
                .WithMany()
                .HasForeignKey(d => d.UsedById)
                .HasConstraintName("FK_E504F432FCEF271C");
        }
    }
}
