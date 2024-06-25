using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.Shared;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate;

public sealed class Comment : Entity<CommentId>
{
  public Comment(
    CommentId id,
    string text, 
    MemberId memberId,
    TaskId taskId) : base(id)
  {
    Text = text;
    MemberId = memberId;
    TaskId = taskId;
  }
  public string Text { get; private set; }
  public MemberId MemberId { get; private set; }
  public TaskId TaskId { get; private set; }

  public static Comment Create(string text, MemberId memberId, TaskId taskId)
  {
    return new Comment(new CommentId(Guid.NewGuid()), text, memberId, taskId);
  }
  
  #pragma warning disable
  public Comment() {}
  #pragma warning restore
}