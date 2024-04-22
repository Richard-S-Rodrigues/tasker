using Tasking.Domain.Shared;

namespace Tasking.Domain.BoardAggregate.ValueObjects;

public sealed class BoardId : ValueObject
{
  public BoardId(long value)
  {
    Value = value;
  }
  public long Value { get; }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;      
  }
} 