using Tasker.Domain.Shared;

namespace Tasker.Domain.CommentAggregate.ValueObjects;

public sealed class CommentId : ValueObject
{
  public CommentId(long value)
  {
    Value = value;
  }
  public long Value { get; private set;}

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}