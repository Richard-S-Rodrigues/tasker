using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.Shared.Repository;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate.Repositories;

public interface ITaskRepository : IRepository<Task, TaskId>
{
  System.Threading.Tasks.Task<List<Task>> GetAllByBoardId(BoardId boardId);
  System.Threading.Tasks.Task AddChecklist(TaskChecklist taskChecklist);
  System.Threading.Tasks.Task UpdateChecklist(TaskChecklist taskChecklist);
  System.Threading.Tasks.Task<TaskChecklist> GetTaskChecklistById(TaskId taskId, TaskChecklistId taskChecklistId);
}