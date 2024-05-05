using MediatR;
using Tasker.Domain.BoardAggregate;
using Tasker.Domain.BoardAggregate.Commands;
using Tasker.Domain.BoardAggregate.Repositories;

namespace Tasker.Application.Boards.Commands;

public class DeleteBoardCommandHandler : IRequestHandler<DeleteBoardCommand>
{
  private readonly IBoardRepository _boardRepository;

  public DeleteBoardCommandHandler(IBoardRepository boardRepository)
  {
    _boardRepository = boardRepository;
  }

  public async Task Handle(DeleteBoardCommand request, CancellationToken cancellationToken)
  {
    await _boardRepository.Delete(request.Id);
  }
}
