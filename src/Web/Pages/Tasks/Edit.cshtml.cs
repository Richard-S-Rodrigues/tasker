using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Tasker.Web.Pages.Tasks;

public class Edit : BaseTaskForm
{
  public Edit(ISender sender,  IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager) : base(sender, httpContextAccessor, userManager) {}
}