using Tasker.Domain.AttachmentFileAggregate.ValueObjects;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.CommentAggregate.ValueObjects;
using Tasker.Domain.TaskAggregate.Enums;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Web.Pages.Tasks.ViewModels;

public class TaskViewModel
{
  public Guid? Id { get; set; }
  public Guid BoardId { get; set; }
  public string Title { get; set; } = "";
  public string? Description { get; set; }
  public TimeDetails TimeDetails { get; set; } = new();
  public Status Status { get; set; }
  public Priority Priority { get; set; }
  public List<Responsible> Responsibles { get; set; } = new();
  public List<AttachmentFileId> AttachmentFileIds { get; set; } = new();
  public List<CommentId> CommentIds { get; set; } = new();

  public static TaskViewModel ToViewModel(Domain.TaskAggregate.Task task)
  {
    return new()
    {
      Id = task.Id.Value,
      Title = task.Title,
      Description = task.Description,
      TimeDetails = task.TimeDetails,
      Status = task.Status,
      Priority = task.Priority,
      Responsibles = task.Responsibles,
      AttachmentFileIds = task.AttachmentFileIds,
      CommentIds = task.CommentIds
    };
  }

  public static Domain.TaskAggregate.Task ToEntity(TaskViewModel taskViewModel)
  {
    return new(
      new TaskId(taskViewModel.Id!.Value), 
      new BoardId(taskViewModel.BoardId),
      taskViewModel.Title,
      taskViewModel.Description,
      taskViewModel.TimeDetails,
      taskViewModel.Status,
      taskViewModel.Priority,
      taskViewModel.Responsibles,
      taskViewModel.AttachmentFileIds,
      taskViewModel.CommentIds);
  }
}