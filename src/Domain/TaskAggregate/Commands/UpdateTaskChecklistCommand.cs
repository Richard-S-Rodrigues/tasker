using MediatR;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate.Commands;

public record UpdateTaskChecklistCommand(
  TaskChecklistId id,
  string title,
  string? description,
  bool isDone,
  TaskId taskId) : IRequest;