
using Tasker.Domain.TaskAggregate;
using Tasker.Domain.TaskAggregate.ValueObjects;
using Tasker.Domain.UserAggregate.ValueObjects;

namespace Tasker.Web.Pages.Tasks.ViewModels;

public class TaskChecklistViewModel
{
  public Guid? Id { get; set; }
  public string Title { get; set; } = "";
  public string? Description { get; set; }
  public bool IsDone { get; set; }
  public Guid TaskId { get; set; }
  public Guid UserId { get; set; }

  public static TaskChecklistViewModel ToViewModel(Domain.TaskAggregate.TaskChecklist taskChecklist)
  {
    return new()
    {
      Id = taskChecklist.Id.Value,
      Title = taskChecklist.Title,
      Description = taskChecklist.Description,
      IsDone = taskChecklist.IsDone,
      TaskId = taskChecklist.TaskId.Value,
      UserId = taskChecklist.UserId.Value
    };
  }

  public static IEnumerable<TaskChecklistViewModel> ToEnumerableViewModel(IEnumerable<Domain.TaskAggregate.TaskChecklist> taskChecklists)
  {
    return taskChecklists.Select(taskChecklist => ToViewModel(taskChecklist));
  }

  public static Domain.TaskAggregate.TaskChecklist ToEntity(TaskChecklistViewModel taskChecklistViewModel)
  {
    if (!taskChecklistViewModel.Id.HasValue)
    {
      return TaskChecklist.Create(
        taskChecklistViewModel.Title,
        taskChecklistViewModel.Description,
        taskChecklistViewModel.IsDone,
        new TaskId(taskChecklistViewModel.TaskId),
        new UserId(taskChecklistViewModel.UserId)  
      );
    }
    
    return new(
      new TaskChecklistId(taskChecklistViewModel.Id!.Value),
      taskChecklistViewModel.Title,
      taskChecklistViewModel.Description,
      taskChecklistViewModel.IsDone,
      new TaskId(taskChecklistViewModel.TaskId),
      new UserId(taskChecklistViewModel.UserId)
    );
  }

  public static IEnumerable<Domain.TaskAggregate.TaskChecklist> ToEnumerableEntity(IEnumerable<TaskChecklistViewModel> taskChecklistsViewModel)
  {
    return taskChecklistsViewModel.Select(taskChecklist => ToEntity(taskChecklist));
  }
}