using Tasker.Domain.Shared;

namespace Tasker.Domain.MemberAggregate.ValueObjects;

public sealed class MemberId : ValueObject
{
  public MemberId(Guid value)
  {
    Value = value;
  }
  public Guid Value { get; private set;}

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}