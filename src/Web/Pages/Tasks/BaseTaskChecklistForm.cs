using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tasker.Domain.TaskAggregate.Commands;
using Tasker.Domain.TaskAggregate.ValueObjects;
using Tasker.Web.Pages.Tasks.ViewModels;

namespace Tasker.Web.Pages.Tasks;

[IgnoreAntiforgeryToken]
public class BaseTaskChecklistForm : PageModel
{
  private readonly ISender _sender;
  
  public BaseTaskChecklistForm(ISender sender) 
  {
    _sender = sender;
  }

  [BindProperty(SupportsGet = true)]
  public Guid BoardId { get; set; }
  [BindProperty(SupportsGet = true)]
  public Guid TaskId { get; set; }
  [BindProperty(SupportsGet = true)]
  public Guid? Id { get; set; }
  [BindProperty]
  public TaskChecklistViewModel CurrentTaskChecklist { get; set; } = new();

  public async Task<IActionResult> OnPostAsync()
  {
    try 
    {
      var taskChecklist = TaskChecklistViewModel.ToEntity(CurrentTaskChecklist);
      if (CurrentTaskChecklist.Id.HasValue)
      {
        var updateCommand = new UpdateTaskChecklistCommand(
          taskChecklist.Id, 
          taskChecklist.Title,
          taskChecklist.Description,
          taskChecklist.IsDone,
          new TaskId(TaskId));
        await _sender.Send(updateCommand);
      }
      else 
      {
        var createCommand = new CreateTaskChecklistCommand(
          taskChecklist.Title,
          taskChecklist.Description,
          taskChecklist.IsDone,
          new TaskId(TaskId));
        await _sender.Send(createCommand);
      }

      Response.Headers.Add("HX-Redirect", Url.Page("./Edit", new { boardId = BoardId, id = TaskId }));
      return new EmptyResult();
    }
    catch(Exception e)
    {
      return Page();
    }
  }
}