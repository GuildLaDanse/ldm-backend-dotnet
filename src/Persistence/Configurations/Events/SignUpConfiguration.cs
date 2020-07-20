using LaDanse.Domain.Entities.Events;
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Configurations.Events
{
    public class SignUpConfiguration : IEntityTypeConfiguration<SignUp>
    {
        public void Configure(EntityTypeBuilder<SignUp> builder)
        {
            builder.ToTable("SignUp");

            builder.HasIndex(e => e.UserId)
                .HasName("IDX_DC8B3F7B62DEB3E8");

            builder.HasIndex(e => e.EventId)
                .HasName("IDX_DC8B3F7B2B2EBB6C");

            builder.HasGuidKey();

            builder.Property(e => e.Type)
                .IsRequired()
                .HasColumnName("type")
                .HasColumnType(MySqlBuilderTypes.Enum);

            builder.Property(e => e.UserId)
                .HasColumnName("userId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DC8B3F7B62DEB3E8");

            builder.Property(e => e.EventId)
                .HasColumnName("eventId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.Event)
                .WithMany()
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DC8B3F7B2B2EBB6C");
        }
    }
}