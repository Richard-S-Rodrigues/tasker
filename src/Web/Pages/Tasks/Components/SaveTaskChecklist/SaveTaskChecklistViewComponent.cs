using Microsoft.AspNetCore.Mvc;

namespace Tasker.Web.Pages.Tasks.Components.SaveTaskChecklist;

public class SaveTaskChecklistViewComponent : ViewComponent
{

  public IViewComponentResult Invoke(Guid boardId, Guid taskId, Guid? id, BaseTaskChecklistForm model)
  {
    ViewBag.CurrentPage = id.HasValue ? "EditTaskChecklist" : "CreateTaskChecklist";
    return View("/Pages/Tasks/Components/SaveTaskChecklist/Default.cshtml", model); 
  }
}
