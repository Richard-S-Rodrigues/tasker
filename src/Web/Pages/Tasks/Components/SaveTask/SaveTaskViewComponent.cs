using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tasker.Domain.TaskAggregate.Enums;
using Tasker.Domain.TaskAggregate.Queries;
using Tasker.Domain.TaskAggregate.ValueObjects;
using Tasker.Web.Helpers;
using Tasker.Web.Pages.Tasks.ViewModels;

namespace Tasker.Web.Pages.Tasks.Components.SaveTask;

public class SaveTaskViewComponent : ViewComponent
{
  private readonly ISender _sender;
  public SaveTaskViewComponent(ISender sender) 
  {
    _sender = sender;
  }

  public async Task<IViewComponentResult> InvokeAsync(Guid boardId, BaseTaskForm model, Guid? id)
  {
    ViewBag.CurrentPage = id.HasValue ? "Edit" : "Create";
    ViewBag.TaskStatusOptions = Enum.GetValues(typeof(Status))
    .Cast<Status>()
    .Select(e => new SelectListItem
    {
        Value = ((int)e).ToString(),
        Text = EnumHelper.GetEnumStatusLabel(e)
    }).ToList();

    ViewBag.TaskPriorityOptions = Enum.GetValues(typeof(Priority))
    .Cast<Priority>()
    .Select(e => new SelectListItem
    {
        Value = ((int)e).ToString(),
        Text = EnumHelper.GetEnumPriorityLabel(e)
    }).ToList();

    if (id.HasValue)
    {
      var task = await _sender.Send(new GetTaskByIdQuery(new TaskId(id.Value)));
      if (task is not null)
      {
        model.CurrentTask = TaskViewModel.ToViewModel(task);
      }
    }

    model.CurrentTask.BoardId = boardId;

    return View("/Pages/Tasks/Components/SaveTask/Default.cshtml", model); 
  }
}
