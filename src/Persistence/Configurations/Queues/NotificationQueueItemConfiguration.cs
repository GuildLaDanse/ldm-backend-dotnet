using LaDanse.Domain.Entities.Queues;
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Configurations.Queues
{
    public class NotificationQueueItemConfiguration : IEntityTypeConfiguration<NotificationQueueItem>
    {
        public void Configure(EntityTypeBuilder<NotificationQueueItem> builder)
        {
            builder.ToTable("NotificationQueueItem");

            builder.HasIndex(e => e.ActivityById)
                .HasDatabaseName("IDX_C656D44393C757EE");

            builder.HasGuidKey();
            
            builder.Property(e => e.ActivityOn)
                .IsRequired()
                .HasColumnName("activityOn")
                .HasColumnType(MySqlBuilderTypes.DateTime);

            builder.Property(e => e.ActivityType)
                .IsRequired()
                .HasColumnName("activityType")
                .HasUtf8ColumnType(MySqlBuilderTypes.String(255));

            builder.Property(e => e.ProcessedOn)
                .HasColumnName("processedOn")
                .HasColumnType(MySqlBuilderTypes.DateTime);

            builder.Property(e => e.RawData)
                .HasColumnName("rawData")
                .HasUtf8ColumnType(MySqlBuilderTypes.LongText);

            builder.Property(e => e.ActivityById)
                .HasColumnName("activityById")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.ActivityBy)
                .WithMany()
                .HasForeignKey(d => d.ActivityById)
                .HasConstraintName("FK_C656D44393C757EE");
        }
    }
}
