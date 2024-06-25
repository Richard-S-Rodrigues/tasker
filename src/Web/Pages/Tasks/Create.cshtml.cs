using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Tasker.Web.Pages.Tasks;

public class Create : BaseTaskForm
{
  public Create(ISender sender,  IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager) : base(sender, httpContextAccessor, userManager) {}
}