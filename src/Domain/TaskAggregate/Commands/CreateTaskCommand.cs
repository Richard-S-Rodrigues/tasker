using MediatR;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.TaskAggregate.Enums;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate.Commands;

public record CreateTaskCommand(
    BoardId boardId,
    string title,
    string? description,
    TimeDetails timeDetails,
    Status status, 
    Priority priority) : IRequest;