using Tasking.Domain.Shared;

namespace Tasking.Domain.MemberAggregate.ValueObjects;

public sealed class MemberId : ValueObject
{
  public MemberId(long value)
  {
    Value = value;
  }
  public long Value { get; }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}