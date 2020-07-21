using LaDanse.Domain.Entities.Comments;
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Configurations.Comments
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");

            builder.HasIndex(e => e.GroupId)
                .HasName("IDX_5BC96BF0ED8188B0");

            builder.HasIndex(e => e.PosterId)
                .HasName("IDX_5BC96BF0581A197");

            builder.HasGuidKey();
            
            builder.Property(e => e.Content)
                .HasColumnName("content")
                .IsRequired()
                .HasUtf8ColumnType(MySqlBuilderTypes.String((4096)));

            builder.Property(e => e.PostDate)
                .HasColumnName("postDate")
                .HasColumnType(MySqlBuilderTypes.DateTime);
            
            builder.Property(e => e.GroupId)
                .HasColumnName("groupId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.Group)
                .WithMany()
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_5BC96BF0ED8188B0");

            builder.Property(e => e.PosterId)
                .HasColumnName("posterId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.Poster)
                .WithMany()
                .HasForeignKey(d => d.PosterId)
                .HasConstraintName("FK_5BC96BF0581A197");
        }
    }
}
