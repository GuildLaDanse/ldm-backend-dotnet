using LaDanse.Domain.Entities.Events;
using LaDanse.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Configurations.Events
{
    public class SignedForGameRoleConfiguration : IEntityTypeConfiguration<SignedForGameRole>
    {
        public void Configure(EntityTypeBuilder<SignedForGameRole> builder)
        {
            builder.ToTable("SignedForGameRole");

            builder.HasIndex(e => e.SignUpId)
                .HasDatabaseName("IDX_16186B55A966702F");

            builder.HasGuidKey();

            builder.Property(e => e.GameRole)
                .IsRequired()
                .HasColumnName("gameRole")
                .HasColumnType(MySqlBuilderTypes.Enum);

            builder.Property(e => e.SignUpId)
                .HasColumnName("signUpId")
                .HasForeignKeyColumnType();
            builder.HasOne(d => d.SignUp)
                .WithMany()
                .HasForeignKey(d => d.SignUpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_16186B55A966702F");
        }
    }
}
