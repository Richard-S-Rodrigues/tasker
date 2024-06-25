using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tasker.Domain.TaskAggregate.Queries;
using Tasker.Domain.TaskAggregate.ValueObjects;
using Tasker.Web.Pages.Tasks.ViewModels;

namespace Tasker.Web.Pages.Tasks.Components.CommentList;

public class CommentListViewComponent : ViewComponent
{
  private readonly ISender _sender;
  private IHttpContextAccessor _httpContextAccessor;
  private readonly UserManager<IdentityUser> _userManager;
  public CommentListViewComponent(ISender sender, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager) 
  {
    _sender = sender;
    _httpContextAccessor = httpContextAccessor;
    _userManager = userManager;
  }

  public async Task<IViewComponentResult> InvokeAsync(Guid taskId)
  {
    var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext!.User);
    ViewBag.CurrentUserId = Guid.Parse(user.Id);
    var comments = await _sender.Send(new GetCommentsByTaskIdQuery(new TaskId(taskId)));
    return View("/Pages/Tasks/Components/CommentList/Default.cshtml", CommentViewModel.ToEnumerableViewModel(comments).ToList());
  }
}