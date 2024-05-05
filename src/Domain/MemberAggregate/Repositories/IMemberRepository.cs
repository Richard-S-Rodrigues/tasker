using Tasker.Domain.MemberAggregate.ValueObjects;
using Tasker.Domain.Shared.Repository;

namespace Tasker.Domain.MemberAggregate.Repositories;

public interface IMemberRepository : IRepository<Member, MemberId>
{

}