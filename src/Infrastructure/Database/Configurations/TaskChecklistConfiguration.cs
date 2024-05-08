using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasker.Domain.TaskAggregate.ValueObjects;
using Tasker.Domain.TaskChecklistAggregate;
using Tasker.Domain.TaskChecklistAggregate.ValueObjects;
using Tasker.Domain.UserAggregate.ValueObjects;

namespace Tasker.Infrastructure.Database.Configurations;

internal class TaskChecklistConfiguration : IEntityTypeConfiguration<TaskChecklist>
{
  public void Configure(EntityTypeBuilder<TaskChecklist> builder)
  {
    builder.ToTable("task_checklist");

    builder.HasKey(p => p.Id);

    builder.Property(p => p.Id)
      .HasColumnName("id")
      .HasConversion(
        TaskChecklistId => TaskChecklistId.Value,
        value => new TaskChecklistId(value)
      );

    builder
      .Property(p => p.Title)
      .HasColumnName("title")
      .IsRequired(true);

    builder
      .Property(p => p.IsDone)
      .HasColumnName("is_done")
      .HasColumnType("boolean")
      .HasDefaultValue(false);

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