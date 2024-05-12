using MediatR;
using Tasker.Domain.TaskAggregate.Queries;
using Tasker.Domain.TaskAggregate.Repositories;

namespace Tasker.Application.Tasks.Queries;

public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksByBoardIdQuery, List<Domain.TaskAggregate.Task>>
{
  private readonly ITaskRepository _taskRepository;

  public GetAllTasksQueryHandler(ITaskRepository taskRepository)
  {
    _taskRepository = taskRepository;
  }

  public async Task<List<Domain.TaskAggregate.Task>> Handle(GetAllTasksByBoardIdQuery request, CancellationToken cancellationToken)
  {
    return await _taskRepository.GetAllByBoardId(request.boardId);
  }
}
