using Tasker.Domain.CommentAggregate.ValueObjects;
using Tasker.Domain.Shared;
using Tasker.Domain.TaskAggregate.ValueObjects;
using Tasker.Domain.UserAggregate.ValueObjects;

namespace Tasker.Domain.CommentAggregate;

public sealed class Comment : AggregateRoot<CommentId>
{
  public Comment(
    CommentId id,
    string text, 
    UserId userId,
    TaskId taskId) : base(id)
  {
    Text = text;
    UserId = userId;
    TaskId = taskId;
  }
  public string Text { get; private set; }
  public UserId UserId { get; private set; }
  public TaskId TaskId { get; private set; }
  
  #pragma warning disable
  public Comment() {}
  #pragma warning restore
}