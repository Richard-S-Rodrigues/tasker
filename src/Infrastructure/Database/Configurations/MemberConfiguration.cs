using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.MemberAggregate;
using Tasker.Domain.MemberAggregate.ValueObjects;
using Tasker.Domain.UserAggregate.ValueObjects;

namespace Tasker.Infrastructure.Database.Configurations;

internal class MemberConfiguration : IEntityTypeConfiguration<Member>
{
  public void Configure(EntityTypeBuilder<Member> builder)
  {
    builder.ToTable("member");

    builder.HasKey(p => p.Id);

    builder.Property(p => p.Id).HasConversion(
      memberId => memberId.Value,
      value => new MemberId(value));
    
    builder
      .Property(p => p.IsAdmin)
      .HasColumnName("is_admin")
      .HasColumnType("boolean")
      .HasDefaultValue(false);

    builder.Property(p => p.UserId)
      .HasColumnName("user_id")
      .HasColumnType("bigint")
      .HasConversion(userId => userId.Value, value => new UserId(value))
      .IsRequired(true);

    builder.Property(p => p.BoardId)
      .HasColumnName("board_id")
      .HasColumnType("bigint")
      .HasConversion(boardId => boardId.Value, value => new BoardId(value))
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