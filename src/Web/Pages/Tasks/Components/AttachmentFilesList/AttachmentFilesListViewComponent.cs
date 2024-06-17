using Microsoft.AspNetCore.Mvc;
using Tasker.Web.Pages.Tasks.ViewModels;

namespace Tasker.Web.Pages.Tasks.Components.AttachmentFilesList;

public class AttachmentFilesListViewComponent : ViewComponent
{

  public IViewComponentResult Invoke(List<AttachmentFileViewModel> model)
  {
    return View("/Pages/Tasks/Components/AttachmentFilesList/Default.cshtml", model); 
  }
}
