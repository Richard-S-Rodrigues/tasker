using Tasker.Domain.TaskAggregate.Repositories;
using Tasker.Infrastructure.Context;

namespace Tasker.Infrastructure.Database.Repositories;

public class TaskRepository : ITaskRepository
{
  private readonly ApplicationDbContext _applicationDbContext;

  public TaskRepository(ApplicationDbContext applicationDbContext)
  {
    _applicationDbContext = applicationDbContext;
  }

  public async Task Add(Domain.TaskAggregate.Task entity)
  {
    _applicationDbContext.Add(entity);
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task Delete(Domain.TaskAggregate.Task entity)
  {
    _applicationDbContext.Remove(entity);
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task<Domain.TaskAggregate.Task> Update(Domain.TaskAggregate.Task entity)
  {
    _applicationDbContext.Update(entity);
    await _applicationDbContext.SaveChangesAsync();
    return entity;
  }
}