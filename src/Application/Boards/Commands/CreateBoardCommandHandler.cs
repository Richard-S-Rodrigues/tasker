using MediatR;
using Tasker.Domain.BoardAggregate;
using Tasker.Domain.BoardAggregate.Commands;
using Tasker.Domain.BoardAggregate.Repositories;
using Tasker.Domain.BoardAggregate.ValueObjects;

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
    var board = Board.Create(request.Name, new List<Member>());
    
    await _boardRepository.Add(board);

    await _boardRepository.AddMemberToBoard(board.Id, new Member(new MemberId(request.UserId), board.Id, request.UserName, true));
  }
}
