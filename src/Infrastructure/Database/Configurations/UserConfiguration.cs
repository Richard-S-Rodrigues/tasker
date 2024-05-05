using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasker.Domain.UserAggregate;
using Tasker.Domain.UserAggregate.ValueObjects;

namespace Tasker.Infrastructure.Database.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.ToTable("user");

    builder.HasKey(p => p.Id);

    builder.Property(p => p.Id)
      .HasColumnName("id")
      .HasConversion(
        userId => userId.Value,
        value => new UserId(value)
      );

    builder
      .Property(p => p.Name)
      .HasColumnName("name")
      .IsRequired(true);

    builder.Property(p => p.CreatedAt)
      .HasColumnName("created_at")
      .HasColumnType("timestamp without time zone");
    builder.Property(p => p.UpdatedAt)
    .HasColumnName("updated_at")
    .HasColumnType("timestamp without time zone");
    builder.Property(p => p.DeletedAt)
    .HasColumnName("deleted_at")
    .HasColumnType("timestamp without time zone");
    builder
        .Property(p => p.CreatedBy)
        .HasColumnName("created_by")
        .HasConversion<long?>(
            s => s != null ? Convert.ToInt64(s) : null,
            l => l != null ? Convert.ToString(l) : null
        );
    builder
        .Property(p => p.UpdatedBy)
        .HasColumnName("updated_by")
        .HasConversion<long?>(
            s => s != null ? Convert.ToInt64(s) : null,
            l => l != null ? Convert.ToString(l) : null
        );
    builder
        .Property(p => p.DeletedBy)
        .HasColumnName("deleted_by")
        .HasConversion<long?>(
            s => s != null ? Convert.ToInt64(s) : null,
            l => l != null ? Convert.ToString(l) : null
        );
  }
} 