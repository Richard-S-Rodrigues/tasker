using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Htmx;
using Tasker.Web.Pages.Shared.ViewModels;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.TaskAggregate.Queries;
using Tasker.Web.Pages.Tasks.ViewModels;
using Tasker.Web.Pages.Boards.ViewModels;
using Tasker.Domain.BoardAggregate.Queries;
using Tasker.Domain.TaskAggregate.Commands;

namespace Tasker.Web.Pages.Tasks;

[IgnoreAntiforgeryToken]
public class Index : PageModel
{
  private readonly ISender _sender;
  public Index(ISender sender)
  {   
    _sender = sender;
  }

  public ErrorViewModel Error { get; private set; } = new();

  public BoardViewModel Board { get; private set; }
  
  public List<TaskViewModel> TaskList { get; private set; } = new();

  [BindProperty]
  public TaskViewModel CurrentTask { get; set; } = new();

  public async Task<IActionResult> OnGetAsync(Guid? boardId)
  {
    if (boardId == null)
    {
      return RedirectToPage("/boards");
    }
    
    Board = await GetBoardData(boardId.Value);
    TaskList = await GetTasks(boardId.Value);

    if (HttpContext.Request.IsHtmx())
    {
      return Partial("_Result", this);
    }

    return Page();
  }

  public async Task<List<TaskViewModel>> GetTasks(Guid boardId)
  {
    var tasks = await _sender.Send(new GetAllTasksByBoardIdQuery(new BoardId(boardId)));
    return tasks.Select(task => TaskViewModel.ToViewModel(task)).ToList();
  }

  public async Task<BoardViewModel> GetBoardData(Guid boardId)
  {
    var board = await _sender.Send(new GetBoardByIdQuery(new BoardId(boardId)));
    
    return BoardViewModel.ToViewModel(board!);
  }    

  public async Task<IActionResult> OnPostSaveTask()
  {
    try 
    {
      var taskEntity = TaskViewModel.ToEntity(CurrentTask);
      if (CurrentTask.Id.HasValue)
      {
          var updateCommand = new UpdateTaskCommand(
            taskEntity.Id,
            taskEntity.BoardId, 
            taskEntity.Title,
            taskEntity.Description,
            taskEntity.TimeDetails,
            taskEntity.Status,
            taskEntity.Priority,
            taskEntity.Responsibles,
            taskEntity.AttachmentFiles,
            taskEntity.Comments,
            taskEntity.TaskChecklists);
          await _sender.Send(updateCommand);
      }
      else 
      {
          var createCommand = new CreateTaskCommand(
            taskEntity.BoardId,
            taskEntity.Title,
            taskEntity.Description,
            taskEntity.TimeDetails,
            taskEntity.Priority,
            taskEntity.Responsibles);
          await _sender.Send(createCommand);
      }

      TaskList = await GetTasks(CurrentTask.BoardId);

      return RedirectToPage($"/tasks?boardId={CurrentTask.BoardId}");
    }
    catch(Exception e)
    {
      Error.HasError = true;
      Error.ErrorMessage = e.Message;
      return Page();
    }
  }
}
