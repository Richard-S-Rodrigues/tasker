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

  public async Task<IViewComponentResult> InvokeAsync(Guid boardId, Guid? id)
  {
    var viewModel = new ViewModel();

    if (id.HasValue)
    {
      var task = await _sender.Send(new GetTaskByIdQuery(new TaskId(id.Value)));
      if (task is not null)
      {
        viewModel.CurrentTask = TaskViewModel.ToViewModel(task);
      }
    }

    viewModel.CurrentTask.BoardId = boardId;

    return View("/Pages/Tasks/Components/SaveTask/Default.cshtml", viewModel); 
  }
}

public class ViewModel
{
  public TaskViewModel CurrentTask { get; set; } = new();
  public List<SelectListItem> TaskStatusOptions { get; set; } = Enum.GetValues(typeof(Status))
    .Cast<Status>()
    .Select(e => new SelectListItem
    {
        Value = ((int)e).ToString(),
        Text = EnumHelper.GetEnumStatusLabel(e)
    }).ToList();
  public List<SelectListItem> TaskPriorityOptions { get; set; } = Enum.GetValues(typeof(Priority))
    .Cast<Priority>()
    .Select(e => new SelectListItem
    {
        Value = ((int)e).ToString(),
        Text = EnumHelper.GetEnumPriorityLabel(e)
    }).ToList();
}
