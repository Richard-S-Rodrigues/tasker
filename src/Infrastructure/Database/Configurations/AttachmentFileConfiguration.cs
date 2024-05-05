using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasker.Domain.AttachmentFileAggregate;
using Tasker.Domain.AttachmentFileAggregate.ValueObjects;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Infrastructure.Database.Configurations;

internal class AttachmentFileConfiguration : IEntityTypeConfiguration<AttachmentFile>
{
  public void Configure(EntityTypeBuilder<AttachmentFile> builder)
  {
    builder.ToTable("attachment_file");

    builder.HasKey(p => p.Id);

    builder.Property(p => p.Id)
      .HasColumnName("id")
      .HasConversion(
        id => id.Value,
        value => new AttachmentFileId(value)
      );
    
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