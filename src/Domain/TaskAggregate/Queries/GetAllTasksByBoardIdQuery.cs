using MediatR;
using Tasker.Domain.BoardAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate.Queries;

public record GetAllTasksByBoardIdQuery(BoardId boardId) : IRequest<List<Task>>
{
}