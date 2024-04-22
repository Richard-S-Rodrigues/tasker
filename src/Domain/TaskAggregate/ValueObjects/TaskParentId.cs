using Tasker.Domain.Shared;

namespace Tasker.Domain.TaskAggregate.ValueObjects;

public sealed class TaskParentId : ValueObject
{
  public TaskParentId(long? value)
  {
    Value = value;
  }
  public long? Value { get; }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value!;      
  }
} 