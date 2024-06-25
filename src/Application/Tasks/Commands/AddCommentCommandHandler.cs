using MediatR;
using Tasker.Domain.TaskAggregate;
using Tasker.Domain.TaskAggregate.Commands;
using Tasker.Domain.TaskAggregate.Repositories;

namespace Tasker.Application.Tasks.Commands;

public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand>
{
  private readonly ITaskRepository _taskRepository;

  public AddCommentCommandHandler(ITaskRepository taskRepository)
  {
    _taskRepository = taskRepository;
  }

  public async System.Threading.Tasks.Task Handle(AddCommentCommand request, CancellationToken cancellationToken)
  {
    var comment = Comment.Create(
      request.text, 
      request.memberId,
      request.taskId
    );

    await _taskRepository.AddComment(comment);
  }
}
