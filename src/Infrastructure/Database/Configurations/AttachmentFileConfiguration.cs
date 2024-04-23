using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasker.Domain.AttachmentFileAgggregate;
using Tasker.Domain.AttachmentFileAgggregate.ValueObjects;

namespace Tasker.Infrastructure.Database.Configurations;

internal class AttachmentFileConfiguration : IEntityTypeConfiguration<AttachmentFile>
{
  public void Configure(EntityTypeBuilder<AttachmentFile> builder)
  {
    builder.ToTable("attachment_file");

    builder.HasKey(p => p.Id);

    builder.Property(p => p.Id).HasConversion(
      boardId => boardId.Value,
      value => new AttachmentFileId(value));
    
    builder.OwnsOne(
      a => a.TaskId,
      b =>
      {
        b.WithOwner().HasForeignKey("id");
        b.Property(taskId => taskId.Value)
          .HasColumnName("task_id")
          .ValueGeneratedNever();
      }
    );
    
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