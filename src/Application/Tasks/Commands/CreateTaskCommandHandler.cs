using MediatR;
using Tasker.Domain.TaskAggregate;
using Tasker.Domain.TaskAggregate.Commands;
using Tasker.Domain.TaskAggregate.Enums;
using Tasker.Domain.TaskAggregate.Repositories;

namespace Tasker.Application.Tasks.Commands;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand>
{
  private readonly ITaskRepository _taskRepository;

  public CreateTaskCommandHandler(ITaskRepository taskRepository)
  {
    _taskRepository = taskRepository;
  }

  public async System.Threading.Tasks.Task Handle(CreateTaskCommand request, CancellationToken cancellationToken)
  {
    var task = Domain.TaskAggregate.Task.Create(
      request.boardId,
      request.title,
      request.description,
      request.timeDetails,
      request.status,
      request.priority,
      request.responsibles,
      new List<AttachmentFile>(),
      new List<Comment>(),
      new List<TaskChecklist>()
    );

    await _taskRepository.Add(task);
  }
}
