using Tasker.Domain.Shared;
using Tasker.Domain.UserAggregate.ValueObjects;

namespace Tasker.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
  public User(UserId id, string name) : base(id)
  {
    UserId = id;
    Name = name;
  }
  public UserId UserId { get; private set; }
  public string Name { get; private set; }
}