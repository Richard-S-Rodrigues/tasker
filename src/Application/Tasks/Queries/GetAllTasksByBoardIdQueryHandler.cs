using MediatR;
using Tasker.Domain.TaskAggregate.Queries;

namespace Tasker.Application.Tasks.Queries;

public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksByBoardIdQuery, List<Domain.TaskAggregate.Task>>
{
  private readonly ITaskQueries _taskQueries;

  public GetAllTasksQueryHandler(ITaskQueries taskQueries)
  {
    _taskQueries = taskQueries;
  }

  public async Task<List<Domain.TaskAggregate.Task>> Handle(GetAllTasksByBoardIdQuery request, CancellationToken cancellationToken)
  {
    return await _taskQueries.GetAllTasksByBoardId(request.boardId.Value);
  }
}
