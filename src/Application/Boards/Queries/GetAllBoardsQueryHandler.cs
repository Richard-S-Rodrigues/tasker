using MediatR;
using Tasker.Domain.BoardAggregate;
using Tasker.Domain.BoardAggregate.Queries;
using Tasker.Domain.BoardAggregate.Repositories;

namespace Tasker.Application.Boards.Queries;

public class GetAllBoardsQueryHandler : IRequestHandler<GetAllBoardsQuery, List<Board>>
{
  private readonly IBoardRepository _boardRepository;

  public GetAllBoardsQueryHandler(IBoardRepository boardRepository)
  {
    _boardRepository = boardRepository;
  }

  public async Task<List<Board>> Handle(GetAllBoardsQuery request, CancellationToken cancellationToken)
  {
    return await _boardRepository.GetAll();
  }
}
