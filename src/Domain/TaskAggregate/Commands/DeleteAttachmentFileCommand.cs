using MediatR;

namespace Tasker.Domain.TaskAggregate.Commands;

public record DeleteAttachmentFileCommand(
  AttachmentFile attachmentFile) : IRequest;