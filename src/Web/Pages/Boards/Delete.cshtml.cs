using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tasker.Web.Pages.Boards;

public class Delete : PageModel
{
  public Delete() {}

  [BindProperty(SupportsGet = true)]
  public Guid Id { get; set; }
}