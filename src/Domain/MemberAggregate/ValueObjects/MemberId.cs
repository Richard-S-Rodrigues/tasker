using Tasker.Domain.Shared;

namespace Tasker.Domain.MemberAggregate.ValueObjects;

public sealed class MemberId : ValueObject
{
  public MemberId(long? value)
  {
    Value = value;
  }
  public long? Value { get; private set;}

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value!;
  }
}