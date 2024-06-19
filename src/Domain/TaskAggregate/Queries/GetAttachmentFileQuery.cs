using MediatR;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate.Queries;

public record GetAttachmentFileQuery(TaskId taskId, AttachmentFileId attachmentFileId) : IRequest<AttachmentFile>
{
}