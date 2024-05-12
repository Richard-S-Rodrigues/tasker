using Tasker.Domain.BoardAggregate.ValueObjects;
using Tasker.Domain.TaskAggregate.Repositories;
using Tasker.Domain.TaskAggregate.ValueObjects;
using Tasker.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

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
    _applicationDbContext.Tasks.Add(entity);
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task Delete(TaskId id)
  {
    var task = await _applicationDbContext.Tasks.FindAsync(id);

    if (task is not null)
    {
      _applicationDbContext.Tasks.Remove(task);
    }
    
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task<Domain.TaskAggregate.Task> Update(Domain.TaskAggregate.Task entity)
  {
    _applicationDbContext.Tasks.Update(entity);
    await _applicationDbContext.SaveChangesAsync();
    return entity;
  }

  public async Task<Domain.TaskAggregate.Task?> Get(TaskId id)
  {
    return await _applicationDbContext.Tasks.FindAsync(id);
  }

  public async Task<List<Domain.TaskAggregate.Task>> GetAllByBoardId(BoardId boardId)
  {
    return await _applicationDbContext.Tasks.Where(t => t.BoardId == boardId && t.DeletedAt == null).ToListAsync();
  }
}