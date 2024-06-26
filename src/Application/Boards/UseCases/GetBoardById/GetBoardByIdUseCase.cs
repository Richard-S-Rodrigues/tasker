using Tasker.Domain.BoardAggregate;
using Tasker.Domain.BoardAggregate.Repositories;
using Tasker.Domain.BoardAggregate.ValueObjects;

namespace Tasker.Application.Boards.UseCases.GetBoardById;

public class GetBoardByIdUseCase : IGetBoardByIdUseCase
{
  private readonly IBoardRepository _repository;
  public GetBoardByIdUseCase(IBoardRepository boardRepository)
  {
    _repository = boardRepository;
  }

  public async Task<Board> Execute(BoardId input)
  {
    var board = await _repository.Get(input);

    if (board is null)
    {
      throw new Exception("Board not found");
    }
     
    return board;
  }
}