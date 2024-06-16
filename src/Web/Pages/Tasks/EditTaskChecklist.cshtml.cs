using MediatR;

namespace Tasker.Web.Pages.Tasks;

public class EditTaskChecklist : BaseTaskChecklistForm
{
  public EditTaskChecklist(ISender sender) : base(sender) {}
}