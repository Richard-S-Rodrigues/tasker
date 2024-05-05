using MediatR;
using Tasker.Domain.BoardAggregate.ValueObjects;

namespace Tasker.Domain.BoardAggregate.Commands;

public record UpdateBoardCommand(
  BoardId Id,
  string Name) : IRequest;