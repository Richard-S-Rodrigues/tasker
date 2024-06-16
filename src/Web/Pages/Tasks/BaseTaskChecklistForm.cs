using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tasker.Web.Pages.Tasks.ViewModels;

namespace Tasker.Web.Pages.Tasks;

public class BaseTaskChecklistForm : PageModel
{
  public BaseTaskChecklistForm() {}

  [BindProperty(SupportsGet = true)]
  public Guid BoardId { get; set; }
  [BindProperty(SupportsGet = true)]
  public Guid TaskId { get; set; }
  [BindProperty(SupportsGet = true)]
  public Guid? Id { get; set; }
  [BindProperty]
  public TaskChecklistViewModel CurrentTaskChecklist { get; set; } = new();
}