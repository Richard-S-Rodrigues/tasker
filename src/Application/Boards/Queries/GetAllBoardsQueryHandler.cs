using MediatR;
using Tasker.Domain.BoardAggregate.Queries;

namespace Tasker.Application.Boards.Queries;

public class GetAllBoardsQueryHandler : IRequestHandler<GetAllBoardsQuery, List<BoardDTO>>
{
  private readonly IBoardQueries _boardQueries;

  public GetAllBoardsQueryHandler(IBoardQueries boardQueries)
  {
    _boardQueries = boardQueries;
  }

  public async Task<List<BoardDTO>> Handle(GetAllBoardsQuery request, CancellationToken cancellationToken)
  {
    return await _boardQueries.GetAllBoards();
  }
}
