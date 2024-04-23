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

    builder.Property(p => p.Id).HasConversion(
      boardId => boardId.Value,
      value => new UserId(value));
    
    builder
      .Property(p => p.Name);

    builder.Property(p => p.CreatedAt).HasColumnType("timestamp without time zone");
    builder.Property(p => p.UpdatedAt).HasColumnType("timestamp without time zone");
    builder.Property(p => p.DeletedAt).HasColumnType("timestamp without time zone");
    builder
        .Property(p => p.CreatedBy)
        .HasConversion<long?>(
            s => s != null ? Convert.ToInt64(s) : null,
            l => l != null ? Convert.ToString(l) : null
        );
    builder
        .Property(p => p.UpdatedBy)
        .HasConversion<long?>(
            s => s != null ? Convert.ToInt64(s) : null,
            l => l != null ? Convert.ToString(l) : null
        );
    builder
        .Property(p => p.DeletedBy)
        .HasConversion<long?>(
            s => s != null ? Convert.ToInt64(s) : null,
            l => l != null ? Convert.ToString(l) : null
        );
  }
} 