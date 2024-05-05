using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.TaskAggregate.ValueObjects;
using Tasker.Domain.UserAggregate.ValueObjects;

namespace Tasker.Infrastructure.Database.Configurations;

internal class TaskConfiguration : IEntityTypeConfiguration<Domain.TaskAggregate.Task>
{
  public void Configure(EntityTypeBuilder<Domain.TaskAggregate.Task> builder)
  {
    builder.ToTable("task");

    builder.HasKey(p => p.Id);

    builder.Property(p => p.Id)
      .HasColumnName("id")
      .HasConversion(
        taskId => taskId.Value,
        value => new TaskId(value)
      );

    builder.Property(p => p.Title)
      .HasColumnName("title")
      .IsRequired(true);
    
    builder.Property(p => p.Description)
      .HasColumnName("description")
      .IsRequired(false);
    
    builder.Property(p => p.Status)
      .HasColumnName("status")
      .HasConversion<int>()
      .IsRequired(true);
    builder.Property(p => p.Priority)
      .HasColumnName("priority")
      .HasConversion<int>()
      .IsRequired(true);

    builder.Property(p => p.BoardId)
      .HasColumnName("board_id")
      .HasConversion(boardId => boardId.Value, value => new BoardId(value))
      .IsRequired(true);

    ConfigureTimeDetails(builder);
    ConfigureResponsiblesTable(builder);
    ConfigureAttachmentFileIdsTable(builder);
    ConfigureCommentIdsTable(builder);

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

  private static void ConfigureTimeDetails(EntityTypeBuilder<Domain.TaskAggregate.Task> builder)
  {
    builder.OwnsOne(t => t.TimeDetails, b => {
      b.Property(p => p.StartDate)
        .HasColumnName("start_date")
        .HasColumnType("timestamp without time zone")
        .IsRequired(true);

      b.Property(p => p.EndDate)
        .HasColumnName("end_date")
        .HasColumnType("timestamp without time zone")
        .IsRequired(false)
        .HasDefaultValue(null);

      b.Property(p => p.Time)
        .HasColumnName("time")
        .HasColumnType("time")
        .HasConversion(
            v => v.HasValue ? v.Value.ToTimeSpan() : default,
            v => v != default ? TimeOnly.FromTimeSpan(v) : null
        )
        .IsRequired(false)
        .HasDefaultValue(null);

      b.Property(p => p.EstimatedTime)
        .HasColumnName("estimated_time")
        .HasColumnType("time")
        .HasConversion(
            v => v.HasValue ? v.Value.ToTimeSpan() : default,
            v => v != default ? TimeOnly.FromTimeSpan(v) : null
        )
        .IsRequired(false)
        .HasDefaultValue(null);
    });

    builder.Metadata
      .FindNavigation(nameof(Domain.TaskAggregate.Task.TimeDetails))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);  
  }

  private static void ConfigureResponsiblesTable(EntityTypeBuilder<Domain.TaskAggregate.Task> builder)
  {
    builder.OwnsMany(t => t.Responsibles, b => {
      b.ToTable("task_responsibles");
      
      b.WithOwner().HasForeignKey("task_id");
      
      b.HasKey(p => p.UserId);
      
      b.Property(p => p.UserId).HasConversion(
        userId => userId.Value,
        value => new UserId(value))
        .HasColumnName("user_id")
        .ValueGeneratedNever();

      b.Property(p => p.Time)
        .HasColumnName("time")
        .HasColumnType("time")
        .HasConversion(
            v => v.HasValue ? v.Value.ToTimeSpan() : default,
            v => v != default ? TimeOnly.FromTimeSpan(v) : null
        )
        .IsRequired(false)
        .HasDefaultValue(null);

      b.Property(p => p.EstimatedTime)
        .HasColumnName("estimated_time")
        .HasColumnType("time")
        .HasConversion(
            v => v.HasValue ? v.Value.ToTimeSpan() : default,
            v => v != default ? TimeOnly.FromTimeSpan(v) : null
        )
        .IsRequired(false)
        .HasDefaultValue(null);
    });

    builder.Metadata
      .FindNavigation(nameof(Domain.TaskAggregate.Task.Responsibles))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }

  private static void ConfigureAttachmentFileIdsTable(EntityTypeBuilder<Domain.TaskAggregate.Task> builder)
  {
    builder.OwnsMany(m => m.AttachmentFileIds, b =>
    {
      b.ToTable("task_attachment_file_ids");
        b.WithOwner().HasForeignKey("task_id");
        b.Property<Guid>("id").ValueGeneratedOnAdd();
        b.HasKey("id");
        b.Property(attachmentFileId => attachmentFileId.Value)
          .HasColumnName("attachment_file_id")
          .ValueGeneratedNever();
    });

    builder.Metadata
      .FindNavigation(nameof(Domain.TaskAggregate.Task.AttachmentFileIds))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }

  private static void ConfigureCommentIdsTable(EntityTypeBuilder<Domain.TaskAggregate.Task> builder)
  {
    builder.OwnsMany(m => m.CommentIds, b =>
    {
      b.ToTable("task_comment_ids");
        b.WithOwner().HasForeignKey("task_id");
        b.Property<Guid>("id").ValueGeneratedOnAdd();
        b.HasKey("id");
        b.Property(commentId => commentId.Value)
          .HasColumnName("comment_id")
          .ValueGeneratedNever();
    });

    builder.Metadata
      .FindNavigation(nameof(Domain.TaskAggregate.Task.CommentIds))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }
} 