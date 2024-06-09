using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tasker.Web.Pages.Tasks;

public class Create : PageModel
{
  public Create() {}

  [BindProperty(SupportsGet = true)]
  public Guid BoardId { get; set; }
}