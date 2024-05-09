using Tasker.Domain.BoardAggregate.Queries;
using Tasker.Domain.BoardAggregate.ValueObjects;

namespace Tasker.Web.Pages.Boards.ViewModels;

public class BoardViewModel
{
  public Guid? Id { get; set; }
  public string Name { get; set; } = "";

  public static BoardViewModel ToViewModel(BoardDTO boardDTO)
  {
    return new()
    {
      Id = boardDTO.Id.Value,
      Name = boardDTO.Name
    };
  }

  public static Tasker.Domain.BoardAggregate.Board ToEntity(BoardViewModel boardViewModel)
  {
    return new(new BoardId(boardViewModel.Id!.Value), boardViewModel.Name);
  }
}