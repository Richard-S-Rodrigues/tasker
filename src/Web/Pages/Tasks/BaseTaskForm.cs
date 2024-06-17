using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tasker.Domain.TaskAggregate.Commands;
using Tasker.Domain.TaskAggregate.Queries;
using Tasker.Domain.TaskAggregate.ValueObjects;
using Tasker.Web.Pages.Tasks.ViewModels;

namespace Tasker.Web.Pages.Tasks;

[IgnoreAntiforgeryToken]
public class BaseTaskForm : PageModel
{
  private readonly ISender _sender;
  public BaseTaskForm(ISender sender)
  {   
    _sender = sender;
  }

  [BindProperty(SupportsGet = true)]
  public Guid? Id { get; set; }
  
  [BindProperty(SupportsGet = true)]
  public Guid BoardId { get; set; }

  [BindProperty]
  public TaskViewModel CurrentTask { get; set; } = new();

  [BindProperty]
  public IFormFile SelectedFile { get; set; } = null!;

  public async Task<IActionResult> OnPostAsync()
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
            taskEntity.Status,
            taskEntity.Priority,
            taskEntity.Responsibles);
          await _sender.Send(createCommand);
      }

      Response.Headers.Add("HX-Redirect", Url.Page("./Index", new { boardId = CurrentTask.BoardId }));
      return new EmptyResult();
    }
    catch(Exception e)
    {
      return Page();
    }
  }

  public async Task<IActionResult> OnPostDelete()
  {
    if (Id.HasValue)
    {
      await _sender.Send(new DeleteTaskCommand(new TaskId(Id.Value)));
    }
    
    Response.Headers.Add("HX-Redirect", Url.Page("./Index", new { boardId = CurrentTask.BoardId }));
    return new EmptyResult();
  }

  public async Task OnPostToggleChecklistStatus(Guid checklistId)
  {
    var checklist = await _sender.Send(new GetTaskChecklistQuery(new TaskId(Id!.Value), new TaskChecklistId(checklistId)));

    if (checklist is not null)
    {
      var updateChecklistCommand = new UpdateTaskChecklistCommand(
          checklist.Id, 
          checklist.Title,
          checklist.Description,
          !checklist.IsDone,
          new TaskId(Id!.Value));
        await _sender.Send(updateChecklistCommand);
    }
  }
  
  public async Task<IActionResult> OnPostUploadSelectedFile()
  {
    if (SelectedFile != null)
    {
      string name = SelectedFile.FileName;
      string contentType = SelectedFile.ContentType;
      
      using (var memoryStream = new MemoryStream())
      {
        await SelectedFile.CopyToAsync(memoryStream);
        var fileBytes = memoryStream.ToArray();
        string base64 = Convert.ToBase64String(fileBytes);

        var command = new AddAttachmentFileCommand(new TaskId(Id!.Value), name, contentType, base64);
        await _sender.Send(command);
      }
    }

    var attachmentFiles = await _sender.Send(new GetAttachmentFilesByTaskIdQuery(new TaskId(Id!.Value)));
    return Partial("_AttachmentFilesList", AttachmentFileViewModel.ToEnumerableViewModel(attachmentFiles).ToList());
  }

  public async Task<IActionResult> OnPostDeleteAttachmentFile(Guid id)
  {
    var attachmentFile = CurrentTask.AttachmentFiles.FirstOrDefault(af => af.Id!.Value == id);

    if (attachmentFile is not null)
    {
      await _sender.Send(new DeleteAttachmentFileCommand(AttachmentFileViewModel.ToEntity(attachmentFile)));
      CurrentTask.AttachmentFiles.Remove(attachmentFile);
    }

    return Partial("_AttachmentFilesList", CurrentTask.AttachmentFiles.ToList());
  }
}