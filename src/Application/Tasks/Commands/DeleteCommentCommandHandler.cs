using MediatR;
using Tasker.Domain.TaskAggregate.Commands;
using Tasker.Domain.TaskAggregate.Repositories;

namespace Tasker.Application.Tasks.Commands;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
{
  private readonly ITaskRepository _taskRepository;

  public DeleteCommentCommandHandler(ITaskRepository taskRepository)
  {
    _taskRepository = taskRepository;
  }

  public async System.Threading.Tasks.Task Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
  {
    var comment = await _taskRepository.GetComment(request.TaskId, request.CommentId);
    if (comment is not null)
    {
      await _taskRepository.DeleteComment(comment);
    }
  }
}
