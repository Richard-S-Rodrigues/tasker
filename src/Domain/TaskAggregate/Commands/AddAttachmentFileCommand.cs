using MediatR;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate.Commands;

public record AddAttachmentFileCommand(
  TaskId taskId, 
  string name, 
  string contentType, 
  string base64) : IRequest;