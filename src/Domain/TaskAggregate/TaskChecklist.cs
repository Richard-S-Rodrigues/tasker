using Tasker.Domain.Shared;
using Tasker.Domain.TaskAggregate.ValueObjects;
using Tasker.Domain.UserAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate;

public sealed class TaskChecklist : Entity<TaskChecklistId>
{
  public TaskChecklist(
    TaskChecklistId id, 
    string title,
    bool isDone,
    TaskId taskId,
    UserId userId) : base(id)
  {
    Title = title;
    IsDone = isDone;
    TaskId = taskId;
    UserId = userId;
  }
  public string Title { get; private set; }
  public bool IsDone { get; private set; }
  public TaskId TaskId { get; private set; }
  public UserId UserId { get; private set; }

  public static TaskChecklist Create(
    string title,
    bool isDone,
    TaskId taskId,
    UserId userId)
  {
    return new TaskChecklist(
      new TaskChecklistId(Guid.NewGuid()), 
      title,
      isDone,
      taskId,
      userId);
  }

  #pragma warning disable
  public TaskChecklist() {}
  #pragma warning restore
}