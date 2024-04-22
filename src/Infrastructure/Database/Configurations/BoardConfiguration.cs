using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasker.Domain.BoardAggregate;
using Tasker.Domain.BoardAggregate.ValueObjects;

namespace Tasker.Infrastructure.Database.Configurations;

internal class BoardConfiguration : IEntityTypeConfiguration<Board>
{
  public void Configure(EntityTypeBuilder<Board> builder)
  {
    builder.ToTable("board");

    builder.HasKey(p => p.Id);

    builder.Property(p => p.Id).HasConversion(
      boardId => boardId.Value,
      value => new BoardId(value));
    
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

    builder.Property(p => p.Name);

    builder.OwnsMany(
      a => a.TaskIds,
      b => 
      {
        b.WithOwner().HasForeignKey("TaskId");
        b.Property<long>("id").ValueGeneratedOnAdd();
        b.HasKey("id");
        b.Property(taskId => taskId.Value)
          .HasColumnName("task_id")
          .ValueGeneratedNever();
      }
    );
    builder.Metadata
      .FindNavigation(nameof(Board.TaskIds))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);

    builder.OwnsMany(
      a => a.MemberIds,
      b => 
      {
        b.WithOwner().HasForeignKey("MemberId");
        b.Property<long>("id").ValueGeneratedOnAdd();
        b.HasKey("id");
        b.Property(memberId => memberId.Value)
          .HasColumnName("member_id")
          .ValueGeneratedNever();
      }
    );
    builder.Metadata
      .FindNavigation(nameof(Board.MemberIds))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }
} 