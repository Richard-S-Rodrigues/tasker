using Tasker.Domain.Shared;

namespace Tasker.Domain.TaskAggregate.ValueObjects;

public sealed class TaskId : ValueObject
{
  public TaskId(long? value)
  {
    Value = value;
  }
  public long? Value { get; private set; }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value!;      
  }
} 