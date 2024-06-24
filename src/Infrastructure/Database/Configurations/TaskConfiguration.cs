using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.TaskAggregate.ValueObjects;

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
    ConfigureAttachmentFilesTable(builder);
    ConfigureCommentsTable(builder);
    ConfigureTaskChecklistsTable(builder);

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
        .IsRequired(true);

      b.Property(p => p.Time)
        .HasColumnName("time");

      b.Property(p => p.EstimatedTime)
        .HasColumnName("estimated_time");
        
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
      
      b.HasKey(p => p.MemberId);
      
      b.Property(p => p.MemberId).HasConversion(
        memberId => memberId.Value,
        value => new MemberId(value))
        .HasColumnName("user_id")
        .ValueGeneratedNever();

      b.Property(p => p.Time)
        .HasColumnName("time");

      b.Property(p => p.EstimatedTime)
        .HasColumnName("estimated_time");

      });

    builder.Metadata
      .FindNavigation(nameof(Domain.TaskAggregate.Task.Responsibles))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }

  private static void ConfigureAttachmentFilesTable(EntityTypeBuilder<Domain.TaskAggregate.Task> builder)
  {
    builder.OwnsMany(m => m.AttachmentFiles, b =>
    {
      b.ToTable("task_attachment_file");
        
      b.HasKey(p => p.Id);

      b.Property(p => p.Id)
        .HasColumnName("id")
        .HasConversion(
          id => id.Value,
          value => new AttachmentFileId(value)
        );
      
      b.Property(p => p.TaskId)
        .HasColumnName("task_id")
        .HasConversion(taskId => taskId.Value, value => new TaskId(value));

      b.Property(c => c.Name)
        .HasColumnName("name")
        .IsRequired(true);

      b.Property(c => c.ContentType)
        .HasColumnName("content_type")
        .IsRequired(true);

      b.Property(c => c.Base64)
        .HasColumnName("base64")
        .IsRequired(true);

      b.Property(p => p.CreatedAt)
        .HasColumnName("created_at")
        .HasColumnType("timestamp without time zone");
      b.Property(p => p.UpdatedAt)
        .HasColumnName("updated_at")
        .HasColumnType("timestamp without time zone");
      b.Property(p => p.DeletedAt)
        .HasColumnName("deleted_at")
        .HasColumnType("timestamp without time zone");
      b.Property(p => p.CreatedBy)
        .HasColumnName("created_by")
        .HasConversion<long?>(
            s => s != null ? Convert.ToInt64(s) : null,
            l => l != null ? Convert.ToString(l) : null
        );
      b.Property(p => p.UpdatedBy)
        .HasColumnName("updated_by")
        .HasConversion<long?>(
            s => s != null ? Convert.ToInt64(s) : null,
            l => l != null ? Convert.ToString(l) : null
        );
      b.Property(p => p.DeletedBy)
        .HasColumnName("deleted_by")
        .HasConversion<long?>(
            s => s != null ? Convert.ToInt64(s) : null,
            l => l != null ? Convert.ToString(l) : null
        );
    });

    builder.Metadata
      .FindNavigation(nameof(Domain.TaskAggregate.Task.AttachmentFiles))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }

  private static void ConfigureCommentsTable(EntityTypeBuilder<Domain.TaskAggregate.Task> builder)
  {
    builder.OwnsMany(m => m.Comments, b =>
    {
      b.ToTable("task_comment");

      b.HasKey(p => p.Id);

      b.Property(p => p.Id)
        .HasColumnName("id")
        .HasConversion(
          commentId => commentId.Value,
          value => new CommentId(value)
        );
    
      b.Property(c => c.Text)
        .HasColumnName("text")
        .IsRequired(true);

      b.Property(p => p.MemberId)
        .HasColumnName("user_id")
        .HasConversion(memberId => memberId.Value, value => new MemberId(value))
        .IsRequired(true);

      b.Property(p => p.TaskId)
        .HasColumnName("task_id")
        .HasConversion(taskId => taskId.Value, value => new TaskId(value))
        .IsRequired(true);
    
      b.Property(p => p.CreatedAt)
        .HasColumnName("created_at")
        .HasColumnType("timestamp without time zone");
      b.Property(p => p.UpdatedAt)
        .HasColumnName("updated_at")
        .HasColumnType("timestamp without time zone");
      b.Property(p => p.DeletedAt)
        .HasColumnName("deleted_at")
        .HasColumnType("timestamp without time zone");
      b.Property(p => p.CreatedBy)
        .HasColumnName("created_by")
        .HasConversion<long?>(
            s => s != null ? Convert.ToInt64(s) : null,
            l => l != null ? Convert.ToString(l) : null
        );
      b.Property(p => p.UpdatedBy)
        .HasColumnName("updated_by")
        .HasConversion<long?>(
            s => s != null ? Convert.ToInt64(s) : null,
            l => l != null ? Convert.ToString(l) : null
        );
      b.Property(p => p.DeletedBy)
        .HasColumnName("deleted_by")
        .HasConversion<long?>(
            s => s != null ? Convert.ToInt64(s) : null,
            l => l != null ? Convert.ToString(l) : null
        );
    });

    builder.Metadata
      .FindNavigation(nameof(Domain.TaskAggregate.Task.Comments))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }

  private static void ConfigureTaskChecklistsTable(EntityTypeBuilder<Domain.TaskAggregate.Task> builder)
  {
    builder.OwnsMany(m => m.TaskChecklists, b =>
    {
      b.ToTable("task_checklist");

      b.HasKey(p => p.Id);

      b.Property(p => p.Id)
        .HasColumnName("id")
        .HasConversion(
          TaskChecklistId => TaskChecklistId.Value,
          value => new TaskChecklistId(value)
        );

      b.Property(p => p.Title)
        .HasColumnName("title")
        .IsRequired(true);
      
      b.Property(p => p.Description)
        .HasColumnName("description")
        .IsRequired(false)
        .HasDefaultValue(null);

      b.Property(p => p.IsDone)
        .HasColumnName("is_done")
        .HasColumnType("boolean")
        .HasDefaultValue(false);

      b.Property(p => p.MemberId)
        .HasColumnName("user_id")
        .HasConversion(memberId => memberId.Value, value => new MemberId(value))
        .IsRequired(true);

      b.Property(p => p.TaskId)
        .HasColumnName("task_id")
        .HasConversion(taskId => taskId.Value, value => new TaskId(value))
        .IsRequired(true);

      b.Property(p => p.CreatedAt)
        .HasColumnName("created_at")
        .HasColumnType("timestamp without time zone");
      b.Property(p => p.UpdatedAt)
        .HasColumnName("updated_at")
        .HasColumnType("timestamp without time zone");
      b.Property(p => p.DeletedAt)
        .HasColumnName("deleted_at")
        .HasColumnType("timestamp without time zone");
      b.Property(p => p.CreatedBy)
        .HasColumnName("created_by")
        .HasConversion<long?>(
            s => s != null ? Convert.ToInt64(s) : null,
            l => l != null ? Convert.ToString(l) : null
        );
      b.Property(p => p.UpdatedBy)
        .HasColumnName("updated_by")
        .HasConversion<long?>(
            s => s != null ? Convert.ToInt64(s) : null,
            l => l != null ? Convert.ToString(l) : null
        );
      b.Property(p => p.DeletedBy)
        .HasColumnName("deleted_by")
        .HasConversion<long?>(
            s => s != null ? Convert.ToInt64(s) : null,
            l => l != null ? Convert.ToString(l) : null
        );
    });

    builder.Metadata
      .FindNavigation(nameof(Domain.TaskAggregate.Task.TaskChecklists))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }
} 