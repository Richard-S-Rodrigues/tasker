using MediatR;
using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.TaskAggregate;
using Tasker.Domain.TaskAggregate.Commands;
using Tasker.Domain.TaskAggregate.Repositories;

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
      new MemberId(Guid.NewGuid())
    );

    await _taskRepository.AddChecklist(taskChecklist);
  }
}
