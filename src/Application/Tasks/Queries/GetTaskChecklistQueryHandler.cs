using MediatR;
using Tasker.Domain.TaskAggregate;
using Tasker.Domain.TaskAggregate.Queries;
using Tasker.Domain.TaskAggregate.Repositories;

namespace Tasker.Application.Tasks.Queries;

public class GetTaskChecklistQueryHandler : IRequestHandler<GetTaskChecklistQuery, TaskChecklist>
{
  private readonly ITaskRepository _taskRepository;

  public GetTaskChecklistQueryHandler(ITaskRepository taskRepository)
  {
    _taskRepository = taskRepository;
  }

  public async Task<TaskChecklist> Handle(GetTaskChecklistQuery request, CancellationToken cancellationToken)
  {
    return await _taskRepository.GetTaskChecklistById(request.taskId, request.taskChecklistId);
  }
}
