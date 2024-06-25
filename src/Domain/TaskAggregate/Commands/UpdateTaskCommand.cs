using MediatR;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.TaskAggregate.Enums;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate.Commands;

public record UpdateTaskCommand(
  TaskId Id,
  BoardId BoardId,
  string Title,
  string? Description,
  TimeDetails TimeDetails,
  Status Status,
  Priority Priority,
  List<AttachmentFile> AttachmentFiles,
  List<Comment> Comments,
  List<TaskChecklist> TaskChecklists) : IRequest;