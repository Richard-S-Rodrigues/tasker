using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasker.Domain.CommentAggregate;
using Tasker.Domain.CommentAggregate.ValueObjects;
using Tasker.Domain.TaskAggregate.ValueObjects;
using Tasker.Domain.UserAggregate.ValueObjects;

namespace Tasker.Infrastructure.Database.Configurations;

internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
  public void Configure(EntityTypeBuilder<Comment> builder)
  {
    builder.ToTable("comment");

    builder.HasKey(p => p.Id);

    builder.Property(p => p.Id)
      .HasColumnName("id")
      .HasConversion(
        commentId => commentId.Value,
        value => new CommentId(value)
      );
    
    builder.Property(c => c.Text)
      .HasColumnName("text")
      .IsRequired(true);

    builder.Property(p => p.UserId)
      .HasColumnName("user_id")
      .HasConversion(userId => userId.Value, value => new UserId(value))
      .IsRequired(true);

    builder.Property(p => p.TaskId)
      .HasColumnName("task_id")
      .HasConversion(taskId => taskId.Value, value => new TaskId(value))
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