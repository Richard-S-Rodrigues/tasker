using MediatR;
using Tasker.Domain.TaskAggregate.ValueObjects;
using Tasker.Domain.UserAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate.Commands;

public record UpdateTaskChecklistCommand(
  TaskChecklistId id,
  string title,
  string? description,
  bool isDone,
  TaskId taskId) : IRequest;