using Tasker.Domain.UserAggregate;
using Tasker.Domain.UserAggregate.Repositories;
using Tasker.Infrastructure.Context;

namespace Tasker.Infrastructure.Database.Repositories;

public class UserRepository : IUserRepository
{
  private readonly ApplicationDbContext _applicationDbContext;

  public UserRepository(ApplicationDbContext applicationDbContext)
  {
    _applicationDbContext = applicationDbContext;
  }

  public async Task Add(User entity)
  {
    _applicationDbContext.Add(entity);
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task Delete(User entity)
  {
    _applicationDbContext.Remove(entity);
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task<User> Update(User entity)
  {
    _applicationDbContext.Update(entity);
    await _applicationDbContext.SaveChangesAsync();
    return entity;
  }
}