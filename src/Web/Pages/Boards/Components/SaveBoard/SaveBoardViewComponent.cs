using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasker.Domain.BoardAggregate.Queries;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Web.Pages.Boards.ViewModels;

namespace Tasker.Web.Pages.Boards.Components.SaveBoard;

public class SaveBoardViewComponent : ViewComponent
{
  private readonly ISender _sender;
  public SaveBoardViewComponent(ISender sender) 
  {
    _sender = sender;
  }

  public async Task<IViewComponentResult> InvokeAsync(Guid? id)
  {
    var board = new BoardViewModel();

    if (id.HasValue)
    {
      var result = await _sender.Send(new GetBoardByIdQuery(new BoardId(id.Value)));
      if (result is not null)
      {
        board = BoardViewModel.ToViewModel(result);
      }
    }

    return View("/Pages/Boards/Components/SaveBoard/Default.cshtml", board); 
  }
}
