using MediatR;
using Tasker.Domain.BoardAggregate;
using Tasker.Domain.BoardAggregate.Queries;
using Tasker.Domain.BoardAggregate.Repositories;

namespace Tasker.Application.Boards.Queries;

public class GetBoardByIdQueryHandler : IRequestHandler<GetBoardByIdQuery, Board?>
{
  private readonly IBoardRepository _boardRepository;

  public GetBoardByIdQueryHandler(IBoardRepository boardRepository)
  {
    _boardRepository = boardRepository;
  }

  public async Task<Board?> Handle(GetBoardByIdQuery request, CancellationToken cancellationToken)
  {
    return await _boardRepository.Get(request.boardId);
  }
}
