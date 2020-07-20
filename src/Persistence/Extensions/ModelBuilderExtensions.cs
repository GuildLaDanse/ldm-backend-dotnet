using System;
using System.Linq;
using System.Reflection;
using LaDanse.Domain.Shared;
using LaDanse.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaDanse.Persistence.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyAllConfigurations(this ModelBuilder modelBuilder)
        {
            var applyConfigurationMethodInfo = modelBuilder
                .GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .First(m => m.Name.Equals("ApplyConfiguration", StringComparison.OrdinalIgnoreCase));

            var ret = typeof(LaDanseDbContext).Assembly
                .GetTypes()
                .Select(t => (t,
                    i: t.GetInterfaces().FirstOrDefault(i =>
                        i.Name.Equals(typeof(IEntityTypeConfiguration<>).Name, StringComparison.Ordinal))))
                .Where(it => it.i != null)
                .Select(it => (et: it.i.GetGenericArguments()[0], cfgObj: Activator.CreateInstance(it.t)))
                .Select(it =>
                    applyConfigurationMethodInfo.MakeGenericMethod(it.et).Invoke(modelBuilder, new[] {it.cfgObj}))
                .ToList();
        }

        public static void TemporalEntity<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : class, ITemporalEntity
        {
            builder.Property(e => e.EndTime)
                .HasColumnName("endTime")
                .HasColumnType(MySqlBuilderTypes.DateTime);

            builder.Property(e => e.FromTime)
                .HasColumnName("fromTime")
                .HasColumnType(MySqlBuilderTypes.DateTime);
        }

        public static void HasGuidKey<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : class, IBaseEntity<Guid>
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType(MySqlBuilderTypes.Guid);
        }

        public static void HasUtf8ColumnType(this PropertyBuilder<string> builder, string dbType)
        {
            builder
                .HasColumnType(dbType)
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");
        }

        public static void HasForeignKeyColumnType(this PropertyBuilder<Guid> builder)
        {
            builder
                .IsRequired()
                .HasColumnType(MySqlBuilderTypes.ForeignKey)
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");
        }

        public static void HasForeignKeyColumnType(this PropertyBuilder<Guid?> builder)
        {
            builder
                .HasColumnType(MySqlBuilderTypes.ForeignKey)
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_unicode_ci");
        }
    }
}