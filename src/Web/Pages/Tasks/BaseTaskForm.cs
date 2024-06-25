using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.TaskAggregate.Commands;
using Tasker.Domain.TaskAggregate.Queries;
using Tasker.Domain.TaskAggregate.ValueObjects;
using Tasker.Web.Pages.Tasks.ViewModels;

namespace Tasker.Web.Pages.Tasks;

[IgnoreAntiforgeryToken]
public class BaseTaskForm : PageModel
{
  private readonly ISender _sender;
  private IHttpContextAccessor _httpContextAccessor;
  private readonly UserManager<IdentityUser> _userManager;

  public BaseTaskForm(ISender sender, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
  {   
    _sender = sender;
    _httpContextAccessor = httpContextAccessor;
    _userManager = userManager;
  }

  [BindProperty(SupportsGet = true)]
  public Guid? Id { get; set; }
  
  [BindProperty(SupportsGet = true)]
  public Guid BoardId { get; set; }

  [BindProperty]
  public TaskViewModel CurrentTask { get; set; } = new();

  [BindProperty]
  public IFormFile SelectedFile { get; set; } = null!;
  [BindProperty]
  public string? CurrentCommentMessage { get; set; } = null!;

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
            taskEntity.Priority);
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
    return ViewComponent("AttachmentFilesList", AttachmentFileViewModel.ToEnumerableViewModel(attachmentFiles).ToList());
  }

  public async Task<IActionResult> OnPostDeleteAttachmentFile(Guid id, Guid taskId)
  {
    var attachmentFiles = await _sender.Send(new GetAttachmentFilesByTaskIdQuery(new TaskId(taskId)));
    var attachmentFile = attachmentFiles.FirstOrDefault(af => af.Id!.Value == id);

    if (attachmentFile is not null)
    {
      await _sender.Send(new DeleteAttachmentFileCommand(attachmentFile));
      attachmentFiles.Remove(attachmentFile);
    }

    return ViewComponent("AttachmentFilesList", AttachmentFileViewModel.ToEnumerableViewModel(attachmentFiles).ToList());
  }

  public async Task<IActionResult> OnGetDownloadAttachmentFile(Guid id, Guid taskId)
  {
    var attachmentFile = await _sender.Send(new GetAttachmentFileQuery(new TaskId(taskId), new AttachmentFileId(id)));
    if (attachmentFile is null)
    {
      return new EmptyResult();
    }
    var attachmentFileByteData = Convert.FromBase64String(attachmentFile.Base64);
    
    return File(attachmentFileByteData, attachmentFile.ContentType, attachmentFile.Name);
  }

  public async Task<IActionResult> OnPostAddComment()
  {
    var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext!.User);
    if (CurrentCommentMessage != null)
    {
      await _sender.Send(new AddCommentCommand(CurrentCommentMessage, new MemberId(Guid.Parse(user.Id)), new TaskId(Id!.Value)));
    }
    
    return ViewComponent("CommentList", new { taskId = Id!.Value });
  }

  public async Task<IActionResult> OnPostRemoveComment(Guid commentId)
  {
    await _sender.Send(new DeleteCommentCommand(new TaskId(Id!.Value), new CommentId(commentId)));
    return ViewComponent("CommentList", new { taskId = Id!.Value });
  }
}