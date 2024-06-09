using MediatR;
using Tasker.Domain.TaskAggregate.Queries;
using Tasker.Domain.TaskAggregate.Repositories;

namespace Tasker.Application.Tasks.Queries;

public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Domain.TaskAggregate.Task>
{
  private readonly ITaskRepository _taskRepository;

  public GetTaskByIdQueryHandler(ITaskRepository taskRepository)
  {
    _taskRepository = taskRepository;
  }

  public async Task<Domain.TaskAggregate.Task> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
  {
    return await _taskRepository.Get(request.taskId);
  }
}
