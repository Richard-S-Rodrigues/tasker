using MediatR;
using Tasker.Domain.BoardAggregate.ValueObjects;

namespace Tasker.Domain.BoardAggregate.Queries;

public record GetAllMembersByBoardIdQuery(BoardId boardId) : IRequest<List<Member>>
{
}