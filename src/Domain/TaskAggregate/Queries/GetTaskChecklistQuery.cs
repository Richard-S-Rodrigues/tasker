using MediatR;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate.Queries;

public record GetTaskChecklistQuery(TaskId taskId, TaskChecklistId taskChecklistId) : IRequest<TaskChecklist>
{
}