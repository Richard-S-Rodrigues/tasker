using Tasker.Domain.Shared.Repository;
using Tasker.Domain.TaskAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate.Repositories;

public interface ITaskRepository : IRepository<Task, TaskId>
{

}