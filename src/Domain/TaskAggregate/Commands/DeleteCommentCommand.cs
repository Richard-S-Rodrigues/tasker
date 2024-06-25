using MediatR;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate.Commands;

public record DeleteCommentCommand(TaskId TaskId, CommentId CommentId) : IRequest;