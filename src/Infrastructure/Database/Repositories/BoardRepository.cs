using Tasker.Domain.BoardAggregate;
using Tasker.Domain.BoardAggregate.Repositories;
using Tasker.Infrastructure.Context;

namespace Tasker.Infrastructure.Database.Repositories;

public class BoardRepository : IBoardRepository
{
  private readonly ApplicationDbContext _applicationDbContext;

  public BoardRepository(ApplicationDbContext applicationDbContext)
  {
    _applicationDbContext = applicationDbContext;
  }

  public async Task Add(Board entity)
  {
    _applicationDbContext.Boards.Add(entity);
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task Delete(Board entity)
  {
    _applicationDbContext.Boards.Remove(entity);
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task<Board> Update(Board entity)
  {
    _applicationDbContext.Boards.Update(entity);
    await _applicationDbContext.SaveChangesAsync();
    return entity;
  }
}