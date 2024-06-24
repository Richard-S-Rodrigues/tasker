using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.Shared;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate;

public sealed class TaskChecklist : Entity<TaskChecklistId>
{
  public TaskChecklist(
    TaskChecklistId id, 
    string title,
    string? description,
    bool isDone,
    TaskId taskId,
    MemberId memberId) : base(id)
  {
    Title = title;
    Description = description;
    IsDone = isDone;
    TaskId = taskId;
    MemberId = memberId;
  }
  public string Title { get; private set; }
  public string? Description { get; private set; }
  public bool IsDone { get; private set; }
  public TaskId TaskId { get; private set; }
  public MemberId MemberId { get; private set; }

  public static TaskChecklist Create(
    string title,
    string? description,
    bool isDone,
    TaskId taskId,
    MemberId memberId)
  {
    return new TaskChecklist(
      new TaskChecklistId(Guid.NewGuid()), 
      title,
      description,
      isDone,
      taskId,
      memberId);
  }

  public void Update(
    string title,
    string? description,
    bool isDone)
  {
    Title = title;
    Description = description;
    IsDone = isDone;
  }

  #pragma warning disable
  public TaskChecklist() {}
  #pragma warning restore
}