using Tasking.Domain.Shared;
using Tasking.Domain.UserAggregate.ValueObjects;

namespace Tasking.Domain.UserAggregate;

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