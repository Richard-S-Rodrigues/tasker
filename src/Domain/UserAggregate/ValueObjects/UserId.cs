using Tasker.Domain.Shared;

namespace Tasker.Domain.UserAggregate.ValueObjects;

public sealed class UserId : ValueObject
{
  public UserId(Guid value)
  {
    Value = value;
  }
  public Guid Value { get; private set; }
  
  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}