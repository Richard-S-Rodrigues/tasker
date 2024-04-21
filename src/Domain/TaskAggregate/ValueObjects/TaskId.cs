using Tasking.Domain.Shared;

namespace Tasking.Domain.TaskAggregate.ValueObjects;

public sealed class TaskId : ValueObject
{
  public TaskId(long value)
  {
    Value = value;
  }
  public long Value { get; }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;      
  }
} 