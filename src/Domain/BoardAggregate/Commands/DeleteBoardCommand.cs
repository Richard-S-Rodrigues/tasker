using MediatR;
using Tasker.Domain.BoardAggregate.ValueObjects;

namespace Tasker.Domain.BoardAggregate.Commands;

public record DeleteBoardCommand(
  BoardId Id) : IRequest;