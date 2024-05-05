using MediatR;
using Tasker.Domain.BoardAggregate;
using Tasker.Domain.BoardAggregate.Commands;
using Tasker.Domain.BoardAggregate.Repositories;

namespace Tasker.Application.Boards.Commands;

public class CreateBoardCommandHandler : IRequestHandler<CreateBoardCommand>
{
  private readonly IBoardRepository _boardRepository;

  public CreateBoardCommandHandler(IBoardRepository boardRepository)
  {
    _boardRepository = boardRepository;
  }

  public async Task Handle(CreateBoardCommand request, CancellationToken cancellationToken)
  {
    var board = Board.Create(request.Name);

    await _boardRepository.Add(board);
  }
}
