using MediatR;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate.Queries;

public record GetAttachmentFilesByTaskIdQuery(TaskId taskId) : IRequest<List<AttachmentFile>>
{
}