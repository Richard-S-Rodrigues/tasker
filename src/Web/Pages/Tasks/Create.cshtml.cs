using MediatR;

namespace Tasker.Web.Pages.Tasks;

public class Create : BaseTaskForm
{
  public Create(ISender sender) : base(sender) {}
}