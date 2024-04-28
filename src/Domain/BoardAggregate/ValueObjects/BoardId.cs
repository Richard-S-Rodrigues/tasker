using Tasker.Domain.Shared;

namespace Tasker.Domain.BoardAggregate.ValueObjects;

public sealed class BoardId : ValueObject
{
  public BoardId(long? value)
  {
    Value = value;
  }
  public long? Value { get; private set; }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value!;      
  }
} 