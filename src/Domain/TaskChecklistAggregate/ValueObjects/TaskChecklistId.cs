using Tasker.Domain.Shared;

namespace Tasker.Domain.TaskChecklistAggregate.ValueObjects;

public sealed class TaskChecklistId : ValueObject
{
  public TaskChecklistId(Guid value)
  {
    Value = value;
  }
  public Guid Value { get; private set; }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;      
  }
} 