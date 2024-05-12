using MediatR;
using Tasker.Domain.BoardAggregate.ValueObjects;

namespace Tasker.Domain.BoardAggregate.Queries;

public record GetBoardByIdQuery(BoardId boardId) : IRequest<Board?>
{
}