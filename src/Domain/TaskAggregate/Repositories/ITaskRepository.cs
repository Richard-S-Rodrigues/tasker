using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.Shared.Repository;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate.Repositories;

public interface ITaskRepository : IRepository<Task, TaskId>
{
  Task<List<Task>> GetAllByBoardId(BoardId boardId);
}