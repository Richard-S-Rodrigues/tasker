using MediatR;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate.Queries;

public record GetTaskByIdQuery(TaskId taskId) : IRequest<Task>
{
}