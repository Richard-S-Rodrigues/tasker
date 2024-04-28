using Tasker.Domain.MemberAggregate;
using Tasker.Domain.MemberAggregate.Repositories;
using Tasker.Infrastructure.Context;

namespace Tasker.Infrastructure.Database.Repositories;

public class MemberRepository : IMemberRepository
{
  private readonly ApplicationDbContext _applicationDbContext;

  public MemberRepository(ApplicationDbContext applicationDbContext)
  {
    _applicationDbContext = applicationDbContext;
  }

  public async Task Add(Member entity)
  {
    _applicationDbContext.Add(entity);
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task Delete(Member entity)
  {
    _applicationDbContext.Remove(entity);
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task<Member> Update(Member entity)
  {
    _applicationDbContext.Update(entity);
    await _applicationDbContext.SaveChangesAsync();
    return entity;
  }
}