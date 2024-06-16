using Microsoft.AspNetCore.Mvc;
using Tasker.Web.Pages.Tasks.ViewModels;

namespace Tasker.Web.Pages.Tasks.Components.TaskList;

public class TaskListViewComponent : ViewComponent
{

  public IViewComponentResult Invoke(List<TaskViewModel> model)
  {

    return View("/Pages/Tasks/Components/TaskList/Default.cshtml", model); 
  }
}
