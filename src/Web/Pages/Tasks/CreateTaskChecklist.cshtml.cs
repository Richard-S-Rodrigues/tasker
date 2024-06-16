using MediatR;

namespace Tasker.Web.Pages.Tasks;

public class CreateTaskChecklist : BaseTaskChecklistForm
{
  public CreateTaskChecklist(ISender sender) : base(sender) {}
}