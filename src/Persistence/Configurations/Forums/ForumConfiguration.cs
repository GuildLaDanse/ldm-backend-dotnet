using LaDanse.Domain.Entities.Forums;
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Configurations.Forums
{
    public class ForumConfiguration : IEntityTypeConfiguration<Forum>
    {
        public void Configure(EntityTypeBuilder<Forum> builder)
        {
            builder.ToTable("Forum");

            builder.HasIndex(e => e.LastPostPosterId)
                .HasName("IDX_44EA91C922F0147C");

            builder.HasIndex(e => e.LastPostTopicId)
                .HasName("IDX_44EA91C91CA16452");

            builder.HasGuidKey();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasUtf8ColumnType(MySqlBuilderTypes.String(255));

            builder.Property(e => e.Description)
                .IsRequired()
                .HasColumnName("description")
                .HasUtf8ColumnType(MySqlBuilderTypes.Text);

            builder.Property(e => e.LastPostDate)
                .HasColumnName("lastPostDate")
                .HasColumnType(MySqlBuilderTypes.DateTime);

            builder.Property(e => e.LastPostPosterId)
                .HasColumnName("lastPostPosterId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.LastPostPoster)
                .WithMany()
                .HasForeignKey(d => d.LastPostPosterId)
                .HasConstraintName("FK_44EA91C922F0147C");

            builder.Property(e => e.LastPostTopicId)
                .HasColumnName("lastPostTopicId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.LastPostTopic)
                .WithMany()
                .HasForeignKey(d => d.LastPostTopicId)
                .HasConstraintName("FK_44EA91C91CA16452");
        }
    }
}