using MediatR;
using Tasker.Domain.TaskAggregate;
using Tasker.Domain.TaskAggregate.Commands;
using Tasker.Domain.TaskAggregate.Repositories;
using Tasker.Domain.UserAggregate.ValueObjects;

namespace Tasker.Application.Tasks.Commands;

public class CreateTaskChecklistCommandHandler : IRequestHandler<CreateTaskChecklistCommand>
{
  private readonly ITaskRepository _taskRepository;

  public CreateTaskChecklistCommandHandler(ITaskRepository taskRepository)
  {
    _taskRepository = taskRepository;
  }

  public async System.Threading.Tasks.Task Handle(CreateTaskChecklistCommand request, CancellationToken cancellationToken)
  {
    var taskChecklist = TaskChecklist.Create(
      request.title,
      request.description,
      request.isDone,
      request.taskId,
      new UserId(Guid.NewGuid())
    );

    await _taskRepository.AddChecklist(taskChecklist);
  }
}
