using MediatR;
using Tasker.Domain.BoardAggregate;
using Tasker.Domain.BoardAggregate.Commands;
using Tasker.Domain.BoardAggregate.Repositories;

namespace Tasker.Application.Boards.Commands;

public class UpdateBoardCommandHandler : IRequestHandler<UpdateBoardCommand>
{
  private readonly IBoardRepository _boardRepository;

  public UpdateBoardCommandHandler(IBoardRepository boardRepository)
  {
    _boardRepository = boardRepository;
  }

  public async Task Handle(UpdateBoardCommand request, CancellationToken cancellationToken)
  {
    var board = new Board(request.Id, request.Name, request.Members);

    await _boardRepository.Update(board);
  }
}
