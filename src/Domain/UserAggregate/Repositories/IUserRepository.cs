using Tasker.Domain.Shared.Repository;
using Tasker.Domain.UserAggregate.ValueObjects;

namespace Tasker.Domain.UserAggregate.Repositories;

public interface IUserRepository : IRepository<User, UserId>
{

}