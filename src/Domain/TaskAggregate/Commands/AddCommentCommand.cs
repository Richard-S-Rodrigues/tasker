using MediatR;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate.Commands;

public record AddCommentCommand(
  string text, 
  MemberId memberId,
  TaskId taskId) : IRequest;