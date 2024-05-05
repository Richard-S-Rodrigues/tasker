using Tasker.Domain.Shared;
using Tasker.Domain.UserAggregate.ValueObjects;

namespace Tasker.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
  private User(UserId id, string name) : base(id)
  {
    Name = name;
  }
  public string Name { get; private set; }

  public static User Create(string name)
  {
    return new User(new UserId(Guid.NewGuid()), name);
  }

  #pragma warning disable
  public User() {}
  #pragma warning restore
}