using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.TaskAggregate;
using Tasker.Domain.TaskAggregate.Enums;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Web.Pages.Tasks.ViewModels;

public class TaskViewModel
{
  public Guid? Id { get; set; }
  public Guid BoardId { get; set; }
  public string Title { get; set; } = "";
  public string? Description { get; set; }
  public DateTime StartDate { get; private set; } = DateTime.Now;
  public DateTime EndDate { get; private set; } = DateTime.Now.AddDays(1);
  public TimeOnly? Time { get; private set; }
  public TimeOnly? EstimatedTime { get; private set; }
  public Status Status { get; set; }
  public Priority Priority { get; set; }
  public List<Responsible> Responsibles { get; set; } = new();
  public List<AttachmentFile> AttachmentFiles { get; set; } = new();
  public List<Comment> Comments { get; set; } = new();
  public List<TaskChecklistViewModel> TaskChecklists { get; set; } = new();

  public static TaskViewModel ToViewModel(Domain.TaskAggregate.Task task)
  {
    return new()
    {
      Id = task.Id.Value,
      Title = task.Title,
      Description = task.Description,
      StartDate = task.TimeDetails.StartDate,
      EndDate = task.TimeDetails.EndDate,
      EstimatedTime = task.TimeDetails.EstimatedTime,
      Time = task.TimeDetails.Time,
      Status = task.Status,
      Priority = task.Priority,
      Responsibles = task.Responsibles,
      AttachmentFiles = task.AttachmentFiles,
      Comments = task.Comments,
      TaskChecklists = TaskChecklistViewModel.ToEnumerableViewModel(task.TaskChecklists).ToList()
    };
  }

  public static Domain.TaskAggregate.Task ToEntity(TaskViewModel taskViewModel)
  {
    if (!taskViewModel.Id.HasValue)
    {
      return Domain.TaskAggregate.Task.Create( 
        new BoardId(taskViewModel.BoardId),
        taskViewModel.Title,
        taskViewModel.Description,
        new TimeDetails(taskViewModel.StartDate, taskViewModel.EndDate, taskViewModel.Time, taskViewModel.EstimatedTime),
        taskViewModel.Status,
        taskViewModel.Priority,
        taskViewModel.Responsibles,
        taskViewModel.AttachmentFiles,
        taskViewModel.Comments,
        TaskChecklistViewModel.ToEnumerableEntity(taskViewModel.TaskChecklists).ToList());  
    }
    
    return new(
      new TaskId(taskViewModel.Id.Value), 
      new BoardId(taskViewModel.BoardId),
      taskViewModel.Title,
      taskViewModel.Description,
      new TimeDetails(taskViewModel.StartDate, taskViewModel.EndDate, taskViewModel.Time, taskViewModel.EstimatedTime),
      taskViewModel.Status,
      taskViewModel.Priority,
      taskViewModel.Responsibles,
      taskViewModel.AttachmentFiles,
      taskViewModel.Comments,
      TaskChecklistViewModel.ToEnumerableEntity(taskViewModel.TaskChecklists).ToList());
  }
}