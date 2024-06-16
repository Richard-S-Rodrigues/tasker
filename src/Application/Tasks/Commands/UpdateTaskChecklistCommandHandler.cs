using MediatR;
using Tasker.Domain.TaskAggregate;
using Tasker.Domain.TaskAggregate.Commands;
using Tasker.Domain.TaskAggregate.Repositories;
using Tasker.Domain.UserAggregate.ValueObjects;

namespace Tasker.Application.Tasks.Commands;

public class UpdateTaskChecklistCommandHandler : IRequestHandler<UpdateTaskChecklistCommand>
{
  private readonly ITaskRepository _taskRepository;

  public UpdateTaskChecklistCommandHandler(ITaskRepository taskRepository)
  {
    _taskRepository = taskRepository;
  }

  public async System.Threading.Tasks.Task Handle(UpdateTaskChecklistCommand request, CancellationToken cancellationToken)
  {
    var taskChecklist = new TaskChecklist(
      request.id,
      request.title,
      request.description,
      request.isDone,
      request.taskId,
      new UserId(Guid.NewGuid())
    );

    await _taskRepository.UpdateChecklist(taskChecklist);
  }
}
