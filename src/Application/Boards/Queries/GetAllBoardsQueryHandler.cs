using MediatR;
using Tasker.Domain.BoardAggregate;
using Tasker.Domain.BoardAggregate.Queries;

namespace Tasker.Application.Boards.Queries;

public class GetAllBoardsQueryHandler : IRequestHandler<GetAllBoardsQuery, List<Board>>
{
  private readonly IBoardQueries _boardQueries;

  public GetAllBoardsQueryHandler(IBoardQueries boardQueries)
  {
    _boardQueries = boardQueries;
  }

  public async Task<List<Board>> Handle(GetAllBoardsQuery request, CancellationToken cancellationToken)
  {
    return await _boardQueries.GetAllBoards();
  }
}
