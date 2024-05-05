using Tasker.Domain.Shared;

namespace Tasker.Domain.TaskAggregate.ValueObjects;

public sealed class TaskId : ValueObject
{
  public TaskId(Guid value)
  {
    Value = value;
  }
  public Guid Value { get; private set; }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;      
  }
} 