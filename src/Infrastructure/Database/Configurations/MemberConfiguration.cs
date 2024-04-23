using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasker.Domain.MemberAggregate;
using Tasker.Domain.MemberAggregate.ValueObjects;

namespace Tasker.Infrastructure.Database.Configurations;

internal class MemberConfiguration : IEntityTypeConfiguration<Member>
{
  public void Configure(EntityTypeBuilder<Member> builder)
  {
    builder.ToTable("member");

    builder.HasKey(p => p.Id);

    builder.Property(p => p.Id).HasConversion(
      boardId => boardId.Value,
      value => new MemberId(value));
    
    builder
      .Property(p => p.IsAdmin)
      .HasColumnType("boolean")
      .HasDefaultValue(false);
        
    builder.OwnsOne(
      a => a.BoardId,
      b =>
      {
        b.WithOwner().HasForeignKey("BoardId");
        b.Property(boardId => boardId.Value)
          .HasColumnName("board_id")
          .ValueGeneratedNever();
      }
    );

    builder.OwnsOne(
      a => a.UserId,
      b =>
      {
        b.WithOwner().HasForeignKey("UserId");
        b.Property(UserId => UserId.Value)
          .HasColumnName("user_id")
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