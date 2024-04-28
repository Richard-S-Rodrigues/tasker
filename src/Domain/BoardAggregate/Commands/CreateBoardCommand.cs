using ErrorOr;
using MediatR;

namespace Tasker.Domain.BoardAggregate.Commands;

public record CreateBoardCommand(
  string Name) : IRequest<ErrorOr<Board>>;