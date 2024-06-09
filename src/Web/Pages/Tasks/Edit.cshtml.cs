using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tasker.Web.Pages.Tasks;

public class Edit : PageModel
{
  public Edit() {}

  [BindProperty(SupportsGet = true)]
  public Guid Id { get; set; }
  
  [BindProperty(SupportsGet = true)]
  public Guid BoardId { get; set; }
}