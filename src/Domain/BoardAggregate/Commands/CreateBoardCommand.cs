using MediatR;

namespace Tasker.Domain.BoardAggregate.Commands;

public record CreateBoardCommand(
  string Name,
  Guid UserId,
  string UserName) : IRequest;