using Tasker.Domain.Shared;

namespace Tasker.Domain.BoardAggregate.ValueObjects;

public sealed class BoardId : ValueObject
{
  public BoardId(Guid value)
  {
    Value = value;
  }
  public Guid Value { get; private set; }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;      
  }
} 