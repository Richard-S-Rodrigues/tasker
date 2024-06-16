using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasker.Domain.TaskAggregate.Queries;
using Tasker.Domain.TaskAggregate.ValueObjects;
using Tasker.Web.Pages.Tasks.ViewModels;

namespace Tasker.Web.Pages.Tasks.Components.SaveTaskChecklist;

public class SaveTaskChecklistViewComponent : ViewComponent
{
  private readonly ISender _sender;

  public SaveTaskChecklistViewComponent(ISender sender)
  {
    _sender = sender;
  }

  public async Task<IViewComponentResult> InvokeAsync(Guid taskId, Guid? id, BaseTaskChecklistForm model)
  {
    ViewBag.CurrentPage = id.HasValue ? "EditTaskChecklist" : "CreateTaskChecklist";

    if (id.HasValue)
    {
      var taskChecklist = await _sender.Send(new GetTaskChecklistQuery(new TaskId(taskId), new TaskChecklistId(id.Value)));
      model.CurrentTaskChecklist = TaskChecklistViewModel.ToViewModel(taskChecklist);
    }
    return View("/Pages/Tasks/Components/SaveTaskChecklist/Default.cshtml", model); 
  }
}
