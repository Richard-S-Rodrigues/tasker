using Tasker.Domain.MemberAggregate;
using Tasker.Domain.MemberAggregate.Repositories;
using Tasker.Domain.MemberAggregate.ValueObjects;
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
    _applicationDbContext.Members.Add(entity);
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task Delete(MemberId id)
  {
    var member = await _applicationDbContext.Members.FindAsync(id);

    if (member is not null)
    {
      _applicationDbContext.Members.Remove(member);
    }
    
    await _applicationDbContext.SaveChangesAsync();
  }

  public async Task<Member> Update(Member entity)
  {
    _applicationDbContext.Members.Update(entity);
    await _applicationDbContext.SaveChangesAsync();
    return entity;
  }
}