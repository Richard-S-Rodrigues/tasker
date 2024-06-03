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
using Tasker.Domain.TaskAggregate.ValueObjects;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tasker.Domain.TaskAggregate.Enums;

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

  public List<SelectListItem> TaskStatusOptions { get; set; } = Enum.GetValues(typeof(Status))
    .Cast<Status>()
    .Select(e => new SelectListItem
    {
        Value = ((int)e).ToString(),
        Text = GetEnumStatusLabel(e)
    }).ToList();
  public List<SelectListItem> TaskPriorityOptions { get; set; } = Enum.GetValues(typeof(Priority))
    .Cast<Priority>()
    .Select(e => new SelectListItem
    {
        Value = ((int)e).ToString(),
        Text = GetEnumPriorityLabel(e)
    }).ToList();
  
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

  public IActionResult OnGetSaveTaskModal(Guid boardId, Guid? taskId)
  {

    if (taskId.HasValue)
    {
      var task = TaskList.FirstOrDefault(b => b.Id == taskId.Value);
      if (task != null)
      {
        CurrentTask = task;
      }
    }

    CurrentTask.BoardId = boardId;
    
    return Partial("_TaskModal", this);
  }

  public IActionResult OnPostAddChecklist()
  {
    return Partial("_SaveTaskChecklist", new TaskChecklistViewModel());
  }

  public IActionResult OnPostSaveChecklist(string title)
  {
    var checklist = new TaskChecklistViewModel
    {
      Title = title
    };

    CurrentTask.TaskChecklists.Add(checklist);

    return Partial("_TaskModal", this);
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

      if (HttpContext.Request.IsHtmx())
      {
        return Partial("_Result", this);
      }

      return Page();
    }
    catch(Exception e)
    {
      Error.HasError = true;
      Error.ErrorMessage = e.Message;
      return Partial("_Result", this);
    }
  }

  private static string GetEnumStatusLabel(Status value)
  {
    return value switch
    {
      Status.InRefinement => "Em refinamento",
      Status.Ready => "Pronto",
      Status.OnProgress => "Em progresso",
      Status.Interrupted => "Interrompido",
      Status.Canceled => "Cancelado",
      Status.Done => "Concluído",
      _ => value.ToString()
    };
  }

  private static string GetEnumPriorityLabel(Priority value)
  {
    return value switch
    {
      Priority.Low => "Baixa",
      Priority.Medium => "Média",
      Priority.High => "Alta",
      Priority.Urgent => "Urgente",
      _ => value.ToString()
    };
  }
}
