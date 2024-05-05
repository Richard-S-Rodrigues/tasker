using Tasker.Domain.Shared;

namespace Tasker.Domain.CommentAggregate.ValueObjects;

public sealed class CommentId : ValueObject
{
  public CommentId(Guid value)
  {
    Value = value;
  }
  public Guid Value { get; private set;}

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}