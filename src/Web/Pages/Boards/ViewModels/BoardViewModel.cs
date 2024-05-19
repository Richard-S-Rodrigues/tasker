using Tasker.Domain.BoardAggregate;
using Tasker.Domain.BoardAggregate.ValueObjects;

namespace Tasker.Web.Pages.Boards.ViewModels;

public class BoardViewModel
{
  public Guid? Id { get; set; }
  public string Name { get; set; } = "";
  public List<Member> Members { get; set; } = new();

  public static BoardViewModel ToViewModel(Board board)
  {
    return new()
    {
      Id = board.Id.Value,
      Name = board.Name,
      Members = board.Members
    };
  }

  public static Board ToEntity(BoardViewModel boardViewModel)
  {
    return new(new BoardId(boardViewModel.Id!.Value), boardViewModel.Name, boardViewModel.Members);
  }
}