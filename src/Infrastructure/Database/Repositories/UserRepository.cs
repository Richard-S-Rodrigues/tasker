using Tasker.Domain.UserAggregate;
using Tasker.Domain.UserAggregate.Repositories;
using Tasker.Domain.UserAggregate.ValueObjects;
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
    _applicationDbContext.Users.Add(entity);
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task Delete(UserId id)
  {
    var user = await _applicationDbContext.Users.FindAsync(id);

    if (user is not null)
    {
      _applicationDbContext.Users.Remove(user);
    }
    
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task<User?> Get(UserId id)
  {
    return await _applicationDbContext.Users.FindAsync(id);
  }

  public async Task<User> Update(User entity)
  {
    _applicationDbContext.Users.Update(entity);
    await _applicationDbContext.SaveChangesAsync();
    return entity;
  }
}