using MediatR;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate.Queries;

public record GetCommentsByTaskIdQuery(TaskId TaskId) : IRequest<List<CommentDTO>>
{
}