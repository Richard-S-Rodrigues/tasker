using MediatR;
using Tasker.Domain.BoardAggregate;
using Tasker.Domain.BoardAggregate.Queries;
using Tasker.Domain.BoardAggregate.Repositories;

namespace Tasker.Application.Boards.Queries;

public class GetAllMembersByBoardIdQueryHandler : IRequestHandler<GetAllMembersByBoardIdQuery, List<Member>>
{
  private readonly IBoardRepository _boardRepository;

  public GetAllMembersByBoardIdQueryHandler(IBoardRepository boardRepository)
  {
    _boardRepository = boardRepository;
  }

  public async Task<List<Member>> Handle(GetAllMembersByBoardIdQuery request, CancellationToken cancellationToken)
  {
    return await _boardRepository.GetAllMembersByBoardId(request.boardId);
  }
}
