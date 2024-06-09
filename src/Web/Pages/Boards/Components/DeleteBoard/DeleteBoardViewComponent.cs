using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasker.Domain.BoardAggregate.Queries;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Web.Pages.Boards.ViewModels;

namespace Tasker.Web.Pages.Boards.Components.DeleteBoard;

public class DeleteBoardViewComponent : ViewComponent
{
  private readonly ISender _sender;
  public DeleteBoardViewComponent(ISender sender) 
  {
    _sender = sender;
  }

  public async Task<IViewComponentResult> InvokeAsync(Guid id)
  {
    
    var result = await _sender.Send(new GetBoardByIdQuery(new BoardId(id)));
    
    var board = BoardViewModel.ToViewModel(result);

    return View("/Pages/Boards/Components/DeleteBoard/Default.cshtml", board); 
  }
}
