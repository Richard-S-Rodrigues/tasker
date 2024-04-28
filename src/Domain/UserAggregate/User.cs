using Tasker.Domain.Shared;
using Tasker.Domain.UserAggregate.ValueObjects;

namespace Tasker.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
  public User(UserId id, string name) : base(id)
  {
    Name = name;
  }
  public string Name { get; private set; }

  #pragma warning disable
  public User() {}
  #pragma warning restore
}