using Tasker.Domain.Shared;
using Tasker.Domain.UserAggregate.ValueObjects;

namespace Tasker.Domain.TaskAggregate.ValueObjects;

public sealed class Responsible : ValueObject
{
  public Responsible(
    UserId userId,
    TimeOnly estimatedTime,
    TimeOnly time)
  {
    UserId = userId;
    EstimatedTime = estimatedTime;
    Time = time;
  }
  public UserId UserId { get; private set; }
  public TimeOnly? EstimatedTime { get; private set; }
  public TimeOnly? Time { get; private set; }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return UserId;
    yield return EstimatedTime!;
    yield return Time!;
  }

  #pragma warning disable
  public Responsible() {}
  #pragma warning restore
}