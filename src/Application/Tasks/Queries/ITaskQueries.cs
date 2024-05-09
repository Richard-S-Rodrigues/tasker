
namespace Tasker.Application.Tasks.Queries;

public interface ITaskQueries
{
  Task<List<Domain.TaskAggregate.Task>> GetAllTasksByBoardId(Guid boardId);
}