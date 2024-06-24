using MediatR;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.TaskAggregate;
using Tasker.Domain.TaskAggregate.Commands;
using Tasker.Domain.TaskAggregate.Repositories;

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
      new MemberId(Guid.NewGuid())
    );

    await _taskRepository.UpdateChecklist(taskChecklist);
  }
}
