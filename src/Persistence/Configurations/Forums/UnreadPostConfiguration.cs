using LaDanse.Domain.Entities.Forums;
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Configurations.Forums
{
    public class UnreadPostConfiguration : IEntityTypeConfiguration<UnreadPost>
    {
        public void Configure(EntityTypeBuilder<UnreadPost> builder)
        {
            builder.ToTable("UnreadPost");

            builder.HasIndex(e => e.UserId)
                .HasName("IDX_6B0B9B3E62DEB3E8");

            builder.HasIndex(e => e.PostId)
                .HasName("IDX_6B0B9B3EE094D20D");

            builder.HasGuidKey();

            builder.Property(e => e.UserId)
                .HasColumnName("userId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_6B0B9B3E62DEB3E8");

            builder.Property(e => e.PostId)
                .HasColumnName("postId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.Post)
                .WithMany()
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_6B0B9B3EE094D20D");
        }
    }
}
