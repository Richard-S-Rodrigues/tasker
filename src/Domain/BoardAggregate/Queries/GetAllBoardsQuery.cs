using MediatR;

namespace Tasker.Domain.BoardAggregate.Queries;

public record GetAllBoardsQuery() : IRequest<List<Board>>
{
}