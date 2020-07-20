using LaDanse.Domain.Entities.Comments;
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Configurations.Comments
{
    public class CommentGroupConfiguration : IEntityTypeConfiguration<CommentGroup>
    {
        public void Configure(EntityTypeBuilder<CommentGroup> builder)
        {
            builder.ToTable("CommentGroup");

            builder.HasGuidKey();

            builder.Property(e => e.PostDate)
                .HasColumnName("postDate")
                .HasColumnType(MySqlBuilderTypes.DateTime);
        }
    }
}