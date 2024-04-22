using Tasker.Domain.Shared;

namespace Tasker.Domain.UserAggregate.ValueObjects;

public sealed class UserId : ValueObject
{
  public UserId(long value)
  {
    Value = value;
  }
  public long Value { get; }
  
  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}